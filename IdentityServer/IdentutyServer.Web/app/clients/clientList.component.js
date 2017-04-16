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
var index_1 = require("../services/index");
var index_2 = require("../services/index");
var ClientListComponent = (function () {
    function ClientListComponent(router, alertService, clientService) {
        this.router = router;
        this.alertService = alertService;
        this.clientService = clientService;
        this.loading = false;
        this.clients = new Array();
        this.loadClients();
    }
    ClientListComponent.prototype.loadClients = function () {
        var _this = this;
        this.loading = true;
        this.clientService.getClients()
            .subscribe(function (data) {
            _this.loading = false;
            var mapped = data.json();
            _this.clients = mapped;
        }, function (error) {
            _this.alertService.error(error);
            _this.loading = false;
            _this.clients = new Array();
        });
    };
    ClientListComponent.prototype.deleteClient = function (clientId) {
        var _this = this;
        this.loading = true;
        this.clientService.deleteClient(clientId)
            .subscribe(function (data) {
            _this.loading = false;
            _this.loadClients();
        }, function (error) {
            _this.alertService.error(error);
            _this.loading = false;
        });
    };
    return ClientListComponent;
}());
ClientListComponent = __decorate([
    core_1.Component({
        selector: 'my-app',
        moduleId: module.id,
        providers: [index_1.ClientService],
        templateUrl: 'clientList.component.html'
    }),
    __metadata("design:paramtypes", [router_1.Router,
        index_2.AlertService,
        index_1.ClientService])
], ClientListComponent);
exports.ClientListComponent = ClientListComponent;
//# sourceMappingURL=clientList.component.js.map