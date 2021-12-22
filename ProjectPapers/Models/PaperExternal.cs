namespace ProjectPapers.Models
{
    public class PaperExternal
    {
        public uint? Id { get; set; } // TODO: index should be encrypted outwards
        public string? Title { get; set; }
        public string[]? Authors { get; set; }
        public DateOnly? DatePublished { get; set; }
        public uint? ReferencesCount { get; set; }
        public uint? CitationsCount { get; set; }
        public uint? Interactions_Clicks { get; set; }

        public PaperExternal(DB.Data.Paper paper)
        {
            Id = paper.Id;
            Title = paper.Title;
            Authors = paper.Authors;
            DatePublished = paper.DatePublished;
            CitationsCount = paper.CitationsCount;
            ReferencesCount = paper.ReferencesCount;
            Interactions_Clicks = paper.Interactions_Clicks;
        }

        public DB.Data.Paper ToDBModel()
        {
            return new DB.Data.Paper
            {
                Id = Id ?? throw new InvalidOperationException(),
                Title = !string.IsNullOrWhiteSpace(Title) ? Title.Trim() : throw new InvalidOperationException(),
                Authors = Authors?.Where(x => x != null).Select(x => x.Trim()).ToArray() ?? Array.Empty<string>(),
                DatePublished = DatePublished ?? throw new InvalidOperationException(),
                CitationsCount = CitationsCount ?? 0,
                ReferencesCount = ReferencesCount ?? 0,
                Interactions_Clicks = Interactions_Clicks ?? 0
            };
        }
    }
}
