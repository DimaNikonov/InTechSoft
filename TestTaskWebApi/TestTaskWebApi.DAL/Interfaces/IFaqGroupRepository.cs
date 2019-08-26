using System.Collections.Generic;
using TestTaskWebApi.DAL.Entitties;

namespace TestTaskWebApi.DAL.Interfaces
{
    public interface IFaqGroupRepository : IRepository<FaqGroup>
    {
        IEnumerable<FaqGroup> Search(string searchPattern);
    }
}
