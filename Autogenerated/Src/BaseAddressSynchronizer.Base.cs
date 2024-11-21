namespace BPMSoft.Configuration
{
	using Core.Factories;
	using EntitySynchronization;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: BaseAddressSynchronizer

	/// <summary>
	/// Provides methods for synchronizing address with master entity columns.
	/// </summary>
	public class BaseAddressSynchronizer
	{

		#region Properties: Private

		private UserConnection UserConnection {
			get;
		}

		private Entity AddressEntity {
			get;
		}

		private string MasterEntityName {
			get;
		}

		private string AddressEntityName {
			get {
				return AddressEntity.SchemaName;
			}
		}

		private string AddressReferenceColumnName {
			get {
				return string.Format("{0}Id", MasterEntityName);
			}
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// <see cref="IEqualComparatorProvider"/>
		/// </summary>
		private IEqualComparatorProvider _equalComparatorProvider;
		protected IEqualComparatorProvider EqualComparatorProvider {
			get {
				return _equalComparatorProvider ??
					(_equalComparatorProvider = ClassFactory.Get<EqualComparatorProvider>());
			}
		}

		/// <summary>
		/// <see cref="IEntitySynchronizationProvider"/>
		/// </summary>
		private IEntitySynchronizationProvider _entitySynchronizationProvider;
		protected IEntitySynchronizationProvider EntitySynchronizationProvider {
			get {
				return _entitySynchronizationProvider ??
					(_entitySynchronizationProvider = ClassFactory.Get<EntitySynchronizationProvider>(
						new ConstructorArgument("userConnection", UserConnection)));
			}
		}

		/// <summary>
		/// <see cref="IColumnValuesSynchronizer"/>
		/// </summary>
		private IColumnValuesSynchronizer _columnValuesSynchronizer;
		protected IColumnValuesSynchronizer ColumnValuesSynchronizer {
			get {
				return _columnValuesSynchronizer ??
					(_columnValuesSynchronizer = ClassFactory.Get<ColumnValuesSynchronizer>());
			}
		}

		#endregion

		#region Construcors: Public

		/// <summary>
		/// Initializes instance of synchronizer.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		/// <param name="addressEntity">Current address entity.</param>
		/// <param name="masterEntityName">Master entity name.</param>
		public BaseAddressSynchronizer(UserConnection userConnection, Entity addressEntity,
				string masterEntityName) {
			UserConnection = userConnection;
			AddressEntity = addressEntity;
			MasterEntityName = masterEntityName;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Synchronization column mapping.
		/// </summary>
		/// <returns>List of <see cref="SynchronizationColumnMapping"/></returns>
		protected virtual ICollection<SynchronizationColumnMapping> GetSynchronizationColumnMappings() {
			SynchronizationColumnComparator dateEqualComparator = EqualComparatorProvider.GetDateEqualComparator();
			SynchronizationColumnComparator stringEqualComparator = EqualComparatorProvider.GetStringEqualComparator();
			return new List<SynchronizationColumnMapping> {
				new SynchronizationColumnMapping {
					SourceColumnName = "AddressTypeId",
					DestinationColumnName = "AddressTypeId"
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "CountryId",
					DestinationColumnName = "CountryId"
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "RegionId",
					DestinationColumnName = "RegionId"
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "CityId",
					DestinationColumnName = "CityId"
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "Address",
					DestinationColumnName = "Address",
					Comparator = stringEqualComparator
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "Zip",
					DestinationColumnName = "Zip",
					Comparator = stringEqualComparator
				}
			};
		}

		/// <summary>
		/// Returns master entity.
		/// </summary>
		/// <returns>Master <see cref="Entity"/>.</returns>
		protected virtual Entity GetMasterEntity() {
			var masterEntityId = AddressEntity.GetTypedColumnValue<Guid>(AddressReferenceColumnName);
			return EntitySynchronizationProvider.FindEntity(MasterEntityName, new Dictionary<string, object> {
				{ "Id", masterEntityId}
			});
		}

		/// <summary>
		/// Returns empty address entity.
		/// </summary>
		/// <returns>Empty address <see cref="Entity"/>.</returns>
		protected virtual Entity GetEmptyAddressEntity() {
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName(AddressEntity.SchemaName);
			Entity entity = schema.CreateEntity(UserConnection);
			entity.SetDefColumnValues();
			return entity;
		}

		/// <summary>
		/// Checks is entity column values changed.
		/// </summary>
		/// <param name="entity"><see cref="Entity"/></param>
		/// <returns>Is entity column values changed tag.</returns>
		protected virtual bool IsEntityChanged(Entity entity) {
			return entity.GetChangedColumnValues().Any(c => !c.IsVirtual);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Resets rpimary column value.
		/// </summary>
		public virtual void ResetPrimaryColumn() {
			var masterEntityId = AddressEntity.GetTypedColumnValue<Guid>(AddressReferenceColumnName);
			var resetPrimaryColumn = new Update(UserConnection, AddressEntityName)
				.Set("Primary", Column.Parameter(false))
				.Where(AddressReferenceColumnName).IsEqual(Column.Parameter(masterEntityId))
				.And("Id").IsNotEqual(Column.Parameter(AddressEntity.PrimaryColumnValue)) as Update;
			resetPrimaryColumn.Execute();
		}

		/// <summary>
		/// Clears synced master entity columns.
		/// </summary>
		public virtual void ClearMasterEntityAddress() {
			var masterEntity = GetMasterEntity();
			if (masterEntity == null) {
				return;
			}
			var emptyAddress = GetEmptyAddressEntity();
			ICollection<SynchronizationColumnMapping> columnMappings = GetSynchronizationColumnMappings();
			ColumnValuesSynchronizer.SynchronizeEntities(emptyAddress, masterEntity, columnMappings);
			if (IsEntityChanged(masterEntity)) {
				masterEntity.Save();
			}
		}

		/// <summary>
		/// Synchronizes address with master entity.
		/// </summary>
		public virtual void SyncAddressWithMasterEntity() {
			var masterEntity = GetMasterEntity();
			if (masterEntity == null) {
				return;
			}
			ICollection<SynchronizationColumnMapping> columnMappings = GetSynchronizationColumnMappings();
			ColumnValuesSynchronizer.SynchronizeEntities(AddressEntity, masterEntity, columnMappings);
			if (IsEntityChanged(masterEntity)) {
				//masterEntity.SetColumnValue("GPSN", string.Empty);
				//masterEntity.SetColumnValue("GPSE", string.Empty);
				masterEntity.Save();
			}
		}

		/// <summary>
		/// Returns address count.
		/// </summary>
		/// <returns>Primary count.</returns>
		public virtual int GetAddressesCount() {
			var masterEntityId = AddressEntity.GetTypedColumnValue<Guid>(AddressReferenceColumnName);
			Select primaryCountSelect = new Select(UserConnection)
				.Column(Func.Count("Id"))
				.From(AddressEntityName)
				.Where(AddressReferenceColumnName).IsEqual(Column.Parameter(masterEntityId)) as Select;
			return primaryCountSelect.ExecuteScalar<int>();
		}

		/// <summary>
		/// Sets primary address to last created address.
		/// </summary>
		public virtual void SetPrimaryAddress() {
			var masterEntityId = AddressEntity.GetTypedColumnValue<Guid>(AddressReferenceColumnName);
			var nextPrimaryAddress = new EntitySchemaQuery(UserConnection.EntitySchemaManager, AddressEntityName);
			nextPrimaryAddress.Filters.Add(nextPrimaryAddress.CreateFilterWithParameters(FilterComparisonType.Equal,
				MasterEntityName, masterEntityId));
			var createdOnColumn = nextPrimaryAddress.AddColumn("CreatedOn");
			nextPrimaryAddress.AddAllSchemaColumns();
			createdOnColumn.OrderByDesc();
			var options = new EntitySchemaQueryOptions {
				PageableDirection = PageableSelectDirection.First,
				PageableRowCount = 1,
				PageableConditionValues = new Dictionary<string, object>()
			};
			var collection = nextPrimaryAddress.GetEntityCollection(UserConnection, options);
			var primaryAddress = collection.Count > 0 ? collection.First() : null;
			if (primaryAddress != null) {
				primaryAddress.SetColumnValue("Primary", true);
				primaryAddress.Save();
			}
		}

		#endregion

	}

	#endregion

}
