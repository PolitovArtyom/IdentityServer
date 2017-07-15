using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer.AuthorizationProvider.TestProvider.Models;

namespace IdentityServer.AuthorizationProvider.TestProvider
{
    internal class DbContext
    {
        private readonly string _connectionString;

        public DbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<User> GetUser(string userName)
        {
            try
            {
                var getUserCommand = $"SELECT * FROM Users u WHERE u.UserName = '{userName}'";
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SQLiteCommand(getUserCommand, connection);
                    var reader = await command.ExecuteReaderAsync();

                    User user = null;
                    while (await reader.ReadAsync())
                    {
                        user = new User()
                        {
                            Id = reader.GetInt64(0),
                            UserName = reader.GetString(1),
                            PasswordHash = reader.GetString(2)
                        };
                        break;
                    }
                    connection.Close();
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error accessing provider db", ex);
            }
        }

        public async Task<IEnumerable<Role>> GetUserRoles(long userId)
        {
            try
            {
                var getRolesCommand = $"SELECT r.Id, r.Name FROM UserRoles u INNER JOIN Roles r ON u.RoleId = r.Id WHERE u.UserId = {userId}";
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SQLiteCommand(getRolesCommand, connection);
                    var reader = await command.ExecuteReaderAsync();

                    var roles = new List<Role>();
                    while (await reader.ReadAsync())
                    {
                        roles.Add(new Role()
                        {
                            Id = reader.GetInt64(0),
                            Name = reader.GetString(1),
                        });
                    }
                    connection.Close();
                    return roles;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error accessing provider db", ex);
            }
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            try
            {
                var getRolesCommand = "SELECT * FROM Roles";
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SQLiteCommand(getRolesCommand, connection);
                    var reader = await command.ExecuteReaderAsync();

                    var roles = new List<Role>();
                    while (await reader.ReadAsync())
                    {
                        roles.Add(new Role()
                        {
                            Id = reader.GetInt64(0),
                            Name = reader.GetString(1),
                        });
                    }
                    connection.Close();
                    return roles;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error accessing provider db", ex);
            }
        }

        public async Task AddUser(string userName, string passwordHash, IEnumerable<Role> roles)
        {
            try
            {
                var insertUser = $"INSERT INTO USERS VALUES (null,'{userName}', '{passwordHash}'); SELECT last_insert_rowid() FROM USERS";
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    var inserUserCommand = new SQLiteCommand(insertUser, connection);
                    var userId = (long) await inserUserCommand.ExecuteScalarAsync();

                    if (roles.Any())
                    {
                        var stringBuilder = new StringBuilder("INSERT INTO UserRoles VALUES ");
                        foreach (var role in roles)
                        {
                            stringBuilder.Append($"({userId},{role.Id}), ");

                        }
                        stringBuilder.Remove(stringBuilder.Length - 2, 1);
                        stringBuilder.Append(";");

                        var insertUserRolesCommand = new SQLiteCommand(stringBuilder.ToString(), connection);
                        await insertUserRolesCommand.ExecuteNonQueryAsync();

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error accessing provider db", ex);
            }
        }

        public async Task<Role> GetRole(string id)
        {
            try
            {
                var getRolesCommand = $"SELECT r.Id, r.Name FROM Roles r WHERE r.Id = {id}";
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SQLiteCommand(getRolesCommand, connection);
                    var reader = await command.ExecuteReaderAsync();

                    Role role = null;
                    while (await reader.ReadAsync())
                    {
                        role = new Role()
                        {
                            Id = reader.GetInt64(0),
                            Name = reader.GetString(1)
                        };
                    }
                    connection.Close();
                    return role;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error accessing provider db", ex);
            }
        }
    }
}
