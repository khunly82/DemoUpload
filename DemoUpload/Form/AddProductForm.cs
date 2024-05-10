namespace DemoUpload.Form
{
    public class AddProductForm
    {
        public string Nom { get; set; } = null!;
        public IFormFile ImageFile { get; set; } = null!;
    }
}
