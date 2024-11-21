namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CloudDataResponseSchema

	/// <exclude/>
	public class CloudDataResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CloudDataResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CloudDataResponseSchema(CloudDataResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("db4128e4-39dd-4160-97b6-b20928a12b20");
			Name = "CloudDataResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,193,78,131,64,16,61,211,164,255,48,193,11,189,192,93,161,137,86,99,76,172,105,218,163,241,176,93,166,116,19,216,37,187,139,166,154,254,187,179,11,53,180,216,166,23,96,223,206,188,247,230,13,146,85,104,106,198,17,30,22,243,149,218,216,120,166,228,70,20,141,102,86,40,57,30,253,140,71,65,99,132,44,96,181,51,22,43,186,47,75,228,238,210,196,207,40,81,11,126,119,90,179,108,164,21,21,198,43,186,101,165,248,246,92,84,69,117,55,26,11,58,192,172,100,198,220,210,75,53,249,35,179,108,73,54,136,18,125,81,146,36,144,154,166,170,152,222,77,187,243,147,36,165,45,112,37,45,227,22,176,196,10,165,53,4,28,252,196,135,206,164,215,250,238,200,105,38,171,169,235,131,128,186,89,151,130,3,119,250,255,201,7,52,49,61,255,140,46,180,170,81,91,129,228,118,225,123,219,251,83,143,29,128,8,92,227,38,11,91,191,78,153,132,95,40,149,16,146,41,8,250,48,80,10,99,157,219,161,221,214,239,28,171,53,234,232,141,150,3,25,132,57,65,225,196,153,63,184,127,37,130,116,160,48,5,215,12,110,101,65,80,160,117,123,9,2,211,125,236,187,185,80,230,237,104,199,115,18,143,177,186,225,86,233,147,73,59,205,65,86,209,164,147,242,170,25,72,252,58,103,44,154,92,99,97,142,118,171,242,107,114,190,207,115,3,105,205,52,171,40,108,144,20,84,22,186,108,67,202,216,170,254,30,156,57,135,94,200,220,35,158,172,207,52,189,184,76,183,75,10,140,73,142,113,154,248,102,207,213,133,245,169,68,238,92,70,131,78,255,11,244,147,139,93,153,7,207,101,212,97,199,177,237,127,1,214,137,197,248,187,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("db4128e4-39dd-4160-97b6-b20928a12b20"));
		}

		#endregion

	}

	#endregion

}

