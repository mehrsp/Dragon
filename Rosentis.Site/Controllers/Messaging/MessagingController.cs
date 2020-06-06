using Rosentis.DataContract.Messaging;
using Rosentis.ServiceContract.Messaging;
using Rosentis.Site.Controllers.Base;
using System.Web.Mvc;

namespace Rosentis.Site.Controllers.Messaging
{
	public class MessagingController: ApiController
	{
		//private IMessageService _messageService;
		//public MessagingController(IMessageService messageService)
		//{
		//	_messageService = messageService;
		//}
		//public MessagingController()
		//{
		//}
		//[HttpPost]
		//public ActionResult SendMessage(MessageDto model)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		_messageService.Save(model);
		//		return View();
		//	}
		//	else
		//	{
		//		var message = "";
		//		foreach (ModelState modelState in ViewData.ModelState.Values)
		//		{
		//			foreach (ModelError error in modelState.Errors)
		//			{
		//				message += error.ErrorMessage + ",";
		//			}
		//		}
		//		message = message.TrimEnd(',');
		//		ViewBag.Message = message;
		//		return View();
		//	}
		//}
	}
}