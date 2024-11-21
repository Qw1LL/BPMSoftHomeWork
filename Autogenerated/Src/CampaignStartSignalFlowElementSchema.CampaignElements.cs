namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignStartSignalFlowElementSchema

	/// <exclude/>
	public class CampaignStartSignalFlowElementSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignStartSignalFlowElementSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignStartSignalFlowElementSchema(CampaignStartSignalFlowElementSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("823b00f3-7d8f-4414-a5d0-9dfbf7ad3656");
			Name = "CampaignStartSignalFlowElement";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,143,205,10,131,64,12,132,207,10,190,67,160,119,189,151,210,67,197,222,10,5,159,32,174,81,23,246,71,220,44,86,74,223,189,234,90,108,79,189,101,66,38,243,141,65,77,174,71,65,112,185,223,74,219,112,154,91,211,200,214,15,200,210,154,36,126,38,113,18,71,135,129,218,89,66,174,208,185,35,228,168,123,148,173,41,25,7,46,231,1,213,85,217,177,80,164,201,240,234,200,178,12,78,206,107,141,195,116,222,116,241,32,225,25,43,69,32,182,15,64,193,3,99,39,69,7,88,215,32,172,97,20,236,128,237,126,134,190,150,100,102,204,106,2,183,6,166,159,144,236,43,165,247,149,146,2,196,130,249,135,18,246,26,63,236,81,104,252,10,189,201,212,161,250,34,231,221,27,26,58,165,215,48,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("823b00f3-7d8f-4414-a5d0-9dfbf7ad3656"));
		}

		#endregion

	}

	#endregion

}

