namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ICaseRuleHandlerSchema

	/// <exclude/>
	public class ICaseRuleHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICaseRuleHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICaseRuleHandlerSchema(ICaseRuleHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("66c513b1-90ad-4e77-a206-4ecd2c1e8325");
			Name = "ICaseRuleHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,65,106,3,49,12,69,215,19,200,29,68,86,237,102,124,128,166,89,36,20,154,69,161,52,244,0,170,163,153,26,60,242,32,219,133,161,228,238,149,61,109,8,77,192,27,73,255,251,63,137,113,160,56,162,37,216,190,190,28,66,151,218,93,224,206,245,89,48,185,192,203,197,247,114,209,228,232,184,191,16,8,61,220,236,182,79,156,92,114,20,117,172,2,99,12,172,99,30,6,148,105,243,91,239,57,145,116,37,175,11,2,146,61,69,16,178,232,109,246,53,177,253,51,154,11,231,152,63,188,179,224,206,230,253,14,35,189,169,251,25,249,232,73,84,83,64,155,247,72,162,11,48,217,242,23,252,43,171,164,233,41,21,252,230,84,33,175,40,107,67,23,145,9,198,160,137,103,80,248,44,89,186,115,65,188,102,156,59,35,10,14,192,122,213,199,21,149,107,76,171,77,189,202,180,54,117,86,165,95,193,29,97,70,135,187,121,12,179,250,190,160,41,153,190,31,19,85,103,156,155,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("66c513b1-90ad-4e77-a206-4ecd2c1e8325"));
		}

		#endregion

	}

	#endregion

}

