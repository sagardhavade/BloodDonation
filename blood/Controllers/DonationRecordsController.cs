using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using blood.Models;

namespace blood.Controllers
{
    public class DonationRecordsController : Controller
    {
        private BloodDonationEntities2 db = new BloodDonationEntities2();

        // GET: DonationRecords
        public async Task<ActionResult> Index()
        {
            return View(await db.DonationRecords.ToListAsync());
        }

        // GET: DonationRecords/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRecord donationRecord = await db.DonationRecords.FindAsync(id);
            if (donationRecord == null)
            {
                return HttpNotFound();
            }
            return View(donationRecord);
        }

        // GET: DonationRecords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonationRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,DonorName,BloodType,Gender,StaffName,Quantity")] DonationRecord donationRecord)
        {
            if (ModelState.IsValid)
            {
                db.DonationRecords.Add(donationRecord);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(donationRecord);
        }

        // GET: DonationRecords/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRecord donationRecord = await db.DonationRecords.FindAsync(id);
            if (donationRecord == null)
            {
                return HttpNotFound();
            }
            return View(donationRecord);
        }

        // POST: DonationRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,DonorName,BloodType,Gender,StaffName,Quantity")] DonationRecord donationRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donationRecord).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(donationRecord);
        }

        // GET: DonationRecords/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRecord donationRecord = await db.DonationRecords.FindAsync(id);
            if (donationRecord == null)
            {
                return HttpNotFound();
            }
            return View(donationRecord);
        }

        // POST: DonationRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DonationRecord donationRecord = await db.DonationRecords.FindAsync(id);
            db.DonationRecords.Remove(donationRecord);
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
