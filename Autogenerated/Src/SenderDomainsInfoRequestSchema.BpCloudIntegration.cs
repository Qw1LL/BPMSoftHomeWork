namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SenderDomainsInfoRequestSchema

	/// <exclude/>
	public class SenderDomainsInfoRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SenderDomainsInfoRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SenderDomainsInfoRequestSchema(SenderDomainsInfoRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("de4bf405-ea8f-4a2e-9f9c-d9b55688e01f");
			Name = "SenderDomainsInfoRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,145,61,111,194,48,16,134,103,34,229,63,156,210,165,93,146,157,143,14,64,85,117,160,66,100,172,58,152,112,73,45,197,118,122,231,32,81,196,127,175,63,8,82,65,168,147,245,158,239,94,223,251,24,180,80,200,157,168,16,230,235,85,105,106,155,47,140,174,101,211,147,176,210,232,124,241,82,174,204,14,91,78,147,99,154,164,201,168,103,169,27,40,15,108,81,229,155,94,91,169,48,47,145,164,104,229,79,152,153,132,190,7,194,198,9,88,180,130,121,12,37,234,29,210,210,40,33,53,191,233,218,108,240,187,71,182,161,183,40,10,152,114,175,148,160,195,243,89,135,57,168,13,1,197,78,176,6,26,180,192,193,9,118,209,10,164,243,202,7,143,226,202,100,202,136,162,101,3,21,97,61,203,254,137,152,207,5,163,139,178,151,21,158,215,203,160,240,94,31,75,97,133,155,178,36,42,251,233,10,93,191,109,101,5,85,88,242,94,54,24,195,173,99,154,140,34,200,11,161,53,153,14,201,74,116,152,214,193,55,222,95,83,9,133,87,180,12,14,10,251,211,126,33,116,100,246,210,3,241,63,57,48,26,224,56,124,158,205,45,156,152,104,133,106,139,244,248,238,39,103,144,13,86,94,103,79,62,230,144,147,45,249,95,119,155,94,26,224,232,95,154,248,69,38,112,58,39,114,32,98,168,160,99,245,111,241,244,11,102,187,101,209,114,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("de4bf405-ea8f-4a2e-9f9c-d9b55688e01f"));
		}

		#endregion

	}

	#endregion

}

