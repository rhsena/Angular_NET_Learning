angular.module("listaTelefonica").controller("ListaTelefonicaController", function($scope, $filter, lowercaseFilter){
			$scope.app = "Lista Telefonica";
			$scope.contatos = [ 
				{ nome: "James",  telefone: "9999-0007" , operadora: { nome: "Vivo", codigo: 15 , tipo: "Celular" }, cor: "green", data: new Date()},
				{ nome: lowercaseFilter("Vesper"), telefone: "9999-1119" , operadora: { nome: "Claro", codigo: 21 , tipo: "Celular"}, cor: "blue", data: new Date()},
				{ nome: $filter('uppercase')("Mr. White"), telefone: "9999-0001" , operadora: { nome: "GVT", codigo: 25 , tipo: "Fixo"}, cor: "orange", data: new Date()} 
			];
			$scope.operadoras = [
 				{ nome: "Vivo", codigo: 15 , tipo: "Celular", preco: 1},
 				{ nome: "Oi", codigo: 31 , tipo: "Celular", preco: 2},
 				{ nome: "Claro", codigo: 21 , tipo: "Celular", preco: 1 },
 				{ nome: "Tim", codigo: 35 , tipo: "Celular", preco: 2},
 				{ nome: "GVT", codigo: 25 , tipo: "Fixo", preco: 2},
 				{ nome: "Embratel", codigo: 11 , tipo: "Fixo", preco: 3}
			];
			$scope.adicionarContato = function  (contato) {
				$scope.contatos.push(angular.copy(contato));			
				delete $scope.contato;
				$scope.contatoForm.$setPristine();
			};
			$scope.apagarContato = function (contatos){
				$scope.contatos = contatos.filter(function(contato){
					if(!contato.selecionado) return contato;
				})	
			};
			$scope.isContatoSelecionado = function(contatos){
			   return contatos.some( function (contato){
			  		return contato.selecionado;
			  	})
			  	//console.log(isContatoSelecionado);
			};
			$scope.ordernarPor = function(campo){
				$scope.criterioDeOrdenacao = campo;
				$scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
			};		
		});