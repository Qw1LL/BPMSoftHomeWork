namespace BPMSoft.Configuration.ESN
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Core.Factories;
	using BPMSoft.Web.Common.ServiceRouting;
	using Web.Common;

	#region  Class: EsnLikesServiceResponse

	[DataContract]
	public class EsnLikesServiceResponse : ConfigurationServiceResponse
	{
		#region Constructors: Public

		public EsnLikesServiceResponse() { }

		public EsnLikesServiceResponse(Exception exception) : base(exception) { }

		#endregion

		#region Properties: Public

		[DataMember(Name = "likes")]
		public IEnumerable<EsnLikeDTO> EsnLikes { get; set; }

		#endregion
	}

	#endregion

	#region  Class: EsnPostMessageResponse

	[DataContract]
	public class EsnPostMessageResponse : ConfigurationServiceResponse
	{
		#region Constructors: Public

		public EsnPostMessageResponse() { }

		public EsnPostMessageResponse(Exception exception) : base(exception) { }

		#endregion

		#region Properties: Public

		[DataMember(Name = "Id")]
		public Guid Id { get; set; }

		#endregion
	}

	#endregion

	#region  Class: EsnMessagesServiceResponse

	[DataContract]
	public class EsnMessagesServiceResponse : ConfigurationServiceResponse
	{
		public EsnMessagesServiceResponse() { }

		public EsnMessagesServiceResponse(Exception exception) : base(exception) { }

		[DataMember(Name = "EsnMessages")]
		public IEnumerable<EsnReadMessageDTO> EsnMessages { get; set; }

	}

	#endregion

	#region  Class: EsnService

	/// <summary>
	/// Provides API for work with enterprise social network.
	/// </summary>
	[DefaultServiceRoute]
	[SspServiceRoute]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EsnService : BaseService, IReadOnlySessionState
	{
		#region  Fields: Private

		private IEsnCenter _esnCenter;

		#endregion

		#region Properties: Private

		private Guid GetCurrentUserId => UserConnection.CurrentUser.Id;

		private IEsnCenter EsnCenter {
			get {
				if (_esnCenter == null) {
					var centerFactory = ClassFactory.Get<IEsnCenterFactory>();
					_esnCenter = centerFactory.CreateEsnCenter(UserConnection);
				}
				return _esnCenter;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get user likes for messages.
		/// </summary>
		/// <param name="messageIds">Message id collection.</param>
		/// <returns>Instance of <see cref="EsnLikesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnLikesServiceResponse GetMessageLikesForUser(List<Guid> messageIds) {
			EsnLikesServiceResponse result;
			try {
				var likes = EsnCenter.GetMessageLikesForUser(GetCurrentUserId, messageIds);
				result = new EsnLikesServiceResponse {
						EsnLikes = likes
				};
			} catch (Exception e) {
				result = new EsnLikesServiceResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Get collection of users who liked message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="EsnLikesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnLikesServiceResponse GetWhoLikedMessage(Guid messageId) {
			EsnLikesServiceResponse result;
			try {
				var likes = EsnCenter.GetWhoLikedMessage(messageId);
				result = new EsnLikesServiceResponse {
						EsnLikes = likes
				};
			} catch (Exception e) {
				result = new EsnLikesServiceResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Like message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse LikeMessage(Guid messageId) {
			var result = new ConfigurationServiceResponse();
			try {
				EsnCenter.LikeMessage(GetCurrentUserId, messageId);
			} catch (Exception e) {
				result = new ConfigurationServiceResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Remove user like.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UnLikeMessage(Guid messageId) {
			var result = new ConfigurationServiceResponse();
			try {
				EsnCenter.UnLikeMessage(GetCurrentUserId, messageId);
			} catch (Exception e) {
				result = new ConfigurationServiceResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Get comment collection for message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnMessagesServiceResponse ReadComments(Guid schemaUId, Guid entityId, Guid messageId) {
			var result = new EsnMessagesServiceResponse();
			try {
				result.EsnMessages = EsnCenter.ReadComments(schemaUId, entityId, messageId);
			} catch (Exception e) {
				result = new EsnMessagesServiceResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Get message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnMessagesServiceResponse ReadMessage(Guid schemaUId, Guid entityId, Guid messageId) {
			var result = new EsnMessagesServiceResponse();
			try {
				result.EsnMessages = new [] { EsnCenter.ReadMessage(schemaUId, entityId, messageId) };
			} catch (Exception e) {
				result = new EsnMessagesServiceResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Get chunk messages for entity.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="readOptions">Reading options <see cref="EsnReadMessageOptions" />.</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnMessagesServiceResponse ReadEntityMessage(Guid schemaUId, Guid entityId,
				EsnReadMessageOptions readOptions) {
			var result = new EsnMessagesServiceResponse();
			try {
				result.EsnMessages = EsnCenter.ReadEntityMessage(schemaUId, entityId, readOptions);
			} catch (Exception e) {
				result = new EsnMessagesServiceResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Get chunk messages for user feed.
		/// </summary>
		/// <param name="readOptions">Reading options <see cref="EsnReadMessageOptions" />.</param>
		/// <returns>Instance of <see cref="EsnMessagesServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnMessagesServiceResponse ReadFeed(EsnReadMessageOptions readOptions) {
			var result = new EsnMessagesServiceResponse();
			try {
				result.EsnMessages = EsnCenter.ReadFeedMessage(readOptions);
			} catch (Exception e) {
				result = new EsnMessagesServiceResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Post new message.
		/// </summary>
		/// <param name="message">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		/// <returns>Instance of <see cref="EsnPostMessageResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnPostMessageResponse PostMessage(EsnWriteMessageDTO message) {
			var result = new EsnPostMessageResponse();
			try {
				result.Id = EsnCenter.PostMessage(message);
			} catch (Exception e) {
				result = new EsnPostMessageResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Post new comment.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <param name="comment">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		/// <returns>Instance of <see cref="EsnPostMessageResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EsnPostMessageResponse PostComment(Guid messageId, EsnWriteMessageDTO comment) {
			var result = new EsnPostMessageResponse();
			try {
				result.Id = EsnCenter.PostComment(messageId, comment);
			} catch (Exception e) {
				result = new EsnPostMessageResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Edit message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <param name="message">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse EditMessage(Guid messageId, EsnWriteMessageDTO message) {
			var result = new ConfigurationServiceResponse();
			try {
				EsnCenter.EditMessage(messageId, message);
			} catch (Exception e) {
				result = new ConfigurationServiceResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Edit comment.
		/// </summary>
		/// <param name="commentId">Comment id.</param>
		/// <param name="comment">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse EditComment(Guid commentId, EsnWriteMessageDTO comment) {
			var result = new ConfigurationServiceResponse();
			try {
				EsnCenter.EditComment(commentId, comment);
			} catch (Exception e) {
				result = new ConfigurationServiceResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Delete message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteMessage(Guid schemaUId, Guid entityId, Guid messageId) {
			var result = new ConfigurationServiceResponse();
			try {
				EsnCenter.DeleteMessage(schemaUId, entityId, messageId);
			} catch (Exception e) {
				result = new ConfigurationServiceResponse(e);
			}
			return result;
		}

		/// <summary>
		/// Delete comment.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="commentId">Comment id.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse" />.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteComment(Guid schemaUId, Guid entityId, Guid commentId) {
			var result = new ConfigurationServiceResponse();
			try {
				EsnCenter.DeleteComment(schemaUId, entityId, commentId);
			} catch (Exception e) {
				result = new ConfigurationServiceResponse(e);
			}
			return result;
		}

		#endregion
	}

	#endregion
}

