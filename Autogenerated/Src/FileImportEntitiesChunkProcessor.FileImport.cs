namespace BPMSoft.Configuration.FileImport
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using SystemSettings = BPMSoft.Core.Configuration.SysSettings;

	#region  Class: FileImportEntitiesChunkProcessor

	///<inheritdoc cref="IFileImportEntitiesChunkProcessor"/>
	/// <summary>
	/// Execute import entities by passed parameters.
	/// </summary>
	[DefaultBinding(typeof(IFileImportEntitiesChunkProcessor), Name = nameof(FileImportEntitiesChunkProcessor))]
	public class FileImportEntitiesChunkProcessor : IFileImportEntitiesChunkProcessor
	{

		#region Fields: Private

		private readonly UserConnection UserConnection;
		private readonly IColumnsAggregatorAdapter ColumnsProcessor;
		private IChildImportEntitiesGetter _childImportEntitiesGetter;
		private IChildImportEntitiesSetter _childImportEntitiesSetter;
		private IPrimaryEntityFinder _primaryEntityFinder;
		private bool? _saveInBackgroundMode;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Create instance of <see cref="FileImportEntitiesChunkProcessor"/>
		/// </summary>
		/// <param name="userConnection"></param>
		/// <param name="columnsProcessor"></param>
		public FileImportEntitiesChunkProcessor(UserConnection userConnection, IColumnsAggregatorAdapter columnsProcessor) {
			UserConnection = userConnection;
			ColumnsProcessor = columnsProcessor;
		}

		#endregion

		#region Properties: Private

		private IPrimaryEntityFinder PrimaryEntityFinder
		{
			get {
				if(_primaryEntityFinder is null) {
					var fileImportFactory = ClassFactory.Get<IFileImportFactory>();
					_primaryEntityFinder = fileImportFactory.GetPrimaryEntityFinder(UserConnection, ColumnsProcessor);
				}
				return _primaryEntityFinder;
			}
		}

		private IChildImportEntitiesGetter ChildImportEntitiesGetter => _childImportEntitiesGetter ??
				(_childImportEntitiesGetter = ClassFactory.Get<IChildImportEntitiesGetter>(GetConstructorArguments()));

		private IChildImportEntitiesSetter ChildImportEntitiesSetter => _childImportEntitiesSetter ??
				(_childImportEntitiesSetter = ClassFactory.Get<IChildImportEntitiesSetter>(GetConstructorArguments()));

		private bool SaveInBackgroundMode {
			get {
				if (_saveInBackgroundMode.HasValue) {
					return _saveInBackgroundMode.Value;
				}
				_saveInBackgroundMode = SystemSettings.GetValue(UserConnection, "RunProcessesInBackgroundOnFileImport", false);
				return _saveInBackgroundMode.Value;
			}
		}

		#endregion

		#region Events: Public

		public event EventHandler<ImportEntitySavedEventArgs> ImportEntitySaved;

		public event EventHandler<ImportEntitySaveErrorEventArgs> ImportEntitySaveError;

		#endregion

		#region Methods: Private

		private ConstructorArgument[] GetConstructorArguments() => new[] {
			GetUserConnectionArgument(),
			new ConstructorArgument("columnsProcessor", ColumnsProcessor)
		};

		private IEnumerable<ImportColumn> GetKeyColumns(ImportParameters parameters) => parameters.GetKeyColumns();

		private ConstructorArgument GetUserConnectionArgument() =>
			new ConstructorArgument("userConnection", UserConnection);

		private void InitEntityForSave(ImportParameters parameters, ImportEntity importEntity) {
			importEntity.InitPrimaryEntity(UserConnection, parameters);
			foreach(ImportColumn column in parameters.Columns) {
				ImportColumnValue columnValue = importEntity.FindColumnValue(column);
				if(columnValue == null) {
					continue;
				}
				SetEntityColumnValue(importEntity, column, columnValue);
			}
		}

		private void SetEntityColumnValue(ImportEntity importEntity, ImportColumn column, ImportColumnValue columnValue) {
			foreach(ImportColumnDestination destination in column.Destinations) {
				Entity entity = importEntity.GetEntityForSave(UserConnection, destination);
				string columnValueName = destination.ColumnValueName;
				object valueForSave = ColumnsProcessor.FindValueForSave(destination, columnValue);
				if(valueForSave == null) {
					continue;
				}
				if(entity.StoringState != StoringObjectState.New) {
					object entityValue = entity.GetColumnValue(columnValueName);
					if(valueForSave.Equals(entityValue) || destination.IsKey) {
						continue;
					}
				}
				if(entity.Schema.Columns.GetByName(destination.ColumnName).DataValueType is TextDataValueType) {
					valueForSave = valueForSave.ToString().Trim();
				}
				entity.SetColumnValue(columnValueName, valueForSave);
			}
		}

		private void InitImportEntities(ImportParameters parameters) {
			var keyColumns = GetKeyColumns(parameters);
			PrimaryEntityFinder.LoadPrimaryEntity(parameters, keyColumns);
			var childEntities = ChildImportEntitiesGetter.Get(parameters);
			ChildImportEntitiesSetter.Set(parameters, childEntities);
		}

		private void OnImportEntitySaved(Entity primaryEntity, ImportParameters parameters, uint rowIndex) {
			var args = new ImportEntitySavedEventArgs {
				PrimaryEntity = primaryEntity,
				RootSchemaUId = parameters.RootSchemaUId,
				ImportSessionId = parameters.ImportSessionId,
				ChunkId = parameters.ChunkId,
				RowIndex = rowIndex
			};
			ImportEntitySaved?.Invoke(this, args);
		}

		private void OnImportEntitySaveError(Exception e, ImportEntity importEntity, Guid importSessionId) {
			var eventArgs = new ImportEntitySaveErrorEventArgs {
				Exception = e,
				ImportEntity = importEntity,
				ImportSessionId = importSessionId
			};
			ImportEntitySaveError?.Invoke(this, eventArgs);
		}

		private void SaveImportEntities(ImportParameters parameters) {
			Guid sessionId = parameters.ImportSessionId;
			var entities = parameters.Entities;
			ImportEntity importEntity;
			while((importEntity = entities.FirstOrDefault()) != null) {
				if(importEntity.ImportEntityException != null) {
					OnImportEntitySaveError(importEntity.ImportEntityException, importEntity, sessionId);
					entities.Remove(importEntity);
					continue;
				}
				try {
					InitEntityForSave(parameters, importEntity);
					importEntity.Save(SaveInBackgroundMode);
					OnImportEntitySaved(importEntity.PrimaryEntity, parameters, importEntity.RowIndex);
				} catch(OutOfMemoryException) {
					throw;
				} catch(Exception e) {
					OnImportEntitySaveError(e, importEntity, sessionId);
				} finally {
					entities.Remove(importEntity);
				}
			}
		}

		#endregion

		#region Methods: Public

		///<inheritdoc cref="IFileImportEntitiesChunkProcessor"/>
		public void ProcessChunk(ImportParameters importParameters) {
			if(importParameters.GetIsImportCancelled(UserConnection)) {
				return;
			}
			InitImportEntities(importParameters);
			SaveImportEntities(importParameters);
		}

		#endregion
	}

	#endregion
}
