namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Packages;

	#region Class: DataBindingManufacturerParameters

	public class DataBindingManufacturerColumn
	{

		#region Properties: Public

		public string Name { get; set; }

		public bool IsForceUpdate { get; set; }

		public bool IsKey { get; set; }

		#endregion

		#region Constructors: Public

		public DataBindingManufacturerColumn() { }

		public DataBindingManufacturerColumn(string name) {
			Name = name;
		}

		public DataBindingManufacturerColumn(string name, bool forceUpdate, bool key) {
			Name = name;
			IsForceUpdate = forceUpdate;
			IsKey = key;
		}

		#endregion

	}

	#endregion

	#region Class: DataBindingManufacturerParameters

	public class DataBindingManufacturerParameters
	{

		#region Properties: Public

		public string Name { get; set; }

		public string EntitySchemaName { get; set; }

		public Guid PackageUId { get; set; }

		public IEnumerable<DataBindingManufacturerColumn> Columns { get; set; }

		public EntitySchemaQueryFilterCollection Filters { get; set; }

		#endregion

	}

	#endregion

	#region Class: DataBindingManufacturerResult

	public class DataBindingManufacturerResult
	{

		#region Properties: Public

		public bool Success { get; set; }

		public Collection<ItemValidationMessage> ResultMessages { get; set; }

		#endregion

	}

	#endregion

	#region Interface: IDataBindingManufacturer

	public interface IDataBindingManufacturer
	{
		DataBindingManufacturerResult GenerateBinding(EntityCollection entities, DataBindingManufacturerParameters parameters);
	}

	#endregion

	#region Class: SchemaDataBindingManufacturer

	[DefaultBinding(typeof(IDataBindingManufacturer), Name = "SchemaDataBindingManufacturer")]
	public class SchemaDataBindingManufacturer : IDataBindingManufacturer
	{

		#region Fields: Private

		private PackageValidator _packageValidator;

		private PackageElementUtilities _packageElementUtilities;

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection {
			get;
			set;
		}

		/// <summary>
		/// Package validator.
		/// </summary>
		protected PackageValidator PackageValidator =>
			_packageValidator ?? (_packageValidator =
				ClassFactory.Get<PackageValidator>(
					new ConstructorArgument("userConnection", UserConnection)));

		/// <summary>
		/// Binding manufacturer.
		/// </summary>
		protected PackageElementUtilities PackageElementUtilities =>
			_packageElementUtilities ?? (_packageElementUtilities = ClassFactory.Get<PackageElementUtilities>(
				new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Constructors: Public

		public SchemaDataBindingManufacturer(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Returns packageId by package UId.
		/// </summary>
		/// <param name="packageUId">Package UId</param>
		/// <returns></returns>
		private Guid GetPackageIdByUId(Guid packageUId) {
			return WorkspaceUtilities.GetPackageIdByUId(packageUId, UserConnection);
		}

		/// <summary>
		/// Creates package schema data descriptor.
		/// </summary>
		/// <param name="schemaDataName">Schema data name</param>
		/// <param name="packageUId">Package UId</param>
		/// <param name="entitySchemaUId">Entity schema UId</param>
		/// <returns><see cref="PackageSchemaDataDescriptor"/></returns>
		private PackageSchemaDataDescriptor CreateSchemaDataDescriptor(string schemaDataName, Guid packageUId, Guid entitySchemaUId) {
			var schemaDataUId = GetSchemaDataUId(packageUId, schemaDataName);
			PackageSchemaDataDescriptor schemaDataDescriptor = new PackageSchemaDataDescriptor();
			schemaDataDescriptor.UId = schemaDataUId;
			schemaDataDescriptor.Name = schemaDataName;
			schemaDataDescriptor.Package = new Package {
				UId = packageUId
			};
			schemaDataDescriptor.Schema = new SchemaDescriptor {
				UId = entitySchemaUId
			};
			return schemaDataDescriptor;
		}

		/// <summary>
		/// Finds exists schema data UId by name and package UId, if not exist generate new UId.
		/// </summary>
		/// <param name="packageUId">Package UId</param>
		/// <param name="schemaDataName">Schema data name</param>
		/// <returns></returns>
		private Guid GetSchemaDataUId(Guid packageUId, string schemaDataName) {
			var packageId = GetPackageIdByUId(packageUId);
			var schemaDataUId = WorkspaceUtilities.FindSchemaDataUIdByName(packageId, schemaDataName, UserConnection);
			if (schemaDataUId.IsEmpty()) {
				schemaDataUId = Guid.NewGuid();
			}
			return schemaDataUId;
		}

		/// <summary>
		/// Adds columns to <see cref="PackageSchemaDataDescriptor"/>.
		/// </summary>
		/// <param name="schemaDataDescriptor"><see cref="PackageSchemaDataDescriptor"/></param>
		/// <param name="columns">Columns</param>
		/// <param name="entitySchema"><see cref="EntitySchema"/></param>
		private void AddColumnToSchemaData(PackageSchemaDataDescriptor schemaDataDescriptor, IEnumerable<DataBindingManufacturerColumn>  columns, EntitySchema entitySchema) {
			foreach (DataBindingManufacturerColumn column in columns) {
				var entitySchemaColumn = entitySchema.Columns.GetByName(column.Name);
				schemaDataDescriptor.AddColumn(new PackageSchemaDataColumnDescriptor(entitySchemaColumn.UId, column.IsForceUpdate, column.IsKey,
					column.Name, entitySchemaColumn.DataValueTypeUId));
			}
		}

		/// <summary>
		/// Validates <see cref="PackageSchemaDataDescriptor"/>.
		/// </summary>
		/// <param name="schemaDataDescriptor"><see cref="PackageSchemaDataDescriptor"/></param>
		/// <param name="entities">Entities</param>
		/// <param name="resultMessages">Validation messages</param>
		/// <returns></returns>
		private bool ValidateSchemaData(PackageSchemaDataDescriptor schemaDataDescriptor, EntityCollection entities, out Collection<ItemValidationMessage> resultMessages) {
			resultMessages = new Collection<ItemValidationMessage>();
			return PackageValidator.ValidateSchemaData(schemaDataDescriptor, entities, resultMessages);
		}

		/// <summary>
		/// Saves <see cref="PackageSchemaDataDescriptor"/>.
		/// </summary>
		/// <param name="schemaDataDescriptor"><see cref="PackageSchemaDataDescriptor"/></param>
		/// <param name="entities">Entities</param>
		/// <param name="serializedFilters">Filters for old UI</param>
		/// <returns><see cref="PackageSchemaDataDescriptor"/> Id</returns>
		private Guid SaveSchemaData(PackageSchemaDataDescriptor schemaDataDescriptor, EntityCollection entities, string serializedFilters) {
			return PackageElementUtilities.SavePackageSchemaData(schemaDataDescriptor, entities, serializedFilters);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Generates binding by parameters.
		/// </summary>
		/// <param name="parameters"><see cref="DataBindingManufacturerParameters"/></param>
		/// <returns><see cref="DataBindingManufacturerResult"/></returns>
		public DataBindingManufacturerResult GenerateBinding(EntityCollection entities, DataBindingManufacturerParameters parameters) {
			string schemaDataName = parameters.Name;
			string entitySchemaName = parameters.EntitySchemaName;
			Guid packageUId = parameters.PackageUId;
			IEnumerable<DataBindingManufacturerColumn> columns = parameters.Columns;

			schemaDataName.CheckArgumentNullOrEmpty(nameof(schemaDataName));
			entitySchemaName.CheckArgumentNullOrEmpty(nameof(entitySchemaName));
			packageUId.CheckArgumentEmpty(nameof(packageUId));
			columns.CheckArgumentNull(nameof(columns));

			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entitySchemaName);
			
			PackageSchemaDataDescriptor schemaDataDescriptor = CreateSchemaDataDescriptor(schemaDataName, packageUId, entitySchema.UId);
			AddColumnToSchemaData(schemaDataDescriptor, columns, entitySchema);

			var resultMessages = new Collection<ItemValidationMessage>();
			if (!ValidateSchemaData(schemaDataDescriptor, entities, out resultMessages)) {
				return new DataBindingManufacturerResult {
					Success = false,
					ResultMessages = resultMessages
				};
			}

			SaveSchemaData(schemaDataDescriptor, entities, string.Empty);
			return new DataBindingManufacturerResult { Success = true };
		}

		#endregion

	}

	#endregion

}
