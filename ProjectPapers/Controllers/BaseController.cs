using Microsoft.AspNetCore.Mvc;
using ProjectPapers.DB;

namespace ProjectPapers.Controllers
{
    public class BaseController : ControllerBase
    {
        protected DBContext _db;
        
        public BaseController(DBContext dBContext)
        {
            db = dBContext;
        }
    }
}
