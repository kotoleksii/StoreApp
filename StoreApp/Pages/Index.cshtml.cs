using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration Configuration;
        public string AppName { get; set; }

        public IndexModel(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public void OnGet()
        {
            string appName = Configuration.GetSection("AppSettings")["AppName"];

            AppName = appName;
        }
    }
}
