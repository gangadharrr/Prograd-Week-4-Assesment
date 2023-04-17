using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prograd_Week_4_Assesment.Models;
using System.IO;


namespace Prograd_Week_4_Assesment.Controllers
{
    public class TextEditorController : Controller
    {
        public static string filename="untitled.txt";
        // GET: TextController
        public ActionResult Index()
        {

            FileStream file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(file);
            TextEditor textobj=new TextEditor();
            textobj.filename=filename;
            textobj.textregion=reader.ReadToEnd();
            reader.Close();
            file.Close();
            return View(textobj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TextEditor text)
        {
            System.IO.File.Delete( filename);
            filename = text.filename;
            FileStream file = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(text.textregion);
            writer.Close();
            file.Close();
            return RedirectToAction("Index");
        }
        // GET: TextController/Details/5
        public ActionResult NewFile(int id)
        {
            filename = "untitled.txt";
            System.IO.File.Delete(filename);
            return RedirectToAction("Index");
        }

        // GET: TextController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TextController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TextController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TextController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TextController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TextController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
