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
  
   <img width="219" alt="image" src="https://github.com/nkmk23/PatternCQRS/assets/69180185/7bed14e7-a9fe-4819-b7ab-e23d18016ab3">


2. **Configurar Postman**:
   - Abre Postman e importa el archivo de la carpeta `Docs/Postman_Collection`.
<img width="220" alt="image" src="https://github.com/nkmk23/PatternCQRS/assets/69180185/573ae365-1500-4cbb-8fda-f72510f9dcd9">

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
  
8. **Documentación**:
   - Si quiere acceder al detalle de como esta construida el API puede ingresar a SwaggerHub e importar el archivo que esta en la carpeta `Docs/Swagger`, para revisar como esta creado el API. O revisando el explorador encontrara la documentación tipo OpenApi del proyecto. 
  <img width="911" alt="image" src="https://github.com/nkmk23/PatternCQRS/assets/69180185/646a0b86-6112-4cc5-ba93-86cc5dcfac36">

   
