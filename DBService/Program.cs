using DBService.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DBService
{
    class Program
    {
        static void Main(string[] args)
        {
            PageService service = new PageService();
            //service.addPage(new Entitties.Page()
            //{ Content_UA = "text", Caption = "some", ContainerType = "container" },
            //    null);
            //service.addPage(new Entitties.Page() 
            //{ Content_UA = "text", Caption = "first_Category", ContainerType = "container" },
            //    "some");
            //service.addPage(new Entitties.Page()
            //{ Content_UA = "text", Caption = "second_Category", ContainerType = "container" },
            //   "some");
            //service.addPage(new Entitties.Page()
            //{ Content_UA = "text", Caption = "first_second_item", ContainerType = "single" },
            //   "second_Category");
            //service.addPage(new Entitties.Page()
            //{ Content_UA = "text", Caption = "second_second_item", ContainerType = "single" },
            //  "second_Category");
            //service.addPage(new Entitties.Page()
            //{ Content_UA = "text", Caption = "first_first_item", ContainerType = "single" },
            //   "first_Category");
            //service.addPage(new Entitties.Page()
            //{ Content_UA = "text", Caption = "second_first_item", ContainerType = "single" },
            //  "first_Category");

            //service.addPage(new Entitties.Page()
            //{ Content_UA = "text", Caption = "alias_Category", ContainerType = "container" },
            //    "some");
            service.addAlias("first_second_item", new Entitties.Page()
            { Content_UA = "text_alias", Content_En = "text_alias", Caption = "first_second_item_alias", ContainerType = "single", },
               "alias_Category");

            using (var context = new ApplicationContext())
            {
                var query = context.Pages.Include(e => e.Parent).ToList();
                foreach (var employee in query)
                {
                    Console.WriteLine("{0} {1}", employee.PageId, employee.ParentId);
                }
                var baseItem = query.First(i => i.Caption == "some");
                var childer = query.Where(i => i.Parent == baseItem).ToList();
                Console.WriteLine(childer.Count);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
