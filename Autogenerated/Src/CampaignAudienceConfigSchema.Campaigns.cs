namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignAudienceConfigSchema

	/// <exclude/>
	public class CampaignAudienceConfigSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignAudienceConfigSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignAudienceConfigSchema(CampaignAudienceConfigSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("639d6364-2acb-4af6-9f5a-465dfd23757f");
			Name = "CampaignAudienceConfig";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bac310da-8f6a-4932-87be-74eb3d9d7067");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,148,203,110,219,48,16,69,215,10,144,127,24,164,155,4,8,172,125,19,167,104,84,160,205,162,133,1,181,31,192,82,35,139,168,68,169,124,212,13,2,255,123,135,47,73,86,29,199,27,195,28,114,206,220,59,28,74,178,14,245,192,56,194,227,230,107,217,215,102,85,244,178,22,91,171,152,17,189,188,188,120,185,188,200,172,22,114,11,229,179,54,216,221,141,235,41,65,33,69,41,254,78,225,150,146,160,104,153,214,239,161,96,221,192,196,86,126,180,149,64,201,49,144,253,201,60,207,225,94,219,174,99,234,249,33,174,125,22,236,26,193,27,224,189,52,76,72,13,3,83,164,208,160,210,80,247,10,184,66,102,16,120,36,3,139,104,208,134,84,172,18,57,159,161,7,251,179,21,28,184,167,191,38,41,35,155,244,59,57,232,165,54,202,114,162,146,145,141,71,132,19,75,229,62,16,14,56,213,41,203,73,249,95,75,136,120,79,32,201,215,250,202,106,84,84,76,34,119,237,190,122,120,34,2,115,134,250,26,76,131,224,246,29,55,30,88,221,231,62,251,56,44,181,229,169,34,80,133,210,136,90,80,122,68,37,239,167,25,26,181,166,66,14,81,134,191,32,70,212,10,190,48,13,21,214,204,182,6,254,176,214,34,204,2,159,173,168,66,244,160,70,188,129,227,189,191,254,113,208,1,111,120,90,222,6,230,100,44,6,70,149,176,78,213,175,221,198,205,13,184,129,205,178,5,117,189,224,186,41,206,178,114,70,25,137,97,43,137,245,123,83,121,191,185,143,179,130,178,10,227,114,56,59,27,213,15,168,140,192,115,38,167,72,131,190,16,236,134,253,183,69,69,148,87,70,41,118,117,145,183,88,190,192,22,205,29,236,79,40,56,118,203,223,16,171,115,30,156,63,178,235,213,47,72,180,157,48,77,234,37,86,238,249,26,193,197,192,164,33,158,234,59,208,68,97,237,27,166,252,29,79,183,115,134,139,34,9,156,217,120,187,68,202,58,175,198,119,209,69,199,238,19,181,163,193,31,90,70,173,158,230,19,240,47,114,235,31,234,201,226,159,168,167,142,246,97,84,80,242,6,43,219,98,229,182,146,24,61,83,180,152,182,16,61,12,238,255,1,119,42,31,81,205,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("639d6364-2acb-4af6-9f5a-465dfd23757f"));
		}

		#endregion

	}

	#endregion

}

