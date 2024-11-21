namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LowerExpressionConverterSchema

	/// <exclude/>
	public class LowerExpressionConverterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LowerExpressionConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LowerExpressionConverterSchema(LowerExpressionConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b69b03e9-3983-48ee-b50b-7df2ea273c76");
			Name = "LowerExpressionConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("75f7d434-56de-4d62-8a8c-9fe090e3ebb1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,82,77,79,194,64,16,61,151,132,255,48,169,23,154,152,246,142,216,4,9,7,18,81,18,188,25,15,75,59,212,154,118,183,217,15,148,24,254,187,179,187,93,4,193,67,219,236,155,247,222,206,155,41,103,45,170,142,21,8,15,171,229,90,108,117,58,19,124,91,87,70,50,93,11,62,28,124,15,7,145,81,53,175,96,189,87,26,219,187,225,128,144,27,137,21,149,97,214,48,165,198,240,40,62,81,206,191,58,137,74,17,76,22,59,148,26,165,229,18,59,203,50,152,40,211,182,76,238,243,254,236,36,80,48,133,160,180,180,254,120,212,67,17,12,160,176,23,164,193,35,59,49,121,189,114,223,84,147,213,198,104,28,197,206,63,78,222,136,217,153,77,83,23,222,234,223,86,97,12,139,107,48,233,237,8,34,251,132,212,75,212,239,162,164,220,43,231,28,202,127,99,58,160,119,82,33,229,142,53,6,109,160,203,68,30,233,152,100,45,112,218,203,125,236,200,113,190,62,149,78,50,199,184,46,96,178,50,45,114,173,226,28,166,101,89,219,29,178,6,142,240,165,90,162,54,146,171,60,36,46,207,26,5,45,160,57,110,138,212,129,110,245,253,92,123,254,220,10,24,141,94,108,62,176,208,94,127,27,170,199,14,224,30,226,56,1,55,211,168,47,210,135,224,145,63,37,78,72,191,25,213,235,109,64,211,133,122,50,77,243,44,231,109,167,247,22,76,130,73,228,123,178,46,94,117,112,239,95,52,125,17,110,235,11,190,99,178,102,92,143,18,71,36,158,219,42,242,210,47,214,157,61,122,14,30,126,0,239,135,230,236,39,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b69b03e9-3983-48ee-b50b-7df2ea273c76"));
		}

		#endregion

	}

	#endregion

}

