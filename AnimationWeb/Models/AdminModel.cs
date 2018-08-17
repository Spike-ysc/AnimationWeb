namespace AnimationWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdminModel : DbContext
    {
        public AdminModel()
            : base("name=AdminModel")
        {
        }

        public virtual DbSet<AdminTable> AdminTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
