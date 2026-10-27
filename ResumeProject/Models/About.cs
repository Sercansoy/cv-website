using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeProject.Models
{
    public class About
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        [Required(ErrorMessage = "Name field cannot be empty.")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20, ErrorMessage ="Last Name cannot exceed 20 characters.")]
        [Required(ErrorMessage = "LastName field cannot be empty.")]
        public string LastName { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(70, ErrorMessage = "Address cannot exceed 70 characters.")]
        [Required(ErrorMessage = "Address field cannot be empty.")]
        public string Address {  get; set; }

        [Column(TypeName ="varchar")]
        [StringLength (20, ErrorMessage = "Phone Number cannot exceed 20 characters.")]
        [Required(ErrorMessage = "Phone Number field cannot be empty.")]
        public string PhoneNumber { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(30, ErrorMessage = "Email cannot exceed 30 characters.")]
        [Required(ErrorMessage = "Email field cannot be empty.")]
        public string  EMail { get; set; }

        [Column(TypeName ="varchar(MAX)")]
        public string Details { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250, ErrorMessage = "ImageURL cannot exceed 250 characters.")]
        public string ImageUrl { get; set; }

    }
}