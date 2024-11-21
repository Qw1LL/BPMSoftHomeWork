namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;

	#region Class: ChangeProjectIdRecordOperationExecutor

	/// <summary>
	/// Operation to change identifiers in copied project records.
	/// </summary>
	public class ChangeProjectIdRecordOperationExecutor : IRecordOperationExecutor
	{
		#region Fields: Private

		private readonly IDictionary<Guid, Guid> _keyMapping;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="keyMapping">Dictionary with mapping from old to new identifiers.</param>
		public ChangeProjectIdRecordOperationExecutor(IDictionary<Guid, Guid> keyMapping) {
			_keyMapping = keyMapping;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Execute identifier change. 
		/// </summary>
		/// <param name="entity">Project entity</param>
		public void Execute(Entity entity) {
			entity.CheckArgumentNull("entity");
			var selfId = entity.GetTypedColumnValue<Guid>("Id");
			var parentId = entity.GetTypedColumnValue<Guid>("ParentProjectId");
			Guid newParentId, newSelfId;
			if (!_keyMapping.TryGetValue(selfId, out newSelfId)) {
				newSelfId = Guid.NewGuid();
			}
			entity.SetColumnValue("Id", newSelfId);
			if (_keyMapping.TryGetValue(parentId, out newParentId) && parentId != Guid.Empty) {
				entity.SetColumnValue("ParentProjectId", newParentId);
			}
		}

		#endregion
	}

	#endregion
}
