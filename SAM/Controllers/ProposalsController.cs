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
    public class ProposalsController : Controller
    {
        private SAMContextPropersal db = new SAMContextPropersal();

        // GET: Proposals
        public async Task<ActionResult> Index()
        {
            return View(await db.Proposals.ToListAsync());
        }

        // GET: Proposals/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposal proposal = await db.Proposals.FindAsync(id);
            if (proposal == null)
            {
                return HttpNotFound();
            }
            return View(proposal);
        }

        // GET: Proposals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proposals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DocNo,OrganName,Date,Subject,ActName,StartDate,EndDate,Place,StdBudget,OthName,OthBudget,Total,Act1,Act2,Act3,Act4,Act5,Act6,UrlFile")] Proposal proposal)
        {
            if (ModelState.IsValid)
            {
                db.Proposals.Add(proposal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(proposal);
        }

        // GET: Proposals/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposal proposal = await db.Proposals.FindAsync(id);
            if (proposal == null)
            {
                return HttpNotFound();
            }
            return View(proposal);
        }

        // POST: Proposals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DocNo,OrganName,Date,Subject,ActName,StartDate,EndDate,Place,StdBudget,OthName,OthBudget,Total,Act1,Act2,Act3,Act4,Act5,Act6,UrlFile")] Proposal proposal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proposal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(proposal);
        }

        // GET: Proposals/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposal proposal = await db.Proposals.FindAsync(id);
            if (proposal == null)
            {
                return HttpNotFound();
            }
            return View(proposal);
        }

        // POST: Proposals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Proposal proposal = await db.Proposals.FindAsync(id);
            db.Proposals.Remove(proposal);
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
