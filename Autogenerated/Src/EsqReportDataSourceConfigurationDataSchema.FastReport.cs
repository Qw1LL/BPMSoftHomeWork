namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EsqReportDataSourceConfigurationDataSchema

	/// <exclude/>
	public class EsqReportDataSourceConfigurationDataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EsqReportDataSourceConfigurationDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EsqReportDataSourceConfigurationDataSchema(EsqReportDataSourceConfigurationDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7b8fabd5-6170-498c-b58a-d959035f2847");
			Name = "EsqReportDataSourceConfigurationData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,84,75,79,227,48,16,62,7,137,255,48,98,47,169,84,229,7,240,232,1,90,208,34,209,237,18,180,151,21,7,215,153,180,94,165,118,240,131,110,65,252,119,198,113,74,32,180,74,4,151,36,182,103,190,151,167,149,108,133,166,100,28,225,124,118,147,170,220,38,23,74,230,98,225,52,179,66,201,228,22,75,165,173,144,139,228,146,25,27,86,135,7,207,135,7,145,51,180,11,233,198,88,92,157,180,214,4,82,20,200,61,130,73,174,80,162,22,188,169,153,226,218,210,129,39,187,54,74,54,7,141,4,141,196,199,173,210,2,205,231,243,169,19,73,138,250,81,112,188,81,25,22,201,152,89,70,186,173,166,30,42,167,134,31,26,23,196,14,23,5,51,230,24,38,230,33,104,247,149,169,114,154,227,7,159,126,187,234,251,59,198,156,185,194,158,11,153,17,101,108,55,37,170,60,254,217,217,61,24,194,148,178,132,51,56,154,164,191,143,6,247,4,86,186,121,33,56,112,175,161,151,4,56,134,30,50,35,138,159,158,141,71,10,211,106,231,227,34,171,179,138,52,84,212,2,250,80,199,87,78,100,32,178,33,16,150,15,91,146,155,183,133,161,27,100,133,120,194,172,242,74,58,231,204,96,236,203,125,221,0,252,68,68,145,213,155,250,43,74,249,18,87,204,80,30,254,142,137,238,17,181,77,198,248,134,244,107,254,143,38,228,116,44,170,49,97,122,115,26,184,134,94,110,37,180,66,24,141,226,22,185,159,135,40,122,1,206,44,95,110,233,236,82,171,53,72,92,195,228,63,199,210,67,198,219,74,255,124,169,35,67,153,133,212,62,70,56,211,170,36,125,52,109,59,3,236,20,9,91,187,207,176,64,123,2,187,233,194,110,107,243,243,164,54,184,85,65,123,138,222,31,183,71,161,195,71,125,155,213,160,214,74,205,59,185,61,221,210,143,219,173,228,8,194,219,236,66,250,174,241,0,221,97,127,91,244,181,16,102,204,210,244,236,15,129,104,254,176,194,225,29,253,3,180,86,251,187,106,236,91,204,81,163,228,24,132,118,228,221,110,10,190,246,53,245,136,150,42,95,1,164,224,38,25,216,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7b8fabd5-6170-498c-b58a-d959035f2847"));
		}

		#endregion

	}

	#endregion

}

