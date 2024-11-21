namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: HierarchicalRecords

	public class HierarchicalRecords
	{

		#region Fields: Private

		private string _entitySchemaName;

		private string _parentColumnName;

		private UserConnection _userConnection;

		#endregion Fields: Private

		#region Constructors: Public

		public HierarchicalRecords(UserConnection userConnection, string entitySchemaName, string parentColumnName) {
			_userConnection = userConnection;
			_entitySchemaName = entitySchemaName;
			_parentColumnName = parentColumnName;
		}

		#endregion Constructors: Public

		#region Methods: Private

		/// <summary>
		/// Get entity from DB by id 
		/// </summary>
		/// <param name="elementId"></param>
		/// <returns>Return entity</returns>
		private Entity GetEntity(Guid elementId) {
			EntitySchema schema = _userConnection.EntitySchemaManager.GetInstanceByName(_entitySchemaName);
			Entity entity = schema.CreateEntity(_userConnection);
			entity.FetchFromDB(elementId);
			return entity;
		}

		#endregion Methods: Private

		#region Methods: Public

		/// <summary>
		/// Check if parent element in hierarchy of his parent.
		/// </summary>
		/// <param name="childId"></param>
		/// <param name="parentId"></param>
		/// <returns><c>true</c> if element in hierarchy</returns>
		public bool HasParentInBranch(Guid childId, Guid parentId) {
			Guid currentId = parentId;
			List<Guid> checkedIds = new List<Guid> {
				currentId
			};
			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				while (true) {
					Select currentElementSelect = new Select(_userConnection)
						.Column(_parentColumnName)
						.From(_entitySchemaName).Where("Id").IsEqual(Column.Parameter(currentId)) as Select;
					using (IDataReader reader = currentElementSelect.ExecuteReader(dbExecutor)) {
						if (reader.Read()) {
							if (reader.IsDBNull(reader.GetOrdinal(_parentColumnName))) {
								return false;
							} else {
								Guid currentElementParentId = reader.GetColumnValue<Guid>(_parentColumnName);
								if (currentElementParentId.Equals(childId)) {
									return true;
								}
								if (checkedIds.Contains(currentElementParentId)) {
									string LocalizableString = new LocalizableString(_userConnection.Workspace.ResourceStorage,
										"HierarchicalRecordsHelper", "LocalizableStrings.HierarchicalErrorMessage.Value");
									throw new LoopInHierarchyException(LocalizableString);
								} else {
									checkedIds.Add(currentElementParentId);
									currentId = currentElementParentId;
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Set parent element to current element
		/// </summary>
		/// <param name="childId"></param>
		/// <param name="parentId"></param>
		public void ChangeParent(Guid childId, Guid parentId) {
			Entity entity = GetEntity(childId);
			entity.SetColumnValue(_parentColumnName, parentId);
			entity.Save();
		}

		/// <summary>
		/// Remove parent element from current
		/// </summary>
		/// <param name="childId"></param>
		public void RemoveParent(Guid parentId) {
			Entity entity = GetEntity(parentId);
			entity.SetColumnValue(_parentColumnName, null);
			entity.Save();
		}

		#endregion Methods: Public
	}

	#endregion Class: HierarchicalRecords

	#region Class: LoopInHierarchyException

	public class LoopInHierarchyException : Exception
	{
		public LoopInHierarchyException() {
		}
		public LoopInHierarchyException(string message)
			: base(message) {
		}
	}

	#endregion Class: LoopInHierarchyException

}
