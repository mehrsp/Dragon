//using System;
//using System.Net.Http;
//using System.ServiceModel.Channels;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web;
//using Rosentis.Api.IoCConfig;
//using Rosentis.Persistance.Facade;
//using StackExchange.Redis;

namespace Rosentis.Api.JsonWebTokenConfig
{
    public abstract class MessageHandler 
		
		//: DelegatingHandler
    {
    //    public string ip;
    //    readonly ConnectionMultiplexer _redis;
    //    readonly IDatabase _db;
    //    public LogDto log;


    //    public MessageHandler()
    //    {
    //        _redis = ConnectionMultiplexer.Connect("127.0.0.1");
    //        _db = _redis.GetDatabase();
    //        log = new LogDto();
    //    }


    //    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    //    {
    //        var corrId = string.Format("{0}{1}", DateTime.Now.Ticks, Thread.CurrentThread.ManagedThreadId);
    //        var requestInfo = string.Format("{0} {1}", request.Method, request.RequestUri);

    //        var requestMessage = await request.Content.ReadAsByteArrayAsync();

    //        await IncommingMessageAsync(corrId, requestInfo, requestMessage);

    //        var response = await base.SendAsync(request, cancellationToken);

    //        if (request.Properties.ContainsKey("MS_HttpContext"))
    //        {
    //            ip = ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
    //        }
    //        else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
    //        {
    //            var prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
    //            ip = prop.Address;
    //        }
    //        else if (HttpContext.Current != null)
    //        {
    //            ip = HttpContext.Current.Request.UserHostAddress;
    //        }
    //        else
    //        {
    //            ip = null;
    //        }
    //        var accessToken = request.Headers.Authorization.Parameter;
    //        var userId = _db.StringGet(accessToken + "_userId");
    //        log.UserId = userId;
    //        byte[] responseMessage;

    //        if (response.IsSuccessStatusCode)
    //            responseMessage = await response.Content.ReadAsByteArrayAsync();
    //        else
    //            responseMessage = Encoding.UTF8.GetBytes(response.ReasonPhrase);

    //        await OutgoingMessageAsync(corrId, requestInfo, responseMessage);

    //        return response;
    //    }


    //    protected abstract System.Threading.Tasks.Task IncommingMessageAsync(string correlationId, string requestInfo, byte[] message);
    //    protected abstract System.Threading.Tasks.Task OutgoingMessageAsync(string correlationId, string requestInfo, byte[] message);
    //}



    //public class MessageLoggingHandler : MessageHandler

    //{


    //    protected override async System.Threading.Tasks.Task IncommingMessageAsync(string correlationId, string requestInfo, byte[] message)
    //    {
    //        //await System.Threading.Tasks.Task.Run(() =>
    //        //    Debug.WriteLine(string.Format("{0} - Request: {1}\r\n{2}", correlationId, requestInfo, Encoding.UTF8.GetString(message))));
    //        //log.RequestAddress = requestInfo;
    //        //log.RequestValue = Encoding.UTF8.GetString(message);
    //        LoggerProxy.Log(LoggerProxy.LogLevels.Trace, GetType(), "no");
    //    }


    //    protected override async System.Threading.Tasks.Task OutgoingMessageAsync(string correlationId, string requestInfo, byte[] message)
    //    {
    //        //await System.Threading.Tasks.Task.Run(() =>
    //        //    Debug.WriteLine(string.Format("{0} - Response: {1}\r\n{2}", correlationId, requestInfo, Encoding.UTF8.GetString(message))));
    //        //log.ResponseValue = Encoding.UTF8.GetString(message);
    //        //log.RequestIp = ip;

    //        var d = new LogHistory();
    //        d.Save(log);

    //    }


    //}

    //public class LogHistory
    //{


    //    public void Save(LogDto log)
    //    {
    //        var container = SmObjectFactory.Container;

    //        var c = container.GetInstance<IUnitOfWork>();
    //        var datacontext = container.GetInstance<RosentisContext>();

    //        //   var logEntity=new Log(log.Id,log.UserId,log.RequestIp,log.RequestAddress,log.RequestValue,log.ResponseValue,DateTime.Now);
    //        // var log1 = datacontext.Add(logEntity);
    //        datacontext.SaveChanges();

    //    }
    }
}