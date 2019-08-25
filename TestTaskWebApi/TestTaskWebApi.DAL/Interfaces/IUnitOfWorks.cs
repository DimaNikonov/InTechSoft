using System.Threading.Tasks;

namespace TestTaskWebApi.DAL.Interfaces
{
    public interface IUnitOfWorks
    {
        IFaqGroupRepository FaqGroupRepository { get; }

        IFaqQuestionRepositiry FaqQuestionRepositiry { get; }

        Task SaveAsync();

    }
}
