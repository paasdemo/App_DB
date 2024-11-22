using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_DB.Models
{
    public class Products
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Proid { get; set; }
        public string? Proname { get; set; }
        public int Proprice { get; set; }
        public string? Prodesc { get; set; }
        public int Procateid { get; set; }

    }
}
