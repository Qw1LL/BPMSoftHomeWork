namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AccountInfoResponseSchema

	/// <exclude/>
	public class AccountInfoResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountInfoResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountInfoResponseSchema(AccountInfoResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("126bd8c9-55dd-b001-f748-1309e196c95f");
			Name = "AccountInfoResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,205,106,195,48,16,132,207,49,248,29,22,114,183,239,77,41,180,105,8,129,148,154,184,121,0,89,94,187,11,182,100,244,211,54,132,190,123,37,249,135,180,13,38,23,129,198,59,243,205,98,9,214,162,238,24,71,120,202,94,114,89,153,100,45,69,69,181,85,204,144,20,73,46,57,177,102,143,172,220,162,136,163,115,28,45,172,38,81,67,126,210,6,219,85,28,57,101,169,176,118,195,176,110,152,214,119,240,200,185,180,194,236,68,37,15,46,92,10,141,97,44,77,83,184,215,182,109,153,58,61,12,247,231,183,87,80,195,16,124,146,121,7,114,54,213,6,58,176,66,90,3,172,207,75,198,136,244,34,163,179,69,67,28,184,39,95,7,47,92,103,119,78,37,51,37,59,84,134,208,53,205,130,187,255,254,183,93,16,118,122,164,3,126,145,54,218,151,248,223,98,172,81,72,217,56,207,208,99,19,28,112,134,26,205,10,180,63,190,103,88,131,11,168,156,135,108,45,149,211,170,229,205,241,23,171,48,110,232,3,111,92,197,143,222,12,241,143,200,216,146,36,28,15,251,121,128,54,202,191,163,201,113,84,205,53,204,18,69,217,255,185,112,239,213,223,162,211,126,0,180,220,81,85,199,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("126bd8c9-55dd-b001-f748-1309e196c95f"));
		}

		#endregion

	}

	#endregion

}

