namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ActivityCaseValuePairSchema

	/// <exclude/>
	public class ActivityCaseValuePairSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ActivityCaseValuePairSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ActivityCaseValuePairSchema(ActivityCaseValuePairSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("64d1bc1c-8aa8-4e74-bc6c-174824b86bb2");
			Name = "ActivityCaseValuePair";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,144,77,75,196,48,16,134,207,45,244,63,12,236,125,123,87,17,180,7,217,131,80,92,240,62,38,211,58,208,38,33,147,44,20,217,255,110,210,143,197,15,84,188,132,201,59,121,223,121,50,6,71,18,135,138,224,190,125,60,218,46,236,27,107,58,238,163,199,192,214,84,229,91,85,22,81,216,244,112,156,36,208,120,93,149,73,217,121,234,83,27,154,1,69,174,224,78,5,62,113,152,26,20,122,198,33,82,139,236,231,135,117,93,195,141,196,113,68,63,221,174,247,39,114,158,132,76,16,8,175,4,167,108,0,151,28,96,59,80,41,2,208,104,192,53,115,191,165,212,31,98,92,124,25,88,129,16,14,164,65,101,138,159,32,138,244,131,116,94,144,91,111,29,249,192,148,184,219,57,102,233,215,95,72,103,97,203,4,214,137,151,59,38,159,121,190,3,109,68,15,145,245,197,117,208,144,215,87,20,61,133,180,183,84,200,90,156,127,153,153,249,255,55,47,59,254,156,181,35,163,151,21,204,247,69,253,44,158,223,1,136,64,147,57,14,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("64d1bc1c-8aa8-4e74-bc6c-174824b86bb2"));
		}

		#endregion

	}

	#endregion

}

