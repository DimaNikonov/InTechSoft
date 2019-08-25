namespace TestTaskWebApi.API.Entities
{
    public class CreateFaqQuestionViewModel
    {
        public string Question { get; set; }

        public string Answer { get; set; }

        public int FaqGroupId { get; set; }
    }
}
