namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MailingServiceSettingsSchema

	/// <exclude/>
	public class MailingServiceSettingsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MailingServiceSettingsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MailingServiceSettingsSchema(MailingServiceSettingsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("aab368d1-5d3d-4df2-8f5a-686ab5543ad8");
			Name = "MailingServiceSettings";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,145,63,79,195,48,16,197,231,86,234,119,56,181,11,44,201,78,1,9,90,196,148,42,34,98,66,12,110,114,9,22,254,19,217,231,74,165,226,187,115,78,26,160,165,72,176,216,186,231,247,124,191,179,141,208,232,91,81,34,220,230,89,97,107,74,22,214,212,178,9,78,144,180,38,89,220,21,153,173,80,249,201,120,55,25,143,130,151,166,129,98,235,9,117,242,16,12,73,141,73,129,78,10,37,223,186,196,124,50,102,223,204,97,195,5,44,148,240,254,2,50,33,21,7,217,184,145,37,22,72,196,149,239,156,105,154,194,165,15,90,11,183,189,222,215,131,1,108,13,244,130,80,42,27,42,240,125,58,25,66,233,183,212,211,82,144,96,114,114,162,164,103,22,218,176,86,178,228,36,247,255,181,253,136,71,226,245,147,54,119,182,69,71,18,25,57,239,46,232,207,143,25,59,225,30,137,1,29,99,241,30,41,13,63,229,64,220,58,187,145,21,186,8,251,147,182,199,205,80,175,209,157,173,98,236,10,166,67,100,122,30,249,135,1,60,185,248,226,249,254,112,21,205,59,104,144,230,177,241,28,222,255,74,40,12,216,182,181,142,130,145,180,5,178,160,197,235,23,40,84,88,139,160,232,31,192,193,227,128,117,227,151,125,252,16,126,109,173,130,199,19,182,83,35,204,208,84,253,63,116,117,175,30,138,172,125,0,230,158,196,135,176,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aab368d1-5d3d-4df2-8f5a-686ab5543ad8"));
		}

		#endregion

	}

	#endregion

}

