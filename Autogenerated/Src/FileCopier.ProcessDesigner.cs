namespace BPMSoft.Configuration
{
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Interface: IFileCopier

	/// <summary>
	/// Provides methods for the copying files. 
	/// </summary>
	public interface IFileCopier
	{

		/// <summary>
		/// Copies an existing file to a new file.
		/// </summary>
		/// <param name="sourceEntity">The entity of the file to copy.</param>
		/// <param name="targetEntity">The destination entity of the file.</param>
		void Copy(Entity sourceEntity, Entity targetEntity);
	}

	#endregion

	#region Class: FileCopier

	/// <inheritdoc />
	[DefaultBinding(typeof(IFileCopier))]
	public class FileCopier : IFileCopier
	{

		#region Methods: Private

		private static bool GetIsLoadedColumnValue(EntityColumnValue sourceEntityColumnValue) {
			return sourceEntityColumnValue?.IsLoaded == true;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public void Copy(Entity sourceEntity, Entity targetEntity) {
			sourceEntity.CheckArgumentNull(nameof(sourceEntity));
			targetEntity.CheckArgumentNull(nameof(targetEntity));
			UserConnection userConnection = sourceEntity.UserConnection;
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			EntitySchema sourceSchema = entitySchemaManager.GetInstanceByUId(sourceEntity.Schema.UId);
			EntitySchemaColumnCollection sourceSchemaColumns = sourceSchema.Columns;
			EntitySchemaColumn dataSchemaColumn = sourceSchemaColumns.GetByName("Data");
			EntityColumnValue sourceEntityColumnValue = sourceEntity
				.FindEntityColumnValue(dataSchemaColumn.ColumnValueName);
			bool result = GetIsLoadedColumnValue(sourceEntityColumnValue);
			if (!result) {
				Entity sourceEntityNew = sourceSchema.CreateEntity(userConnection);
				sourceEntityNew.PrimaryColumnValue = sourceEntity.PrimaryColumnValue;
				result = sourceEntityNew.FetchFromDB(new[] { dataSchemaColumn.Name }, false);
				sourceEntityColumnValue = sourceEntityNew.FindEntityColumnValue(dataSchemaColumn.ColumnValueName);
				result = result && sourceEntityColumnValue?.IsLoaded == true;
			}
			if (result) {
				targetEntity.SetBytesValue(dataSchemaColumn.ColumnValueName, sourceEntityColumnValue.StreamBytes);
			}
		}

		#endregion

	}

	#endregion

}

