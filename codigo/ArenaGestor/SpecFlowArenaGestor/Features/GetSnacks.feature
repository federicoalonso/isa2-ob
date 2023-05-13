Feature: Obtener snacks
    Como usuario que está realizando la compra de tickets
	Quiero poder obtener la lista de snacks disponible para compra
	Para poder comprar algo y disfrutarlo durante el evento

@validAdd
Scenario: Obtener snacks correcto, usuario Administrador
	Given un usuario "Administrador"
	When solicito la lista disponible de "Snacks"
	Then veo el mensaje de la obtencion con el codigo "200"

Scenario: Obtener snacks correcto, usuario Espectador
	Given un usuario "Espectador"
	When solicito la lista disponible de "Snacks"
	Then veo el mensaje de la obtencion con el codigo "200"

Scenario: Obtener snacks correcto, usuario Vendedor
	Given un usuario "Vendedor"
	When solicito la lista disponible de "Snacks"
	Then veo el mensaje de la obtencion con el codigo "200"

Scenario: Obtener un snack por id correcto, usuario Administrador
	Given un usuario "Administrador"
	When solicito el "Snacks" de id "1"
	Then veo el mensaje de la obtencion con el codigo "200"

Scenario: Obtener un snack por id correcto, usuario Espectador
	Given un usuario "Espectador"
	When solicito el "Snacks" de id "1"
	Then veo el mensaje de la obtencion con el codigo "200"

Scenario: Obtener un snack por id correcto, usuario Vendedor
	Given un usuario "Vendedor"
	When solicito el "Snacks" de id "1"
	Then veo el mensaje de la obtencion con el codigo "200"

Scenario: Obtener snacks incorrecto, usuario Artista
	Given un usuario "Artista"
	When solicito la lista disponible de "Snacks"
	Then veo el mensaje de la obtencion con el codigo "403"

Scenario: Obtener snacks incorrecto, usuario Acomodador
	Given un usuario "Acomodador"
	When solicito la lista disponible de "Snacks"
	Then veo el mensaje de la obtencion con el codigo "403"

Scenario: Obtener un snack por id incorrecto, usuario Artista
	Given un usuario "Artista"
	When solicito el "Snacks" de id "1"
	Then veo el mensaje de la obtencion con el codigo "403"

Scenario: Obtener un snack por id incorrecto, usuario Acomodador
	Given un usuario "Acomodador"
	When solicito el "Snacks" de id "1"
	Then veo el mensaje de la obtencion con el codigo "403"

Scenario: Obtener un snack por id incorrecto, usuario Administrador con id inexistente
	Given un usuario "Administrador"
	When solicito el "Snacks" de id "4561"
	Then veo el mensaje de la obtencion con el codigo "404"

Scenario: Obtener un snack por id incorrecto, usuario Espectador con id inexistente
	Given un usuario "Espectador"
	When solicito el "Snacks" de id "4561"
	Then veo el mensaje de la obtencion con el codigo "404"

Scenario: Obtener un snack por id incorrecto, usuario Vendedor con id inexistente
	Given un usuario "Vendedor"
	When solicito el "Snacks" de id "4561"
	Then veo el mensaje de la obtencion con el codigo "404"