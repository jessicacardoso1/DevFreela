namespace DevFreela.API.Models
{
    public class CreateProjectModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int IdClient { get; set; }

        public int idFreelancer { get; set; }

        public decimal TotalCost { get; set; }
    }
}
