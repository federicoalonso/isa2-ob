Feature: Baja de snack
	Como usuario administrador, 
	quiero dar de baja un snack a partir de su id
	para dejar de ofrecerlo a los usuarios.


@validDelete
Scenario: Baja de snack correcto
	Given un usuario con rol "Administrador"
	When solicito la baja de "Snacks" de id existente 
	Then Veo el mensaje con el codigo "200"

Scenario: Baja de snack incorrecta, usuario sin credenciales habilitadas Acomodador
	Given un "Acomodador" logueado en el sistema
	When solicito la baja de "Snacks" de id existente 
	Then Veo el mensaje con el codigo "403"

Scenario: Baja de snack incorrecta, usuario sin credenciales habilitadas Vendedor
	Given un "Vendedor" logueado en el sistema
	When solicito la baja de "Snacks" de id existente 
	Then Veo el mensaje con el codigo "403"

Scenario: Baja de snack incorrecta, usuario sin credenciales habilitadas Espectador
	Given un "Espectador" logueado en el sistema
	When solicito la baja de "Snacks" de id existente 
	Then Veo el mensaje con el codigo "403"

Scenario: Baja de snack incorrecta, usuario sin credenciales habilitadas Artista
	Given un "Artista" logueado en el sistema
	When solicito la baja de "Snacks" de id existente 
	Then Veo el mensaje con el codigo "403"

Scenario: Baja de snack incorrecta, snack inexistente
	Given un "Artista" logueado en el sistema
	When solicito la baja de "Snacks" de id que no existe "99987"
	Then Veo el mensaje con el codigo "403"

