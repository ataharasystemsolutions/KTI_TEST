using AdminLteMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminLteMvc.Models.WEBSales;
using System.Data.Entity;

namespace AdminLteMvc.Controllers
{
    public class RequestDeliveryController : Controller
    {
        private ContextModel db = new ContextModel();
        // GET: RequestDelivery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult rdSchedule()
        {
            var rds = db.RequestDeliverySchedule.ToList();
            var allpending = db.Database.SqlQuery<Models.Class.get_alltrnforRDS>("exec get_alltrnforRDS").ToList();
            List<SelectListItem> allpendinglist = new List<SelectListItem>();
            allpendinglist.Clear();
            allpendinglist.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (Models.Class.get_alltrnforRDS ll in allpending)
            {
                allpendinglist.Add(new SelectListItem { Text = ll.EIROConvanNo, Value = ll.EIROID.ToString() });
            }
            ViewBag.rds = rds;
            ViewBag.allpendinglist = allpendinglist;
            return View();
        }

        [HttpPost]
        public ActionResult gettrntrnDetails(int Id)
        {
            var allpending = db.Database.SqlQuery<Models.Class.get_alltrnforRDS>("exec get_alltrnforRDS").ToList();
            var allpendingfind = allpending.Where(a=>a.EIROID==Id);
            return new JsonResult { Data = new { allpendingfind = allpendingfind } };
        }
        public ActionResult addRDS( FormCollection form) 
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            try
            {
                int eiroid = int.Parse(form["EIROID"].ToString());
                var eirout = db.EirPullOut.Where(a => a.EIROID == eiroid).Single();

               
                var rds = new RequestDeliverySchedule();
                rds.dateCreated = DateTime.Today;
                rds.shipper = form["shipper"].Trim();
                rds.serviceType = form["servicetype"].Trim();
                rds.convanNo = form["hdnconvanNo"];
                rds.EIRONo = eirout.EIRONo;
                rds.EIROTransactionNoget = eirout.EIROTransactionNo;
                rds.status = form["needcro"] == "Yes" ? "Requested" : "Approved";
                rds.needCro = form["needcro"];
                rds.remarks = form["remarks"];

                db.RequestDeliverySchedule.Add(rds);
                db.SaveChanges();

                var rdsConsignee = new RequestDeliveryScheduleConsignee();
                for (int i = 0; i <= 10; i++)
                {
                    string consignee = "";
                    string ds = "";
                    string de = "";

                    switch (i)
                    {
                        case 0:
                            if (form["con1"].Trim().Length > 0)
                            {
                                consignee = form["con1"];
                                ds = form["ds1"];
                                de = form["de1"];
                            }
                            break;
                        case 1:
                            if (form["con2"].Trim().Length > 0)
                            {
                                consignee = form["con2"];
                                ds = form["ds2"];
                                de = form["de2"];
                            }
                            break;
                        case 2:
                            if (form["con3"].Trim().Length > 0)
                            {
                                consignee = form["con3"];
                                ds = form["ds3"];
                                de = form["de3"];
                            }
                            break;
                        case 3:
                            if (form["con4"].Trim().Length > 0)
                            {
                                consignee = form["con4"];
                                ds = form["ds4"];
                                de = form["de4"];
                            }
                            break;
                        case 4:
                            if (form["con5"].Trim().Length > 0)
                            {
                                consignee = form["con5"];
                                ds = form["ds5"];
                                de = form["de5"];
                            }
                            break;
                        case 5:
                            if (form["con6"].Trim().Length > 0)
                            {
                                consignee = form["con6"];
                                ds = form["ds6"];
                                de = form["de6"];
                            }
                            break;
                        case 6:
                            if (form["con7"].Trim().Length > 0)
                            {
                                consignee = form["con7"];
                                ds = form["ds7"];
                                de = form["de7"];
                            }
                            break;
                        case 7:
                            if (form["con8"].Trim().Length > 0)
                            {
                                consignee = form["con8"];
                                ds = form["ds8"];
                                de = form["de8"];
                            }
                            break;
                        case 8:
                            if (form["con9"].Trim().Length > 0)
                            {
                                consignee = form["con9"];
                                ds = form["ds9"];
                                de = form["de9"];
                            }
                            break;
                        case 9:
                            if (form["con10"].Trim().Length > 0)
                            {
                                consignee = form["con10"];
                                ds = form["ds10"];
                                de = form["de10"];
                            }
                            break;
                    }
                    if (consignee.Length > 0)
                    {
                        rdsConsignee.deliveryID = rds.deliveryID;
                        rdsConsignee.consigneeName = consignee;
                        rdsConsignee.startDate = DateTime.Parse(ds);
                        rdsConsignee.endDate = DateTime.Parse(de);
                        rdsConsignee.Status = form["needcro"] == "Yes" ? "For Approval" : "Approved";
                        db.RequestDeliveryScheduleConsignee.Add(rdsConsignee);
                        db.SaveChanges();
                    }

                }
                ViewBag.Message = "Saved";
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }

            return RedirectToAction("rdSchedule");
        }
        [HttpPost]
        public ActionResult getDetails(int Id)
        {
            var query = "select consigneeId,deliveryID, consigneeAddress,consigneeContact,Action,Status,consigneeName," +
                "case when LEFT(CONVERT(varchar,startdate,101),10)='01/01/1900' then '-' else LEFT(CONVERT(varchar,startdate,101),10) end as startDate," +
                "case when LEFT(CONVERT(varchar,endDate,101),10)='01/01/1900' then '-' else LEFT(CONVERT(varchar,endDate,101),10) end as endDate, status " +
                "from RequestDeliveryScheduleConsignees where deliveryID=" + Id+" ";
            var det = db.Database.SqlQuery<Models.Class.RequestDeliveryScheduleConsigneeDisplay>(query);
            return new JsonResult { Data = new { det = det } };
        }

    }
}