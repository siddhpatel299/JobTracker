using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FrontEnd.Views.Shared
{
    public class LoginLayout : PageModel
    {
        private readonly ILogger<LoginLayout> _logger;

        public LoginLayout(ILogger<LoginLayout> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}