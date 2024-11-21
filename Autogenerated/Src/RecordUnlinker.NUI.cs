namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;
	
	#region Class: RecordUnlinker

	public class RecordUnlinker : BaseRecordExecutor {

		#region Constructors: Public

		public RecordUnlinker(UserConnection userConnection, IDictionary<string, object> parameters)
				: base(userConnection, parameters) {
			RecordRightOperation = SchemaRecordRightLevels.CanEdit;
			RightExceptionMessage = "EntitySchema.Exception.NoRightFor.Update";
		}

		#endregion

		#region Methods: Public
		
		protected override void DeleteOperation() {
			Entity.Save(validateRequired: false);
		}

		#endregion
		
	}

	#endregion
	
}
