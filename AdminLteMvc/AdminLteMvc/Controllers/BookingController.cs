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
using Microsoft.AspNet.Identity;

namespace AdminLteMvc.Controllers
{
    public class BookingController : Controller
    { 
        private ContextModel db = new ContextModel();
        // GET: Booking
        public ActionResult Index(Booking bk)
        {
            return View(bk);
        }

        //public ActionResult GetItems(GridParams g, string search)
        //{
        //    var list = db.Booking.Where(o => o.trnStatus.Contains(search) || o.docDate.Contains(search) || o.docNum.Contains(search) || o.cnameshpr.Contains(search) 
        //    || o.csize.Contains(search) || o.cstatus.Contains(search) || o.mnemonic.Contains(search)
        //    || o.accountexecutive.Contains(search) || o.contactno.Contains(search) || o.contactperson.Contains(search)
        //    || o.csr.Contains(search) || o.inhouseBookingDate.Contains(search) || o.inputtedby.Contains(search) || o.noofcvs.Contains(search) || o.shipperTelNo.Contains(search)).AsQueryable();
        //    return Json(new GridModelBuilder<Models.WEBSales.Booking>(list, g)
        //    {
        //        KeyProp = o => o.ID,// needed for Entity Framework | nesting | tree | api
        //        Map = o => new
        //        {
        //            o.ID,
        //            o.preparedBy,
        //            o.trnStatus,
        //            o.docDate,
        //            o.docNum,
        //            o.billTo,
        //            o.mnemonic,
        //            o.cnameshpr,
        //            o.shipperAddress,
        //            o.shipperTelNo,
        //            o.csize,
        //            o.cstatus,
        //            o.csr,
        //            o.contactno,
        //            o.contactperson,
        //            o.inhouseBookingDate,
        //            o.inputtedby,
        //            o.noofcvs,
        //            o.accountexecutive
        //        }
        //    }.Build());
        //}
        public ActionResult GetItems(GridParams g, string search)
        {
            var list = db.Database.SqlQuery<Models.Class.BookingTRN>("select * from BookingList where dataField like'%" + search + "%'");
            return Json(new GridModelBuilder<Models.Class.BookingTRN>(list.AsQueryable(), g)
            {
                KeyProp = o => o.ID,  // needed for Entity Framework | nesting | tree | api
                Map = o => new
                {
                    o.ID,
                    o.preparedBy,
                    o.stat,
                    o.trnStatus,
                    o.docDate,
                    o.docNum,
                    o.billTo,
                    o.mnemonic,
                    o.cnameshpr,
                    o.shipperAddress,
                    o.shipperTelNo,
                    o.csize,
                    o.cstatus,
                    o.csr,
                    o.contactno,
                    o.contactperson,
                    o.inhouseBookingDate,
                    o.inputtedby,
                    o.noofcvs,
                    o.accountexecutive
                }
            }.Build());
        }

        public void GetAccountExecutiveCSR()
        {
            string query = "SELECT * FROM EmployeeMasters WHERE JobTitle IN('Account Executive');";
            var list = db.Database.SqlQuery<Models.WEBSales.EmployeeMaster>(query);
            List<SelectListItem> aeList = new List<SelectListItem>();
            foreach (Models.WEBSales.EmployeeMaster acc in list)
            {
                aeList.Add(new SelectListItem
                {
                    Text = acc.FirstName +" "+ acc.MiddleName +" "+ acc.LastName,
                    Value = acc.FirstName.ToString() +" "+ acc.MiddleName.ToString() +" "+ acc.LastName.ToString()
                });
            }
            ViewBag.aeList = aeList;

            string qquery = "SELECT * FROM EmployeeMasters WHERE JobTitle IN('CSR');";
            var Llist = db.Database.SqlQuery<Models.WEBSales.EmployeeMaster>(qquery);
            List<SelectListItem> csrList = new List<SelectListItem>();
            foreach (Models.WEBSales.EmployeeMaster csr in Llist)
            {
                csrList.Add(new SelectListItem
                {
                    Text = csr.FirstName + " " + csr.MiddleName + " " + csr.LastName,
                    Value = csr.FirstName.ToString() + " " + csr.MiddleName.ToString() + " " + csr.LastName.ToString()
                });
            }
            ViewBag.csrList = csrList;

        }
        public ActionResult Create()
        {
            var checkYear = db.Booking.AsEnumerable().Select(r => r.docID).FirstOrDefault();

            var mnemonic = db.Mnemonics.ToList();
            var custshpr = db.CustomerShippers.ToList();
            var convanSizes = db.ConVanSizes.ToList();
            var convanStatus = db.ConVanStatus.ToList();
            var inBy = db.InputtedBy.ToList();
            List<SelectListItem> mnemonicList = new List<SelectListItem>();
            List<SelectListItem> customerShipperList = new List<SelectListItem>();
            List<SelectListItem> ConVanSizeList = new List<SelectListItem>();
            List<SelectListItem> ConVanStatList = new List<SelectListItem>();
            List<SelectListItem> InByList = new List<SelectListItem>();
            foreach (Mnemonics item in mnemonic)
            {
                mnemonicList.Add(new SelectListItem
                {
                    Text = item.mnemonic,
                    Value = item.mnemonic
                });
            }

            foreach (CustomerShippers item in custshpr)
            {
                customerShipperList.Add(new SelectListItem
                {
                    Text = item.custShipr,
                    Value = item.custShipr
                });
            }

            foreach (ConVanSizes item in convanSizes)
            {
                ConVanSizeList.Add(new SelectListItem
                {
                    Text = item.sizes,
                    Value = item.sizes
                });
            }

            foreach (ConVanStatus item in convanStatus)
            {
                ConVanStatList.Add(new SelectListItem
                {
                    Text = item.status,
                    Value = item.status
                });
            }
            foreach (InputtedBy item in inBy)
            {
                InByList.Add(new SelectListItem
                {
                    Text = item.firstname + " " + item.lastname,
                    Value = item.firstname + " " + item.lastname
                });
            }

            ViewBag.MnemonicList = mnemonicList;
            ViewBag.CustomerShipperList = customerShipperList;
            ViewBag.ConVanSizesList = ConVanSizeList;
            ViewBag.ConVanStatusList = ConVanStatList;
            ViewBag.InByList = InByList;

            GetAccountExecutiveCSR();
            return View();
        }

        [HttpGet]
        public ActionResult GetIDSFromYear(string yearInput)
        {
            List<string> ids = new List<string>();
            var checkYear = db.Booking.AsEnumerable().Select(r => r.docYear).ToList();
            var idValue = "";
            if (checkYear.Contains(yearInput))
            {
                ids = db.Booking.Where(s => s.docYear.Equals(yearInput)).Select(r => r.docID).ToList();
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
        public ActionResult BindMnemonic(string mnemonicValue)
        {
            var getMnemonicID = db.Mnemonics.Where(s => s.mnemonic.Equals(mnemonicValue)).Select(r => r.ID).SingleOrDefault();
            var Custshipper = db.CustomerShippers.Where(s => s.mnemID.Equals(getMnemonicID)).Select(r => r.custShipr).SingleOrDefault();
            var telnum = db.Mnemonics.Where(s=>s.mnemonic.Equals(mnemonicValue)).Select(s=>s.shipperstelephoneno).Single();
            var conper = db.Mnemonics.Where(s => s.mnemonic.Equals(mnemonicValue)).Select(s => s.contactperson).Single();
            var connum = db.Mnemonics.Where(s => s.mnemonic.Equals(mnemonicValue)).Select(s => s.contactno).Single();
            List<SelectListItem> addresses = new List<SelectListItem>();

            var adds = db.Mnemonics.Where(s => s.mnemonic.Equals(mnemonicValue)).Select(x => new { x.address1, x.address2, x.address3, x.address4, x.address5 }).ToList();

            //return Json(new Modle.JsonResponseData { Status = flag, Message = msg, Html = html }, JsonRequestBehavior.AllowGet);
            //return Json(custshipper);

            if (adds[0].address1 != null)
            {
                addresses.Add(new SelectListItem
                {
                    Text = adds[0].address1,
                    Value = adds[0].address1
                });
            }
            if (adds[0].address2 != null)
            {
                addresses.Add(new SelectListItem
                {
                    Text = adds[0].address2,
                    Value = adds[0].address2
                });
            }
            if (adds[0].address3 != null)
            {
                addresses.Add(new SelectListItem
                {
                    Text = adds[0].address3,
                    Value = adds[0].address3
                });
            }
            if (adds[0].address4 != null)
            {
                addresses.Add(new SelectListItem
                {
                    Text = adds[0].address4,
                    Value = adds[0].address4
                });
            }
            if (adds[0].address5 != null)
            {
                addresses.Add(new SelectListItem
                {
                    Text = adds[0].address5,
                    Value = adds[0].address5
                });
            }

            var result = new
            {
                shipper = Custshipper,
                tel = telnum,
                address = addresses,
                person = conper,
                cno = connum
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult BindConsignee(string consigneeValue)
        {
            var cadd = db.Consignee.Where(s => s.consignee.Equals(consigneeValue)).Select(r => r.consigneeaddress).SingleOrDefault();
            var cnum = db.Consignee.Where(s => s.consignee.Equals(consigneeValue)).Select(r => r.consigneecontactno).SingleOrDefault();

            var result = new
            {
                cadd,
                cnum
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateBooking(Booking bk)
        {
            bool status = false;

            var isValidModel = TryUpdateModel(bk);
            if (isValidModel)
            {
                using (var db = new ContextModel())
                {
                    db.Entry(bk).State = EntityState.Modified;
                    db.SaveChanges();
                }
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult Cancel(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking bkdtls = db.Booking.Find(id);
            if (bkdtls == null)
            {
                return HttpNotFound();
            }
            return View(bkdtls);
        }

        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public ActionResult CancelConfirmed(int id)
        {
            var bk = new Booking() { ID = id};
            using (var db = new ContextModel())
            {
                db.Booking.Attach(bk);
                bk.trnStatus = "Cancelled";
                db.Entry(bk).Property(x => x.trnStatus).IsModified = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Booking bk)
        {
          
            if (ModelState.IsValid)
            {
                db.Booking.Add(bk);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View(bk);
        }

        [HttpPost]
        public JsonResult Save(Booking data)
        {
            int userid = int.Parse(User.Identity.GetUserName());
            bool status = false;

            var isValidModel = TryUpdateModel(data);
            if (isValidModel)
            {
              var saveBooking=  db.Booking.Add(data);
                saveBooking.userId = userid;
                db.Booking.Add(saveBooking);
                db.SaveChanges();

                status = true;
            }


            return new JsonResult { Data = new { status = status, transacID = data.ID } };
        }

        public ActionResult TrnDetails(int ID)
        {
            int flag = 0;
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking idDtls = db.Booking.Find(ID);
            string docuID = idDtls.docID.ToString();
            var bkdetails = db.TransactionDetails.Where(t => t.transactionID==ID && t.dtlStatus!= "Cancelled").ToList();
            //if (bkdetails == null)
            //{
            //    return HttpNotFound();
            //}
            ViewBag.Branch = new SelectList(db.Projects, "ProjectCode", "ProjectName");
            int bk =int.Parse(idDtls.noofcvs);
            int trn = bkdetails.Count();

            if (bk == trn)
                flag = 1;

            ViewBag.flag = flag;

            return View("TrnDetails", idDtls);
        }

        public ActionResult ViewBooking(int ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking idDtls = db.Booking.Find(ID);
            if (idDtls == null)
            {
                return HttpNotFound();
            }
            return View("ViewBooking", idDtls);
        }

        public ActionResult GetTrnDetails(GridParams g, string search, string trnID)
        {


            var list = db.TransactionDetails.Where(o => o.documentID.Contains(trnID)).Where(x => (x.booktype.Contains(search) || x.conClass.Contains(search) || x.cyEPO.Contains(search) || x.cyLD.Contains(search) || x.cySA.Contains(search) || x.destination.Contains(search) || x.origin.Contains(search) || x.payMode.Contains(search))).OrderBy(s => s.transactionNo);
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
                    o.conClass,
                    o.conRqrmnts,
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

        public ActionResult AddDetail(int ID)
        {
            Booking newDetail = db.Booking.Find(ID);
            var keyID = newDetail.ID;
            ViewBag.ID = keyID;
            var documID = newDetail.docID;
            ViewBag.docuID = documID;
            ViewBag.docNumber = newDetail.docNum;
            ViewBag.CSIZE = newDetail.csize;
            ViewBag.BookingDate = newDetail.docDate;
            ViewBag.CnameShipper = newDetail.cnameshpr;



            var plist = db.PriceGroup.ToList();
            var org = db.Origin.ToList();
            var dest = db.Destination.ToList();
            var dbCon = db.Consignee.ToList();
            var dbCharge = db.ChargeTo.ToList();
            var dbServ = db.ServiceType.ToList();
            var dbCargo = db.CargoType.ToList();
            var dbContainer = db.ContainerClass.ToList();
            var dbConRequirements = db.ConVanRequirements.ToList();
            var dbEPO = db.CYEPO.ToList();
            var dbSA = db.CYSA.ToList();
            var dbLD = db.CYLD.ToList();
            var dbpm = db.PaymentMode.ToList();
            var bktype = db.BookingType.ToList();
            var cvnos = db.ConVanNo.Distinct().ToList();
            List<SelectListItem> cvnosList = new List<SelectListItem>();
            List<SelectListItem> prList = new List<SelectListItem>();
            List<SelectListItem> orgList = new List<SelectListItem>();
            List<SelectListItem> destList = new List<SelectListItem>();
            List<SelectListItem> dbConList = new List<SelectListItem>();
            List<SelectListItem> dbChargeList = new List<SelectListItem>();
            List<SelectListItem> dbServList = new List<SelectListItem>();
            List<SelectListItem> dbCargoList = new List<SelectListItem>();
            List<SelectListItem> dbContainerList = new List<SelectListItem>();
            List<SelectListItem> dbConRequirementsList = new List<SelectListItem>();
            List<SelectListItem> dbEPOList = new List<SelectListItem>();
            List<SelectListItem> dbSAList = new List<SelectListItem>();
            List<SelectListItem> dbLDList = new List<SelectListItem>();
            List<SelectListItem> paymentList = new List<SelectListItem>();
            List<SelectListItem> bktypeList = new List<SelectListItem>();
            foreach (PaymentMode item in dbpm)
            {
                paymentList.Add(new SelectListItem
                {
                    Text = item.paymentmode,
                    Value = item.paymentmode
                });
            }
            foreach (PriceGroup item in plist)
            {
                prList.Add(new SelectListItem
                {
                    Text = item.priceGroup,
                    Value = item.priceGroup
                });
            }
            foreach (Origin item in org)
            {
                orgList.Add(new SelectListItem
                {
                    Text = item.origin,
                    Value = item.origin
                });
            }
            foreach (Destination item in dest)
            {
                destList.Add(new SelectListItem
                {
                    Text = item.destination,
                    Value = item.destination
                });
            }
            foreach (Consignee item in dbCon)
            {
                dbConList.Add(new SelectListItem
                {
                    Text = item.consignee,
                    Value = item.consignee
                });
            }
            foreach (ChargeTo item in dbCharge)
            {
                dbChargeList.Add(new SelectListItem
                {
                    Text = item.chargeTo,
                    Value = item.chargeTo
                });
            }
            foreach (ServiceType item in dbServ)
            {
                dbServList.Add(new SelectListItem
                {
                    Text = item.sType,
                    Value = item.sType
                });
            }
            foreach (CargoType item in dbCargo)
            {
                dbCargoList.Add(new SelectListItem
                {
                    Text = item.cargotype,
                    Value = item.cargotype
                });
            }
            foreach (ContainerClass item in dbContainer)
            {
                dbContainerList.Add(new SelectListItem
                {
                    Text = item.conclass,
                    Value = item.conclass
                });
            }
            foreach (ConVanRequirements item in dbConRequirements)
            {
                dbConRequirementsList.Add(new SelectListItem
                {
                    Text = item.requirements,
                    Value = item.requirements
                });
            }
            foreach (CYEPO item in dbEPO)
            {
                dbEPOList.Add(new SelectListItem
                {
                    Text = item.cyEpo,
                    Value = item.cyEpo
                });
            }
            foreach (CYSA item in dbSA)
            {
                dbSAList.Add(new SelectListItem
                {
                    Text = item.cySa,
                    Value = item.cySa
                });
            }
            foreach (CYLD item in dbLD) 
            {
                dbLDList.Add(new SelectListItem
                {
                    Text = item.cyLd,
                    Value = item.cyLd
                });
            }
            foreach (BookingType item in bktype)
            {
                bktypeList.Add(new SelectListItem
                {
                    Text = item.bookingtype,
                    Value = item.bookingtype
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

            // var getdocuID = db.Booking.Where(a => a.ID.Equals(keyID)).Select(r => r.docID).SingleOrDefault();
            var getAllTrnNoFromDocu = db.TransactionDetails.Where(s => s.documentID.Equals(documID)).Select(r => r.transactionNo).ToList();
            var trnValue = "";

            if (getAllTrnNoFromDocu.Count() == 0)
            {
                trnValue = newDetail.docNum + "-001";
            }
            else
            {
                List<int> trnList = new List<int>();
                for (int runs = 0; runs < getAllTrnNoFromDocu.Count(); runs++)
                {
                    var trnnum = getAllTrnNoFromDocu[runs].Substring(11);
                    trnList.Add(Int32.Parse(trnnum));
                }
                int[] IDS = trnList.ToArray();
                var biggestID = IDS.Max() + 1;
                var tempVal = biggestID.ToString();
                trnValue = newDetail.docNum+ "-00" + tempVal;
            }

            ViewBag.TrnValue = trnValue;
            ViewBag.PriceList = prList;
            ViewBag.OriginList = orgList;
            ViewBag.DestinationList = destList;
            ViewBag.ConsigneeList = dbConList;
            ViewBag.ChargeToList = dbChargeList;
            ViewBag.ServiceTypeList = dbServList;
            ViewBag.CargoTypeList = dbCargoList;
            ViewBag.ContainerClassList = dbContainerList;
            ViewBag.ConVanRequirementList = dbConRequirementsList;
            ViewBag.EPOList = dbEPOList;
            ViewBag.SAList = dbSAList;
            ViewBag.LDList = dbLDList;

            ViewBag.PaymentMode = paymentList;
            ViewBag.BookingType = bktypeList;
            ViewBag.ConVanNoList = cvnosList;
            return View();
        }

        [HttpPost]
        public JsonResult SaveNewDetail(TransactionDetails trnD)
        {
            bool status = false;
            int next = 0;

            var bk = db.Booking.Where(a => a.ID == trnD.transactionID).SingleOrDefault();
            var trn = db.TransactionDetails.Where(a => a.transactionID == trnD.transactionID && a.dtlStatus!= "Cancelled").ToList();

            int noofcv = int.Parse(bk.noofcvs);
            int trn_cnt = trn.Count();

            if (noofcv > trn_cnt)
            {
                var isValidModel = TryUpdateModel(trnD);
                if (isValidModel)
                {
                    db.TransactionDetails.Add(trnD);
                    db.SaveChanges();
                    status = true;
                }

                var trn1 = db.TransactionDetails.Where(a => a.transactionID == trnD.transactionID && a.dtlStatus != "Cancelled").ToList();
                if (noofcv > trn1.Count())
                    next = 1;
                else
                    next = 0;
            }
            return new JsonResult { Data = new { status = status, next=next } };
        }

        public ActionResult CancelDetail(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionDetails trndtls = db.TransactionDetails.Find(id);
            if (trndtls == null)
            {
                return HttpNotFound();
            }
            return View(trndtls);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("CancelDetail")]
        [ValidateAntiForgeryToken]
        public ActionResult CancelDtlConfirmed(int id)
        {

            TransactionDetails detail = db.TransactionDetails.Find(id);
            var IDtran = detail.transactionID;
            var dtl = new TransactionDetails() { tranID = id };
            using (var db = new ContextModel())
            {
                db.TransactionDetails.Attach(dtl);
                dtl.dtlStatus = "Cancelled";
                db.Entry(dtl).Property(x => x.dtlStatus).IsModified = true;
                db.SaveChanges();
            }
            return RedirectToAction("TrnDetails", new { ID = IDtran });
        }

        public ActionResult EditBooking(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking bkDtl = db.Booking.Find(id);
            if (bkDtl == null)
            {
                return HttpNotFound();
            }

            var mnemonic = db.Mnemonics.ToList();
            var custshpr = db.CustomerShippers.ToList();
            var convanSizes = db.ConVanSizes.ToList();
            var convanStatus = db.ConVanStatus.ToList();
            var inBy = db.InputtedBy.ToList();
            var csrs = db.CSR.ToList();
            var executives = db.AccountExecutive.ToList();
            List<SelectListItem> mnemonicList = new List<SelectListItem>();
            List<SelectListItem> customerShipperList = new List<SelectListItem>();
            List<SelectListItem> ConVanSizeList = new List<SelectListItem>();
            List<SelectListItem> ConVanStatList = new List<SelectListItem>();
            List<SelectListItem> InByList = new List<SelectListItem>();
            List<SelectListItem> CSRList = new List<SelectListItem>();
            List<SelectListItem> ExecutiveList = new List<SelectListItem>();
            foreach (Mnemonics item in mnemonic)
            {
                mnemonicList.Add(new SelectListItem
                {
                    Text = item.mnemonic,
                    Value = item.mnemonic
                });
            }

            foreach (CustomerShippers item in custshpr)
            {
                customerShipperList.Add(new SelectListItem
                {
                    Text = item.custShipr,
                    Value = item.custShipr
                });
            }

            foreach (ConVanSizes item in convanSizes)
            {
                ConVanSizeList.Add(new SelectListItem
                {
                    Text = item.sizes,
                    Value = item.sizes
                });
            }

            foreach (ConVanStatus item in convanStatus)
            {
                ConVanStatList.Add(new SelectListItem
                {
                    Text = item.status,
                    Value = item.status
                });
            }
            foreach (InputtedBy item in inBy)
            {
                InByList.Add(new SelectListItem
                {
                    Text = item.firstname + " " + item.lastname,
                    Value = item.firstname + " " + item.lastname
                });
            }
            foreach (CSR item in csrs)
            {
                CSRList.Add(new SelectListItem
                {
                    Text = item.csrname,
                    Value = item.csrname
                });
            }
            foreach (AccountExecutive item in executives)
            {
                ExecutiveList.Add(new SelectListItem
                {
                    Text = item.executivename,
                    Value = item.executivename
                });
            }


            ViewBag.MnemonicList = mnemonicList;
            ViewBag.CustomerShipperList = customerShipperList;
            ViewBag.ConVanSizesList = ConVanSizeList;
            ViewBag.ConVanStatusList = ConVanStatList;
            ViewBag.InByList = InByList;
            ViewBag.CSRSList = CSRList;
            ViewBag.AccountExecutiveList = ExecutiveList;

            List<SelectListItem> addresses = new List<SelectListItem>();

            var adds = db.Mnemonics.Where(s => s.mnemonic.Equals(bkDtl.mnemonic)).Select(x => new { x.address1, x.address2, x.address3, x.address4, x.address5 }).ToList();

            //return Json(new Modle.JsonResponseData { Status = flag, Message = msg, Html = html }, JsonRequestBehavior.AllowGet);
            //return Json(custshipper);

            if (adds[0].address1 != null)
            {
                addresses.Add(new SelectListItem
                {
                    Text = adds[0].address1,
                    Value = adds[0].address1
                });
            }
            if (adds[0].address2 != null)
            {
                addresses.Add(new SelectListItem
                {
                    Text = adds[0].address2,
                    Value = adds[0].address2
                });
            }
            if (adds[0].address3 != null)
            {
                addresses.Add(new SelectListItem
                {
                    Text = adds[0].address3,
                    Value = adds[0].address3
                });
            }
            if (adds[0].address4 != null)
            {
                addresses.Add(new SelectListItem
                {
                    Text = adds[0].address4,
                    Value = adds[0].address4
                });
            }
            if (adds[0].address5 != null)
            {
                addresses.Add(new SelectListItem
                {
                    Text = adds[0].address5,
                    Value = adds[0].address5
                });
            }

            ViewBag.Addresses = addresses;

            return View(bkDtl);
        }

            public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionDetails edtDtl = db.TransactionDetails.Find(id);
            if (edtDtl == null)
            {
                return HttpNotFound();
            }

            var plist = db.PriceGroup.ToList();
            var org = db.Origin.ToList();
            var dest = db.Destination.ToList();
            var dbCon = db.Consignee.ToList();
            var dbCharge = db.ChargeTo.ToList();
            var dbServ = db.ServiceType.ToList();
            var dbCargo = db.CargoType.ToList();
            var dbContainer = db.ContainerClass.ToList();
            var dbConRequirements = db.ConVanRequirements.ToList();
            var dbEPO = db.CYEPO.ToList();
            var dbSA = db.CYSA.ToList();
            var dbLD = db.CYLD.ToList();
            var dbpm = db.PaymentMode.ToList();
            var bktype = db.BookingType.ToList();
            List<SelectListItem> prList = new List<SelectListItem>();
            List<SelectListItem> orgList = new List<SelectListItem>();
            List<SelectListItem> destList = new List<SelectListItem>();
            List<SelectListItem> dbConList = new List<SelectListItem>();
            List<SelectListItem> dbChargeList = new List<SelectListItem>();
            List<SelectListItem> dbServList = new List<SelectListItem>();
            List<SelectListItem> dbCargoList = new List<SelectListItem>();
            List<SelectListItem> dbContainerList = new List<SelectListItem>();
            List<SelectListItem> dbConRequirementsList = new List<SelectListItem>();
            List<SelectListItem> dbEPOList = new List<SelectListItem>();
            List<SelectListItem> dbSAList = new List<SelectListItem>();
            List<SelectListItem> dbLDList = new List<SelectListItem>();
            List<SelectListItem> paymentList = new List<SelectListItem>();
            List<SelectListItem> bktypeList = new List<SelectListItem>();
            foreach (PaymentMode item in dbpm)
            {
                paymentList.Add(new SelectListItem
                {
                    Text = item.paymentmode,
                    Value = item.paymentmode
                });
            }
            foreach (PriceGroup item in plist)
            {
                prList.Add(new SelectListItem
                {
                    Text = item.priceGroup,
                    Value = item.priceGroup
                });
            }
            foreach (Origin item in org)
            {
                orgList.Add(new SelectListItem
                {
                    Text = item.origin,
                    Value = item.origin
                });
            }
            foreach (Destination item in dest)
            {
                destList.Add(new SelectListItem
                {
                    Text = item.destination,
                    Value = item.destination
                });
            }
            foreach (Consignee item in dbCon)
            {
                dbConList.Add(new SelectListItem
                {
                    Text = item.consignee,
                    Value = item.consignee
                });
            }
            foreach (ChargeTo item in dbCharge)
            {
                dbChargeList.Add(new SelectListItem
                {
                    Text = item.chargeTo,
                    Value = item.chargeTo
                });
            }
            foreach (ServiceType item in dbServ)
            {
                dbServList.Add(new SelectListItem
                {
                    Text = item.sType,
                    Value = item.sType
                });
            }
            foreach (CargoType item in dbCargo)
            {
                dbCargoList.Add(new SelectListItem
                {
                    Text = item.cargotype,
                    Value = item.cargotype
                });
            }
            foreach (ContainerClass item in dbContainer)
            {
                dbContainerList.Add(new SelectListItem
                {
                    Text = item.conclass,
                    Value = item.conclass
                });
            }
            foreach (ConVanRequirements item in dbConRequirements)
            {
                dbConRequirementsList.Add(new SelectListItem
                {
                    Text = item.requirements,
                    Value = item.requirements
                });
            }
            foreach (CYEPO item in dbEPO)
            {
                dbEPOList.Add(new SelectListItem
                {
                    Text = item.cyEpo,
                    Value = item.cyEpo
                });
            }
            foreach (CYSA item in dbSA)
            {
                dbSAList.Add(new SelectListItem
                {
                    Text = item.cySa,
                    Value = item.cySa
                });
            }
            foreach (CYLD item in dbLD)
            {
                dbLDList.Add(new SelectListItem
                {
                    Text = item.cyLd,
                    Value = item.cyLd
                });
            }
            foreach (BookingType item in bktype)
            {
                bktypeList.Add(new SelectListItem
                {
                    Text = item.bookingtype,
                    Value = item.bookingtype
                });
            }
            ViewBag.BookingType = bktypeList;
            ViewBag.PriceList = prList;
            ViewBag.OriginList = orgList;
            ViewBag.DestinationList = destList;
            ViewBag.ConsigneeList = dbConList;
            ViewBag.ChargeToList = dbChargeList;
            ViewBag.ServiceTypeList = dbServList;
            ViewBag.CargoTypeList = dbCargoList;
            ViewBag.ContainerClassList = dbContainerList;
            ViewBag.ConVanRequirementList = dbConRequirementsList;
            ViewBag.EPOList = dbEPOList;
            ViewBag.SAList = dbSAList;
            ViewBag.LDList = dbLDList;

            ViewBag.PaymentMode = paymentList;


            return View(edtDtl);
        }

        [HttpPost]
        public JsonResult Update(TransactionDetails trndtl)
        {
            bool status = false;

            var isValidModel = TryUpdateModel(trndtl);
            if (isValidModel)
            {
                using (var db = new ContextModel())
                {
                    db.Entry(trndtl).State = EntityState.Modified;
                    db.SaveChanges();
                }
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}