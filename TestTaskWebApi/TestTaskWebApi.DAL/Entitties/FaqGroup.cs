using System.Collections.Generic;

namespace TestTaskWebApi.DAL.Entitties
{
    public class FaqGroup
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<FaqQuestion> FaqQuestions { get; set; }
    }
}
