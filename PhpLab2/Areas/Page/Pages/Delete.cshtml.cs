using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhpLab2.Areas.Page.Pages
{
    public class DeleteModel : PageModel
    {
        public PageService pageService { get; set; }
        public string Title { get; set; }

        public DeleteModel()
        {
            pageService = new PageService();
        }
        public void OnGet(string title)
        {
            Title = title;
        }

        public void OnPost(string title)
        {
            var page = pageService.GetPageByCaption(title);
            pageService.DeletePage(page);
        }
    }
}
