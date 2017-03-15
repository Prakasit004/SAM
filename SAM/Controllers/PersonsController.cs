using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAM.Models;

namespace SAM.Controllers
{
    public class PersonsController : Controller
    {
        private SAMContext db = new SAMContext();

        // GET: Persons
        public async Task<ActionResult> Index()
        {
            return View(await db.Persons.ToListAsync());
        }

        // GET: Persons/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persons persons = await db.Persons.FindAsync(id);
            if (persons == null)
            {
                return HttpNotFound();
            }
            return View(persons);
        }

        // GET: Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Username,Name,Organization,Email,Tel")] Persons persons)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(persons);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(persons);
        }

        // GET: Persons/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persons persons = await db.Persons.FindAsync(id);
            if (persons == null)
            {
                return HttpNotFound();
            }
            return View(persons);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Username,Name,Organization,Email,Tel")] Persons persons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persons).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(persons);
        }

        // GET: Persons/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persons persons = await db.Persons.FindAsync(id);
            if (persons == null)
            {
                return HttpNotFound();
            }
            return View(persons);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Persons persons = await db.Persons.FindAsync(id);
            db.Persons.Remove(persons);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
