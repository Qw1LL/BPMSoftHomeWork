namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AccountApiFormFieldsResponseSchema

	/// <exclude/>
	public class AccountApiFormFieldsResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountApiFormFieldsResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountApiFormFieldsResponseSchema(AccountApiFormFieldsResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b2106199-c783-417b-8ee7-13bea17b63c5");
			Name = "AccountApiFormFieldsResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,84,193,78,227,48,16,61,23,137,127,176,224,194,94,218,59,160,74,221,34,88,86,176,155,165,189,173,246,96,236,105,107,41,177,179,30,7,182,66,252,251,78,18,39,109,82,167,68,168,136,139,165,204,188,121,243,252,50,30,166,121,2,152,114,1,236,107,116,63,51,11,55,156,26,189,80,203,204,114,167,140,30,206,140,80,60,190,3,46,111,64,31,31,189,28,31,13,50,84,122,201,126,192,179,51,26,243,138,239,104,244,69,157,152,173,209,65,66,52,113,12,34,231,192,33,149,130,85,130,48,132,58,181,176,164,40,155,198,28,241,156,77,132,48,153,118,147,84,93,27,155,92,43,136,37,62,144,36,170,131,2,63,26,141,216,37,102,73,194,237,122,236,191,175,230,63,153,91,113,199,36,160,176,234,209,2,155,68,183,204,250,58,182,176,38,97,188,100,102,8,246,73,9,24,86,92,163,45,178,52,123,140,149,96,34,215,178,87,10,59,103,13,43,40,238,34,107,158,148,4,187,145,59,32,127,232,108,223,241,155,146,18,116,65,88,230,27,109,27,217,65,69,81,115,80,151,20,172,83,64,68,81,81,231,1,191,115,223,125,118,125,118,146,255,201,147,47,127,138,148,231,71,103,139,95,69,25,246,194,150,224,46,200,12,58,94,195,12,92,227,51,216,48,199,164,200,5,89,78,65,203,82,107,25,240,241,118,184,229,9,141,25,130,118,1,63,234,204,251,189,80,178,117,11,69,115,112,43,251,152,32,202,238,115,248,231,194,78,76,55,128,67,218,145,161,51,73,78,250,43,163,209,170,97,77,103,2,160,3,154,228,47,216,207,167,191,94,65,183,81,149,198,15,113,234,62,139,157,74,99,152,174,12,189,237,55,61,235,130,127,230,115,251,52,7,35,11,18,22,74,131,220,227,91,8,244,126,183,210,154,173,216,115,225,235,70,77,208,33,110,220,165,175,37,111,181,89,193,232,181,121,105,119,10,221,229,214,134,30,111,175,107,12,73,12,239,147,16,173,223,36,227,106,165,244,162,219,89,1,65,230,29,20,53,217,173,236,221,47,252,124,176,179,115,24,95,105,232,96,235,161,102,51,70,251,52,236,142,238,56,48,206,193,126,173,57,42,163,205,224,235,127,80,252,133,164,52,9,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b2106199-c783-417b-8ee7-13bea17b63c5"));
		}

		#endregion

	}

	#endregion

}

