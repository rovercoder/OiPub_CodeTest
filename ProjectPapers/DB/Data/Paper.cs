namespace ProjectPapers.DB.Data
{
    public class Paper
    {
        public uint Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string[] Authors { get; set; } = Array.Empty<string>();
        public DateOnly DatePublished { get; set; } = DateOnly.MinValue;
        public uint ReferencesCount { get; set; } = 0;
        public uint CitationsCount { get; set; } = 0;
        public uint Interactions_Clicks { get; set; } = 0;
    }
}
