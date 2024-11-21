namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FastReportDataSourceDataProviderResolverSchema

	/// <exclude/>
	public class FastReportDataSourceDataProviderResolverSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FastReportDataSourceDataProviderResolverSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FastReportDataSourceDataProviderResolverSchema(FastReportDataSourceDataProviderResolverSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("75f557f5-7498-4287-b71f-94807d66eb36");
			Name = "FastReportDataSourceDataProviderResolver";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,81,203,78,195,48,16,60,187,82,255,97,17,151,68,66,249,128,130,56,80,30,226,80,20,53,252,128,113,55,169,165,212,142,214,235,148,8,241,239,216,78,72,225,212,94,44,239,172,103,102,61,107,228,1,93,39,21,194,67,185,169,108,205,197,218,154,90,55,158,36,107,107,138,45,118,150,88,155,166,120,150,142,199,106,185,248,90,46,132,119,1,133,106,112,140,135,219,185,62,169,16,6,138,98,75,26,93,232,135,23,215,132,77,208,132,117,43,157,91,193,73,240,81,178,172,172,39,133,241,86,146,237,245,14,105,139,206,182,61,82,226,118,254,163,213,10,84,164,94,204,132,21,188,94,238,34,194,175,194,57,143,185,65,222,219,93,24,180,76,222,99,115,154,227,172,44,76,186,153,99,138,185,116,19,254,22,242,206,33,230,39,132,174,33,187,74,97,140,65,13,197,59,13,47,200,119,103,213,239,179,191,122,55,96,61,67,47,105,118,201,127,45,4,239,201,30,193,224,17,158,62,21,118,113,167,89,30,215,37,196,119,58,9,217,147,153,153,169,21,58,41,8,52,187,49,139,84,143,232,127,48,96,63,82,52,6,174,66,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("75f557f5-7498-4287-b71f-94807d66eb36"));
		}

		#endregion

	}

	#endregion

}

