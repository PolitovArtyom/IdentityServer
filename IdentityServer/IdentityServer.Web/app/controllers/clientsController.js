'use strict';
app.controller('clientsController', ['$scope', '$location', '$timeout', 'clientsService', function ($scope, $location, $timeout, clientsService) {

    $scope.success = false;
    $scope.message = "";
    $scope.clients = [];
    $scope.clientModel = {
        id: "",
        Name: "",
        Secret: "",
        Callback: "",
        LogoutPage: "",
        Description: ""
    };
    $scope.clientsCount = 0;
       
   

    $scope.GetClients = function () {

        clientsService.getClients($scope.clientModel.id).then(function (result) {
            $scope.success = true;
           
            if (result.status === 200) {
                $scope.clients = result.data;
                $scope.clientsCount = result.data.length;
            }
               
        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to retreive clients due to:" + errors.join(' ');
         });
    };

}]);