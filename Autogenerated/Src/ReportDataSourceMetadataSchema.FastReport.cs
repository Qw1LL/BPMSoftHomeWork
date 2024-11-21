namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ReportDataSourceMetadataSchema

	/// <exclude/>
	public class ReportDataSourceMetadataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportDataSourceMetadataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportDataSourceMetadataSchema(ReportDataSourceMetadataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0f7879a2-86ee-4454-873c-c2e2e1511084");
			Name = "ReportDataSourceMetadata";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,143,65,10,131,48,16,69,215,10,222,97,160,123,15,80,119,181,180,116,97,145,218,11,164,58,74,64,147,144,76,22,34,189,123,199,164,20,132,210,110,6,254,207,155,63,63,74,76,232,140,104,17,14,117,213,232,158,242,82,171,94,14,222,10,146,90,229,55,52,218,146,84,67,126,18,142,162,202,210,37,75,19,239,216,133,102,118,132,83,145,165,236,236,44,14,188,3,229,40,156,219,67,132,143,130,68,163,189,109,177,66,18,29,171,192,26,255,24,101,11,237,138,254,32,19,190,196,243,19,93,91,109,144,251,32,231,215,33,34,190,191,227,206,94,118,112,233,96,129,1,169,0,183,142,231,134,112,100,215,218,87,254,246,127,234,62,155,47,84,232,131,170,139,149,130,142,219,91,147,189,23,253,159,129,220,93,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0f7879a2-86ee-4454-873c-c2e2e1511084"));
		}

		#endregion

	}

	#endregion

}

