namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ICampaignFragmentSyncManagerSchema

	/// <exclude/>
	public class ICampaignFragmentSyncManagerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICampaignFragmentSyncManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICampaignFragmentSyncManagerSchema(ICampaignFragmentSyncManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5f487be7-70f8-43c3-96b8-4b744c2ea4c4");
			Name = "ICampaignFragmentSyncManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,148,77,78,195,48,16,133,215,84,234,29,70,101,3,18,106,246,80,186,160,8,169,139,74,72,21,7,152,58,147,196,82,60,14,30,27,40,136,187,227,184,127,9,173,96,195,146,77,34,143,237,207,239,189,113,194,104,72,26,84,4,119,143,139,165,45,252,120,102,185,208,101,112,232,181,229,225,224,99,56,56,11,162,185,236,44,112,116,51,28,196,250,185,163,50,46,130,57,123,114,69,132,92,195,124,134,166,65,93,242,131,195,210,16,251,229,154,213,2,25,75,114,105,79,150,101,48,145,96,12,186,245,116,59,190,39,81,78,175,72,160,8,172,218,115,177,214,126,13,133,117,160,182,60,104,208,121,173,116,131,236,5,36,82,43,103,89,191,39,153,176,5,249,10,61,104,1,101,141,137,213,118,127,233,108,104,192,22,7,144,168,138,12,2,213,212,234,19,120,213,190,2,122,14,88,31,97,107,91,106,53,222,169,206,58,178,155,176,170,181,2,189,115,254,139,241,179,24,99,124,238,19,91,144,175,108,46,215,240,152,56,155,201,239,209,164,194,114,47,41,198,115,58,140,214,230,107,165,85,117,152,47,182,34,4,42,204,97,69,196,64,111,164,130,167,188,181,115,236,103,83,137,88,52,192,241,78,220,142,130,144,139,119,129,41,53,100,52,157,179,120,228,232,52,102,57,17,34,80,142,138,219,209,83,127,89,54,5,85,163,200,120,146,37,216,105,246,33,103,202,103,54,176,31,77,211,171,101,119,231,122,62,123,200,23,171,243,110,54,23,125,29,208,87,127,5,81,107,219,172,30,61,29,121,121,243,67,248,15,214,69,195,157,61,255,45,104,250,45,72,9,253,101,31,206,137,243,205,71,146,198,159,155,31,77,175,24,107,95,193,67,225,75,183,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5f487be7-70f8-43c3-96b8-4b744c2ea4c4"));
		}

		#endregion

	}

	#endregion

}

