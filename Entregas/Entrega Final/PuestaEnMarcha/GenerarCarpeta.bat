@echo off

REM Definir la ruta de origen y destino
set "origen=.\assets\files\ArenaGestorExtensions"
set "destino=C:\ArenaGestorExtensions"

REM Realizar la copia de la carpeta
xcopy /E /I "%origen%" "%destino%"

echo Carpeta copiada exitosamente a %destino%.