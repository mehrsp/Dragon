using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Shop;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.ServiceContract.Shop;
using Rosentis.Site.Jwt;

namespace Rosentis.Site.Controllers
{
    public class OrdersController : ApiController
    {
        //private IInvoiceApplicationService _invoiceApplicationService;

        //private IInvoiceDetailsApplicationService _invoiceDetailsApplicationService;
        //private IUsersApplicationService _iuserApplicationService;

        //public OrdersController(IInvoiceApplicationService invoiceApplicationService, IInvoiceDetailsApplicationService invoiceDetailsApplicationService, IUsersApplicationService iuserApplicationService)
        //{
        //    _invoiceApplicationService = invoiceApplicationService;
        //    _invoiceDetailsApplicationService = invoiceDetailsApplicationService;
        //    _iuserApplicationService = iuserApplicationService;
        //}

        //// GET: Order
        ////[JwtAuthorize]
        ////public ActionResult Index()
        ////{
        ////    var items = new InvoiceDtos();
        ////    items.Invoices = _invoiceApplicationService.FindAll(x => x.UserId == UserId).OrderByDescending(x => x.CreatedDate).ToList();
        ////    return View(items.Invoices);
        ////}

        ////public ActionResult Invoice(string id)
        ////{
        ////    var model = _invoiceApplicationService.Find(Guid.Parse(id));
        ////    Criteria criteria = new EqualCriteria
        ////    {
        ////        ObjectType = typeof(string),
        ////        FirstOprand = "InvoiceId",
        ////        SecondOperand = model.Id.ToString()
        ////    };
        ////    model.InvoiceDetails = _invoiceDetailsApplicationService.FindAll(criteria,new List<SortItem>(){new SortItem(){SortFiledsSelector = "CreatedDate",Direction = SortDirection.Descending}});
        ////    return View(model);
        ////}
    }
}