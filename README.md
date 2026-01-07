# TechStore – Sistema de Gestión de Productos
Aplicación web desarrollada en .NET 8 para la gestión de productos tecnológicos, basada en una arquitectura API REST + MVC.

## Tecnologías utilizadas
- C#
- .NET 8
- ASP.NET Core Web API
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Git y GitHub

## Arquitectura
El sistema está dividido en dos proyectos:
- **GestionProductos.API**: expone los servicios REST para la gestión de productos.
- **GestionProductos.MVC**: consume la API y presenta la interfaz web al usuario.

## Funcionalidades
- CRUD completo de productos
- Activación y desactivación de productos
- Filtro de productos activos y todos
- Validaciones de datos
- Persistencia con Entity Framework Core

## Ejecución del proyecto
1. Clonar el repositorio
2. Configurar la cadena de conexión a SQL Server
3. Ejecutar las migraciones:
4. Iniciar ambos proyectos (API y MVC)

## Base de datos
Tabla **Productos**:
- IdProducto
- Nombre
- Marca
- Categoría
- Precio
- Stock
- Estado
- FechaRegistro
