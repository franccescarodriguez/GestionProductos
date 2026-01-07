# TechStore – Sistema de Gestión de Productos

Aplicación web desarrollada en **.NET 8** para la gestión de productos tecnológicos, basada en una arquitectura **API REST + MVC**, aplicando buenas prácticas de desarrollo de software y control de versiones con GitHub.

El sistema permite administrar productos mediante operaciones CRUD, control de stock y estado, consumiendo una API REST desde una aplicación MVC.

---

## Tecnologías utilizadas
- Lenguaje: **C#**
- Framework: **.NET 8**
- ASP.NET Core Web API
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Git y GitHub
- Bootstrap (interfaz)

---

## Arquitectura del sistema
El sistema está dividido en dos proyectos principales:

- **GestionProductos.API**  
  Expone los servicios REST para la gestión de productos y el acceso a datos mediante Entity Framework Core.

- **GestionProductos.MVC**  
  Consume la API REST y presenta la interfaz web al usuario utilizando vistas Razor.

Esta arquitectura desacoplada permite mayor mantenibilidad y escalabilidad.

---

## Estructura del proyecto

GestionProductos
│
├── GestionProductos.API
│ ├── Controllers
│ ├── Models
│ ├── Data
│ └── Program.cs
│
├── GestionProductos.MVC
│ ├── Controllers
│ ├── Models
│ ├── Views
│ ├── wwwroot
│ └── Program.cs
│
├── Database
│ └── seed_productos.sql
│
└── README.md


---

## Funcionalidades
- CRUD completo de productos
- Activación y desactivación lógica de productos
- Filtro de productos activos y todos
- Validaciones de datos
- Control de stock
- Persistencia con Entity Framework Core
- Consumo de API REST desde MVC

---

## Endpoints de la API
| Método | Endpoint | Descripción |
|------|---------|------------|
| GET | /api/productos | Listar productos |
| GET | /api/productos/{id} | Obtener producto por ID |
| POST | /api/productos | Registrar producto |
| PUT | /api/productos/{id} | Actualizar producto |
| DELETE | /api/productos/{id} | Desactivar producto |
| PUT | /api/productos/reactivar/{id} | Reactivar producto |

---

## Base de datos
Tabla **Productos**:
- IdProducto (int)
- Nombre (string)
- Marca (string)
- Categoria (string)
- Precio (decimal)
- Stock (int)
- Estado (bool)
- FechaRegistro (datetime)

---

## Ejecución del proyecto

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/USUARIO/GestionProductos.git
   
2. Configurar la cadena de conexión a SQL Server en appsettings.json.
3. Ejecutar las migraciones:
      Update-Database
4. Poblar datos de prueba ejecutando el script:
      Database/seed_productos.sql
5. Iniciar ambos proyectos (API y MVC) desde Visual Studio.

---

## Control de versiones
El proyecto utiliza Git y GitHub para el control de versiones, con commits frecuentes y descriptivos que evidencian el trabajo colaborativo del equipo.

## Observaciones
-Proyecto con fines académicos.
-No incluye autenticación avanzada.
-Arquitectura preparada para futuras mejoras.

## Referencias
Microsoft Docs – ASP.NET Core
Microsoft Docs – Entity Framework Core

---
