using DBService.Entitties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBService.Services
{
    public class PageService
    {
        public void addPage(Page input, string parentName)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.Pages.FirstOrDefault(i => i.Caption == input.Caption) != null)
                {
                    return;
                }

                var basePage = parentName?.Length == 0 || parentName == null ? null : db.Pages.FirstOrDefault(i => i.Caption == parentName);
                int amountOfChilder = parentName?.Length == 0 || parentName == null ? -1 : db.Pages.Where(i => i.ParentId == basePage.PageId).Count();
                input.Parent = basePage;
                input.CustomOrder = amountOfChilder + 1;
                input.Alias = null;
                input.CreationDate = DateTime.Now;
                input.EditDate = DateTime.Now;
                //var page = new Page() { Content_UA = "text", Caption = label, CreationDate = DateTime.Now, EditDate = DateTime.Now, Parent = null, ContainerType = "single", Alias = null, CustomOrder = amountOfChilder + 1 };
                db.Pages.Add(input);
                db.SaveChanges();
            }
        }

        public void addAlias(string inputTarget, Page alias, string parentName)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.Pages.FirstOrDefault(i => i.Caption == inputTarget) == null)
                {
                    return;
                }
                var item = db.Pages.FirstOrDefault(i => i.Caption == inputTarget);
                alias.Alias = item;
                alias.Content_En = alias.Content_En == null ? item.Content_En : alias.Content_En;
                alias.Content_UA = alias.Content_UA == null ? item.Content_UA : alias.Content_UA;
                alias.Intro_En = alias.Intro_En == null ? item.Intro_En : alias.Intro_En;
                alias.Intro_UA = alias.Intro_UA == null ? item.Intro_UA : alias.Intro_UA;
                alias.Image = alias.Image == null ? item.Image : alias.Image;
                var basePage = parentName?.Length == 0 || parentName == null ? null : db.Pages.FirstOrDefault(i => i.Caption == parentName);
                int amountOfChilder = parentName?.Length == 0 || parentName == null ? -1 : db.Pages.Where(i => i.ParentId == basePage.PageId).Count();
                alias.Parent = basePage;
                alias.CustomOrder = amountOfChilder + 1;
                db.Pages.Add(alias);
                db.SaveChanges();
            }
        }

        public List<Page> GetChildren(string input)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var id = db.Pages.FirstOrDefault(i => i.Caption == input);
                return db.Pages.Where(i => i.ParentId == id.PageId).OrderBy(i => i.CustomOrder).ToList();
            }
        }

        public Page GetHead()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Pages.First(i => i.Parent == null);
            }
        }

        public Page GetPageByCaption(string caption)
        {
            
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Pages.Include(i => i.Parent).Include(i => i.Alias).First(i => i.Caption == caption);
            }
        }

        public List<Page> GetPages()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.Pages.ToList();
            }
        }

        public void SaveChagedPage(Page p)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var j = db.Pages.FirstOrDefault(i => i.Caption == p.Caption);
                j.Intro_En = p.Intro_En;
                j.Intro_UA = p.Intro_UA;
                j.Content_En = p.Content_En;
                j.Content_UA = p.Content_UA;
                db.SaveChanges();
            }
        }

        public void DeletePage(Page p)
        {
            CascadeRemove(p);
        }

        private void CascadeRemove(Page p)
        {
            if (p.ContainerType == "container")
            {
                var listChild = GetChildren(p.Caption);
                foreach (var item in listChild)
                {
                    CascadeRemove(item);
                }
            }
            else
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.Pages.Remove(p);
                }
            }
        }
    }
}
