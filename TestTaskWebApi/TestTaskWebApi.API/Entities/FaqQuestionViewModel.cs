namespace TestTaskWebApi.API.Entities
{
    public class FaqQuestionViewModel
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public int FaqGroupId { get; set; }
    }
}
