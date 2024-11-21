namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactInAccountLeadLanguageRuleSchema

	/// <exclude/>
	public class ContactInAccountLeadLanguageRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactInAccountLeadLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactInAccountLeadLanguageRuleSchema(ContactInAccountLeadLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cfdf212a-4f1d-4503-a3e8-25f804f8d198");
			Name = "ContactInAccountLeadLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("df5a8bee-e0f6-4225-b7c8-127f6fd1b1ca");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,147,219,106,227,48,16,134,175,83,232,59,12,222,155,4,130,125,159,230,64,27,74,9,52,221,180,217,238,189,34,141,19,129,45,185,58,164,152,165,239,190,35,203,110,14,45,155,189,49,104,164,249,102,254,127,198,138,149,104,43,198,17,238,86,203,181,206,93,58,215,42,151,91,111,152,147,90,93,95,253,185,190,234,121,43,213,22,214,181,117,88,222,124,158,15,9,6,191,143,166,247,202,73,39,209,210,53,61,248,97,112,75,76,152,23,204,218,17,80,33,199,184,91,168,91,206,181,87,238,17,153,120,100,106,235,217,22,95,124,129,77,78,150,101,48,182,190,44,153,169,167,237,185,201,31,130,219,49,7,149,209,123,41,208,2,143,52,200,141,46,129,69,34,72,5,5,81,161,104,177,96,136,155,118,216,236,136,91,249,77,33,57,240,128,190,216,25,140,224,142,89,60,109,182,71,78,209,247,160,82,43,235,140,231,78,27,18,187,106,248,241,197,185,166,40,202,32,115,164,67,82,22,83,52,15,157,211,35,68,224,6,243,73,114,169,165,36,155,6,93,95,133,197,72,197,12,43,65,209,176,39,137,183,104,8,167,144,135,9,39,211,87,58,7,251,218,64,58,206,154,215,77,114,107,203,165,234,253,215,19,38,156,150,24,4,82,111,4,27,242,172,127,118,5,97,191,122,189,240,249,104,253,67,37,162,133,167,126,46,209,237,180,248,31,43,127,110,28,35,27,15,83,167,5,161,69,204,37,233,108,214,163,219,21,90,143,110,83,154,120,216,149,127,185,40,213,14,141,116,66,115,200,142,237,209,123,52,134,138,192,131,151,2,30,208,117,222,44,68,191,9,133,242,174,126,65,174,141,88,136,78,244,158,25,64,251,6,19,80,248,14,205,191,82,175,249,14,75,246,236,209,212,103,166,166,199,15,150,76,17,222,12,33,9,163,72,6,55,159,192,78,244,92,23,190,84,79,52,113,226,163,125,75,111,133,136,177,126,242,236,89,17,236,16,237,56,211,149,145,65,105,59,230,180,107,63,93,16,58,13,140,200,143,29,180,106,90,44,169,141,225,179,118,135,231,162,35,194,160,243,70,181,119,179,144,253,171,174,176,237,236,55,43,60,142,131,99,211,254,87,29,3,152,205,26,135,211,251,178,114,117,195,251,126,103,98,244,52,248,241,23,250,147,116,192,234,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cfdf212a-4f1d-4503-a3e8-25f804f8d198"));
		}

		#endregion

	}

	#endregion

}

