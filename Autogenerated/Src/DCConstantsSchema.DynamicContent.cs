namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DCConstantsSchema

	/// <exclude/>
	public class DCConstantsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DCConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DCConstantsSchema(DCConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b71266ae-26dd-4d4b-bb2e-0ecca246e43c");
			Name = "DCConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ad993b20-8db8-48d6-9762-5a83fb4975c6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,145,221,106,194,64,16,133,175,21,124,135,65,111,218,139,24,109,99,45,246,7,204,143,165,23,5,193,190,192,152,76,116,33,217,132,221,73,37,20,223,189,187,27,91,212,222,100,153,51,147,115,190,217,149,88,146,174,49,37,8,215,31,155,42,231,113,84,201,92,236,26,133,44,42,57,142,91,137,165,72,141,200,36,121,208,255,30,244,123,141,22,114,7,155,86,51,149,79,131,190,81,70,138,118,102,26,162,2,181,94,64,28,153,121,205,40,89,187,182,239,251,240,172,155,178,68,213,190,158,106,235,136,66,106,72,79,163,240,133,69,67,26,242,74,65,214,165,218,158,141,133,92,85,165,45,44,152,227,130,76,164,246,68,37,72,143,127,35,252,179,140,186,217,22,198,193,88,179,53,178,96,151,92,61,179,138,249,254,177,175,85,85,147,98,227,183,128,181,251,185,235,251,87,240,78,136,163,37,179,18,219,134,9,114,81,48,41,224,182,38,16,25,28,246,34,221,67,70,58,53,125,179,143,38,84,86,64,70,67,163,236,213,161,238,150,181,224,255,201,175,208,21,97,86,201,162,133,183,198,184,159,5,175,92,238,167,137,125,207,224,5,36,29,220,200,205,48,78,150,73,24,7,51,47,137,166,43,47,88,205,66,47,156,132,145,151,204,31,130,249,100,54,125,188,187,15,134,183,221,203,245,70,36,179,238,6,92,125,236,222,243,66,60,254,0,230,27,255,217,37,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b71266ae-26dd-4d4b-bb2e-0ecca246e43c"));
		}

		#endregion

	}

	#endregion

}

