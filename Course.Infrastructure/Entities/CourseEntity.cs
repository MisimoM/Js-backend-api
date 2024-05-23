using System.ComponentModel.DataAnnotations;

namespace Course.Infrastructure.Entities
{
    public class CourseEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        //CourseHeader
        public string? ImageUrl { get; set; }
        public bool? IsBestSeller { get; set; }
        public bool? IsDigital { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public int? StarRating { get; set; }
        public int? Reviews { get; set; }
        public int? Likes { get; set; }
        public int? LikesInPercent { get; set; }
        public int? Hours { get; set; }

        //InfoCard
        public int? Articles { get; set; }
        public int? DownloadeableResources { get; set; }

        //CourseDescription
        public string? Description { get; set; }
        public string[]? DescriptionList { get; set; }

        public string[]? Categories { get; set; }

        public virtual List<AuthorEntity>? Authors { get; set; }
        public virtual PriceEntity? Prices { get; set; }

        public virtual List<ProgramDetailsEntity>? ProgramDetails {  get; set; }
    }

}
