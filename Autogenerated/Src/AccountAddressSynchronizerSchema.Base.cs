namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AccountAddressSynchronizerSchema

	/// <exclude/>
	public class AccountAddressSynchronizerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountAddressSynchronizerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountAddressSynchronizerSchema(AccountAddressSynchronizerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("74191a0d-e4ee-4056-8a11-3e962a99a246");
			Name = "AccountAddressSynchronizer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,83,77,111,219,48,12,61,187,64,254,3,145,94,28,32,112,238,89,87,160,77,131,96,135,20,1,140,253,0,85,102,18,1,182,228,81,82,138,108,200,127,31,101,203,249,170,151,109,135,30,69,62,62,190,71,82,90,84,104,107,33,17,158,87,203,220,172,93,54,51,122,173,54,158,132,83,70,15,238,126,13,238,18,111,149,222,192,92,59,229,246,249,94,203,45,25,173,126,54,128,47,199,116,190,183,14,43,46,47,75,148,33,101,179,5,106,36,37,79,152,83,15,194,254,104,214,116,81,104,57,205,128,123,194,13,83,193,172,20,214,78,225,73,74,227,181,123,42,10,66,107,79,82,144,26,244,100,50,129,7,235,171,74,208,254,49,190,87,100,118,170,64,11,21,186,173,41,44,172,13,129,61,86,134,254,162,101,5,209,210,194,187,114,219,46,152,117,180,147,51,222,218,191,149,74,130,12,162,110,104,130,41,60,11,139,189,106,147,48,215,147,61,158,150,35,47,13,177,201,85,195,222,24,234,58,253,185,71,250,221,34,113,185,110,103,14,254,226,57,142,75,235,172,181,175,17,76,3,119,242,198,226,210,235,130,11,228,24,134,177,245,112,4,141,226,67,171,235,30,117,209,106,143,239,104,100,217,14,153,77,144,113,76,137,69,244,209,61,193,236,144,136,23,2,223,78,151,242,112,117,84,156,241,149,94,138,186,230,245,60,194,2,221,45,128,77,163,182,164,23,53,51,85,45,248,154,195,218,29,49,126,254,195,139,242,44,250,21,174,34,241,100,136,239,215,229,125,37,233,40,28,111,146,236,4,65,24,226,165,28,38,12,193,236,239,178,91,150,143,12,25,47,58,213,248,14,183,234,163,231,36,55,158,100,36,120,229,223,204,237,135,139,85,254,58,28,183,249,23,180,78,233,179,250,62,208,197,56,122,199,52,8,184,195,167,74,158,255,139,228,35,232,63,37,19,58,79,186,103,93,77,186,231,172,99,236,60,116,248,13,127,8,152,238,46,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("74191a0d-e4ee-4056-8a11-3e962a99a246"));
		}

		#endregion

	}

	#endregion

}

