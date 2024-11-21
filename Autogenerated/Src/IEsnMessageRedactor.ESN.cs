namespace BPMSoft.Configuration.ESN
{
	using System;
	using Core.Entities;

	#region  Interface: IEsnMessageRedactor

	/// <summary>
	/// Provides methods for social network redacting messages.
	/// </summary>
	public interface IEsnMessageRedactor
	{
		/// <summary>
		/// Post entity's message.
		/// </summary>
		/// <param name="messageData">Message data.</param>
		/// with the help of <see cref="EsnWriteMessageDTO"/>.
		Guid PostMessage(EsnWriteMessageDTO messageData);

		/// <summary>
		/// Post message's comment.
		/// </summary>
		/// <param name="messageId">Message Id.</param>
		/// <param name="commentData">Comment data.</param>
		/// with the help of <see cref="EsnWriteMessageDTO"/>.
		Guid PostComment(Guid messageId, EsnWriteMessageDTO commentData);

		/// <summary>
		/// Edit entity's message.
		/// </summary>
		/// <param name="message">Message whos be edited.</param>
		/// <param name="messageData">String message.</param>
		/// with the help of <see cref="Entity"/>.
		bool EditMessage(Entity message, string messageData);

		/// <summary>
		/// Edit message's comment.
		/// </summary>
		/// <param name="comment">Comment whos be edited.</param>
		/// <param name="commentData">String comment.</param>
		///  with the help of <see cref="Entity"/>.
		bool EditComment(Entity comment, string commentData);

		/// <summary>
		/// Delete entity's message.
		/// </summary>
		/// <param name="message">Message whos be deleted.</param>
		///  with the help of <see cref="Entity"/>.
		bool DeleteMessage(Entity message);

		/// <summary>
		/// Delete entity's message.
		/// </summary>
		/// <param name="comment">Comment whos be deleted.</param>
		///  with the help of <see cref="Entity"/>.
		bool DeleteComment(Entity comment);
	}

	#endregion
}
