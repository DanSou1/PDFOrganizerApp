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

---Obtener y registrar logs (Logprocess)

Endpoint para subir archivos PDF
→ Guarda archivos en C:\PruebaEQ para ser procesados

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