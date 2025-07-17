using Microsoft.AspNetCore.Mvc;

namespace PDFControl.Controllers
{
    public class UploadPDFController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadPDFS(IFormFile pdfFile)
        {
            System.IO.File.WriteAllText("log.txt", "Entró al controlador");
            try
            {
                if (pdfFile == null || pdfFile.Length == 0 || Path.GetExtension(pdfFile.FileName) != ".pdf")
                {
                    ViewBag.Message = "Error al cargar archivo, verifique el tipo de archivo";
                    return View();
                }
                else if (pdfFile.Length > 10 * 1024 * 1024)
                {
                    return View();
                }
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                var filePath = Path.Combine(folderPath, pdfFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await pdfFile.CopyToAsync(stream);
                }
                return StatusCode(200, "Se ha subido con exito");
            }
            catch(Exception e){
                return StatusCode(500, $"Error al subir el archivo: {e.Message}"); ;
            }
            
        }
    }
}
