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

namespace AdminLteMvc.Controllers
{
    [Authorize]
    public class AccomInvoicesController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: AccomInvoices
        public ActionResult Index()
        {
            return View(db.AccomInvoices.ToList());
        }

        public ActionResult GetList(GridParams g, string search)
        {
            string user = User.Identity.Name;
            var userbranch = db.Users.FirstOrDefault(o => o.UserID == user).Branch;

            var list = db.AccomInvoices.Where(o => (o.CardCode.Contains(search) || o.CardName.Contains(search) || o.Project.Equals(search)) && o.Project == userbranch).AsQueryable();
            return Json(new GridModelBuilder<Models.WEBSales.AccomInvoice>(list, g)
            {
                KeyProp = o => o.DocEntry,// needed for Entity Framework | nesting | tree | api
                Map = o => new
                {

                    o.DocEntry,
                    o.DocNum,
                    o.CardName,
                    o.CardCode,
                    DocDate = o.DocDate.ToShortDateString(),
                    TaxDate = o.TaxDate.ToShortDateString(),
                    DocDueDate = o.DocDueDate.ToShortDateString(),
                    o.Project,
                    o.Status,
                    o.U_SAPStatus,
                    o.U_ErrorMessage,
                    DocTotal = o.DocTotal.ToString("#,###.00"),
                    o.NumAtCard
                }
            }.Build());
        }


        public JsonResult getDownPayment(string id, int? pricelist)
        {
            var results = from m in db.PriceLists
                          from n in db.PriceListLines.Where(p => p.PriceListID == m.PriceListID)
                          where m.PriceListID == pricelist && n.ItemCode == id
                          select new { n.DPYT2 };
            return Json(results.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getInstallment(int terms)
        {
            var result = db.PaymentTerms.FirstOrDefault(i => i.GroupNum == terms).InstNum;

            return new JsonResult { Data = new { result = result } };
        }


        public JsonResult getWTax(string id)
        {

            var wtax = (from i in db.BPWithHoldings.Where(o => o.CardCode == id)
                        from x in db.WithHoldings.Where(a => a.WTCode == i.WTCode)
                        select new { i.WTCode, x.WTName, x.Rate, x.Category }).ToList();

            return new JsonResult { Data = wtax, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getWTaxLine(string id, string wtcode)
        {

            var wtax = (from i in db.BPWithHoldings.Where(o => o.CardCode == id)
                        from x in db.WithHoldings.Where(a => a.WTCode == i.WTCode && a.WTCode == wtcode)
                        select new { i.WTCode, x.WTName, x.Rate, x.Category }).ToList();

            return new JsonResult { Data = wtax, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult Serial_Lookup(string id)
        {
            var item = (from i in db.SerialMasters.Where(x => x.Balance != 0 && x.QuantOut != x.Quantity && x.ItemCode == id)
                        select new
                        {
                            ItemCode = i.ItemCode,
                            MnfSerial = i.MnfSerial,
                            DistNumber = i.DistNumber,
                            EngineNo = i.EngineNo,
                            ChasisNo = i.ChasisNo,
                            Color = i.Color,
                            FrameNo = i.FrameNo
                        }).ToList();

            return Json(item, JsonRequestBehavior.AllowGet);
        }


        // GET: AccomInvoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccomInvoice accomInvoice = db.AccomInvoices.Find(id);
            if (accomInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.PriceList = new SelectList(db.PriceLists, "PriceListID", "PriceListName", accomInvoice.PriceList); 
            return View(accomInvoice);
        }

        public JsonResult Lookup_Fields(string term)
        {
            var results = from m in db.Items
                          where m.ItemCode.Equals(term) && m.Active == true
                          select new { m.BuyUnitMsr, m.ManSerNum };
            return Json(results.ToList(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult getPrice(string itemcode, int terms, decimal downpayment, int pricelist)
        {
            int mos = db.PaymentTerms.FirstOrDefault(x => x.GroupNum == terms).InstNum;

            List<Models.Class.tmpPriceList> list = new List<Models.Class.tmpPriceList>();

            var results = (from pr in db.PriceLists.Where(x => x.PriceListID == pricelist)
                           from prl in db.PriceListLines.Where(x => x.ItemCode == itemcode && x.PriceListID == pr.PriceListID && x.DPYT2 == downpayment)
                           select prl).ToList();


            foreach (var item in results)
            {
                if (mos == 1)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos1 * mos) + item.DPYT2,
                        MA = item.Mos1,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 2)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos2 * mos) + item.DPYT2,
                        MA = item.Mos2,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }

                if (mos == 3)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos3 * mos) + item.DPYT2,
                        MA = item.Mos3,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 4)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos4 * mos) + item.DPYT2,
                        MA = item.Mos4,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 5)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos5 * mos) + item.DPYT2,
                        MA = item.Mos5,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 6)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos6 * mos) + item.DPYT2,
                        MA = item.Mos6,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 7)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos7 * mos) + item.DPYT2,
                        MA = item.Mos7,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 8)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos8 * mos) + item.DPYT2,
                        MA = item.Mos8,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 9)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos9 * mos) + item.DPYT2,
                        MA = item.Mos9,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 10)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos10 * mos) + item.DPYT2,
                        MA = item.Mos10,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 11)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos11 * mos) + item.DPYT2,
                        MA = item.Mos11,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 12)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos12 * mos) + item.DPYT2,
                        MA = item.Mos12,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 13)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos13 * mos) + item.DPYT2,
                        MA = item.Mos13,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 14)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos14 * mos) + item.DPYT2,
                        MA = item.Mos14,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 15)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos15 * mos) + item.DPYT2,
                        MA = item.Mos15,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 16)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos16 * mos) + item.DPYT2,
                        MA = item.Mos16,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 17)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos17 * mos) + item.DPYT2,
                        MA = item.Mos17,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 18)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos18 * mos) + item.DPYT2,
                        MA = item.Mos18,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 19)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos19 * mos) + item.DPYT2,
                        MA = item.Mos19,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 20)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos20 * mos) + item.DPYT2,
                        MA = item.Mos20,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 21)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos21 * mos) + item.DPYT2,
                        MA = item.Mos21,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 22)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos22 * mos) + item.DPYT2,
                        MA = item.Mos22,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 23)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos23 * mos) + item.DPYT2,
                        MA = item.Mos23,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 24)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos24 * mos) + item.DPYT2,
                        MA = item.Mos24,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 25)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos25 * mos) + item.DPYT2,
                        MA = item.Mos25,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 26)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos26 * mos) + item.DPYT2,
                        MA = item.Mos26,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 27)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos27 * mos) + item.DPYT2,
                        MA = item.Mos27,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 28)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos28 * mos) + item.DPYT2,
                        MA = item.Mos28,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 29)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos29 * mos) + item.DPYT2,
                        MA = item.Mos29,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 30)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos30 * mos) + item.DPYT2,
                        MA = item.Mos30,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 31)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos31 * mos) + item.DPYT2,
                        MA = item.Mos31,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 32)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos32 * mos) + item.DPYT2,
                        MA = item.Mos32,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 33)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos33 * mos) + item.DPYT2,
                        MA = item.Mos33,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 34)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos34 * mos) + item.DPYT2,
                        MA = item.Mos34,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 35)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos35 * mos) + item.DPYT2,
                        MA = item.Mos35,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
                if (mos == 36)
                {
                    var soitems = new Models.Class.tmpPriceList()
                    {
                        Price = (item.Mos36 * mos) + item.DPYT2,
                        MA = item.Mos36,
                        Rebate = item.Rebate
                    };
                    list.Add(soitems);
                }
            }

            return Json(list.ToList(), JsonRequestBehavior.AllowGet);
        }



        // GET: AccomInvoices/Create
        public ActionResult Create()
        {

            string user = User.Identity.Name;
            var userbranch = db.Users.FirstOrDefault(o => o.UserID == user).Branch;


            var branch_pricelst = db.PriceListBranches.Where(o => o.PrjCode == userbranch).Select(o => o.PriceListID).ToList();

            var pricelist = (from n in db.PriceLists.Where(o => o.Validfrom <= DateTime.Today && o.Validto >= DateTime.Today && branch_pricelst.Contains(o.PriceListID)).DefaultIfEmpty()
                             select n
                            ).ToList();

            ViewBag.PriceList = new SelectList(pricelist, "PriceListID", "PriceListName");
            ViewBag.Branch = userbranch;

            int? docentry = 0;
            docentry = db.AccomInvoices.Max(u => (int?)u.DocNum) == null ? 0 : db.AccomInvoices.Max(u => (int?)u.DocNum);
            ViewBag.DocNum = docentry + 1;
            return View();
        }


        public int getDocNum()
        {
            int? docentry = 0;
            docentry = db.AccomInvoices.Max(u => (int?)u.DocNum) == null ? 0 : db.AccomInvoices.Max(u => (int?)u.DocNum);

            return Convert.ToInt32(docentry + 1);

        }

        [HttpPost]
        public JsonResult Save(AccomInvoice data)
        {
            bool status = false;

            //var isValidModel = TryUpdateModel(data);
            //if (isValidModel)
            //{
         
                data.DocNum = getDocNum();

                db.AccomInvoices.Add(data);
                db.SaveChanges();

                status = true;
            //}


            return new JsonResult { Data = new { status = status } };
        }

        // POST: AccomInvoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocEntry,DocNum,CardCode,CardName,Status,DocDate,TaxDate,DocDueDate,CreatedDate,CreatedTime,NumAtCard,Remarks,DocTotal,SubTotal,WTaxTotal,PaidTodate,ReceiptNum,Discount,Project,GroupNum,OwnerCode,SlpCode,Address,PriceList,Installment,ActivityType,U_SAPStatus,U_SAPDocEntry,U_ErrorMessage,PNIssuedNo,PNIssuedAt,PNIssuedDate,CMIssuedDate,InterestRate")] AccomInvoice accomInvoice)
        {
            if (ModelState.IsValid)
            {
                db.AccomInvoices.Add(accomInvoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accomInvoice);
        }

        // GET: AccomInvoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccomInvoice accomInvoice = db.AccomInvoices.Find(id);
            if (accomInvoice == null)
            {
                return HttpNotFound();
            }
            return View(accomInvoice);
        }

        // POST: AccomInvoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocEntry,DocNum,CardCode,CardName,Status,DocDate,TaxDate,DocDueDate,CreatedDate,CreatedTime,NumAtCard,Remarks,DocTotal,SubTotal,WTaxTotal,PaidTodate,ReceiptNum,Discount,Project,GroupNum,OwnerCode,SlpCode,Address,PriceList,Installment,ActivityType,U_SAPStatus,U_SAPDocEntry,U_ErrorMessage,PNIssuedNo,PNIssuedAt,PNIssuedDate,CMIssuedDate,InterestRate")] AccomInvoice accomInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accomInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accomInvoice);
        }

        // GET: AccomInvoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccomInvoice accomInvoice = db.AccomInvoices.Find(id);
            if (accomInvoice == null)
            {
                return HttpNotFound();
            }
            return View(accomInvoice);
        }

        // POST: AccomInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccomInvoice accomInvoice = db.AccomInvoices.Find(id);
            db.AccomInvoices.Remove(accomInvoice);
            db.SaveChanges();
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
