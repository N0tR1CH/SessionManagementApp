using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SessionManagementApp.Forms;
using System.Collections.Generic;
using System.Net;
using Microsoft.Extensions.Logging;

namespace SessionManagementApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    
    [BindProperty]
    public YearNameForm YearNameForm { get; set; }
    
    public List<YearNameForm> YearNameForms { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    
    public void OnGet()
    {
    }
    
    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            var Data = HttpContext.Session.GetString("YearNameForms");
            
            if (Data != null)
                YearNameForms = JsonConvert.DeserializeObject<List<YearNameForm>>(Data);
            else
                YearNameForms = new List<YearNameForm>();
            
            YearNameForms.Add(YearNameForm);
            
            HttpContext.Session.SetString("YearNameForms", JsonConvert.SerializeObject(YearNameForms));
        }
        return Page();
    }
}