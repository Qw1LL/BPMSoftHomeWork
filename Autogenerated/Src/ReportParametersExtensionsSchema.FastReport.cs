namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ReportParametersExtensionsSchema

	/// <exclude/>
	public class ReportParametersExtensionsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportParametersExtensionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportParametersExtensionsSchema(ReportParametersExtensionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb807f21-ad89-4edf-8b4c-a6a175aae41f");
			Name = "ReportParametersExtensions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,84,219,110,218,64,16,125,118,164,252,195,52,145,34,144,144,63,160,109,34,53,9,68,72,37,165,208,246,125,177,199,176,213,178,75,119,103,163,90,85,254,189,227,93,95,48,160,146,242,96,152,251,153,115,198,104,177,69,183,19,25,194,253,124,182,52,5,165,15,70,23,114,237,173,32,105,116,186,192,157,177,36,245,58,157,8,71,209,186,188,248,115,121,145,120,199,94,88,150,142,112,203,69,74,97,86,85,184,244,9,53,90,153,125,104,115,186,206,22,79,123,211,177,38,73,18,221,113,248,217,203,116,137,246,69,102,56,51,57,170,244,81,144,96,140,100,69,70,111,72,31,255,38,212,174,2,198,201,156,126,109,113,205,22,60,124,22,206,189,135,184,209,92,88,230,129,208,186,46,61,100,239,252,74,201,12,28,49,27,25,100,138,107,254,89,146,48,51,252,108,167,204,144,54,38,231,57,243,208,40,6,251,77,167,97,247,114,153,109,112,43,190,122,180,229,68,42,238,59,101,94,129,123,87,123,142,221,175,232,156,88,179,61,156,63,160,141,116,48,93,160,200,191,104,85,62,202,160,131,176,229,71,71,150,185,25,129,89,253,100,113,238,192,25,111,51,28,85,24,146,228,187,67,203,60,234,40,27,248,158,57,130,88,11,184,7,238,153,7,14,161,210,62,73,100,1,131,216,46,253,102,203,39,164,31,66,121,28,92,181,72,221,21,207,245,4,47,194,194,174,193,58,132,155,155,206,130,51,176,235,70,119,32,148,170,127,55,227,195,252,206,221,195,112,8,185,195,177,31,105,26,182,29,19,139,228,173,62,149,148,222,123,169,242,118,181,19,19,250,236,13,171,187,228,207,107,248,138,207,186,187,246,74,133,232,235,169,91,88,25,163,128,119,249,148,231,231,244,62,186,154,255,82,247,45,215,210,234,228,26,142,42,14,139,128,11,110,247,194,213,59,118,254,74,143,14,44,94,207,194,24,138,91,164,225,190,34,117,149,188,245,164,119,183,129,180,86,167,186,174,145,134,169,170,51,27,214,107,166,201,250,240,111,115,32,64,33,148,139,254,90,129,107,212,121,124,91,131,29,189,125,39,251,254,2,213,242,48,156,40,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb807f21-ad89-4edf-8b4c-a6a175aae41f"));
		}

		#endregion

	}

	#endregion

}

