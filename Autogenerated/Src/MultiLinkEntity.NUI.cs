namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: MultiLinkEntity

	/// <summary>
	/// Strategy of multiple linking records.
	/// </summary>
	public class MultiLinkEntity : IMultiOperationStrategy
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly Dictionary<string, object> _strategyParameters;

		private string _linkedEntityName;
		private string _linkedColumnName;
		private string _columnName;
		private Guid _linkedRecordId;

		#endregion

		#region Constructors: Public

		public MultiLinkEntity(UserConnection userConnection, Dictionary<string, object> strategyParameters) {
			_userConnection = userConnection;
			_strategyParameters = strategyParameters;
		}

		#endregion

		#region Methods: Protected

		protected virtual void PrepareParameters(Dictionary<string, object> parameters) {
			_linkedEntityName = parameters.GetValue<string>("LinkedEntityName", string.Empty);
			_linkedColumnName = parameters.GetValue<string>("LinkedColumnName", string.Empty);
			_columnName = parameters.GetValue<string>("ColumnName", string.Empty);
			Guid.TryParse(parameters.GetValue<string>("LinkedRecordId", string.Empty), out _linkedRecordId);
			if (_linkedEntityName.IsNullOrEmpty()) {
				throw new ArgumentEmptyException("LinkedEntityName");
			}
			if (_linkedColumnName.IsNullOrEmpty()) {
				throw new ArgumentEmptyException("LinkedColumnName");
			}
			if (_linkedRecordId.IsEmpty()) {
				throw new ArgumentEmptyException("LinkedRecordId");
			}
			if (_columnName.IsNullOrEmpty()) {
				throw new ArgumentEmptyException("ColumnName");
			}
		}

		/// <summary>
		/// Connects entities by <paramref name="recordsId"/>.
		/// </summary>
		/// <param name="recordsId">Unique identifiers.</param>
		protected virtual void Connect(List<Guid> recordsId) {
			EntitySchema entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(_linkedEntityName);
			foreach (Guid recordId in recordsId) {
				Entity entity = entitySchema.CreateEntity(_userConnection);
				entity.SetDefColumnValues();
				entity.SetColumnValue(_linkedColumnName, _linkedRecordId);
				entity.SetColumnValue(_columnName, recordId);
				entity.Save(validateRequired: false);
			}
		}

		#endregion


		#region Methods: Public

		/// <summary>
		/// Do operation on <paramref name="entityName"/> <paramref name="recordsId"/>.
		/// </summary>
		/// <param name="entityName">Name of entity.</param>
		/// <param name="recordsId">Unique identifiers.</param>
		public virtual void DoOperation(string entityName, List<Guid> recordsId) {
			PrepareParameters(_strategyParameters);
			Connect(recordsId);
		}

		#endregion

	}

	#endregion

}
