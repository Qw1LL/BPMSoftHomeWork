namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignTimerFlowElementSchema

	/// <exclude/>
	public class CampaignTimerFlowElementSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignTimerFlowElementSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignTimerFlowElementSchema(CampaignTimerFlowElementSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a2be9fb0-f9e2-400e-a7f9-206a3251c665");
			Name = "CampaignTimerFlowElement";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,143,203,10,194,48,16,69,215,13,244,31,6,220,55,123,17,23,134,186,19,10,250,3,211,56,45,129,60,74,30,168,72,255,93,99,42,234,194,229,129,57,115,239,181,104,40,76,40,9,118,221,225,232,134,216,8,103,7,53,38,143,81,57,91,179,123,205,106,86,173,60,141,79,4,161,49,132,53,8,52,19,170,209,158,148,33,191,215,238,210,106,50,100,227,235,150,115,14,155,144,140,65,127,219,46,220,94,73,166,136,189,38,136,217,1,42,2,96,4,185,60,107,222,46,255,146,167,212,107,37,65,230,220,191,177,240,105,244,83,166,42,229,231,50,129,236,185,172,200,56,63,0,191,48,28,5,249,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a2be9fb0-f9e2-400e-a7f9-206a3251c665"));
		}

		#endregion

	}

	#endregion

}

