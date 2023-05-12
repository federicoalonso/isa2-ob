# Compra de snacks

**Como** usuario que está realizo la compra de tickets  
**Quiero** poder comprar snacks  
**Para** disfrutarlos durante el evento sin necesidad de abonarlos en el lugar

**Escenario: Compra de un Snack correcta, con usuario Espectador**  
**Dado** un usuario Espectador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra 2  
**Cuando** solicito la compra del Snacks  
**Entonces** verifico el mensaje con el código 200

**Escenario: Compra de dos Snacks correcta, con usuario Espectador**  
**Dado** un usuario Espectador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra 2  
**Y** el nombre del segundo producto Lays  
**Y** con id 2  
**Y** la cantidad de compra del segundo producto 4  
**Cuando** solicito la compra de varios Snacks  
**Entonces** verifico el mensaje con el código 200

**Escenario: Compra de un Snack correcta, con usuario Vendedor**  
**Dado** un usuario Vendedor logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra 2  
**Cuando** solicito la compra del Snacks  
**Entonces** verifico el mensaje con el código 200

**Escenario: Compra de dos Snacks correcta, con usuario Vendedor**  
**Dado** un usuario Vendedor logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra 2  
**Y** el nombre del segundo producto Lays  
**Y** con id 2  
**Y** la cantidad de compra del segundo producto 4  
**Cuando** solicito la compra de varios Snacks  
**Entonces** verifico el mensaje con el código 200

**Escenario: Compra de un Snack correcta, con usuario Administrador**  
**Dado** un usuario Administrador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra 2  
**Cuando** solicito la compra del Snacks  
**Entonces** verifico el mensaje con el código 200

**Escenario: Compra de dos Snacks correcta, con usuario Administrador**  
**Dado** un usuario Administrador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra 2  
**Y** el nombre del segundo producto Lays  
**Y** con id 2  
**Y** la cantidad de compra del segundo producto 4  
**Cuando** solicito la compra de varios Snacks  
**Entonces** verifico el mensaje con el código 200

**Escenario: Compra de un Snack incorrecta, con usuario Acomodador (sin permisos)**  
**Dado** un usuario Acomodador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra 2  
**Cuando** solicito la compra del Snacks  
**Entonces** verifico el mensaje con el código 403

**Escenario: Compra de dos Snacks incorrecta, con usuario Acomodador (sin permisos)**  
**Dado** un usuario Acomodador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra 2  
**Y** el nombre del segundo producto Lays  
**Y** con id 2  
**Y** la cantidad de compra del segundo producto 4  
**Cuando** solicito la compra de varios Snacks  
**Entonces** verifico el mensaje con el código 403

**Escenario: Compra de un Snack incorrecta, con usuario Artista (sin permisos)**  
**Dado** un usuario Artista logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra 2  
**Cuando** solicito la compra del Snacks  
**Entonces** verifico el mensaje con el código 403

**Escenario: Compra de dos Snacks incorrecta, con usuario Artista (sin permisos)**  
**Dado** un usuario Artista logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra 2  
**Y** el nombre del segundo producto Lays  
**Y** con id 2  
**Y** la cantidad de compra del segundo producto 4  
**Cuando** solicito la compra de varios Snacks  
**Entonces** verifico el mensaje con el código 403

**Escenario: Compra de un Snack incorrecta, con usuario Espectador, snackId inexistente**  
**Dado** un usuario Espectador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 100  
**Y** la cantidad de compra 2  
**Cuando** solicito la compra del Snacks  
**Entonces** verifico el mensaje con el código 404

**Escenario: Compra de dos Snacks incorrecta, con usuario Espectador, snackId inexistente**  
**Dado** un usuario Espectador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 100  
**Y** la cantidad de compra 2  
**Y** el nombre del segundo producto Lays  
**Y** con id 2000  
**Y** la cantidad de compra del segundo producto 4  
**Cuando** solicito la compra de varios Snacks  
**Entonces** verifico el mensaje con el código 404

**Escenario: Compra de un Snack incorrecta, cantidad de snacks mayor al stock**  
**Dado** un usuario Espectador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra 20000000  
**Cuando** solicito la compra del Snacks  
**Entonces** verifico el mensaje con el código 404

**Escenario: Compra de dos Snacks incorrecta, cantidad de snacks mayor al stock**  
**Dado** un usuario Espectador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 100  
**Y** la cantidad de compra 2  
**Y** el nombre del segundo producto Lays  
**Y** con id 2000  
**Y** la cantidad de compra del segundo producto 4  
**Cuando** solicito la compra de varios Snacks  
**Entonces** verifico el mensaje con el código 404

**Escenario: Compra de un Snack incorrecta, cantidad de snacks negativa**  
**Dado** un usuario Espectador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra -20000  
**Cuando** solicito la compra del Snacks  
**Entonces** verifico el mensaje con el código 404

**Escenario: Compra de dos Snacks incorrecta, cantidad de snacks negativa**  
**Dado** un usuario Espectador logueado en el sistema  
**Y** el nombre del producto Doritos  
**Y** de id 1  
**Y** la cantidad de compra -2  
**Y** el nombre del segundo producto Lays  
**Y** con id 2  
**Y** la cantidad de compra del segundo producto -4  
**Cuando** solicito la compra de varios Snacks  
**Entonces** verifico el mensaje con el código 404
