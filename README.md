Datos a tener en cuenta:
1) Desactivación de Alertas:
las alertas fueron desactivadas es decir, se configuro application.DisplayAlerts = WdAlertLevel.wdAlertsNone desactiva las alertas en Word. Esto significa que no aparecerán mensajes 
emergentes que puedan interrumpir el proceso de automatización.
2) Creación de una nueva instancia de Word:
Cada vez que se llama a ExportarAPDF o UnirArchivosWordAPDF, se crea una nueva instancia de Word Application. Esto es lo que se refiere a "Single Use".
3) Modificacion del `app.config`:
El archivo app.config es un archivo de configuración utilizado en aplicaciones .NET para definir ajustes de configuración. Estos ajustes pueden incluir cadenas de conexión, configuración
de ensamblados, configuraciones de seguridad, y otros parámetros necesarios para la ejecución de la aplicación.
4) por que se modifico el app.config?
Para ayudar a resolver problemas de versiones de ensamblados y mejorar la estabilidad al trabajar con Microsoft.Office.Interop.Word
