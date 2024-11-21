namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFastReportDataSourceDataProviderSchema

	/// <exclude/>
	public class IFastReportDataSourceDataProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFastReportDataSourceDataProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFastReportDataSourceDataProviderSchema(IFastReportDataSourceDataProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("871baf4c-f2ae-497e-a62e-ab72c52c22b2");
			Name = "IFastReportDataSourceDataProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,81,65,106,195,48,16,60,59,144,63,44,228,210,66,240,3,210,144,67,27,26,124,8,49,113,250,0,197,94,59,106,28,201,236,74,5,83,250,247,174,37,90,145,158,122,17,218,89,205,236,236,200,168,27,242,160,106,132,231,114,95,217,214,229,47,214,180,186,243,164,156,182,38,63,226,96,201,105,211,229,175,138,93,172,230,179,207,249,44,243,44,40,84,35,59,188,9,169,239,177,158,24,156,239,208,32,233,250,233,239,155,211,133,80,53,147,212,73,241,149,83,63,77,38,20,84,240,5,97,39,90,80,24,135,212,138,187,21,20,105,254,86,57,85,89,79,53,78,183,146,236,135,110,144,2,113,240,231,94,215,160,127,120,255,161,101,178,141,156,191,67,247,232,46,182,225,21,148,65,44,54,39,203,235,164,179,213,97,89,69,227,6,118,24,160,135,55,70,146,240,76,204,1,252,93,185,132,226,40,219,31,76,63,38,238,154,29,73,0,75,176,231,119,121,182,129,65,145,252,135,120,231,199,24,68,182,64,211,68,95,161,254,138,241,220,129,130,125,3,126,115,243,140,198,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("871baf4c-f2ae-497e-a62e-ab72c52c22b2"));
		}

		#endregion

	}

	#endregion

}

