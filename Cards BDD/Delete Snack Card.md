# Obtener snacks

**Como** usuario que está realizando la compra de tickets  
**Quiero** poder obtener la lista de snacks disponible para compra  
**Para** poder comprar algo y disfrutarlo durante el evento

**Escenario: Obtener snacks correcto, usuario Administrador**  
**Dado** un usuario Administrador  
**Cuando** solicito la lista disponible de Snacks  
**Entonces** veo el mensaje de la obtención con el código 200

**Escenario: Obtener snacks correcto, usuario Espectador**  
**Dado** un usuario Espectador  
**Cuando** solicito la lista disponible de Snacks  
**Entonces** veo el mensaje de la obtención con el código 200

**Escenario: Obtener snacks correcto, usuario Vendedor**  
**Dado** un usuario Vendedor  
**Cuando** solicito la lista disponible de Snacks  
**Entonces** veo el mensaje de la obtención con el código 200

**Escenario: Obtener un snack por id correcto, usuario Administrador**  
**Dado** un usuario Administrador  
**Cuando** solicito el Snacks de id 1  
**Entonces** veo el mensaje de la obtención con el código 200

**Escenario: Obtener un snack por id correcto, usuario Espectador**  
**Dado** un usuario Espectador  
**Cuando** solicito el Snacks de id 1  
**Entonces** veo el mensaje de la obtención con el código 200

**Escenario: Obtener un snack por id correcto, usuario Vendedor**  
**Dado** un usuario Vendedor  
**Cuando** solicito el Snacks de id 1  
**Entonces** veo el mensaje de la obtención con el código 200

**Escenario: Obtener snacks incorrecto, usuario Artista**  
**Dado** un usuario Artista  
**Cuando** solicito la lista disponible de Snacks  
**Entonces** veo el mensaje de la obtención con el código 403

**Escenario: Obtener snacks incorrecto, usuario Acomodador**  
**Dado** un usuario Acomodador  
**Cuando** solicito la lista disponible de Snacks  
**Entonces** veo el mensaje de la obtención con el código 403

**Escenario: Obtener un snack por id incorrecto, usuario Artista**  
**Dado** un usuario Artista  
**Cuando** solicito el Snacks de id 1  
**Entonces** veo el mensaje de la obtención con el código 403

**Escenario: Obtener un snack por id incorrecto, usuario Acomodador**  
**Dado** un usuario Acomodador  
**Cuando** solicito el Snacks de id 1  
**Entonces** veo el mensaje de la obtención con el código 403

**Escenario: Obtener un snack por id incorrecto, usuario Administrador con id inexistente**  
**Dado** un usuario Administrador  
**Cuando** solicito el Snacks de id 4561  
**Entonces** veo el mensaje de la obtención con el código 404

**Escenario: Obtener un snack por id incorrecto, usuario Espectador con id inexistente**  
**Dado** un usuario Espectador  
**Cuando** solicito el Snacks de id 4561  
**Entonces** veo el mensaje de la obtención con el código 404

**Escenario: Obtener un snack por id incorrecto, usuario Vendedor con id inexistente**  
**Dado** un usuario Vendedor  
**Cuando** solicito el Snacks de id 4561  
**Entonces** veo el mensaje de la obtención con el código 404
