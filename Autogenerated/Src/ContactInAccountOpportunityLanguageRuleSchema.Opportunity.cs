namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactInAccountOpportunityLanguageRuleSchema

	/// <exclude/>
	public class ContactInAccountOpportunityLanguageRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactInAccountOpportunityLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactInAccountOpportunityLanguageRuleSchema(ContactInAccountOpportunityLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0a831195-1dd5-446c-9d0a-2a61dd77a5bb");
			Name = "ContactInAccountOpportunityLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0e987dc8-e3a7-4136-b3d3-af8a5676bbce");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,147,219,106,227,48,16,134,175,83,232,59,12,222,155,4,130,125,159,230,64,27,74,9,108,182,217,30,246,94,145,199,137,192,150,188,35,41,139,89,250,238,59,178,156,99,203,146,27,131,70,154,111,230,255,103,172,69,133,182,22,18,225,97,181,124,53,133,75,231,70,23,106,227,73,56,101,244,237,205,223,219,155,158,183,74,111,224,181,177,14,171,187,195,249,152,64,248,117,52,125,212,78,57,133,150,175,249,193,55,194,13,51,97,94,10,107,71,192,133,156,144,110,161,239,165,52,94,187,231,186,54,228,188,86,174,249,46,244,198,139,13,190,248,18,219,212,44,203,96,108,125,85,9,106,166,221,185,197,12,193,109,133,131,154,204,78,229,104,65,70,40,148,29,1,10,67,112,66,78,247,176,236,132,86,251,117,169,36,200,0,188,182,45,24,193,131,176,120,222,105,143,221,226,239,81,169,209,214,145,151,206,16,11,94,181,101,226,139,75,65,81,17,161,112,44,66,113,150,208,60,19,83,240,35,68,144,132,197,36,185,178,179,36,155,6,149,159,101,198,72,45,72,84,160,121,238,147,196,91,36,166,106,148,97,216,201,244,157,207,193,194,46,144,142,179,246,117,155,220,153,116,101,19,253,247,51,52,156,87,26,4,96,111,4,107,118,176,127,113,5,97,227,122,189,240,249,232,220,68,157,71,67,207,221,93,162,219,154,252,26,99,159,215,78,176,169,199,173,224,93,225,213,44,20,203,45,200,84,135,181,81,26,68,212,245,63,11,149,222,34,41,151,27,9,217,169,55,102,135,68,140,134,39,175,114,120,66,183,119,100,145,247,219,80,40,234,154,23,148,134,242,69,190,151,186,19,4,104,127,195,4,52,254,129,246,159,105,94,229,22,43,241,211,35,53,23,86,166,167,15,150,66,51,158,134,144,156,204,33,25,220,29,184,123,197,115,83,250,74,255,224,169,115,25,46,150,222,231,121,140,245,147,110,146,233,138,84,208,217,77,56,221,55,159,46,242,100,144,134,212,136,141,245,59,45,29,141,181,198,240,69,179,195,75,201,17,65,232,60,233,238,110,22,178,223,154,26,187,134,126,137,210,227,56,248,53,237,127,110,127,0,179,89,235,111,250,88,213,174,105,121,95,239,73,140,158,7,63,254,1,197,0,61,2,240,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0a831195-1dd5-446c-9d0a-2a61dd77a5bb"));
		}

		#endregion

	}

	#endregion

}

