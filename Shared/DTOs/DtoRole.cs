namespace TaskApi.Shared.DTOs
{
    public record DtoRole:DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string MainImageUrl { get; set; }
        public List<string> SecondaryImagesUrl { get; set; }
    }
}
