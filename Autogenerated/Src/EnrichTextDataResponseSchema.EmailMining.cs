namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EnrichTextDataResponseSchema

	/// <exclude/>
	public class EnrichTextDataResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EnrichTextDataResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EnrichTextDataResponseSchema(EnrichTextDataResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("292254cb-473a-40ba-91c0-ffcaaa382dcd");
			Name = "EnrichTextDataResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,193,78,227,48,16,61,7,137,127,24,133,75,123,73,238,208,86,2,118,65,72,116,85,209,189,173,56,24,103,210,90,56,118,100,79,186,203,174,248,247,29,59,6,165,45,237,178,151,200,158,188,121,126,243,230,25,209,160,111,133,68,184,90,204,151,182,166,226,218,154,90,173,58,39,72,89,115,122,242,231,244,36,235,188,50,43,88,190,120,194,230,98,231,206,120,173,81,6,176,47,110,209,160,83,114,15,243,208,25,82,13,22,75,254,43,180,250,29,185,25,197,184,51,135,43,190,192,181,22,222,159,195,87,195,253,235,239,248,139,190,8,18,15,172,141,121,49,34,203,178,132,137,239,154,70,184,151,89,186,247,112,32,198,67,197,13,128,26,27,52,228,65,190,203,42,222,122,203,65,243,143,64,207,163,146,19,146,30,185,208,118,79,90,73,144,65,198,65,21,25,187,193,223,119,209,11,103,91,116,164,144,149,47,34,65,255,127,87,106,42,32,130,116,88,79,243,158,63,60,207,175,223,177,67,57,148,51,80,124,240,160,149,167,32,121,95,115,47,122,142,205,19,186,209,55,94,28,76,33,15,83,231,227,48,193,219,8,247,76,48,217,158,32,60,49,131,112,130,176,207,44,91,33,133,37,101,153,79,135,215,35,194,239,173,125,238,90,216,8,221,161,7,91,131,144,210,242,70,61,208,90,16,56,212,188,207,13,2,89,118,61,142,244,31,250,107,102,170,46,19,225,193,65,18,160,159,227,102,216,242,143,129,206,208,84,253,178,182,55,199,222,123,114,157,36,235,118,118,151,30,255,56,2,163,113,122,47,122,57,5,131,63,15,250,61,26,127,70,200,28,105,109,171,207,228,231,178,170,60,76,90,225,68,195,33,2,195,6,78,243,144,153,156,179,195,222,15,242,21,52,132,234,145,44,197,74,36,27,50,205,142,134,52,100,148,109,19,70,98,49,41,99,115,228,74,150,109,172,170,130,202,209,190,25,49,219,67,239,138,128,139,197,67,38,165,218,182,111,175,127,1,34,35,69,1,176,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("292254cb-473a-40ba-91c0-ffcaaa382dcd"));
		}

		#endregion

	}

	#endregion

}

