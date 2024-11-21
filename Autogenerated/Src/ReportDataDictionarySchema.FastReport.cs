namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ReportDataDictionarySchema

	/// <exclude/>
	public class ReportDataDictionarySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportDataDictionarySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportDataDictionarySchema(ReportDataDictionarySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c199853d-7f4a-40ab-afca-865c27583e7a");
			Name = "ReportDataDictionary";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,65,106,195,48,16,60,39,144,63,8,122,73,33,248,1,105,240,161,73,91,114,40,13,241,177,244,176,150,215,65,69,150,140,180,134,186,165,127,239,218,106,237,58,49,38,23,225,29,207,206,206,172,100,160,64,95,130,68,113,127,120,78,108,78,209,214,154,92,157,42,7,164,172,137,142,88,90,71,202,156,162,71,240,20,170,197,252,107,49,159,85,158,81,145,212,158,176,184,59,171,89,68,107,148,141,130,143,158,208,160,83,242,130,115,172,12,169,2,163,132,255,130,86,159,237,64,102,49,239,198,225,137,11,177,213,224,253,90,132,177,59,32,216,169,86,20,92,221,242,94,187,222,84,227,27,3,101,149,106,37,133,108,250,70,219,196,90,244,197,198,147,99,67,43,177,127,48,85,129,174,81,217,236,143,8,217,139,209,245,8,207,166,239,156,42,142,99,30,197,59,224,179,183,202,81,201,85,146,172,99,199,7,103,137,153,152,5,82,249,87,142,122,90,14,54,176,55,185,21,254,28,89,137,132,28,66,193,54,120,18,225,7,9,127,6,220,114,182,20,60,46,71,154,47,185,205,21,206,190,127,51,160,201,66,140,201,76,237,110,23,33,80,216,243,104,154,206,199,112,200,84,139,50,36,36,240,51,84,84,119,237,61,112,173,204,232,133,103,221,103,167,252,31,154,216,67,64,135,32,99,63,180,212,155,146,51,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c199853d-7f4a-40ab-afca-865c27583e7a"));
		}

		#endregion

	}

	#endregion

}

