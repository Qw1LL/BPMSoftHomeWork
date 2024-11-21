namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailStateSchema

	/// <exclude/>
	public class EmailStateSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailStateSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailStateSchema(EmailStateSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b3683c63-c39e-be9c-9916-00ffa0f49f4f");
			Name = "EmailState";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b39fd9cb-6840-4142-8022-7c9d0489d323");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,145,203,10,194,48,16,69,215,45,244,31,6,220,138,245,181,18,43,248,232,82,80,252,130,177,78,107,32,73,75,154,136,34,254,187,105,106,69,81,235,242,78,14,231,78,24,137,130,202,2,19,130,197,102,189,203,83,221,91,230,50,101,153,81,168,89,46,3,255,26,248,129,239,117,20,101,54,66,44,141,152,64,44,144,241,157,70,77,238,49,12,67,152,150,70,8,84,151,217,35,59,4,202,138,41,123,13,19,190,64,133,217,115,150,0,89,225,155,207,179,133,222,135,210,13,86,148,162,225,186,182,86,210,79,171,183,53,100,232,0,17,244,187,110,183,239,166,185,74,142,236,132,28,168,106,254,161,122,66,17,12,218,100,203,92,20,156,180,109,117,255,248,46,107,32,43,27,182,201,226,115,193,84,187,170,65,34,24,181,174,133,50,33,254,103,171,134,137,96,108,243,173,190,53,201,67,125,238,42,218,217,29,66,124,43,225,36,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b3683c63-c39e-be9c-9916-00ffa0f49f4f"));
		}

		#endregion

	}

	#endregion

}

