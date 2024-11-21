namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignStartLandingFlowElementSchema

	/// <exclude/>
	public class CampaignStartLandingFlowElementSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignStartLandingFlowElementSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignStartLandingFlowElementSchema(CampaignStartLandingFlowElementSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("61400b6c-6c0b-7653-fe9c-14375ff174b0");
			Name = "CampaignStartLandingFlowElement";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,143,193,10,194,48,16,68,207,45,244,31,22,188,183,119,17,15,150,122,82,16,250,5,219,100,173,129,100,83,154,13,90,196,127,55,90,69,61,121,156,97,103,231,13,163,163,48,160,34,216,28,246,173,63,74,89,123,62,154,62,142,40,198,115,145,95,139,188,200,179,197,72,125,146,80,91,12,97,9,53,186,1,77,207,173,224,40,59,100,109,184,223,90,127,110,44,57,98,121,70,170,170,130,85,136,206,225,56,173,95,186,185,144,138,130,157,37,80,175,23,64,115,6,228,132,2,168,117,0,229,89,80,73,0,241,159,51,140,218,16,39,206,110,130,144,12,180,229,187,164,250,106,25,98,103,141,2,245,224,252,135,9,159,33,63,240,89,218,156,221,230,221,196,122,158,254,144,201,187,3,230,247,225,121,48,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("61400b6c-6c0b-7653-fe9c-14375ff174b0"));
		}

		#endregion

	}

	#endregion

}

