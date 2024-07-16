namespace BookManagerApp.ViewModels
{
    public class CreateShelfViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Icon { get; set; }
    }
}
