namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LookupExcelCellWriterSchema

	/// <exclude/>
	public class LookupExcelCellWriterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LookupExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LookupExcelCellWriterSchema(LookupExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("434dfe6c-8e8d-4e15-b08d-b3f5add4566b");
			Name = "LookupExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,79,139,194,48,16,197,207,22,250,29,6,246,222,220,213,245,96,113,79,43,20,20,60,103,211,177,6,211,76,152,166,254,65,252,238,155,38,42,238,234,33,135,55,243,222,188,31,177,178,197,206,73,133,48,175,150,43,218,250,162,36,187,213,77,207,210,107,178,197,226,228,136,253,154,22,39,133,38,207,46,121,150,103,163,15,198,38,44,161,52,178,235,198,240,77,180,239,93,116,148,104,204,134,181,71,142,70,33,4,76,187,190,109,37,159,103,55,157,220,128,131,29,194,51,112,140,129,226,238,23,79,1,215,255,24,173,64,13,69,239,123,96,12,43,207,218,54,47,253,163,4,251,160,173,152,28,178,215,24,144,171,120,55,237,67,233,84,219,29,134,88,77,10,196,208,123,47,166,3,50,235,26,225,113,253,139,184,149,254,69,127,206,254,143,138,132,59,185,65,160,173,19,71,212,215,244,143,127,134,215,95,135,193,222,178,140,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("434dfe6c-8e8d-4e15-b08d-b3f5add4566b"));
		}

		#endregion

	}

	#endregion

}

