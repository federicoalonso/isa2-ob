Feature: Compra de snacks
Como usuario que está realizando la compra de tickets
Quiero poder comprar snacks 
Para disfrutarlos durante el evento sin necesidad de abonarlos en el lugar


@validBuy
Scenario: Compra de un Snack correcta, con usuario Espectador
	Given un usuario "Espectador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "2"
	When solicito la compra del "Snacks"
	Then verifico el mensaje con el codigo "200"

Scenario: Compra de dos Snacks correcta, con usuario Espectador
	Given un usuario "Espectador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "2"
	And el nombre del segundo producto "Lays"
	And con id "2" 
	And la cantidad de compra del segundo producto "4"
	When solicito la compra de varios "Snacks"
	Then verifico el mensaje con el codigo "200"

Scenario: Compra de un Snack correcta, con usuario Vendedor
	Given un usuario "Vendedor" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "2"
	When solicito la compra del "Snacks"
	Then verifico el mensaje con el codigo "200"

Scenario: Compra de dos Snacks correcta, con usuario Vendedor
	Given un usuario "Vendedor" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "2"
	And el nombre del segundo producto "Lays"
	And con id "2" 
	And la cantidad de compra del segundo producto "4"
	When solicito la compra de varios "Snacks"
	Then verifico el mensaje con el codigo "200"

Scenario: Compra de un Snack correcta, con usuario Administrador
	Given un usuario "Administrador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "2"
	When solicito la compra del "Snacks"
	Then verifico el mensaje con el codigo "200"

Scenario: Compra de dos Snacks correcta, con usuario Administrador
	Given un usuario "Administrador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "2"
	And el nombre del segundo producto "Lays"
	And con id "2" 
	And la cantidad de compra del segundo producto "4"
	When solicito la compra de varios "Snacks"
	Then verifico el mensaje con el codigo "200"

Scenario: Compra de un Snack incorrecta, con usuario Acomodador (sin permisos)
	Given un usuario "Acomodador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "2"
	When solicito la compra del "Snacks"
	Then verifico el mensaje con el codigo "403"

Scenario: Compra de dos Snacks incorrecta, con usuario Acomodador (sin permisos)
	Given un usuario "Acomodador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "2"
	And el nombre del segundo producto "Lays"
	And con id "2" 
	And la cantidad de compra del segundo producto "4"
	When solicito la compra de varios "Snacks"
	Then verifico el mensaje con el codigo "403"

Scenario: Compra de un Snack incorrecta, con usuario Artista (sin permisos)
	Given un usuario "Artista" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "2"
	When solicito la compra del "Snacks"
	Then verifico el mensaje con el codigo "403"

Scenario: Compra de dos Snacks incorrecta, con usuario Artista (sin permisos)
	Given un usuario "Artista" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "2"
	And el nombre del segundo producto "Lays"
	And con id "2" 
	And la cantidad de compra del segundo producto "4"
	When solicito la compra de varios "Snacks"
	Then verifico el mensaje con el codigo "403"

Scenario: Compra de un Snack incorrecta, con usuario Espectador, snackId inexistente
	Given un usuario "Espectador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "100" 
	And la cantidad de compra "2"
	When solicito la compra del "Snacks"
	Then verifico el mensaje con el codigo "404"

Scenario: Compra de dos Snacks incorrecta, con usuario Espectador, snackId inexistente
	Given un usuario "Espectador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "100" 
	And la cantidad de compra "2"
	And el nombre del segundo producto "Lays"
	And con id "2000" 
	And la cantidad de compra del segundo producto "4"
	When solicito la compra de varios "Snacks"
	Then verifico el mensaje con el codigo "404"

Scenario: Compra de un Snack incorrecta, cantidad de snacks mayor al stock
	Given un usuario "Espectador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "20000000"
	When solicito la compra del "Snacks"
	Then verifico el mensaje con el codigo "404"

Scenario: Compra de dos Snacks incorrecta, cantidad de snacks mayor al stock
	Given un usuario "Espectador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "100" 
	And la cantidad de compra "2"
	And el nombre del segundo producto "Lays"
	And con id "2000" 
	And la cantidad de compra del segundo producto "4"
	When solicito la compra de varios "Snacks"
	Then verifico el mensaje con el codigo "404"

Scenario: Compra de un Snack incorrecta, cantidad de snacks negativa
	Given un usuario "Espectador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "-20000"
	When solicito la compra del "Snacks"
	Then verifico el mensaje con el codigo "404"

Scenario: Compra de dos Snacks incorrecta, cantidad de snacks negativa
	Given un usuario "Espectador" logueado en el sistema
	And el nombre del producto "Doritos"
	And de id "1" 
	And la cantidad de compra "-2"
	And el nombre del segundo producto "Lays"
	And con id "2" 
	And la cantidad de compra del segundo producto "-4"
	When solicito la compra de varios "Snacks"
	Then verifico el mensaje con el codigo "404"