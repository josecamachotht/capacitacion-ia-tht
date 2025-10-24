# Supermarket API

Una API REST desarrollada en .NET 9 para la gestión de productos de supermercado, implementando patrones de arquitectura limpia y mejores prácticas de desarrollo.

## 🚀 Características

- **CRUD completo de productos**: Crear, leer, actualizar y eliminar productos
- **Categorización de productos**: Organización por categorías
- **Búsqueda por código de barras**: Localización rápida de productos
- **Soft delete**: Eliminación lógica de productos manteniendo el historial
- **Validación de datos**: Validaciones automáticas usando Data Annotations
- **Documentación OpenAPI**: Swagger integrado para documentación automática
- **Arquitectura por capas**: Separación clara entre controladores, servicios y repositorios
- **Entity Framework Core**: ORM con soporte para PostgreSQL
- **Logging**: Sistema de logs integrado

## 🏗️ Arquitectura

El proyecto sigue una arquitectura de capas:

```
SupermarketAPI/
├── Controllers/     # Controladores API (Capa de presentación)
├── Services/        # Lógica de negocio (Capa de aplicación)
├── Repositories/    # Acceso a datos (Capa de infraestructura)
├── Models/          # Entidades del dominio
├── DTOs/            # Objetos de transferencia de datos
├── Data/            # Contexto de Entity Framework
└── Migrations/      # Migraciones de base de datos
```

## 🛠️ Tecnologías Utilizadas

- **.NET 9**: Framework principal
- **ASP.NET Core Web API**: Para crear la API REST
- **Entity Framework Core**: ORM para acceso a datos
- **PostgreSQL**: Base de datos relacional
- **Npgsql**: Proveedor de Entity Framework para PostgreSQL
- **OpenAPI/Swagger**: Documentación automática de la API
- **Data Annotations**: Validación de modelos

## 📋 Prerrequisitos

- .NET 9 SDK
- PostgreSQL 12 o superior
- Visual Studio Code (recomendado) o Visual Studio
- Git

## ⚙️ Configuración

### 1. Clonar el repositorio

```bash
git clone <repository-url>
cd ejercicio-1/SupermarketAPI
```

### 2. Configurar la base de datos

1. Asegúrate de que PostgreSQL esté ejecutándose
2. Crea una base de datos llamada `SupermarketDB`
3. Actualiza la cadena de conexión en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=SupermarketDB;Username=tu_usuario;Password=tu_contraseña"
  }
}
```

### 3. Aplicar migraciones

```bash
dotnet ef database update
```

### 4. Ejecutar la aplicación

```bash
dotnet run
```

La API estará disponible en:
- HTTPS: `https://localhost:7146`
- HTTP: `http://localhost:5146`

## 📖 Uso de la API

### Endpoints principales

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/products` | Obtener todos los productos |
| GET | `/api/products/{id}` | Obtener producto por ID |
| POST | `/api/products` | Crear nuevo producto |
| PUT | `/api/products/{id}` | Actualizar producto |
| DELETE | `/api/products/{id}` | Eliminar producto (soft delete) |
| GET | `/api/products/category/{category}` | Obtener productos por categoría |
| GET | `/api/products/barcode/{barcode}` | Obtener producto por código de barras |

### Modelo de datos

#### Product
```json
{
  "id": 1,
  "name": "Leche Entera 1L",
  "description": "Leche entera pasteurizada en envase de cartón de 1 litro",
  "price": 2.50,
  "category": "Lácteos",
  "stock": 50,
  "barcode": "7501234567890",
  "createdAt": "2023-10-22T10:00:00Z",
  "updatedAt": "2023-10-22T10:00:00Z",
  "isActive": true
}
```

### Ejemplos de uso

#### Crear un producto
```bash
curl -X POST "https://localhost:7146/api/products" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Yogurt Natural",
    "description": "Yogurt natural sin azúcar, 150g",
    "price": 1.75,
    "category": "Lácteos",
    "stock": 30,
    "barcode": "7501234567893"
  }'
```

#### Obtener todos los productos
```bash
curl -X GET "https://localhost:7146/api/products"
```

## 🔧 Desarrollo

### Estructura del proyecto

- **Models**: Contiene las entidades del dominio (`Product.cs`)
- **DTOs**: Objetos para transferencia de datos entre capas
  - `CreateProductDto.cs`: Para crear productos
  - `UpdateProductDto.cs`: Para actualizar productos
  - `ProductResponseDto.cs`: Para respuestas de la API
- **Repositories**: Patrón Repository para acceso a datos
- **Services**: Lógica de negocio y orquestación
- **Controllers**: Puntos de entrada de la API REST

### Comandos útiles

```bash
# Compilar el proyecto
dotnet build

# Ejecutar tests
dotnet test

# Crear nueva migración
dotnet ef migrations add NombreDeLaMigracion

# Aplicar migraciones
dotnet ef database update

# Generar documentación OpenAPI
dotnet run --project SupermarketAPI
```

## 📚 Documentación de la API

Una vez que la aplicación esté ejecutándose, puedes acceder a la documentación interactiva de Swagger en:

- **Swagger UI**: `https://localhost:7146/swagger`
- **OpenAPI JSON**: `https://localhost:7146/swagger/v1/swagger.json`

## 🧪 Testing

El proyecto incluye un archivo `SupermarketAPI.http` con ejemplos de peticiones para probar la API usando la extensión REST Client de VS Code.

## 🤝 Contribución

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - mira el archivo [LICENSE](LICENSE) para detalles.

## ✨ Características futuras

- [ ] Autenticación y autorización JWT
- [ ] Paginación en listados
- [ ] Filtros avanzados de búsqueda
- [ ] Sistema de auditoría
- [ ] Caché con Redis
- [ ] Containerización con Docker
- [ ] Tests unitarios e integración
- [ ] CI/CD pipeline

## 🐛 Problemas conocidos

- Configurar la cadena de conexión de PostgreSQL según tu entorno local
- Asegúrate de que la base de datos esté creada antes de ejecutar las migraciones

## 📞 Soporte

Si tienes alguna pregunta o problema, por favor abre un issue en el repositorio.