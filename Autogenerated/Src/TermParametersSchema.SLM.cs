namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TermParametersSchema

	/// <exclude/>
	public class TermParametersSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TermParametersSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TermParametersSchema(TermParametersSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cce52b8e-5cff-471e-bee8-6f28959e4246");
			Name = "TermParameters";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,148,219,106,227,48,16,134,175,19,200,59,76,111,74,23,138,205,94,55,9,236,134,82,74,41,132,166,237,189,34,79,178,2,89,50,51,82,193,44,125,247,202,242,33,118,210,116,183,39,176,193,210,252,51,250,191,97,44,207,202,108,97,85,178,195,252,98,50,246,189,101,178,176,90,163,116,202,26,78,174,208,32,41,25,36,147,177,17,57,114,33,36,194,239,229,237,202,110,92,80,154,141,218,122,18,149,56,89,33,61,41,137,247,72,249,100,252,119,50,30,165,105,10,83,246,121,46,168,156,55,235,42,10,133,160,80,203,33,113,210,202,210,158,174,240,107,173,36,72,45,152,99,194,178,211,135,104,85,121,84,144,122,18,14,129,93,56,91,2,161,200,172,209,37,40,227,224,86,153,123,149,227,131,81,238,81,104,143,48,131,159,17,96,116,224,40,110,44,132,70,147,9,2,149,161,113,106,163,144,42,91,135,190,90,99,87,94,101,93,214,117,6,209,209,104,139,238,34,126,112,243,241,124,244,196,29,15,108,44,5,247,92,132,102,35,100,21,146,20,90,122,93,183,244,77,27,55,88,70,190,165,80,52,109,237,112,210,178,159,87,205,152,195,93,83,60,158,201,159,246,202,86,251,202,218,183,120,93,53,197,255,233,245,168,219,59,116,158,12,131,251,35,220,206,235,110,222,64,80,112,109,137,194,128,31,113,28,119,168,174,51,255,21,228,195,50,220,165,79,211,86,213,3,93,91,171,225,154,23,181,102,8,116,246,163,65,170,243,246,112,147,122,88,231,179,131,1,126,31,117,55,77,159,163,238,101,191,3,120,56,109,251,192,195,232,87,1,187,225,149,242,17,216,253,18,255,73,28,36,175,131,30,239,199,233,233,27,211,17,130,189,107,229,100,22,111,154,228,50,47,92,217,253,165,225,13,207,11,192,218,198,34,192,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cce52b8e-5cff-471e-bee8-6f28959e4246"));
		}

		#endregion

	}

	#endregion

}

