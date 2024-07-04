using System.ComponentModel.DataAnnotations;

namespace foodBackend.models
{
    public class CategoryModel
    {
        [Required]
        public string categoryName { get; set; }
        
        
    }
}
