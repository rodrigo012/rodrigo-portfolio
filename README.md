# Portfolio · Rodrigo Román

Portfolio personal como desarrollador **Full Stack .NET / Blazor**.

Construido con **Blazor WebAssembly** (standalone), **CSS propio** (tema oscuro) y sin dependencias externas. Todo el contenido (perfil, proyectos, skills y snippets) vive en un único servicio editable: no hay datos hardcodeados en las páginas.

## Requisitos

- [.NET SDK 8 o superior](https://dotnet.microsoft.com/download) (probado con .NET 10)

## Cómo correr el portfolio

```bash
cd rodrigo-portfolio
dotnet run
```

Abrí la URL que muestra la consola (por defecto algo como `http://localhost:5xxx`).

Para desarrollo con recarga automática:

```bash
dotnet watch
```

## Estructura del proyecto

```
rodrigo-portfolio/
├── Models/                  # Project, Skill, SkillCategory, CodeSnippet, SiteInfo
├── Services/
│   └── PortfolioDataService.cs   # ⭐ TODO el contenido del portfolio se edita acá
├── Layout/
│   └── MainLayout.razor     # Header, navegación y footer
├── Shared/
│   └── ProjectCard.razor    # Card reutilizable de proyecto
├── Pages/
│   ├── Home.razor           # /
│   ├── About.razor          # /about (sobre mí + skills)
│   ├── Projects.razor       # /projects
│   ├── ProjectDetail.razor  # /projects/{slug}
│   ├── Code.razor           # /code (snippets)
│   └── Contact.razor        # /contact
└── wwwroot/
    └── css/app.css          # Tema oscuro (colores en las variables :root)
```

## Cómo editar los proyectos

Todos los proyectos están en la lista `_projects` de [`Services/PortfolioDataService.cs`](Services/PortfolioDataService.cs). Cada proyecto es un objeto `Project` con estos campos:

| Campo | Descripción |
|---|---|
| `Name` | Nombre visible del proyecto |
| `Slug` | Identificador de la URL (`/projects/{slug}`, en minúsculas y con guiones) |
| `ShortDescription` | Texto corto para la card |
| `LongDescription` | Descripción completa para la página de detalle |
| `Type` | Tipo de proyecto (ej: "Fullstack / Sistema empresarial") |
| `Status` | `ProjectStatus.Demo`, `ProjectStatus.EnDesarrollo` o `ProjectStatus.Concepto` |
| `Technologies` | Lista de tecnologías (se muestran como chips) |
| `Features` | Lista de funcionalidades principales |
| `ProblemSolved` | Qué problema resuelve |
| `WhatItDemonstrates` | Qué demuestra técnicamente |
| `Screenshots` | Rutas de imágenes relativas a `wwwroot` (vacía → muestra placeholder) |
| `RepositoryUrl` | URL del repo. Si es `null` se muestra "Repositorio: pendiente de publicación" |

## Cómo agregar un proyecto nuevo

1. Abrí `Services/PortfolioDataService.cs`.
2. Agregá un nuevo `new Project { ... }` a la lista `_projects`, copiando la estructura de cualquiera de los existentes.
3. Elegí un `Slug` único (ej: `"mi-nuevo-proyecto"`). La ruta `/projects/mi-nuevo-proyecto` funciona automáticamente, no hace falta crear páginas nuevas.

### Agregar screenshots

1. Creá la carpeta `wwwroot/img/projects/{slug}/` y copiá las imágenes ahí.
2. Cargá las rutas en el proyecto:

```csharp
Screenshots = new() { "img/projects/mi-proyecto/pantalla-1.png" }
```

## Cómo cambiar tus links personales

En `Services/PortfolioDataService.cs`, editá la propiedad `Site`:

```csharp
Email = "tu-email@ejemplo.com",                        // <-- tu email real
GitHubUrl = "https://github.com/tu-usuario",           // <-- tu GitHub real
LinkedInUrl = "https://www.linkedin.com/in/tu-usuario" // <-- tu LinkedIn real
```

Ahí también podés cambiar el nombre, el rol, la descripción del hero (`Tagline`), el texto de "Sobre mí" (`AboutText`), las skills y los snippets de código.

## Cómo cambiar los colores

Los colores del tema están como variables CSS al inicio de [`wwwroot/css/app.css`](wwwroot/css/app.css) (`:root`). Cambiando `--accent` y `--accent-2` se re-colorea todo el sitio.

## Cómo publicar el portfolio

Blazor WebAssembly compila a archivos estáticos, así que se puede hostear gratis en casi cualquier lado.

### 1. Generar la versión de producción

```bash
dotnet publish -c Release
```

Los archivos quedan en `bin/Release/net10.0/publish/wwwroot/` (la carpeta `netX.Y` depende de tu SDK).

### 2. Opciones de hosting

- **GitHub Pages**: subí el contenido de `publish/wwwroot` a una rama `gh-pages`. Ojo: si el sitio no queda en la raíz del dominio, ajustá el `<base href="/" />` de `wwwroot/index.html` (ej: `<base href="/mi-repo/" />`).
- **Azure Static Web Apps**: tiene plantilla oficial para Blazor WASM; conectás el repo y se despliega solo.
- **Netlify / Vercel / Cloudflare Pages**: publicá la carpeta `publish/wwwroot` como sitio estático.

Para que las rutas como `/projects/gestion-administrativa` funcionen al recargar la página, el host debe redirigir todas las rutas a `index.html` (fallback de SPA). En Netlify por ejemplo se agrega un archivo `_redirects` con `/* /index.html 200`; en Azure Static Web Apps ya viene resuelto.

## Notas

- Todos los datos de contacto y links son **placeholders editables** — no hay links inventados a repositorios.
- Los proyectos son **casos de portfolio curados**, escritos como contenido editable, sin referencias a código o clientes privados.
