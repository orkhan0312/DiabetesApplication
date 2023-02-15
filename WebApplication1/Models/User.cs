using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required(ErrorMessage ="Please Enter First Name")]
    [Display(Name = "Please Enter First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage ="Please Enter Last Name")]
    [Display(Name = "Please Enter Last Name")]
    public string LastName { get; set; }

    [MaxLength(450)]
    /* [Index(IsUnique = true)]*/
    [Required(ErrorMessage ="Please Enter Username")]
    [Display(Name = "Please Enter Username")]
    public string Username { get; set; }

    [Required(ErrorMessage ="Please Enter Password")]
    [Display(Name = "Please Enter Password")]
    [MaxLength(16)]
    public string Password { get; set; }

    [Required(ErrorMessage ="Please Enter Age")]
    [Display(Name = "Please Enter First Age")]
    public int Age { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public class UsersViewModel
    {
        public List<User> Users { get; set; }
    }
}