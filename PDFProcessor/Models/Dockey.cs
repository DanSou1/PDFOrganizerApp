using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PDFProcessor.Models;

[Table("DOCKEY")]
public partial class Dockey
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string DocName { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string KeyStone { get; set; } = null!;
}
