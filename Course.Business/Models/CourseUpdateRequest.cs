namespace Course.Business.Models
{
    public class CourseUpdateRequest
    {
        public string Id { get; set; } = null!;
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
        public int? Articles { get; set; }
        public int? DownloadeableResources { get; set; }
        public string? Description { get; set; }
        public string[]? DescriptionList { get; set; }
        public string[]? Categories { get; set; }
        public virtual List<AuthorUpdateRequest>? Authors { get; set; }
        public virtual PriceUpdateRequest? Prices { get; set; }

        public virtual List<ProgramDetailsUpdateRequest>? ProgramDetails { get; set; }
    }

    public class ProgramDetailsUpdateRequest
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
    }

    public class PriceUpdateRequest
    {
        public decimal? Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string? Currency { get; set; }
    }

    public class AuthorUpdateRequest
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Text { get; set; }
    }
}
