namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignFireTimeConfigSchema

	/// <exclude/>
	public class CampaignFireTimeConfigSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignFireTimeConfigSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignFireTimeConfigSchema(CampaignFireTimeConfigSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b9223c62-28e8-4dfe-acbc-1c6c34636529");
			Name = "CampaignFireTimeConfig";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,219,106,195,48,12,125,78,97,255,32,218,247,228,125,151,194,214,181,99,131,65,33,251,1,215,81,18,143,196,14,150,67,27,202,254,125,178,211,100,93,187,149,237,197,88,199,242,209,145,116,180,168,145,26,33,17,30,214,175,169,201,93,188,48,58,87,69,107,133,83,70,95,77,246,87,147,168,37,165,11,72,59,114,88,223,140,241,215,7,139,241,66,212,141,80,133,142,151,186,173,137,147,56,109,102,177,96,14,88,84,130,232,26,134,148,149,178,248,166,106,236,11,133,204,36,73,224,150,218,186,22,182,155,31,226,240,11,92,41,28,72,163,157,80,154,160,17,150,245,58,180,4,185,177,64,178,196,172,173,16,52,238,56,235,192,15,239,102,19,15,164,201,17,107,211,110,42,37,65,6,226,223,212,68,220,48,159,163,248,181,53,13,90,167,144,59,88,7,130,254,253,84,114,0,94,204,6,200,9,235,192,49,101,12,207,154,35,205,195,53,57,39,35,130,180,152,223,77,31,133,11,53,167,201,220,11,61,87,58,72,29,18,33,28,126,21,81,84,160,243,59,136,34,58,92,62,46,8,74,29,239,17,139,46,140,235,72,193,207,187,91,85,102,251,132,26,249,143,177,35,236,209,148,39,93,139,241,237,88,248,8,66,209,223,144,128,165,145,239,153,13,211,16,100,216,160,206,24,208,188,78,197,91,236,71,218,93,238,125,40,223,151,94,238,80,182,222,145,99,71,231,200,254,255,243,185,151,158,161,119,89,134,72,210,170,13,235,223,250,152,109,4,84,154,182,202,32,51,12,41,87,130,24,93,246,119,241,222,161,217,161,208,105,124,89,242,140,199,214,219,48,196,61,250,29,100,236,19,168,169,246,70,195,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b9223c62-28e8-4dfe-acbc-1c6c34636529"));
		}

		#endregion

	}

	#endregion

}

