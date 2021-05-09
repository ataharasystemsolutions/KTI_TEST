using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminLteMvc.Models;
using AdminLteMvc.Models.WEBSales;
using Omu.AwesomeMvc;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace AdminLteMvc.Controllers
{
    public class BOLController : Controller
    {
        private ContextModel db = new ContextModel();
        // GET: BOL
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BL(FinalBilling fb)
        {
            return View(fb);
        }
        public ActionResult getBL(GridParams g, string search)
        {
            var list = db.FinalBilling.Where(a => a.bookingNo.Contains(search) ||
                    a.billofladingNo.Contains(search) ||
                    a.bookingNo.Contains(search) ||
                    a.transactionNo.Contains(search) ||
                    a.vesselVoyage.Contains(search) ||
                    a.shipperName.Contains(search) ||
                    a.shipperAdd.Contains(search) ||
                    a.consigneeName.Contains(search) ||
                    a.consigneeAdd.Contains(search) ||
                    a.notifypartName.Contains(search) ||
                    a.notifypartAdd.Contains(search) ||
                    a.origin.Contains(search) ||
                    a.portoforigin.Contains(search) ||
                    a.relayPort.Contains(search) ||
                    a.portofDestination.Contains(search) ||
                    a.vesselName.Contains(search) ||
                    a.voyageNumber.Contains(search) ||
                    a.serviceMode.Contains(search) ||
                    a.cargoTypeorcontent.Contains(search) ||
                    a.billingReferenceNo.Contains(search)

            ).AsQueryable();
            return Json(new GridModelBuilder<Models.WEBSales.FinalBilling>(list, g)
            {
                KeyProp = o => o.billID,// needed for Entity Framework | nesting | tree | api
                Map = o => new
                {
                    o.billID,
                    o.billofladingNo,
                    o.eirinNo,
                    o.BillStatus,
                    o.bookingNo,
                    o.transactionNo,
                    o.vesselVoyage,
                    o.shipperName,
                    o.shipperAdd,
                    o.consigneeName,
                    o.consigneeAdd,
                    o.notifypartName,
                    o.notifypartAdd,
                    o.origin,
                    o.portoforigin,
                    o.relayPort,
                    o.portofDestination,
                    o.vesselName,
                    o.voyageNumber,
                    o.serviceMode,
                    o.cargoTypeorcontent,
                    o.billingReferenceNo


                }
            }.Build());
        }

        public ActionResult DisplayFbReport(string billID)
        {
            ViewBag.billID = billID;
            return View("DisplayFbReport");
        }
        public FileResult FbReport(string billID)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath(@"~/Report_Documents/fbRpt.rpt")));
            string query = String.Format("exec fbRept '{0}'", billID);
            var list = db.Database.SqlQuery<Reports_VM.fbRpt>(query).ToList();

            if (list.Count > 0)
            {
                rd.SetDataSource(list);
                rd.SetParameterValue(0, billID);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
            }

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf");
        }

        public ActionResult getPULLOUTFULLCONVAN(string Id)
        {
            var check = db.Database.SqlQuery<AdminLteMvc.Models.WEBSales.FinalBilling>("select * from checkforpulloutFullConvan where billID="+ Id + "").ToList();
            int cnt = check.Count();
            return new JsonResult { Data = new { cnt = cnt } };
        }
    }
}