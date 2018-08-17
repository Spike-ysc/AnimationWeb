namespace AnimationWeb.Areas.News.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewsModel : DbContext
    {
        public NewsModel()
            : base("name=NewsModel")
        {
        }

        public virtual DbSet<NewsPage> NewsPage { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
