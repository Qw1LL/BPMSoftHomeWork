namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ReportDataSourceConfigurationSchema

	/// <exclude/>
	public class ReportDataSourceConfigurationSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportDataSourceConfigurationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportDataSourceConfigurationSchema(ReportDataSourceConfigurationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("46cfbe19-cf35-44dc-b6c8-28814e8be6f8");
			Name = "ReportDataSourceConfiguration";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6b2e55c4-93df-4e50-a678-d373851bda85");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,203,110,194,48,16,60,7,137,127,88,169,23,42,161,124,0,47,137,66,139,114,160,141,74,127,192,36,75,112,21,236,200,118,168,34,196,191,119,237,0,33,45,132,92,44,237,120,118,118,246,33,216,14,117,198,34,132,151,112,185,146,27,227,207,164,216,240,36,87,204,112,41,252,79,204,164,50,92,36,254,27,211,166,140,94,69,194,5,118,59,135,110,199,203,53,253,193,170,208,6,119,195,63,49,73,165,41,70,86,71,251,11,20,168,120,84,113,218,215,251,159,83,177,230,204,176,149,204,85,132,254,116,173,141,98,167,114,22,167,60,202,124,82,152,16,4,179,148,105,61,128,50,181,74,171,149,119,9,89,190,78,121,4,145,229,55,211,71,95,141,223,22,158,192,0,130,187,213,60,239,103,139,10,225,177,14,201,56,67,125,8,30,114,73,151,86,99,213,47,189,211,72,140,202,35,35,21,141,32,116,13,150,140,83,179,141,154,189,22,246,98,122,158,193,94,132,231,57,96,236,32,187,58,239,120,50,131,34,46,253,212,205,133,74,102,72,219,196,219,214,22,57,143,161,42,29,196,48,158,184,216,15,226,97,141,73,45,218,35,169,184,239,116,220,23,182,13,234,252,22,109,185,231,0,9,154,33,28,107,201,180,6,22,127,136,180,152,115,119,114,76,21,163,210,64,31,228,250,155,206,126,2,33,83,84,212,160,210,103,141,76,241,61,51,8,250,74,240,222,92,150,104,182,50,190,61,148,189,164,161,76,179,44,45,170,26,189,54,150,178,11,253,188,173,43,147,227,171,239,134,205,149,104,29,36,236,23,18,46,190,112,75,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("46cfbe19-cf35-44dc-b6c8-28814e8be6f8"));
		}

		#endregion

	}

	#endregion

}

