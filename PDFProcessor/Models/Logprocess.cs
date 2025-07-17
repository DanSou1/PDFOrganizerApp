using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PDFProcessor.Models;

[Table("LOGPROCESS")]
public partial class Logprocess
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string OriginalFileName { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string ExistingState { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? NewFileName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateProcces { get; set; }
}
