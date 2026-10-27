using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ResumeProject.Models
{
    public class Context : DbContext
    {
        public DbSet<About> Abouts { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Certificate> Certificates { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Skills> Skills { get; set; }

        public DbSet<Social_media> Social_Medias { get; set; }
    }
}