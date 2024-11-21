namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AccountRequestSchema

	/// <exclude/>
	public class AccountRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountRequestSchema(AccountRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c2254511-5ed7-2a4b-f1ee-949aba2a67b2");
			Name = "AccountRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,144,203,106,195,48,16,69,215,54,248,31,6,178,183,247,109,41,180,9,132,66,75,77,211,31,152,72,99,35,176,53,174,52,90,148,144,127,111,36,229,229,182,100,35,152,199,225,220,145,197,145,252,132,138,224,185,125,219,112,39,245,146,109,103,250,224,80,12,219,122,195,202,224,240,74,168,215,100,171,114,87,149,85,89,44,28,245,135,33,44,7,244,254,14,158,148,226,96,229,131,190,2,121,73,27,77,211,192,131,15,227,136,238,251,241,88,175,62,223,193,229,29,232,216,1,102,12,194,164,81,200,215,39,172,185,226,166,176,29,140,2,21,69,127,60,69,78,115,142,211,58,158,200,137,161,67,166,54,129,121,254,59,76,17,27,241,92,9,218,48,104,30,209,216,168,79,131,153,255,20,192,139,51,182,191,64,171,196,192,14,122,146,123,240,241,217,223,144,181,51,24,140,245,130,86,209,109,231,150,121,72,228,25,124,57,114,255,121,23,100,117,254,135,84,231,238,188,185,255,1,79,184,190,248,237,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c2254511-5ed7-2a4b-f1ee-949aba2a67b2"));
		}

		#endregion

	}

	#endregion

}

