using System.Threading.Tasks;
using TestTaskWebApi.DAL.Interfaces;
using TestTaskWebApi.DAL.Repositories;

namespace TestTaskWebApi.DAL
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly AppContext dbContext;

        private IFaqGroupRepository faqGroupRepository;

        private IFaqQuestionRepositiry faqQuestionRepositiry;

        public UnitOfWork(AppContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task SaveAsync()
        {
            return this.dbContext.SaveChangesAsync();
        }

        public IFaqGroupRepository FaqGroupRepository => this.faqGroupRepository ?? (this.faqGroupRepository = new FaqGroupRepository(this.dbContext));

        public IFaqQuestionRepositiry FaqQuestionRepositiry => this.faqQuestionRepositiry ?? (this.faqQuestionRepositiry = new FaqQuestionRepository(this.dbContext));

    }
}
