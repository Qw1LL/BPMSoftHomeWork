namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFastReportDataSourceDataProviderResolverSchema

	/// <exclude/>
	public class IFastReportDataSourceDataProviderResolverSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFastReportDataSourceDataProviderResolverSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFastReportDataSourceDataProviderResolverSchema(IFastReportDataSourceDataProviderResolverSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("63e653b8-2ae5-4d31-aae6-1228169299ce");
			Name = "IFastReportDataSourceDataProviderResolver";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,144,177,14,130,64,12,134,103,72,120,135,38,46,186,240,0,184,169,49,97,192,16,120,130,19,10,94,130,215,75,175,176,24,223,221,147,67,141,147,113,107,255,182,223,223,214,168,43,58,171,26,132,93,89,212,212,73,186,39,211,233,126,100,37,154,76,90,161,37,22,109,250,244,168,156,132,44,137,111,73,156,196,209,138,177,247,61,144,27,65,238,60,35,131,252,211,117,80,162,106,26,185,193,103,84,50,77,186,69,174,208,209,48,33,207,0,59,158,7,221,128,126,205,255,51,30,133,29,222,75,20,40,23,106,93,6,229,12,13,197,159,60,88,128,107,39,236,143,4,187,232,39,255,150,205,118,113,64,211,6,147,57,191,135,219,191,68,175,61,0,161,237,169,129,73,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("63e653b8-2ae5-4d31-aae6-1228169299ce"));
		}

		#endregion

	}

	#endregion

}

