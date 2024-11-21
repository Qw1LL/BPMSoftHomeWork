namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: GetThrottlingScheduleRequestSchema

	/// <exclude/>
	public class GetThrottlingScheduleRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GetThrottlingScheduleRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GetThrottlingScheduleRequestSchema(GetThrottlingScheduleRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("164861d9-449c-4213-a157-80657f43f33a");
			Name = "GetThrottlingScheduleRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,145,49,79,195,48,16,133,231,86,234,127,56,149,5,150,100,111,129,161,41,66,29,138,170,134,13,33,228,58,151,212,82,98,23,223,25,169,84,252,119,206,73,90,40,8,22,91,126,126,247,238,62,219,170,6,105,167,52,194,108,181,204,93,201,73,230,108,105,170,224,21,27,103,147,236,46,95,139,193,89,66,26,13,15,163,225,32,144,177,21,228,123,98,108,146,117,176,108,26,76,114,244,70,213,230,189,45,154,158,92,127,102,46,93,129,53,137,81,172,23,30,43,145,33,171,21,209,4,238,145,31,183,222,49,215,146,144,235,45,22,161,198,53,190,6,36,110,253,105,154,194,53,133,166,81,126,127,219,159,231,138,21,104,103,217,43,205,192,14,42,148,237,20,3,212,231,80,114,12,72,191,37,60,197,242,172,175,126,22,97,23,54,181,209,160,227,68,255,14,4,19,152,41,66,193,127,51,250,107,202,129,60,148,172,39,180,149,119,59,244,108,80,248,86,109,118,119,255,19,165,21,164,31,129,243,64,113,95,204,193,149,103,36,50,36,99,181,143,32,191,73,58,148,37,54,27,244,151,15,242,183,112,3,227,99,201,139,41,198,87,17,239,200,103,44,67,222,95,46,10,56,196,87,155,198,190,83,248,232,1,208,22,29,67,123,238,212,115,81,180,79,168,252,164,121,69,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("164861d9-449c-4213-a157-80657f43f33a"));
		}

		#endregion

	}

	#endregion

}

