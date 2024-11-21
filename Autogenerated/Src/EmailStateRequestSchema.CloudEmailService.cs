namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailStateRequestSchema

	/// <exclude/>
	public class EmailStateRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailStateRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailStateRequestSchema(EmailStateRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e71e3e74-ee53-49b0-8b08-eff380e4bbfa");
			Name = "EmailStateRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b39fd9cb-6840-4142-8022-7c9d0489d323");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,146,77,79,195,48,12,134,207,157,180,255,96,141,11,92,218,59,95,147,24,211,180,195,208,180,114,67,28,178,214,237,34,218,164,36,14,210,64,252,119,156,164,67,140,47,33,16,151,166,118,236,87,207,27,91,137,22,109,39,10,132,139,229,34,215,21,165,19,173,42,89,59,35,72,106,53,28,60,13,7,137,179,82,213,144,111,45,97,123,242,46,78,87,78,145,108,49,205,209,72,209,200,199,208,199,85,92,119,96,176,230,0,38,141,176,246,24,166,173,144,77,78,130,112,133,247,14,45,133,162,44,203,224,212,186,182,21,102,123,222,199,43,236,12,90,84,100,193,196,82,208,21,208,6,1,189,6,88,47,2,22,205,131,44,48,221,137,100,111,84,110,46,5,9,182,66,70,20,116,203,137,206,173,27,89,64,225,81,62,35,73,216,40,127,95,153,151,70,119,104,72,34,131,47,67,111,188,127,143,27,18,51,100,82,109,152,136,207,136,56,47,129,52,20,27,44,238,60,224,71,194,136,184,192,118,141,230,240,138,199,0,103,48,10,189,243,114,116,228,145,119,204,51,39,203,113,100,102,85,63,144,36,169,145,252,36,146,196,246,63,207,63,197,227,183,51,4,165,127,192,254,77,217,167,212,37,84,161,66,81,52,96,127,131,31,180,57,143,251,6,124,230,154,119,100,12,249,174,224,207,54,80,149,255,100,130,149,191,179,48,141,215,95,26,128,126,143,88,38,174,82,136,163,175,253,36,231,94,0,8,33,124,28,127,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e71e3e74-ee53-49b0-8b08-eff380e4bbfa"));
		}

		#endregion

	}

	#endregion

}

