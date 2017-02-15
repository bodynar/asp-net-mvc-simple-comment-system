namespace AspNetMvc.SimpleCommentSystem.EF
{
    #region References
    using System.Data.Entity;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    #endregion

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AppDbContext Create()
            => new AppDbContext();

        public virtual DbSet<News> News { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

    }

    public class AppDbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            
            // and another one

            base.Seed(context);
        }

    }
}