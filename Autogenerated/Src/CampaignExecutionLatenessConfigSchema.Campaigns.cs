namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignExecutionLatenessConfigSchema

	/// <exclude/>
	public class CampaignExecutionLatenessConfigSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignExecutionLatenessConfigSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignExecutionLatenessConfigSchema(CampaignExecutionLatenessConfigSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("363990ca-c5bf-49b2-9d2c-6f6312c3cdc6");
			Name = "CampaignExecutionLatenessConfig";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,146,207,106,195,48,12,198,207,41,244,29,68,123,79,238,91,215,195,66,25,133,21,10,217,11,168,174,146,26,108,39,88,202,182,50,246,238,179,243,167,221,58,214,194,14,49,177,244,249,231,79,146,29,90,226,6,21,193,227,118,83,212,165,164,121,237,74,93,181,30,69,215,110,58,249,152,78,146,150,181,171,160,56,178,144,189,191,216,7,189,49,164,162,152,211,39,114,228,181,58,107,206,80,79,105,142,182,65,93,185,144,14,130,185,167,42,28,130,220,32,243,29,140,201,213,59,169,54,210,158,81,2,141,185,247,211,29,201,178,12,22,220,90,139,254,184,28,246,221,113,144,3,10,168,218,9,106,199,160,6,22,152,129,1,13,250,80,168,144,231,116,228,100,223,64,77,187,51,90,129,234,88,55,157,36,161,39,97,61,85,176,245,117,67,94,52,133,50,182,29,41,102,227,119,105,184,11,140,56,120,69,211,82,10,107,199,130,46,76,160,46,131,152,8,148,167,242,97,246,162,45,21,13,186,89,182,140,158,127,155,30,93,143,194,19,56,6,32,206,45,73,42,146,56,140,36,225,225,231,179,183,126,221,152,28,27,186,126,231,159,61,58,67,254,97,32,63,61,165,216,11,171,185,212,158,246,64,134,44,57,97,120,211,114,0,137,213,133,81,239,117,20,94,183,185,94,185,214,146,199,157,161,197,104,185,80,7,178,184,234,153,75,216,12,183,196,166,133,1,247,212,33,123,171,136,57,185,125,255,6,186,125,31,253,25,12,177,47,153,198,205,8,99,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("363990ca-c5bf-49b2-9d2c-6f6312c3cdc6"));
		}

		#endregion

	}

	#endregion

}

