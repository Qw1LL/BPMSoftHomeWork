namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AccountConstsSchema

	/// <exclude/>
	public class AccountConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountConstsSchema(AccountConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a6894da9-d220-412d-8d46-9dc9c008ba69");
			Name = "AccountConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("912fb492-38c7-4dbe-88b2-46a261777d72");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,85,143,177,10,194,48,24,132,231,6,242,14,63,186,232,16,181,88,49,34,14,54,70,113,16,5,159,32,166,81,2,109,82,154,4,41,210,119,183,45,42,120,219,221,125,28,92,112,218,60,224,90,59,175,138,53,70,24,25,81,40,87,10,169,32,189,156,174,246,238,39,204,154,187,126,132,74,120,109,13,70,47,140,162,50,220,114,45,193,249,54,147,32,115,225,28,108,165,180,193,248,150,118,222,181,76,199,69,211,41,12,191,2,2,189,249,37,29,240,191,84,41,145,89,147,215,112,8,58,131,115,168,152,45,74,97,234,207,246,49,131,13,24,245,236,235,209,128,207,103,52,93,210,152,204,217,34,37,9,103,41,161,43,190,39,11,22,243,93,178,219,38,148,242,193,184,125,21,53,24,53,111,39,254,7,55,234,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a6894da9-d220-412d-8d46-9dc9c008ba69"));
		}

		#endregion

	}

	#endregion

}

