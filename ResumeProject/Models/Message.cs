using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeProject.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "Name field cannot be empty.")]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "Email field cannot be empty.")]
        public string Email { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "Subject field cannot be empty.")]
        public string Subject { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(1000, ErrorMessage ="Message cannot exceed 1000 characters")]
        [Required(ErrorMessage = "Message field cannot be empty.")]
        public string Messages { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Date field cannot be empty.")]
        public DateTime Date {  get; set; }


    }
}