namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using Newtonsoft.Json;
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web;
	using BPMSoft.Core;
	using BPMSoft.Web.Common.ServiceRouting;
#if NETSTANDARD2_0
	using TS = BPMSoft.Web.Http.Abstractions;
#endif
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class OmnichannelOutcomeMessagingService : OmnichannelMessagingService
	{

		#region Constants: Private 

		private const string OmnichannelMessageSendErrorMetricName = "omnichannel_messaging_message_send_error_count";

		#endregion

		#region Constructors: Public

		public OmnichannelOutcomeMessagingService(UserConnection userConnection) : base(userConnection) {
		}

		public OmnichannelOutcomeMessagingService() : base() {
		}

		#endregion

		#region Methods: Private

		private void SaveFile(MessageAttachment attachment) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("OmnichannelMessageFile");
			var entity = entitySchema.CreateEntity(UserConnection);
			entity.SetColumnValue("Id", attachment.FileId);
			entity.SetColumnValue("MessageId", attachment.MessageId);
			entity.SetColumnValue("Name", attachment.FileName);
			entity.SetColumnValue("TypeId", Guid.Parse("529BC2F8-0EE0-DF11-971B-001D60E938C6"));
			entity.SetColumnValue("Size", attachment.Content.Length);
			entity.SetStreamValue("Data", attachment.Content);
			entity.Save(false);
			attachment.Content.Dispose();
		}

#if NETSTANDARD2_0
		private TS.HttpRequest GetRequest() {
			return HttpContextAccessor.GetInstance().Request;
		}
#else
		private HttpRequestWrapper GetRequest() {
			return new HttpRequestWrapper(System.Web.HttpContext.Current.Request);
		}
#endif
		private MessagingMessage AddAttachments(MessagingMessage message) {
			message.Attachments = new List<MessageAttachment>();
			var request = GetRequest();
			var files = request.Files;
#if NETSTANDARD2_0
			foreach (string fileKey in files.AllKeys) {
				TS.HttpPostedFile file = files[fileKey];
#else
			foreach (string fileKey in files) {
				HttpPostedFileBase file = files[fileKey];
#endif
				MessageType fileType = Enum.TryParse(file.ContentType.Split('/')[0], true, out fileType) && fileType != MessageType.Text
					? fileType
					: MessageType.File;
				message.MessageType = fileType;
				MemoryStream ms = new MemoryStream();
				file.InputStream.CopyTo(ms);
				var attachment = new MessageAttachment {
					FileId = Guid.NewGuid().ToString(),
					FileName = file.FileName,
					MimeType = file.ContentType,
					FileType = fileType,
					Content = ms
				};
				message.Attachments.Add(attachment);
			}
			return message;
		}

		private long GetCurrentTime() {
			return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
		}

		private OmnichannelMessagingServiceResponse SendAndClearTextMessage(MessagingMessage message) {
			var response = SendMessage(message);
			message.Message = string.Empty;
			return response;
		}

		private void SaveAttachments(MessagingMessage message) {
			message.Attachments.ForEach((att) => {
				att.MessageId = message.Id;
				SaveFile(att);
			});
		}

		private bool IsError(string response) {
			return response.Contains("error");
		}

		private OmnichannelMessagingMessageMetric GetMetric() {
			return new OmnichannelMessagingMessageMetric {
				Direction = OmnichannelProviders.Domain.Entities.MessageDirection.Outcoming
			};
		}

		#endregion


		#region Methods: Public

		/// <summary>
		/// Sends message to integration api.
		/// </summary>
		/// <param name="message">Unified messaging message.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public OmnichannelMessagingServiceResponse SendMessage(MessagingMessage message) {
			message.IsStandBy = false;
			var response = new OmnichannelMessagingServiceResponse();
			message.Timestamp = GetCurrentTime();
			Stopwatch stopWatch = new Stopwatch();
			var metric = GetMetric();
			try {
				stopWatch.Start();
				var result = InternalSend(message);
				stopWatch.Stop();
				metric.Duration = stopWatch.ElapsedMilliseconds;
				metric.Size = message.GetSize();
				if (IsError(result)) {
					response = GetSendingError(message.Source, result);
					Log.InfoFormat("Error while sending the message to contact {0} in chat {1}: {2}",
						message.ContactId, message.ChatId, result);
					metric.ErrorType = MessageSendingError.Messenger;
				} else {
					response.Success = true;
				}
			} catch (Exception e) {
				stopWatch.Stop();
				metric.Duration = stopWatch.ElapsedMilliseconds;
				metric.ErrorType = MessageSendingError.Internal;
				response = GetSendingError();
				Log.ErrorFormat("Error while sending the message. Error info: {0}", e.Message);
			}
			MetricReporter.Report(metric);
			if (!response.Success) {
				MetricReporter.Gauge(OmnichannelMessageSendErrorMetricName, 1);
			}
			return response;
		}

		/// <summary>
		/// Sends message with attachments.
		/// </summary>
		/// <param name="message">Unified messaging message.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public OmnichannelMessagingServiceResponse SendMessageWithAttachments() {
			var response = new OmnichannelMessagingServiceResponse();
			MessagingMessage message = JsonConvert.DeserializeObject<MessagingMessage>(GetRequest().Form["message"]);
			message.Id = Guid.NewGuid();
			message.Timestamp = GetCurrentTime();
			Stopwatch stopWatch = new Stopwatch();
			var metric = GetMetric();
			try {
				if (message.Message.Length > 0) {
					response = SendAndClearTextMessage(message);
					if (!response.Success) {
						return response;
					}
				}
				stopWatch.Start();
				AddAttachments(message);
				metric.Type = message.MessageType;
				message.Id = Guid.NewGuid();
				message.ChatId = ChatRepository.AddMessage(message, out bool isNewChat).ToString();
				var result = MessageManager.Send(message, message.ChannelName);
				stopWatch.Stop();
				metric.Duration = stopWatch.ElapsedMilliseconds;
				metric.Size = message.GetSize();
				if (!IsError(result)) {
					SaveAttachments(message);
					OperatorNotifier.NewConversationMessageNotify(message as UnifiedMessage);
				} else {
					metric.ErrorType = MessageSendingError.Messenger;
					response = GetSendingError(message.Source, result);
					Log.InfoFormat("Error while sending the message with attachments to contact {0} in chat {1}: {2}",
						message.ContactId, message.ChatId, result);
				}
			} catch (Exception e) {
				stopWatch.Stop();
				metric.Duration = stopWatch.ElapsedMilliseconds;
				metric.ErrorType = MessageSendingError.Internal;
				metric.Type = message.MessageType;
				response = GetSendingError();
				Log.ErrorFormat("Error while sending the message with attachments. Error info: {0}", e.Message);
			}
			MetricReporter.Report(metric);
			if (!response.Success) {
				MetricReporter.Gauge(OmnichannelMessageSendErrorMetricName, 1);
			}
			return response;
		}

		#endregion

	}
}
