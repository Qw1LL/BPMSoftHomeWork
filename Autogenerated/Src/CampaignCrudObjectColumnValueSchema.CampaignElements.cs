namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignCrudObjectColumnValueSchema

	/// <exclude/>
	public class CampaignCrudObjectColumnValueSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignCrudObjectColumnValueSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignCrudObjectColumnValueSchema(CampaignCrudObjectColumnValueSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("64496986-5fe2-4f0f-beca-e34f759c7102");
			Name = "CampaignCrudObjectColumnValue";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,81,77,107,195,48,12,61,55,208,255,32,232,189,185,175,99,135,101,236,227,80,86,86,218,187,98,43,169,135,63,178,88,30,148,178,255,62,199,78,199,62,232,218,139,176,159,164,247,158,36,139,134,124,135,130,224,118,181,92,187,134,231,149,179,141,106,67,143,172,156,157,22,135,105,49,9,94,217,22,214,123,207,100,22,211,34,34,179,158,218,152,134,74,163,247,87,80,161,233,80,181,182,234,131,124,174,95,73,112,229,116,48,118,139,58,80,106,40,203,18,174,125,48,6,251,253,205,248,207,53,240,62,20,129,113,146,52,240,14,25,148,135,224,73,66,189,7,49,18,67,245,178,185,3,151,168,129,52,25,178,236,231,71,222,242,27,113,23,106,173,4,136,193,216,57,95,147,56,92,140,95,211,44,137,119,78,198,121,86,137,36,39,127,59,79,192,198,170,183,104,90,201,232,67,53,138,122,112,13,12,111,142,158,147,196,96,238,175,187,163,189,135,160,228,56,255,230,73,194,1,90,226,5,248,33,124,252,35,187,77,171,138,82,62,238,64,112,220,209,37,98,227,218,114,243,165,82,247,26,91,96,7,202,74,37,144,41,159,38,223,106,135,30,12,138,222,165,19,156,22,174,157,211,240,136,126,153,106,79,234,207,200,202,124,129,244,207,232,79,48,98,159,188,9,88,82,170,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("64496986-5fe2-4f0f-beca-e34f759c7102"));
		}

		#endregion

	}

	#endregion

}

