namespace BPMSoft.Configuration.ESN
{
	using System;
	using System.Collections.Generic;
	using Common;
	using Core;
	using Core.DB;
	using Core.Entities;
	using Core.Factories;

	#region  Class: EsnSecurityEngine

	/// <inheritdoc />
	[DefaultBinding(typeof(IEsnSecurityEngine))]
	public class EsnSecurityEngine : IEsnSecurityEngine
	{
		#region Constants: Private

		private const string CanSelectEverything = "CanSelectEverything";
		private const string CanInsertEverything = "CanInsertEverything";
		private const string CanUpdateEverything = "CanUpdateEverything";
		private const string CanDeleteEverything = "CanDeleteEverything";
		private const string CanDeleteAllMessageComment = "CanDeleteAllMessageComment";

		private readonly Guid _socialChannelUId = Guid.Parse("dd74c060-eb4b-4f15-b381-db91ca5ac483");
		private readonly UserConnection _userConnection;
		private Dictionary<Guid, bool> _permissions;

		#endregion

		#region Constructors: Public

		public EsnSecurityEngine(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			userConnection.DBSecurityEngine.CheckDependencyNull("UserConnection.DBSecurityEngine");
			_userConnection = userConnection;
			_permissions = new Dictionary<Guid, bool>();
		}

		#endregion

		#region Methods: Private

		private EntitySchema GetEntitySchema(Guid channelUId) {
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByUId(channelUId);
			entitySchema.CheckArgumentNull(nameof(entitySchema));
			return entitySchema;
		}

		private bool GetIsRecordLevelRightAllowed(EntitySchema entitySchema,
				Guid entityId, SchemaRecordRightLevels inspectRightLevel) {
			if (!_userConnection.DBSecurityEngine.GetIsEntitySchemaAdministratedByRecords(entitySchema)) {
				return true;
			}
			var rightLevel = _userConnection.DBSecurityEngine.GetEntitySchemaRecordRightLevel(entitySchema, entityId);
			return (rightLevel & inspectRightLevel) == inspectRightLevel;
		}

		private bool GetIsReadSchemaAllowed(EntitySchema entitySchema)
		{
			if (!_userConnection.DBSecurityEngine.GetIsEntitySchemaAdministratedByOperations(entitySchema.Name))
			{
				return true;
			}
			return _userConnection.DBSecurityEngine.GetIsEntitySchemaReadingAllowed(entitySchema.Name);
		}

		private string GetEntitySchemaNameByUId(Guid channelUId)
		{
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByUId(channelUId);
			entitySchema.CheckArgumentNull(nameof(entitySchema));
			return entitySchema.Name;
		}

		private bool GetIsRecordLevelRightAllowed(string entitySchemaName,
				Guid entityId, SchemaRecordRightLevels inspectRightLevel)
		{
			if (!_userConnection.DBSecurityEngine.GetIsEntitySchemaAdministratedByRecords(entitySchemaName))
			{
				return true;
			}
			var rightLevel = _userConnection.DBSecurityEngine.GetEntitySchemaRecordRightLevel(entitySchemaName, entityId);
			return (rightLevel & inspectRightLevel) == inspectRightLevel;
		}

		private bool GetIsReadSchemaAllowed(string entitySchemaName)
		{
			if (!_userConnection.DBSecurityEngine.GetIsEntitySchemaAdministratedByOperations(entitySchemaName))
			{
				return true;
			}
			return _userConnection.DBSecurityEngine.GetIsEntitySchemaReadingAllowed(entitySchemaName);
		}

		private bool GetCanAllUsersPostInChannel(Guid channelId) {
			Select select = new Select(_userConnection)
				.Column("PublisherRightKind")
				.From("SocialChannel")
				.Where("Id").IsEqual(Column.Parameter(channelId)) as Select;
			return select.ExecuteScalar<bool>();
		}

		private bool GetCanReadEntityMessage(Guid schemaUId, Guid entityId) {
			if (_userConnection.DBSecurityEngine.GetCanExecuteOperation(CanSelectEverything)) {
				return true;
			}
			if (_permissions.TryGetValue(entityId, out bool havePermission)) {
				return havePermission;
			}
			var entitySchemaName = GetEntitySchemaNameByUId(schemaUId);
			havePermission = GetIsReadSchemaAllowed(entitySchemaName)
				&& GetIsRecordLevelRightAllowed(entitySchemaName, entityId, SchemaRecordRightLevels.CanRead);
			_permissions[entityId] = havePermission;
			return havePermission;
		}

		private bool GetIsPostAuthorAndCanRead(Guid schemaUId, Guid entityId, Guid messageAuthorId) =>
			_userConnection.CurrentUser.ContactId.Equals(messageAuthorId) &&
			GetCanReadEntityMessage(schemaUId, entityId);

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public bool CanReadEntityMessage(Guid schemaUId, Guid entityId) =>
			GetCanReadEntityMessage(schemaUId, entityId);

		/// <inheritdoc />
		public bool CanCreateMessage(Guid schemaUId, Guid entityId) {
			if (_userConnection.DBSecurityEngine.GetCanExecuteOperation(CanInsertEverything)) {
				return true;
			} else if (!GetCanReadEntityMessage(schemaUId, entityId)) {
				return false;
			} else if (!schemaUId.Equals(_socialChannelUId) || GetCanAllUsersPostInChannel(entityId)) {
				return true;
			}
			var schemaName = GetEntitySchemaNameByUId(schemaUId);
			return GetIsRecordLevelRightAllowed(schemaName, entityId, SchemaRecordRightLevels.CanEdit);
		}

		/// <inheritdoc />
		public bool CanCreateComment(Guid schemaUId, Guid entityId) =>
			_userConnection.DBSecurityEngine.GetCanExecuteOperation(CanInsertEverything) ||
			GetCanReadEntityMessage(schemaUId, entityId);

		/// <inheritdoc />
		public bool CanEditPost(Guid schemaUId, Guid entityId, Guid messageAuthorId) =>
			_userConnection.DBSecurityEngine.GetCanExecuteOperation(CanUpdateEverything) ||
			GetIsPostAuthorAndCanRead(schemaUId, entityId, messageAuthorId);

		/// <inheritdoc />
		public bool CanDeletePost(Guid schemaUId, Guid entityId, Guid messageAuthorId) =>
			_userConnection.DBSecurityEngine.GetCanExecuteOperation(CanDeleteEverything) ||
			_userConnection.DBSecurityEngine.GetCanExecuteOperation(CanDeleteAllMessageComment) ||
			GetIsPostAuthorAndCanRead(schemaUId, entityId, messageAuthorId);

		#endregion
	}

	#endregion
}

