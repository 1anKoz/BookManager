namespace BookManagerApp.ViewModels
{
    public class EditShelfViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? IconImg { get; set; }
        public string? IconUrl { get; set; }
    }
}
