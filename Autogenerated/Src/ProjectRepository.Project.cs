namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Factories;

	#region Class: ProjectRepository

	/// <summary>
	/// Repository for Project entity.
	/// </summary>
	public class ProjectRepository
	{

		#region Constants: Private

		private const string ProjectSchemaName = "Project";
		private const string ProjectIdParameterName = "ProjectId";
		private const string GuidTypeName = "Guid";

		#endregion

		#region Field: Protected

		protected UserConnection UserConnection;

		protected EntitySchema SchemaInstance;

		protected List<Entity> InsertQueue;

		protected bool ShouldSelectOnlyClonableColumns;

		#endregion

		#region Fields: Public

		private RightsHelper _rightHelper;
		public RightsHelper RightHelper => _rightHelper ?? (_rightHelper = ClassFactory.Get<RightsHelper>(new ConstructorArgument("userConnection", 
			UserConnection.AppConnection.SystemUserConnection)));

		#endregion

		#region Constructors: Public

		public ProjectRepository(UserConnection userConnection, bool shouldSelectOnlyClonableColumns) {
			UserConnection = userConnection;
			InsertQueue = new List<Entity>();
			SchemaInstance = userConnection.EntitySchemaManager.FindInstanceByName("Project");
			ShouldSelectOnlyClonableColumns = shouldSelectOnlyClonableColumns;
		}

		#endregion

		#region Methods: Private

		private HierarchicalSelectOptions GetSelectOptions(Guid projectId) {
			var hierarhicalOptions = new HierarchicalSelectOptions {
				PrimaryColumnName = "Id",
				ParentColumnName = "ParentProjectId",
				SelectType = HierarchicalSelectType.Children,
				IncludeLevelColumn = true
			};
			QueryCondition startingCondition = hierarhicalOptions.StartingPrimaryColumnCondition;
			startingCondition.LeftExpression = new QueryColumnExpression("Id");
			startingCondition.IsEqual(new QueryParameter(ProjectIdParameterName, projectId, GuidTypeName));
			return hierarhicalOptions;
		}

		#endregion

		#region Methods: Protected

		protected virtual IList<string> GetSelectColumns() {
			IEnumerable<EntitySchemaColumn> columns = SchemaInstance.Columns;
			if (ShouldSelectOnlyClonableColumns) {
				columns = columns.Where(e => e.IsValueCloneable || e.Name == "Id");
			}
			var columnNames = columns.Select(e => e.ColumnValueName).ToList();
			return columnNames;
		}

		protected virtual Select GetProjectBaseSelect(Guid projectId, IList<string> columns) {
			Select select = new Select(UserConnection).From("Project");
			foreach (string column in columns) {
				select = select.Column("Project", column).As(column);
			}
			return select;
		}

		protected virtual (Entity entity, int level) ProcessReaderRowWithLevel(IDataReader reader, 
			IList<string> columns) {
			Entity entity = SchemaInstance.CreateEntity(UserConnection);
			foreach (string column in columns) {
				entity.SetColumnValue(column, reader.GetColumnValue(column));
			}
			return (entity, reader.GetColumnValue<int>("Level"));
		}
		
		[Obsolete("Method is deprecated, use BPMSoft.Configuration.ProjectRepository.ProcessReaderRowWithLevel")]
		protected virtual Entity ProcessReaderRow(IDataReader reader,
			IList<string> columns) {
			Entity entity = SchemaInstance.CreateEntity(UserConnection);
			foreach (string column in columns) {
				entity.SetColumnValue(column, reader.GetColumnValue(column));
				entity.ForceSetColumnValue("Level", reader.GetColumnValue<int>("Level"));
			}
			return entity;
		}

		protected virtual void SetCopiedRecordRights(Entity entity) {
			var recordRecordId = entity.GetTypedColumnValue<string>("Id");
			RightHelper.SetRecordRight(UserConnection.CurrentUser.Id, ProjectSchemaName, recordRecordId,
				(int)EntitySchemaRecordRightOperation.Read, (int)EntitySchemaRecordRightLevel.AllowAndGrant);
			RightHelper.SetRecordRight(UserConnection.CurrentUser.Id, ProjectSchemaName, recordRecordId,
				(int)EntitySchemaRecordRightOperation.Edit, (int)EntitySchemaRecordRightLevel.AllowAndGrant);
			RightHelper.SetRecordRight(UserConnection.CurrentUser.Id, ProjectSchemaName, recordRecordId,
				(int)EntitySchemaRecordRightOperation.Delete, (int)EntitySchemaRecordRightLevel.AllowAndGrant);
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(ProjectSchemaName);
			UserConnection.DBSecurityEngine.AddDefRights(Guid.Parse(recordRecordId), entitySchema);
		}

		protected virtual void SetCopiedRecordsRights() {
			foreach (var entity in InsertQueue) {
				SetCopiedRecordRights(entity);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get project with all subordinate works.
		/// </summary>
		/// <param name="projectId">Project identifier</param>
		public virtual EntityCollection GetHierarchyCollection(Guid projectId) {
			IList<string> columns = GetSelectColumns();
			Select select = GetProjectBaseSelect(projectId, columns);
			select.HierarchicalOptions = GetSelectOptions(projectId);
			Dictionary<Entity, int> entityDictionary = new Dictionary<Entity, int>();
			select.ExecuteReader(reader => {
				var entityRecord = ProcessReaderRowWithLevel(reader, columns);
				entityDictionary.Add(entityRecord.entity, entityRecord.level);
			});
			EntityCollection result = new EntityCollection(UserConnection, SchemaInstance);
			entityDictionary = entityDictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
			entityDictionary.ForEach(item=>result.Add(item.Key));
			return result;
		}

		/// <summary>
		/// Store item in queue before insert.
		/// </summary>
		/// <param name="entity">Project entity</param>
		public virtual void PrepareToInsert(Entity entity) {
			InsertQueue.Add(entity);
		}

		/// <summary>
		/// Insert all items in queue.
		/// </summary>
		public virtual void ExecuteInsert() {
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				try {
					foreach (Entity entity in InsertQueue) {
						entity.Save(false);
						SetCopiedRecordRights(entity);
					}
				} catch (DbOperationException exception) {
					throw;
				}
			}
			InsertQueue.Clear();
		}

		#endregion
	}

	#endregion
}
