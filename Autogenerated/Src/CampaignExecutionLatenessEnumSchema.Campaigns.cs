namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignExecutionLatenessEnumSchema

	/// <exclude/>
	public class CampaignExecutionLatenessEnumSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignExecutionLatenessEnumSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignExecutionLatenessEnumSchema(CampaignExecutionLatenessEnumSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("790d2649-25eb-4742-88b0-ff7156873fad");
			Name = "CampaignExecutionLatenessEnum";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,147,77,75,196,48,16,134,207,45,244,63,12,120,149,173,95,39,177,130,214,189,185,139,176,158,188,101,147,105,59,208,76,74,146,250,129,248,223,77,187,141,10,235,174,30,244,56,195,59,207,251,206,132,176,208,232,58,33,17,174,239,22,43,83,249,89,105,184,162,186,183,194,147,225,44,125,205,210,44,77,14,44,214,161,132,57,247,250,28,74,161,59,65,53,207,159,81,246,131,236,86,120,100,116,110,212,230,121,14,23,174,215,90,216,151,203,169,190,65,39,45,173,209,65,59,73,161,50,22,228,4,2,140,164,89,4,228,95,8,93,191,110,73,2,6,243,125,222,73,200,154,108,217,143,141,7,180,230,195,122,240,216,54,73,150,134,17,10,56,58,28,183,248,158,179,52,190,33,174,161,17,143,8,107,68,6,77,174,34,139,106,39,116,177,17,4,242,241,62,242,202,104,4,108,81,35,123,7,79,228,27,240,20,90,210,176,162,97,207,223,123,78,142,234,62,204,151,113,124,30,209,5,156,236,203,17,207,9,228,160,182,24,42,11,190,17,12,174,67,73,21,161,130,240,146,158,164,104,63,223,114,72,186,35,76,25,197,5,156,254,139,111,4,8,86,224,254,238,136,49,247,21,171,159,238,121,22,244,111,155,111,130,172,54,63,101,40,67,239,29,136,20,190,69,95,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("790d2649-25eb-4742-88b0-ff7156873fad"));
		}

		#endregion

	}

	#endregion

}

