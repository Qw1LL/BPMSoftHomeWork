namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FromEmailMaskValidationRuleSchema

	/// <exclude/>
	public class FromEmailMaskValidationRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FromEmailMaskValidationRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FromEmailMaskValidationRuleSchema(FromEmailMaskValidationRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c4a873c4-bfd7-48e3-ac0b-3c4de968c246");
			Name = "FromEmailMaskValidationRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bbfdb6d8-67aa-4e5b-af46-39321e13789f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,83,75,111,219,48,12,62,187,64,255,3,219,1,69,2,12,242,189,107,122,104,186,21,193,230,161,72,176,220,21,155,78,132,200,146,39,74,25,130,161,255,125,148,252,88,230,1,189,200,22,73,125,15,138,50,178,65,106,101,137,240,244,90,108,108,237,197,210,154,90,237,131,147,94,89,3,215,87,191,175,175,178,64,202,236,97,115,38,143,13,23,104,141,101,204,146,120,65,131,78,149,159,166,53,223,148,249,201,65,14,127,112,184,143,64,75,45,137,238,1,190,56,219,124,110,164,210,133,164,227,86,106,85,37,162,117,208,152,234,243,60,135,7,10,77,35,221,249,177,223,175,177,117,72,104,60,129,63,32,148,17,10,126,41,127,232,22,199,103,9,108,13,167,17,14,106,235,0,35,13,65,205,140,208,200,210,89,130,221,153,255,232,40,6,162,252,130,169,13,59,173,202,30,253,29,153,112,15,79,146,112,18,100,0,238,20,175,163,227,2,253,193,86,236,249,213,89,207,13,195,170,203,79,29,166,64,143,134,157,67,246,90,97,111,160,211,31,163,23,154,216,76,244,240,191,137,46,210,74,39,27,48,124,183,139,91,135,165,106,21,55,239,246,113,61,252,198,102,237,130,62,118,12,226,33,79,7,210,249,118,16,11,246,132,206,169,10,225,100,85,5,43,227,209,25,169,7,161,179,85,129,68,114,143,35,232,202,212,22,70,182,57,196,193,201,178,147,116,241,94,2,142,234,97,1,47,232,147,135,237,144,24,65,102,35,192,71,40,184,152,103,138,7,146,60,137,127,221,127,197,243,60,78,93,150,169,26,102,19,130,155,5,152,160,53,220,221,193,77,15,242,195,243,199,43,36,49,24,72,165,147,147,49,25,80,252,213,54,31,108,100,163,46,177,50,12,36,245,154,223,13,43,195,165,229,22,45,96,166,216,115,79,118,153,18,75,105,74,212,88,109,210,157,210,179,101,34,243,221,250,45,63,156,90,97,213,185,120,139,43,47,105,128,184,178,155,161,180,239,162,151,193,183,63,47,243,174,132,182,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c4a873c4-bfd7-48e3-ac0b-3c4de968c246"));
		}

		#endregion

	}

	#endregion

}

