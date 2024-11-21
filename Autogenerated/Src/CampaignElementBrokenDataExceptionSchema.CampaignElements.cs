namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignElementBrokenDataExceptionSchema

	/// <exclude/>
	public class CampaignElementBrokenDataExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignElementBrokenDataExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignElementBrokenDataExceptionSchema(CampaignElementBrokenDataExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("244e9e83-75da-48e7-886d-ea2dfe372f7f");
			Name = "CampaignElementBrokenDataException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,49,110,194,64,16,172,131,196,31,86,78,67,26,187,39,64,1,161,72,17,9,137,124,96,125,94,155,83,236,61,235,238,44,66,16,127,207,250,124,64,66,10,210,88,218,209,206,236,204,248,24,27,114,45,42,130,229,230,109,107,74,159,174,12,151,186,234,44,122,109,56,93,97,211,162,174,120,93,83,67,236,221,120,116,28,143,30,58,167,185,130,237,193,121,106,158,199,35,65,30,45,85,178,15,171,26,157,155,194,13,109,105,205,7,241,11,122,92,127,42,106,123,229,192,202,178,12,102,174,107,26,180,135,69,156,47,27,160,185,208,10,61,21,144,7,62,24,43,152,50,236,180,28,102,15,133,8,10,2,42,94,3,26,206,165,103,233,236,135,118,219,229,181,86,160,122,131,255,240,7,211,171,19,97,75,106,249,94,99,138,9,111,59,229,141,149,180,155,32,61,108,220,70,10,192,43,107,175,177,214,95,228,0,129,105,47,174,157,71,150,218,77,9,126,71,66,33,2,101,169,156,39,247,189,37,217,34,230,216,107,191,131,243,21,4,215,146,210,165,150,198,200,90,105,75,254,173,195,138,250,62,254,22,50,32,45,90,108,128,229,25,204,147,184,158,44,222,197,81,28,196,29,74,211,228,148,213,185,216,239,205,6,241,116,150,5,110,144,138,229,222,183,62,145,218,250,183,19,213,159,164,230,28,29,77,46,243,17,78,177,106,226,98,104,59,204,3,250,27,60,125,3,170,66,65,36,190,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("244e9e83-75da-48e7-886d-ea2dfe372f7f"));
		}

		#endregion

	}

	#endregion

}

