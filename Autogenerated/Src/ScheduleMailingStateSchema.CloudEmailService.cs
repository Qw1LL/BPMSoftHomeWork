namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ScheduleMailingStateSchema

	/// <exclude/>
	public class ScheduleMailingStateSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ScheduleMailingStateSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ScheduleMailingStateSchema(ScheduleMailingStateSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("196c6b02-4784-4c5a-9831-b4fc6e589e4f");
			Name = "ScheduleMailingState";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b39fd9cb-6840-4142-8022-7c9d0489d323");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,81,77,75,3,49,16,61,111,161,255,97,232,169,189,116,239,218,46,104,89,181,96,69,220,163,120,72,179,179,221,64,54,89,102,146,126,40,254,119,103,91,90,139,160,136,8,73,32,51,239,189,153,121,227,84,131,220,42,141,112,253,184,40,124,21,198,51,239,42,179,138,164,130,241,174,223,123,235,247,146,200,198,173,160,216,113,192,230,178,223,147,72,27,151,214,104,208,86,49,67,161,107,44,163,197,133,50,86,128,69,80,1,225,2,206,191,66,233,132,142,60,191,70,34,83,34,220,70,83,62,191,192,213,90,176,106,105,241,198,83,190,69,29,187,218,29,49,50,50,76,51,8,53,249,13,56,220,192,131,15,243,166,181,216,160,11,88,230,91,141,109,7,30,142,14,141,37,45,249,128,90,82,159,69,56,80,215,127,78,228,105,129,204,106,133,197,62,52,243,146,253,47,245,181,80,238,245,235,95,149,211,52,133,9,199,166,81,180,203,142,129,131,23,98,65,168,13,75,37,113,114,124,2,167,95,209,19,194,16,201,113,54,119,2,117,178,83,95,137,38,34,104,194,106,58,56,95,200,201,229,39,228,104,195,32,205,198,147,244,200,255,102,210,31,248,112,167,92,105,197,86,108,231,50,31,57,101,135,35,216,175,60,249,157,7,73,242,46,143,92,57,31,93,59,112,102,149,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("196c6b02-4784-4c5a-9831-b4fc6e589e4f"));
		}

		#endregion

	}

	#endregion

}

