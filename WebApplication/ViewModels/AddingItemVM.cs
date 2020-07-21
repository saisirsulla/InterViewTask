using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class AddingItemVM
    {
        public string ItemDescription { get; set; }
        public int ItemGroup { get; set; }
        public List<ItemGroup> ItemGroupList { get; set; }
    }
}