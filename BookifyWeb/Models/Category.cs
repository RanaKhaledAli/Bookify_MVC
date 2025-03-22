using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookifyWeb.Models
{
    public class Category
    {
        
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }
        //If we have multiple categories, which category should be displayed first on the page
        [DisplayName("Display Order")]
        [Range(1, 100,ErrorMessage ="Display Order must be between 1-100")]          
        public int DisplayOrder { get; set; }
    }
}
