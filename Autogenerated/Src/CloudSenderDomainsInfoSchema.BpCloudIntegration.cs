namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CloudSenderDomainsInfoSchema

	/// <exclude/>
	public class CloudSenderDomainsInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CloudSenderDomainsInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CloudSenderDomainsInfoSchema(CloudSenderDomainsInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f2e8d79a-460e-4a42-b17f-4d076f55b6e6");
			Name = "CloudSenderDomainsInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,75,111,219,48,12,62,183,64,255,3,209,30,118,179,239,75,215,195,146,173,232,186,12,65,12,244,174,90,148,39,68,150,12,81,206,16,20,251,239,163,36,199,72,31,41,156,29,6,236,18,193,36,245,61,72,133,86,180,72,157,168,17,62,175,150,149,83,161,152,59,171,116,211,123,17,180,179,197,252,75,181,116,18,13,93,156,63,93,156,159,245,164,109,3,213,142,2,182,92,105,12,214,177,140,138,91,180,232,117,61,27,107,126,224,175,192,137,136,248,141,156,229,4,167,174,60,54,92,14,115,35,136,62,242,225,122,89,161,149,232,23,174,21,218,210,157,85,46,85,150,101,9,215,212,183,173,240,187,155,225,123,141,157,71,66,27,8,248,236,24,29,193,41,8,63,17,8,253,86,179,9,229,60,231,130,215,184,141,34,100,70,77,97,190,40,99,12,57,100,138,61,69,121,192,209,245,143,70,215,80,71,113,71,181,157,113,27,248,119,180,178,242,174,67,31,52,178,159,85,2,200,249,151,6,82,224,22,89,123,210,194,103,212,189,23,40,172,4,29,62,112,178,203,253,28,33,14,5,14,160,136,194,144,131,218,163,250,116,121,40,241,178,76,85,131,143,239,154,194,245,43,27,55,48,216,129,39,104,48,204,162,150,25,252,62,73,52,42,209,155,0,114,163,219,2,248,189,132,132,183,21,166,71,208,10,58,239,182,154,9,243,141,248,26,12,194,6,119,105,12,194,152,189,235,35,38,7,249,196,83,228,113,45,50,217,226,254,110,121,207,16,255,137,104,86,187,198,218,121,249,247,130,171,213,215,172,110,18,99,213,169,135,100,229,31,241,45,56,190,57,141,49,191,187,200,161,101,90,46,252,79,141,45,154,198,151,46,63,140,119,79,236,238,122,191,47,40,136,208,79,27,98,149,74,79,167,168,121,95,190,79,160,109,224,23,40,167,183,110,196,230,101,77,162,153,54,162,101,174,125,139,228,138,23,66,222,95,233,59,71,159,7,57,246,7,233,152,203,175,28,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f2e8d79a-460e-4a42-b17f-4d076f55b6e6"));
		}

		#endregion

	}

	#endregion

}

