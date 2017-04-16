"use strict";
var router_1 = require("@angular/router");
var signup_component_1 = require("./signup/signup.component");
var login_component_1 = require("./login/login.component");
var index_1 = require("./clients/index");
var index_2 = require("./guards/index");
var appRoutes = [
    { path: 'login', component: login_component_1.LoginComponent },
    { path: 'signup', component: signup_component_1.SignupComponent },
    { path: 'clients', component: index_1.ClientListComponent, canActivate: [index_2.AuthGuard] },
    { path: 'clients/:id', component: index_1.ClientComponent, canActivate: [index_2.AuthGuard] },
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map