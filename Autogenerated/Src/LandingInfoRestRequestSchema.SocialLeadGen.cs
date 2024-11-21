namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LandingInfoRestRequestSchema

	/// <exclude/>
	public class LandingInfoRestRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LandingInfoRestRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LandingInfoRestRequestSchema(LandingInfoRestRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e5fd23eb-b854-0a9b-4281-cb8f7bee4cd8");
			Name = "LandingInfoRestRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,144,203,74,196,64,16,69,215,19,200,63,20,184,79,246,142,184,48,226,48,48,98,152,8,174,59,233,74,44,232,71,236,7,50,12,254,187,149,238,140,248,192,77,53,117,251,214,229,84,25,161,209,207,98,64,184,107,31,59,59,134,170,177,102,164,41,58,17,200,154,170,179,3,9,117,64,33,119,104,202,226,92,22,155,232,201,76,208,157,124,64,189,45,11,86,174,28,78,108,134,70,9,239,175,225,32,140,100,203,222,140,246,136,62,28,241,45,242,147,156,117,93,195,141,143,90,11,119,186,93,251,70,217,40,193,101,23,220,63,63,193,59,133,87,32,30,119,58,81,128,232,109,12,160,114,110,117,201,169,191,5,205,177,87,52,192,176,16,252,11,176,97,124,174,95,188,173,179,51,186,64,200,208,109,10,200,255,191,41,147,176,134,2,201,5,224,47,193,5,97,23,73,166,99,134,40,201,190,96,255,192,107,236,37,156,97,194,176,5,191,148,143,149,3,141,204,40,169,207,234,79,145,181,79,186,195,191,140,163,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e5fd23eb-b854-0a9b-4281-cb8f7bee4cd8"));
		}

		#endregion

	}

	#endregion

}

