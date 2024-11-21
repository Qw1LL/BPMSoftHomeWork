namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ILanguageRuleSchema

	/// <exclude/>
	public class ILanguageRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ILanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ILanguageRuleSchema(ILanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6e06075a-13a8-4259-bad5-f82e6f51b55b");
			Name = "ILanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a79d048a-6394-421e-9091-4cdc0081ecbf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,145,65,106,195,48,16,69,215,54,248,14,67,178,105,55,214,190,117,189,72,91,130,161,1,147,156,64,182,70,142,192,150,204,72,42,152,146,187,87,150,99,154,144,238,52,95,127,254,60,141,52,31,208,142,188,69,216,213,135,147,145,46,127,55,90,170,206,19,119,202,232,44,253,201,210,196,91,165,59,56,77,214,225,240,154,165,65,97,140,65,97,253,48,112,154,202,107,253,129,182,37,213,160,5,119,70,32,223,135,147,52,4,166,113,92,233,57,129,67,207,117,231,121,135,249,154,193,110,66,70,223,244,170,5,165,29,146,156,145,170,175,171,253,24,194,130,97,102,73,182,132,93,32,131,3,186,179,17,246,5,234,216,22,177,30,184,162,80,147,249,86,34,208,172,211,33,84,218,41,169,144,64,35,138,133,179,24,57,241,129,80,130,14,75,121,219,204,22,55,29,177,53,36,42,177,97,229,12,253,72,189,40,177,247,255,198,242,51,214,64,81,184,153,157,23,44,182,253,165,16,58,79,218,150,235,187,239,205,235,237,108,223,123,37,96,143,110,117,86,226,41,74,247,179,159,151,223,74,182,168,197,178,182,80,93,178,244,242,11,226,161,94,112,247,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6e06075a-13a8-4259-bad5-f82e6f51b55b"));
		}

		#endregion

	}

	#endregion

}

