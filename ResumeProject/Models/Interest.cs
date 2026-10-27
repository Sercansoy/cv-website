using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeProject.Models
{
    public class Interest
    {
        [Key]
        public int InterestID { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(300)]
        public string Title { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(300)]
        public string Description { get; set; }
    }
}