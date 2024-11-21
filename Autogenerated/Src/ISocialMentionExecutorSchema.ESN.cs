namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISocialMentionExecutorSchema

	/// <exclude/>
	public class ISocialMentionExecutorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISocialMentionExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISocialMentionExecutorSchema(ISocialMentionExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("731044fc-827f-47a1-af08-e646f558fb9f");
			Name = "ISocialMentionExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,145,207,110,194,48,12,198,207,32,241,14,22,92,54,105,106,239,140,113,216,132,38,14,157,144,250,4,161,117,75,52,154,32,219,225,143,38,222,125,38,1,198,54,109,183,228,203,247,57,63,219,206,116,200,27,83,33,60,47,138,210,55,146,189,120,215,216,54,144,17,235,93,54,43,223,6,253,143,65,191,23,216,186,22,202,3,11,118,143,131,190,42,35,194,86,45,0,115,39,72,141,214,24,195,188,244,149,53,235,2,221,41,61,219,99,21,196,83,180,231,121,14,19,14,93,103,232,48,61,223,23,228,183,182,70,134,14,101,229,107,134,198,19,236,60,189,195,206,202,10,2,35,233,83,172,197,217,165,70,126,83,100,19,150,107,91,129,189,16,252,1,0,218,129,186,175,200,69,250,110,12,139,152,79,143,63,1,163,80,154,45,94,16,192,44,125,144,72,197,32,43,35,87,54,5,80,1,161,10,68,42,169,206,108,90,60,33,255,102,78,202,198,144,233,192,233,248,159,134,103,251,188,30,78,139,116,4,91,103,147,60,122,254,141,124,5,4,247,242,45,178,245,182,214,70,35,160,238,84,76,37,124,247,26,84,188,126,247,0,44,116,90,235,89,185,79,139,237,141,208,213,105,82,241,126,76,235,190,17,143,159,129,211,76,184,55,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("731044fc-827f-47a1-af08-e646f558fb9f"));
		}

		#endregion

	}

	#endregion

}

