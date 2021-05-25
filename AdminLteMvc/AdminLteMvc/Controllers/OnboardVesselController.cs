using AdminLteMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminLteMvc.Models.WEBSales;
using Microsoft.AspNet.Identity;

namespace AdminLteMvc.Controllers
{
    public class OnboardVesselController : Controller
    {
        // GET: OnboardVessel
        private ContextModel db = new ContextModel();
        public ActionResult onboard()
        {
            string query = "select a.vesselMnemonic+'-'+b.voyageNo vesselvoyage,b.voyageID,b.status from Vessels a " +
                             "inner join VoyageNoes b on a.vesselID = b.vesselid ";
            var list = db.Database.SqlQuery<Models.Class.dataPopulation>(query);
            List<SelectListItem> vesList = new List<SelectListItem>();
            foreach (Models.Class.dataPopulation jj in list)
            {
                vesList.Add(new SelectListItem
                {
                    Text = jj.vesselvoyage,
                    Value = jj.voyageID.ToString()
                });
            }
            ViewBag.vesList = vesList;


            string qq = "select (select count(*) from onboardVesselLoadItems where onboardID=a.onboardID) itemCount, " +
                        "a.onboardID,left(convert(varchar,a.dateCreated,101),10) dateCreated, " +
                        "b.vesselMnemonic, a.vessleName,a.voyageNo,a.status from onboardVessels a " +
                        "inner join Vessels b on a.vesselId = b.vesselID order by a.onboardId desc";
            var onloadVesselList = db.Database.SqlQuery<AdminLteMvc.Models.Class.DisplayonboardVessels>(qq);
            ViewBag.onloadVesselList = onloadVesselList;
            return View();
        }
        public ActionResult getbillofladingpervoyageno(int voyageId)
        {
            
            var getBOL = db.FinalBilling.Where(a => a.BillStatus == "Billed" && a.voyageID == voyageId).ToList();

            string query = "select a.vesselname,b.voyageNo as voyageNo,b.voyageID,b.status from Vessels a " +
                          "inner join VoyageNoes b on a.vesselID = b.vesselid where b.voyageID="+ voyageId + " ";
            var voyageDetails = db.Database.SqlQuery<Models.Class.dataPopulation>(query).ToList();

 
            return new JsonResult { Data = new { getBOL = getBOL, voyageDetails= voyageDetails } };
        }
        public class vesselVoyage {
            public int vesselID { get; set; }
            public string vesselName { get; set; }
            public string vesselMnemonic { get; set; }
            public int voyageID { get; set; }
            public string voyageNo { get; set; }
        }
        

        public JsonResult SaveOnboardVessel(Models.Class.onboardVessel ov)
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            string err_msg = "";
            Boolean status = false;
            try
            {
                int userid = int.Parse(User.Identity.GetUserName());
                int empid = int.Parse(db.Users.Where(u => u.ID == userid).First().EmpID);
                var emp = db.EmployeeMasters.Where(a => a.ID == empid).First();

                var vesselVoyage = db.Database.SqlQuery<vesselVoyage>("select * from Vessels a left join VoyageNoes b on a.vesselID = b.vesselid where b.voyageID=" + ov.datParent.voyageID + "").First();
                onboardVessel saveOV = new onboardVessel();
                saveOV.vessleName = vesselVoyage.vesselName;
                saveOV.vesselID = vesselVoyage.vesselID;
                saveOV.voyageID = vesselVoyage.voyageID;
                saveOV.voyageNo = vesselVoyage.voyageNo;
                saveOV.dateCreated = DateTime.Now;
                saveOV.userID = userid;
                saveOV.userName = emp.FirstName + ' ' + emp.MiddleName + ' ' + emp.LastName;
                saveOV.status = "For Departure";
                var ret = db.onboardVessel.Add(saveOV);
                db.SaveChanges();

                foreach (var item in ov.data)
                {
                    onboardVesselLoadItem OVLI = new onboardVesselLoadItem();
                    OVLI.billID = item.billID;
                    OVLI.billofLadingNo = item.billofLadingNo;
                    OVLI.onboardID = ret.onboardID;
                    OVLI.userID = userid;
                    OVLI.dateCreated = DateTime.Now;
                    OVLI.status = "Active";
                    db.onboardVesselLoadItem.Add(OVLI);
                    db.SaveChanges();
                }
                status = true;
                transaction.Commit();
            }
            catch 
            {
                transaction.Rollback();
            }
            return new JsonResult { Data = new { status = status, errmsg = err_msg } };
        }
    }
}