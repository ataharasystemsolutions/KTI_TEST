using AdminLteMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminLteMvc.Models.WEBSales;
using System.Data.Entity;
using System.Net;
using Omu.AwesomeMvc;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace AdminLteMvc.Controllers
{
    public abstract partial class BaseController : Controller
    {
        private string notification;
        /// <summary>    
        /// Add notification to users    
        /// </summary>    
        /// <param name="message"></param>    
        protected void AddNotification(string message)
        {
            notification = message;
        }
        /// <summary>    
        /// </summary>    
        /// <param name="filterContext"></param>    
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (!string.IsNullOrWhiteSpace(this.notification)) filterContext.Controller.ViewData.Add("PageLoadNotification", this.notification);
        }
       
    }
   
    public class croController : Controller
    {
        private ContextModel db = new ContextModel();
        // GET: cro
        public ActionResult Index()
        {
            return View();
        }
        protected void loadable()
        {
            var hR = db.HandlingRequirements.ToList();
            List<SelectListItem> hRlist = new List<SelectListItem>();
            hRlist.Add(new SelectListItem { Text="Select", Value="0"});
            foreach (var i in hR)
            {
                hRlist.Add(new SelectListItem { Text = i.description, Value=i.handlingReqID.ToString()}) ;
            }
            ViewBag.hRlist = hRlist;
            var CYL = db.CYLocation.ToList();
            List<SelectListItem> CYlist = new List<SelectListItem>();
            CYlist.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (var i in CYL)
            {
                CYlist.Add(new SelectListItem { Text = i.cyLocation, Value = i.cyID.ToString() });
            }
            ViewBag.CYlist = CYlist;

            var autTrucker = db.Truckers.ToList();
            List<SelectListItem> autTruckerList = new List<SelectListItem>();
            autTruckerList.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (var i in autTrucker)
            {
                autTruckerList.Add(new SelectListItem { Text = i.truckername, Value = i.truckername });
            }
            ViewBag.autTruckerList = autTruckerList;
        }
        public ActionResult forapprovalList()
        {
            loadable();
            var list = db.Database.SqlQuery<Models.Class.forapprovalList>("select a.consigneeId, b.shipper,b.serviceType,b.convanNo,a.consigneeName,left(convert(varchar,a.startDate,101),10)startDate,left(convert(varchar,a.endDate,101),10)endDate, A.Status from  RequestDeliveryScheduleConsignees a  inner join RequestDeliverySchedules b on a.deliveryID=b.deliveryID where a.Status='For Approval'").ToList();
            ViewBag.list = list;
            return View();
        }


        public ActionResult consigneeDetails(int id)
        {
            string query = String.Format("exec getDetailsCROapproval '{0}'", id);
            var ds = db.Database.SqlQuery<Models.Class.getconsigneeDet>(query).ToList();
            int cntt = ds.Count();
            return new JsonResult { Data = new { ds = ds, cntt= cntt } };
        }


        public ActionResult addCRO(FormCollection collect)
        {
            string iD = collect["issueDate"];
            string eD = collect["expiryDate"];
            string driver = collect["authorizeDriverDestination"];
            string plate = collect["AuthorizedTruckPlateNoDestination"];
            string truckerDestination = collect["authorizedTruckerDestination"];
            string ladenConvan = collect["selectedConVan"];
            string stripping = collect["selectedStripping"];
            string HR = collect["selectedHR"];
            if (IsValid(iD, eD, driver, plate, truckerDestination, ladenConvan, stripping, HR))
            {
                DbContextTransaction transaction = db.Database.BeginTransaction();
                try
                {
                    string test = collect["selectedHR"];
                    string year = DateTime.Now.Year.ToString();
                    string yy = year.Substring(Math.Max(0, year.Length - 2));
                    var cnt = db.Database.SqlQuery<CRO>("select * from CROes where YEAR(issueDate)=" + year + "");

                    int seriesNumber = 100000 + int.Parse(cnt.Count().ToString());
                    seriesNumber = seriesNumber + 1;

                    string finalSeries = seriesNumber.ToString().Substring(Math.Max(0, seriesNumber.ToString().Length - 5)).ToString();

                    var save_cro = new CRO();

                    save_cro.deliveryId = int.Parse(collect["hdndelId"]);
                    save_cro.croSerial = "CRO-CV-" + year + "-" + finalSeries;
                    save_cro.shipper = collect["shipper"];
                    save_cro.shipperContactPerson = collect["shippercontact"];
                    save_cro.consignee = collect["consignee"];
                    save_cro.transactionNo = collect["transactionnumber"];
                    save_cro.EIRONO = collect["EIRONO"];
                    save_cro.issueDate = DateTime.Parse(collect["issueDate"]);
                    save_cro.expyreDate = DateTime.Parse(collect["expiryDate"]);
                    save_cro.AuthorizedTruckerDestination = truckerDestination;
                    save_cro.AuthorizedDriverDestination = driver;
                    save_cro.AuthorizedTruckPlateNoDestination = plate;
                    save_cro.CYPullofOutofCargoLadenConVan = collect["selectedConVan"];
                    save_cro.CYStuffingStripping = collect["selectedStripping"];
                    save_cro.PackedAs = collect["packedAS"];
                    save_cro.ConVanFlatRackNo = collect["convanFlatrackNo"];
                    save_cro.Quantity = collect["qty"];
                    save_cro.Unit = collect["units"];
                    save_cro.CargoDesciption = collect["cargodescription"];
                    save_cro.OtherCargoDetails = collect["cargodetails"];
                    save_cro.ServiceMode = collect["serviceMode"];
                    save_cro.Origin = collect["origin"];
                    save_cro.Destination = collect["destination"];
                    save_cro.VesselVoyage = collect["vesselVoyage"];
                    save_cro.paymentTerms = collect["paymentTerms"];
                    save_cro.SpecialHandlingRequirement = collect["selectedHR"];
                    save_cro.Remarks = collect["remarks"];
                    save_cro.IssuedBy = collect["issuedBy"];
                    save_cro.ApprovedBy = collect["approveBy"];
                    save_cro.status = "Approved";
                    var ret = db.CRO.Add(save_cro);
                    db.SaveChanges();

                    var updateStat_Consignee = db.RequestDeliveryScheduleConsignee.Where(a => a.consigneeId == ret.deliveryId).SingleOrDefault();
                    updateStat_Consignee.Status = "Approved";
                    db.SaveChanges();


                    var getActiveConsignee = db.RequestDeliveryScheduleConsignee.Where(a => a.deliveryID == updateStat_Consignee.deliveryID && a.Status == "For Approval").ToList();
                    if (getActiveConsignee.Count == 0)
                    {
                        var updateStat_RDS = db.RequestDeliverySchedule.Where(a => a.deliveryID == updateStat_Consignee.deliveryID).SingleOrDefault();
                        updateStat_RDS.status = "Approved";
                        db.SaveChanges();
                    }

                    TempData["message"] = "Saved";
                    transaction.Commit();
                 
                }
                catch (Exception exp)
                {
                    transaction.Rollback();
                    TempData["message"] = "UnSaved";
                }
              
            }
            else
            {
                TempData["message"] = "UnSaved";
            }
            return RedirectToAction("forapprovalList");
        }

        protected bool IsValid(string iD, string eD, string driver, string plate, string truckerDestination, string ladenConvan, string stripping, string HR)
        {
            bool ret = true;
            if (iD.Length == 0)
            {
                ret = false;
                ViewBag.Message = "Invalid";
            }
            else if(eD.Length == 0)
            {
                ret = false;
                ViewBag.Message = "Invalid";
            }
            else if (driver.Length == 0)
            {
                ret = false;
                ViewBag.Message = "Invalid";
            }
            else if (plate.Length == 0)
            {
                ret = false;
                ViewBag.Message = "Invalid";
            }
            else if (truckerDestination.Length == 0)
            {
                ret = false;
                ViewBag.Message = "Invalid";
            }
            else if (ladenConvan.Length == 0)
            {
                ret = false;
                ViewBag.Message = "Invalid";
            }
            else if (stripping.Length == 0)
            {
                ret = false;
                ViewBag.Message = "Invalid";
            }
            else if (HR.Length == 0)
            {
                ret = false;
                ViewBag.Message = "Invalid";
            }
            return ret;
        }


        public ActionResult croList(CRO cr)
        {
            return View(cr);
        }
        public ActionResult GetcroListItems(GridParams g, string search)
        {
            var list = db.Database.SqlQuery<CRO>("select * from croes");
            return Json(new GridModelBuilder<CRO>(list.AsQueryable(), g)
            {
                KeyProp = o => o.croID,  // needed for Entity Framework | nesting | tree | api
                Map = o => new
                {
                    o.croID,
                    o.croSerial,
                    o.transactionNo,
                    o.shipper,
                    o.shipperContactPerson,
                    o.consignee,
                    o.Origin,
                    o.Destination,
                    o.ServiceMode,
                    o.VesselVoyage,
                    o.CargoDesciption
                }
            }.Build());
        }

        public ActionResult DisplayCRO(string croID)
        {
            ViewBag.croID = croID;
            return View("DisplaycRO");
        }
        public FileResult CROReport(string croID)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath(@"~/Report_Documents/CRO.rpt")));
            string query = String.Format("exec pulledCROData '{0}'", croID);
            var list = db.Database.SqlQuery<Models.Class.pulledCRODATA>(query).ToList();

            if (list.Count > 0)
            {
                rd.SetDataSource(list);
                rd.SetParameterValue(0, croID);
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