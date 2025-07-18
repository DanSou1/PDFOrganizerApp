# PDFOrganizerApp
Sistema de procesamiento y organización de PDFs con ASP.NET + Servicio de Windows
# 📄 Proyecto de Prueba Técnica - Procesamiento de PDFs (.NET)

Este proyecto resuelve una prueba técnica para desarrollador .NET Full Stack Junior. La solución automatiza el procesamiento de archivos PDF, permitiendo:

- Cargar archivos PDF desde una interfaz web.
- Administrar palabras clave (claves de búsqueda).
- Procesar los documentos localmente con un servicio tipo Windows que renombra y clasifica los archivos.
- Visualizar registros de procesamiento.

---

## 📁 Estructura del proyecto

/PDFProcessor ← API ASP.NET Core
/PDFManager ← Servicio Windows para procesar archivos
/Frontend ← Interfaz web (HTML, JS, CSS, Bootstrap)
/README.md ← Este instructivo


## 🧱 Requisitos

- Visual Studio 2022 o superior
- .NET 8 SDK
- SQL Server (LocalDB o instancia real)
- Postman (opcional para pruebas)
- Git (opcional para clonar)

---

## 🧱 Requisitos para compilar y ejecutar el proyecto

Para poder ejecutar correctamente el proyecto en Visual Studio, asegúrese de tener instalado lo siguiente:

### ✅ Software necesario

| Herramienta              | Versión recomendada        | Descripción                           |
|--------------------------|----------------------------|---------------------------------------|
| Visual Studio            | 2022 o superior             | Para abrir y ejecutar la solución     |
| .NET SDK                 | .NET 8.0                    | Requerido para compilar los proyectos |
| SQL Server               | 2017 o superior             | Motor de base de datos                |
| Git                      | (opcional, para clonar)     | Para trabajar desde GitHub            |

> ⚠️ Asegúrate de incluir la carga de trabajo **“Desarrollo de ASP.NET y web”** durante la instalación de Visual Studio.

---

### 📦 Paquetes NuGet utilizados

Los paquetes se restauran automáticamente al compilar. Si no, puedes ejecutarlo manualmente:

```bash
dotnet restore


## 🛠 1. Configuración de la base de datos

### Tablas requeridas:

```sql
CREATE TABLE DOCKEY (
    Id INT PRIMARY KEY IDENTITY,
    DocName VARCHAR(200) NOT NULL,
    Keystone VARCHAR(200) NOT NULL
);

CREATE TABLE LOGPROCESS (
    Id INT PRIMARY KEY IDENTITY,
    OriginalFileName VARCHAR(200) NOT NULL,
    ExistingState VARCHAR(200) NOT NULL,
    NewFileName VARCHAR(200),
    DateProcces DATETIME NOT NULL
);



🌐 2. API REST - PDFProcessor (ASP.NET Core)
Instrucciones para ejecutar:
Abrir la solución PDFProcessor.sln en Visual Studio.

Verifica que el archivo appsettings.json tenga la cadena correcta de conexión a SQL Server:

json
Copiar
Editar
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=PruebaPDF;Trusted_Connection=True;TrustServerCertificate=True;"
}
Ejecutar el proyecto (F5 o botón "Iniciar").

Swagger estará disponible en:
👉 https://localhost:7214/swagger  

Funcionalidades expuestas:
CRUD para DocKey

--- ---

## 🧪 Iniciar todo desde Visual Studio

Este proyecto contiene tres componentes:

1. **PDFProcessor** – API ASP.NET Core (maneja claves, logs y subida de archivos)
2. **PDFManager** – Servicio de consola tipo Windows que organiza los PDFs
3. **Frontend** – Interfaz web HTML, CSS, JS (se abre directamente desde el navegador)

Para facilitar la ejecución de todo el sistema al mismo tiempo desde Visual Studio, se puede configurar el arranque múltiple.

---

### 🧰 Configurar múltiples proyectos de inicio en Visual Studio

1. Abrir la solución en Visual Studio.
2. En el **Explorador de soluciones**, haz clic derecho sobre la solución (arriba de todo).
3. Selecciona **"Establecer proyectos de inicio..."**
4. En la ventana emergente:
   - Marca: ✅ **"Varios proyectos de inicio"**
   - Asigna la acción **"Iniciar"** a los siguientes proyectos:

   | Proyecto       | Acción  |
   |----------------|---------|
   | PDFProcessor   | Iniciar |
   | PDFManager     | Iniciar |
   | PDFControl     | Iniciar |

5. Clic en **Aceptar**.

---


⚙️ 3. Servicio de procesamiento PDF - PDFManager
¿Qué hace?
Se ejecuta en segundo plano.

Analiza todos los PDFs en C:\PruebaEQ

Busca palabras clave desde la base de datos

Renombra y mueve los archivos:

A C:\PruebaEQ\OCR si encuentra coincidencias

A C:\PruebaEQ\UNKNOWN si no encuentra nada

Guarda un log del resultado en SQL Server.


---Cómo compilar y publicar:
Abrir el proyecto PDFManager en Visual Studio.

Verifica que la conexión a la base de datos esté en AppDbContext.cs o en Program.cs.

Da clic derecho al proyecto → Publicar

Publica en una carpeta local como C:\Servicios\PDFManager

puedes ejecutarlo como .exe manualmente para pruebas.

---💻 4. Frontend Web - HTML/JS/CSS/Bootstrap
¿Qué hace?
Permite subir archivos PDF

Permite agregar, editar y eliminar claves (DocKey)

Visualiza la tabla de logs

¿Cómo ejecutarlo?
Abre el archivo index.html con tu navegador.

Asegúrate de que la API esté corriendo en https://localhost:7214

Las acciones se conectan vía fetch() con la API.

--- ✅ Comprobaciones
 API conectada con SQL Server

 Servicio clasifica archivos correctamente

 Frontend funcional con JS puro + Bootstrap

 Carga archivos, administra claves y muestra logs

 Proyecto separado en 3 capas bien organizadas

 Código comentado y limpio

 🧠 Créditos
Proyecto desarrollado por Daniel Sulaiman como parte de una prueba técnica .NET
