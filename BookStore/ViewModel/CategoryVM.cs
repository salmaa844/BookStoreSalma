using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class CategoryVM

    {
        public int Id { get; set; }
        [Required(ErrorMessage = "category is required")]
        [MaxLength(30)]
        [Remote("ChakeName",null,ErrorMessage ="existsssss")]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;


    }

}
