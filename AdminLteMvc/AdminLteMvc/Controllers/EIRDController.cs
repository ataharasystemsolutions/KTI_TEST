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
    public class EIRDController : Controller
    {
        private ContextModel db = new ContextModel();
        // GET: EIRD
        public ActionResult IndexOutLD(EIROutLD ld)
        {
            return View(ld);
        }

        public ActionResult IndexInECV(EIRINECV ecv)
        {
            return View(ecv);
        }
        public ActionResult GetPullOutLD(GridParams g, string search)
        {

            var list = db.EIROutLD.Where(o => o.eirldstatus.Contains(search) || o.eirldno.Contains(search) || o.eirldstatus.Contains(search) || o.eirldidate.Contains(search)
            || o.eirlditime.Contains(search) || o.eirldservicetype.Contains(search) || o.eirldtransactionno.Contains(search)
            || o.eirldconvanno.Contains(search) || o.eirldconvansize.Contains(search) || o.eirldconvanstatus.Contains(search)
            || o.eirldconsignee.Contains(search) || o.eirldshipper.Contains(search) || o.eirldtruckerdestination.Contains(search)
            || o.eirlddriversname.Contains(search) || o.eirldplateno.Contains(search) || o.eirldrelayport.Contains(search)
            || o.eirldvessel.Contains(search) || o.eirldvoyageno.Contains(search) || o.eirldsealno.Contains(search)
            || o.eirldsealstatus.Contains(search) || o.eirldportofdestination.Contains(search) || o.eirldportoforigin.Contains(search)
            || o.eirldweight.Contains(search) || o.eirldvolume.Contains(search) || o.eirlddamagescode.Contains(search)
            || o.eirldscr.Contains(search) || o.eirldremarks.Contains(search) || o.eirldcheckerdestination.Contains(search) || o.eirldtotriptype.Contains(search)).AsQueryable();
            return Json(new GridModelBuilder<Models.WEBSales.EIROutLD>(list, g)
            {
                KeyProp = o => o.eiroID,// needed for Entity Framework | nesting | tree | api
                Map = o => new
                {
                    o.eiroID,
                    o.eirldno,
                    o.eirldstatus,
                    o.eirldidate,
                    o.eirlditime,
                    o.eirldservicetype,
                    o.eirldtransactionno,
                    o.eirldconvanno,
                    o.eirldconvanstatus,
                    o.eirldconvansize,
                    o.eirldconsignee,
                    o.eirldshipper,
                    o.eirldtruckerdestination,
                    o.eirlddriversname,
                    o.eirldplateno,
                    o.eirldrelayport,
                    o.eirldvessel,
                    o.eirldvoyageno,
                    o.eirldsealno,
                    o.eirldsealstatus,
                    o.eirldportoforigin,
                    o.eirldportofdestination,
                    o.eirldweight,
                    o.eirldvolume,
                    o.eirlddamagescode,
                    o.eirldscr,
                    o.eirldremarks,
                    o.eirldcheckerdestination,
                    o.eirldtotriptype
                }
            }.Build());
        }

        public ActionResult GetReturnedECV(GridParams g, string search)
        {

            var list = db.EIRINECV.Where(o => o.eirinecvstatus.Contains(search) || o.eirinecvno.Contains(search) || o.eirinecvstatus.Contains(search) || o.eirinecvidate.Contains(search)
            || o.eirinecvitime.Contains(search) || o.eirinecvservicetype.Contains(search) || o.eirinecvtransactionno.Contains(search)
            || o.eirinecvconvanno.Contains(search) || o.eirinecvconvansize.Contains(search) || o.eirinecvconvanstatus.Contains(search)
            || o.eirinecvconsignee.Contains(search) || o.eirinecvshipper.Contains(search) || o.eirinecvtrucker.Contains(search)
            || o.eirinecvdriversname.Contains(search) || o.eirinecvplateno.Contains(search) || o.eirinecvrelayport.Contains(search)
            || o.eirinecvvessel.Contains(search) || o.eirinecvvoyageno.Contains(search) || o.eirinecvsealno.Contains(search)
            || o.eirinecvsealstatus.Contains(search) || o.eirinecvportofdestination.Contains(search) || o.eirinecvportoforigin.Contains(search)
            || o.eirinecvweight.Contains(search) || o.eirinecvvolume.Contains(search) || o.eirinecvdamagescode.Contains(search)
            || o.eirinecvscr.Contains(search) || o.eirinecvremarks.Contains(search) || o.eirinecvtriptype.Contains(search)).AsQueryable();
            return Json(new GridModelBuilder<Models.WEBSales.EIRINECV>(list, g)
            {
                KeyProp = o => o.eirinecvID,// needed for Entity Framework | nesting | tree | api
                Map = o => new
                {
                    o.eirinecvID,
                    o.eirinecvno,
                    o.eirinecvstatus,
                    o.eirinecvidate,
                    o.eirinecvitime,
                    o.eirinecvservicetype,
                    o.eirinecvtransactionno,
                    o.eirinecvconvanno,
                    o.eirinecvconvanstatus,
                    o.eirinecvconvansize,
                    o.eirinecvconsignee,
                    o.eirinecvshipper,
                    o.eirinecvtrucker,
                    o.eirinecvdriversname,
                    o.eirinecvplateno,
                    o.eirinecvrelayport,
                    o.eirinecvvessel,
                    o.eirinecvvoyageno,
                    o.eirinecvsealno,
                    o.eirinecvsealstatus,
                    o.eirinecvportoforigin,
                    o.eirinecvportofdestination,
                    o.eirinecvweight,
                    o.eirinecvvolume,
                    o.eirinecvdamagescode,
                    o.eirinecvscr,
                    o.eirinecvremarks,
                    o.eirinecvwaybillno,
                    o.eirinecvtriptype
                }
            }.Build());
        }
        public ActionResult Pull(int ID, string eirinno)
        {
            var dateTime = DateTime.Now;

            //Setting up the EIR No

            List<string> ids = new List<string>();
            var getNoOfEIR = db.EIROutLD.AsEnumerable().Select(r => r.eirldno).ToList();
            var idValue = "";
            if (getNoOfEIR.Count() >= 1)
            {
                List<int> idList = new List<int>();
                foreach (var a in getNoOfEIR)
                {
                    string eirno = a.Substring(11);
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

            var no = "OUTLD-" + dateTime.Year + "-" + idValue;

            //Get date and time for autostamp

            var datet = DateTime.Now.ToString("dd/MM/yyyy");
            var timet = DateTime.Now.ToString("h:mm:ss tt");

            //Get first the TrnNo, given the EIRIN No, so it's easier to get the details below.

            var trnno = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRITransactionNo).Single();

            //Get the service type for set

            var st = db.TransactionDetails.Where(s => s.transactionNo.Equals(trnno)).Select(s => s.serviceType).Single();


            //Get the Convan No./Status/Size, Consignee, Shippers, Drivers Name, Plate No, Vessel, Voyage No and etc.

            var cvno = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIConvanNo).Single();
            var cvsize = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIConvanSize).Single();
            var cvstatus = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIConvanStatus).Single();
            var consignee = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIConsignee).Single();
            var shipper = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIShipper).Single();
            var driver = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIDriversName).Single();
            var plate = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIPlateNo).Single();
            var relayport = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIRelayPort).Single();
            var vessel = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIVessel).Single();
            var voyageno = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIVoyageNo).Single();
            var sealno = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRISealNo).Single();
            var sealstatus = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRISealStatus).Single();
            var pog = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIPortOfOrigin).Single();
            var pod = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIPortOfDestination).Single();
            var weight = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIWeight).Single();
            var volume = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIVolume).Single();
            var scr = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRISCR).Single();
            var triptype = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.triptype).Single();


            //Get the list for the DamagesCodes and Seal Status

            var dc = db.EIRIn.Where(s => s.EIRINo.Equals(eirinno)).Select(s => s.EIRIDamagesCode).Single();

            var damages = db.DamagesCode.ToList();
            var ss = db.SealStatus.ToList();
            List<SelectListItem> sealstatList = new List<SelectListItem>();
            List<SelectListItem> damageList = new List<SelectListItem>();
            foreach (DamagesCode item in damages)
            {
                damageList.Add(new SelectListItem
                {
                    Text = item.damage,
                    Value = item.damage
                });
            }
            foreach (SealStatus item in ss)
            {
                sealstatList.Add(new SelectListItem
                {
                    Text = item.sealstatus,
                    Value = item.sealstatus
                });
            }
            ViewBag.DamageList = damageList;
            ViewBag.SealStatusList = sealstatList;

            EIROutLD ladendata = new EIROutLD
            {
                eirldno = no,
                eirldidate = datet,
                eirlditime = timet,
                eirldservicetype = st,
                eirldtransactionno = trnno,
                eirldconvanno = cvno,
                eirldconvansize = cvsize,
                eirldconvanstatus = cvstatus,
                eirldconsignee = consignee,
                eirldshipper = shipper,
                eirlddriversname = driver,
                eirldplateno = plate,
                eirldrelayport = relayport,
                eirldvessel = vessel,
                eirldvoyageno = voyageno,
                eirldsealno = sealno,
                eirldsealstatus = sealstatus,
                eirldportoforigin = pog,
                eirldportofdestination = pod,
                eirldweight = weight,
                eirldvolume = volume,
                eirldscr = scr,
                eirldtotriptype = triptype
            };
            ViewBag.EIROUT = ladendata;
            ViewBag.damages = dc;
            return View();
        }

        [HttpPost]
        public JsonResult SavePull(EIROutLD data)
        {
            bool status = false;
            DbContextTransaction transaction = db.Database.BeginTransaction();
            try
            {
               

                var isValidModel = TryUpdateModel(data);
                if (isValidModel)
                {
                    db.EIROutLD.Add(data);
                    db.SaveChanges();

                    //Update status in Bill of Lading

                    var bolID = db.FinalBilling.Where(s => s.transactionNo.Equals(data.eirldtransactionno)).Select(s => s.billID).Single();
                    var fb = db.FinalBilling.Find(bolID);
                    db.FinalBilling.Attach(fb);
                    fb.BillStatus = "Delivered";
                    db.Entry(fb).Property("BillStatus").IsModified = true;
                    db.SaveChanges();

                    //Update status in Proforma BL

                    var pblID = db.ProformaBills.Where(s => s.proformaBillRefNo.Equals(fb.billingReferenceNo)).Select(s => s.proformaBillID).Single();
                    var pb = db.ProformaBills.Find(pblID);
                    db.ProformaBills.Attach(pb);
                    pb.proformaBillStatus = "Delivered";
                    db.Entry(pb).Property("proformaBillStatus").IsModified = true;
                    db.SaveChanges();

                    //Update status in EIR In

                    var eirinID = db.EIRIn.Where(s => s.EIRITransactionNo.Equals(data.eirldtransactionno)).Select(s => s.EIRIID).Single();
                    var eirin = db.EIRIn.Find(eirinID);
                    db.EIRIn.Attach(eirin);
                    eirin.EIRIStatus = "Delivered";
                    db.Entry(eirin).Property("EIRIStatus").IsModified = true;
                    db.SaveChanges();

                    //Update status in EIR Out

                    var eiroutID = db.EirPullOut.Where(s => s.EIROTransactionNo.Equals(data.eirldtransactionno)).Select(s => s.EIROID).Single();
                    var eirout = db.EirPullOut.Find(eiroutID);
                    db.EirPullOut.Attach(eirout);
                    eirout.EIROStatus = "Delivered";
                    db.Entry(eirout).Property("EIROStatus").IsModified = true;
                    db.SaveChanges();


                    status = true;
                }
                transaction.Commit();
            }
            catch (Exception exp)
            {
                transaction.Rollback();
            }
           


            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult ReturnECV(int ID)
        {
            ViewBag.IDFromOut = ID;


            EIROutLD eirDetails = db.EIROutLD.Find(ID);
            var dateTime = DateTime.Now;
            ViewBag.TimeToday = DateTime.Now.ToString("h:mm:ss tt");

            List<string> ids = new List<string>();
            var getNoOfEIR = db.EIRINECV.AsEnumerable().Select(r => r.eirinecvno).ToList();
            var idValue = "";
            if (getNoOfEIR.Count() >= 1)
            {
                List<int> idList = new List<int>();
                foreach (var a in getNoOfEIR)
                {
                    string eirno = a.Substring(11);
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
            var poo = db.PortOfOrigin.ToList();
            var pod = db.PortOfDestination.ToList();
            var vsl = db.Vessel.ToList();
            var slstat = db.SealStatus.ToList();
            List<SelectListItem> damageList = new List<SelectListItem>();
            List<SelectListItem> pooList = new List<SelectListItem>();
            List<SelectListItem> podList = new List<SelectListItem>();
            List<SelectListItem> vslList = new List<SelectListItem>();
            List<SelectListItem> slstatList = new List<SelectListItem>();
            foreach (DamagesCode item in damages)
            {
                damageList.Add(new SelectListItem
                {
                    Text = item.damage,
                    Value = item.damage
                });
            }
            foreach (PortOfOrigin item in poo)
            {
                pooList.Add(new SelectListItem
                {
                    Text = item.originport,
                    Value = item.originport
                });
            }
            foreach (PortOfDestination item in pod)
            {
                podList.Add(new SelectListItem
                {
                    Text = item.destinationport,
                    Value = item.destinationport
                });
            }
            foreach (Vessel item in vsl)
            {
                vslList.Add(new SelectListItem
                {
                    Text = item.vesselName,
                    Value = item.vesselName
                });
            }
            foreach (SealStatus item in slstat)
            {
                slstatList.Add(new SelectListItem
                {
                    Text = item.sealstatus,
                    Value = item.sealstatus
                });
            }
            ViewBag.DamageList = damageList;
            ViewBag.PooList = pooList;
            ViewBag.PodList = podList;
            ViewBag.VesselList = vslList;
            ViewBag.SealStatList = slstatList;
            ViewBag.EIRINo = "INECV-" + dateTime.Year + "-" + idValue;
            return View("ReturnECV", eirDetails);
        }

        [HttpPost]
        public JsonResult SaveReturnECV(EIRINECV data, int ID)
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            bool status = false;
            try { 
                    var isValidModel = TryUpdateModel(data);
                    if (isValidModel)
                    {
                        db.EIRINECV.Add(data);
                        db.SaveChanges();

                        //Update status in EIR OUT LD

                        var eiroID = db.EIROutLD.Where(s => s.eirldno.Equals(data.eirinecvreferenceno)).Select(s => s.eiroID).Single();
                        var outld = db.EIROutLD.Find(eiroID);
                        db.EIROutLD.Attach(outld);
                        outld.eirldstatus = "Returned";
                        db.Entry(outld).Property("eirldstatus").IsModified = true;
                        db.SaveChanges();

                        //Update status in Bill of Lading

                        var bolID = db.FinalBilling.Where(s => s.transactionNo.Equals(data.eirinecvtransactionno)).Select(s => s.billID).Single();
                        var fb = db.FinalBilling.Find(bolID);
                        db.FinalBilling.Attach(fb);
                        fb.BillStatus = "Returned";
                        db.Entry(fb).Property("BillStatus").IsModified = true;
                        db.SaveChanges();

                        //Update status in Proforma BL

                        var pblID = db.ProformaBills.Where(s => s.proformaBillRefNo.Equals(fb.billingReferenceNo)).Select(s => s.proformaBillID).Single();
                        var pb = db.ProformaBills.Find(pblID);
                        db.ProformaBills.Attach(pb);
                        pb.proformaBillStatus = "Returned";
                        db.Entry(pb).Property("proformaBillStatus").IsModified = true;
                        db.SaveChanges();

                        //Update status in EIR In

                        var eirinID = db.EIRIn.Where(s => s.EIRITransactionNo.Equals(data.eirinecvtransactionno)).Select(s => s.EIRIID).Single();
                        var eirin = db.EIRIn.Find(eirinID);
                        db.EIRIn.Attach(eirin);
                        eirin.EIRIStatus = "Returned";
                        db.Entry(eirin).Property("EIRIStatus").IsModified = true;
                        db.SaveChanges();

                        //Update status in EIR Out

                        var eiroutID = db.EirPullOut.Where(s => s.EIROTransactionNo.Equals(data.eirinecvtransactionno)).Select(s => s.EIROID).Single();
                        var eirout = db.EirPullOut.Find(eiroutID);
                        db.EirPullOut.Attach(eirout);
                        eirout.EIROStatus = "Returned";
                        db.Entry(eirout).Property("EIROStatus").IsModified = true;
                        db.SaveChanges();

                        //Update Canvan Number Status to Open
                        var cns = db.ConVanNo.Where(s => s.convanNo.Equals(data.eirinecvconvanno)).SingleOrDefault();
                        cns.status = "Open";
                        db.SaveChanges();

                        status = true;
                    }
                transaction.Commit();
            }
            catch {
                transaction.Rollback();
            }

            return new JsonResult { Data = new { status = status, eirinno = data.eirinecvno } };
        }

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
                            fname = fl + '.' + f[1]; // file.FileName;
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
    }
}