using Microsoft.AspNetCore.Mvc;
using ProjectPapers.DB;
using ProjectPapers.DB.Data;
using ProjectPapers.DB.Models;
using ProjectPapers.DB.Repositories;
using ProjectPapers.Models;

namespace ProjectPapers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PapersController : BaseController
    {
        private PapersRepository papers;

        private readonly ILogger<PapersController> _logger;

        public PapersController(ILogger<PapersController> logger, DBContext dbContext) : base(dbContext)
        {
            _logger = logger;
            papers = new PapersRepository(dbContext);
        }

        [HttpGet]
        public async Task<PaginatedList<PaperExternal>> Get(PaperCriteria? paperCriteria, uint currentPage = 1, uint pageSize = 10, string sortByColumn = "Id")
        {
            PaginatedList<Paper> papersMatched;
            try
            {
                papersMatched = await papers.Search(paperCriteria ?? new PaperCriteria { PaperTitle = string.Empty }, currentPage, pageSize, sortByColumn);
            }
            catch (Exception ex)
            {
                throw new InvalidProgramException("Something went wrong.");
            }
            return new PaginatedList<PaperExternal>(papersMatched.Items.Select(x => new PaperExternal(x)).ToList(), papersMatched.TotalCount, papersMatched.CurrentPage, papersMatched.PageSize);
        }
        [HttpPut]
        public async Task<Paper> TrackClick(uint paperId)
        {
            if (paperId < 1)
            {
                throw new InvalidDataException("paperId not valid");
            }

            var paper = await papers.GetById(paperId) 
                ?? throw new InvalidDataException("Paper not found.");

            try
            {
                paper.Interactions_Clicks++;
                paper = papers.Update(paper);
            }
            catch (Exception ex)
            {
                throw new InvalidProgramException("Something went wrong.");
            }
            return paper;
        }
        [HttpPost]
        public async Task<PaperExternal> Add(PaperExternal paper)
        {
            if (paper.Id != null)
            {
                throw new InvalidDataException("Paper ID should be empty.");
            }
            try
            {
                paper = new PaperExternal(await papers.Create(paper.ToDBModel()));
            }
            catch (Exception ex)
            {
                throw new InvalidProgramException("Something went wrong.");
            }
            return paper;
        }
    }
}