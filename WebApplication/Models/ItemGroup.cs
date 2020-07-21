using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ItemGroup
    {
        public int Id { get; set; }
        public string GroupDescription { get; set; }
        public List<Item> Item { get; set; }
    }
}