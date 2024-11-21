namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AccountRestResponseSchema

	/// <exclude/>
	public class AccountRestResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountRestResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountRestResponseSchema(AccountRestResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c549c9b6-fa79-24e6-145a-6a71c2ee8ca3");
			Name = "AccountRestResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,93,107,2,49,16,124,86,240,63,44,248,126,247,174,165,96,45,136,96,169,104,253,1,49,89,175,11,185,236,145,15,139,72,255,123,147,220,157,173,173,72,31,178,33,147,201,206,204,18,35,106,116,141,144,8,79,235,151,45,31,124,49,103,115,160,42,88,225,137,77,177,101,73,66,175,80,168,5,154,209,240,60,26,14,130,35,83,193,246,228,60,214,211,209,48,34,99,139,85,36,195,92,11,231,38,48,147,146,131,241,27,116,105,53,108,28,102,90,89,150,240,224,66,93,11,123,122,236,206,115,205,65,129,237,104,240,252,246,10,31,228,223,129,204,129,109,157,61,128,216,115,240,32,218,174,69,223,168,252,209,169,9,123,77,18,100,210,191,37,15,19,184,10,146,238,214,150,143,164,208,126,91,28,196,116,177,94,226,68,70,131,214,19,198,76,235,172,208,222,255,206,145,129,78,21,72,37,135,127,45,246,30,23,129,84,79,94,42,56,67,133,126,10,46,149,207,59,237,151,174,31,64,220,61,29,241,190,202,158,89,199,55,179,76,253,183,72,250,2,62,40,98,216,109,86,247,5,156,183,233,23,92,94,236,172,190,37,51,70,163,218,105,230,115,139,94,131,17,251,2,171,54,138,115,133,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c549c9b6-fa79-24e6-145a-6a71c2ee8ca3"));
		}

		#endregion

	}

	#endregion

}

