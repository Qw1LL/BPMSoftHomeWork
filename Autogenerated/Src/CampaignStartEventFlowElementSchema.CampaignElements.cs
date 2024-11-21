namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignStartEventFlowElementSchema

	/// <exclude/>
	public class CampaignStartEventFlowElementSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignStartEventFlowElementSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignStartEventFlowElementSchema(CampaignStartEventFlowElementSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b2c0d06b-bc9a-4a03-b964-92f201a1b9c3");
			Name = "CampaignStartEventFlowElement";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,143,79,11,130,64,16,197,207,10,126,135,129,238,122,143,232,144,216,45,8,252,4,227,58,218,194,254,145,221,217,74,162,239,222,154,134,117,233,54,239,49,111,230,247,12,106,242,3,10,130,195,249,84,219,142,243,210,154,78,246,193,33,75,107,178,244,145,165,89,154,108,28,245,81,66,169,208,251,45,148,168,7,148,189,169,25,29,87,87,50,124,84,246,86,41,210,113,124,7,138,162,128,157,15,90,163,27,247,139,174,238,36,2,99,163,8,196,114,0,104,206,0,95,144,1,219,214,131,176,134,81,176,7,182,235,26,134,86,146,137,148,205,8,62,26,168,242,207,147,226,235,203,16,26,37,5,136,137,242,63,36,172,37,126,208,147,216,55,121,206,157,201,180,115,237,73,70,239,5,246,168,63,158,44,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b2c0d06b-bc9a-4a03-b964-92f201a1b9c3"));
		}

		#endregion

	}

	#endregion

}

