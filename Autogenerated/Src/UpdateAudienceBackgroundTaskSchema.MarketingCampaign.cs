namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: UpdateAudienceBackgroundTaskSchema

	/// <exclude/>
	public class UpdateAudienceBackgroundTaskSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UpdateAudienceBackgroundTaskSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UpdateAudienceBackgroundTaskSchema(UpdateAudienceBackgroundTaskSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fe47ef50-c61a-408b-9310-9543c3f3a000");
			Name = "UpdateAudienceBackgroundTask";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,81,93,75,195,48,20,125,174,224,127,200,99,7,210,31,48,231,192,205,169,123,152,200,58,159,229,46,189,235,66,179,180,222,36,21,17,255,187,183,171,29,107,109,81,104,3,247,227,228,156,156,99,224,128,182,0,137,98,246,188,138,243,157,139,230,185,217,169,212,19,56,149,27,241,121,121,17,120,171,76,218,63,143,86,96,18,82,90,199,72,165,146,120,221,179,78,3,221,232,30,164,203,73,161,29,152,111,192,102,213,140,167,133,223,106,37,133,212,96,173,120,41,18,112,120,235,19,133,70,226,12,100,150,82,238,77,82,237,139,177,88,182,59,147,122,125,3,148,162,107,64,119,224,96,122,37,150,47,22,137,31,100,80,86,175,89,227,155,87,132,9,19,86,239,14,10,82,37,67,69,123,75,188,250,86,93,43,108,36,150,185,74,196,218,155,112,136,86,20,64,108,186,67,178,163,163,189,12,61,117,162,14,213,77,15,25,3,74,32,177,245,58,91,28,64,233,230,242,71,212,5,18,67,230,149,75,181,185,31,209,3,186,201,172,127,117,26,142,234,235,236,187,114,114,47,194,51,29,177,220,227,1,158,184,108,68,6,18,44,10,195,157,124,23,46,74,52,110,52,254,61,56,81,53,195,96,64,103,212,231,207,153,130,81,45,141,241,132,144,253,20,189,76,113,161,213,73,203,31,116,199,221,13,218,255,50,126,85,39,31,221,128,99,116,237,164,194,78,112,237,212,26,15,59,97,114,86,61,233,86,156,252,243,247,13,136,171,149,55,157,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fe47ef50-c61a-408b-9310-9543c3f3a000"));
		}

		#endregion

	}

	#endregion

}

