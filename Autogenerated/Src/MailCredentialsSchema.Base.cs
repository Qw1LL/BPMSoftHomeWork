namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MailCredentialsSchema

	/// <exclude/>
	public class MailCredentialsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MailCredentialsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MailCredentialsSchema(MailCredentialsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9fb91463-07a1-4af3-bf11-902a4739cfa3");
			Name = "MailCredentials";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,193,138,194,64,12,134,207,22,250,14,1,239,62,128,158,186,34,172,7,161,208,250,0,99,39,118,7,166,147,146,164,7,17,223,125,103,90,17,21,172,151,129,36,223,252,9,95,48,29,74,111,26,132,159,242,80,209,89,87,7,227,60,228,217,53,207,242,108,177,100,108,29,5,216,122,35,178,134,52,219,50,90,12,234,140,151,17,233,135,147,119,13,52,137,120,7,96,13,207,85,164,167,216,71,110,201,212,35,171,195,24,94,142,65,211,252,30,42,202,46,180,240,75,162,112,133,22,117,3,146,158,219,19,227,130,66,73,252,25,56,17,121,56,10,86,226,191,50,123,235,113,118,83,237,58,164,225,243,178,251,197,21,6,139,188,235,162,142,194,90,198,168,102,118,117,165,134,181,142,138,102,169,189,20,129,194,165,163,65,138,65,255,146,214,198,104,242,248,246,109,84,28,79,152,44,143,245,212,125,109,222,254,1,151,16,140,195,254,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9fb91463-07a1-4af3-bf11-902a4739cfa3"));
		}

		#endregion

	}

	#endregion

}

