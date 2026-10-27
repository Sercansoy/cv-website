using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeProject.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateID { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(300)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}