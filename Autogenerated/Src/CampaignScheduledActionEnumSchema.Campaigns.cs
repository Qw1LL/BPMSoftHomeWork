namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignScheduledActionEnumSchema

	/// <exclude/>
	public class CampaignScheduledActionEnumSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignScheduledActionEnumSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignScheduledActionEnumSchema(CampaignScheduledActionEnumSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ee85b26e-3465-4222-8e7e-6c8dbf431c31");
			Name = "CampaignScheduledActionEnum";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,147,77,75,195,64,16,134,207,9,228,63,12,120,149,166,85,79,98,4,109,61,10,98,14,158,183,187,147,116,161,251,193,126,28,138,248,223,157,108,26,90,73,90,130,199,25,222,125,222,119,102,88,205,20,122,203,56,194,235,199,123,109,154,176,88,27,221,200,54,58,22,164,209,69,254,93,228,69,158,221,56,108,169,132,55,29,213,35,172,153,178,76,182,186,230,59,20,113,143,226,133,247,98,82,150,101,9,79,62,42,197,220,225,249,88,111,144,121,238,228,22,61,176,164,244,208,24,7,252,136,1,33,41,66,32,152,91,12,132,242,12,97,227,118,47,57,32,121,95,182,206,40,104,54,114,79,141,207,168,79,94,125,128,206,103,108,148,117,202,10,150,183,105,146,105,88,29,152,11,51,113,189,182,130,213,117,160,177,179,121,36,173,224,238,42,110,88,12,248,201,164,240,181,195,179,117,36,17,137,233,182,65,42,4,129,141,212,232,7,154,212,39,96,154,102,195,2,118,221,225,14,128,58,200,112,184,20,248,207,91,138,126,63,55,250,196,78,70,201,141,181,115,147,27,251,239,224,105,229,15,212,252,233,127,2,106,209,127,134,174,164,222,47,134,85,207,142,66,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ee85b26e-3465-4222-8e7e-6c8dbf431c31"));
		}

		#endregion

	}

	#endregion

}

