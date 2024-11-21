namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImapSyncJobSchedulerSchema

	/// <exclude/>
	public class IImapSyncJobSchedulerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImapSyncJobSchedulerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImapSyncJobSchedulerSchema(IImapSyncJobSchedulerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("42c2b310-e629-40cf-90c2-3202b6197a53");
			Name = "IImapSyncJobScheduler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("80eb4b00-d20b-4335-a2cc-1f02c0e63f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,81,107,219,48,16,126,78,161,255,225,72,95,86,8,246,123,155,24,54,119,12,15,12,102,217,126,128,44,159,27,117,178,20,116,82,182,108,244,191,239,100,59,233,178,46,93,25,180,180,47,70,58,157,190,251,190,239,228,51,162,67,90,11,137,240,174,42,151,182,245,73,41,148,62,61,249,121,122,50,9,164,204,53,44,183,228,177,75,114,171,53,74,175,172,161,228,3,26,116,74,94,238,115,118,119,115,235,144,163,28,63,115,120,205,185,80,24,143,174,101,252,11,40,138,78,172,151,91,35,63,218,122,41,87,216,4,141,174,79,78,211,20,230,20,186,78,184,109,54,238,43,103,55,170,65,130,14,253,202,54,4,173,117,80,148,111,43,32,134,88,57,107,212,15,17,233,192,141,173,65,197,50,162,167,151,236,0,211,223,16,215,161,214,74,14,105,145,205,49,50,19,214,205,223,61,253,114,40,126,1,85,15,48,28,254,73,183,15,228,43,148,95,163,23,71,57,226,119,69,158,51,34,193,251,12,135,200,90,56,209,129,225,166,44,166,129,208,229,214,152,193,245,105,54,39,68,144,14,219,197,244,203,225,81,154,177,50,242,194,72,76,230,105,143,241,119,200,126,141,236,1,77,179,106,191,126,208,218,251,128,14,125,112,134,178,207,46,224,12,84,251,15,197,51,176,92,228,155,34,132,86,104,138,12,119,8,17,178,182,86,195,149,69,26,155,241,62,222,121,115,40,16,14,173,152,65,113,165,250,21,123,55,39,239,216,84,174,82,223,240,113,6,119,26,97,1,38,104,125,126,249,64,219,62,97,103,55,120,92,253,235,237,213,198,170,102,148,55,90,251,124,174,230,78,112,238,139,116,149,7,151,109,10,83,42,19,60,178,181,71,31,239,144,201,111,24,101,232,127,219,167,239,86,238,80,248,199,118,139,103,217,200,113,175,102,22,145,38,255,213,198,51,52,205,48,243,250,253,237,48,196,15,130,183,191,0,129,130,143,170,44,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("42c2b310-e629-40cf-90c2-3202b6197a53"));
		}

		#endregion

	}

	#endregion

}

