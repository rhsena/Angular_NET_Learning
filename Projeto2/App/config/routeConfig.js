angular.module("aplicacao").config(function ($routeProvider) {
    $routeProvider.when("/Contatos", {
        templateUrl: "Contatos.html", 
        controller: "ListaContatosController"
    });

    $routeProvider.when("/NovaOperadora", {
        templateUrl: "NovaOperadora.html",
        controller: "OperadoraController"
    });

    $routeProvider.otherwise({redirectTo: "/Contatos"});

});