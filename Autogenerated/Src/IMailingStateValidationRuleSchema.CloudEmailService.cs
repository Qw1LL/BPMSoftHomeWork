namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMailingStateValidationRuleSchema

	/// <exclude/>
	public class IMailingStateValidationRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMailingStateValidationRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMailingStateValidationRuleSchema(IMailingStateValidationRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d21ccf92-5dc5-4e8f-9f1a-b4b1c7befaaa");
			Name = "IMailingStateValidationRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bbfdb6d8-67aa-4e5b-af46-39321e13789f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,145,49,79,195,48,16,133,231,70,202,127,56,133,5,150,100,135,54,3,136,161,67,164,170,69,236,38,57,183,150,146,115,116,62,35,16,226,191,115,73,218,38,2,33,121,176,159,207,223,189,123,38,211,97,232,77,141,240,184,171,14,222,74,254,228,201,186,99,100,35,206,83,154,124,165,73,154,172,138,162,128,117,136,93,103,248,179,60,159,247,216,51,6,36,9,32,39,132,202,184,214,209,241,32,70,240,213,180,174,25,1,251,216,34,212,158,132,77,45,249,133,84,44,80,125,124,107,93,13,142,4,217,14,70,182,255,147,180,124,242,179,186,97,60,170,8,21,202,201,55,225,30,118,35,102,186,252,237,118,16,86,207,31,88,71,65,120,191,18,193,122,134,208,99,237,172,195,6,88,27,228,215,231,75,139,147,210,27,54,29,144,6,182,201,194,224,45,43,95,116,238,113,59,162,102,114,190,46,198,234,249,49,163,68,166,80,110,73,235,73,167,244,86,45,162,102,195,104,55,217,98,76,253,14,79,1,179,162,4,158,19,94,184,86,41,182,18,180,199,5,58,116,249,75,128,179,132,183,203,64,39,191,119,15,231,24,145,154,41,201,241,252,157,38,186,126,0,40,103,223,215,20,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d21ccf92-5dc5-4e8f-9f1a-b4b1c7befaaa"));
		}

		#endregion

	}

	#endregion

}

