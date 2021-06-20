using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhpLab2.Areas.Page.Pages
{
    public class CreateModel : PageModel
    {
        public PageService pageService { get; set; }
        public CreateModel()
        {
            pageService = new PageService(); 
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            var caption = Request.Form["Caption"].ToString();
            var BaseCategory = Request.Form["BaseCategory"].ToString();
            var Intro_en = Request.Form["Intro_en"].ToString();
            var Intro_ua = Request.Form["Intro_ua"].ToString();
            var Content_en = Request.Form["Content_en"].ToString();
            var Content_ua = Request.Form["Content_ua"].ToString();
            var Container = Request.Form["container"].ToString();


            pageService.addPage(new DBService.Entitties.Page() { Caption = caption, Intro_En = Intro_en, Intro_UA = Intro_ua, Content_En = Content_en, Content_UA = Content_ua, ContainerType = Container }, BaseCategory);
        }
    }
}
