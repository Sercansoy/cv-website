using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeProject.Models
{
    public class Skills
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Skill { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Icon { get; set; }

        public bool IsLearning { get; set; }

        [Column(TypeName = "tinyint")]
        public byte Progress { get; set; }
    }
}