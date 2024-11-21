namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;

	#region Class: RightsManagerHelper

	/// <summary>
	/// Rights manager.
	/// </summary>
	public class RightsManagerHelper
	{
		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private UserConnection _userConnection;

		/// <summary>
		/// Schema name for grant rights.
		/// </summary>
		private string _schemaName;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize RightsManagerHelper.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance</param>
		/// <param name="schemaName">Schema name for grant rights</param>
		public RightsManagerHelper(UserConnection userConnection, string schemaName) {
			_userConnection = userConnection;
			_schemaName = schemaName;
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// Schema rights table name.
		/// </summary>
		private string SchemaRightsTableName {
			get {
				return _schemaName.StartsWith("Sys") ?
					string.Concat(_schemaName, "Right") : string.Concat("Sys", _schemaName, "Right");
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Creates delete query for record rights excluding sources.
		/// </summary>
		/// <param name="recordId">Entity record unique identifier.</param>
		/// <param name="sourcesToExclude">Sources to exclude list.</param>
		/// <returns><see cref="Query"/> instance.</returns>
		protected virtual Query GetDeleteQueryForRemoveRecordRightsExcludingSources(Guid recordId, List<Guid> sourcesToExclude) {
			Delete deleteQuery = new Delete(_userConnection)
				.From(SchemaRightsTableName)
				.Where("RecordId").IsEqual(Column.Parameter(recordId))
				.And()
					.OpenBlock("SourceId").Not().In(Column.Parameters(sourcesToExclude))
						.Or("SourceId").IsNull()
					.CloseBlock() as Delete;
			return deleteQuery;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Set entity schema record right level for operation
		/// </summary>
		/// <param name="sysAdminUnitId">SysAdminUnit id</param>
		/// <param name="recordId">Record id</param>
		/// <param name="operation">Operation</param>
		/// <param name="rightLevel">Right level</param>
		/// <param name="sourceId">Source id</param>
		/// <returns></returns>
		public virtual Guid SetEntitySchemaRecordRightLevel(Guid sysAdminUnitId, Guid recordId, EntitySchemaRecordRightOperation operation, 
			EntitySchemaRecordRightLevel rightLevel, Guid sourceId) {
				return _userConnection.DBSecurityEngine
					.SetEntitySchemaRecordRightLevel(sysAdminUnitId, _schemaName, recordId, operation, rightLevel, sourceId);
		}

		/// <summary>
		/// Grant rights for record by right parameters
		/// </summary>
		/// <param name="rightsParams"><see cref="RightsParams"/> instance</param>
		public virtual void GrantRightsForRecord(RightsParams rightsParams) {
			foreach (var rightLevel in rightsParams.OperationsRights) {
				foreach (var operation in rightLevel.Value) {
					SetEntitySchemaRecordRightLevel(rightsParams.SysAdminUnitId, rightsParams.RecordId,
							operation, rightLevel.Key, rightsParams.SourceId);
				}
			}
		}

		/// <summary>
		/// Remove record rights by source.
		/// </summary>
		/// <param name="recordId"><see cref="RightsParams"/> instance</param>
		/// <param name="sourceId">Source Id</param>
		public virtual void RemoveRecordRightsBySource(Guid recordId, Guid sourceId) {
			var deleteCommand = new Delete(_userConnection)
				.From(SchemaRightsTableName)
				.Where("RecordId").IsEqual(Column.Parameter(recordId))
				.And("SourceId").IsEqual(Column.Parameter(sourceId));
			deleteCommand.Execute();
		}

		/// <summary>
		/// Remove record rights excluding sources.
		/// </summary>
		/// <param name="recordId"><see cref="RightsParams"/> instance</param>
		/// <param name="sourcesToExclude">Sources Ids to exclude from delete</param>
		public virtual void RemoveRecordRightsExcludingSources(Guid recordId, List<Guid> sourcesToExclude) {
			Delete deleteQuery = (Delete)GetDeleteQueryForRemoveRecordRightsExcludingSources(recordId, sourcesToExclude);
			deleteQuery.Execute();
		}

		/// <summary>
		/// Remove record rights for user.
		/// </summary>
		/// <param name="recordId">Record unique identifier.</param>
		/// <param name="sysAdminUnitId"><see cref="SysAdminUnit"/> instance unique identifier.</param>
		public virtual void RemoveRecordRights(Guid recordId, Guid sysAdminUnitId) {
			var deleteCommand = new Delete(_userConnection)
				.From(SchemaRightsTableName)
				.Where("RecordId").IsEqual(Column.Parameter(recordId))
				.And("SysAdminUnitId").IsEqual(Column.Parameter(sysAdminUnitId));
			deleteCommand.Execute();
		}

		#endregion

		
	}

	#endregion

	#region Class: RightsParams

	/// <summary>
	/// Grant rights parameters.
	/// </summary>
	public class RightsParams
	{
		#region Constructors: Public

		/// <summary>
		/// Initialize right parameters.
		/// </summary>
		/// <param name="recordId">The id of the record</param>
		/// <param name="sourceId">The id of right`s source</param>
		public RightsParams(Guid recordId, Guid sourceId) {
			RecordId = recordId;
			SourceId = sourceId;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// The id of the record
		/// </summary>
		public Guid RecordId { get; private set; }

		/// <summary>
		/// The id of right`s source.
		/// </summary>
		public Guid SourceId { get; private set; }

		/// <summary>
		/// The id of SysAdminUnit.
		/// </summary>
		public Guid SysAdminUnitId { get; set; }

		/// <summary>
		/// Right`s level for operation (Key: RightLevel, Value: List of operation)
		/// </summary>
		public Dictionary<EntitySchemaRecordRightLevel, List<EntitySchemaRecordRightOperation>> OperationsRights { get; set; }

		#endregion
	}

	#endregion
}
