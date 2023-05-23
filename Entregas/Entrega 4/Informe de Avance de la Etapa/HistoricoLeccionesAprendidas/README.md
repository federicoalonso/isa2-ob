# Histórico de lecciones aprendidas

Si bien esto no es de la etapa actual, nos resulta útil no perder el histórico de las lecciones que hemos ido aprendiendo a lo largo del obligatorio, esas lecciones se enuncian a continuación:

**Lección al informar erróneamente un bug**

En la etapa anterior reportamos un bug que a su vez se reportó como crítico y que en realidad fue un error al realizar el testing. Es fundamental realizar pruebas exhaustivas y validar la funcionalidad antes de informar un error, ya que esto ayuda a evitar la asignación de recursos y tiempo en la solución de problemas que en realidad no existen. En este caso, nos dimos cuenta de que se trataba de un error de reporte, que implicó que se malgaste tiempo en algo que funcionaba correctamente. Al detectar el error procedimos a continuar enfocándonos en otras tareas prioritarias, pero en principio el uso de nuestro tiempo no fue de la manera más eficiente.

**Escaneos de seguridad durante el proceso de desarrollo**

En la etapa de automatización del testing detectamos problemas de seguridad de la aplicación que provocaron que tuviéramos que modificar el pipeline de github actions para que pudiera pasar los mismos. Identificamos que es importante que esta práctica se realice mediante el desarrollo de las aplicaciones, para evitar que se detecte el error cuando ya es demasiado costoso realizar el cambio.

**No hardcodear rutas en las pruebas locales**

Sucede en esta aplicación que las librerías que utiliza para realizar la importación y exportación se encuentre en una dirección específica del creador del código (C:\ArenaGestorExtensions), si bien todas las máquinas windows tienen el disco C, al intentar ejecutar las pruebas en linux, o al realizarlo desde github actions (en un ambiente ubuntu), estas fallan. En esta altura de la aplicación ya es complicado cambiar la configuración y la ejecución de las pruebas, pero el haberlo encontrado en una etapa temprana nos hubiera evitado estos errores ahora. Entendemos que es una opción de mejora de la segunda entrega y procederemos a trabajar en realizar estas modificaciones.

**Subestimar los bugs**

Nos pasó que subestimamos uno de los bugs, lo que llevó mucho más tiempo de lo planificado para poder repararlo. Aprendimos que no debemos subestimar los bugs, y que si vuelve a suceder una situación similar es buena idea trabajar en equipo para poder ayudarnos. 

**Documentar correctamente los informes y amoldar la estructura del repositorio para que sea más accesible:**
Muchas veces es difícil identificar los problemas que terceros para poder acceder a los recursos que nosotros preparamos, o que muchas veces discutimos pero no quedaron plasmados por escrito, es por eso que para esta etapa vamos a proceder a documentar de forma más exhaustiva el presente informe, así como también reorganizar el repositorio para que sea más accesible.

**No querer adelantarnos en los pasos al momento de confeccionar los tableros:**
Inicialmente complejizamos mucho el tablero incluyendo etapas relacionadas a un proceso de ingeniería que sería necesario más adelante en el obligatorio. Esto se debió principalmente al intento por incluir –aunque forzosamente– todos los pasos y por comprender equivocadamente los lineamientos recibidos en las expectativas de la entrega. En la versión actual, consideramos que entendimos mejor qué es lo que se espera de la entrega y, por consiguiente, fuimos capaces de ajustar adecuadamente el proceso de ingeniería.

**Trabajar en equipo cuando nos atascamos mejora los tiempos de entrega:**
Un aspecto fundamental para la organización en esta entrega particular fue la comunicación del equipo y la colaboración activa entre los participantes. A lo largo de esta entrega experimentamos diversas dificultades cuyo origen estaba fuera de nuestro alcance. Por este motivo, hubo momentos de gran incertidumbre frente a lo esperado, al alcance y a cuáles pasos dar para acercarnos a un objetivo final. Ante esta dificultad el equipo aumentó la frecuencia de las comunicaciones y, a través de una gestión del cambio adecuada pudo buscar alternativas para seguir avanzando.

**Adaptarse ante los cambios en los requerimientos:**
Conforme mencionado anteriormente, la gestión del cambio, la flexibilidad y la adecuada distribución de tareas fueron las bases para conseguir que un proyecto inicialmente bloqueado pueda salir adelante. En este sentido, es importante estar dispuesto a realizar cambios y/o ajustes en el proceso definido de manera que posibilite la adaptación a las necesidades del proyecto superando las dificultades. Así, debemos mencionar que los ajustes en la dinámica del equipo y la priorización de las tareas fueron de vital importancia. Puntualmente en esta etapa, debimos encontrar alternativas para avanzar con el desarrollo inclusive aunque supiéramos que no era lo correcto según nuestro proceso. Lógicamente, parte de la madurez de un equipo se puede medir en la definición de los procesos, pero una acción correctiva a un proceso que claramente no está siendo aplicable es una demostración de la agilidad de la gestión.

**Intentar identificar los cuellos de botella:**
Relacionado con lo anterior, uno de los principios de Kanban es ayudar en la visualización y gestión del flujo de trabajo. En este sentido podemos afirmar que por primera vez en el obligatorio experimentamos un cuello de botella en la actividad de Test Cases Implementation. Es muy importante identificarlos tempranamente ya que permite tomar medidas correctivas rápidas para evitar que los bloqueos se acumulen y afecten la productividad general del proyecto.

**Retroalimentación de lo planificado en la retrospectiva anterior:**
A partir de la retrospectiva anterior, decidimos que al principio de la entrega íbamos a coordinar el tablero de forma conjunta e íbamos a agregar las tarjetas que nos resultaran necesarias, esto lo logramos, y fue lo que nos permitió no perder el rumbo a lo largo de la entrega. Además establecimos pactar las reuniones a través de la herramienta Google Calendar, lo que nos resultó de mucha utilidad. Por último nos propusimos consultarnos en las reuniones intermedias si las tareas que estábamos realizando estaban incluidas en el tablero, si bien lo realizamos en parte, nos faltó prestarle más atención al tablero.

