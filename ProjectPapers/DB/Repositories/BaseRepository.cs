namespace ProjectPapers.DB.Repositories
{
    public class BaseRepository
    {
        protected DBContext _dbContext;

        public BaseRepository(DBContext dBContext)
        {
            _dbContext = dBContext;
        }
    }
}
