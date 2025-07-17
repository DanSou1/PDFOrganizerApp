using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace PDFProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : Controller
    {
        [HttpPost]
        [RequestSizeLimit(10 * 1024 * 1024)]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0 || !Path.GetExtension(file.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Por favor suba un archivo PDF válido.");
            }

            try
            {
                string targetFolder = @"C:\PruebaEQ";
                Directory.CreateDirectory(targetFolder);
                string filePath = Path.Combine(targetFolder, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Ok(new { Message = "Archivo subido exitosamente.", FilePath = filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al procesar el archivo: {ex.Message}");
            }
        }
    }
}
