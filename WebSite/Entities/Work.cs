namespace WebSite.Entities
{
    public class Work
    {
        public int Id { get; set; }

        public string? ImgSrc { get; set; }

        public string? BigImgSrc { get; set; }

        public string? ImgAlt { get; set; }


        public string? Title { get; set; }

        public string? Category { get; set; }

        public string? Description { get; set; }

        public string? Content { get; set; }

        public string? Keywords { get; set; }

        public string? Slug { get; set; }
    }
}