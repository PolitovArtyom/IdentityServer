"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var index_1 = require("../../services/index");
var index_2 = require("../../models/index");
var RolesComponent = (function () {
    function RolesComponent(router, alertService, roleService) {
        this.router = router;
        this.alertService = alertService;
        this.roleService = roleService;
        this.loading = false;
        this.roleRows = new Array();
    }
    Object.defineProperty(RolesComponent.prototype, "clientId", {
        set: function (id) {
            if (id) {
                this._clientId = id;
                this.loadRoles();
            }
        },
        enumerable: true,
        configurable: true
    });
    RolesComponent.prototype.loadRoles = function () {
        var _this = this;
        this.loading = true;
        this.roleService.loadClientRoles(this._clientId)
            .subscribe(function (data) {
            _this.loading = false;
            _this.roleRows = data.map(function (role) {
                var mapped = new RoleRow();
                mapped.role = role;
                return mapped;
            });
            ;
        }, function (error) { return _this.processError(error); });
    };
    RolesComponent.prototype.newRole = function () {
        var newRoleRow = new RoleRow();
        newRoleRow.isLocked = false;
        newRoleRow.role = new index_2.Role();
        newRoleRow.role.clientId = this._clientId;
        this.roleRows.push(newRoleRow);
    };
    RolesComponent.prototype.saveRole = function (roleRow) {
        var _this = this;
        roleRow.isLocked = true;
        this.loading = true;
        var response;
        if (roleRow.role.id)
            response = this.roleService.updateRole(roleRow.role);
        else {
            response = this.roleService.addRole(roleRow.role);
        }
        response.subscribe(function (data) {
            _this.loading = false;
            _this.loadRoles();
        }, function (error) { return _this.processError(error); });
    };
    RolesComponent.prototype.cancel = function () {
        this.loadRoles();
    };
    RolesComponent.prototype.deleteRole = function (roleId) {
        var _this = this;
        this.roleService.deleteRole(roleId)
            .subscribe(function (data) { return _this.loadRoles(); }, function (error) { return _this.processError(error); });
    };
    RolesComponent.prototype.processError = function (error) {
        this.alertService.error(error);
        this.loading = false;
        this.roleRows = new Array();
    };
    return RolesComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Number),
    __metadata("design:paramtypes", [Number])
], RolesComponent.prototype, "clientId", null);
RolesComponent = __decorate([
    core_1.Component({
        selector: 'roles-list',
        moduleId: module.id,
        providers: [index_1.RoleService],
        templateUrl: 'roles.component.html'
    }),
    __metadata("design:paramtypes", [router_1.Router,
        index_1.AlertService,
        index_1.RoleService])
], RolesComponent);
exports.RolesComponent = RolesComponent;
var RoleRow = (function () {
    function RoleRow() {
        this.isLocked = true;
    }
    return RoleRow;
}());
//# sourceMappingURL=roles.component.js.map