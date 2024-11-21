namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ReportDataSourceConfigurationProviderSchema

	/// <exclude/>
	public class ReportDataSourceConfigurationProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportDataSourceConfigurationProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportDataSourceConfigurationProviderSchema(ReportDataSourceConfigurationProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b9a3794e-b34a-4c43-b274-cc907214da97");
			Name = "ReportDataSourceConfigurationProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6b2e55c4-93df-4e50-a678-d373851bda85");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,83,193,106,2,49,16,61,175,224,63,12,120,217,66,217,15,176,173,208,218,42,30,4,81,123,46,113,51,174,161,107,178,76,18,69,74,255,189,201,166,178,174,202,186,208,30,231,77,222,188,121,51,19,201,182,168,11,150,34,188,204,166,11,181,54,201,80,201,181,200,44,49,35,148,76,230,88,40,50,66,102,201,136,105,19,162,55,153,9,137,221,206,87,183,19,89,237,114,176,56,104,131,219,135,179,56,89,110,8,25,247,228,37,211,159,186,202,183,215,186,198,33,188,68,43,238,43,51,108,161,44,165,152,60,175,180,33,150,250,226,94,220,145,122,132,153,139,96,152,51,173,251,16,88,21,163,214,207,140,212,78,112,164,146,88,216,85,46,82,72,61,175,29,237,113,217,248,204,195,3,232,195,228,86,153,198,42,109,68,6,174,253,104,191,65,66,184,253,218,117,84,122,188,135,201,205,183,174,174,59,1,95,253,56,214,145,192,156,187,185,206,72,236,152,193,144,44,66,0,254,22,148,204,15,80,109,183,42,62,101,146,101,72,240,193,207,161,176,184,168,135,146,7,149,186,164,235,202,45,217,166,70,145,23,46,215,244,171,27,86,214,106,89,241,187,70,114,25,137,229,181,128,173,133,119,224,79,61,138,46,155,131,39,144,184,111,114,20,159,149,242,167,27,125,55,123,154,162,217,40,126,221,142,255,73,255,112,19,48,70,83,131,227,177,21,28,42,131,19,126,116,189,99,116,130,59,199,151,99,72,92,181,74,174,77,3,113,77,169,28,74,68,104,44,201,210,97,50,34,181,157,163,182,185,137,253,128,255,108,248,68,239,174,105,7,1,173,131,14,251,1,249,66,172,2,39,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b9a3794e-b34a-4c43-b274-cc907214da97"));
		}

		#endregion

	}

	#endregion

}

