namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ChannelInOmniChatLanguageRuleSchema

	/// <exclude/>
	public class ChannelInOmniChatLanguageRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ChannelInOmniChatLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ChannelInOmniChatLanguageRuleSchema(ChannelInOmniChatLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("793788e6-b334-a107-994a-4852353f66cb");
			Name = "ChannelInOmniChatLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,147,193,110,155,64,16,134,207,142,148,119,24,209,139,45,89,112,119,108,164,198,170,34,75,113,235,214,77,239,27,24,240,74,176,75,102,119,93,161,40,239,222,129,5,130,73,148,230,130,152,97,230,155,249,255,93,64,137,18,77,37,18,132,219,195,254,168,51,27,110,181,202,100,238,72,88,169,213,245,213,243,245,213,204,25,169,114,56,214,198,98,121,51,196,175,13,132,239,103,195,111,202,74,43,209,240,103,46,136,162,8,214,198,149,165,160,58,238,226,109,33,140,89,66,69,250,44,83,52,80,8,149,59,145,227,18,50,210,37,252,40,149,220,158,132,5,15,231,87,165,176,8,123,88,52,162,85,238,177,144,9,36,13,176,47,220,169,30,112,223,113,127,185,2,97,5,183,194,224,56,197,253,44,148,159,179,47,132,57,11,7,182,193,88,114,137,213,100,86,112,104,225,190,98,42,195,235,32,20,150,247,151,220,37,20,219,169,51,46,66,132,132,48,219,4,31,238,19,68,113,163,232,173,36,159,169,4,137,18,154,131,218,4,206,32,241,102,10,147,230,116,130,248,129,99,72,134,68,184,142,218,234,182,185,51,228,195,209,243,135,11,32,219,60,14,23,13,102,182,130,71,118,107,62,249,4,207,240,210,57,134,42,245,166,93,58,184,71,123,210,233,103,204,59,76,79,255,127,135,255,25,171,116,215,189,75,131,120,32,97,115,33,107,224,97,252,146,73,164,11,199,90,134,84,39,36,105,83,157,64,52,246,81,159,145,136,27,225,206,201,20,238,112,240,113,151,206,219,212,235,64,54,167,117,238,44,8,208,60,193,6,20,254,133,246,103,168,143,201,9,75,241,211,33,213,19,243,195,113,193,94,40,70,211,18,130,126,247,96,113,51,64,123,159,182,186,112,165,250,206,122,121,6,79,10,191,166,169,207,205,251,43,23,246,107,134,108,196,34,108,106,61,199,79,27,182,238,66,143,97,117,62,158,172,184,28,139,244,152,86,122,191,207,46,101,192,37,177,97,253,174,43,236,246,250,35,10,135,235,166,41,158,191,85,209,49,9,173,35,53,162,182,233,247,175,27,103,95,254,1,250,196,34,57,198,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("793788e6-b334-a107-994a-4852353f66cb"));
		}

		#endregion

	}

	#endregion

}

