namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;

	#region Class: MultiOperationProvider

	/// <summary>
	/// Provider for multiple operations.
	/// </summary>
	public class MultiOperationProvider
	{

		#region Fields: Private

		private readonly IMultiOperationStrategy _strategy;
		private readonly string _entityName;
		private readonly List<Guid> _recordsId;

		#endregion

		#region Constructors: Public

		public MultiOperationProvider(IMultiOperationStrategy strategy, string entityName, List<Guid> recordsId) {
			if (strategy == null) {
				throw new ArgumentNullException("Strategy");
			}
			if (string.IsNullOrEmpty(entityName)) {
				throw new ArgumentNullException("EntityName");
			}
			if (recordsId.IsNullOrEmpty()) {
				throw new ArgumentNullException("RecordsId");
			}
			_strategy = strategy;
			_entityName = entityName;
			_recordsId = recordsId;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Do operation.
		/// </summary>
		public virtual void DoOperation() {
			_strategy.DoOperation(_entityName, _recordsId);
		}

		#endregion

	}

	#endregion

}
