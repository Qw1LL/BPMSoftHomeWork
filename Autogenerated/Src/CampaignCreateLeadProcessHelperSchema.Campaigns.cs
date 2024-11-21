namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignCreateLeadProcessHelperSchema

	/// <exclude/>
	public class CampaignCreateLeadProcessHelperSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignCreateLeadProcessHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignCreateLeadProcessHelperSchema(CampaignCreateLeadProcessHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7c1f6025-2ed1-42c2-928b-a879e96e8221");
			Name = "CampaignCreateLeadProcessHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2def6958-6e0c-463c-8c46-5a65b8967369");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,84,219,142,155,48,16,125,78,165,254,195,136,188,36,18,130,190,47,139,212,166,237,150,118,187,138,148,94,30,43,7,38,169,91,176,209,216,236,42,138,242,239,29,48,215,44,109,145,44,204,248,204,153,153,51,99,148,40,208,148,34,69,120,179,253,188,211,7,27,108,180,58,200,99,69,194,74,173,224,252,242,197,162,50,82,29,97,119,50,22,139,155,171,111,134,231,57,166,53,214,4,119,168,144,100,58,96,6,78,194,121,107,176,75,127,98,86,229,72,124,206,136,178,218,231,50,5,99,57,124,10,105,46,140,129,141,40,74,33,143,106,67,40,44,222,163,200,182,164,83,52,230,3,230,37,82,147,227,162,94,37,201,71,70,64,202,201,88,230,160,58,90,231,93,251,53,12,154,62,234,253,3,215,189,21,214,34,41,184,5,111,6,244,227,252,234,226,221,116,212,97,24,66,100,170,162,16,116,138,59,195,178,123,186,93,111,113,27,232,45,211,215,114,25,244,156,225,53,105,84,10,18,5,40,78,240,214,171,12,18,55,68,57,133,189,248,89,196,225,25,91,130,40,108,88,230,73,115,46,114,103,177,76,50,47,78,178,198,15,188,17,139,247,111,119,43,232,136,54,81,7,61,244,126,148,89,75,2,45,115,253,53,236,199,105,14,98,140,195,77,7,224,81,203,12,92,223,199,45,90,125,157,232,2,83,153,124,184,171,216,109,40,211,135,228,157,170,10,36,177,207,49,250,132,167,111,34,175,184,253,146,162,26,233,240,113,12,115,149,173,221,120,45,218,105,50,39,149,182,227,195,115,227,140,193,123,77,133,176,171,255,78,154,11,20,60,224,83,253,94,173,215,205,120,45,222,202,38,18,15,65,228,8,125,208,251,95,28,62,134,70,23,100,95,195,209,20,62,193,223,177,171,46,211,197,25,188,251,161,197,254,72,8,184,248,61,228,203,92,27,253,89,13,224,210,120,93,92,186,175,203,178,191,180,253,245,77,138,2,51,201,109,106,175,38,23,190,26,105,229,15,87,140,99,244,251,103,55,154,15,93,130,211,142,6,223,53,253,110,126,83,129,99,187,58,222,84,68,168,108,61,21,45,96,16,206,137,92,87,192,235,242,7,227,42,22,92,240,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7c1f6025-2ed1-42c2-928b-a879e96e8221"));
		}

		#endregion

	}

	#endregion

}

