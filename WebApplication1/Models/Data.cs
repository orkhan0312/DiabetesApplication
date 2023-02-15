using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Data
{
    [Key]
    public int DataID { get; set; }

    [Required]
    public int UserID { get; set; }

    public DateTime Date { get; set; }

    [Required]
    public double GlucoseLevel { get; set; }

    [Required]
    public double SugarConsumption { get; set; }

    [Required]
    public double PhysicalActivity { get; set; }

    [Required]
    public double BloodPressure { get; set; }
}