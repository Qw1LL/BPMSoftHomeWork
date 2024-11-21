namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignDeduplicatorRuleSchema

	/// <exclude/>
	public class CampaignDeduplicatorRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignDeduplicatorRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignDeduplicatorRuleSchema(CampaignDeduplicatorRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("078983fb-8c59-4207-a217-01b1057fd97c");
			Name = "CampaignDeduplicatorRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,203,106,195,48,16,60,39,144,127,24,200,61,190,55,165,135,186,37,244,208,98,106,242,1,138,181,182,5,150,228,74,171,131,9,253,247,74,114,82,210,7,33,23,177,154,93,205,204,238,202,8,77,126,20,13,225,177,122,173,109,203,155,210,154,86,117,193,9,86,214,172,150,199,213,114,17,188,50,29,234,201,51,233,237,106,25,145,181,163,46,166,81,14,194,251,59,148,66,143,66,117,230,137,100,24,7,213,8,182,238,61,12,148,107,139,162,192,189,15,90,11,55,61,156,238,41,9,41,88,64,91,73,3,184,23,12,229,17,60,73,28,38,52,39,66,200,11,70,208,64,154,12,251,205,153,181,184,160,29,195,33,214,161,73,142,174,24,90,196,134,226,249,221,65,229,236,72,142,21,197,54,170,76,49,231,127,187,206,192,222,168,143,64,80,50,186,80,173,34,7,219,34,197,60,193,55,61,105,145,172,253,245,118,54,183,11,74,226,57,215,215,185,124,255,34,113,68,71,188,133,79,199,231,21,241,74,112,15,182,104,236,16,180,73,81,171,140,196,185,65,242,113,112,215,229,61,187,180,200,50,19,100,186,91,181,223,226,55,65,27,87,192,61,193,197,65,222,36,148,95,253,35,177,38,35,231,241,231,251,140,254,4,35,246,5,69,42,167,94,155,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("078983fb-8c59-4207-a217-01b1057fd97c"));
		}

		#endregion

	}

	#endregion

}

