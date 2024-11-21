namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MailingStateValidationRuleSchema

	/// <exclude/>
	public class MailingStateValidationRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MailingStateValidationRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MailingStateValidationRuleSchema(MailingStateValidationRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6a9f50c4-bce9-47b7-a069-b260821478be");
			Name = "MailingStateValidationRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bbfdb6d8-67aa-4e5b-af46-39321e13789f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,145,79,79,195,48,12,197,207,171,212,239,96,149,11,92,90,113,133,173,135,33,14,59,76,154,54,196,61,180,78,23,169,117,42,199,65,32,196,119,199,109,247,167,2,33,229,144,188,56,63,63,191,144,233,48,244,166,66,88,239,182,7,111,37,127,242,100,93,19,217,136,243,148,38,95,105,146,38,139,162,40,96,25,98,215,25,254,44,79,231,61,246,140,1,73,2,200,17,97,107,92,235,168,57,136,17,124,53,173,171,71,192,62,182,8,149,39,97,83,73,126,38,21,51,84,31,223,90,87,129,35,65,182,131,145,205,255,164,123,173,159,12,45,110,24,27,85,97,139,114,244,117,120,128,221,200,153,46,127,219,29,132,197,243,7,86,81,16,222,47,72,176,158,33,244,88,57,235,176,6,214,14,249,229,249,220,227,164,244,134,77,7,164,137,173,178,48,152,203,202,23,29,124,220,142,168,43,57,95,22,99,245,245,49,163,68,166,80,110,72,235,73,199,244,86,45,162,134,195,104,87,217,108,78,253,15,79,1,179,162,4,190,70,60,115,173,82,108,37,104,143,51,116,232,242,151,0,39,9,111,231,137,78,126,239,30,79,49,34,213,83,146,227,249,59,77,116,253,0,215,213,22,17,21,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6a9f50c4-bce9-47b7-a069-b260821478be"));
		}

		#endregion

	}

	#endregion

}

