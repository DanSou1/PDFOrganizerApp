using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using PDFProcessor.Models;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly AppDbContext _context;

    public Worker(ILogger<Worker> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Servicio iniciado a las: {time}", DateTimeOffset.Now);

        string entryFolder = @"C:\PruebaEQ";
        string folderOCR = System.IO.Path.Combine(entryFolder, "OCR");
        string folderUNKNOWN = System.IO.Path.Combine(entryFolder, "UNKNOWN");

        // Crear carpetas si no existen
        Directory.CreateDirectory(entryFolder);
        Directory.CreateDirectory(folderOCR);
        Directory.CreateDirectory(folderUNKNOWN);

        while (!stoppingToken.IsCancellationRequested)
        {
            string[] files = Directory.GetFiles(entryFolder, "*.pdf");

            foreach (var file in files)
            {
                try
                {
                    string text = ExtractTextFromPdf(file);
                    string originalName = System.IO.Path.GetFileName(file);
                    string newName = "";
                    string destination = "";
                    string state = "Unknown";

                    var dockeys = _context.Dockeys.ToList();
                    foreach (var doc in dockeys)
                    {
                        if (text.Contains(doc.KeyStone, StringComparison.OrdinalIgnoreCase))
                        {
                            newName = $"{doc.DocName}_{originalName}";
                            destination = System.IO.Path.Combine(folderOCR, newName);
                            state = "Processed";
                            break;
                        }
                    }

                    if (state == "Processed")
                        File.Move(file, destination);
                    else
                    {
                        destination = System.IO.Path.Combine(folderUNKNOWN, originalName);
                        File.Move(file, destination);
                    }

                    var log = new Logprocess
                    {
                        OriginalFileName = originalName,
                        NewFileName = state == "Processed" ? newName : null,
                        DateProcces = DateTime.Now,
                        ExistingState = state
                    };

                    _context.Logprocesses.Add(log);
                    _context.SaveChanges();

                    _logger.LogInformation($"Archivo procesado: {originalName} - Estado: {state}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error procesando archivo: {file}. Detalles: {ex.Message}");
                }
            }

            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken); // Espera 10 segundos
        }
    }

    private string ExtractTextFromPdf(string path)
    {
        using (PdfReader reader = new PdfReader(path))
        {
            string text = "";
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, i);
            }
            return text;
        }
    }
}
