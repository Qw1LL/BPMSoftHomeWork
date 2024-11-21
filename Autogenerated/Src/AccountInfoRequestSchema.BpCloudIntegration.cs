namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AccountInfoRequestSchema

	/// <exclude/>
	public class AccountInfoRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountInfoRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountInfoRequestSchema(AccountInfoRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d34c2d1e-3df3-49cb-81c1-5fa5d286583e");
			Name = "AccountInfoRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,81,193,74,196,48,16,61,111,161,255,48,236,94,244,210,222,183,171,176,91,69,68,42,203,214,155,120,200,102,167,53,216,36,53,153,44,212,197,127,55,73,217,138,34,120,73,152,151,247,230,205,155,40,38,209,246,140,35,108,182,85,173,27,202,74,173,26,209,58,195,72,104,149,149,183,117,165,15,216,217,52,57,165,73,154,204,156,21,170,133,122,176,132,50,219,57,69,66,98,86,163,17,172,19,31,81,83,68,222,194,96,235,11,40,59,102,237,18,214,156,107,79,190,87,141,222,225,187,67,75,145,245,124,195,136,121,71,50,140,211,139,7,122,183,239,4,7,30,84,127,136,96,9,27,102,209,251,29,5,199,169,211,108,156,109,50,221,26,221,163,33,129,222,121,27,59,166,241,61,207,115,88,89,39,37,51,195,245,25,184,67,178,160,13,216,112,211,43,2,115,254,244,193,120,140,3,111,56,100,147,56,255,173,94,29,89,231,112,42,159,254,211,127,211,99,246,10,229,30,205,197,163,255,6,184,130,121,144,62,224,48,191,12,187,56,47,195,146,9,59,95,143,111,112,130,22,169,8,227,22,240,57,230,90,160,58,140,209,99,61,162,63,65,143,125,1,133,23,154,101,236,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d34c2d1e-3df3-49cb-81c1-5fa5d286583e"));
		}

		#endregion

	}

	#endregion

}

