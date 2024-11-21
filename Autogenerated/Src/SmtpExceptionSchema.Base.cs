namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SmtpExceptionSchema

	/// <exclude/>
	public class SmtpExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SmtpExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SmtpExceptionSchema(SmtpExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f9b38078-c13e-40e2-9656-40242891b8a4");
			Name = "SmtpException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,81,75,106,196,48,12,93,39,144,59,8,102,51,133,208,3,36,116,209,207,44,7,2,62,129,199,85,131,33,177,141,37,151,150,50,119,175,237,36,157,38,12,165,148,46,12,214,147,244,62,200,200,17,201,73,133,240,208,29,133,125,225,219,163,212,67,85,126,84,101,17,72,155,30,196,59,49,142,109,85,70,100,231,177,215,214,192,227,32,137,26,16,35,187,195,155,66,199,17,204,3,46,156,6,173,64,165,254,186,13,13,220,59,23,155,50,85,23,56,9,21,233,45,220,157,183,14,61,107,140,2,93,72,27,153,121,161,38,246,201,213,97,140,54,5,154,103,193,146,3,77,52,69,143,220,230,143,243,250,85,50,2,205,192,121,226,216,197,133,73,102,174,151,60,214,68,222,160,216,250,235,170,171,40,251,217,3,174,61,212,112,29,127,66,82,94,231,205,155,108,174,129,147,36,220,255,48,54,199,217,134,188,219,82,183,223,178,253,175,211,26,46,39,210,198,160,255,42,127,153,161,222,174,253,37,211,230,94,19,186,6,207,159,221,130,149,135,194,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f9b38078-c13e-40e2-9656-40242891b8a4"));
		}

		#endregion

	}

	#endregion

}

