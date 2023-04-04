using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SessionManagementApp.Forms;

namespace SessionManagementApp.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<YearNameForm> YearNameForms { get; set; }

        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("YearNameForms");

            if (Data != null)
            {
                YearNameForms = JsonConvert.DeserializeObject<List<YearNameForm>>(Data);
            }
        }
    }
}
