namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EsqDataProviderSchema

	/// <exclude/>
	public class EsqDataProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EsqDataProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EsqDataProviderSchema(EsqDataProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1b749fe1-786e-461b-a25c-c9db1807ffe5");
			Name = "EsqDataProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("907f2de3-5104-49b3-a54a-bb8730240b72");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,83,95,111,218,48,16,127,78,165,126,135,147,250,18,164,202,31,160,163,145,182,22,38,180,161,33,96,123,157,76,184,82,111,137,29,206,54,2,77,251,238,59,219,176,44,41,67,237,11,198,231,59,255,254,57,90,214,104,27,89,34,124,152,77,23,230,201,137,7,163,159,212,198,147,116,202,104,49,199,198,144,83,122,35,198,210,186,180,27,233,141,210,40,70,118,123,125,245,235,250,42,243,150,207,97,113,176,14,107,30,175,42,44,195,172,21,31,81,35,169,242,93,191,231,179,210,219,23,197,229,51,161,92,7,164,165,180,63,109,123,222,18,35,60,95,21,35,237,148,83,120,102,168,229,255,40,157,92,24,79,37,138,247,43,235,72,38,146,60,194,67,55,132,27,222,193,67,37,173,189,3,150,22,218,103,100,118,106,141,20,91,26,191,170,84,9,101,232,232,55,192,29,76,254,221,15,143,231,11,12,94,20,60,205,62,241,239,95,156,177,194,106,205,64,51,82,59,233,48,29,54,105,3,193,7,163,171,3,124,181,72,28,135,78,126,194,119,223,217,39,230,217,13,234,117,186,181,11,193,141,172,210,151,206,80,0,138,236,143,56,73,73,79,67,222,67,235,130,13,32,36,157,101,61,14,112,223,235,11,9,100,191,47,51,155,162,123,54,255,85,63,153,179,252,47,44,255,81,197,27,37,29,134,44,132,35,188,5,179,250,17,252,12,218,118,72,110,105,218,158,60,190,129,3,96,92,110,47,94,147,214,2,208,110,249,185,250,90,79,101,19,5,70,137,132,206,147,238,28,138,14,210,30,238,11,216,139,79,200,48,241,127,194,228,231,238,210,196,55,89,121,204,247,34,174,131,193,219,60,121,25,84,248,30,134,147,145,246,53,146,92,85,56,124,133,69,69,1,76,39,228,155,119,222,34,216,184,156,226,220,73,58,178,111,191,91,206,52,53,133,47,60,136,74,206,182,13,121,239,17,36,129,39,223,2,91,49,38,83,207,209,250,202,229,253,235,69,34,114,172,7,251,206,165,121,138,177,101,210,38,117,209,209,84,237,22,185,246,7,222,39,136,40,232,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b749fe1-786e-461b-a25c-c9db1807ffe5"));
		}

		#endregion

	}

	#endregion

}

