using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi.Controllers
{
    public class VideoPointInformationsController : Controller
    {
        private DefaultContext db = new DefaultContext();

        // GET: VideoPointInformations
        public async Task<ActionResult> Index()
        {
            return View(await db.VideoPointInformation.ToListAsync());
        }

        // GET: VideoPointInformations/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoPointInformation videoPointBitInformation = await db.VideoPointInformation.FindAsync(id);
            if (videoPointBitInformation == null)
            {
                return HttpNotFound();
            }
            return View(videoPointBitInformation);
        }

        // GET: VideoPointInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoPointInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,VPBISerialNumber,VPISerialNumber,VPBIMonitoringPointNumber,VPBIAffiliatedOrganization,VPBIBelongToTheRegion,VPBIPlatform,VPBILongitude,VPBILatitude,VersionNo,TransactionID,CreateBy,CreateOn,UpdateBy,UpdateOn,DataLevel,Latitude,Longitude,IsDeleted,Polyline,Polygon")] VideoPointInformation videoPointBitInformation)
        {
            if (ModelState.IsValid)
            {
                db.VideoPointInformation.Add(videoPointBitInformation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(videoPointBitInformation);
        }

        // GET: VideoPointInformations/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoPointInformation videoPointBitInformation = await db.VideoPointInformation.FindAsync(id);
            if (videoPointBitInformation == null)
            {
                return HttpNotFound();
            }
            return View(videoPointBitInformation);
        }

        // POST: VideoPointInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,VPBISerialNumber,VPISerialNumber,VPBIMonitoringPointNumber,VPBIAffiliatedOrganization,VPBIBelongToTheRegion,VPBIPlatform,VPBILongitude,VPBILatitude,VersionNo,TransactionID,CreateBy,CreateOn,UpdateBy,UpdateOn,DataLevel,Latitude,Longitude,IsDeleted,Polyline,Polygon")] VideoPointInformation videoPointBitInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoPointBitInformation).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(videoPointBitInformation);
        }

        // GET: VideoPointInformations/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoPointInformation videoPointBitInformation = await db.VideoPointInformation.FindAsync(id);
            if (videoPointBitInformation == null)
            {
                return HttpNotFound();
            }
            return View(videoPointBitInformation);
        }

        // POST: VideoPointInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            VideoPointInformation videoPointBitInformation = await db.VideoPointInformation.FindAsync(id);
            db.VideoPointInformation.Remove(videoPointBitInformation);
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
