namespace AnimationWeb.Areas.News.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsPage")]
    public partial class NewsPage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string link { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        [StringLength(50)]
        public string time { get; set; }

        [Required]
        [StringLength(50)]
        public string decription { get; set; }

        [Required]
        [StringLength(50)]
        public string img { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }
    }
}
