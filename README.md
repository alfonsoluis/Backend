# Solucion del test de Backend

La solucion ha sido desarollado en .NET Framework 8. Aquí encontrarás una guía rápida para ejecutar localmente y trabajar con la API que permite realizar operaciones CRUD (Crear, Leer, Actualizar, Borrar) en una colección de libros.

## 🛠️ Requisitos previos

- Visual Studio 2022 (o una versión compatible).
- .NET Framework 8.
- Configurar SQL Server Express. Actualizar el string de conexión en el archivo `appsettings.json` con los parametros correspondientes.

## ⚙️ Configuración del Proyecto

Para ejecutar este proyecto, seguir estos pasos:

1. **Clonar el repositorio**: Asegurarse de tener el proyecto en tu máquina local.
2. **Abrir en Visual Studio**: Abrir el archivo de solución (*.sln) en Visual Studio.
3. **Restaurar paquetes**: Si es necesario, restaurar los paquetes NuGet. Esto se puede hacer automáticamente al abrir el proyecto o manualmente haciendo clic derecho sobre la solución y seleccionando "Restaurar paquetes NuGet".

## 📊 Actualizar la Base de Datos

Para actualizar la base de datos con los seeds correspondientes, seguir estas instrucciones en la consola de administración de paquetes de Visual Studio:

1. **Actualizar la base de datos**: 
   - Abrir la consola de administración de paquetes (desde "Herramientas" > "Administrador de paquetes NuGet" > "Consola del administrador de paquetes").
   - Ejecutar el comando `Update-Database` para aplicar las migraciones y asegurarse de que la base de datos esté actualizada.
   
2. **Volver a aplicar las semillas**: 
   - Si es necesario restablecer la base de datos con datos semilla, ejecutar el comando `Remove-Database` seguido de `Update-Database`.

## 🚀 Ejecución del Proyecto

Para ejecutar el proyecto, seguir estas instrucciones:

1. **Seleccionar el proyecto de inicio**: Asegurarse de que el proyecto correcto esté configurado como proyecto de inicio en Visual Studio.
2. **Ejecutar el proyecto**: Usar el atajo `F5` para ejecutar con depuración o `Ctrl + F5` para ejecutar sin depuración.
3. **Acceder a Swagger**: Una vez que el proyecto esté en ejecución, abrir el navegador y acceder a `http://localhost:<tu-puerto>/swagger` para ver la interfaz de Swagger y así interactuar con la API.

## 🛡️ Autorización en Swagger

Para autorizar en Swagger, seguir estos pasos:

1. **Obtener el token de autorización**: 
   - Usar el endpoint `User/Authorize` para obtener un token JWT. Deberás proporcionar las credenciales del usuario almacenado en la base de datos.
2. **Copiar el token**: Copiar el token JWT que se genera.
3. **Autorizar en Swagger**: 
   - Buscar el botón de autorización (normalmente un candado).
   - Pegar el token en el campo "Bearer Token" y hacer clic en "Authorize".
   - Con esto, interactuar con los endpoints que requieren autorización.

## 🎯 Pruebas Con Postman

Se ha incluido en el proyecto una colección de Postman con ejemplos de solicitudes para probar los endpoints de la API. Para usarla, seguir estos pasos:

1. **Importar la colección**: 
   - Abrir Postman y hacer clic en "Importar" para cargar la colección.
   - Seleccionar el archivo `collection.json` ubicado en la carpeta `Postman`.


Con estos pasos, todo debería estar listo para ejecutar el proyecto! 👨‍💻👩‍💻