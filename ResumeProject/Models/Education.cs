using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeProject.Models
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        [Required(ErrorMessage = "Title field cannot be empty.")]
        public string Title { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100, ErrorMessage ="Subtitle cannot exceed 100 characters.")]
        [Required(ErrorMessage ="Subtitle field cannot be empty.")]
        public string SubTitle { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100, ErrorMessage ="Date cannot exceed 100 characters.")]
        [Required(ErrorMessage ="Date field cannot be empty.")]
        public string Date { get; set; }

    }
}