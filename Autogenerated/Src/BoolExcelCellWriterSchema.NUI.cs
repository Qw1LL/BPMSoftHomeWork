namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BoolExcelCellWriterSchema

	/// <exclude/>
	public class BoolExcelCellWriterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BoolExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BoolExcelCellWriterSchema(BoolExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bb306662-1573-42f1-9db8-66a8d68b57c0");
			Name = "BoolExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,77,79,195,48,12,134,207,157,180,255,96,193,101,147,80,123,7,6,18,19,156,24,154,196,215,57,107,205,8,74,227,202,73,199,151,248,239,56,201,10,219,24,131,67,171,58,126,109,191,125,28,171,106,116,141,42,17,206,166,147,107,122,240,249,152,236,131,158,183,172,188,38,155,159,191,52,196,254,134,206,95,74,52,253,222,123,191,151,181,78,219,249,138,188,174,201,30,245,123,146,217,103,156,75,17,140,141,114,238,16,174,61,139,50,86,142,209,152,123,214,30,57,10,139,162,128,99,215,214,181,226,215,147,101,156,212,128,65,14,242,24,120,142,5,121,167,47,86,10,154,118,102,116,9,101,24,4,103,68,102,99,10,252,58,61,147,95,144,247,183,87,178,206,43,235,197,239,148,245,66,121,76,249,38,5,80,134,60,184,100,238,170,213,19,101,213,28,249,74,184,193,8,246,58,12,146,217,59,218,81,121,195,45,38,71,119,202,180,216,149,39,122,183,94,27,151,111,72,118,182,187,80,198,253,213,111,83,211,53,220,71,91,165,159,95,39,49,101,106,144,189,198,128,34,242,77,121,129,127,172,237,35,10,192,138,74,40,2,255,110,1,180,64,102,93,33,124,113,190,32,174,149,255,17,143,78,54,143,242,176,182,63,44,77,208,63,82,21,87,67,30,75,143,213,46,75,157,230,219,85,71,43,14,140,16,6,52,123,18,17,44,66,48,132,112,159,179,108,161,24,102,226,38,42,4,227,32,4,195,164,17,135,162,96,244,45,219,85,209,8,188,236,43,38,179,83,176,248,12,151,84,42,163,223,212,204,44,169,15,214,175,203,193,182,75,48,204,227,103,234,115,248,207,62,219,182,191,108,20,237,126,108,165,154,78,215,15,63,62,1,19,225,178,222,0,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bb306662-1573-42f1-9db8-66a8d68b57c0"));
		}

		#endregion

	}

	#endregion

}

