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
using CrystalDecisions.Shared; 
using Omu.AwesomeMvc;

namespace AdminLteMvc.Controllers
{
    public class ProformaController : Controller
    {
        private ContextModel db = new ContextModel();
        // GET: Proforma
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Billing()
        {
            loadable();

            List<EirPullOut> EirOut = db.EirPullOut.Where(s=>s.EIROStatus == "Pull-Out").ToList();
            ViewBag.ReferenceNos = new SelectList(EirOut, "EIRONo", "EIRONo");

            var dateTime = DateTime.Now;

            //List<string> ids = new List<string>();
            //var getNoOfBills = db.ProformaBills.AsEnumerable().Select(r => r.proformaBillNo).ToList();
            //var idValue = "";
            //if (getNoOfBills.Count() >= 1)
            //{
            //    List<int> idList = new List<int>();
            //    foreach (var a in getNoOfBills)
            //    {
            //        string eirno = a.Substring(9);
            //        idList.Add(Int32.Parse(eirno));
            //    }
            //    int[] IDS = idList.ToArray();
            //    var biggestID = IDS.Max() + 1;
            //    idValue = biggestID.ToString();
            //}
            //else
            //{
            //    idValue = "10001";
            //}
            //ViewBag.ProformaNo = "PBL-" + dateTime.Year + "-" + idValue;


            //new update proforma bill number should be editable and mandatory
            //ViewBag.ProformaNo = "test";
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
            return View();
        }
        public JsonResult GetVesselNo(int vesselID)
        {
            List<VoyageNo> VoyageNoList = db.VoyageNo.Where(s => s.vesselid.Equals(vesselID.ToString())).ToList();
            return Json(VoyageNoList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBills(GridParams g, string search)
        {
            var list = db.Database.SqlQuery<Models.Class.proformaBill>("select * from proformaBILL where dataFeild like'%" + search + "%'");
            return Json(new GridModelBuilder<Models.Class.proformaBill>(list.AsQueryable(), g)
            {
                KeyProp = o => o.proformaBillID,// needed for Entity Framework | nesting | tree | api
                Map = o => new
                {
                    o.proformaBillID,
                    o.outID,
                    o.proformaBillStatus,
                    o.proformaBillNo,
                    o.proformaBillDate,
                    o.proformaBillVesselName,
                    o.proformaBillVoyageNo,
                    o.proformaBillDestination,
                    o.proformaBillShipper,
                    o.proformaBillShippersAddress,
                    o.proformaBillShippersTelNo,
                    o.proformaBillServiceType,
                    o.proformaBillConsignee,
                    o.proformaBillConsigneesAddress,
                    o.proformaBillConsigneesTelNo,
                    o.proformaBillMarks,
                    o.proformaBillQty,
                    o.proformaBillUnit,
                    o.proformaBillDescriptionOfCargo,
                    o.proformaBillValue,
                    o.proformaBillWeight,
                    o.proformaBillMeasurement,
                    o.proformaBillRemarks,
                    o.proformaBillMeasuredBy,
                    o.proformaBillTruckersName,
                    o.proformaBillShippersName
                }
            }.Build());
        }

        [HttpGet]
        public ActionResult GetDetails(string refno)
        {
            var getEIR = db.EirPullOut.Where(s => s.EIRONo.Equals(refno)).Single();
            var getbkno = db.ATW.Where(s=>s.atwBkNo.Equals(getEIR.EIROAtwBkNo)).Select(s=>s.bkNo).Single();
            var bkdtls = db.Booking.Where(s=>s.docNum.Equals(getbkno)).Single();
            var trndetails = db.TransactionDetails.Where(s=>s.docNumber.Equals(getbkno)).SingleOrDefault();
            //var ctel = db.TransactionDetails.Where(s => s.docNumber.Equals(getbkno)).Select(s => s.consigneetelno).First();

            var VesselName = getEIR.vesselID;
            var VoyageNo = getEIR.voyageID;
            var VoyageNoText = getEIR.EIROVoyageNo;
            var Destination = getEIR.EIROPortOfDestination;
            var Shipper = getEIR.EIROShipper;
            var ShippersAddress = bkdtls.shipperAddress;
            var ShippersTelNo = bkdtls.shipperTelNo;
            var ServiceType = getEIR.EIROServiceType;
            var Consignee = getEIR.EIROConsignee;
            //var ConsigneeAddress = trndetails.consigneeAdd;
            //var ConsigneeTelNo = trndetails.consigneetelno;
            //var Quantity = trndetails.quantity;
            //var Unit = trndetails.unitofmeasurement;
            //var Price = trndetails.price;
            var Trucker = getEIR.EIROTrucker;

            var result = new {
                ven = VesselName,
                von = VoyageNo,
                vonText = VoyageNoText,
                des = Destination, 
                shpr = Shipper, 
                shpra = ShippersAddress, 
                shprtel = ShippersTelNo,
                st = ServiceType,
                con = Consignee,
                //cona = ConsigneeAddress,
                //cont = ConsigneeTelNo,
                trucker = Trucker,
                //qty = Quantity,
                //unit = Unit,
                //price = Price
            };

            var Vessel = db.Vessel.ToList();
            List<SelectListItem> vessellist = new List<SelectListItem>();
            vessellist.Clear();
            vessellist.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (Vessel v in Vessel)
            {
                vessellist.Add(new SelectListItem
                {
                    Text = v.vesselName.Trim(),
                    Value = v.vesselName.Trim()
                });
            }
            ViewBag.vessellist = vessellist;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveBill(Models.Class.saveProforma bill)
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            bool status = false;
            var chk = db.ProformaBills.Where(a => a.proformaBillNo == bill.datParent.proformaBillNo).ToList();
            if (chk.Count == 0)
            {
                try
                {
                    var outeir = db.EirPullOut.Where(s => s.EIRONo.Equals(bill.datParent.proformaBillRefNo)).Single();
                    var eirpull = db.EirPullOut.Find(outeir.EIROID);
                    db.EirPullOut.Attach(eirpull);
                    eirpull.EIROStatus = "Proforma";
                    db.Entry(eirpull).Property("EIROStatus").IsModified = true;
                    db.SaveChanges();


                    var voyNo = db.VoyageNo.Where(a => a.transactionNumber == outeir.EIROTransactionNo).ToList();
                    if (voyNo.Count > 0)
                    {
                        if (voyNo.SingleOrDefault().voyageID != bill.datParent.proformaBillVoyageID)
                        {
                            var updateVoyageNo = voyNo.SingleOrDefault();
                            updateVoyageNo.status = "Open";
                            updateVoyageNo.transactionNumber = "-";
                            db.SaveChanges();

                            var updateSelectedVoyageNo = db.VoyageNo.Where(a => a.voyageID == bill.datParent.proformaBillVoyageID).First();
                            updateSelectedVoyageNo.status = "Closed";
                            updateSelectedVoyageNo.transactionNumber = outeir.EIROTransactionNo;
                            db.SaveChanges();

                        }
                    }


                    var isValidModel = TryUpdateModel(bill);
                    if (isValidModel)
                    {
                        //save data to proformabills table
                        ProformaBills pb = db.ProformaBills.Add(bill.datParent);
                        pb.proformaBillStatus = "Pending";
                        var ret = db.ProformaBills.Add(pb);
                        db.SaveChanges();

                        //saving multiple item 
                        foreach (ProformaBillsItems PBI in bill.data)
                        {
                            ProformaBillsItems PBI_save = new ProformaBillsItems();
                            PBI_save.proformaBillID = ret.proformaBillID;
                            PBI_save.marks = PBI.marks;
                            PBI_save.quantity = PBI.quantity;
                            PBI_save.unit = PBI.unit;
                            PBI_save.description = PBI.description;
                            db.ProformaBillsItems.Add(PBI_save);
                            db.SaveChanges();
                        }
                        status = true;
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            else
            {
                transaction.Rollback();
            }
          
          
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult ViewBill(int ID)
        {
            var billinfo = db.ProformaBills.Find(ID);
            return View("ViewBill", billinfo);
        }
        public ActionResult ViewBillDetails(string billNo)
        {
            ViewBag.BillNo = billNo;
            return View("ViewBillDetails");
        }
        public FileResult DisplayProformaBOLReport(string billNo)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            ReportDocument rd = new ReportDocument();
            //rd.Load("D:/Integration File/Kargamine 4162021/UPDATED/AdminLteMvc-master/AdminLteMvc/AdminLteMvc/Report_Documents/ProformaBillOfLading.rpt");
            //rd.Load(directory + "/Report_Documents/ProformaBillOfLading.rpt");
            rd.Load(Path.Combine(Server.MapPath(@"~/Report_Documents/ProformaBillOfLading.rpt")));
            string query = String.Format("exec SP_BillOfLadingReportByBillNo '{0}'", billNo.Trim());
            var list = db.Database.SqlQuery<Reports_VM.ProformaVm>(query).ToList();

            if (list.Count > 0)
            {
                rd.SetDataSource(list);
                rd.SetParameterValue(0, billNo);

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


        public void loadable()
        {
         
            var org = db.Origin.ToList();
            var dest = db.Destination.ToList();
            var dbCon = db.Consignee.ToList();
          
            var dbServ = db.ServiceType.ToList();
            var dbCargo = db.CargoType.ToList();
       
            var dbEPO = db.CYEPO.ToList();
            var dbSA = db.CYSA.ToList();
            var dbLD = db.CYLD.ToList();
            var dbpm = db.PaymentMode.ToList();
            var bktype = db.BookingType.ToList();

            
            //string query = "select a.vesselMnemonic+'-'+b.voyageNo vesselvoyage,b.voyageID from Vessels a " +
            //"inner join VoyageNoes b on a.vesselID = b.vesselid where b.status='Open' and b.transactionNumber='-'";
            //var vessel = db.Database.SqlQuery<Models.Class.dataPopulation>(query);

            List <SelectListItem> prList = new List<SelectListItem>();
            prList.Clear();
            List<SelectListItem> orgList = new List<SelectListItem>();
            orgList.Clear();
            List<SelectListItem> destList = new List<SelectListItem>();
            destList.Clear();
            List<SelectListItem> dbConList = new List<SelectListItem>();
            dbConList.Clear();


            List<SelectListItem> dbChargeList = new List<SelectListItem>();
            dbConList.Clear();
            List<SelectListItem> dbServList = new List<SelectListItem>();
            dbServList.Clear();
            List<SelectListItem> dbCargoList = new List<SelectListItem>();
            dbCargoList.Clear();
            dbCargoList.Add(new SelectListItem { Text="Select",Value="0"});
            List<SelectListItem> dbContainerList = new List<SelectListItem>();
            dbContainerList.Clear();
            List<SelectListItem> dbConRequirementsList = new List<SelectListItem>();
            dbConRequirementsList.Clear();
            List<SelectListItem> dbEPOList = new List<SelectListItem>();
            dbEPOList.Clear();
            List<SelectListItem> dbSAList = new List<SelectListItem>();
            dbSAList.Clear();
            List<SelectListItem> dbLDList = new List<SelectListItem>();
            dbLDList.Clear();
            List<SelectListItem> paymentList = new List<SelectListItem>();
            paymentList.Clear();
            List<SelectListItem> bktypeList = new List<SelectListItem>();
            bktypeList.Clear();
            List<SelectListItem> chargeeList = new List<SelectListItem>();
            chargeeList.Clear();

            //List<SelectListItem> vesselList = new List<SelectListItem>();
            //vesselList.Clear();



            //foreach (Models.Class.dataPopulation item in vessel)
            //{
            //    vesselList.Add(new SelectListItem
            //    {
            //        Text = item.vesselvoyage,
            //        Value = item.voyageID.ToString()
            //    });
            //}

            foreach (PaymentMode item in dbpm)
            {
                paymentList.Add(new SelectListItem
                {
                    Text = item.paymentmode,
                    Value = item.paymentmode
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
            dbConList.Add(new SelectListItem
            {
                Text = "Select",
                Value = "Select"
            });
            foreach (Consignee item in dbCon)
            {
                dbConList.Add(new SelectListItem
                {
                    Text = item.consignee,
                    Value = item.consignee
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
            ViewBag.chargeeList = chargeeList;
            //ViewBag.vesselList = vesselList;


            
            List<SelectListItem> portorigin = new List<SelectListItem>();
            var poo=db.PortOfOrigin.ToList();
            portorigin.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (PortOfOrigin item in poo)
            {
                portorigin.Add(new SelectListItem { Text = item.originport, Value =item.originport});
            }
            ViewBag.portorigin = portorigin;


            List<SelectListItem> portdestList = new List<SelectListItem>();
            var pod = db.PortOfDestination.ToList();
            portdestList.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (PortOfDestination item in pod)
            {
                portdestList.Add(new SelectListItem { Text = item.destinationport, Value = item.destinationport });
            }
            ViewBag.portdestList = portdestList;

            //relay port
            List<SelectListItem> cyepo = new List<SelectListItem>();
            var rp = db.CYEPO.ToList();
            cyepo.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (CYEPO item in rp)
            {
                cyepo.Add(new SelectListItem { Text = item.cyEpo, Value = item.cyEpo });
            }
            ViewBag.cyepo = cyepo;

            //EIR IN transaction
            List<SelectListItem> eirin = new List<SelectListItem>();
            var en = db.EIRIn.Where(x=>x.EIRIStatus=="In").ToList();
            eirin.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (EIRIn item in en)
            {
                eirin.Add(new SelectListItem { Text = item.EIRINo, Value = item.EIRIID.ToString() });
            }
            ViewBag.eirin = eirin;

            //EIR IN transaction
            List<SelectListItem> unit = new List<SelectListItem>();
            var un = db.UnitCases.Where(a => a.status == "Active").ToList();
            unit.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (UnitCases item in un)
            {
                unit.Add(new SelectListItem { Text = item.description, Value = item.description.ToString() });
            }
            ViewBag.unit = unit;

            //EIR IN transaction
            List<SelectListItem> packedASS = new List<SelectListItem>();
            var PS = db.packedAs.Where(a => a.status == "Active").ToList();
            packedASS.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (packedAs item in PS)
            {
                packedASS.Add(new SelectListItem { Text = item.description, Value = item.description.ToString() });
            }
            ViewBag.packedASS = packedASS;



        }
        public ActionResult BillofLading()
        {
            loadable();
            return View();
        }

        [HttpPost]
        public ActionResult pulledbillladingdata(string refno)
        {
            
            var list = db.Database.SqlQuery<Models.Class.billoflading_pulled_data>("select * from billoflading_pulled_data where EIRIID ='" + refno + "'");
            return new JsonResult { Data = new { parent = list } };
        }
        public ActionResult selectvesselvoyage(int refno)
        {
            string query = "select a.vesselMnemonic+'-'+b.voyageNo vesselvoyage,b.voyageID,b.status from Vessels a " +
                            "inner join VoyageNoes b on a.vesselID = b.vesselid ";
            var list = db.Database.SqlQuery<Models.Class.dataPopulation>(query);
            return Json(list, JsonRequestBehavior.AllowGet);
            //return new JsonResult { Data = new { parent = list } };
        }
        public ActionResult getVesselVoyage(int refno)
        {
            string query = "select a.vesselName, b.voyageNo,b.voyageID,b.status from Vessels a " +
                            "inner join VoyageNoes b on a.vesselID = b.vesselid where b.voyageID="+refno+" ";
            var list = db.Database.SqlQuery<Models.Class.dataPopulation>(query);
            
            return new JsonResult { Data = new { parent = list } };
        }
        public ActionResult getVoyageLeg(int refno)
        {
            string query = "select voyageID,category,portOrigin from VoyageNoCategories where voyageID=" + refno + " group by voyageID,category,portOrigin ";
            var list = db.Database.SqlQuery<Models.Class.dataPopulation>(query);
            return Json(list, JsonRequestBehavior.AllowGet);
            //return new JsonResult { Data = new { parent = list } };
        }
        [HttpPost]
        public ActionResult getVoyageLegCategory(string refno, string category)
        {
            string query = "select voyageID,category,portOrigin,portDestination from VoyageNoCategories where voyageID="+refno+" and category='"+ category + "' and (portOrigin is not null or portDestination is not null)";
            var list = db.Database.SqlQuery<Models.Class.dataPopulation> (query);
            var portOrigin = list.First();
            return new JsonResult { Data = new { parent = list, portOrigin= portOrigin.portOrigin } };
        }

        public JsonResult saveFinalBill(Models.Class.saveBilloflading bill)
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            Boolean status = false;
            string err_msg = "";
            var checkData = db.FinalBilling.Where(x => x.billofladingNo == bill.datParent.billofladingNo && x.BillStatus == "Active").FirstOrDefault();
            var eirin = db.EIRIn.Where(x => x.EIRIID == bill.datParent.eirinID).SingleOrDefault();
            if (checkData != null)
            {
                err_msg = "Exist";
            }
            else
            {
                try
                {
                    string userid = "1";
                    var fb = db.FinalBilling.Add(bill.datParent);
                    fb.issuedby = "Admin";
                    fb.placeIssued = "Main Office";
                    fb.userID = int.Parse(userid);
                    fb.dateIssued = DateTime.Now;
                    fb.BillStatus = "Billed";
                    fb.billingReferenceNo = eirin.EIRIReferenceNo;
                    var ret = db.FinalBilling.Add(fb);
                    db.SaveChanges();
                    int parenetID = ret.billID;
                  
                    foreach (FinalBillingItem item in bill.data)
                    {
                        var fbi = new FinalBillingItem();
                        fbi.billID = parenetID;
                        fbi.mark = item.mark;
                        fbi.qty = item.qty;
                        fbi.unit = item.unit;
                        fbi.description = item.description;
                        fbi.value = item.value;
                        fbi.weight = item.weight;
                        fbi.measurement = item.measurement;
                        fbi.status = "Active";
                        db.FinalBillingItem.Add(fbi);
                        db.SaveChanges();
                    }
                    transaction.Commit();
                    status = true;
                    err_msg = "save";


                    var outEmpty = db.EirPullOut.Where(a=>a.EIRONo == eirin.EIRIReferenceNo).FirstOrDefault();
                    outEmpty.EIROStatus = "Billed";
                    db.SaveChanges();

                    var proformaBL = db.ProformaBills.Where(a => a.proformaBillRefNo == eirin.EIRIReferenceNo).FirstOrDefault();
                    proformaBL.proformaBillStatus = "Billed";
                    db.SaveChanges();

                    var infull = db.EIRIn.Where(a => a.EIRIReferenceNo == eirin.EIRIReferenceNo).FirstOrDefault();
                    infull.EIRIStatus = "Billed";
                    db.SaveChanges();

                    var EIROUT = db.EirPullOut.Where(a => a.EIRONo == eirin.EIRIReferenceNo).Single();

                    var voyNo = db.VoyageNo.Where(a => a.transactionNumber == EIROUT.EIROTransactionNo).ToList();
                    if (voyNo.Count > 0)
                    {
                        if (voyNo.SingleOrDefault().voyageID != bill.datParent.voyageID)
                        {
                            var updateVoyageNo = voyNo.SingleOrDefault();
                            updateVoyageNo.status = "Open";
                            updateVoyageNo.transactionNumber = "-";
                            db.SaveChanges();

                            var updateSelectedVoyageNo = db.VoyageNo.Where(a => a.voyageID == bill.datParent.voyageID).First();
                            updateSelectedVoyageNo.status = "Closed";
                            updateSelectedVoyageNo.transactionNumber = EIROUT.EIROTransactionNo;
                            db.SaveChanges();

                        }
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            return new JsonResult { Data = new { status = status, errmsg = err_msg } };
        }


    }
}