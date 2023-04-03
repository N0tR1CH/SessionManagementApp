using System.ComponentModel.DataAnnotations;

namespace SessionManagementApp.Forms;

public class YearNameForm
{
   [Required]
   [Range(1899,2022)]
   [Display(Name = "Year")]
   public int Year { get; set; }
   
   [Required]
   [StringLength(100, ErrorMessage = "Maximum length is 100 characters")]
   [Display(Name = "Name")]
   public string Name { get; set; }
}