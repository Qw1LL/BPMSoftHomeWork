namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AccountMLangBinderSchema

	/// <exclude/>
	public class AccountMLangBinderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountMLangBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountMLangBinderSchema(AccountMLangBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2b2c9475-0367-40a6-8f73-d4237f998eae");
			Name = "AccountMLangBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5fe5418-b108-401a-ba83-ff1213a966db");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,81,209,106,195,32,20,125,78,161,255,32,221,75,7,35,121,223,74,161,41,27,20,26,86,232,195,158,141,185,205,132,168,65,175,97,101,244,223,119,141,102,100,235,139,162,231,220,227,57,71,205,21,184,158,11,96,229,169,58,155,11,230,123,163,47,178,245,150,163,52,122,185,248,94,46,50,239,164,110,103,4,11,249,27,23,104,172,4,247,114,135,127,64,77,28,165,140,38,140,208,7,11,45,73,177,125,199,157,123,102,59,33,140,215,88,29,185,110,75,169,27,176,35,171,40,10,182,113,94,41,110,175,219,116,78,84,166,124,135,178,35,190,231,45,48,17,116,88,61,142,230,211,100,49,27,237,125,221,73,145,120,247,207,49,242,208,247,175,3,104,60,74,135,160,193,150,220,1,13,82,86,90,127,13,87,128,159,166,33,203,167,81,48,130,73,220,12,96,173,108,128,13,70,54,236,93,147,226,25,185,197,245,36,77,53,34,124,33,19,113,127,100,161,200,44,171,233,165,124,70,159,224,80,99,150,141,21,197,106,175,121,112,187,57,4,223,33,246,1,129,190,196,216,167,41,209,127,96,187,94,37,100,21,213,110,41,13,232,38,6,26,207,241,246,239,229,237,7,191,105,168,144,6,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2b2c9475-0367-40a6-8f73-d4237f998eae"));
		}

		#endregion

	}

	#endregion

}

