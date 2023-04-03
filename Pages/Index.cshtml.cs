using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SessionManagementApp.Forms;
using System.Collections.Generic;
using System.Net;
using Microsoft.Extensions.Logging;
using SessionManagementApp.ExtensionMethods;

namespace SessionManagementApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    
    [BindProperty]
    public YearNameForm YearNameForm { get; set; }

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
            HttpContext.Session.SetString("YearNameForm", JsonConvert.SerializeObject(YearNameForm));
        }
        return Page();
    }
}