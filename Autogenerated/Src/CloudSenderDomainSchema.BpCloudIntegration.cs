namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CloudSenderDomainSchema

	/// <exclude/>
	public class CloudSenderDomainSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CloudSenderDomainSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CloudSenderDomainSchema(CloudSenderDomainSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e61dae9a-2655-48a6-bc4a-42efa1e9c942");
			Name = "CloudSenderDomain";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,146,193,78,195,48,12,134,207,171,212,119,176,180,251,122,103,136,3,101,112,64,149,42,250,4,89,227,148,136,54,169,156,4,81,77,123,119,220,116,67,21,236,80,6,151,70,249,227,248,251,82,217,136,14,93,47,106,132,251,178,168,172,242,155,220,26,165,155,64,194,107,107,54,249,174,42,172,196,214,165,201,33,77,86,107,194,134,99,200,91,225,220,13,47,54,200,10,141,68,122,176,157,208,38,77,184,40,203,50,184,117,161,235,4,13,119,167,253,11,246,132,14,141,119,160,141,178,212,197,246,32,246,54,120,144,241,46,112,12,92,34,181,105,192,191,34,32,167,173,219,156,59,102,179,150,125,216,183,186,134,122,212,184,100,177,98,89,254,126,249,150,100,123,36,175,145,165,203,120,119,58,255,174,26,131,39,100,203,232,194,235,40,114,242,19,82,242,27,162,208,79,163,179,146,243,52,250,79,34,112,128,6,253,118,236,180,133,227,111,144,239,72,90,233,122,250,75,72,100,105,17,118,55,86,254,19,245,13,135,69,204,103,28,174,39,22,31,139,57,92,122,53,166,42,31,23,115,170,94,253,233,73,206,11,31,56,82,179,217,89,6,158,46,94,0,175,121,184,167,73,142,251,41,157,135,199,79,184,99,156,59,200,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e61dae9a-2655-48a6-bc4a-42efa1e9c942"));
		}

		#endregion

	}

	#endregion

}

