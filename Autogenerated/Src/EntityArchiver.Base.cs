namespace BPMSoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using System.Linq;
	using BPMSoft.Core.DB;

	[Obsolete("7.12.2 | Interface is obsolete and will be removed in upcoming releases.")]
	#region Interface: IArchivingEntity

	public interface IArchivingEntity
	{

		/// <summary>
		/// Schema name.
		/// </summary>
		string SchemaName {
			get;
			set;
		}

		/// <summary>
		/// History schema name.
		/// </summary>
		string HistorySchemaName {
			get;
			set;
		}

		/// <summary>
		/// Indicates this schema is referenced schema.
		/// </summary>
		bool GetIsReferencedSchema();

		/// <summary>
		/// User connection.
		/// </summary>
		UserConnection UserConnection {
			get;
			set;
		}

		/// <summary>
		/// Column names.
		/// </summary>
		IList<string> ColumnNames {
			get;
			set;
		}

		/// <summary>
		/// Insert archiving data command.
		/// </summary>
		IDBCommand InsertSelectCommand {
			get;
		}

		/// <summary>
		/// Delete archiving data command.
		/// </summary>
		IDBCommand DeleteCommand {
			get;
		}

	}

	#endregion

	[Obsolete("7.12.2 | Class is obsolete and will be removed in upcoming releases. Use BPMSoft.Configuration.SysProcessLogArchiver instead.")]
	#region Class: EntityArchiever

	public class EntityArchiever : IEntityArchiver
	{

		#region Fields: Private

		private readonly ArchivingEntitySet _entitySet;
		private readonly DBExecutor _dbExecutor;

		#endregion

		#region Constructors: Public

		public EntityArchiever(DBExecutor dbExecutor, ArchivingEntitySet entitySet) {
			_entitySet = entitySet;
			_dbExecutor = dbExecutor;
		}

		#endregion

		#region Methods: Private

		private void HistorizeEntities(bool hasCascade) {
			using (_dbExecutor) {
				try {
					_dbExecutor.StartTransaction();
					InsertArchivingData(_entitySet.Entities);
					if (hasCascade) {
						DeleteReferencedEntityData(_entitySet.Entities);
					} else {
						DeleteAllEntitiesData(_entitySet.Entities);
					}
					_dbExecutor.CommitTransaction();
				} catch (Exception exception) {
					_dbExecutor.RollbackTransaction();
					throw exception;
				}
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual void InsertArchivingData(IEnumerable<IArchivingEntity> entities) {
			foreach (IArchivingEntity entity in entities) {
				entity.InsertSelectCommand.Execute(_dbExecutor);
			}
		}

		protected virtual void DeleteReferencedEntityData(IEnumerable<IArchivingEntity> entities) {
			IArchivingEntity referencedEntity = entities.FirstOrDefault(e => e.GetIsReferencedSchema());
			if (referencedEntity == null) {
				throw new EntityArchivingException("Referenced entity should be specified");
			}
			referencedEntity.DeleteCommand.Execute(_dbExecutor);
		}

		protected virtual void DeleteAllEntitiesData(IEnumerable<IArchivingEntity> entities) {
			foreach (IArchivingEntity entity in entities.Reverse()) {
				entity.DeleteCommand.Execute(_dbExecutor);
			}
		}

		#endregion

		#region Custom: IEntityArchiver Members

		/// <summary>
		/// Archieves entity records.
		/// </summary>
		public void Archive() {
			HistorizeEntities(true);
		}

		#endregion

	}

	#endregion

	[Obsolete("7.12.2 | Class is obsolete and will be removed in upcoming releases")]
	#region Class: ArchivingEntitySet

	public class ArchivingEntitySet
	{

		#region Constructors: Public

		public ArchivingEntitySet() {
			Entities = new List<IArchivingEntity>();
		}

		public ArchivingEntitySet(IEnumerable<IArchivingEntity> entities) {
			Entities = new List<IArchivingEntity>(entities);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Collection of archieving entities.
		/// </summary>
		public IList<IArchivingEntity> Entities {
			get;
			protected set;
		}

		#endregion

	}

	#endregion

	[Obsolete("7.12.2 | Class is obsolete and will be removed in upcoming releases")]
	#region Class: EntityArchivingException

	public class EntityArchivingException : System.Exception
	{

		#region Constructors: Public

		public EntityArchivingException(string message)
			: base(message) {
		}

		#endregion

	}

	#endregion

}

