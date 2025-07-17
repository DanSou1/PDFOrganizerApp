namespace PDFControl.Models
{
    public class LogprocessModel
    {
        public int id { get; set; }
        public string originalFileName { get; set; }
        public string existingState { get; set; }
        public string newFileName { get; set; }
        public string dateProcces { get; set; }
    }
}
