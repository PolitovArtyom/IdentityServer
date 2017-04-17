"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
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
var http_1 = require("@angular/http");
require("rxjs/add/operator/map");
var base_service_1 = require("../services/base.service");
var RoleService = (function (_super) {
    __extends(RoleService, _super);
    function RoleService(http) {
        var _this = _super.call(this) || this;
        _this.http = http;
        //TODO How to inject service uri?
        _this.uri = "http://localhost:49536/";
        return _this;
    }
    RoleService.prototype.loadClientRoles = function (clientId) {
        var requestOptions = _super.prototype.getAuthHeader.call(this);
        return this.http.get(this.uri + '/api/role?clientId=' + clientId, requestOptions)
            .map(function (response) {
            var roles = response.json();
            return roles;
        });
    };
    RoleService.prototype.updateRole = function (role) {
        var requestOptions = _super.prototype.getAuthHeader.call(this);
        return this.http.put(this.uri + '/api/role', role, requestOptions);
    };
    RoleService.prototype.addRole = function (role) {
        var requestOptions = _super.prototype.getAuthHeader.call(this);
        return this.http.post(this.uri + '/api/role', role, requestOptions);
    };
    RoleService.prototype.deleteRole = function (roleId) {
        var requestOptions = _super.prototype.getAuthHeader.call(this);
        return this.http.delete(this.uri + '/api/role?id=' + roleId, requestOptions);
    };
    return RoleService;
}(base_service_1.ServiceBase));
RoleService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], RoleService);
exports.RoleService = RoleService;
//# sourceMappingURL=role.service.js.map