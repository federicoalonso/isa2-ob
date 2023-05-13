# Edición de snack

**Como** usuario administrador  
**quiero** editar un snack  
**para** cambiar los datos de descripción, precio y/o cantidad.

**Escenario: Edición de snack correcto**  
**Dado** un usuario con rol Administrador logueado  
**Y** ingreso los datos caseId 2, descripción Pringles, precio 13 y cantidad 15 y existe un snack con dicho caseId  
**Cuando** solicito editar el Snacks con los referidos nuevos datos  
**Entonces** veo el mensaje resultante con el código 200

**Escenario: Edición de snack incorrecta, usuario sin credenciales habilitadas Acomodador**  
**Dado** un usuario con rol Acomodador logueado  
**Y** ingreso los datos caseId 2, descripción Pringles, precio 13 y cantidad 15 y existe un snack con dicho caseId  
**Cuando** solicito editar el Snacks con los referidos nuevos datos  
**Entonces** veo el mensaje resultante con el código 403

**Escenario: Edición de snack incorrecta, usuario sin credenciales habilitadas Vendedor**  
**Dado** un usuario con rol Vendedor logueado  
**Y** ingreso los datos caseId 2, descripción Pringles, precio 13 y cantidad 15 y existe un snack con dicho caseId  
**Cuando** solicito editar el Snacks con los referidos nuevos datos  
**Entonces** veo el mensaje resultante con el código 403

**Escenario: Edición de snack incorrecta, usuario sin credenciales habilitadas Espectador**  
**Dado** un usuario con rol Espectador logueado  
**Y** ingreso los datos caseId 2, descripción Pringles, precio 13 y cantidad 15 y existe un snack con dicho caseId  
**Cuando** solicito editar el Snacks con los referidos nuevos datos  
**Entonces** veo el mensaje resultante con el código 403

**Escenario: Edición de snack incorrecta, usuario sin credenciales habilitadas Artista**  
**Dado** un usuario con rol Artista logueado  
**Y** ingreso los datos caseId 2, descripción Pringles, precio 13 y cantidad 15 y existe un snack con dicho caseId  
**Cuando** solicito editar el Snacks con los referidos nuevos datos  
**Entonces** veo el mensaje resultante con el código 403

**Escenario: Edición de snack incorrecta, id no existe**  
**Dado** un usuario con rol Administrador logueado  
**Y** ingreso los datos caseId 99999, descripción Pringles, precio 13 y cantidad 15 y no existe un snack con dicho caseId  
**Cuando** solicito editar el Snacks con los referidos nuevos datos  
**Entonces** veo el mensaje resultante con el código 404

**Escenario: Edición de snack incorrecta, descripción vacia**  
**Dado** un usuario con rol Administrador logueado  
**Y** ingreso los datos caseId 2, descripción , precio 13 y cantidad 15 y existe un snack con dicho caseId  
**Cuando** solicito editar el Snacks con los referidos nuevos datos  
**Entonces** veo el mensaje resultante con el código 404

**Escenario: Edición de snack incorrecta, precio incorrecto**  
**Dado** un usuario con rol Administrador logueado  
**Y** ingreso los datos caseId 2, descripción Pringles, precio -50 y cantidad 15 y existe un snack con dicho caseId  
**Cuando** solicito editar el Snacks con los referidos nuevos datos  
**Entonces** veo el mensaje resultante con el código 404

**Escenario: Edición de snack incorrecta, cantidad incorrecta**  
**Dado** un usuario con rol Administrador logueado  
**Y** ingreso los datos caseId 2, descripción Pringles, precio 13 y cantidad -30 y existe un snack con dicho caseId  
**Cuando** solicito editar el Snacks con los referidos nuevos datos  
**Entonces** veo el mensaje resultante con el código 404
