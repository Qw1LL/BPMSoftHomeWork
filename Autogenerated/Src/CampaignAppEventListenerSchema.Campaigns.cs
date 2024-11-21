namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignAppEventListenerSchema

	/// <exclude/>
	public class CampaignAppEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignAppEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignAppEventListenerSchema(CampaignAppEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3e664810-988a-4dee-b55a-dbf31d8fa22e");
			Name = "CampaignAppEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1f302b36-4763-41e5-806c-b1f1f1b6d901");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,84,81,107,219,48,16,126,78,161,255,225,112,95,82,24,246,123,154,26,214,52,133,140,150,149,121,176,103,69,62,219,98,214,201,72,114,169,55,246,223,119,150,147,206,105,155,6,202,104,251,98,228,187,211,119,223,125,250,36,18,26,93,35,36,194,197,237,77,102,10,31,47,12,21,170,108,173,240,202,208,241,209,239,227,163,73,235,20,149,163,2,139,241,66,232,70,168,146,206,94,78,199,43,242,104,11,198,119,135,42,51,47,172,207,120,37,234,61,165,87,66,122,99,213,115,80,63,112,205,53,90,155,158,16,103,79,44,150,76,31,22,181,112,110,6,219,38,159,155,102,121,135,228,175,149,243,72,104,67,109,146,36,48,119,173,214,194,118,233,230,255,27,54,22,29,87,58,208,232,43,147,59,240,6,20,41,175,68,173,126,33,176,100,63,69,137,241,118,127,50,2,104,218,117,173,36,200,190,247,222,214,48,131,213,83,58,19,150,155,191,15,252,111,134,230,51,184,13,152,67,242,49,225,16,184,80,196,36,55,180,28,231,17,65,90,44,206,163,160,193,160,93,23,37,41,40,143,218,245,196,159,50,31,34,141,176,66,3,177,51,206,35,105,248,0,239,125,148,174,200,121,65,236,19,83,140,193,183,35,44,54,117,73,26,207,147,0,16,240,54,82,220,25,149,195,215,94,131,112,202,211,71,187,96,211,229,20,122,183,77,38,99,198,113,63,216,124,181,149,113,121,143,178,237,157,121,109,202,18,237,39,216,147,72,167,81,235,208,114,3,66,217,135,163,211,179,67,216,95,204,250,82,241,101,240,178,26,35,239,132,95,131,251,93,105,204,120,115,222,214,99,220,157,240,107,112,175,172,40,53,171,152,117,36,43,107,136,125,57,130,127,46,155,78,7,212,63,47,24,41,28,211,146,114,64,221,248,14,42,65,57,243,123,47,191,48,145,67,110,73,146,75,3,100,124,213,63,8,133,177,192,171,135,155,0,29,250,248,240,200,25,58,199,162,7,119,126,128,193,199,116,222,112,252,229,135,56,245,127,100,254,235,232,39,72,249,240,170,134,255,33,186,27,228,216,95,93,210,226,210,16,7,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3e664810-988a-4dee-b55a-dbf31d8fa22e"));
		}

		#endregion

	}

	#endregion

}

