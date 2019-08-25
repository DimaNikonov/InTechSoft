using TestTaskWebApi.DAL.Entitties;
using TestTaskWebApi.DAL.Interfaces;

namespace TestTaskWebApi.DAL.Repositories
{
    public class FaqQuestionRepository : Repository<FaqQuestion>, IFaqQuestionRepositiry
    {
        public FaqQuestionRepository(AppContext dbContext) : base(dbContext)
        {
        }
    }
}
