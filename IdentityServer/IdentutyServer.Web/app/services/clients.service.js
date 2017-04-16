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
var http_1 = require("@angular/http");
require("rxjs/add/operator/map");
var ClientService = (function () {
    function ClientService(http) {
        this.http = http;
        this.uri = "http://localhost:49536/";
    }
    ClientService.prototype.getClients = function () {
        var requestOptions = this.getOptions();
        return (this.http.get(this.uri + '/api/client', requestOptions));
    };
    ClientService.prototype.getClient = function (id) {
        var requestOptions = this.getOptions();
        return this.http.get(this.uri + '/api/client/' + id, requestOptions)
            .map(function (response) {
            var client = response.json();
            return client;
        });
    };
    ClientService.prototype.updateClient = function (client) {
        var requestOptions = this.getOptions();
        return this.http.put(this.uri + '/api/client/', client, requestOptions);
    };
    ClientService.prototype.addClient = function (client) {
        var requestOptions = this.getOptions();
        return this.http.post(this.uri + '/api/client/', client, requestOptions);
    };
    ClientService.prototype.deleteClient = function (clientId) {
        var requestOptions = this.getOptions();
        return this.http.delete(this.uri + '/api/client/' + clientId, requestOptions);
    };
    ClientService.prototype.getOptions = function () {
        var user = localStorage.getItem('userToken').toString();
        var headers = new http_1.Headers();
        headers.append('Authorization', "Bearer " + user);
        var requestOptions = new http_1.RequestOptions({
            headers: headers
        });
        return requestOptions;
    };
    return ClientService;
}());
ClientService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], ClientService);
exports.ClientService = ClientService;
//# sourceMappingURL=clients.service.js.map