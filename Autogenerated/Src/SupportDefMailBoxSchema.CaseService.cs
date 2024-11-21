namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SupportDefMailBoxSchema

	/// <exclude/>
	public class SupportDefMailBoxSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SupportDefMailBoxSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SupportDefMailBoxSchema(SupportDefMailBoxSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6f94f800-c500-433f-bc1d-fcfd77df71cb");
			Name = "SupportDefMailBox";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77fa8847-960e-4748-ad77-e37bb90e03a0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,147,193,78,195,48,12,134,207,65,218,59,88,229,50,164,169,189,143,109,7,96,32,14,147,38,85,112,69,89,235,142,72,109,82,57,201,216,64,188,59,105,210,142,181,99,28,237,252,182,127,127,73,36,175,80,215,60,67,184,91,175,82,85,152,248,94,201,66,108,45,113,35,148,28,93,125,141,174,152,213,66,110,79,4,132,183,199,108,122,208,6,171,20,141,113,145,134,121,79,214,111,22,59,109,39,116,13,92,139,107,194,173,59,128,251,146,107,61,133,212,214,181,34,243,128,197,138,139,242,78,237,189,40,73,18,152,105,91,85,156,14,139,54,94,147,218,137,28,53,84,78,8,27,181,135,130,84,5,218,155,1,221,14,233,138,147,147,234,218,110,74,145,65,214,76,60,31,8,83,120,254,195,5,107,40,28,221,62,10,44,115,103,119,77,98,199,13,122,147,172,14,1,16,242,92,201,242,0,47,26,201,173,47,49,107,118,135,55,219,139,195,254,236,26,101,30,186,182,113,7,68,73,109,200,102,70,81,51,200,123,14,138,33,13,159,120,150,194,8,94,138,79,4,137,31,32,92,49,151,238,78,85,225,180,136,144,17,22,243,232,108,177,40,57,118,232,49,10,153,154,19,175,64,186,7,50,143,250,230,163,69,179,28,100,199,196,44,241,98,95,219,2,62,27,54,30,0,233,183,188,1,143,152,13,48,185,247,116,198,141,177,239,255,225,173,208,188,171,252,23,27,99,23,193,61,161,1,29,156,250,167,116,225,37,197,255,96,34,52,150,164,94,180,11,119,109,226,89,210,157,156,80,113,151,218,124,26,55,118,220,109,28,84,131,127,20,59,197,43,47,45,206,66,197,98,60,0,51,129,238,58,83,164,157,200,112,217,204,141,38,237,132,120,89,213,230,112,115,137,150,39,18,242,125,136,223,63,241,109,41,149,16,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6f94f800-c500-433f-bc1d-fcfd77df71cb"));
		}

		#endregion

	}

	#endregion

}

