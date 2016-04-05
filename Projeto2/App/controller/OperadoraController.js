angular.module("aplicacao").controller("OperadoraController", function ($scope, $http, $location) {

    $scope.novaOperadora = function (operadora) {
        $http.post("http://localhost:53957/api/Operadora", operadora).success(function () {
            $location.path("/Contatos");
        });
    };
    
    

});