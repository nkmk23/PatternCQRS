# CustomerAPI

CustomerAPI es una API desarrollada en .NET 6 con el objetivo de permitir la gestión de clientes para una empresa. La API proporciona cinco (5) endpoints principales:

- **Consultar todos los clientes**
- **Consultar un cliente por ID**
- **Agregar un nuevo cliente**
- **Eliminar un cliente (Borrado lógico)**
- **Modificar la información de un cliente**

## Procedimiento para Ejecutar el Proyecto

Sigue estos pasos para ejecutar el proyecto:

1. **Crear la Base de Datos**:
   - Busca en la carpeta `Docs/Base de Datos/CreateDatabase`.
   - Abre el documento en SQL Server y ejecuta la consulta para crear la base de datos.
   - Ejecuta la consulta para crear la tabla.

2. **Configurar Postman**:
   - Abre Postman e importa el archivo de la carpeta `Docs/Postman_Collection`.

3. **Clonar el Repositorio**:
   git clone <URL del repositorio>

4. **Configurar la Cadena de Conexión**:
   - Ve al archivo `appsettings.json` del proyecto.
   - Busca el parámetro `DefaultConnection` y coloca la cadena de conexión al servidor de base de datos.

5. **Ejecutar el Proyecto**:
   - Ejecuta el proyecto en modo debug.

6. **Configurar Postman**:
   - Coloca el servidor del equipo en los endpoints de Postman.

7. **Seguir Instrucciones del Video**:
   - Sigue las instrucciones que están en el video ubicado en la carpeta `Docs/Demo`.
