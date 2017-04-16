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
var index_3 = require("../models/index");
var SignupComponent = (function () {
    function SignupComponent(router, userService, alertService) {
        this.router = router;
        this.userService = userService;
        this.alertService = alertService;
        this.user = new index_3.User();
        this.loading = false;
    }
    SignupComponent.prototype.register = function () {
        var _this = this;
        this.loading = true;
        this.userService.register(this.user)
            .subscribe(function (data) {
            _this.loading = true;
            _this.alertService.success('Registration successful. Redirecting to login page...', true);
            setTimeout(function () { return _this.router.navigate(['/login']); }, 2000);
        }, function (error) {
            _this.alertService.error(error);
            _this.loading = false;
        });
    };
    return SignupComponent;
}());
SignupComponent = __decorate([
    core_1.Component({
        selector: 'my-app',
        moduleId: module.id,
        providers: [index_1.UserService],
        templateUrl: 'signup.component.html'
    }),
    __metadata("design:paramtypes", [router_1.Router,
        index_1.UserService,
        index_2.AlertService])
], SignupComponent);
exports.SignupComponent = SignupComponent;
//# sourceMappingURL=signup.component.js.map