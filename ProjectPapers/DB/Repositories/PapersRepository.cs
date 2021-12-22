using ProjectPapers.DB.Data;
using ProjectPapers.DB.Models;
using ProjectPapers.Extensions;
using ProjectPapers.Models;
using System.Linq.Expressions;

namespace ProjectPapers.DB.Repositories
{
    public class PapersRepository : BaseRepository, IPapersRepository
    {
        public PapersRepository(DBContext dbContext) : base(dbContext) 
        { 

        }

        public async Task<PaginatedList<Paper>> Search(PaperCriteria entityParameters, uint currentPage = 1, uint pageSize = 10, string? sortByColumn = null)
        {
            var paperTitleLowered = entityParameters.PaperTitle.ToLower();
            
            if (currentPage < 1 || pageSize == 0)
            {
                throw new InvalidDataException("Pagination arguments invalid.");
            }

            var papersQuery = _dbContext
                .Papers
                .Where(paper => paper.Title.ToLower().Contains(paperTitleLowered));

            papersQuery = (sortByColumn?.Trim().ToLower()) switch
            {
                "title" => papersQuery.OrderBy(x => x.Title),
                "citationsCount" => papersQuery.OrderBy(x => x.CitationsCount),
                _ => throw new InvalidDataException("sortByColumn invalid."),
            };
            
            return await papersQuery.ToPaginatedList(currentPage, pageSize);
        }

        public async Task<Paper?> GetById(uint entityId)
        {
            return await _dbContext.FindAsync<Paper>(entityId);
        }

        public async Task<Paper> Create(Paper entity)
        {
            return (await _dbContext.Papers.AddAsync(entity)).Entity;
        }

        public Paper Update(Paper entity)
        {
            return _dbContext.Update(entity).Entity;
        }

        public void Delete(Paper entity)
        {
            _dbContext.Papers.Remove(entity);
        }
    }
}
