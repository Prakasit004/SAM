using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAM.Models;

namespace SAM.Controllers
{
    public class ProposalStatusController : Controller
    {
        private SAMContext db = new SAMContext();

        // GET: ProposalStatus
        public ActionResult Index()
        {
            return View(db.ProposalStatus.ToList());
        }

        // GET: ProposalStatus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProposalStatus proposalStatus = db.ProposalStatus.Find(id);
            if (proposalStatus == null)
            {
                return HttpNotFound();
            }
            return View(proposalStatus);
        }

        // GET: ProposalStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProposalStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocNo,StatusID,PropStatus")] ProposalStatus proposalStatus)
        {
            if (ModelState.IsValid)
            {
                db.ProposalStatus.Add(proposalStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proposalStatus);
        }

        // GET: ProposalStatus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProposalStatus proposalStatus = db.ProposalStatus.Find(id);
            if (proposalStatus == null)
            {
                return HttpNotFound();
            }
            return View(proposalStatus);
        }

        // POST: ProposalStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocNo,StatusID,PropStatus")] ProposalStatus proposalStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proposalStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proposalStatus);
        }

        // GET: ProposalStatus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProposalStatus proposalStatus = db.ProposalStatus.Find(id);
            if (proposalStatus == null)
            {
                return HttpNotFound();
            }
            return View(proposalStatus);
        }

        // POST: ProposalStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProposalStatus proposalStatus = db.ProposalStatus.Find(id);
            db.ProposalStatus.Remove(proposalStatus);
            db.SaveChanges();
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
