angular.module("listaTelefonica").controller("novoContatoController", function($scope, $filter, lowercaseFilter,$location){
		
			$scope.operadoras = [
 				{ nome: "Vivo", codigo: 15 , tipo: "Celular", preco: 1},
 				{ nome: "Oi", codigo: 31 , tipo: "Celular", preco: 2},
 				{ nome: "Claro", codigo: 21 , tipo: "Celular", preco: 1 },
 				{ nome: "Tim", codigo: 35 , tipo: "Celular", preco: 2},
 				{ nome: "GVT", codigo: 25 , tipo: "Fixo", preco: 2},
 				{ nome: "Embratel", codigo: 11 , tipo: "Fixo", preco: 3}
			];
			$scope.adicionarContato = function  (contato) {
				ListaTelefonicaController.adicionarContato(contato);
			};
	
		});