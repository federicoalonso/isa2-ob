# Alta de snack

**Como** usuario administrador  
**quiero** dar de alta un nuevo snack con su descripción precio y cantidad  
**para** poder ofrecerlo a los usuarios.

**Escenario: Alta de snack correcto**  
**Dado** un Administrador logueado en el sistema  
**Y** el nombre Mani Japones  
**Y** el precio 50  
**Y** la cantidad 200  
**Cuando** solicito el alta del Snacks generado con esos valores  
**Entonces** Veo el mensaje con el código 200

**Escenario: Alta de snack incorrecto, usuario sin credenciales habilitadas Acomodador**  
**Dado** un Acomodador logueado en el sistema  
**Y** el nombre Mani Japones  
**Y** el precio 50  
**Y** la cantidad 200  
**Cuando** solicito el alta del Snacks generado con esos valores  
**Entonces** Veo el mensaje con el código 403

**Escenario: Alta de snack incorrecto, usuario sin credenciales habilitadas Espectador**  
**Dado** un Espectador logueado en el sistema  
**Y** el nombre Mani Japones  
**Y** el precio 50  
**Y** la cantidad 200  
**Cuando** solicito el alta del Snacks generado con esos valores  
**Entonces** Veo el mensaje con el código 403 o el error 500

**Escenario: Alta de snack incorrecto, usuario sin credenciales habilitadas Artista**  
**Dado** un Artista logueado en el sistema  
**Y** el nombre Mani Japones  
**Y** el precio 50  
**Y** la cantidad 200  
**Cuando** solicito el alta del Snacks generado con esos valores  
**Entonces** Veo el mensaje con el código 403 o el error 500

**Escenario: Alta de snack incorrecto, usuario sin credenciales habilitadas Vendedor**  
**Dado** un Vendedor logueado en el sistema  
**Y** el nombre Mani Japones  
**Y** el precio 50  
**Y** la cantidad 200  
**Cuando** solicito el alta del Snacks generado con esos valores  
**Entonces** Veo el mensaje con el código 403 o el error 500

**Escenario: Alta de snack incorrecto, precio negativo**  
**Dado** un Administrador logueado en el sistema  
**Y** el nombre Ticholos  
**Y** el precio -50  
**Y** la cantidad 200  
**Cuando** solicito el alta del Snacks generado con esos valores  
**Entonces** Veo el mensaje con el código 404

**Escenario: Alta de snack incorrecto, precio cero**  
**Dado** un Administrador logueado en el sistema  
**Y** el nombre Ticholos  
**Y** el precio 0  
**Y** la cantidad 200  
**Cuando** solicito el alta del Snacks generado con esos valores  
**Entonces** Veo el mensaje con el código 200

**Escenario: Alta de snack incorrecto, cantidad cero**  
**Dado** un Administrador logueado en el sistema  
**Y** el nombre Ticholos  
**Y** el precio 100  
**Y** la cantidad 0  
**Cuando** solicito el alta del Snacks generado con esos valores  
**Entonces** Veo el mensaje con el código 200

**Escenario: Alta de snack incorrecto, cantidad negativa**  
**Dado** un Administrador logueado en el sistema  
**Y** el nombre Ticholos  
**Y** el precio 100  
**Y** la cantidad -50  
**Cuando** solicito el alta del Snacks generado con esos valores  
**Entonces** Veo el mensaje con el código 404

**Escenario: Alta de snack incorrecto, producto sin descripción**  
**Dado** un Administrador logueado en el sistema  
**Y** el nombre  
**Y** el precio 100  
**Y** la cantidad 50  
**Cuando** solicito el alta del Snacks generado con esos valores  
**Entonces** Veo el mensaje con el código 404
