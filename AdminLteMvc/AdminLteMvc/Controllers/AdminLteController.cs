using AdminLteMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLteMvc.Controllers
{
    //[Authorize]
    /// <summary>
    /// This is an example controller using the AdminLTE NuGet package's CSHTML templates, CSS, and JavaScript
    /// You can delete these, or use them as handy references when building your own applications
    /// </summary>
    public class AdminLteController : Controller
    {
        private ContextModel db = new ContextModel();
        /// <summary>
        /// The home page of the AdminLTE demo dashboard, recreated in this new system
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //var list = (from n in db.SalesInvoices.ToList()
            //            select new
            //            {
            //                n.Project,
            //                n.DocTotal
            //            }
            //       )
            //       .Union(from n in db.AccomInvoices.ToList()
            //              select new
            //              {
            //                  n.Project,
            //                  n.DocTotal
            //              })
            //     .Union(from n in db.CashInvoices.ToList()
            //            select new
            //            {
            //                n.Project,
            //                n.DocTotal
            //            })
            //       .Union(from n in db.DPInvoices.ToList()
            //              select new
            //              {
            //                  n.Project,
            //                  n.DocTotal
            //              });

            //var final = (from n in list.AsEnumerable()
            //             group n by new { n.Project } into g
            //             select new Models.Class.tmpSalesForAllBranch()
            //             {
            //                 Project = g.Key.Project,
            //                 DocTotal = g.Sum(i => i.DocTotal)

            //             }).ToList();

            //ViewBag.SalesForAllBranch = final;

            ////Unposted Transactions
            //ViewBag.SalesOrder = db.SalesOrders.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.CashInvoice = db.CashInvoices.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.InstInvoice = db.SalesInvoices.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.AccomInvoice = db.AccomInvoices.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.DownPayment = db.DPInvoices.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.Incoming = db.Incomings.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.Resumption = db.GoodsIssues.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.Repossesion = db.GoodsReceipts.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.StockTransfer = db.InvTransfers.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.BranchReceiving = db.BranchReceivings.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.WarrantyReturns = db.WarrantyReturns.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.OtherGoodsReceipt = db.OtherGoodsReceipts.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.WarrantyRepairs = db.WarrantyRepairs.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.ChangeUnit = db.ChangeUnits.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.Replacement = db.Replacements.Where(o => o.U_SAPStatus == false).Count();
            //ViewBag.OtherGoodsIssue = db.OtherGoodsIssues.Where(o => o.U_SAPStatus == false).Count();

            return View();
        }

        public ActionResult GetSales_AllBranch()
        {
            var list = (from n in db.SalesInvoices.ToList()
                        select new
                        {
                          n.Project,
                          n.DocTotal
                        }
                       )
                       .Union(from n in db.AccomInvoices.ToList()
                              select new
                              {
                                n.Project,
                                n.DocTotal
                              })
                     .Union(from n in db.CashInvoices.ToList()
                            select new
                            {
                               n.Project,
                               n.DocTotal
                            })
                       .Union(from n in db.DPInvoices.ToList()
                              select new
                              {
                                n.Project,
                                n.DocTotal
                              });

            var final = (from n in list.AsEnumerable()
                         group n by new { n.Project } into g
                         select new 
                         {
                            Project= g.Key.Project,
                            DocTotal=g.Sum(i=>i.DocTotal)

                         }).ToList();


            return Json(final, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The color page of the AdminLTE demo, demonstrating the AdminLte.Color enum and supporting methods
        /// </summary>
        /// <returns></returns>
        public ActionResult Colors()
        {
            return View();
        }
    }
}