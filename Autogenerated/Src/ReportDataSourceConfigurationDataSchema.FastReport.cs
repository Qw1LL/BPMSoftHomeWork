namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ReportDataSourceConfigurationDataSchema

	/// <exclude/>
	public class ReportDataSourceConfigurationDataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportDataSourceConfigurationDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportDataSourceConfigurationDataSchema(ReportDataSourceConfigurationDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("daa9a74a-aaec-4721-8d24-877607029c28");
			Name = "ReportDataSourceConfigurationData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,144,77,106,3,49,12,133,215,51,48,119,16,116,211,66,153,3,36,116,211,148,148,44,82,66,231,4,138,173,12,134,196,54,182,188,8,161,119,175,252,83,202,116,147,110,4,122,250,121,31,207,226,133,162,71,69,240,122,216,79,238,196,227,198,217,147,153,83,64,54,206,142,159,228,93,96,99,231,113,139,145,107,55,244,183,161,239,82,20,21,166,107,100,186,172,135,94,148,135,64,179,220,192,230,140,49,174,160,46,191,33,227,228,82,80,180,120,156,229,114,228,211,241,108,20,224,49,114,64,197,160,242,241,253,91,88,193,238,31,6,157,144,74,253,69,115,86,124,146,98,23,132,240,16,28,147,98,210,117,201,255,180,247,237,31,223,147,209,96,244,51,200,187,156,131,149,28,159,32,231,210,117,59,13,47,50,147,80,164,249,144,129,180,121,94,132,175,6,68,86,87,166,37,160,32,121,146,192,41,227,149,104,26,91,141,169,216,202,255,27,204,196,107,104,207,218,176,161,20,199,229,194,31,183,170,46,69,209,190,1,192,144,50,132,12,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("daa9a74a-aaec-4721-8d24-877607029c28"));
		}

		#endregion

	}

	#endregion

}

