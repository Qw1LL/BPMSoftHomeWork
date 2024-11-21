namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ServiceSchemaParameterBuilderSchema

	/// <exclude/>
	public class ServiceSchemaParameterBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ServiceSchemaParameterBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ServiceSchemaParameterBuilderSchema(ServiceSchemaParameterBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5f037ecb-feb6-462e-a7ed-458ad1f12252");
			Name = "ServiceSchemaParameterBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("73951534-6fa4-4e40-b925-a1e2e4e079e3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,83,77,107,194,64,16,61,175,224,127,24,232,37,1,201,15,176,86,169,218,22,193,22,193,210,75,233,97,221,76,116,75,178,73,119,55,22,41,254,247,78,178,166,137,31,104,15,230,146,143,121,251,230,189,153,23,197,19,52,25,23,8,195,217,243,60,141,108,48,74,85,36,151,185,230,86,166,42,152,163,94,75,129,115,177,194,132,183,91,63,237,86,187,197,114,35,213,18,230,27,99,49,33,124,28,163,40,192,38,120,66,133,90,138,219,67,204,84,170,175,250,99,221,73,99,240,200,133,77,181,68,67,117,66,220,104,92,18,21,76,148,69,29,145,174,46,76,246,52,204,184,38,201,84,28,230,50,14,81,151,167,178,124,17,75,1,178,58,116,241,12,35,35,140,141,101,169,155,235,77,207,88,77,210,58,144,46,62,201,76,31,74,164,55,121,80,121,130,154,47,98,236,157,102,236,67,86,61,26,191,176,184,117,54,80,133,206,9,189,52,108,141,98,110,76,23,46,59,122,31,99,196,243,216,14,165,10,73,152,103,55,25,166,145,119,222,151,239,127,212,195,16,69,171,243,157,160,251,175,65,21,163,202,180,92,115,139,96,44,229,66,192,149,39,215,41,90,156,221,135,113,28,127,167,141,15,229,10,89,68,33,226,98,5,222,154,235,154,145,162,208,92,204,14,203,28,27,172,121,156,35,220,213,136,224,5,41,167,97,205,62,160,224,23,169,246,212,126,1,238,250,142,137,57,155,7,229,14,40,252,62,51,28,207,247,253,224,53,157,74,99,61,31,6,131,134,130,183,66,83,17,32,186,142,204,6,247,97,232,213,216,81,26,98,199,185,40,51,199,216,22,202,155,70,155,107,117,60,172,18,228,146,89,197,227,218,217,223,141,120,167,192,81,52,22,124,121,48,149,198,19,127,80,187,181,253,5,65,79,61,57,168,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5f037ecb-feb6-462e-a7ed-458ad1f12252"));
		}

		#endregion

	}

	#endregion

}

