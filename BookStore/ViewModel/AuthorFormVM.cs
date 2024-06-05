using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class AuthorFormVM
    {
        public int Id { get; set; }
        [MaxLength(50,ErrorMessage ="The Name field can`t exceed 50 character")]
        public string Name { get; set; }
    }
}
