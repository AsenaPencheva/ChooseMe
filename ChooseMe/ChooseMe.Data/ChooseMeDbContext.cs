namespace ChooseMe.Web.Data
{
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ChooseMe.Models;
    using System.Linq;
    using System;
    using ChooseMe.Data;

    public class ChooseMeDbContext : IdentityDbContext<User>, IChooseMeDbContext
    {
        public ChooseMeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ChooseMeDbContext Create()
        {
            return new ChooseMeDbContext();
        }

        public virtual IDbSet<AdoptionForm> AdoptionForms { get; set; }

        public virtual IDbSet<Animal> Animals { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Form> Forms { get; set; }

        public virtual IDbSet<Godparent> Godparents { get; set; }

        public virtual IDbSet<Like> Likes { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<VolunteerForm> VolunteerForms { get; set; }

        public virtual IDbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Organization>()
                .HasMany(x => x.Animals)
                .WithRequired(x => x.Organization)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}