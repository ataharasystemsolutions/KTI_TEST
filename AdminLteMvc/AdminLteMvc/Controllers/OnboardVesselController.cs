using AdminLteMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminLteMvc.Models.WEBSales;
using Microsoft.AspNet.Identity;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

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
            var getBOL = db.Database.SqlQuery<FinalBilling>("select a.* from FinalBillings a left join onboardVesselLoadItems b on a.billID = b.billID where b.status is null or b.status = 'Canceled'");    
            //db.FinalBilling.Where(a => a.BillStatus == "Billed" && a.voyageID == voyageId).ToList();
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
            var onboardVessel = db.onboardVessel.Where(a=>a.voyageID== ov.datParent.voyageID && (a.status=="For Departure" || a.status=="Departed")).ToList();
            if (onboardVessel.Count() == 0)
            {
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
                    var voyNo = db.VoyageNo.Where(a => a.voyageID == vesselVoyage.voyageID).ToList();
                    if (voyNo.Count > 0)
                    {
                        var updateSelectedVoyageNo = db.VoyageNo.Where(a => a.voyageID == vesselVoyage.voyageID).First();
                        updateSelectedVoyageNo.status = "Closed";
                        db.SaveChanges();
                    }
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
                    foreach (var item in ov.voyageRoute)
                    {
                        onboardVesselVoyageRoute ovvr = new onboardVesselVoyageRoute();
                        ovvr.onboardID = ret.onboardID;
                        ovvr.userID = userid;
                        ovvr.dateCreated = DateTime.Now;
                        ovvr.status = "For Departure";
                        ovvr.action = "Active";

                        ovvr.voyageID = item.voyageID;
                        ovvr.vesselName = item.vesselName;
                        ovvr.voyageNo = item.voyageNo;
                        ovvr.voyageLegName = item.voyageLegName;
                        ovvr.portofOrigin = item.portofOrigin;
                        ovvr.portofDestination = item.portofDestination;
                        ovvr.ATD = item.ATD;
                        ovvr.ATA = item.ATA;

                        db.onboardVesselVoyageRoute.Add(ovvr);
                        db.SaveChanges();
                    }

                    status = true;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
            else
            {
                status = false;
                err_msg = "has pending";
            }
            return new JsonResult { Data = new { status = status, errmsg = err_msg } };
        }
        public JsonResult getvoyageRoute(int onboardID)
        {
            string query = "select a.routeID,a.onboardID, c.vesselMnemonic,a.vesselName,a.voyageNo,a.voyageLegName,  " +
                        "a.portofOrigin,a.portofDestination,a.ATD,a.ATA,a.status " +
                        "from onboardVesselVoyageRoutes a " +
                        "inner join VoyageNoes b on a.voyageID = b.voyageID " +
                        "inner join Vessels c on b.vesselid = c.vesselID " +
                        "where a.onboardID = "+onboardID+"";

            var voyageRoute = db.Database.SqlQuery<displayVoyageRoute>(query);
            return Json(voyageRoute, JsonRequestBehavior.AllowGet);
           
        }

       

        public JsonResult getLoadList(int onboardID)
        {
            string query = "select * from Yard_VesselLoadlist_Format where onboardID=" + onboardID + "";
            var voyageRoute = db.Database.SqlQuery<displayLoadList>(query);
            return Json(voyageRoute, JsonRequestBehavior.AllowGet);

        }

        
        public JsonResult updatestatusDeparted(int ID)
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            var msg = "saved";
            try
            {
                //update master data
                var onboard = db.onboardVessel.Where(a => a.onboardID == ID).SingleOrDefault();
                onboard.status = "Departed";
                db.SaveChanges();

                //update branch data
                var onboardRoute = db.onboardVesselVoyageRoute.Where(a => a.onboardID == ID).ToList();
                foreach (onboardVesselVoyageRoute route in onboardRoute)
                {
                    route.status = "Departed";
                    db.SaveChanges();
                }
                transaction.Commit();
            }
            catch {
                msg = "failed";
                transaction.Rollback();
            }
           
          
            

            return new JsonResult { Data = new { msg=msg } };
        }
        public JsonResult updatestatusArrived(int ID)
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            var onboardRoute = db.onboardVesselVoyageRoute.Where(a => a.routeID == ID).SingleOrDefault();
            var msg = "saved";
            try
            {
                onboardRoute.status = "Arrived";
                db.SaveChanges();


                //checked lines per onboardID
                var chkRoute = db.onboardVesselVoyageRoute.Where(a => a.onboardID == onboardRoute.onboardID).ToList();
                var chkroutewithstatus = chkRoute.Where(a => a.onboardID == onboardRoute.onboardID && a.status == "Arrived" && a.action == "Active").ToList();
                if (chkRoute.Count == chkroutewithstatus.Count())
                {
                    //update status to "Arrived" in master data
                    var onboard = db.onboardVessel.Where(a => a.onboardID == onboardRoute.onboardID).SingleOrDefault();
                    onboard.status = "Arrived";
                    db.SaveChanges();

                    //update voyageno status to "Open"
                    var voyageNumber = db.VoyageNo.Where(a => a.voyageID == onboard.voyageID).SingleOrDefault();
                    voyageNumber.status = "Open";
                    db.SaveChanges();

                }
                transaction.Commit();
            }
            catch {
                msg = "failed";
                transaction.Rollback();
            }
            return new JsonResult { Data = new { msg = msg,onboardID= onboardRoute.onboardID } };
        }
        
        public class displayVoyageRoute
        {
            public int routeID { get; set; }
            public int onboardID { get; set; }
            public string vesselMnemonic { get; set; }
            public string vesselName { get; set; }
            public string voyageNo { get; set; }
            public string voyageLegName { get; set; }
            public string portofOrigin { get; set; }
            public string portofDestination { get; set; }
            public string ATD { get; set; }
            public string ATA { get; set; }
            public string status { get; set; }
        }
        public class displayLoadList
        {

            public int onboardID { get; set; }
            public string vessleName { get; set; }
            public string voyageNo { get; set; }
            public string billofladingNo { get; set; }
            public string EIRIConvanNo { get; set; }
            public string EIRISealNo { get; set; }
            public string shipperName { get; set; }
            public string origin { get; set; }
            public string portoforigin { get; set; }
            public string portofDestination { get; set; }
            public string finalDestination { get; set; }
            public string consigneeName { get; set; }
            public string serviceMode { get; set; }
            public string CargoDetails { get; set; }
            public string EIRIConvanStatus { get; set; }
            public int itemID { get; set; }
            
        }

        public ActionResult DisplayLoadListReport(string onboardID,string type)
        {
            ViewBag.onboardID = onboardID;
            ViewBag.type = type;
            return View("DisplayLoadListReport");
        }
        public FileResult LoadlistReport(string onboardID,string type)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath(@"~/Report_Documents/"+ type + ".rpt")));
            string query = "";

            if(type== "Yard_VesselLoadList")
                query = String.Format("select * from Yard_VesselLoadlist_Format where onboardID="+ onboardID + "");
            
            if(type== "forCoastGuard")
                query = String.Format("select * from For_CoastGuard where onboardID=" + onboardID + "");

            if (type == "Cherry_Roselyn")
                query = String.Format("select * from cherry_roselyn_coron where onboardID=" + onboardID + "");

            if (type == "Roma_Nessa_FT")
                query = String.Format("select * from Roma_Nessa_FT where onboardID=" + onboardID + "");

            if (type == "Trigo")
                query = String.Format("select * from Trigo where onboardID=" + onboardID + "");

            if (type == "Accounting")
                query = String.Format("select * from Accounting where onboardID=" + onboardID + "");

            if (type == "coastingManifest")
                query = String.Format("select * from Coasting_Manifest where routeID=" + onboardID + "");


            var list = db.Database.SqlQuery<Reports_VM.YardVessellLoadList>(query).ToList();
            if (list.Count > 0)
            {
                rd.SetDataSource(list);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
            }
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf");
        }
    }
}