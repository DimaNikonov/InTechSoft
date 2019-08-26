using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestTaskWebApi.DAL.Entitties;
using TestTaskWebApi.DAL.Interfaces;

namespace TestTaskWebApi.DAL.Repositories
{
    public class FaqGroupRepository : Repository<FaqGroup>, IFaqGroupRepository
    {
        public FaqGroupRepository(AppContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<FaqGroup> Search(string searchPattern)
        {
            var faqGroups=dbContext.FaqGroups.Include(x => x.FaqQuestions);
            return faqGroups.Where(x => x.Title.Contains(searchPattern) || x.FaqQuestions.Any(t => t.Question.Contains(searchPattern) || t.Answer.Contains(searchPattern))).Select(x=>x);
        }
    }
}
