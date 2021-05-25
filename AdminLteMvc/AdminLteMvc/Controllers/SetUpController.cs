using AdminLteMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminLteMvc.Models.WEBSales;


namespace AdminLteMvc.Controllers
{
    public class SetUpController : Controller
    {
        // GET: SetUp
        private ContextModel db = new ContextModel();
        public ActionResult Index()
        {
            return View();
        }

        public class vn
        {
            public int vesselID { get; set; }
            public string vesselName { get; set; }
            public string vesselMnemonic { get; set; }
            public string voyageNo { get; set; }
            public string category { get; set; }
            public string portOrigin { get; set; }
            public string portDestination { get; set; }

            public string status { get; set; }
            public string transactionNumber { get; set; }

        }
        public ActionResult vesselVoyage ()
        {
            //Vessel
            var vesselList = db.Vessel.ToList();
            List<SelectListItem> vList = new List<SelectListItem>();
            foreach (Vessel item in vesselList)
            {
                vList.Add(new SelectListItem
                {
                    Text = item.vesselName,
                    Value = item.vesselID.ToString()
                });
            }
            ViewBag.vList = vList;
            ViewBag.vesselList = vesselList;

            var location = db.CYLocation.ToList();
            List<SelectListItem> locList = new List<SelectListItem>();
            foreach (CYLocation item in location)
            {
                locList.Add(new SelectListItem
                {
                    Text = item.cyLocation,
                    Value = item.cyLocation
                });
            }
            ViewBag.locList = locList;

            //Voyage Number
            string queryVN = "select a.vesselID,a.vesselName,a.vesselMnemonic,b.voyageNo,b.status,b.transactionNumber from Vessels a " +
                            "inner join VoyageNoes b on a.vesselID = b.vesselid " +
                            "order by vesselID";
            var vn = db.Database.SqlQuery<vn>(queryVN).ToList();
            ViewBag.vn = vn;

            //Voyage Number
            string queryVNL = "select a.vesselID,a.vesselName,a.vesselMnemonic,b.voyageNo,c.category,c.portOrigin,c.portDestination from Vessels a " +
                            "inner join VoyageNoes b on a.vesselID = b.vesselid " +
                            "inner join VoyageNoCategories c on b.voyageID = c.voyageID " +
                            "order by vesselID";
            var vnl = db.Database.SqlQuery<vn>(queryVNL).ToList();
            ViewBag.vnl = vnl;
            return View();
        }
        public ActionResult saveVessel(FormCollection col)
        {
            if (chkInput(col["vesselName"], col["vesselMnemonic"]))
            {
                string vn = col["vesselName"].ToString();
                string vm = col["vesselMnemonic"].ToString();
                var chk = db.Vessel.Where(a => a.vesselName== vn || a.vesselMnemonic== vm).ToList();

                if (chk.Count == 0)
                {
                    var vess = new Vessel();
                    vess.vesselName = col["vesselName"];
                    vess.vesselMnemonic = col["vesselMnemonic"];
                    db.Vessel.Add(vess);
                    db.SaveChanges();
                    TempData["Message"] = "Saved";
                }
                else
                    TempData["Message"] = "Exist";
            }
            return RedirectToAction("vesselVoyage", "SetUp");
        }

        public bool chkInput(string vesselName,string vesselMnemonic)
        {
            bool ret = true;
            if (vesselName.Length == 0)
            {
                TempData["Message"] = "Failed";
                ret = false;
            }
            if (vesselMnemonic.Length == 0)
            {
                TempData["Message"] = "Failed";
                ret = false;
            }
            return ret;
        }

        public ActionResult saveVoyageNO(string Id,string vn)
        {
            bool status = true;
            var chk = db.VoyageNo.Where(a => a.voyageNo == vn).ToList();
            if (chk.Count == 0)
            {
                var vnSave = new VoyageNo();
                vnSave.vesselid = Id;
                vnSave.voyageNo = vn;
                vnSave.status = "Open";
                vnSave.transactionNumber = "-";
                db.VoyageNo.Add(vnSave);
                db.SaveChanges();
                TempData["Tab"] = "vn";
                TempData["Message"] = "Saved";
            }
            else 
            {
                TempData["Message"] = "Exist";
                TempData["Tab"] = "vn";
                status = false;
            }
            return new JsonResult { Data = new { status = status} };
        }


        public ActionResult getVoyage(string Id)
        {
            var voyageN = db.VoyageNo.Where(a => a.vesselid == Id).ToList();
            return new JsonResult { Data = new { voyageN = voyageN } };
        }
        public ActionResult saveVoyageLeg(int voyageId, string voyageLeg, string origin, string destination)
        {
            bool status = true;
            var chk = db.VoyageNoCategory.Where(a => a.voyageID == voyageId && a.category==voyageLeg && a.portOrigin==origin && a.portDestination==destination).ToList();
            if (chk.Count == 0)
            {
                var vncSave = new VoyageNoCategory();
                vncSave.voyageID = voyageId;
                vncSave.category = voyageLeg;
                vncSave.portOrigin = origin;
                vncSave.portDestination = destination;
                db.VoyageNoCategory.Add(vncSave);
                db.SaveChanges();
                TempData["Tab"] = "vl";
                TempData["Message"] = "Saved";
            }
            else
            {
                TempData["Message"] = "Exist";
                TempData["Tab"] = "vl";
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }


    }
}