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
var RolesComponent = (function () {
    function RolesComponent(router, alertService, roleService) {
        this.router = router;
        this.alertService = alertService;
        this.roleService = roleService;
        this.loading = false;
        this.roles = new Array();
    }
    Object.defineProperty(RolesComponent.prototype, "clientId", {
        set: function (id) {
            if (id) {
                this._clientId = 0;
                this.loadRoles(id);
            }
        },
        enumerable: true,
        configurable: true
    });
    RolesComponent.prototype.loadRoles = function (clientId) {
        var _this = this;
        this.loading = true;
        this.roleService.loadClientRoles(clientId)
            .subscribe(function (data) {
            _this.loading = false;
            _this.roles = data;
        }, function (error) {
            _this.alertService.error(error);
            _this.loading = false;
            _this.roles = new Array();
        });
    };
    RolesComponent.prototype.modifyRole = function (clientId) {
        var _this = this;
        this.loading = true;
        this.roleService.loadClientRoles(clientId)
            .subscribe(function (data) {
            _this.loading = false;
            _this.roles = data;
        }, function (error) {
            _this.alertService.error(error);
            _this.loading = false;
            _this.roles = new Array();
        });
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
//# sourceMappingURL=roles.component.js.map