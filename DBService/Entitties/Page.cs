using System;
using System.Collections.Generic;
using System.Text;

namespace DBService.Entitties
{
    public class Page
    {
        public int PageId { get; set; }
        public string Caption { get; set; }
        public string Intro_UA { get; set; }
        public string Content_UA { get; set; }
        public string Intro_En { get; set; }
        public string Content_En { get; set; }
        public string Image { get; set; }
        public int CustomOrder { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public string ContainerType { get; set; } // container, list, single

        public int? ParentId { get; set; }
        public Page Parent { get; set; }


        public int? CustomAliasId { get; set; }
        public Page Alias { get; set; }
    }
}
