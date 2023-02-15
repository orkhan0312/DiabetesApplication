using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Meal
{
    [Key]
    public int MealId { get; set; }

    /*[Index(IsUnique=true)]*/
    [Required]
    public string MealTitle { get; set; } = null!; // can be nullable
    public double SugarRatio { get; set; }
    public int UserId { get; set; }
}