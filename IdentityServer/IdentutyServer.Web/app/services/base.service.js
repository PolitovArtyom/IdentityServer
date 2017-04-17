"use strict";
var http_1 = require("@angular/http");
var ServiceBase = (function () {
    function ServiceBase() {
    }
    ServiceBase.prototype.getAuthHeader = function () {
        var user = localStorage.getItem('userToken').toString();
        var headers = new http_1.Headers();
        headers.append('Authorization', "Bearer " + user);
        var requestOptions = new http_1.RequestOptions({
            headers: headers
        });
        return requestOptions;
    };
    return ServiceBase;
}());
exports.ServiceBase = ServiceBase;
//# sourceMappingURL=base.service.js.map