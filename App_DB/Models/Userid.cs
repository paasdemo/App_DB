using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_DB.Models
{
    public class Userid
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        public string? loginid { get; set; }
        public string? loginpass { get; set; }
        public string? uname { get; set; }
        public string? sesid { get; set; }
    }
}
