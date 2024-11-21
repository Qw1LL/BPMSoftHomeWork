namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BulkEmailQueueJobDispatcherSchema

	/// <exclude/>
	public class BulkEmailQueueJobDispatcherSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BulkEmailQueueJobDispatcherSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BulkEmailQueueJobDispatcherSchema(BulkEmailQueueJobDispatcherSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("36fbfa11-e34f-c606-1a25-604da3e18cd6");
			Name = "BulkEmailQueueJobDispatcher";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("8ded9bc0-26e3-4d8b-ab12-46857e761bcf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,84,193,142,18,65,16,61,179,201,254,67,37,123,217,77,200,16,175,136,36,176,226,6,35,6,29,141,7,227,97,152,46,160,178,61,221,99,117,55,100,98,246,223,173,158,97,16,88,69,145,3,129,170,247,170,95,189,174,106,147,21,232,202,44,71,24,207,103,169,93,250,228,222,154,37,173,2,103,158,172,185,190,250,113,125,213,9,142,204,10,210,202,121,44,36,175,53,230,49,233,146,7,52,200,148,191,220,99,126,21,97,76,210,124,141,42,104,228,231,249,47,184,16,76,81,88,35,57,201,222,48,174,164,34,220,235,204,185,62,140,131,126,156,20,25,233,15,1,3,190,181,139,215,36,34,189,212,227,26,222,235,245,96,224,66,81,100,92,13,119,255,83,228,13,58,88,8,21,48,114,225,123,36,195,150,252,26,164,73,151,173,36,189,180,124,8,201,130,34,52,210,125,201,54,23,140,104,76,218,250,189,131,3,202,176,208,148,67,30,229,157,83,7,162,61,115,120,6,209,133,233,168,44,39,27,52,254,29,137,161,98,160,212,23,151,229,123,111,195,156,109,137,236,9,197,11,249,237,197,111,84,13,164,150,70,70,42,145,87,54,239,69,117,157,178,197,128,221,32,51,41,132,233,196,132,2,57,91,104,28,28,203,153,53,94,124,170,74,28,194,72,107,187,69,117,16,115,240,170,174,217,49,184,61,105,245,0,245,245,27,196,201,144,207,31,33,201,72,169,209,206,223,113,245,134,180,151,238,47,227,88,173,144,167,234,50,86,180,245,175,140,143,88,136,85,210,125,203,251,87,198,165,13,157,210,162,186,154,243,212,76,126,231,6,141,106,174,253,120,6,102,232,215,86,253,255,0,108,44,41,104,87,80,70,240,214,121,142,43,184,181,252,88,111,252,123,89,253,46,236,162,193,33,199,192,221,238,90,101,70,247,235,187,95,228,25,153,224,81,87,82,109,112,102,196,135,183,141,41,18,124,96,27,202,230,160,147,115,219,3,187,32,147,78,86,77,77,83,93,26,126,177,51,149,92,243,228,124,22,104,31,60,135,40,183,21,213,223,247,214,222,65,65,110,73,140,83,35,45,133,250,129,234,195,97,27,179,103,249,36,149,253,246,115,43,171,93,221,197,71,170,243,244,219,59,105,162,199,65,137,253,4,246,215,24,171,60,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("36fbfa11-e34f-c606-1a25-604da3e18cd6"));
		}

		#endregion

	}

	#endregion

}

