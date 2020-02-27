using DigitalDiary.Interfaces;
using DigitalDiary.Models;
using DigitalDiary.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Memory> repo = new MemoryRepository();
        IMemoryRepository MRepo = new MemoryRepository();

        [HttpGet]
        public ActionResult Index()
        {
            int id = (int)Session["UserId"];
            return View(MRepo.GetUserMeoriesList(id));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(repo.Get(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            Memory memoryModel = new Memory();
            using (DigitalDiaryDataContext db = new DigitalDiaryDataContext())
            {
                memoryModel.ImportanceClassifierCollection = db.Importances.ToList<Importance>();
            }
            return View(memoryModel);
        }

        [HttpPost]
        public ActionResult Create(Memory m)
        {
            m.UserId = (int)Session["UserId"];
            string FileName = Path.GetFileNameWithoutExtension(m.ImageFile.FileName);
            string extension = Path.GetExtension(m.ImageFile.FileName);
            FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
            m.ImagePath = "~/Images/" + FileName;
            FileName = Path.Combine(Server.MapPath("~/Images/"), FileName);
            m.ImageFile.SaveAs(FileName);
            ModelState.Clear();
            DateTime date = DateTime.Now;
            m.LastModificationDate = date.ToLongTimeString();

            repo.Insert(m);
            return RedirectToAction("Details", new { id = m.MemoryId });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Memory memoryModel = new Memory();
            using (DigitalDiaryDataContext db = new DigitalDiaryDataContext())
            {
                if (id != 0)
                {
                    memoryModel = db.Memories.Where(x => x.MemoryId == id).FirstOrDefault();
                }
                memoryModel.ImportanceClassifierCollection = db.Importances.ToList<Importance>();
            }
            memoryModel = repo.Get(id);
            return View(memoryModel);
            //return View(repo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Memory m)
        {
            m.UserId = (int)Session["UserId"];
            DateTime date = DateTime.Now;
            string mdate = date.ToLongDateString() + date.ToLongTimeString();
            m.LastModificationDate = mdate;
            repo.Update(m);
            return RedirectToAction("Details", new { id = m.MemoryId });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(repo.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}