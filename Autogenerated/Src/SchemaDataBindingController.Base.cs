namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Packages;

	#region Class: DataBindingControllerResult

	/// <summary>
	/// Result for IDataBindingController
	/// </summary>
	public class DataBindingControllerResult
	{

		#region Properties: Public

		/// <summary>
		/// Is binding successful.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// List of <see cref="ItemValidationMessage"/>.
		/// </summary>
		public Dictionary<Guid, Collection<ItemValidationMessage>> ResultMessages { get; set; }


		#endregion

	}

	#endregion

	#region Class: IDataBindingController

	public interface IDataBindingController
	{
		DataBindingControllerResult GenerateBindings(string schemaName, Guid[] recordIds, Guid sysPackageUId);
	}

	#endregion

	#region Class: SchemaDataBindingController

	[DefaultBinding(typeof(IDataBindingController), Name = "SchemaDataBindingController")]
	public class SchemaDataBindingController : IDataBindingController
	{

		#region Fields: Private

		private readonly string _defaultBindingPrefix = "agb";
		private SchemaDataBindingStructureObtainerContext _structureObtainerContext;
		private IDataBindingManufacturer _manufacturer;
		private readonly List<string> _bindedBundles = new List<string>();

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection { get; set; }

		/// <summary>
		/// Structure obtainer context.
		/// </summary>
		protected SchemaDataBindingStructureObtainerContext StructureObtainerContext =>
			_structureObtainerContext ?? (_structureObtainerContext =
				ClassFactory.Get<SchemaDataBindingStructureObtainerContext>(
					new ConstructorArgument("userConnection", UserConnection)));

		/// <summary>
		/// Binding manufacturer.
		/// </summary>
		protected IDataBindingManufacturer Manufacturer =>
			_manufacturer ?? (_manufacturer = ClassFactory.Get<IDataBindingManufacturer>(
				new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Constructor: Public

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public SchemaDataBindingController(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Get current package unique identifier.
		/// </summary>
		/// <returns>Package unique identifier.</returns>
		private Guid GetCurrentPackageUId() {
			var currentPackageUId = Core.Configuration.SysSettings.GetValue(
				UserConnection, "CurrentPackageId", Guid.Empty);
			if (currentPackageUId.IsNotEmpty()) {
				return currentPackageUId;
			}
			return Core.Configuration.SysSettings.GetValue(
				UserConnection, "CustomPackageUId", Guid.Empty);
		}

		private void AddResultMessages(Guid recordId, Collection<ItemValidationMessage> errorMessages, ref DataBindingControllerResult bindingResult) {
			if (bindingResult.ResultMessages.TryGetValue(recordId, out var messagesCollection)) {
				messagesCollection.AddRangeIfNotExists(errorMessages.ToList());
			} else {
				bindingResult.ResultMessages.Add(recordId, errorMessages);
			}
		}

		private void AddResultMessages(Guid recordId, DataBindingControllerResult innerResult, ref DataBindingControllerResult bindingResult) {
			if (innerResult.ResultMessages?.Any() == true) {
				var resultMessages = innerResult.ResultMessages.First();
				AddResultMessages(recordId, resultMessages.Value, ref bindingResult);
			}
		}

		private void AddExceptionToResultMessages(Guid recordId, Exception exception, ref DataBindingControllerResult bindingResult) {
			Collection<ItemValidationMessage> errorMessages = new Collection<ItemValidationMessage>();
			Descriptor descriptor = new PackageSchemaDataDescriptor();
			string exceptionMessage = exception.Message + exception.StackTrace;
			ResultMessage resultMessage = new ResultMessage(MessageType.Error, exceptionMessage);
			ItemValidationMessage errorMessage = new ItemValidationMessage(descriptor, resultMessage);
			errorMessages.Add(errorMessage);
			AddResultMessages(recordId, errorMessages, ref bindingResult);
		}

		/// <summary>
		/// Generate name for data binding.
		/// </summary>
		/// <param name="bindingStructure">Binding structure.</param>
		/// <param name="recordId">Primary record identifier.</param>
		/// <returns>Name for binding to be created or updated.</returns>
		private string GetSchemaDataBindingName(SchemaDataBindingStructure bindingStructure, Guid recordId) {
			if (bindingStructure.IsBundle) {
				return $"{_defaultBindingPrefix}_{bindingStructure.EntitySchemaName}";
			}
			var identifier = recordId.ToString().Replace("-", "");
			return $"{_defaultBindingPrefix}_{bindingStructure.EntitySchemaName}_{identifier}";
		}

		private void AddBindedBundleToList(SchemaDataBindingStructure bindingStructure) {
			if (bindingStructure.IsBundle) {
				_bindedBundles.Add(bindingStructure.EntitySchemaName);
			};
		}

		private bool IsExistInBindedBundleList(SchemaDataBindingStructure bindingStructure) {
			return bindingStructure.IsBundle && _bindedBundles.Contains(bindingStructure.EntitySchemaName);
		}

		private void ClearBindedBundlesList() {
			_bindedBundles.Clear();
		}

		private DataBindingControllerResult CreateEmptySuccessDataBindingControllerResult() {
			return new DataBindingControllerResult {
				Success = true,
				ResultMessages = new Dictionary<Guid, Collection<ItemValidationMessage>>(),
			};
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Build <see cref="EntitySchemaQuery"/> for record binding.
		/// </summary>
		/// <param name="bindingStructure"><see cref="SchemaDataBindingStructure"/>.</param>
		/// <param name="recordId">Primary record identifier.</param>
		/// <returns><see cref="EntitySchemaQuery"/>.</returns>
		protected EntitySchemaQuery GenerateEsq(SchemaDataBindingStructure bindingStructure, Guid recordId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, bindingStructure.EntitySchemaName);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			foreach (var column in bindingStructure.Columns) {
				esq.AddColumn(column.Name);
			}
			if (!bindingStructure.IsBundle) {
				foreach (string columnPath in bindingStructure.FilterColumnPathes) {
					esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
						columnPath, recordId));
				}
				esq.Filters.LogicalOperation = LogicalOperationStrict.Or;
			}
			return esq;
		}

		protected EntityCollection GetEntities(SchemaDataBindingStructure bindingStructure, Guid recordId) {
			var esq = GenerateEsq(bindingStructure, recordId);
			return esq.GetEntityCollection(UserConnection);
		}

		/// <summary>
		/// Get parameters for <see cref="SchemaDataBindingManufacturer"/>.
		/// </summary>
		/// <param name="bindingStructure"><see cref="SchemaDataBindingStructure"/>.</param>
		/// <param name="recordId">Primary record identifier.</param>
		/// <param name="sysPackageUId">Package UId.</param>
		/// <returns></returns>
		protected DataBindingManufacturerParameters GetManufacturerParameters(SchemaDataBindingStructure bindingStructure, Guid recordId, Guid sysPackageUId) {
			return new DataBindingManufacturerParameters {
				Name = GetSchemaDataBindingName(bindingStructure, recordId),
				PackageUId = sysPackageUId,
				EntitySchemaName = bindingStructure.EntitySchemaName,
				Columns = bindingStructure.Columns.Select(column => new DataBindingManufacturerColumn {
					Name = column.Name,
					IsForceUpdate = column.IsForceUpdate,
					IsKey = column.IsKey
				})
			};
		}

		/// <summary>
		/// Bind inner record by structure passed.
		/// </summary>
		/// <param name="innerStructure"><see cref="SchemaDataBindingStructure"/>.</param>
		/// <param name="recordId">Primary record identifier.</param>
		/// <param name="sysPackageUId">Package UId.</param>
		/// <param name="previousResult"><see cref="DataBindingControllerResult"/> from parent binding.</param>
		/// <returns><see cref="DataBindingControllerResult"/> combined parent and inner structure binding result.</returns>
		protected DataBindingControllerResult GenerateInnerStructureBinding(SchemaDataBindingStructure innerStructure, Guid recordId, Guid sysPackageUId,
			DataBindingControllerResult previousResult = null) {
			var innerResult = GenerateHierarchyBinding(innerStructure, recordId, sysPackageUId, previousResult);
			if (innerResult != null) {
				previousResult.Success = previousResult.Success && innerResult.Success;
				AddResultMessages(recordId, innerResult, ref previousResult);
			}
			return previousResult;
		}

		protected DataBindingControllerResult GenerateInnerStructureCollectionBinding(
				List<SchemaDataBindingStructure> innerStructureCollection, Guid recordId, Guid sysPackageUId,
				DataBindingControllerResult previousResult = null) {
			if (innerStructureCollection != null) {
				foreach (var innerStructure in innerStructureCollection) {
					previousResult = GenerateInnerStructureBinding(innerStructure, recordId, sysPackageUId, previousResult);
				}
			}
			return previousResult;
		}

		/// <summary>
		/// Create data bindings for record with its inner structure.
		/// </summary>
		/// <param name="bindingStructure"><see cref="SchemaDataBindingStructure"/>.</param>
		/// <param name="recordId">Primary record identifier.</param>
		/// <param name="sysPackageUId">Package UId.</param>
		/// <param name="previousResult">Data binding controller result</param>
		/// <returns></returns>
		protected DataBindingControllerResult GenerateHierarchyBinding(SchemaDataBindingStructure bindingStructure, Guid recordId,
			Guid sysPackageUId, DataBindingControllerResult previousResult = null) {
			if (previousResult == null) {
				previousResult = CreateEmptySuccessDataBindingControllerResult();
			}
			if (IsExistInBindedBundleList(bindingStructure)) {
				return previousResult;
			}
			var entities = GetEntities(bindingStructure, recordId);
			if (entities.Count == 0) {
				return previousResult;
			}
			var manufacturerParameters = GetManufacturerParameters(bindingStructure, recordId, sysPackageUId);
			previousResult = GenerateInnerStructureCollectionBinding(bindingStructure.DependsStructures, recordId, sysPackageUId, previousResult);
			var bindingResult = Manufacturer.GenerateBinding(entities, manufacturerParameters);
			previousResult.Success = previousResult.Success && bindingResult.Success;
			if (bindingResult.ResultMessages?.Any() == true) {
				AddResultMessages(recordId, bindingResult.ResultMessages, ref previousResult);
			}
			if (previousResult.Success) {
				AddBindedBundleToList(bindingStructure);				
				previousResult = GenerateInnerStructureCollectionBinding(bindingStructure.InnerStructures, recordId, sysPackageUId, previousResult);
			}
			return previousResult;
		}

		/// <summary>
		/// Create bindings for all records passed.
		/// </summary>
		/// <param name="bindingStructure"><see cref="SchemaDataBindingStructure"/>.</param>
		/// <param name="recordIds">Primary record identifiers list.</param>
		/// <param name="sysPackageUId">Package UId.</param>
		protected DataBindingControllerResult GenerateHierarchyBindings(SchemaDataBindingStructure bindingStructure, Guid[] recordIds, Guid sysPackageUId) {
			var bindingResult = CreateEmptySuccessDataBindingControllerResult();
			foreach (var recordId in recordIds) {
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
					DataBindingControllerResult result = null;
					dbExecutor.StartTransaction();
					try {
						result = GenerateHierarchyBinding(bindingStructure, recordId, sysPackageUId);
					} catch (Exception e) {
						dbExecutor.RollbackTransaction();
						ClearBindedBundlesList();
						bindingResult.Success = false;
						AddExceptionToResultMessages(recordId, e, ref bindingResult);
					}
					if (result == null) {
						continue;
					}
					if (result.Success) {
						dbExecutor.CommitTransaction();
					} else {
						dbExecutor.RollbackTransaction();
						ClearBindedBundlesList();
					}
					bindingResult.Success = bindingResult.Success && result.Success;
					AddResultMessages(recordId, result, ref bindingResult);
				}
			}
			ClearBindedBundlesList();
			return bindingResult;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Run data bindings generation.
		/// </summary>
		/// <param name="schemaName">Name of primary schema</param>
		/// <param name="recordIds">Record identifiers list.</param>
		/// <param name="sysPackageUId">Package UId.</param>
		public virtual DataBindingControllerResult GenerateBindings(string schemaName, Guid[] recordIds, Guid sysPackageUId) {
			var bindingStructure = StructureObtainerContext.ObtainStructureByStrategy(schemaName);
			return GenerateHierarchyBindings(bindingStructure, recordIds, sysPackageUId);
		}

		#endregion

	}

	#endregion

}

