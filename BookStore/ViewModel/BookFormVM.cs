using BookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class BookFormVM
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        public List<SelectListItem>? Authors { get; set; }
        
        public string Publisher { get; set; } = null!;
        [Display(Name = "publish Data")]
        public DateTime publishData { get; set; } = DateTime.Now;
        [Display(Name = "choose Img")]
        public IFormFile? ImageUrl { get; set; }
        public string Description { get; set; }
        public List<int> SelectedCategories { get; set; } = new List<int>(); 

        public List<SelectListItem>? Categories { get; set; }
        public int CategoryId { get;  set; }
    }

}
