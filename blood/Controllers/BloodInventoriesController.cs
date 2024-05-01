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
    public class BloodInventoriesController : Controller
    {
        private BloodDonationEntities4 db = new BloodDonationEntities4();

        // GET: BloodInventories
        public async Task<ActionResult> Index()
        {
            return View(await db.BloodInventories.ToListAsync());
        }

        // GET: BloodInventories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodInventory bloodInventory = await db.BloodInventories.FindAsync(id);
            if (bloodInventory == null)
            {
                return HttpNotFound();
            }
            return View(bloodInventory);
        }

        // GET: BloodInventories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BloodInventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,DonorName,DonarAddress,DonorPhone,BloodType,ExpiryDate,Quantity,CollectLocation,StaffName")] BloodInventory bloodInventory)
        {
            if (ModelState.IsValid)
            {
                db.BloodInventories.Add(bloodInventory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bloodInventory);
        }

        // GET: BloodInventories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodInventory bloodInventory = await db.BloodInventories.FindAsync(id);
            if (bloodInventory == null)
            {
                return HttpNotFound();
            }
            return View(bloodInventory);
        }

        // POST: BloodInventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,DonorName,DonarAddress,DonorPhone,BloodType,ExpiryDate,Quantity,CollectLocation,StaffName")] BloodInventory bloodInventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodInventory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bloodInventory);
        }

        // GET: BloodInventories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodInventory bloodInventory = await db.BloodInventories.FindAsync(id);
            if (bloodInventory == null)
            {
                return HttpNotFound();
            }
            return View(bloodInventory);
        }

        // POST: BloodInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BloodInventory bloodInventory = await db.BloodInventories.FindAsync(id);
            db.BloodInventories.Remove(bloodInventory);
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
