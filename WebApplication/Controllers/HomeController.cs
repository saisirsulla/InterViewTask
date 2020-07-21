using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            return View(db.Item.ToList());
        }


        [HttpGet]
        public ActionResult AddingItem()
        {
            AddingItemVM model = new AddingItemVM()
            {
                ItemGroupList = db.ItemGroups.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddingItem(AddingItemVM model)
        {
            if (ModelState.IsValid)
            {
                ItemGroup itemGroup = db.ItemGroups.FirstOrDefault(x => x.Id == model.ItemGroup);
                Item item = new Item()
                {
                    Id = db.Item.Max(x => x.Id) +1,
                    ItemDescription = model.ItemDescription,
                    ItemGroup = itemGroup
                };
                db.Item.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        //[Route("Home/Edit/{id}")]
        public ActionResult EditItem(int id)
        {
            Item item = db.Item.Include("ItemGroup").FirstOrDefault(x => x.Id == id);
            
            EditingItemVM model = new EditingItemVM()
            {
                ItemDescription = item.ItemDescription,
                ItemGroup = item.ItemGroup.Id,
                ItemGroupList = db.ItemGroups.ToList(),
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult EditItem(EditingItemVM model)
        {
            Item item = db.Item.Include("ItemGroup").FirstOrDefault(x => x.Id == model.Id);

            if (ModelState.IsValid)
            {
                ItemGroup itemGroup = db.ItemGroups.FirstOrDefault(x => x.Id == model.ItemGroup);


                item.ItemDescription = model.ItemDescription;
                item.ItemGroup = itemGroup;

                //db.Item.Attach(item);
                //db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var item = db.Item.FirstOrDefault(x => x.Id == Id);
            db.Item.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int Id)
        {
            return View(db.Item.Include("ItemGroup").FirstOrDefault(x => x.Id == Id));
        }
    }
}