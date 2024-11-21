namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FastReportDataSourceBuilderResolverSchema

	/// <exclude/>
	public class FastReportDataSourceBuilderResolverSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FastReportDataSourceBuilderResolverSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FastReportDataSourceBuilderResolverSchema(FastReportDataSourceBuilderResolverSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e92979a3-208b-459e-b5ac-12cfe09c40e1");
			Name = "FastReportDataSourceBuilderResolver";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("907f2de3-5104-49b3-a54a-bb8730240b72");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,83,89,107,227,48,16,126,118,161,255,97,104,95,92,8,254,1,61,2,73,122,16,104,216,146,100,159,139,106,79,189,2,89,114,117,100,99,150,253,239,59,182,156,186,182,220,144,125,49,210,104,142,239,24,75,86,160,41,89,138,48,127,89,109,212,187,77,22,74,190,243,220,105,102,185,146,201,26,75,165,45,151,121,242,200,140,245,183,7,153,115,137,231,103,127,206,207,34,103,232,13,54,149,177,88,220,12,238,212,74,8,76,235,62,38,121,66,137,154,167,65,206,51,151,31,93,240,116,16,99,53,26,199,163,84,150,90,165,57,154,240,189,235,125,207,44,219,40,167,83,76,102,111,198,106,230,145,31,43,233,224,12,75,168,232,82,99,78,55,88,8,102,204,53,116,185,221,160,185,227,34,67,189,70,163,196,14,117,83,86,186,55,193,83,72,235,170,83,138,224,26,150,71,58,70,228,18,125,63,209,60,114,20,25,193,121,209,124,199,44,250,199,210,95,64,35,203,148,20,21,252,52,168,201,3,233,221,131,87,215,187,223,140,214,140,97,93,49,201,114,194,248,154,13,67,94,163,232,18,101,230,145,245,97,210,48,210,211,213,182,213,96,27,77,90,172,94,159,19,148,137,7,44,250,36,174,160,222,223,40,26,112,131,59,24,33,27,133,4,40,81,226,239,99,172,227,193,192,166,211,223,227,188,87,104,127,169,111,253,9,141,134,5,233,111,49,136,199,1,38,180,172,230,0,69,123,56,240,215,104,157,110,183,212,255,39,21,253,172,246,54,156,53,141,15,181,201,182,42,113,210,240,255,98,212,76,231,174,64,105,227,139,62,241,139,201,112,129,174,254,83,139,208,254,229,154,214,238,7,173,221,61,111,58,50,93,221,62,57,158,77,70,52,154,66,187,17,51,33,226,58,9,120,118,96,191,99,26,190,88,219,242,123,230,198,146,191,161,233,181,50,161,166,117,250,188,218,98,81,10,242,98,153,197,212,223,175,77,43,238,248,132,100,171,58,244,241,30,238,166,176,79,150,68,161,57,126,103,236,254,168,120,62,218,15,82,236,31,194,239,59,45,231,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e92979a3-208b-459e-b5ac-12cfe09c40e1"));
		}

		#endregion

	}

	#endregion

}

