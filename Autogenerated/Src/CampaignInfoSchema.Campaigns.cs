namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignInfoSchema

	/// <exclude/>
	public class CampaignInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignInfoSchema(CampaignInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d788e01e-bff4-487a-85dc-ee3d99dc9d42");
			Name = "CampaignInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,146,201,74,3,65,16,134,207,9,204,59,20,228,158,185,27,241,96,80,201,65,8,12,121,128,78,119,77,79,225,244,98,47,72,8,190,187,53,61,137,137,11,98,20,154,130,218,254,250,168,106,43,12,70,47,36,194,237,250,177,113,109,154,47,157,109,73,231,32,18,57,91,77,247,213,116,146,35,89,13,205,46,38,52,11,246,249,205,2,106,206,195,178,23,49,94,193,82,24,47,72,219,149,109,93,53,229,124,93,215,112,29,179,49,34,236,110,14,126,169,133,212,137,4,1,125,192,136,54,69,232,73,119,233,5,7,11,242,32,3,49,137,132,64,172,6,198,41,236,231,71,201,250,76,211,231,109,79,18,100,145,253,72,48,97,108,182,239,152,235,224,60,134,68,200,172,235,210,54,230,63,99,150,192,198,210,115,230,233,138,249,168,37,12,224,218,19,218,16,76,187,1,232,43,209,17,233,33,147,58,17,41,216,131,198,180,128,56,152,215,63,79,30,150,146,227,5,147,155,210,112,193,252,251,94,232,241,64,100,21,73,190,65,60,141,247,193,105,62,90,28,143,243,51,198,214,185,30,86,150,215,62,182,252,107,1,169,67,240,34,144,36,47,108,226,15,99,159,80,29,238,0,81,118,104,196,47,150,114,87,234,155,82,190,249,126,39,51,180,106,252,48,197,31,163,231,65,254,249,28,124,3,14,163,113,18,52,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d788e01e-bff4-487a-85dc-ee3d99dc9d42"));
		}

		#endregion

	}

	#endregion

}

