namespace BPMSoft.Configuration.ESN
{
	using System;
	using System.Collections.Generic;

	#region  Interface: IEsnCenter

	/// <summary>
	/// Provides methods for work with enterprise social network.
	/// </summary>
	public interface IEsnCenter
	{
		/// <summary>
		/// Get user likes for messages.
		/// </summary>
		/// <param name="userId">User id.</param>
		/// <param name="messageIds">Message id collection.</param>
		/// <returns></returns>
		IEnumerable<EsnLikeDTO> GetMessageLikesForUser(Guid userId,
				IEnumerable<Guid> messageIds);

		/// <summary>
		/// Like message.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="messageId">Message id.</param>
		/// <returns></returns>
		Guid LikeMessage(Guid userId, Guid messageId);

		/// <summary>
		/// Remove user like.
		/// </summary>
		/// <param name="userId">User id.</param>
		/// <param name="messageId">Message id.</param>
		/// <returns></returns>
		bool UnLikeMessage(Guid userId, Guid messageId);

		/// <summary>
		/// Get collection of users who liked message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <returns></returns>
		IEnumerable<EsnLikeDTO> GetWhoLikedMessage(Guid messageId);

		/// <summary>
		/// Get comment collection for message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
		/// <returns>Collection of message DTO <see cref="EsnReadMessageDTO" />.</returns>
		IEnumerable<EsnReadMessageDTO> ReadComments(Guid schemaUId, Guid entityId, Guid messageId);

		/// <summary>
		/// Get message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
		/// <returns><see cref="EsnReadMessageDTO"/>instance.</returns>
		EsnReadMessageDTO ReadMessage(Guid schemaUId, Guid entityId, Guid messageId);

		/// <summary>
		/// Get chunk messages for entity.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="readOptions">Reading options <see cref="EsnReadMessageOptions" />.</param>
		/// <returns>Collection of message DTO <see cref="EsnReadMessageDTO" />.</returns>
		IEnumerable<EsnReadMessageDTO> ReadEntityMessage(Guid schemaUId, Guid entityId, EsnReadMessageOptions readOptions);

		/// <summary>
		/// Get chunk messages for user feed.
		/// </summary>
		/// <param name="readOptions">Reading options <see cref="EsnReadMessageOptions" />.</param>
		/// <returns>Collection of message DTO <see cref="EsnReadMessageDTO" />.</returns>
		IEnumerable<EsnReadMessageDTO> ReadFeedMessage(EsnReadMessageOptions readOptions);

		/// <summary>
		/// Post new message.
		/// </summary>
		/// <param name="message">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		/// <returns>Message id.</returns>
		Guid PostMessage(EsnWriteMessageDTO message);

		/// <summary>
		/// Post new comment.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <param name="comment">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		/// <returns>Message id.</returns>
		Guid PostComment(Guid messageId, EsnWriteMessageDTO comment);

		/// <summary>
		/// Edit message.
		/// </summary>
		/// <param name="messageId">Message id.</param>
		/// <param name="message">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		bool EditMessage(Guid messageId, EsnWriteMessageDTO message);

		/// <summary>
		/// Edit comment.
		/// </summary>
		/// <param name="commentId">Comment id.</param>
		/// <param name="comment">Message dto <see cref="EsnWriteMessageDTO" />.</param>
		bool EditComment(Guid commentId, EsnWriteMessageDTO comment);

		/// <summary>
		/// Delete message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageId">Message id.</param>
        bool DeleteMessage(Guid schemaUId, Guid entityId, Guid messageId);

		/// <summary>
		/// Delete comment.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="commentId">Comment id.</param>
        bool DeleteComment(Guid schemaUId, Guid entityId, Guid commentId);
    }

	#endregion
}

