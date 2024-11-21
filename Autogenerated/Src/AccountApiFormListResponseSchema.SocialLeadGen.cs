namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AccountApiFormListResponseSchema

	/// <exclude/>
	public class AccountApiFormListResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountApiFormListResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountApiFormListResponseSchema(AccountApiFormListResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c594cadb-29f2-49ba-adfb-e460ee13e9d5");
			Name = "AccountApiFormListResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,79,194,64,20,60,67,226,127,120,129,139,94,218,59,16,18,196,104,48,168,141,112,51,30,150,221,215,186,177,221,109,118,95,49,132,248,223,125,253,0,165,32,122,217,164,243,102,102,103,231,213,136,12,125,46,36,194,117,244,176,176,49,5,83,107,98,157,20,78,144,182,38,88,88,169,69,58,71,161,238,208,92,116,183,23,221,78,225,181,73,224,17,63,200,26,95,42,238,189,53,195,253,96,177,241,132,25,219,164,41,202,210,195,7,44,69,167,37,115,152,213,119,152,48,10,211,84,120,63,128,137,148,182,48,52,201,245,173,117,217,92,123,122,230,64,172,194,138,29,134,33,140,124,145,101,194,109,198,205,247,205,242,9,232,77,16,40,244,210,233,149,67,152,68,51,112,141,14,98,103,51,16,181,47,120,116,107,45,49,216,121,133,63,204,242,98,149,106,9,178,76,114,38,8,12,224,160,6,198,41,114,118,173,21,186,239,176,29,238,134,207,246,251,74,179,122,112,112,91,13,119,118,162,189,138,125,115,116,164,145,165,81,37,104,8,47,101,203,205,116,115,217,211,170,119,245,90,13,26,219,212,114,247,51,5,91,72,144,134,252,108,62,62,79,107,13,239,188,165,246,228,170,165,242,228,63,14,169,54,239,168,102,102,234,80,16,170,165,254,205,112,126,76,60,246,63,119,195,130,4,21,254,188,121,205,57,153,187,143,70,213,205,214,64,131,183,225,191,218,111,133,139,121,121,187,76,77,164,242,127,25,149,75,29,87,171,61,153,166,117,107,141,30,130,140,125,1,109,21,204,38,146,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c594cadb-29f2-49ba-adfb-e460ee13e9d5"));
		}

		#endregion

	}

	#endregion

}

