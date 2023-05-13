# Baja de snack

**Como** usuario administrador  
**quiero** dar de baja un snack a partir de su id  
**para** dejar de ofrecerlo a los usuarios.

**Escenario: Baja de snack correcto**  
**Dado** un usuario con rol Administrador  
**Cuando** solicito la baja de Snacks de id existente  
**Entonces** Veo el mensaje con el codigo 200

**Escenario: Baja de snack incorrecta, usuario sin credenciales habilitadas Acomodador**  
**Dado** un Acomodador logueado en el sistema  
**Cuando** solicito la baja de Snacks de id existente  
**Entonces** Veo el mensaje con el codigo 403

**Escenario: Baja de snack incorrecta, usuario sin credenciales habilitadas Vendedor**  
**Dado** un Vendedor logueado en el sistema  
**Cuando** solicito la baja de Snacks de id existente  
**Entonces** Veo el mensaje con el codigo 403

**Escenario: Baja de snack incorrecta, usuario sin credenciales habilitadas Espectador**  
**Dado** un Espectador logueado en el sistema  
**Cuando** solicito la baja de Snacks de id existente  
**Entonces** Veo el mensaje con el codigo 403

**Escenario: Baja de snack incorrecta, usuario sin credenciales habilitadas Artista**  
**Dado** un Artista logueado en el sistema  
**Cuando** solicito la baja de Snacks de id existente  
**Entonces** Veo el mensaje con el codigo 403

**Escenario: Baja de snack incorrecta, snack inexistente**  
**Dado** un Artista logueado en el sistema  
**Cuando** solicito la baja de Snacks de id que no existe 99987  
**Entonces** Veo el mensaje con el codigo 403
