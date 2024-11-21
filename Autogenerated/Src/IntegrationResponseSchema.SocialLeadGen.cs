namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IntegrationResponseSchema

	/// <exclude/>
	public class IntegrationResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IntegrationResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IntegrationResponseSchema(IntegrationResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("34726720-1e07-4f00-be95-bf2446ea34bc");
			Name = "IntegrationResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,145,63,79,195,48,16,197,231,70,202,119,56,149,5,150,100,111,128,129,84,170,144,90,136,26,54,196,224,38,151,96,41,182,35,251,2,42,21,223,157,115,254,148,20,22,199,247,252,252,238,126,142,22,10,93,43,10,132,135,108,151,155,138,162,212,232,74,214,157,21,36,141,142,114,83,72,209,108,81,148,27,212,97,112,10,131,69,231,164,174,33,63,58,66,21,237,59,77,82,97,148,163,101,159,252,234,111,37,97,192,190,43,139,53,23,144,54,194,185,21,60,106,194,122,72,221,74,71,123,110,107,180,195,222,26,199,49,220,186,78,41,97,143,247,99,157,54,166,43,193,142,54,88,191,60,195,167,164,119,144,186,50,86,245,57,96,42,46,207,177,209,148,20,207,162,94,215,130,4,51,145,21,5,189,177,208,118,135,70,22,80,248,169,230,67,77,3,193,10,46,160,89,167,204,154,15,89,162,253,29,122,193,47,193,235,25,146,29,45,90,146,200,164,89,223,97,56,255,75,214,11,27,36,7,198,130,243,223,25,0,52,252,48,158,226,63,198,192,177,67,117,64,123,253,196,63,13,238,96,57,187,234,79,151,55,158,111,2,156,161,205,247,222,8,39,168,145,18,223,63,129,239,17,4,117,57,176,244,245,160,94,138,172,253,0,10,15,170,156,47,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("34726720-1e07-4f00-be95-bf2446ea34bc"));
		}

		#endregion

	}

	#endregion

}

