angular.module("aplicacao").controller("ListaContatosController", function ($scope, $http, Upload, $timeout, $location) {
    //modulo fileupload

    /////////////////////////////////////////
    $scope.appName = "Lista de Contatos";
    $scope.data = new Date();
    $scope.AddContato = function (contato) {
        $http.post("http://localhost:53957/api/Contato", contato).success(function (data, status) {
            delete $scope.contato;
            delete $scope.nomeOperadora;
            $scope.formContato.$setPristine();
            carregarContatos();
        });

    };

    $scope.NovaOperadora = function () {
        $location.path("/NovaOperadora");
    }
    $scope.ordernarPor = function (campo) {
        $scope.criterioOrdenacao = campo;
        $scope.crescOuDecr = !$scope.crescOuDecr;
    };

    $scope.nomeOperadoraGet = function (operadoraID) {
        var operadora = $scope.operadoras.filter(function (elemento) {
            return elemento.OperadoraID === operadoraID;
        });
        //console.log(operadora.length);
        if (operadora.length > 0)
            $scope.nomeOperadora = operadora[0].NomeOperadora;
        else
            delete $scope.nomeOperadora;
    };

    var carregarContatos = function () {
        $http.get("http://localhost:53957/api/Contato").success(function (data, status) {
            $scope.contatos = data;
        });
    };

    var carregarOperadoras = function () {
        $http.get("http://localhost:53957/api/Operadora").success(function (data, status) {
            $scope.operadoras = data;
        });
    };


    carregarContatos();
    carregarOperadoras();
});