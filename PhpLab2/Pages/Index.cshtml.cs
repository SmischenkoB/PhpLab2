using DBService.Entitties;
using DBService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhpLab2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public PageService pageService { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            pageService = new PageService();
        }
        public string Title { get; set; } = "";
        public string Language { get; set; } = "";
        public void OnGet(string title, string language)
        {
            Title = title;
            Language = language;
        }
    }
}
