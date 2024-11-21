namespace BPMSoft.Configuration.ESN
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Entities;

	#region  Class: EsnMessageRedactor

	/// <inheritdoc />
	[DefaultBinding(typeof(IEsnMessageRedactor))]
	public class EsnMessageRedactor : IEsnMessageRedactor
	{
		#region Constants: Protected

		/// <summary>
		/// Entity schema name.
		/// </summary>
		protected const string EsnMessageEntitySchemaName = "SocialMessage";

		/// <summary>
		/// Primary column name.
		/// </summary>
		protected const string EsnPrimaryColumnName = "Id";

		/// <summary>
		/// Entity primary column name where will be posted message.
		/// </summary>
		protected const string EsnEntityIdColumnName = "EntityId";

		/// <summary>
		/// Entity message column name.
		/// </summary>
		protected const string EsnMessageColumnName = "Message";

		/// <summary>
		/// Comment's parent message column name.
		/// </summary>
		protected const string EsnParentIdColumnName = "ParentId";

		/// <summary>
		/// Entity unique Id column name where will be posted message.
		/// </summary>
		protected const string EsnEntitySchemaUIdColumnName = "EntitySchemaUId";

		/// <summary>
		/// User connection.
		/// </summary>
		protected readonly UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		public EsnMessageRedactor(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Entity CreateMessage(string message) {
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(EsnMessageEntitySchemaName);
			var post = schema.CreateEntity(UserConnection);
			post.SetDefColumnValues();
			post.SetColumnValue(EsnMessageColumnName, message);
			return post;
		}

		private void SetUseAdminRights(Entity entity) {
			entity.UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic;
		}

		private bool InnerMessageDelete(Entity entity) {
			SetUseAdminRights(entity);
			return entity.Delete();
		}

		private bool InnerMessageSave(Entity message) {
			SetUseAdminRights(message);
			return message.Save();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Get new message to post.
		/// </summary>
		/// <param name="postData">Data for message post.</param>
		/// <returns></returns>
		protected Entity CreateMessageEntity(EsnWriteMessageDTO postData) {
			var message = CreateMessage(postData.Message);
			if (!Guid.Empty.Equals(postData.Id)) {
				message.SetColumnValue(EsnPrimaryColumnName, postData.Id);
			}
			message.SetColumnValue(EsnEntityIdColumnName, postData.EntityId);
			message.SetColumnValue(EsnEntitySchemaUIdColumnName, postData.SchemaUId);
			return message;
		}

		/// <summary>
		/// Get new comment to message.
		/// </summary>
		/// <param name="postData">Data for comment message.</param>
		/// <param name="parentMessageId">Parent message Id.</param>
		/// <returns></returns>
		protected Entity CreateCommentEntity(EsnWriteMessageDTO postData, Guid parentMessageId) {
			var comment = CreateMessage(postData.Message);
			if (!Guid.Empty.Equals(postData.Id)) {
				comment.SetColumnValue(EsnPrimaryColumnName, postData.Id);
			}
			if (!Guid.Empty.Equals(parentMessageId)) {
				comment.SetColumnValue(EsnParentIdColumnName, parentMessageId);
			}
			return comment;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public bool DeleteComment(Entity comment) => InnerMessageDelete(comment);

		/// <inheritdoc />
		public bool DeleteMessage(Entity message) => InnerMessageDelete(message);

		/// <inheritdoc />
		public bool EditComment(Entity comment, string commentData) {
			comment.SetColumnValue(EsnMessageColumnName, commentData);
			return InnerMessageSave(comment);
		}

		/// <inheritdoc />
		public bool EditMessage(Entity message, string messageData) {
			message.SetColumnValue(EsnMessageColumnName, messageData);
			return InnerMessageSave(message);
		}

		/// <inheritdoc />
		public Guid PostComment(Guid messageId, EsnWriteMessageDTO commentData) {
			var comment = CreateCommentEntity(commentData, messageId);
			return InnerMessageSave(comment) ? comment.PrimaryColumnValue : Guid.Empty;
		}

		/// <inheritdoc />
		public Guid PostMessage(EsnWriteMessageDTO messageData) {
			var message = CreateMessageEntity(messageData);
			return InnerMessageSave(message) ? message.PrimaryColumnValue : Guid.Empty;
		}

		#endregion
	}

	#endregion
}
