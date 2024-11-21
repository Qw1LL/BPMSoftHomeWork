namespace BPMSoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: CommunicationItem

	/// <summary>
	/// Provides properties for communication item info.
	/// </summary>
	public class CommunicationItem
	{
		#region Properties: Public

		/// <summary>
		/// Communication column name.
		/// </summary>
		public string ColumnName {
			get;
			set;
		}

		/// <summary>
		/// Communication type unique identifier.
		/// </summary>
		public Guid CommunicationTypeId {
			get;
			set;
		}

		/// <summary>
		/// New communication column value.
		/// </summary>
		public string ColumnValue {
			get;
			set;
		}

		/// <summary>
		/// Old communication column value/
		/// </summary>
		public string ColumnOldValue {
			get;
			set;
		}

		/// <summary>
		/// Flag, which represents current value is new.
		/// </summary>
		public bool IsNew {
			get {
				return string.IsNullOrEmpty(ColumnOldValue) && ColumnValue.IsNotNullOrEmpty();
			}
		}

		/// <summary>
		/// Flag, represents current value is changed.
		/// </summary>
		public bool IsChanged {
			get {
				return ColumnOldValue.IsNotNullOrEmpty() && ColumnValue.IsNotNullOrEmpty() && !ColumnOldValue.Equals(ColumnValue);
			}
		}

		/// <summary>
		/// Flag, represents current value is cleared.
		/// </summary>
		public bool IsDeleted {
			get {
				return ColumnOldValue.IsNotNullOrEmpty() && string.IsNullOrEmpty(ColumnValue);
			}
		}

		#endregion
	}

	#endregion

	#region Class: CommunicationSynchronizer

	/// <summary>
	/// Provides methods for synchronizing entity communications with communications detail.
	/// </summary>
	public class CommunicationSynchronizer
	{

		#region Constants: Private

		private const string DefCommunicationTypeColumnName = "CommunicationType";
		private const string DefPrimaryColumnName = "Primary";
		private const string NumberColumnName = "Number";
		private const string CommunicationSchemaNameTpl = "{0}Communication";

		#endregion

		#region Properties: Private

		private UserConnection UserConnection {
			get;
			set;
		}

		private Entity CurrentEntity {
			get;
			set;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Primary column name. 
		/// Default value is "Primary".
		/// </summary>
		private readonly string _primaryColumnName;
		protected string PrimaryColumnName {
			get {
				return string.IsNullOrEmpty(_primaryColumnName) ? DefPrimaryColumnName : _primaryColumnName;
			}
		}

		/// <summary>
		/// Current saving entity name.
		/// </summary>
		protected string CurrentEntityName {
			get {
				return CurrentEntity.SchemaName;
			}
		}

		/// <summary>
		/// Communication entity name.
		/// </summary>
		protected virtual string CommunicationEntityName {
			get {
				return string.Format(CommunicationSchemaNameTpl, CurrentEntityName);
			}
		}

		/// <summary>
		/// Column name for link communication entity with current entity.
		/// </summary>
		protected string LinkedColumnName {
			get;
			private set;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// List of <see cref="CommunicationItem"/> for current entity.
		/// </summary>
		private List<CommunicationItem> _communicationColumnsList;
		public List<CommunicationItem> CommunicationItemsList {
			get {
				return _communicationColumnsList ?? (_communicationColumnsList = new List<CommunicationItem>());
			}
		}

		#endregion

		#region Construcors: Public

		/// <summary>
		/// Initializes instance of synchronizer.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		/// <param name="entity">Current entity.</param>
		public CommunicationSynchronizer(UserConnection userConnection, Entity entity) {
			UserConnection = userConnection;
			CurrentEntity = entity;
			LinkedColumnName = GetLinkedColumnName();
		}

		/// <summary>
		/// Initializes primary column name for synchronizer.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="entity">Current entity.</param>
		/// <param name="primaryColumnName">Primary column name.</param>
		public CommunicationSynchronizer(UserConnection userConnection, Entity entity, string primaryColumnName) {
			UserConnection = userConnection;
			CurrentEntity = entity;
			LinkedColumnName = GetLinkedColumnName();
			_primaryColumnName = primaryColumnName;
		}

		#endregion

		#region Methods: Pirvate

		/// <summary>
		/// Removes communication.
		/// </summary>
		/// <param name="communicationItem"><see cref="CommunicationItem"/> instance to remove.</param>
		/// <remarks>Actualizes primary flag column for all records of <see cref="CommunicationItem.CommunicationTypeId"/> type.</remarks>
		private void RemoveCommunication(CommunicationItem communicationItem) {
			ActualizePrimaryState(communicationItem.CommunicationTypeId);
			Entity communicationEntity = CheckExists(communicationItem);
			if (communicationEntity != null) {
				communicationEntity.Delete();
			}
		}

		/// <summary>
		/// Creates or updates communication.
		/// </summary>
		/// <param name="communicationItem"><see cref="CommunicationItem"/> instance.</param>
		private void CreateOrUpdateCommunication(CommunicationItem communicationItem) {
			ActualizePrimaryState(communicationItem.CommunicationTypeId);
			Entity communicationEntity = GetCommunicationEntity();
			communicationEntity.SetColumnValue(DefCommunicationTypeColumnName + "Id", communicationItem.CommunicationTypeId);
			communicationEntity.SetColumnValue(NumberColumnName, communicationItem.ColumnValue);
			communicationEntity.SetColumnValue(PrimaryColumnName, true);
			communicationEntity.Save();
		}

		/// <summary>
		/// Returns communication entity.
		/// </summary>
		/// <returns>Instance of <see cref="Entity"/> instance.</returns>
		private Entity GetCommunicationEntity() {
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(CommunicationEntityName);
			var entity = schema.CreateEntity(UserConnection);
			entity.SetDefColumnValues();
			entity.SetColumnValue(LinkedColumnName + "Id", CurrentEntity.PrimaryColumnValue);
			return entity;
		}

		/// <summary>
		/// Applies communication type filter to <paramref name="esq"/>.
		/// </summary>
		/// <param name="esq">Entity schema query.</param>
		/// <param name="communicationTypeId">Communication type identifier.</param>
		private void ApplyTypeFilter(EntitySchemaQuery esq, Guid communicationTypeId) {
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, DefCommunicationTypeColumnName,
				communicationTypeId));
		}

		/// <summary>
		/// Applies communication value filter to <paramref name="esq"/>.
		/// </summary>
		/// <param name="esq">Entity schema query.</param>
		/// <param name="columnValue">Number value.</param>
		private void ApplyValueFilter(EntitySchemaQuery esq, string columnValue) {
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, NumberColumnName,
				columnValue));
		}

		/// <summary>
		/// Returns linked column name.
		/// </summary>
		/// <returns>Linked column name.</returns>
		private string GetLinkedColumnName() {
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(CommunicationEntityName);
			var schemaUId = CurrentEntity.Schema.UId;
			string linkedColumnName = string.Empty;
			foreach (EntitySchemaColumn column in schema.Columns) {
				if (column.ReferenceSchemaUId.Equals(schemaUId) && !column.UsageType.Equals(EntitySchemaColumnUsageType.Advanced)) {
					linkedColumnName = column.Name;
					break;
				}
			}
			return linkedColumnName;
		}

		/// <summary>
		/// Actualizes primary state for <paramref name="communicationTypeId"/>.
		/// </summary>
		/// <param name="communicationTypeId">Communication type identifier.</param>
		private void ActualizePrimaryState(Guid communicationTypeId) {
			new Update(UserConnection, CommunicationEntityName)
				.Set(PrimaryColumnName, Column.Parameter(false))
				.Where(LinkedColumnName + "Id").IsEqual(Column.Parameter(CurrentEntity.PrimaryColumnValue))
				.And(DefCommunicationTypeColumnName + "Id").IsEqual(Column.Parameter(communicationTypeId)).Execute();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Checks communication exists. 
		/// If communication entity was found, returns it.
		/// </summary>
		/// <param name="communicationItem"><see cref="CommunicationItem"/> instance.</param>
		/// <returns>Communication entity instance.</returns>
		protected virtual Entity CheckExists(CommunicationItem communicationItem) {
			var esq = GetDefCommunicationESQ();
			ApplyTypeFilter(esq, communicationItem.CommunicationTypeId);
			if (communicationItem.IsNew) {
				ApplyValueFilter(esq, communicationItem.ColumnValue);
			} else if (communicationItem.IsChanged || communicationItem.IsDeleted) {
				ApplyValueFilter(esq, communicationItem.ColumnOldValue);
			}
			var resultCollection = esq.GetEntityCollection(UserConnection);
			if (resultCollection.Count > 0) {
				return resultCollection.First();
			}
			return null;
		}

		/// <summary>
		/// Returns default communication entity schema query.
		/// </summary>
		/// <returns>Entity schema query for communication entity.</returns>
		protected virtual EntitySchemaQuery GetDefCommunicationESQ() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, CommunicationEntityName);
			var createdOnColumn = esq.AddColumn("CreatedOn");
			createdOnColumn.OrderByDesc();
			esq.AddAllSchemaColumns();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, LinkedColumnName,
				CurrentEntity.PrimaryColumnValue));
			return esq;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Initializes communication items properties by <paramref name="communicationsList"/>. 
		/// </summary>
		/// <param name="communicationsList">List of communication columns for current entity.</param>
		public virtual void InitializeCommunicationItems(Dictionary<string, Guid> communicationsList) {
			var entity = CurrentEntity;
			var communicationColumnsList = CommunicationItemsList;
			foreach (var communicationItem in communicationsList) {
				var columnName = communicationItem.Key;
				var oldValue = entity.GetTypedOldColumnValue<string>(columnName);
				var newValue = entity.GetTypedColumnValue<string>(columnName);
				if (newValue.Equals(oldValue)) {
					continue;
				}
				communicationColumnsList.Add(new CommunicationItem {
					ColumnName = columnName,
					ColumnOldValue = oldValue,
					ColumnValue = newValue,
					CommunicationTypeId = communicationItem.Value
				});
			}
		}

		/// <summary>
		/// Synchronizes communications from main entity to detail entity.
		/// </summary>
		public virtual void SynchronizeCommunications() {
			foreach (var communicationItem in CommunicationItemsList) {
				if (communicationItem.IsNew || communicationItem.IsChanged) {
					CreateOrUpdateCommunication(communicationItem);
				}
			}
		}

		#endregion

	}

	#endregion

}
