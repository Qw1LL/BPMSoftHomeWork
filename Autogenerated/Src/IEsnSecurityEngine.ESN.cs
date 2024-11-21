namespace BPMSoft.Configuration.ESN
{
	using System;

	#region  Interface: IEsnSecurityEngine

	/// <summary>
	/// Provides methods for checking permission to enterprise social network messages.
	/// </summary>
	public interface IEsnSecurityEngine
	{
		/// <summary>
		/// Check whether the user has access to receive entity messages.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		bool CanReadEntityMessage(Guid schemaUId, Guid entityId);
		
		/// <summary>
		/// Check whether the user has access to posting message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		bool CanCreateMessage(Guid schemaUId, Guid entityId);

		/// <summary>
		/// Check whether the user has access to posting comment.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		bool CanCreateComment(Guid schemaUId, Guid entityId);

		/// <summary>
		/// Check whether the user has access to editing message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageAuthorId">Message author id.</param>
		bool CanEditPost(Guid schemaUId, Guid entityId, Guid messageAuthorId);

		/// <summary>
		/// Check whether the user has access to deleting message.
		/// </summary>
		/// <param name="schemaUId">Schema message UId.</param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="messageAuthorId">Message author id.</param>
		bool CanDeletePost(Guid schemaUId, Guid entityId, Guid messageAuthorId);

	}

	#endregion
}

