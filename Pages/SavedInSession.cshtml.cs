using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SessionManagementApp.Forms;

namespace SessionManagementApp.Pages
{
    public class SavedInSessionModel : PageModel
    {
        private static List<YearNameForm> YearNameForms = new List<YearNameForm>();
        public YearNameForm YearNameForm { get; set; }
        
        public List<YearNameForm> GetYearNameForms()
        {
            return YearNameForms;
        }
        
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("YearNameForm");

            if (Data != null)
            {
                YearNameForm = JsonConvert.DeserializeObject<YearNameForm>(Data);
                YearNameForms.Add(YearNameForm);
            }
        }
    }
}
