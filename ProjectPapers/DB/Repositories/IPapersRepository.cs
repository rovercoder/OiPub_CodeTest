using ProjectPapers.DB.Data;
using ProjectPapers.DB.Models;

namespace ProjectPapers.DB.Repositories
{
    public interface IPapersRepository : IBaseRepository<Paper, uint>
    {
        Task<PaginatedList<Paper>> Search(PaperCriteria entityParameters, uint currentPage = 1, uint pageSize = 10, string? sortByColumn = null);
    }
}
