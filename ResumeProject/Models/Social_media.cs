using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeProject.Models
{
    public class Social_media
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(30)]
        public string Name { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(50)]
        public string Link { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Icon { get; set; }

        public bool Status { get; set; }
    }
}