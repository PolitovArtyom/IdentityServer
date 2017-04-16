"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var app_routing_1 = require("./app.routing");
var index_1 = require("./directives/index");
var index_2 = require("./clients/index");
var signup_component_1 = require("./signup/signup.component");
var login_component_1 = require("./login/login.component");
var index_3 = require("./services/index");
var index_4 = require("./guards/index");
var app_component_1 = require("./app.component");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            http_1.HttpModule,
            app_routing_1.routing],
        declarations: [
            app_component_1.AppComponent,
            signup_component_1.SignupComponent,
            login_component_1.LoginComponent,
            index_1.AlertComponent,
            index_2.ClientListComponent,
            index_2.ClientComponent,
            index_1.HeaderComponent
        ],
        bootstrap: [app_component_1.AppComponent],
        providers: [
            index_4.AuthGuard,
            index_3.UserService,
            index_3.AlertService,
            index_3.ClientService
        ]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map