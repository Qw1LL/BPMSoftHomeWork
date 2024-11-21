namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SendTemplateRequestSchema

	/// <exclude/>
	public class SendTemplateRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SendTemplateRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SendTemplateRequestSchema(SendTemplateRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1b1f76d4-1295-4ca5-bbc0-4faf38c61644");
			Name = "SendTemplateRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,84,193,78,227,64,12,61,131,196,63,88,225,2,151,228,78,1,9,186,8,237,161,171,138,112,67,168,114,19,39,140,148,100,178,99,135,85,23,241,239,120,38,13,180,165,42,148,75,38,246,248,189,153,247,28,167,193,154,184,197,140,224,122,58,73,109,33,241,216,54,133,41,59,135,98,108,19,143,111,210,137,205,169,226,163,195,151,163,195,131,142,77,83,66,186,96,161,122,180,17,199,119,93,35,166,166,56,37,103,176,50,255,3,131,86,105,221,177,163,82,3,24,87,200,124,6,41,53,249,61,213,109,133,66,119,244,183,35,150,80,150,36,9,156,115,87,215,232,22,151,203,56,64,160,176,14,92,95,9,98,129,149,0,230,40,217,19,216,66,55,50,211,26,106,132,97,190,0,89,18,199,3,97,178,193,120,206,68,88,177,133,204,81,113,17,125,33,60,190,70,38,149,244,108,178,225,174,17,36,158,235,225,23,10,42,74,28,102,242,168,137,182,155,87,38,131,44,220,120,139,70,56,131,207,100,138,83,103,245,249,110,210,212,217,150,156,24,82,167,166,129,178,223,223,116,39,36,110,73,85,171,57,236,87,121,34,160,26,77,5,218,85,198,50,120,240,217,132,62,243,140,85,71,239,225,189,66,189,49,75,83,110,60,203,164,39,137,146,203,21,158,15,88,208,63,161,122,78,238,228,143,126,71,112,1,209,242,220,232,212,251,49,24,178,74,6,195,250,2,37,201,200,223,123,4,175,251,8,108,252,81,218,117,255,190,218,235,239,235,252,130,97,183,194,1,48,243,44,235,58,89,156,31,135,161,235,1,241,99,153,125,31,77,174,159,181,41,12,185,253,36,238,64,239,150,23,128,51,147,175,43,187,237,76,222,183,241,119,254,115,73,162,127,7,239,187,159,94,53,106,63,69,185,58,10,168,99,31,88,134,46,192,63,100,207,39,128,242,109,141,254,252,25,202,214,230,249,177,189,146,109,26,143,117,167,159,208,16,247,217,245,164,230,222,0,98,47,54,253,81,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b1f76d4-1295-4ca5-bbc0-4faf38c61644"));
		}

		#endregion

	}

	#endregion

}

