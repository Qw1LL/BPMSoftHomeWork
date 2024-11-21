namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LanguageInContactLanguageRuleSchema

	/// <exclude/>
	public class LanguageInContactLanguageRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LanguageInContactLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LanguageInContactLanguageRuleSchema(LanguageInContactLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e2c80707-56d1-485c-9153-61f3c4d5fd6c");
			Name = "LanguageInContactLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5fe5418-b108-401a-ba83-ff1213a966db");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,147,77,107,227,48,16,134,207,46,244,63,12,222,139,3,193,190,103,19,31,146,77,139,97,11,161,161,187,103,85,26,187,2,91,74,245,145,221,80,250,223,119,108,57,141,237,13,165,23,227,25,233,29,189,243,140,164,88,131,246,192,56,194,122,247,176,215,165,75,55,90,149,178,242,134,57,169,213,237,205,219,237,77,228,173,84,21,236,79,214,97,243,253,35,190,8,154,70,171,107,121,131,215,179,233,143,53,45,208,82,150,101,176,180,190,105,152,57,229,125,188,169,153,181,115,56,24,125,148,2,45,212,76,85,158,85,56,135,210,232,6,184,86,142,113,151,158,213,217,64,126,240,207,181,228,192,219,10,240,179,215,21,106,19,36,231,196,163,175,17,22,176,102,22,135,41,210,83,175,244,141,190,25,172,168,119,32,157,117,198,115,167,141,93,192,174,43,30,118,76,125,7,227,6,153,35,195,146,84,76,17,81,93,210,38,68,224,6,203,85,252,169,159,56,203,219,142,254,111,41,100,14,204,176,6,20,205,106,21,123,139,134,42,40,228,237,128,226,252,137,226,150,74,159,72,151,89,183,187,19,247,64,62,61,58,121,26,21,132,113,253,89,91,38,90,192,51,209,74,38,75,240,6,239,61,49,84,34,64,27,19,124,64,247,162,197,87,224,237,166,227,6,138,148,147,165,164,238,166,131,255,10,38,78,134,183,84,192,157,30,145,107,35,10,17,231,125,247,208,22,118,167,193,9,35,104,93,41,169,94,208,72,39,52,135,108,136,82,31,209,24,18,194,189,151,2,238,241,3,101,33,146,46,213,219,44,4,225,233,216,29,89,55,158,33,246,61,214,132,16,86,160,240,15,132,96,50,133,25,189,147,218,55,42,137,121,60,135,203,221,17,241,44,189,35,26,73,220,247,210,174,242,56,76,41,74,127,147,105,236,53,221,222,194,110,95,61,171,147,80,45,221,181,77,162,67,147,92,108,206,128,217,222,68,251,90,163,232,170,217,116,251,23,185,119,184,167,183,92,99,64,154,208,133,23,52,158,85,14,225,47,37,30,225,164,95,172,246,184,108,129,228,201,200,253,28,180,119,1,222,121,210,228,33,28,108,208,121,163,6,249,46,125,253,138,81,246,253,31,228,178,236,108,188,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e2c80707-56d1-485c-9153-61f3c4d5fd6c"));
		}

		#endregion

	}

	#endregion

}

