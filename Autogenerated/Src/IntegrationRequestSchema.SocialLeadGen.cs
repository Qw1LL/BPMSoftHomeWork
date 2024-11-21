namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IntegrationRequestSchema

	/// <exclude/>
	public class IntegrationRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IntegrationRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IntegrationRequestSchema(IntegrationRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f58b6f1c-5c09-4a6d-a367-9cc43d2b20d0");
			Name = "IntegrationRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,143,193,106,195,48,16,68,207,53,248,31,22,114,183,239,73,201,161,14,132,64,75,77,210,31,216,218,107,87,32,107,93,105,213,82,66,255,189,178,148,4,167,201,73,218,217,97,246,141,193,129,220,136,13,193,83,253,114,224,78,138,138,77,167,122,111,81,20,155,226,192,141,66,253,76,216,110,201,228,217,49,207,242,236,97,97,169,15,75,168,52,58,183,132,157,17,234,147,127,79,159,158,156,68,87,89,150,240,232,252,48,160,253,89,159,230,74,179,111,193,38,23,108,222,94,225,91,201,7,40,211,177,29,98,2,112,23,198,75,96,113,14,42,103,73,163,127,215,170,129,102,58,127,231,58,44,225,10,123,31,180,218,242,151,106,201,134,255,200,198,81,72,73,93,46,101,130,99,36,43,138,66,163,58,30,72,251,255,53,162,176,37,113,192,22,220,244,206,112,65,43,39,19,243,45,244,153,122,198,59,255,111,80,16,142,208,147,172,166,212,21,252,158,240,200,180,137,48,206,73,189,22,131,246,7,157,89,177,192,199,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f58b6f1c-5c09-4a6d-a367-9cc43d2b20d0"));
		}

		#endregion

	}

	#endregion

}

