angular.module("listaTelefonica").filter("name", function(){
	return function (input){
		var listaDeNomes = input.split(" ");
		var listaDeNomesFormatada = listaDeNomes.map(function(nome){
			if(/(da|de|dos|DA|DE|DOS|Da|De|Dos)/.test(nome)) return nome.toLowerCase();
			return nome.charAt(0).toUpperCase() + nome.substring(1).toLowerCase();
		})
		
		return listaDeNomesFormatada.join(" ");
	};
});
angular.module("listaTelefonica").filter("ellipsis", function(){
	return function (input, size){
		//console.log(input.length)
		if (input.length <= size) return input;
		var output = input.substring(0, (size || 3)) + "...";
		return output;

	};

});