using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminLteMvc.Models;
using AdminLteMvc.Models.WEBSales;
using CrystalDecisions.CrystalReports.Engine;
using Omu.AwesomeMvc;
using Microsoft.AspNet.Identity;

namespace AdminLteMvc.Controllers
{
    public class ATWController : Controller
    {
        private ContextModel db = new ContextModel();
        // GET: ATW
        public ActionResult Index()
        {
            var cvnos = db.ConVanNo.Where(a=>a.status=="Open").ToList();
            List<SelectListItem> cvnosList = new List<SelectListItem>();
            cvnosList.Clear();
            cvnosList.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (ConVanNo item in cvnos)
            {
                cvnosList.Add(new SelectListItem
                {
                    Text = item.convanNo,
                    Value = item.convanNo
                });
            }
            ViewBag.ConVanNoList = cvnosList;
            return View();
        }

        public ActionResult GetItems(GridParams g, string search)
        {
            //var list = db.Database.SqlQuery<Models.Class.ATWDisplay>(@"select *,left(CONVERT(varchar,dateChange,101),10) AS dateChangeFormatted from 
            //                                                          ATWs where atwID like '%" + search + "%'");
            //var list = db.Database.SqlQuery<Models.WEBSales.ATW>("select *, dateChange AS dateChangeFormatted from ATWs");
            //var list = db.Database.SqlQuery<Models.WEBSales.ATW>("select *, convert(varchar, dateChange, getdate(), 1) from ATWs where atwID like '%" + search + "%'");
            var list = db.Database.SqlQuery<Models.Class.ATWDisplay>("select *, convert(varchar, dateChange, 1) as dateChangeFormatted from ATWs where atwID like '%" + search + "%'");
            //var list = db.Database.SqlQuery<Models.WEBSales.ATW>(@"select *, CAST(dateChange AS DATE) from ATWs where atwID like '%" + search + "%'");
            //var list = db.ATW.Where(o => o.aDriver.Contains(search) || o.aTrucker.Contains(search) || o.atwBkNo.Contains(search) || o.bkNo.Contains(search) || o.conPerson.Contains(search) || o.cShipper.Contains(search) || o.eDate.Contains(search) || o.iDate.Contains(search) || o.remarks.Contains(search) || o.userId.Contains(search) || o.dateChange.Contains(search)).AsQueryable();
            return Json(new GridModelBuilder<Models.Class.ATWDisplay>(list.AsQueryable(), g)

            {
                KeyProp = o => o.atwID,// needed for Entity Framework | nesting | tree | api
                Map = o => new
                {
                    o.atwID,
                    o.atwBkNo,
                    o.bkNo,
                    o.iDate,
                    o.eDate,
                    o.transactionno1,
                    o.transactionno2,
                    o.convanno1,
                    o.convanno2,
                    o.shipperno1,
                    o.shipperno2,
                    o.issuedBy,
                    o.plateNo,
                    o.aTrucker,
                    o.aDriver,
                    o.cShipper,
                    o.conPerson,
                    o.cvno,
                    o.remarks,
                    o.userId,
                    o.dateChange,
                    o.dateChangeFormatted
                }
            }.Build()) ;
        }

        public ActionResult GetAllTrns(GridParams g, string search)
        {
            var list = db.TransactionDetails.Where(o => o.dtlStatus.Contains("For Withdrawal")).Where(x => (x.cnameshipper.Contains(search) || x.booktype.Contains(search) || x.conClass.Contains(search) || x.cyEPO.Contains(search) || x.cyLD.Contains(search) || x.cySA.Contains(search) || x.destination.Contains(search) || x.origin.Contains(search) || x.payMode.Contains(search))).OrderBy(s => s.tranID);
            //var list = db.TransactionDetails.Where(o => o.dtlStatus.Contains("For Withdrawal")).Where(x => x.cargoType.Contains(search)).OrderBy(s => s.tranID);
            return Json(new GridModelBuilder<Models.WEBSales.TransactionDetails>(list, g)
            {
                KeyProp = o => o.tranID,// needed for Entity Framework | nesting | tree | api
                Map = o => new
                {
                    o.tranID,
                    o.transactionDate,
                    o.transactionNo,
                    o.dtlStatus,
                    o.origin,
                    o.destination,
                    o.consignee1,
                    o.consignee2,
                    o.consignee3,
                    o.consignee4,
                    o.consignee5,
                    o.consignee6,
                    o.consignee7,
                    o.consignee8,
                    o.consignee9,
                    o.consignee10,
                    o.cnameshipper,
                    o.conClass,
                    o.conRqrmnts,
                    o.convanno,
                    o.quantity,
                    o.payMode,
                    o.cyEPO,
                    o.cySA,
                    o.cyLD,
                    o.remarks,
                    o.booktype,
                    o.chargee,
                    o.consize,
                    o.serviceType           
                }
            }.Build());
        }

        public ActionResult Create()
        {
            var documents = db.Booking.Where(s=> s.trnStatus.Contains("Active")).ToList();
            var truckers = db.Truckers.ToList();
            var issuers = db.ATWIssuedBy.ToList();
            var cvnos = db.ConVanNo.Distinct().ToList();
            List<SelectListItem> documentList = new List<SelectListItem>();
            List<SelectListItem> truckerList = new List<SelectListItem>();
            List<SelectListItem> issuersList = new List<SelectListItem>();
            List<SelectListItem> cvnosList = new List<SelectListItem>();
            foreach (Booking item in documents)
            {
                documentList.Add(new SelectListItem
                {
                    Text = item.docNum,
                    Value = item.docNum
                });
            }
            foreach (Truckers item in truckers)
            {
                truckerList.Add(new SelectListItem
                {
                    Text = item.truckername,
                    Value = item.truckername
                });
            }
            foreach (ATWIssuedBy item in issuers)
            {
                issuersList.Add(new SelectListItem
                {
                    Text = item.issuersname,
                    Value = item.issuersname
                });
            }
            foreach (ATWIssuedBy item in issuers)
            {
                issuersList.Add(new SelectListItem
                {
                    Text = item.issuersname,
                    Value = item.issuersname
                });
            }
            foreach (ConVanNo item in cvnos)
            {
                cvnosList.Add(new SelectListItem
                {
                    Text = item.convanNo,
                    Value = item.convanNo
                });
            }
            ViewBag.ConVanNoList = cvnosList;
            ViewBag.DocumentNumbers = documentList;
            ViewBag.TruckerList = truckerList;
            ViewBag.IssuersList = issuersList;
            ViewBag.Opt = "Multiple";
            return View();
        }

        public ActionResult CreateOption(int ID)
        {
            var trndetail = db.TransactionDetails.Find(ID);
            ViewBag.BookNum = trndetail.docNumber;
            ViewBag.CnameShipper = db.Booking.Where(s=>s.docNum.Equals(trndetail.docNumber)).Select(s=>s.cnameshpr).Single();

            var truckers = db.Truckers.ToList();
            var issuers = db.ATWIssuedBy.ToList();
            List<SelectListItem> truckerList = new List<SelectListItem>();
            List<SelectListItem> issuersList = new List<SelectListItem>();
            foreach (Truckers item in truckers)
            {
                truckerList.Add(new SelectListItem
                {
                    Text = item.truckername,
                    Value = item.truckername
                });
            }
            foreach (ATWIssuedBy item in issuers)
            {
                issuersList.Add(new SelectListItem
                {
                    Text = item.issuersname,
                    Value = item.issuersname
                });
            }
            ViewBag.TruckerList = truckerList;
            ViewBag.IssuersList = issuersList;
            ViewBag.Opt = "Single";
            ViewBag.TRNDetail = trndetail;
            return View("Create");
        }

        [HttpGet]
        public ActionResult GetIDSFromYear(string yearInput)
        {
            List<string> ids = new List<string>();
            var checkYear = db.ATW.AsEnumerable().Select(r => r.atwYear).ToList();
            var idValue = "";
            if (checkYear.Contains(yearInput))
            {
                ids = db.ATW.Where(s => s.atwYear.Equals(yearInput)).Select(r => r.atwBkID).ToList();
                List<int> idList = new List<int>();
                for (int runs = 0; runs < ids.Count(); runs++)
                {
                    idList.Add(Int32.Parse(ids[runs]));
                }
                int[] IDS = idList.ToArray();
                var biggestID = IDS.Max() + 1;
                idValue = biggestID.ToString();
            }
            else
            {
                idValue = "10001";
            }
            ViewBag.yearInputted = yearInput;
            ViewBag.idGenerated = idValue;
            return Json(idValue, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetATWTrnDetails(string bknumber)
        {
            var getCompany = db.TransactionDetails.Where(s => s.docNumber.Equals(bknumber) && s.dtlStatus.Equals("For Withdrawal")).ToList();
            var getCname = db.Booking.Where(s=>s.docNum.Equals(bknumber)).Select(s=>s.cnameshpr).Single();
            var result = new
            {
                trndetail = getCompany,
                cname = getCname
                //tel = telnum
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult BindBookingToTransaction(string bknumber)
        {
            var getTrns = db.TransactionDetails.Where(s => bknumber.Contains(s.docNumber)).Select(r => r.transactionNo).ToList();
           // string trnLIST = string.Join(",", getTrns);
            return Json(getTrns, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveHdr(ATW data)
        {
            bool status = false;

            var isValidModel = TryUpdateModel(data);
            if (isValidModel)
            {
                var trns = data.trns.Split(',');
                for (int i=0;i<trns.Length;i++)
                {
                    var trnloop = trns[i];
                    var getTrnID = db.TransactionDetails.Where(s => s.transactionNo.Equals(trnloop)).Select(s=>s.tranID).Single();
                    var detail = new TransactionDetails {tranID = getTrnID };
                    db.TransactionDetails.Attach(detail);
                    detail.dtlStatus = "Withdrawn";                    
                    db.Entry(detail).Property("dtlStatus").IsModified = true;
                    db.SaveChanges();
                }

                var listoftrns = db.TransactionDetails.Where(s => s.docNumber.Equals(data.bkNo)).Select(s => s.dtlStatus).ToList();
                if (((IList<string>)listoftrns).Contains("For Withdrawal"))
                { }
                else
                {
                    var getbkID = db.Booking.Where(s=>s.docNum.Equals(data.bkNo)).Select(s=>s.ID).Single();
                    var activityInDb = db.Booking.Find(getbkID);
                    db.Booking.Attach(activityInDb);
                    activityInDb.trnStatus = "Closed";
                    db.Entry(activityInDb).Property("trnStatus").IsModified = true;
                    db.SaveChanges();
                }

                db.ATW.Add(data);
                db.SaveChanges();

                status = true;
            }


            return new JsonResult { Data = new { status = status, atwid = data.atwID} };
        }

        public ActionResult ATWTrnDetails(int ID)
        {  
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATW idDtls = db.ATW.Find(ID);
            var bkingNum = idDtls.bkNo.ToString();
            var trndb = db.TransactionDetails.Where(s=>s.docNumber.Equals(bkingNum)).Select(s=> s.transactionNo).ToList();
            List<SelectListItem> trnList = new List<SelectListItem>();
            foreach (var item in trndb)
            {
                trnList.Add(new SelectListItem
                {
                    Text = item.ToString(),
                    Value = item.ToString()
                });
            }
            ViewBag.ListOfTRN = trnList;
            string trnID = idDtls.atwBkNo.ToString();
            var atwdetails = db.ATW.Where(t => t.atwBkNo.Contains(trnID)).ToList();
            if (atwdetails == null)
            {
                return HttpNotFound();
            }
            return View("ATWTrnDetails", idDtls);
        }

        public ActionResult GetATWDetails(GridParams g, string search, string trnList, string bknum)
        {
            //var trns = atwBkNo.Split(',');
            //var transactions = new List<TransactionDetails>();

            //for (int i=0; i<trns.Length;i++)
            //{
            //    var tempTrn = trns[i];
            //    var list = db.TransactionDetails.Where(o => o.transactionNo.Contains(tempTrn) && o.docNumber.Equals(bknum)).Where(x => (x.cargoType.Contains(search) || x.conClass.Contains(search) || x.consignee.Contains(search) || x.consigneeAdd.Contains(search) || x.cyEPO.Contains(search) || x.cyLD.Contains(search) || x.cySA.Contains(search) || x.destination.Contains(search) || x.origin.Contains(search) || x.payMode.Contains(search) || x.priceList.Contains(search)));
            //    transactions.Add((TransactionDetails)list);
            //}

            //var list2 = transactions.AsQueryable();

            var lists = trnList.Split(',');
            string[] idlist = new string[lists.Length];
            for (int runs = 0; runs < lists.Length; runs++)
            {
                idlist[runs] = lists[runs];
            }

            //var list = db.TransactionDetails.Where(x => x.transactionNo.Contains(idlist));
            var list = from x in db.TransactionDetails
                       where idlist.Contains(x.transactionNo)
                       select x;
            //||x.cargoType.Contains(search) || x.conClass.Contains(search) || x.consignee.Contains(search) || x.consigneeAdd.Contains(search) || x.cyEPO.Contains(search) || x.cyLD.Contains(search) || x.cySA.Contains(search) || x.destination.Contains(search) || x.origin.Contains(search) || x.payMode.Contains(search) || x.priceList.Contains(search)).OrderBy(o=>o.tranID);
            

            return Json(new GridModelBuilder<Models.WEBSales.TransactionDetails>(list, g)
            {
                KeyProp = o => o.tranID,// needed for Entity Framework | nesting | tree | api
                Map = o => new
                {
                    o.tranID,
                    o.transactionDate,
                    o.transactionNo,
                    o.origin,
                    o.destination,
                    o.conClass,
                    o.conRqrmnts,
                    o.payMode,
                    o.cyEPO,
                    o.cySA,
                    o.cyLD,
                    o.remarks
                }
            }.Build());
        }


        public ActionResult AddATWDetail(int atwID)
        {
            ATW newDetail = db.ATW.Find(atwID);
            return View("AddATWDetail", newDetail);
        }

        //public ActionResult ForPrint(int ID, string atwbkno)
        //{
        //    var trndetail = db.TransactionDetails.Find(ID);
        //    var atwdetail = db.ATW.Where(s=>s.atwBkNo.Equals(atwbkno)).Single();
        //    var bkdetail = db.Booking.Where(s=>s.docNum.Equals(atwdetail.bkNo)).Single();

        //    ViewBag.Trucker = atwdetail.aTrucker;
        //    ViewBag.ATWBookingNo = atwdetail.atwBkNo;
        //    ViewBag.Driver = atwdetail.aDriver;
        //    ViewBag.PlateNo = atwdetail.plateNo;
        //    ViewBag.Shipper = atwdetail.cShipper;
        //    ViewBag.BookingNo = atwdetail.bkNo;
        //    ViewBag.ContactPerson = atwdetail.conPerson;
        //    ViewBag.IssueDate = atwdetail.iDate;
        //    ViewBag.ExpiryDate = atwdetail.eDate;
        //    ViewBag.ConvanSize = bkdetail.csize;
        //    ViewBag.ConvanStatus = bkdetail.cstatus;

        //    return View("ForPrint", trndetail);
        //}
        public FileResult DisplayATWReport(string ATWBKNO, string TRANSNO)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath(@"~/Report_Documents/ATWReport.rpt")));
            string query = String.Format("exec SP_ATW '{0}','{1}'", ATWBKNO, TRANSNO);
            var list = db.Database.SqlQuery<Reports_VM.ATWVm>(query).ToList();

            if (list.Count > 0)
            {
                rd.SetDataSource(list);
                rd.SetParameterValue(0, ATWBKNO);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
            }

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf");
        }

        public ActionResult ATWViewDetails (string transNo, string atwBkNo)
       {
            ViewBag.TRANSNO = transNo;
            ViewBag.ATWBKNO = atwBkNo;
            return View("ATWViewDetails");
        }

        //Cancel
        public ActionResult cancelATW(int Id)
        {
            string userid = User.Identity.GetUserId();
            var atws = db.ATW.Where(a => a.atwID == Id).FirstOrDefault();
            //atws.atwID = userid;
            atws.atwStatus = "InActive";
            atws.dateChange = DateTime.Now;
            atws.userId = userid;
            //atws.eDate = DateTime.Now;
            db.SaveChanges();

            ViewBag.Message = "Cancel Successfully";
            return Json(new { status = "Success" });
        }
    }
}