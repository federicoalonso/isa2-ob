Feature: Edicion de snack
	Como usuario administrador, 
	quiero editar un snack 
	para cambiar los datos de descrípcion, precio y/o cantidad.


@validDelete
Scenario: Edicion de snack correcto
	Given un usuario con rol "Administrador" logueado
	And ingreso los datos caseId "2", descripcion "Pringles", precio "13" y cantidad "15" y existe un snack con dicho caseId
	When solicito editar el "Snacks" con los referidos nuevos datos
	Then Veo el mensaje resultante con el codigo "200"

Scenario: Edicion de snack incorrecta, usuario sin credenciales habilitadas Acomodador
	Given un usuario con rol "Acomodador" logueado
	And ingreso los datos caseId "2", descripcion "Pringles", precio "13" y cantidad "15" y existe un snack con dicho caseId
	When solicito editar el "Snacks" con los referidos nuevos datos
	Then Veo el mensaje resultante con el codigo "403"

Scenario: Edicion de snack incorrecta, usuario sin credenciales habilitadas Vendedor
	Given un usuario con rol "Vendedor" logueado
	And ingreso los datos caseId "2", descripcion "Pringles", precio "13" y cantidad "15" y existe un snack con dicho caseId
	When solicito editar el "Snacks" con los referidos nuevos datos
	Then Veo el mensaje resultante con el codigo "403"

Scenario: Edicion de snack incorrecta, usuario sin credenciales habilitadas Espectador
	Given un usuario con rol "Espectador" logueado
	And ingreso los datos caseId "2", descripcion "Pringles", precio "13" y cantidad "15" y existe un snack con dicho caseId
	When solicito editar el "Snacks" con los referidos nuevos datos
	Then Veo el mensaje resultante con el codigo "403"

Scenario: Edicion de snack incorrecta, usuario sin credenciales habilitadas Artista
	Given un usuario con rol "Artista" logueado
	And ingreso los datos caseId "2", descripcion "Pringles", precio "13" y cantidad "15" y existe un snack con dicho caseId
	When solicito editar el "Snacks" con los referidos nuevos datos
	Then Veo el mensaje resultante con el codigo "403"

Scenario: Edicion de snack incorrecta, id no existe
	Given un usuario con rol "Administrador" logueado
	And ingreso los datos caseId "99999", descripcion "Pringles", precio "13" y cantidad "15" y no existe un snack con dicho caseId
	When solicito editar el "Snacks" con los referidos nuevos datos
	Then Veo el mensaje resultante con el codigo "404"

Scenario: Edicion de snack incorrecta, descripcion vacia
	Given un usuario con rol "Administrador" logueado
	And ingreso los datos caseId "2", descripcion "", precio "13" y cantidad "15" y existe un snack con dicho caseId
	When solicito editar el "Snacks" con los referidos nuevos datos
	Then Veo el mensaje resultante con el codigo "404"

Scenario: Edicion de snack incorrecta, precio incorrecto
	Given un usuario con rol "Administrador" logueado
	And ingreso los datos caseId "2", descripcion "Pringles", precio "-50" y cantidad "15" y existe un snack con dicho caseId
	When solicito editar el "Snacks" con los referidos nuevos datos
	Then Veo el mensaje resultante con el codigo "404"

Scenario: Edicion de snack incorrecta, cantidad incorrecta
	Given un usuario con rol "Administrador" logueado
	And ingreso los datos caseId "2", descripcion "Pringles", precio "13" y cantidad "-30" y existe un snack con dicho caseId
	When solicito editar el "Snacks" con los referidos nuevos datos
	Then Veo el mensaje resultante con el codigo "404"