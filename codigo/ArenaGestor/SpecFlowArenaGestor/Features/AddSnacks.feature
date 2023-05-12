Feature: Alta de snack
	Como usuario administrador, 
	quiero dar de alta un nuevo snack con su descripción, precio y cantidad 
	para poder ofrecerlo a los usuarios.


@validAdd
Scenario: Alta de snack correcto
	Given un "Administrador" logueado en el sistema
	And el nombre "Mani Japones"
	And el precio "50" 
	And la cantidad "200"
	When solicito el alta del "Snacks" generado con esos valores
	Then Veo el mensaje con el codigo "200"

Scenario: Alta de snack incorrecto, usuario sin credenciales habilitadas Acomodador
	Given un "Acomodador" logueado en el sistema
	And el nombre "Mani Japones"
	And el precio "50" 
	And la cantidad "200"
	When solicito el alta del "Snacks" generado con esos valores
	Then Veo el mensaje con el codigo "403"

Scenario: Alta de snack incorrecto, usuario sin credenciales habilitadas Espectador
	Given un "Espectador" logueado en el sistema
	And el nombre "Mani Japones"
	And el precio "50" 
	And la cantidad "200"
	When solicito el alta del "Snacks" generado con esos valores
	Then Veo el mensaje con el codigo "403" o el error "500"

Scenario: Alta de snack incorrecto, usuario sin credenciales habilitadas Artista
	Given un "Artista" logueado en el sistema
	And el nombre "Mani Japones"
	And el precio "50" 
	And la cantidad "200"
	When solicito el alta del "Snacks" generado con esos valores
	Then Veo el mensaje con el codigo "403" o el error "500"

Scenario: Alta de snack incorrecto, usuario sin credenciales habilitadas Vendedor
	Given un "Vendedor" logueado en el sistema
	And el nombre "Mani Japones"
	And el precio "50" 
	And la cantidad "200"
	When solicito el alta del "Snacks" generado con esos valores
	Then Veo el mensaje con el codigo "403" o el error "500"

Scenario: Alta de snack incorrecto, precio negativo
	Given un "Administrador" logueado en el sistema
	And el nombre "Ticholos"
	And el precio "-50" 
	And la cantidad "200"
	When solicito el alta del "Snacks" generado con esos valores
	Then Veo el mensaje con el codigo "404"

Scenario: Alta de snack incorrecto, precio cero
	Given un "Administrador" logueado en el sistema
	And el nombre "Ticholos"
	And el precio "0" 
	And la cantidad "200"
	When solicito el alta del "Snacks" generado con esos valores
	Then Veo el mensaje con el codigo "200"

Scenario: Alta de snack incorrecto, cantidad cero
	Given un "Administrador" logueado en el sistema
	And el nombre "Ticholos"
	And el precio "100" 
	And la cantidad "0"
	When solicito el alta del "Snacks" generado con esos valores
	Then Veo el mensaje con el codigo "200"

Scenario: Alta de snack incorrecto, cantidad negativa
	Given un "Administrador" logueado en el sistema
	And el nombre "Ticholos"
	And el precio "100" 
	And la cantidad "-50"
	When solicito el alta del "Snacks" generado con esos valores
	Then Veo el mensaje con el codigo "404"

Scenario: Alta de snack incorrecto, producto sin descripción 
	Given un "Administrador" logueado en el sistema
	And el nombre ""
	And el precio "100" 
	And la cantidad "50"
	When solicito el alta del "Snacks" generado con esos valores
	Then Veo el mensaje con el codigo "404"