'use strict';
app.factory('clientsService', ['$http', function ($http) {
    
    //TODO почему здесь определяем serviceBase? так не надо
    var serviceBase = 'http://localhost:49536/';
    var clientsServiceFactory = {};

    var getClients = function (id) {
        var request = serviceBase + "api/client";
        if (typeof id === 'number')
            request += "?id=" + id;
       
        return $http.get(request).then(function (results) {
            return results;
        });
    };

    clientsServiceFactory.getClients = getClients;

    return clientsServiceFactory;

}]);