namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BaseLanguageRuleSchema

	/// <exclude/>
	public class BaseLanguageRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseLanguageRuleSchema(BaseLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("baa8372c-43b1-4ee1-aa11-be1c27d2f168");
			Name = "BaseLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2659875a-4670-491c-9c1f-f4641a7bae64");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,65,110,194,48,16,60,131,196,31,86,225,2,23,114,167,192,129,28,80,164,86,66,160,62,192,56,155,200,82,108,71,107,251,128,42,254,94,219,33,148,24,181,234,113,71,179,227,153,241,42,38,209,116,140,35,236,143,31,103,93,219,85,161,85,45,26,71,204,10,173,102,211,175,217,116,226,140,80,13,156,175,198,162,124,123,204,63,11,132,30,245,248,156,176,241,75,80,180,204,152,53,236,153,193,119,166,26,199,26,60,185,22,35,39,207,115,216,24,39,37,163,235,238,62,7,34,176,139,177,196,184,5,30,182,161,214,228,121,136,192,9,235,109,86,62,11,101,249,14,132,236,90,148,168,108,244,105,86,131,116,254,164,221,185,75,43,120,170,156,218,130,53,140,212,253,98,8,253,72,115,36,221,33,89,129,62,210,49,42,198,32,47,73,34,240,105,144,128,107,165,144,7,95,193,214,171,175,193,88,32,23,15,110,58,70,19,147,6,109,168,124,114,235,31,157,163,170,122,95,247,121,168,220,119,96,201,113,171,233,63,54,11,66,102,209,128,240,91,76,249,223,215,245,115,219,105,69,190,240,95,146,68,164,99,196,36,40,127,74,219,204,141,66,100,187,180,144,77,30,217,125,13,164,173,135,177,122,249,147,69,210,197,88,117,121,239,38,33,109,19,218,95,189,165,167,113,112,162,130,3,218,193,68,89,45,34,228,15,76,216,235,9,185,166,170,172,150,65,178,87,28,11,222,190,1,249,173,193,245,72,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("baa8372c-43b1-4ee1-aa11-be1c27d2f168"));
		}

		#endregion

	}

	#endregion

}

