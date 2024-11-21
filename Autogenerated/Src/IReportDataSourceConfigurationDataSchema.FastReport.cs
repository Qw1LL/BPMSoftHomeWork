namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IReportDataSourceConfigurationDataSchema

	/// <exclude/>
	public class IReportDataSourceConfigurationDataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IReportDataSourceConfigurationDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IReportDataSourceConfigurationDataSchema(IReportDataSourceConfigurationDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0c43a542-85de-4648-9651-f6d4fe333f34");
			Name = "IReportDataSourceConfigurationData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,143,193,10,131,48,12,134,207,19,124,135,128,119,31,96,222,230,216,240,176,33,243,9,50,141,165,160,109,105,211,195,144,189,251,162,133,129,59,237,18,200,151,252,127,254,24,156,41,56,236,9,78,237,173,179,35,151,181,53,163,86,209,35,107,107,202,7,57,235,89,27,85,94,48,112,234,242,108,201,179,67,12,66,161,123,5,166,185,202,51,33,133,39,37,26,168,39,12,225,8,77,218,62,35,99,103,163,239,105,231,188,226,77,229,226,115,210,61,104,195,228,199,53,200,63,186,131,36,144,250,61,217,122,235,72,114,146,220,109,55,195,52,191,70,61,64,51,192,2,138,184,130,119,162,129,253,154,253,46,191,255,76,10,50,67,178,220,250,68,247,80,216,7,212,57,14,139,53,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0c43a542-85de-4648-9651-f6d4fe333f34"));
		}

		#endregion

	}

	#endregion

}

