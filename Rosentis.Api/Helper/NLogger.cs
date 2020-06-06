using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Text;
using System.Web.Http.Tracing;
using NLog;
using StackExchange.Redis;
using System.Web;
using Rosentis.Api.ErrorHelper;

namespace Rosentis.Api.Helpers
{
    public sealed class NLogger : ITraceWriter
	{
		private IDatabase _db;
		public NLogger()
		{
			var _redis = ConnectionMultiplexer.Connect("127.0.0.1");
			_db = _redis.GetDatabase();
		}
		#region Private member variables.
		private static readonly Logger ClassLogger = LogManager.GetCurrentClassLogger();

		private static readonly Lazy<Dictionary<TraceLevel, Action<string>>> LoggingMap = new Lazy<Dictionary<TraceLevel, Action<string>>>(() => new Dictionary<TraceLevel, Action<string>> { { TraceLevel.Info, ClassLogger.Info }, { TraceLevel.Debug, ClassLogger.Debug }, { TraceLevel.Error, ClassLogger.Error }, { TraceLevel.Fatal, ClassLogger.Fatal }, { TraceLevel.Warn, ClassLogger.Warn } });
		#endregion

		#region Private properties.
		/// <summary>
		/// Get property for Logger
		/// </summary>
		private Dictionary<TraceLevel, Action<string>> Logger
		{
			get { return LoggingMap.Value; }
		}
		#endregion

		#region Public member methods.
		/// <summary>
		/// Implementation of TraceWriter to trace the logs.
		/// </summary>
		/// <param name="request"></param>
		/// <param name="category"></param>
		/// <param name="level"></param>
		/// <param name="traceAction"></param>
		public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
		{
			string bearerToken = "";
			string Ip = "";
			var userId = "";
			var token = "";

			if (request != null)
			{
				if (request.Headers.Contains("Authorization"))
					bearerToken = request.Headers.GetValues("Authorization").FirstOrDefault();
				if (!string.IsNullOrWhiteSpace(bearerToken))
					token = bearerToken.Substring(7, bearerToken.Length - 7);

				userId = _db.StringGet(token + "_userId");
				Ip = GetClientIp(request);
			}


			if (level != TraceLevel.Off)
			{
				if (traceAction != null && traceAction.Target != null)
				{
					category = category + "|" + "Action Parameters : " + traceAction.Target.ToJSON() + "|IpAddress:" + Ip + "|UserId:" + userId;
				}
				var record = new TraceRecord(request, category, level);
				if (traceAction != null) traceAction(record);
				Log(record);
			}
		}
		#endregion

		#region Private member methods.
		/// <summary>
		/// Logs info/Error to Log file
		/// </summary>
		/// <param name="record"></param>
		private void Log(TraceRecord record)
		{
			var message = new StringBuilder();

			if (!string.IsNullOrWhiteSpace(record.Message))
				message.Append("").Append(record.Message + "|");

			if (record.Request != null)
			{
				if (record.Request.Method != null)
					message.Append("Method: " + record.Request.Method + "|");

				if (record.Request.RequestUri != null)
					message.Append("").Append("URL: " + record.Request.RequestUri + "|");

				if (record.Request.Headers != null && record.Request.Headers.Contains("Token") && record.Request.Headers.GetValues("Token") != null && record.Request.Headers.GetValues("Token").FirstOrDefault() != null)
					message.Append("").Append("Token: " + record.Request.Headers.GetValues("Token").FirstOrDefault() + "|");
			}

			if (!string.IsNullOrWhiteSpace(record.Category))
				message.Append("").Append(record.Category);

			if (!string.IsNullOrWhiteSpace(record.Operator))
				message.Append(" ").Append(record.Operator).Append(" ").Append(record.Operation);

			if (record.Exception != null && !string.IsNullOrWhiteSpace(record.Exception.GetBaseException().Message))
			{
				var exceptionType = record.Exception.GetType();
				message.Append("|");
				if (exceptionType == typeof(ApiException))
				{
					var exception = record.Exception as ApiException;
					if (exception != null)
					{
						message.Append("").Append("Error: " + exception.ErrorDescription + "|");
						message.Append("").Append("Error Code: " + exception.ErrorCode + "|");
					}
				}
				else if (exceptionType == typeof(ApiBusinessException))
				{
					var exception = record.Exception as ApiBusinessException;
					if (exception != null)
					{
						message.Append("").Append("Error: " + exception.ErrorDescription + "|");
						message.Append("").Append("Error Code: " + exception.ErrorCode + "|");
					}
				}
				else if (exceptionType == typeof(ApiDataException))
				{
					var exception = record.Exception as ApiDataException;
					if (exception != null)
					{
						message.Append("").Append("Error: " + exception.ErrorDescription + "|");
						message.Append("").Append("Error Code: " + exception.ErrorCode + "|");
					}
				}
				else
					message.Append("").Append("Error: " + record.Exception.GetBaseException().Message + "|");
			}

			Logger[record.Level](Convert.ToString(message) + Environment.NewLine);
		}
		#endregion
		private string GetClientIp(HttpRequestMessage request)
		{
			if (request.Properties.ContainsKey("MS_HttpContext"))
			{
				return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
			}

			if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
			{
				RemoteEndpointMessageProperty prop;
				prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
				return prop.Address;
			}

			return null;
		}
	}
}