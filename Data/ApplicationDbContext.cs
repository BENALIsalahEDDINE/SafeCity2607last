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

        public DbSet<SafeCity2607last.Models.MessageControleurQualité> MessageControleurQualité { get; set; }

        public DbSet<SafeCity2607last.Models.TypeProposition> TypeProposition { get; set; }

        public DbSet<SafeCity2607last.Models.Mission> Mission { get; set; }

        public DbSet<SafeCity2607last.Models.PropositionPublic> PropositionPublic { get; set; }

        public DbSet<SafeCity2607last.Models.Grade> Currency { get; set; }

        public DbSet<SafeCity2607last.Models.Admin> Admin { get; set; }

        public DbSet<SafeCity2607last.Models.TypeAdmin> TypeAdmin { get; set; }

        public DbSet<SafeCity2607last.Models.InfoPublicationControleurQ> InfoPublicationControleurQ { get; set; }

        public DbSet<SafeCity2607last.Models.Message> Message { get; set; }

        public DbSet<SafeCity2607last.Models.TypeMessage> TypeMessage { get; set; }

        public DbSet<SafeCity2607last.Models.NumberSequence> NumberSequence { get; set; }

        public DbSet<SafeCity2607last.Models.InfosMessage> InfosMessage { get; set; }

        public DbSet<SafeCity2607last.Models.PublicationPublic> PublicationPublic { get; set; }

        public DbSet<SafeCity2607last.Models.InfoMessageCQ> InfoMessageCQ { get; set; }

        public DbSet<SafeCity2607last.Models.PublicationChercheurs> PublicationChercheurs { get; set; }

        public DbSet<SafeCity2607last.Models.CommentairesdePublic> CommentairesdePublic { get; set; }

        public DbSet<SafeCity2607last.Models.DateDébutFinControleurQ> DateDébutFinControleurQ { get; set; }

        public DbSet<SafeCity2607last.Models.DateDébutFinControleurQLine> DateDébutFinControleurQLine { get; set; }

        public DbSet<SafeCity2607last.Models.PropositionsControleurQualité> PropositionsControleurQualité { get; set; }

        public DbSet<SafeCity2607last.Models.DateDébutFinAdmin> DateDébutFinAdmin { get; set; }

        public DbSet<SafeCity2607last.Models.DateDébutFinAdminLine> DateDébutFinAdminLine { get; set; }

        public DbSet<SafeCity2607last.Models.PropositionsAdmin> PropositionsAdmin { get; set; }

        public DbSet<SafeCity2607last.Models.InfosPublicationsAdmin> InfosPublicationsAdmin { get; set; }

        public DbSet<SafeCity2607last.Models.MessagePublic> MessagePublic { get; set; }

        public DbSet<SafeCity2607last.Models.SujetPublication> SujetPublication { get; set; }

        public DbSet<SafeCity2607last.Models.ControleurdeQualité> ControleurdeQualité { get; set; }

        public DbSet<SafeCity2607last.Models.TypeControleurQualité> TypeControleurQualité { get; set; }

        public DbSet<SafeCity2607last.Models.Lieu> Lieu { get; set; }

        public DbSet<SafeCity2607last.Models.UserProfile> UserProfile { get; set; }
    }
}
