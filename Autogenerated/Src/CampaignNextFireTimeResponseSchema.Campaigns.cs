namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignNextFireTimeResponseSchema

	/// <exclude/>
	public class CampaignNextFireTimeResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignNextFireTimeResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignNextFireTimeResponseSchema(CampaignNextFireTimeResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("33b2b06a-b8c5-4d45-827a-16cf4cc3cdd4");
			Name = "CampaignNextFireTimeResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,146,77,79,195,48,12,134,207,157,196,127,176,198,5,36,180,222,249,58,48,132,196,97,211,196,38,14,32,14,105,230,182,65,77,82,57,137,96,32,254,59,78,218,110,108,66,218,165,74,92,231,245,99,191,54,66,163,107,133,68,184,91,204,150,182,244,147,169,53,165,170,2,9,175,172,57,25,125,159,140,178,224,148,169,96,185,113,30,245,213,193,125,242,20,140,87,26,39,75,36,37,26,245,149,222,237,178,118,178,90,255,31,39,228,40,199,79,9,43,126,10,211,70,56,119,9,83,161,91,161,42,51,199,79,255,160,8,87,92,228,137,89,173,113,152,242,243,60,135,107,23,180,22,180,185,237,239,12,239,73,72,15,165,37,160,62,27,68,97,131,7,217,11,130,97,69,40,89,18,18,248,32,149,255,209,122,189,23,94,12,98,111,28,104,67,209,40,9,50,178,29,65,203,120,100,252,221,246,179,32,219,34,121,133,220,212,34,201,116,255,15,249,83,96,233,41,78,135,176,101,122,52,62,77,19,108,201,153,136,32,9,203,155,49,179,165,146,227,252,22,62,106,37,107,80,70,54,97,141,142,15,220,184,238,30,29,237,58,21,92,213,202,29,150,115,181,13,205,26,10,4,91,120,161,12,174,161,36,171,119,208,120,136,18,199,245,44,154,128,171,77,187,91,5,60,179,197,59,74,127,1,49,231,197,26,124,100,190,115,230,30,164,162,77,210,18,113,18,180,130,210,102,40,195,99,86,12,179,101,220,179,166,243,102,134,186,64,58,155,243,250,194,13,140,99,115,131,19,227,243,104,216,224,152,235,6,250,215,42,136,59,157,101,21,250,184,142,89,230,250,195,79,239,27,154,117,103,93,186,119,209,253,224,207,47,88,185,156,25,55,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("33b2b06a-b8c5-4d45-827a-16cf4cc3cdd4"));
		}

		#endregion

	}

	#endregion

}

