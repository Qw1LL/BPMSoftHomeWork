namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignEnumsSchema

	/// <exclude/>
	public class CampaignEnumsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignEnumsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignEnumsSchema(CampaignEnumsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0c552018-5652-4db5-88b4-c7082c75a44f");
			Name = "CampaignEnums";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,146,193,78,2,65,12,134,207,144,240,14,13,30,188,24,86,61,26,32,81,20,245,96,52,65,30,160,12,93,153,100,118,102,156,233,72,54,134,119,183,236,42,138,176,114,241,214,110,255,109,191,105,127,139,5,69,143,138,224,234,233,97,226,114,238,141,156,205,245,75,10,200,218,217,78,251,189,211,238,180,91,71,129,94,36,133,27,155,138,11,152,48,249,145,43,188,33,166,185,232,231,186,214,138,48,203,50,232,199,84,20,24,202,225,103,190,81,0,47,144,65,75,166,144,41,74,74,16,89,66,112,57,120,12,172,149,246,104,57,30,3,42,214,111,235,42,121,80,174,158,4,62,56,79,129,75,200,93,0,149,66,32,203,192,1,109,172,218,247,190,230,103,63,0,124,154,25,173,128,4,188,145,187,37,143,108,237,160,87,31,110,137,227,22,90,53,123,185,208,106,177,221,238,27,78,71,120,14,137,214,52,187,56,173,105,164,205,63,143,214,148,48,128,211,147,106,117,255,9,48,70,19,255,32,184,183,234,23,195,217,65,6,52,102,155,99,169,121,225,18,3,218,82,78,244,117,226,25,70,97,145,96,63,92,3,211,165,244,24,192,185,132,171,218,111,100,231,181,229,246,216,111,115,57,52,19,122,77,100,21,141,141,91,94,147,193,114,106,53,55,26,177,82,64,18,73,189,197,126,36,2,21,40,31,116,27,122,222,24,42,196,100,221,108,120,208,92,135,169,254,176,89,77,166,45,204,177,140,13,59,186,150,210,33,183,108,250,200,101,66,83,163,187,117,109,125,243,134,117,175,62,0,45,47,182,148,21,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0c552018-5652-4db5-88b4-c7082c75a44f"));
		}

		#endregion

	}

	#endregion

}

