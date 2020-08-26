using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SafeCity2607last.Models;

namespace SafeCity2607last.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<SafeCity2607last.Models.ApplicationUser> ApplicationUser { get; set; }



        public DbSet<SafeCity2607last.Models.PropositionPublic> PropositionPublic { get; set; }


        public DbSet<SafeCity2607last.Models.Admin> Admin { get; set; }


        public DbSet<SafeCity2607last.Models.NumberSequence> NumberSequence { get; set; }

        public DbSet<SafeCity2607last.Models.PublicationPublic> PublicationPublic { get; set; }

      


        public DbSet<SafeCity2607last.Models.MessagePublic> MessagePublic { get; set; }


        public DbSet<SafeCity2607last.Models.ControleurdeQualité> ControleurdeQualité { get; set; }



        public DbSet<SafeCity2607last.Models.UserProfile> UserProfile { get; set; }
        public DbSet<SafeCity2607last.Models.CommentairesdePublic> CommentairesdePublic { get; set; }
    }
}
