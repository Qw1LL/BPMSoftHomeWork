namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: MultiDeleteWorker

	public class MultiDeleteWorker : BaseRecordsOperationWorker {
			
		#region Constructors: Public

		public MultiDeleteWorker(UserConnection userConnection, IDictionary<string, object> parameters)
				: base(userConnection, parameters) {
			if (parameters.ContainsKey("IsCascade") && (bool)parameters["IsCascade"] == true) {
				OperationExecutor = new RecordDeleterWithStopProcess(userConnection, parameters);
			} else {
				OperationExecutor = new RecordDeleter(userConnection, parameters);
			}
		}

		#endregion
		
		#region Methods: Protected
		
		protected override Entity GetPreparedEntity(Entity entity) {
			return entity;
		}
		
		protected override Exception GetOperationException() {
			RecordDeleter recordDeleter = (RecordDeleter)OperationExecutor;
			return recordDeleter.OperationException;
		}
		
		#endregion
		
	}

	#endregion
	
}

