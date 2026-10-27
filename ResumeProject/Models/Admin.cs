using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeProject.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(50)]
        public string User { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Password { get; set; }
    }
}