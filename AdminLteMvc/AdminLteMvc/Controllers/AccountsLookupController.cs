using AdminLteMvc.Models;
using Omu.AwesomeMvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLteMvc.Controllers
{
    public class AccountsLookupController : Controller
    {
        private ContextModel db = new ContextModel();
        // GET: ItemLookup
        public ActionResult GetItem(string v)
        {
            var o = db.GLAccounts.SingleOrDefault(f => f.AcctCode == v) ?? new Models.WEBSales.GLAccount();

            return Json(new KeyContent(o.AcctCode, o.AcctName));
        }

        public ActionResult Search(string search, int page)
        {
            search = (search ?? "").ToLower().Trim();
            var list = db.GLAccounts.Where(f => f.AcctName.ToLower().Contains(search)).OrderBy(o => o.AcctCode).ToList();
            return Json(new AjaxListResult
            {
                Items = list.Skip((page - 1) * 100).Take(100).Select(o => new KeyContent(o.AcctCode, o.AcctName)),
                More = list.Count() > page * 100
            });
        }
    }
}