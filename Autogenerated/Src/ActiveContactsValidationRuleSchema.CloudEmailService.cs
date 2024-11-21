namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ActiveContactsValidationRuleSchema

	/// <exclude/>
	public class ActiveContactsValidationRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ActiveContactsValidationRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ActiveContactsValidationRuleSchema(ActiveContactsValidationRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("df11bcd7-a33a-4244-bbc8-b2cfc61e31b4");
			Name = "ActiveContactsValidationRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bbfdb6d8-67aa-4e5b-af46-39321e13789f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,83,77,139,219,48,16,61,59,144,255,32,220,75,22,138,125,79,215,129,110,112,233,66,2,97,221,237,165,244,160,202,99,71,172,45,153,145,156,110,91,246,191,119,244,225,198,77,186,208,139,44,141,230,189,121,243,70,86,188,7,51,112,1,236,238,176,175,116,99,179,173,86,141,108,71,228,86,106,181,92,252,90,46,150,139,36,207,115,118,107,198,190,231,248,99,19,207,15,48,32,24,80,214,48,123,4,198,133,149,39,96,66,43,75,91,118,226,157,172,61,7,195,177,131,108,34,201,103,44,195,248,173,147,130,137,142,27,195,222,123,252,54,192,205,231,63,240,7,66,179,53,187,223,115,217,73,213,86,150,91,248,251,150,152,130,202,228,13,66,235,42,238,193,30,117,109,214,236,224,43,132,203,203,30,92,32,41,159,65,140,22,230,114,27,141,151,205,76,29,92,183,16,34,3,71,222,51,69,94,22,169,113,2,211,205,39,178,196,111,61,223,153,62,187,205,125,246,25,140,96,71,84,102,115,175,40,95,209,36,116,67,58,129,170,35,52,69,58,235,149,38,165,149,129,52,223,48,60,155,63,119,26,204,216,89,67,53,38,82,87,37,218,124,77,52,133,96,53,55,55,200,190,97,228,105,146,36,241,198,205,5,158,173,119,196,125,139,144,229,94,139,59,191,243,185,175,142,208,203,154,9,141,129,194,163,46,96,31,161,27,0,179,73,218,1,176,151,198,16,168,172,165,189,27,187,167,178,39,73,171,40,36,123,52,128,4,85,64,36,90,221,4,33,178,97,171,203,106,36,181,6,86,20,175,63,180,144,86,34,106,156,186,159,218,127,180,244,177,18,76,182,211,109,72,249,160,177,231,118,149,126,217,150,149,203,114,105,7,212,39,89,147,250,248,172,42,80,245,30,140,225,45,124,93,179,157,20,224,92,23,71,16,79,172,33,12,212,89,26,37,39,97,98,76,193,247,127,77,42,202,73,170,81,8,34,36,255,27,222,25,120,27,195,59,241,179,178,232,231,228,154,188,178,58,139,42,66,250,75,40,249,226,215,255,170,123,46,107,113,12,44,129,132,56,252,143,71,141,134,127,207,159,125,148,150,223,51,236,171,134,94,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("df11bcd7-a33a-4244-bbc8-b2cfc61e31b4"));
		}

		#endregion

	}

	#endregion

}

