namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailLicenseInformationResponseSchema

	/// <exclude/>
	public class EmailLicenseInformationResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailLicenseInformationResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailLicenseInformationResponseSchema(EmailLicenseInformationResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c3bb4a3c-028b-42dd-b032-27136305e1d1");
			Name = "EmailLicenseInformationResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,145,75,75,195,64,20,133,247,133,254,135,75,55,234,162,9,110,173,10,54,237,162,208,138,52,186,18,23,183,153,155,56,48,143,48,15,36,150,254,119,39,153,244,37,20,196,44,102,134,195,153,115,207,55,1,133,146,108,141,5,193,244,101,149,235,210,37,153,86,37,175,188,65,199,181,74,178,121,190,210,140,132,29,14,182,195,1,132,207,91,174,42,200,27,235,72,38,107,175,28,151,148,228,100,56,10,254,221,93,154,12,7,209,154,166,41,220,91,47,37,154,230,241,40,173,169,54,100,73,57,11,97,175,181,178,4,95,220,125,2,22,133,14,129,87,22,4,47,168,149,185,42,181,145,177,202,73,102,122,30,250,62,67,135,161,183,51,88,184,143,168,213,126,19,66,160,16,104,45,204,37,114,177,140,153,139,99,228,186,159,126,7,83,180,148,9,237,217,94,138,33,1,57,30,46,208,236,229,167,147,226,146,59,208,37,80,59,210,130,211,16,72,25,212,100,128,97,147,192,162,132,241,45,140,193,171,206,74,172,231,186,196,118,224,91,145,220,144,185,126,14,63,12,30,96,196,66,124,179,108,35,178,118,244,232,166,231,62,97,231,202,193,236,220,6,91,168,200,77,66,167,176,236,254,74,39,12,33,107,34,72,207,213,241,66,120,201,64,216,114,253,15,162,187,251,102,177,162,75,253,95,15,142,223,213,91,99,216,118,63,12,173,186,18,195,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c3bb4a3c-028b-42dd-b032-27136305e1d1"));
		}

		#endregion

	}

	#endregion

}

