namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: NumberDigitExpressionConverterSchema

	/// <exclude/>
	public class NumberDigitExpressionConverterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NumberDigitExpressionConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NumberDigitExpressionConverterSchema(NumberDigitExpressionConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f1dacd9b-b93b-430e-89f3-3ee26a40f8d8");
			Name = "NumberDigitExpressionConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("75f7d434-56de-4d62-8a8c-9fe090e3ebb1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,77,111,219,48,12,61,187,64,255,3,231,92,108,32,80,118,238,218,12,157,151,5,57,180,11,144,220,134,29,20,155,113,52,216,146,161,143,110,217,208,255,62,74,178,189,230,3,216,33,118,244,200,247,72,62,209,146,183,104,58,94,34,124,90,63,109,212,222,178,66,201,189,168,157,230,86,40,121,123,243,231,246,38,113,70,200,26,54,71,99,177,253,112,118,102,203,70,237,120,35,126,135,252,139,232,246,160,145,87,4,80,132,98,19,141,53,165,65,209,112,99,238,224,217,181,59,212,159,69,45,236,226,87,167,209,24,10,82,3,47,168,45,234,192,152,205,102,112,111,92,219,114,125,156,247,231,72,131,202,243,0,71,34,148,3,19,74,175,207,6,250,236,13,255,219,149,66,143,214,106,177,115,22,179,244,77,71,105,254,157,242,59,183,107,68,25,5,255,211,47,220,193,234,26,76,42,228,34,61,199,241,159,208,30,84,69,6,172,131,122,12,158,79,26,128,13,118,156,174,2,13,16,195,25,46,43,3,63,133,61,128,140,30,212,90,185,14,76,204,82,218,143,124,57,115,68,124,74,11,146,46,252,33,125,225,141,195,116,222,27,25,78,236,126,22,50,174,19,184,174,93,139,210,154,116,14,143,85,37,252,101,243,6,70,248,146,173,209,58,45,205,124,240,161,26,186,244,255,200,111,218,145,161,238,144,234,185,189,223,125,198,194,167,16,37,83,187,31,88,218,200,152,14,209,177,58,60,64,10,105,14,126,89,147,164,194,82,180,212,28,189,253,62,38,137,216,67,246,174,71,217,86,31,215,92,27,204,178,168,146,247,154,202,89,207,200,7,149,36,118,213,215,98,139,182,179,199,40,247,26,158,209,187,47,74,183,220,174,228,94,1,125,54,212,199,57,204,150,72,111,99,185,44,49,139,95,3,43,156,214,212,246,233,169,112,13,213,195,156,21,141,146,152,229,192,135,125,251,39,22,235,83,33,22,35,75,127,251,253,138,40,77,213,251,102,87,230,217,53,205,87,29,154,206,70,155,114,248,232,125,162,61,29,161,168,216,143,74,227,179,173,218,4,141,44,157,76,38,211,211,223,123,118,134,165,83,63,117,78,158,138,54,203,131,22,153,19,54,29,101,21,151,61,156,35,122,10,190,254,5,7,127,120,212,124,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f1dacd9b-b93b-430e-89f3-3ee26a40f8d8"));
		}

		#endregion

	}

	#endregion

}

