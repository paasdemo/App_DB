using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace App_DB.Models
{
    [PrimaryKey(nameof(Cartid),nameof(Proid))]
    public class Cartdetail
    {
        
        public int Cartid { get; set; }
        public int Proid  { get; set; }
        public int Quantity { get; set; }

    }
}
