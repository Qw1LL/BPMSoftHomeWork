namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: ProjectCopyManager

	/// <summary>
	/// Utilities for copy operations with Project entity.
	/// </summary>
	public class ProjectCopyManager
	{
		#region Fields: Protected

		protected UserConnection UserConnection;

		protected ProjectRepository Repository;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection"></param>
		public ProjectCopyManager(UserConnection userConnection) {
			UserConnection = userConnection;
			Repository = ClassFactory.Get<ProjectRepository>(
				new ConstructorArgument("userConnection", userConnection),
				new ConstructorArgument("shouldSelectOnlyClonableColumns", true));
		}

		#endregion

		#region Methods: Private

		private Dictionary<Guid, Guid> CreateHierarchyKeysMapping(EntityCollection collection, Guid oldProjectId,
			Guid newProjectId) {
			Dictionary<Guid, Guid> result = collection
				.Select(e => e.GetTypedColumnValue<Guid>("ParentProjectId"))
				.Distinct()
				.Where(e => e != Guid.Empty)
				.ToDictionary(e => e, e => oldProjectId.Equals(e) ? newProjectId : Guid.NewGuid());
			if (!result.ContainsKey(oldProjectId)) {
				result[oldProjectId] = newProjectId;
			}
			return result;
		}

		private EntityCollection GetProjectHierarchyAsCollection(Guid projectId) {
			EntityCollection entities = Repository.GetHierarchyCollection(projectId);
			return entities;
		}

		private void ProcessRecords(EntityCollection collection, IEnumerable<IRecordOperationExecutor> processors) {
			foreach (Entity entity in collection) {
				foreach (IRecordOperationExecutor processor in processors) {
					processor.Execute(entity);
				}
				Repository.PrepareToInsert(entity);
			}
			Repository.ExecuteInsert();
		}

		#endregion

		#region Methods: Protected

		protected virtual IEnumerable<IRecordOperationExecutor> GetRecordProcessors(EntityCollection collection,
			Guid projectId, Guid newProjectId) {
			var keysMapping = CreateHierarchyKeysMapping(collection, projectId, newProjectId);
			DateTime rootProjectStartDate = collection.Find(projectId).GetTypedColumnValue<DateTime>("StartDate");
			return new List<IRecordOperationExecutor> {
				new ChangeProjectDateRecordOperationExecutor(rootProjectStartDate),
				new ChangeProjectIdRecordOperationExecutor(keysMapping)
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Copy Project with all subordinate works.
		/// </summary>
		/// <param name="projectId">Project identifier.</param>
		/// <returns>Created project identifier</returns>
		public virtual Guid CopyProjectWithStructure(Guid projectId) {
			projectId.CheckArgumentEmpty("projectId");
			Guid newProjectId = Guid.NewGuid();
			EntityCollection entities = GetProjectHierarchyAsCollection(projectId);
			var processors = GetRecordProcessors(entities, projectId, newProjectId);
			ProcessRecords(entities, processors);
			return newProjectId;
		}

		#endregion
	}

	#endregion
}
