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
var Rx1 = require("../../node_modules/rxjs/Rx");
var UserService = (function () {
    function UserService(http) {
        this.http = http;
        this.authenticated = new Rx1.BehaviorSubject(null);
        this.uri = "http://localhost:49536";
    }
    UserService.prototype.login = function (user) {
        var _this = this;
        var headers = new http_1.Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        var requestOptions = new http_1.RequestOptions({
            headers: headers
        });
        var data = "grant_type=password&username=" + user.userName + "&password=" + user.password;
        return this.http.post(this.uri + '/token', data, requestOptions)
            .map(function (response) {
            // login successful if there's a jwt token in the response
            var responseUser = response.json();
            if (responseUser && responseUser.access_token) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('userToken', responseUser.access_token);
                localStorage.setItem('userName', user.userName);
                _this.authenticated.next(true);
            }
        });
    };
    UserService.prototype.logout = function () {
        // remove user from local storage to log user out
        localStorage.removeItem('userToken');
        localStorage.removeItem('userName');
        this.authenticated.next(false);
    };
    UserService.prototype.register = function (user) {
        return this.http.post(this.uri + '/api/account/Register', user);
    };
    UserService.prototype.jwt = function () {
        // create authorization header with jwt token
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser && currentUser.token) {
            var headers = new http_1.Headers({ 'Authorization': 'Bearer ' + currentUser.token });
            return new http_1.RequestOptions({ headers: headers });
        }
    };
    return UserService;
}());
UserService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], UserService);
exports.UserService = UserService;
//# sourceMappingURL=users.service.js.map