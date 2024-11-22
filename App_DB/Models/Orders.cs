using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App_DB.Models
{
    public class Orders
    {
        [Key]
        public int Orderid { get; set; }
        public int Orderuserid { get; set; }
        public DateTime Ordardate { get; set; }
        public int Orderamount { get; set; }

    }
}
