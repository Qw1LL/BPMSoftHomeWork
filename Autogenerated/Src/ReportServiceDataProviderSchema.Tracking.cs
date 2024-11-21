namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ReportServiceDataProviderSchema

	/// <exclude/>
	public class ReportServiceDataProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportServiceDataProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportServiceDataProviderSchema(ReportServiceDataProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4bdab04d-2ff8-4619-bc00-3e7bdcd86548");
			Name = "ReportServiceDataProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,83,77,111,156,48,16,61,19,41,255,97,180,185,128,20,193,189,201,174,212,108,171,42,135,166,171,144,244,90,57,48,172,172,130,141,198,246,74,171,40,255,189,99,27,178,129,148,229,0,204,248,205,199,123,51,86,162,67,211,139,10,225,110,247,179,212,141,205,183,90,53,114,239,72,88,169,85,254,68,162,250,43,213,254,242,226,245,242,34,113,134,127,161,60,26,139,221,205,187,125,138,36,60,121,189,21,115,193,58,24,211,204,12,100,232,21,225,158,13,216,182,194,152,47,48,86,251,38,172,216,145,62,200,26,41,224,138,162,128,91,227,186,78,208,113,51,216,3,0,164,106,52,117,33,41,52,164,59,32,236,53,89,48,72,7,89,97,62,134,23,31,226,123,247,210,202,10,42,95,22,30,3,190,140,240,143,165,97,169,163,132,197,224,247,123,251,124,210,35,89,137,204,97,71,242,32,44,70,192,188,239,224,136,250,113,127,214,114,102,3,138,103,0,204,1,94,132,193,89,247,224,168,245,12,62,83,72,250,88,8,140,37,175,119,100,241,181,174,9,141,41,135,220,15,62,245,122,3,171,145,71,68,61,83,187,138,3,72,174,80,213,145,197,57,74,218,98,101,177,142,144,89,225,63,52,230,188,89,164,252,248,137,20,28,68,235,112,145,218,80,112,74,142,75,248,83,191,137,73,178,71,27,190,209,74,100,3,105,4,231,247,230,193,181,237,47,250,222,245,246,152,158,218,203,178,8,29,34,146,211,201,176,161,113,65,115,158,207,168,95,254,3,237,111,223,104,250,204,189,243,185,226,182,88,158,235,101,185,179,252,73,151,161,145,52,11,130,240,67,104,29,169,185,82,73,242,22,63,216,26,156,182,118,62,32,188,223,206,207,143,123,101,57,92,101,53,249,9,134,125,63,179,147,219,19,28,116,3,34,94,141,133,241,4,79,47,72,116,97,119,215,43,55,17,103,181,185,231,100,66,241,160,57,213,84,184,252,182,8,129,113,204,241,22,46,222,191,153,232,48,45,147,241,245,244,55,38,157,187,95,225,255,218,68,239,212,201,190,127,66,255,82,241,3,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4bdab04d-2ff8-4619-bc00-3e7bdcd86548"));
		}

		#endregion

	}

	#endregion

}

