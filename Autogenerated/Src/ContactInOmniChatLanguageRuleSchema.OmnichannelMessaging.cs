namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactInOmniChatLanguageRuleSchema

	/// <exclude/>
	public class ContactInOmniChatLanguageRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactInOmniChatLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactInOmniChatLanguageRuleSchema(ContactInOmniChatLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ba21deee-aa7e-5f17-8481-2cba8316ae86");
			Name = "ContactInOmniChatLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,147,81,107,219,48,16,199,159,83,232,119,56,188,151,4,130,253,158,38,134,53,140,18,88,182,108,89,251,174,90,231,68,96,75,217,73,202,48,165,223,125,103,203,118,29,167,148,190,24,223,249,238,119,247,255,75,214,162,68,123,18,25,194,253,110,187,55,185,139,215,70,231,234,224,73,56,101,244,237,205,203,237,205,196,91,165,15,176,175,172,195,242,174,143,223,26,8,223,207,198,223,180,83,78,161,229,207,92,144,36,9,44,173,47,75,65,85,218,198,235,66,88,59,135,19,153,179,146,104,161,16,250,224,197,1,231,144,147,41,225,103,169,213,250,40,28,4,56,239,230,68,230,226,14,150,12,104,39,255,92,168,12,178,26,216,21,110,116,7,248,222,114,127,251,2,97,1,247,194,226,48,197,253,44,148,159,147,47,132,7,22,94,19,172,35,159,57,67,118,1,187,6,30,42,198,50,130,14,66,225,120,127,197,93,66,179,157,38,231,34,68,200,8,243,85,244,225,62,81,146,214,138,174,37,133,204,73,144,40,65,243,65,173,34,111,145,152,165,49,171,79,39,74,31,57,134,172,79,196,203,164,169,110,154,91,67,62,28,61,125,188,0,178,205,195,112,86,99,38,11,120,102,183,166,163,79,240,2,175,173,99,168,101,48,237,210,193,45,186,163,145,159,49,111,55,62,253,203,195,159,95,159,254,103,188,50,109,251,70,70,105,127,143,176,190,145,21,240,52,126,201,21,210,133,101,13,67,233,35,146,114,210,100,144,12,141,52,103,36,226,70,120,240,74,194,3,246,70,110,228,180,73,189,13,100,119,26,235,206,130,0,237,95,88,129,198,127,208,252,13,213,62,59,98,41,126,121,164,106,228,126,60,44,216,10,205,104,154,67,212,237,30,205,238,122,104,103,212,218,20,190,212,63,88,47,207,224,73,241,87,41,67,110,218,221,185,184,91,51,102,35,102,113,93,27,56,97,90,191,117,27,6,12,171,11,241,104,197,249,80,100,192,52,210,187,125,54,146,1,151,196,154,245,167,58,97,187,215,147,40,60,46,235,166,116,122,173,162,101,18,58,79,122,64,109,210,239,223,55,206,190,254,7,110,97,169,120,198,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba21deee-aa7e-5f17-8481-2cba8316ae86"));
		}

		#endregion

	}

	#endregion

}

