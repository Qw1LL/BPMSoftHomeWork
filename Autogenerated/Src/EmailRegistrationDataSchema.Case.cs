namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailRegistrationDataSchema

	/// <exclude/>
	public class EmailRegistrationDataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailRegistrationDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailRegistrationDataSchema(EmailRegistrationDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("472ffed7-d0b2-439a-902c-a1ccb20b2456");
			Name = "EmailRegistrationData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,107,195,48,12,61,167,208,255,32,218,203,6,163,185,175,31,176,117,99,244,80,40,235,47,240,18,37,8,26,39,216,78,161,148,254,247,201,78,218,184,77,58,178,237,102,201,122,122,79,214,179,20,25,234,66,68,8,175,155,245,54,79,204,100,153,203,132,210,82,9,67,185,28,14,142,195,65,80,106,146,41,108,15,218,96,54,29,14,56,51,86,152,242,53,44,119,66,235,103,120,207,4,237,62,57,165,77,133,123,19,70,112,89,24,134,48,211,101,150,9,117,88,212,49,247,55,130,36,42,72,114,5,104,145,192,26,180,72,81,79,206,152,208,3,21,229,215,142,34,136,44,213,93,38,43,243,162,106,163,242,2,149,33,100,105,27,135,118,162,91,114,92,98,21,163,52,148,16,11,202,19,136,20,10,131,49,188,68,134,246,100,14,86,81,91,210,89,211,71,73,77,233,42,14,142,144,162,153,66,161,104,207,93,64,115,16,156,122,115,187,217,214,213,83,216,177,122,112,119,115,66,127,206,66,40,14,255,66,189,113,200,26,179,138,225,127,179,179,43,246,168,180,91,105,15,114,191,220,114,219,251,192,241,91,94,27,157,126,189,242,72,104,236,67,205,101,205,184,254,115,143,81,198,149,3,109,236,27,146,229,178,95,203,200,228,170,151,37,185,90,72,254,147,172,110,166,17,173,196,100,62,234,244,254,40,92,128,57,20,158,114,94,169,200,64,242,199,158,143,68,68,166,242,230,104,113,61,245,197,224,179,208,1,22,157,120,106,225,90,78,249,17,95,92,155,228,182,89,113,199,125,173,158,93,219,232,124,142,7,183,163,102,236,167,106,105,116,62,84,140,23,65,143,181,117,154,63,12,115,15,237,156,20,184,36,213,193,173,237,231,183,45,125,247,249,142,168,115,126,234,244,13,30,156,237,119,126,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("472ffed7-d0b2-439a-902c-a1ccb20b2456"));
		}

		#endregion

	}

	#endregion

}

