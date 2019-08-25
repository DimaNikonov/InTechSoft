using TestTaskWebApi.DAL.Entitties;
using TestTaskWebApi.DAL.Interfaces;

namespace TestTaskWebApi.DAL.Repositories
{
    public class FaqGroupRepository : Repository<FaqGroup>, IFaqGroupRepository
    {
        public FaqGroupRepository(AppContext dbContext) : base(dbContext)
        {
        }
    }
}
