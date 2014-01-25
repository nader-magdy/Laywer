using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lawyer.Model;
using Lawyer.Data;

namespace Lawyer.Controllers
{
    public class CourtController : Controller
    {
        private LawyerRepository db = new LawyerRepository();

        // GET: /Court/
        public async Task<ActionResult> Index()
        {
            return View(await db.Courts.ToListAsync());
        }

        // GET: /Court/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Court court = await db.Courts.FindAsync(id);
            if (court == null)
            {
                return HttpNotFound();
            }
            return View(court);
        }

        // GET: /Court/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Court/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="CourtId,CourtName,Address,LastModified,Created")] Court court)
        {
            if (ModelState.IsValid)
            {
                db.Courts.Add(court);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(court);
        }

        // GET: /Court/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Court court = await db.Courts.FindAsync(id);
            if (court == null)
            {
                return HttpNotFound();
            }
            return View(court);
        }

        // POST: /Court/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="CourtId,CourtName,Address,LastModified,Created")] Court court)
        {
            if (ModelState.IsValid)
            {
                db.Entry(court).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(court);
        }

        // GET: /Court/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Court court = await db.Courts.FindAsync(id);
            if (court == null)
            {
                return HttpNotFound();
            }
            return View(court);
        }

        // POST: /Court/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Court court = await db.Courts.FindAsync(id);
            db.Courts.Remove(court);
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
