namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AccountApiPredefinedFieldsResponseSchema

	/// <exclude/>
	public class AccountApiPredefinedFieldsResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountApiPredefinedFieldsResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountApiPredefinedFieldsResponseSchema(AccountApiPredefinedFieldsResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1521232e-cc77-4fda-b150-54054f3f6789");
			Name = "AccountApiPredefinedFieldsResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,81,193,78,194,64,16,61,67,194,63,76,240,162,151,246,14,132,4,49,26,13,106,21,111,196,195,178,157,214,77,218,221,102,103,139,33,132,127,119,74,183,96,43,70,47,147,236,155,247,222,188,153,213,34,71,42,132,68,184,142,30,151,38,113,193,220,232,68,165,165,21,78,25,29,44,141,84,34,91,160,136,239,80,15,250,187,65,191,87,146,210,41,60,225,167,51,154,42,197,3,25,61,62,54,150,91,114,152,179,77,150,161,172,60,40,96,41,90,37,153,195,172,11,139,41,163,48,207,4,209,8,102,82,154,82,187,89,161,34,139,49,38,74,99,124,171,48,139,233,149,131,177,26,15,170,48,12,97,66,101,158,11,187,157,250,247,205,219,51,184,15,225,32,70,146,86,173,45,194,44,186,7,235,117,144,88,147,131,168,253,129,208,110,148,196,160,241,10,191,153,21,229,58,83,18,100,149,232,31,129,96,4,173,179,48,238,34,107,54,42,70,123,10,221,227,91,113,237,238,123,50,125,41,89,199,157,154,214,202,112,142,212,107,12,143,142,60,179,64,235,20,86,182,7,185,39,172,170,31,241,221,237,229,176,104,239,49,188,122,63,176,252,68,114,182,250,182,206,178,176,131,20,221,152,207,198,101,223,12,70,29,215,179,107,192,227,93,248,175,124,191,198,107,150,37,31,209,39,92,40,114,147,159,39,153,158,57,19,157,203,221,201,87,163,109,112,255,5,118,189,233,92,8,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1521232e-cc77-4fda-b150-54054f3f6789"));
		}

		#endregion

	}

	#endregion

}

