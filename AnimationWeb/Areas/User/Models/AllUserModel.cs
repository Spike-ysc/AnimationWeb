namespace AnimationWeb.Areas.User.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AllUserModel : DbContext
    {
        public AllUserModel()
            : base("name=AllUserModel1")
        {
        }

        public virtual DbSet<AdminTable> AdminTable { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
