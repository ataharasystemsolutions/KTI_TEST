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

namespace AdminLteMvc.Controllers
{
    public class EIRController : Controller
    {

        private ContextModel db = new ContextModel();
        // GET: EIRPullOut
        public ActionResult IndexOut()
        {
            return View();
        }
        public ActionResult IndexIn()
        {
            return View();
        }
        public ActionResult Trial()
        {
            return View();
        }
        public ActionResult GetItemsOut(GridParams g, string search)
        {
            var list = db.EirPullOut.Where(o => (o.EIRONo.Contains(search) || o.EIROStatus.Contains(search) || o.EIRODate.Contains(search)
            || o.EIROTime.Contains(search) || o.EIROServiceType.Contains(search) || o.EIROConvanNo.Contains(search)
            || o.EIROConvanSize.Contains(search) || o.EIROConvanStatus.Contains(search) || o.EIROTransactionNo.Contains(search)
            || o.EIRORelayPort.Contains(search) || o.EIROShipper.Contains(search) || o.EIROConsignee.Contains(search)
            || o.EIROTrucker.Contains(search) || o.EIROPlateNo.Contains(search) || o.EIRODriversName.Contains(search)
            || o.EIROVessel.Contains(search) || o.EIROVoyageNo.Contains(search) || o.EIROPortOfOrigin.Contains(search)
            || o.EIROPortOfDestination.Contains(search) || o.EIROSealNo.Contains(search) || o.EIROSealStatus.Contains(search)
            || o.EIROWeight.Contains(search) || o.EIROVolume.Contains(search) || o.EIRODamagesCode.Contains(search)
            || o.EIROSCR.Contains(search))).AsQueryable();
            return Json(new GridModelBuilder<Models.WEBSales.EirPullOut>(list, g)
            {
                KeyProp = o => o.EIROID, // needed for Entity Framework | nesting | tree | api
                Map = o => new
                {
                    o.EIROID,
                    o.EIRONo,
                    o.EIROStatus,
                    o.EIRODate,
                    o.EIROTime,
                    o.EIROServiceType,
                    o.EIROConvanNo,
                    o.EIROConvanSize,
                    o.EIROConvanStatus,
                    o.EIROTransactionNo,
                    o.EIRORelayPort,
                    o.EIROShipper,
                    o.EIROConsignee,
                    o.EIROTrucker,
                    o.EIROPlateNo,
                    o.EIRODriversName,
                    o.EIROVessel,
                    o.EIROVoyageNo,
                    o.EIROPortOfOrigin,
                    o.EIROPortOfDestination,
                    o.EIROSealNo,
                    o.EIROSealStatus,
                    o.EIROWeight,
                    o.EIROVolume,
                    o.EIRODamagesCode,
                    o.EIROSCR
                }
            }.Build());
        }

        public ActionResult GetItemsIn(GridParams g, string search)
        {
            var list = db.EIRIn.Where(o => (o.EIRINo.Contains(search) || o.EIRIReferenceNo.Contains(search) || o.EIRIStatus.Contains(search) || o.EIRIDate.Contains(search)
            || o.EIRITime.Contains(search) || o.EIRIServiceType.Contains(search) || o.EIRIConvanNo.Contains(search)
            || o.EIRIConvanSize.Contains(search) || o.EIRIConvanStatus.Contains(search) || o.EIRITransactionNo.Contains(search)
            || o.EIRIRelayPort.Contains(search) || o.EIRIShipper.Contains(search) || o.EIRIConsignee.Contains(search)
            || o.EIRITrucker.Contains(search) || o.EIRIPlateNo.Contains(search) || o.EIRIDriversName.Contains(search)
            || o.EIRIVessel.Contains(search) || o.EIRIVoyageNo.Contains(search) || o.EIRIPortOfOrigin.Contains(search)
            || o.EIRIPortOfDestination.Contains(search) || o.EIRISealNo.Contains(search) || o.EIRISealStatus.Contains(search)
            || o.EIRIWeight.Contains(search) || o.EIRIVolume.Contains(search) || o.EIRIDamagesCode.Contains(search)
            || o.EIRISCR.Contains(search))).AsQueryable();
             //&& o.EIRIStatus == "Billed"
            return Json(new GridModelBuilder<Models.WEBSales.EIRIn>(list, g)
            {
                KeyProp = o => o.EIRIID,// needed for Entity Framework | nesting | tree | api
                Map = o => new
                {
                    o.EIRIID,
                    o.EIRINo,
                    o.EIRIReferenceNo,
                    o.EIRIStatus,
                    o.EIRIDate,
                    o.EIRITime,
                    o.EIRIServiceType,
                    o.EIRIConvanNo,
                    o.EIRIConvanSize,
                    o.EIRIConvanStatus,
                    o.EIRITransactionNo,
                    o.EIRIRelayPort,
                    o.EIRIShipper,
                    o.EIRIConsignee,
                    o.EIRITrucker,
                    o.EIRIPlateNo,
                    o.EIRIDriversName,
                    o.EIRIVessel,
                    o.EIRIVoyageNo,
                    o.EIRIPortOfOrigin,
                    o.EIRIPortOfDestination,
                    o.EIRISealNo,
                    o.EIRISealStatus,
                    o.EIRIWeight,
                    o.EIRIVolume,
                    o.EIRIDamagesCode,
                    o.EIRISCR
                }
            }.Build());
        }

        public ActionResult EirPullOut(int ID, string cvno1, int counter, string cvno2)
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            TempData["atwId"] = ID;
            try {
                ViewBag.ATWID = ID;
                var dateTime = DateTime.Now;
                ViewBag.cn1 = cvno1;
                ViewBag.cn2 = cvno2;

                // get atw transaction and update convanNo
                var atwupdate = db.ATW.Find(ID);
                if (cvno1 != "0" && cvno1!="***" && cvno1.Length!=0)
                    atwupdate.convanno1 = cvno1;
                if (cvno2 != "0" && cvno2 != "***" && cvno2.Length != 0)
                    atwupdate.convanno2 = cvno2;
                db.SaveChanges();


                //update transaction 2
                if (cvno2!="0" && cvno2 != "***" && cvno2.Length != 0)
                {
                    var tran2 = atwupdate.transactionno2;
                    var gettran2ID = db.TransactionDetails.Where(s => s.transactionNo.Equals(tran2)).Select(s => s.tranID).Single();
                    var trn2update = db.TransactionDetails.Find(gettran2ID);
                    trn2update.convanno = cvno2;
                    trn2update.confirmStatus = "Confirmed";
                    //trn2update.atwID = ID;
                    db.SaveChanges();
                }


                //update transaction 1
                if (cvno1 != "0" && cvno1 != "***" && cvno1.Length != 0)
                {
                    var tran1 = atwupdate.transactionno1;
                    var gettran1ID = db.TransactionDetails.Where(s => s.transactionNo.Equals(tran1)).Select(s => s.tranID).Single();
                    var trn1update = db.TransactionDetails.Find(gettran1ID);
                    trn1update.convanno = cvno1;
                    trn1update.confirmStatus = "Confirmed";
                    db.SaveChanges();
                }


                // update convanNo Monitoring
                var cvn = db.ConVanNo.Where(a => a.convanNo == cvno2 || a.convanNo == cvno1).ToList();
                if (cvn.Count() > 0)
                {
                    foreach (var c in cvn)
                    {
                        var cvnn = db.ConVanNo.Where(a => a.convanNo == c.convanNo).SingleOrDefault();
                        cvnn.status = "Closed";
                        db.SaveChanges();
                    }
                }
                transaction.Commit();

                //get transactionDetails
                var tranDet = db.TransactionDetails.Where(a => a.atwID == ID && a.outStatus==null && a.confirmStatus=="Confirmed").ToList();

                List<SelectListItem> trns = new List<SelectListItem>();
                trns.Add(new SelectListItem
                {
                    Text = "Select below",
                    Value = "0"
                });
                foreach (TransactionDetails dt in tranDet)
                {
                    trns.Add
                    (
                        new SelectListItem
                        {
                            Text = dt.transactionNo,
                            Value = dt.transactionNo
                        }
                    );
                }

                //assigned ViewBAG to populate data in every dropdown list
                ViewBag.Trns = trns;
                ViewBag.CounterNo = counter;

                ViewBag.ATWBkNo = atwupdate.atwBkNo;
                ViewBag.DateToday = DateTime.Now.ToString("dd/MM/yyyy");
                ViewBag.TimeToday = DateTime.Now.ToString("h:mm:ss tt");

                List<Vessel> VesselList = db.Vessel.ToList();
                ViewBag.VesselList = new SelectList(VesselList, "vesselID", "vesselName");

                List<PortOfOrigin> portorgList = db.PortOfOrigin.ToList();
                ViewBag.OriginList = new SelectList(portorgList, "poiID", "originport");

                List<PortOfDestination> portdestList = db.PortOfDestination.ToList();
                ViewBag.DestinationList = new SelectList(portdestList, "podID", "destinationport");

                List<SealStatus> sealstatList = db.SealStatus.ToList();
                ViewBag.SealStatusList = new SelectList(sealstatList, "sealID", "sealstatus");

                var damages = db.DamagesCode.ToList();
                List<SelectListItem> damageList = new List<SelectListItem>();
                foreach (DamagesCode item in damages)
                {
                    damageList.Add(new SelectListItem
                    {
                        Text = item.damage,
                        Value = item.damage
                    });
                }
                ViewBag.DamageList = damageList;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            return View();
        }

        [HttpPost]
        public JsonResult Pull(int ID, string cvno1, int counter)
        {
            var atwupdate = db.ATW.Find(ID);
            var dateTime = DateTime.Now;
           
            ViewBag.CounterNo = 3;
            //db.ATW.Attach(atwupdate);
            //atwupdate.convanno1 = cvno1;
            //db.Entry(atwupdate).Property("convanno1").IsModified = true;
            //db.SaveChanges();


            var tran1 = atwupdate.transactionno1;
            var gettran1ID = db.TransactionDetails.Where(s => s.transactionNo.Equals(tran1)).Select(s => s.tranID).Single();
            var trn1update = db.TransactionDetails.Find(gettran1ID);
            //db.TransactionDetails.Attach(trn1update);
            //trn1update.convanno = cvno1;
            //db.Entry(trn1update).Property("convanno").IsModified = true;
            //db.SaveChanges();

            List<SelectListItem> trn = new List<SelectListItem>();
            trn.Add(new SelectListItem
            {
                Text = tran1,
                Value = tran1
            });

            var trnno = trn[0].Value;

            ViewBag.IDPassed = ID;

            List<string> ids = new List<string>();
            var getNoOfEIR = db.EirPullOut.AsEnumerable().Select(r => r.EIRONo).ToList();
            var idValue = "";
            if (getNoOfEIR.Count() >= 1)
            {
                List<int> idList = new List<int>();
                foreach (var a in getNoOfEIR)
                {
                    string eirnum = a.Substring(9);
                    idList.Add(Int32.Parse(eirnum));
                }
                int[] IDS = idList.ToArray();
                var biggestID = IDS.Max() + 1;
                idValue = biggestID.ToString();
            }
            else
            {
                idValue = "10001";
            }

            var eirno = "OUT-" + dateTime.Year + "-" + idValue;

            ViewBag.ListofTrns = atwupdate.trns;

            var cno = trn1update.convanno;
            var getBooking = db.Booking.Where(s => s.docNum.Equals(atwupdate.bkNo)).Single();

            var cstat = getBooking.cstatus;
            var csize = getBooking.csize;
            var shipper = getBooking.cnameshpr;
            var trucker = atwupdate.aTrucker;
            var dname = atwupdate.aDriver;
            var pno = atwupdate.plateNo;

            var trnfromyrd = atwupdate.trns.Split(',');

            var stype = db.TransactionDetails.Where(s => s.transactionNo.Equals(trn1update.transactionNo)).Select(s => s.serviceType).Single();
            var relayp = db.TransactionDetails.Where(s => s.transactionNo.Equals(trn1update.transactionNo)).Select(s => s.cyEPO).Single();
            List<string> consign = new List<string>();
            var c = db.TransactionDetails.Where(s => s.transactionNo.Equals(trn1update.transactionNo)).Select(a => new { a.consignee1, a.consignee2, a.consignee3, a.consignee4, a.consignee5, a.consignee6, a.consignee7, a.consignee8, a.consignee9, a.consignee10 }).ToList();

            consign.Add(c.Select(s => s.consignee1).Single());
            consign.Add(c.Select(s => s.consignee2).Single());
            consign.Add(c.Select(s => s.consignee3).Single());
            consign.Add(c.Select(s => s.consignee4).Single());
            consign.Add(c.Select(s => s.consignee5).Single());
            consign.Add(c.Select(s => s.consignee6).Single());
            consign.Add(c.Select(s => s.consignee7).Single());
            consign.Add(c.Select(s => s.consignee8).Single());
            consign.Add(c.Select(s => s.consignee9).Single());
            consign.Add(c.Select(s => s.consignee10).Single());

            var consignee = string.Join(",", consign);

            ViewBag.ATWBkNo = atwupdate.atwBkNo;
            var dtoday = DateTime.Now.ToString("dd/MM/yyyy");
            var dtime = DateTime.Now.ToString("h:mm:ss tt");

            List<Vessel> VesselList = db.Vessel.ToList();
            ViewBag.VesselList = new SelectList(VesselList, "vesselID", "vesselName");

            List<PortOfOrigin> portorgList = db.PortOfOrigin.ToList();
            ViewBag.OriginList = new SelectList(portorgList, "poiID", "originport");

            List<PortOfDestination> portdestList = db.PortOfDestination.ToList();
            ViewBag.DestinationList = new SelectList(portdestList, "podID", "destinationport");

            List<SealStatus> sealstatList = db.SealStatus.ToList();
            ViewBag.SealStatusList = new SelectList(sealstatList, "sealID", "sealstatus");

            var damages = db.DamagesCode.ToList();
            List<SelectListItem> damageList = new List<SelectListItem>();
            foreach (DamagesCode item in damages)
            {
                damageList.Add(new SelectListItem
                {
                    Text = item.damage,
                    Value = item.damage
                });
            }
            ViewBag.DamageList = damageList;

            var result = new
            {
                eirno = eirno,
                trndrop = trnno,
                idate = dtoday,
                itime = dtime,
                stype = stype,
                trnno = trnno,
                cno = cno,
                cstat = cstat,
                csize = csize,
                consignee = consignee,
                dname = dname,
                trucker = trucker,
                shipper = shipper,
                pno=pno,
                relayp=relayp,
                status = true
            };

            //return Json(result, JsonRequestBehavior.AllowGet);

            return new JsonResult { Data = result };
        }

        public JsonResult GetDataFromTrn(int ID, string trnselected)
        {
            //List<VoyageNo> VoyageNoList = db.VoyageNo.Where(s => s.vesselid.Equals(vesselID.ToString())).ToList();
            var atwdata = db.ATW.Find(ID);
            var tran = trnselected;

            //var tran1 = atwdata.transactionno1;
            var gettranID = db.TransactionDetails.Where(s => s.transactionNo.Equals(trnselected)).Select(s => s.tranID).Single();
            var trnupdate = db.TransactionDetails.Find(gettranID);

            var cvno = trnupdate.convanno;
            //var getATW = db.ATW.Where(s => s.atwBkNo.Equals(activityInDb.yardATWBkNo)).Single();
            var getBooking = db.Booking.Where(s => s.docNum.Equals(atwdata.bkNo)).Single();

            var cstat = getBooking.cstatus;
            var csize = getBooking.csize;
            var shipper = getBooking.cnameshpr;
            var trucker = atwdata.aTrucker;
            var driver = atwdata.aDriver;
            var pn = atwdata.plateNo;

            var trnfromyrd = atwdata.trns.Split(',');
            //List<string> stype = new List<string>();

            var st = db.TransactionDetails.Where(s => s.transactionNo.Equals(trnupdate.transactionNo)).Select(s => s.serviceType).Single();
            var rp = db.TransactionDetails.Where(s => s.transactionNo.Equals(trnupdate.transactionNo)).Select(s => s.cyEPO).Single();
            //List<string> cyEPO = new List<string>();
            List<string> consign = new List<string>();
            //for (int i = 0; i < 10; i++)
            //{
            //    var a = trnfromyrd[i];
            //var st = db.TransactionDetails.Where(s => s.transactionNo.Equals(a)).Select(s => s.serviceType).Single();
            //var cyepo = db.TransactionDetails.Where(s => s.transactionNo.Equals(a)).Select(s => s.cyEPO).Single();
            var c = db.TransactionDetails.Where(s => s.transactionNo.Equals(trnupdate.transactionNo)).Select(a => new { a.consignee1, a.consignee2, a.consignee3, a.consignee4, a.consignee5, a.consignee6, a.consignee7, a.consignee8, a.consignee9, a.consignee10 }).ToList();

            consign.Add(c.Select(s => s.consignee1).Single());
            consign.Add(c.Select(s => s.consignee2).Single());
            consign.Add(c.Select(s => s.consignee3).Single());
            consign.Add(c.Select(s => s.consignee4).Single());
            consign.Add(c.Select(s => s.consignee5).Single());
            consign.Add(c.Select(s => s.consignee6).Single());
            consign.Add(c.Select(s => s.consignee7).Single());
            consign.Add(c.Select(s => s.consignee8).Single());
            consign.Add(c.Select(s => s.consignee9).Single());
            consign.Add(c.Select(s => s.consignee10).Single());
            //stype.Add(st);
            //cyEPO.Add(cyepo);
            //consign.Add(cnsgnee);
            //}

            //ViewBag.ServiceType = string.Join(",", stype);
            //ViewBag.RelayPort = string.Join(",", cyEPO);
            //ViewBag.RelayPort = string.Join(",", cyEPO);
            //ViewBag.Consignee = string.Join(",", consign);

            var consignee = string.Join(",", consign);
            var dateTime = DateTime.Now;

            List<string> ids = new List<string>();
            var getNoOfEIR = db.EirPullOut.AsEnumerable().Select(r => r.EIRONo).ToList();
            var idValue = "";
            if (getNoOfEIR.Count() >= 1)
            {
                List<int> idList = new List<int>();
                foreach (var a in getNoOfEIR)
                {
                    string eirno = a.Substring(9);
                    idList.Add(Int32.Parse(eirno));
                }
                int[] IDS = idList.ToArray();
                var biggestID = IDS.Max() + 1;
                idValue = biggestID.ToString();
            }
            else
            {
                idValue = "10001";
            }

            var eirNO = "OUT-" + dateTime.Year + "-" + idValue;

            var result = new
            {
                CVNO = cvno,
                CSTAT = cstat,
                CSIZE = csize,
                SHIPPER = shipper,
                TRUCKER = trucker,
                DRIVER = driver,
                PLATENO = pn,
                STYPE = st,
                RELAYPORT = rp,
                CONSIGNEE = consignee,
                TRN = tran,
                EIRNo = eirNO
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVesselNo(int vesselID)
        {
            List<VoyageNo> VoyageNoList = db.VoyageNo.Where(s => s.vesselid.Equals(vesselID.ToString()) && s.status=="Open" && s.transactionNumber=="-").ToList();
            return Json(VoyageNoList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetVesselNoIN(int vesselID)
        {
            List<VoyageNo> VoyageNoList = db.VoyageNo.Where(s => s.vesselid.Equals(vesselID.ToString())).ToList();
            return Json(VoyageNoList, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Save(EirPullOut data)
        {
            bool status = false;
            int atwID =int.Parse(TempData["atwId"].ToString());
            int flag = 0;
            DbContextTransaction transaction = db.Database.BeginTransaction();
            try
            {
                var isValidModel = TryUpdateModel(data);
                if (isValidModel)
                {
                    //saving new data to EirPullOut table
                    db.EirPullOut.Add(data);
                    db.SaveChanges();

                    status = true;
                }
                //update table TransactionDetails column outStatus and set to "Pull Out"
                var trnDetails = db.TransactionDetails.Where(a => a.transactionNo == data.EIROTransactionNo).SingleOrDefault();
                trnDetails.outStatus = "Pull Out";
                db.SaveChanges();

              

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }

            //setting up flaging to know the last item to pullout and it will redirect  into the EIROUT TAB
            var chkTRNDETAILS = db.TransactionDetails.Where(a => a.atwID == atwID && a.outStatus==null).ToList();
            if (chkTRNDETAILS.Count > 0)
                flag = 1;


            return new JsonResult { Data = new { status = status,flag=flag } };
        }

        public ActionResult EIRReturn(int ID)
        {
            ViewBag.IDFromOut = ID;


            EirPullOut eirDetails = db.EirPullOut.Find(ID);

            ProformaBills proformaBill = db.ProformaBills.Where(a=>a.proformaBillRefNo==eirDetails.EIRONo).Single();
            ViewBag.vesselID = proformaBill.proformaBillVesselID;
            ViewBag.voyageID = proformaBill.proformaBillVoyageID;

            var dateTime = DateTime.Now;
            ViewBag.TimeToday = DateTime.Now.ToString("h:mm:ss tt");

            List<string> ids = new List<string>();
            var getNoOfEIR = db.EIRIn.AsEnumerable().Select(r => r.EIRINo).ToList();
            var idValue = "";
            if (getNoOfEIR.Count() >= 1)
            {
                List<int> idList = new List<int>();
                foreach (var a in getNoOfEIR)
                {
                    string eirno = a.Substring(8);
                    idList.Add(Int32.Parse(eirno));
                }
                int[] IDS = idList.ToArray();
                var biggestID = IDS.Max() + 1;
                idValue = biggestID.ToString();
            }
            else
            {
                idValue = "10001";
            }
            var damages = db.DamagesCode.ToList();
            List<SelectListItem> damageList = new List<SelectListItem>();
            foreach (DamagesCode item in damages)
            {
                damageList.Add(new SelectListItem
                {
                    Text = item.damage,
                    Value = item.damage
                });
            }
            ViewBag.DamageList = damageList;
            ViewBag.EIRINo = "IN-" + dateTime.Year + "-" + idValue;


            var cyepo = db.CYEPO.ToList();
            List<SelectListItem> cyepolist = new List<SelectListItem>();
            cyepolist.Clear();
            cyepolist.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (CYEPO cp in cyepo)
            {
                cyepolist.Add(new SelectListItem
                {
                    Text = cp.cyEpo,
                    Value = cp.cyEpo
                });
            }
            ViewBag.cyepolist = cyepolist;

            var Vessel = db.Vessel.ToList();
            List<SelectListItem> vessellist = new List<SelectListItem>();
            vessellist.Clear();
            vessellist.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (Vessel v in Vessel)
            {
                vessellist.Add(new SelectListItem
                {
                    Text = v.vesselName.Trim(),
                    Value = v.vesselID.ToString()
                });
            }
            ViewBag.vessellist = vessellist;

            var sealstatus = db.SealStatus.ToList();
            List<SelectListItem> sslist = new List<SelectListItem>();
            sslist.Clear();
            sslist.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (SealStatus ss in sealstatus)
            {
                sslist.Add(new SelectListItem
                {
                    Text = ss.sealstatus.Trim(),
                    Value =ss.sealstatus.Trim()
                });
            }
            ViewBag.sslist = sslist;

            var convanstatus = db.ConVanStatus.ToList();
            List<SelectListItem> cvslist = new List<SelectListItem>();
            cvslist.Clear();
            cvslist.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (ConVanStatus cvs in convanstatus)
            {
                cvslist.Add(new SelectListItem
                {
                    Text = cvs.status.Trim(),
                    Value = cvs.status.Trim()
                });
            }
            ViewBag.cvslist = cvslist;
            return View("EIRReturn", eirDetails);
        }

     
        public ActionResult selectvesselName(string refno)
        {
            string query = "select a.vesselName,b.voyageNo from Vessels a " +
                            "inner join VoyageNoes b on a.vesselID = b.vesselid " +
                            "where a.vesselID  = " + refno + "";
            var list = db.Database.SqlQuery<Models.Class.dataPopulation>(query);
            return new JsonResult { Data = new { parent = list } };
        }
        [HttpPost]
        public ActionResult Return(EIRIn data, int ID)
        {
            bool status = false;
            string ff="";
            DbContextTransaction transaction = db.Database.BeginTransaction();
            try
            {
                var isValidModel = TryUpdateModel(data);
                if (isValidModel)
                {
                    EIRIn ERIN = db.EIRIn.Add(data);
                    ERIN.EIRIConvanStatus = "Full";
                    db.SaveChanges();

                    ff = ERIN.EIRINo;

                    var eirout = db.EirPullOut.Find(ID);
                    db.EirPullOut.Attach(eirout);
                    eirout.EIROStatus = "In";
                    db.Entry(eirout).Property("EIROStatus").IsModified = true;
                    db.SaveChanges();

                    var mnc = db.ProformaBills.Where(x => x.proformaBillRefNo == eirout.EIRONo).FirstOrDefault();
                    mnc.proformaBillStatus = "In";
                    db.SaveChanges();

                    //var voyNo = db.VoyageNo.Where(a => a.transactionNumber == eirout.EIROTransactionNo).ToList();
                    //if (voyNo.Count > 0)
                    //{
                    //    if (voyNo.SingleOrDefault().voyageID != data.voyageID)
                    //    {
                    //        var updateVoyageNo = voyNo.SingleOrDefault();
                    //        updateVoyageNo.status = "Open";
                    //        updateVoyageNo.transactionNumber = "-";
                    //        db.SaveChanges();

                    //        var updateSelectedVoyageNo = db.VoyageNo.Where(a => a.voyageID == data.voyageID).First();
                    //        updateSelectedVoyageNo.status = "Closed";
                    //        updateSelectedVoyageNo.transactionNumber = eirout.EIROTransactionNo;
                    //        db.SaveChanges();

                    //    }
                    //}


                    status = true;
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return Json("Error occurred. Error details: " + ex.Message);
                
            }
            return new JsonResult { Data = new { status = status,   ff=ff } };
        }
        [HttpPost]
        public ActionResult Uploads(string fl)
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            string[] f = file.FileName.Split('.');
                            fname = fl +'.'+ f[1]; // file.FileName;
                        }
                        var uploadRootFolderInput = AppDomain.CurrentDomain.BaseDirectory + "\\Waybill";
                        Directory.CreateDirectory(uploadRootFolderInput);
                        var directoryFullPathInput = uploadRootFolderInput;
                        fname = Path.Combine(directoryFullPathInput, fname);
                        file.SaveAs(fname);
                    }
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        public ActionResult ReturnPrint(int ID)
        {
            var eirndetails = db.EIRIn.Find(ID);
            return View("ReturnPrint", eirndetails);
        }

        public ActionResult ViewDetails(int ID)
        {
            var eiroutdtls = db.EirPullOut.Find(ID);
            return View("ViewDetails", eiroutdtls);
        }
        public ActionResult EIROViewDetails(string eiroNo)
        {
            ViewBag.EIRONO = eiroNo;
            return View("EIROViewDetails");
        }

        public ActionResult EIRIViewDetails(string eirNo)
        {
            ViewBag.EIRINO = eirNo;
            return View("EIRIViewDetails");
        }

        public FileResult DisplayEIROReport(string EIRONo)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath(@"~/Report_Documents/EIROReport.rpt")));
            string query = String.Format("exec SP_PullOutByEIRONo '{0}'", EIRONo);
            var list = db.Database.SqlQuery<Reports_VM.EIROVm>(query).ToList();

            if (list.Count > 0)
            {
                rd.SetDataSource(list);
                rd.SetParameterValue(0, EIRONo);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
            }

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf");
            rd.Close();
            rd.Dispose();
        }

        public FileResult DisplayEIRIReturnReport(string EIRINo)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath(@"~/Report_Documents/EIRIReturnInReport.rpt")));
            string query = String.Format("exec SP_ForReturnPrintReport '{0}'", EIRINo);
            var list = db.Database.SqlQuery<Reports_VM.EIRIVm>(query).ToList();

            if (list.Count > 0)
            {
                rd.SetDataSource(list);
                rd.SetParameterValue(0, EIRINo);

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
