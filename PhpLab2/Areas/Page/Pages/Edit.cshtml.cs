using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhpLab2.Areas.Page.Pages
{
    public class EditModel : PageModel
    {
        public PageService pageService { get; set; }
        public string Title { get; set; }
        public EditModel()
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

            page.Intro_En = Request.Form["Intro_en"].ToString();
            page.Intro_UA = Request.Form["Intro_ua"].ToString();
            page.Content_En = Request.Form["Content_en"].ToString();
            page.Content_UA = Request.Form["Content_ua"].ToString();

            pageService.SaveChagedPage(page);
            //pageService.addPage(new DBService.Entitties.Page() { Caption = caption, Intro_En = Intro_en, Intro_UA = Intro_ua, Content_En = Content_en, Content_UA = Content_ua, ContainerType = Container }, BaseCategory);
        }

    }
}
