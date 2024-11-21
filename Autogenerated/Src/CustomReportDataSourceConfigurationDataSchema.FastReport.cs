namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CustomReportDataSourceConfigurationDataSchema

	/// <exclude/>
	public class CustomReportDataSourceConfigurationDataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CustomReportDataSourceConfigurationDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CustomReportDataSourceConfigurationDataSchema(CustomReportDataSourceConfigurationDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2ad081cc-e1d0-4024-aa7a-4cc3d8fe2ee0");
			Name = "CustomReportDataSourceConfigurationData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,84,203,110,219,48,16,60,59,64,254,97,145,94,100,192,208,7,228,225,67,172,52,104,129,184,70,84,244,82,244,64,83,43,155,133,68,10,124,216,117,3,255,123,151,34,29,215,138,141,168,65,14,245,129,48,151,179,59,179,179,164,36,171,209,52,140,35,220,206,30,114,85,218,116,162,100,41,22,78,51,43,148,76,31,177,81,218,10,185,72,63,50,99,195,238,252,236,233,252,108,224,12,69,33,223,24,139,245,85,103,79,69,170,10,185,175,96,210,123,148,168,5,223,99,166,184,182,116,224,201,62,27,37,247,7,123,9,26,137,143,91,165,5,154,151,231,83,39,210,28,245,74,112,124,80,5,86,105,198,44,35,221,86,83,14,193,41,225,131,198,5,177,195,164,98,198,92,194,196,25,171,234,32,223,131,115,229,52,199,131,86,125,184,77,253,158,97,201,92,101,111,133,44,136,53,177,155,6,85,153,124,122,53,123,56,130,41,217,9,55,112,17,248,46,134,63,168,94,227,230,149,224,192,189,146,190,66,224,18,122,136,29,208,28,104,221,55,75,174,90,237,188,111,212,243,172,229,13,136,168,161,39,123,114,239,68,1,162,24,1,149,243,198,75,106,235,121,99,104,154,172,18,191,177,104,155,38,169,115,102,48,241,112,143,27,130,191,29,131,129,213,155,248,111,176,98,26,10,223,213,13,248,129,19,223,10,181,77,51,124,46,245,101,254,147,174,203,117,79,125,153,85,227,164,35,195,223,18,250,205,180,90,137,2,117,28,132,103,77,255,142,69,88,206,151,88,51,179,67,196,109,56,220,2,103,150,47,119,226,237,82,171,53,72,92,195,221,47,142,141,215,144,68,182,173,95,183,113,6,40,139,48,134,195,153,16,121,67,205,210,61,62,58,145,232,233,129,236,39,88,160,189,34,159,105,217,30,160,51,209,190,41,166,55,215,33,113,116,44,20,92,108,253,107,251,162,199,232,106,57,30,195,174,235,72,112,92,121,136,118,130,111,123,78,52,167,54,251,45,47,160,205,237,94,240,255,216,76,243,30,142,118,105,78,185,151,189,192,253,163,83,190,192,55,86,57,252,74,31,183,206,238,180,99,209,223,71,44,81,163,228,24,36,188,98,115,55,41,40,62,149,212,195,58,66,254,1,228,230,71,137,182,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2ad081cc-e1d0-4024-aa7a-4cc3d8fe2ee0"));
		}

		#endregion

	}

	#endregion

}

