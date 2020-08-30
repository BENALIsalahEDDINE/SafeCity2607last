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



        public DbSet<SafeCity2607last.Models.Proposition> Proposition { get; set; }


        public DbSet<SafeCity2607last.Models.Admin> Admin { get; set; }


        public DbSet<SafeCity2607last.Models.NumberSequence> NumberSequence { get; set; }

        public DbSet<SafeCity2607last.Models.Publication> Publication { get; set; }
        public DbSet<SafeCity2607last.Models.Publications> Publications { get; set; }

        public DbSet<SafeCity2607last.Models.Chercheur> Chercheur { get; set; }
        public DbSet<SafeCity2607last.Models.MessageRecu> MessageRecu { get; set; }
        public DbSet<SafeCity2607last.Models.MessagePersonnalise> MessagePersonnalise { get; set; }
        public DbSet<SafeCity2607last.Models.MessageAuPublic> MessageAuPublic { get; set; }
        public DbSet<SafeCity2607last.Models.CommentairesdePublic> CommentairesdePublic { get; set; }
        public DbSet<SafeCity2607last.Models.Message> Message { get; set; }
        


        public DbSet<SafeCity2607last.Models.ControleurdeQualité> ControleurdeQualité { get; set; }



        public DbSet<SafeCity2607last.Models.UserProfile> UserProfile { get; set; }
    }
}
