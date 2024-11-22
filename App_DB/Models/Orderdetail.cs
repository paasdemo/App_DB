using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace App_DB.Models
{
    [PrimaryKey(nameof(Orderid),nameof(Proid))]
    public class Orderdetail
    {
        public Int64 Orderid { get; set; }
        public int Proid { get; set; }
        public int Orderq { get; set; }
    }
}
