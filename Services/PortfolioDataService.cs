using RodrigoRoman.Portfolio.Models;

namespace RodrigoRoman.Portfolio.Services;

/// <summary>
/// Fuente única de datos del portfolio.
/// Todo el contenido (perfil, proyectos, skills, snippets) se edita acá.
/// </summary>
public class PortfolioDataService
{
    // ============================================================
    // DATOS PERSONALES — editar los placeholders con tus links reales
    // ============================================================
    public SiteInfo Site { get; } = new()
    {
        Name = "Rodrigo Román",
        Role = "Full Stack Developer .NET / Blazor",
        Tagline = "Desarrollo sistemas web empresariales con C#, .NET, Blazor y SQL Server. " +
                  "Foco en código limpio, validaciones sólidas y experiencias de usuario simples y efectivas.",
        Location = "Argentina",
        Email = "tu-email@ejemplo.com",                        // <-- editar
        GitHubUrl = "https://github.com/rodrigo012",
        LinkedInUrl = "https://www.linkedin.com/in/tu-usuario" // <-- editar
    };

    public string AboutText =>
        "Soy desarrollador Full Stack especializado en el ecosistema .NET. Trabajo a diario con C#, " +
        "ASP.NET Core, Blazor y SQL Server construyendo sistemas empresariales: ABMs, formularios con " +
        "validaciones, manejo de permisos, integraciones entre frontend y backend, y paneles de control.\n\n" +
        "Me enfoco en escribir código claro y mantenible, aplicar arquitecturas por capas (Clean Architecture " +
        "cuando el proyecto lo amerita) y resolver problemas concretos: desde diagnosticar y corregir bugs en " +
        "producción hasta optimizar consultas y tiempos de respuesta.\n\n" +
        "Disfruto especialmente el trabajo con Blazor y MudBlazor para construir interfaces modernas sin salir " +
        "de C#, y complemento el acceso a datos con Entity Framework Core y Dapper según lo que pida cada caso.";

    // ============================================================
    // PROYECTOS — agregar, editar o quitar proyectos de esta lista
    // ============================================================
    public IReadOnlyList<Project> GetProjects() => _projects;

    public Project? GetProjectBySlug(string slug) =>
        _projects.FirstOrDefault(p => p.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));

    private readonly List<Project> _projects = new()
    {
        new Project
        {
            Name = "Refricontrol — Gestión de Taller de Refrigeración",
            Slug = "refricontrol",
            Type = "App real / Desktop + Mobile",
            Status = ProjectStatus.Demo,
            ShortDescription = "Sistema completo para talleres de refrigeración: clientes, equipos, órdenes de trabajo, presupuestos, stock, cobros y reportes. Desktop y Android, 100% offline.",
            LongDescription =
                "Aplicación multiplataforma para administrar un taller de refrigeración de punta a punta: clientes " +
                "y sus equipos, órdenes de trabajo con estados y numeración correlativa, presupuestos, stock de " +
                "repuestos con historial de precios, cobros parciales con control de saldo, gastos, garantías y " +
                "adjuntos de fotos y comprobantes.\n\n" +
                "La misma interfaz Blazor se comparte entre la versión de escritorio (WPF + BlazorWebView) y la app " +
                "Android (.NET MAUI Blazor Hybrid). Funciona completamente offline con SQLite, genera reportes en " +
                "Excel y PDF, hace backups y sincroniza los datos entre dispositivos por archivo con estrategia " +
                "last-write-wins. Incluye consulta de precios de repuestos en Mercado Libre y una suite de pruebas " +
                "automatizadas que cubre el núcleo de negocio.",
            Technologies = new() { ".NET 10", "WPF + BlazorWebView", ".NET MAUI Blazor Hybrid", "SQLite", "Entity Framework Core", "Clean Architecture", "ClosedXML (Excel)", "QuestPDF" },
            Features = new()
            {
                "Clientes y equipos",
                "Órdenes de trabajo con estados y numeración automática",
                "Presupuestos con detalle de repuestos y mano de obra",
                "Stock de repuestos, movimientos e historial de precios",
                "Cobros parciales con control de saldo",
                "Gastos y cálculo de ganancia neta",
                "Garantías",
                "Fotos y comprobantes adjuntos",
                "Exportación a Excel y PDF",
                "Backups y sincronización entre dispositivos",
                "Consulta de precios en Mercado Libre",
                "Pruebas automatizadas del núcleo de negocio"
            },
            ProblemSolved =
                "Un taller de refrigeración suele llevar órdenes, repuestos y cobros en papel o planillas sueltas, " +
                "sin trazabilidad ni control de deuda. Refricontrol centraliza toda la operación en una app que " +
                "funciona sin internet, tanto en la PC del taller como en el celular.",
            WhatItDemonstrates =
                "Clean Architecture real en .NET compartiendo la misma UI Blazor entre escritorio y mobile, diseño " +
                "de un motor de sincronización offline (last-write-wins), validaciones de negocio con resultados " +
                "tipados (OperationResult), generación de reportes Excel/PDF y cobertura con tests automatizados."
        },
        new Project
        {
            Name = "EmpresaOps — Plataforma SaaS Multitenant",
            Slug = "empresaops-multitenant",
            Type = "SaaS / Arquitectura multitenant",
            Status = ProjectStatus.Demo,
            ShortDescription = "Plataforma multitenant de órdenes de trabajo para empresas de servicios: varias empresas en una misma app, cada una viendo solo sus datos.",
            LongDescription =
                "MVP empresarial multitenant orientado a empresas de servicios (mantenimiento, soporte técnico, " +
                "instalaciones). Múltiples empresas usan la misma aplicación, y el aislamiento de datos está " +
                "garantizado por diseño: el TenantId se resuelve siempre desde el JWT del usuario y el DbContext " +
                "aplica filtros globales de EF Core a toda entidad de negocio, de modo que ninguna consulta puede " +
                "devolver datos de otra empresa.\n\n" +
                "La solución sigue Clean Architecture y se compone de una Web API con Swagger, un frontend Blazor " +
                "con MudBlazor y una app móvil para técnicos en .NET MAUI Blazor Hybrid. Se levanta con un solo " +
                "comando vía Docker Compose (SQL Server + API, con migraciones y datos de prueba automáticos).",
            Technologies = new() { "ASP.NET Core Web API", "Blazor", "MudBlazor", ".NET MAUI Blazor Hybrid", "SQL Server", "Entity Framework Core", "JWT", "Docker", "Clean Architecture" },
            Features = new()
            {
                "Multitenancy con TenantId resuelto desde el JWT",
                "Filtros globales de EF Core por tenant",
                "Órdenes de trabajo para empresas de servicios",
                "API REST documentada con Swagger",
                "Frontend web con MudBlazor",
                "App móvil para técnicos",
                "Seed automático de empresas de prueba",
                "Docker Compose para levantar todo con un comando",
                "Estructura Clean Architecture"
            },
            ProblemSolved =
                "Cuando un producto se vende a varias empresas, duplicar la aplicación por cliente no escala. " +
                "EmpresaOps opera todos los clientes desde una sola base de código con los datos aislados de forma " +
                "segura a nivel de infraestructura, no de disciplina.",
            WhatItDemonstrates =
                "Diseño multitenant seguro (el tenant nunca viene del request, siempre del token), Clean " +
                "Architecture con capas bien separadas, integración de tres frontends (web, móvil, API) sobre el " +
                "mismo dominio y containerización del entorno de desarrollo."
        },
        new Project
        {
            Name = "Sistema de Gestión Administrativa",
            Slug = "gestion-administrativa",
            Type = "Fullstack / Sistema empresarial",
            Status = ProjectStatus.Demo,
            ShortDescription = "Sistema web genérico para gestión administrativa: ABM de registros, usuarios, permisos, formularios y paneles de control.",
            LongDescription =
                "Sistema web pensado como base para cualquier operación administrativa. Incluye ABM completo de " +
                "entidades, gestión de usuarios con roles y permisos, formularios con validaciones en frontend y " +
                "backend, filtros y búsquedas sobre listados, y paneles de control con indicadores de estado.\n\n" +
                "La aplicación está estructurada por capas: un frontend Blazor con MudBlazor que consume una " +
                "Web API en ASP.NET Core, con autenticación JWT y acceso a datos mediante Entity Framework Core " +
                "sobre SQL Server.",
            Technologies = new() { "Blazor", "MudBlazor", "ASP.NET Core Web API", "SQL Server", "Entity Framework Core", "JWT" },
            Features = new()
            {
                "ABM de entidades",
                "Validaciones de formularios",
                "Modales de creación, edición y eliminación",
                "Manejo de permisos por rol",
                "Filtros y búsquedas",
                "Integración frontend/backend",
                "Diseño responsive",
                "Control de errores centralizado",
                "Estructura por capas"
            },
            ProblemSolved =
                "Muchos negocios administran su operación en planillas dispersas, sin validaciones ni control de " +
                "acceso. Este sistema centraliza los datos, garantiza consistencia con validaciones y da a cada " +
                "usuario acceso solo a lo que le corresponde.",
            WhatItDemonstrates =
                "Integración completa entre Blazor y una Web API, diseño de un esquema de permisos flexible, " +
                "validaciones consistentes en ambos extremos y organización de una solución .NET por capas " +
                "pensada para crecer."
        },
        new Project
        {
            Name = "App de Finanzas Personales",
            Slug = "finanzas-personales",
            Type = "App local / Dashboard personal",
            Status = ProjectStatus.EnDesarrollo,
            ShortDescription = "Aplicación para registrar gastos, ingresos, cuentas y categorías, con balances y reportes personales.",
            LongDescription =
                "Aplicación híbrida para llevar las finanzas personales del día a día: registro de ingresos y " +
                "gastos, cuentas propias, categorías personalizables y soporte de múltiples monedas.\n\n" +
                "Un dashboard resume el balance general y la evolución mensual, y el historial de movimientos " +
                "permite filtrar por cuenta, categoría y período. Todos los datos se guardan localmente en " +
                "SQLite, sin depender de servicios externos.",
            Technologies = new() { ".NET MAUI Blazor Hybrid", "C#", "SQLite", "Entity Framework Core" },
            Features = new()
            {
                "Registro de ingresos y gastos",
                "Cuentas personales",
                "Categorías personalizables",
                "Soporte de múltiples monedas",
                "Dashboard de resumen",
                "Historial de movimientos",
                "Almacenamiento local",
                "Diseño simple y responsive"
            },
            ProblemSolved =
                "Llevar las finanzas personales suele terminar en planillas que nadie mantiene. La app hace que " +
                "registrar un movimiento tome segundos y muestra de un vistazo en qué se va el dinero cada mes.",
            WhatItDemonstrates =
                "Desarrollo con .NET MAUI Blazor Hybrid reutilizando componentes Blazor en una app nativa, " +
                "persistencia local con SQLite + EF Core y diseño de un modelo de datos para movimientos, " +
                "cuentas y monedas."
        },
        new Project
        {
            Name = "App de Entrenamiento y Caminatas",
            Slug = "entrenamiento-caminatas",
            Type = "App personal / Fitness tracking",
            Status = ProjectStatus.EnDesarrollo,
            ShortDescription = "App para registrar caminatas, distancia, ritmo, peso corporal y progreso mensual.",
            LongDescription =
                "Aplicación personal de seguimiento de actividad física orientada a caminatas. Permite iniciar y " +
                "finalizar una actividad, registrar distancia y ritmo, y llevar un historial completo de " +
                "sesiones.\n\n" +
                "Además incluye registro de peso corporal y una vista de progreso mensual con métricas simples: " +
                "kilómetros acumulados, ritmo promedio y evolución del peso. La interfaz está pensada para uso " +
                "diario, con pocas pantallas y acciones directas.",
            Technologies = new() { ".NET MAUI", "Blazor Hybrid", "C#", "Almacenamiento local" },
            Features = new()
            {
                "Iniciar y finalizar actividad",
                "Registro de distancia",
                "Registro de ritmo",
                "Historial de caminatas",
                "Registro de peso corporal",
                "Progreso mensual",
                "Métricas personales",
                "Interfaz simple para uso diario"
            },
            ProblemSolved =
                "Las apps de fitness suelen ser complejas y pedir cuentas, suscripciones y permisos de más. Esta " +
                "app resuelve el caso simple: registrar la caminata de hoy y ver el progreso del mes, sin fricción.",
            WhatItDemonstrates =
                "Diseño de una app móvil enfocada en UX minimalista, manejo de estado de una actividad en curso, " +
                "cálculo de métricas agregadas por período y persistencia local sin backend."
        },
        new Project
        {
            Name = "Gestor Local para Negocio Familiar",
            Slug = "gestor-negocio-familiar",
            Type = "App de escritorio / local",
            Status = ProjectStatus.Demo,
            ShortDescription = "Sistema local para gestionar productos, ventas, clientes y reportes básicos de un negocio pequeño.",
            LongDescription =
                "Sistema de gestión pensado para un comercio pequeño que necesita ordenar su operación sin " +
                "depender de internet ni de servicios pagos. Permite administrar productos con precios y stock, " +
                "registrar ventas, mantener una cartera de clientes y consultar reportes simples.\n\n" +
                "Funciona 100% local con base de datos SQLite y permite exportar listados y reportes a Excel " +
                "para compartirlos o respaldarlos.",
            Technologies = new() { ".NET", "Blazor Hybrid", "SQLite", "C#", "Exportación a Excel" },
            Features = new()
            {
                "Gestión de productos",
                "Registro de ventas",
                "Cartera de clientes",
                "Reportes simples",
                "Exportación a Excel",
                "Base de datos local",
                "Uso sin servidor externo"
            },
            ProblemSolved =
                "Los negocios chicos suelen manejar ventas y stock en papel o planillas sueltas. Este sistema les " +
                "da una herramienta simple, sin costos mensuales ni dependencia de conexión, para ordenar la " +
                "operación diaria.",
            WhatItDemonstrates =
                "Desarrollo de una app de escritorio con stack web (Blazor Hybrid), diseño de datos para " +
                "ventas/stock/clientes, generación de reportes y exportación a Excel, y despliegue local sin " +
                "infraestructura."
        }
    };

    // ============================================================
    // SKILLS — editar categorías y habilidades
    // ============================================================
    public IReadOnlyList<SkillCategory> GetSkillCategories() => new List<SkillCategory>
    {
        new()
        {
            Name = "Backend",
            Icon = "⚙️",
            Skills = new() { new("C#"), new(".NET"), new("ASP.NET Core"), new("APIs REST"), new("JWT / Autenticación"), new("Validaciones") }
        },
        new()
        {
            Name = "Frontend",
            Icon = "🖥️",
            Skills = new() { new("Blazor (Server / WASM / Hybrid)"), new("MudBlazor"), new("Componentes reutilizables"), new("Formularios y modales"), new("Diseño responsive"), new("HTML / CSS") }
        },
        new()
        {
            Name = "Base de datos",
            Icon = "🗄️",
            Skills = new() { new("SQL Server"), new("Entity Framework Core"), new("Dapper"), new("SQLite"), new("Diseño de esquemas"), new("Optimización de consultas") }
        },
        new()
        {
            Name = "Arquitectura",
            Icon = "🏗️",
            Skills = new() { new("Clean Architecture"), new("Estructura por capas"), new("Inyección de dependencias"), new("DTOs y mapeos"), new("Multitenancy"), new("Manejo de permisos") }
        },
        new()
        {
            Name = "Herramientas",
            Icon = "🧰",
            Skills = new() { new("Visual Studio"), new("Git"), new("Postman / Swagger"), new("SQL Server Management Studio"), new("NuGet") }
        },
        new()
        {
            Name = "Calidad / Debugging",
            Icon = "🔍",
            Skills = new() { new("Resolución de bugs"), new("Control de errores"), new("Logging"), new("Optimización de rendimiento"), new("Refactorización"), new("Revisión de código") }
        }
    };

    // ============================================================
    // SNIPPETS DE CÓDIGO — ejemplos genéricos y editables
    // ============================================================
    public IReadOnlyList<CodeSnippet> GetCodeSnippets() => new List<CodeSnippet>
    {
        new()
        {
            Title = "Servicio de API con HttpClient",
            Language = "csharp",
            Description = "Servicio típico del frontend Blazor para consumir una Web API, con manejo de errores y respuesta tipada.",
            Code = """
public class ProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http) => _http = http;

    public async Task<ApiResponse<List<ProductDto>>> GetAllAsync(string? search = null)
    {
        try
        {
            var url = string.IsNullOrWhiteSpace(search)
                ? "api/products"
                : $"api/products?search={Uri.EscapeDataString(search)}";

            var response = await _http.GetFromJsonAsync<ApiResponse<List<ProductDto>>>(url);
            return response ?? ApiResponse<List<ProductDto>>.Fail("Respuesta vacía del servidor.");
        }
        catch (HttpRequestException)
        {
            return ApiResponse<List<ProductDto>>.Fail("No se pudo conectar con el servidor.");
        }
    }

    public async Task<ApiResponse<ProductDto>> CreateAsync(CreateProductRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/products", request);
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<ProductDto>>();
        return result ?? ApiResponse<ProductDto>.Fail("Error al crear el producto.");
    }
}
"""
        },
        new()
        {
            Title = "Validador con FluentValidation",
            Language = "csharp",
            Description = "Validación de un request de creación, con reglas encadenadas y mensajes claros para el usuario.",
            Code = """
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("El precio debe ser mayor a cero.");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Debe seleccionar una categoría.");
    }
}
"""
        },
        new()
        {
            Title = "Componente Blazor reutilizable",
            Language = "razor",
            Description = "Modal de confirmación genérico: se reutiliza en cualquier ABM para confirmar eliminaciones u otras acciones.",
            Code = """
@* ConfirmDialog.razor *@
@if (_visible)
{
    <div class="dialog-backdrop">
        <div class="dialog">
            <h3>@Title</h3>
            <p>@Message</p>
            <div class="dialog-actions">
                <button class="btn-secondary" @onclick="() => Close(false)">Cancelar</button>
                <button class="btn-danger" @onclick="() => Close(true)">Confirmar</button>
            </div>
        </div>
    </div>
}

@code {
    [Parameter] public string Title { get; set; } = "Confirmar";
    [Parameter] public string Message { get; set; } = "¿Estás seguro?";
    [Parameter] public EventCallback<bool> OnClose { get; set; }

    private bool _visible;

    public void Show() { _visible = true; StateHasChanged(); }

    private async Task Close(bool confirmed)
    {
        _visible = false;
        await OnClose.InvokeAsync(confirmed);
    }
}
"""
        },
        new()
        {
            Title = "DTO y request de ejemplo",
            Language = "csharp",
            Description = "Separación entre la entidad de dominio y lo que viaja por la API: DTO de lectura y request de escritura.",
            Code = """
// Lo que la API devuelve al frontend
public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

// Lo que el frontend envía para crear
public class CreateProductRequest
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
}
"""
        },
        new()
        {
            Title = "Estructura de respuesta de API",
            Language = "csharp",
            Description = "Envoltorio genérico para respuestas de la API: éxito, datos y errores en un formato consistente.",
            Code = """
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public List<string> Errors { get; set; } = new();

    public static ApiResponse<T> Ok(T data, string? message = null) =>
        new() { Success = true, Data = data, Message = message };

    public static ApiResponse<T> Fail(string message, List<string>? errors = null) =>
        new() { Success = false, Message = message, Errors = errors ?? new() };
}
"""
        }
    };
}
