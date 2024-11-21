namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactInLeadLanguageRuleSchema

	/// <exclude/>
	public class ContactInLeadLanguageRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactInLeadLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactInLeadLanguageRuleSchema(ContactInLeadLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dd37686f-0318-45bd-ba58-4b312c10abb5");
			Name = "ContactInLeadLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("df5a8bee-e0f6-4225-b7c8-127f6fd1b1ca");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,77,111,219,48,12,134,207,41,208,255,64,120,151,4,8,236,123,154,15,172,65,81,4,104,182,126,172,187,43,22,157,8,176,37,143,146,50,24,67,255,251,40,203,105,18,183,25,118,17,32,138,124,200,247,165,180,168,208,214,34,71,184,125,92,191,152,194,165,75,163,11,181,245,36,156,50,250,250,234,207,245,213,192,91,165,183,240,210,88,135,213,205,251,253,88,64,248,121,52,189,211,78,57,133,150,159,57,225,11,225,150,153,176,44,133,181,19,224,70,78,228,110,165,31,80,200,7,161,183,94,108,241,217,151,216,38,103,89,6,83,235,171,74,80,51,239,238,109,225,24,220,78,56,168,201,236,149,68,11,121,196,128,210,80,50,8,202,142,4,196,168,244,64,202,78,80,181,223,148,42,135,60,208,46,79,1,19,184,21,22,207,7,27,176,29,124,30,165,24,109,29,249,220,25,98,69,143,45,56,102,244,231,143,2,8,133,227,153,21,87,9,205,166,155,130,147,16,33,39,44,102,201,197,89,146,108,30,148,124,148,18,35,181,32,81,129,230,85,206,18,111,145,152,163,49,15,251,75,230,175,124,15,30,117,129,116,154,181,217,109,113,103,196,197,182,195,215,51,24,156,179,71,1,49,152,192,134,93,26,246,158,32,124,155,193,32,28,111,157,99,168,101,52,237,220,193,53,186,157,145,255,99,222,247,141,19,108,220,113,193,188,126,254,95,133,98,129,5,153,170,255,19,254,229,152,210,59,36,229,164,201,33,59,181,194,236,145,136,185,112,239,149,132,123,116,7,59,86,114,216,134,66,71,215,60,99,110,72,174,228,65,231,94,16,160,253,5,51,208,248,27,218,95,223,188,228,59,172,196,147,71,106,122,62,166,167,9,107,161,25,79,99,72,130,251,201,232,230,29,120,208,185,52,165,175,244,55,222,46,243,185,75,250,85,202,24,27,38,79,94,148,193,1,14,180,218,211,195,188,233,138,89,105,40,138,192,216,178,27,191,227,176,188,24,238,205,55,238,171,140,8,66,231,73,119,111,139,80,253,163,169,67,231,48,202,79,81,122,156,6,139,230,195,143,131,143,96,177,104,45,77,239,170,218,53,45,239,243,127,17,163,231,193,183,191,29,211,166,79,165,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dd37686f-0318-45bd-ba58-4b312c10abb5"));
		}

		#endregion

	}

	#endregion

}

