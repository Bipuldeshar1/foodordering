using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace foodBackend.models
{
    public class CategoryModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string categoryName { get; set; }

        public string authorId { get; set; }
        public UserModel userModel { get; set; }
        
        [JsonIgnore]

        public ICollection<foodModel> foodModels { get; set; }

       



        
        
    }
}
