using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeProject.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }

        [Column(TypeName =("varchar"))]
        [StringLength(100)]
        public string Title { get; set; }

        [Column(TypeName =("varchar"))]
        [StringLength(100)]
        public string Company { get; set; }

        [Column(TypeName = ("varchar"))]
        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Date { get; set; }
    }
}