using ProjectPapers.DB.Data;
using ProjectPapers.DB.Models;

namespace ProjectPapers.DB.Models
{
    public class PaperSearch
    {
        public PaperCriteria Criteria { get; set; }
        public IList<Paper> Results { get; set; }
    }
}
