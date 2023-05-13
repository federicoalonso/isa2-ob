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
