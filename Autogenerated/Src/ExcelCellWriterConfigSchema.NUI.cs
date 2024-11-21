namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ExcelCellWriterConfigSchema

	/// <exclude/>
	public class ExcelCellWriterConfigSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExcelCellWriterConfigSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExcelCellWriterConfigSchema(ExcelCellWriterConfigSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("346c17cb-c7b3-4b13-89c8-26d13a32c8da");
			Name = "ExcelCellWriterConfig";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,61,107,3,49,12,134,231,4,242,31,4,221,239,150,210,161,41,29,122,77,161,67,63,104,250,181,250,92,229,112,177,165,195,150,73,66,200,127,175,237,187,148,64,41,25,100,243,162,71,122,37,145,114,24,122,165,17,110,158,31,150,188,146,170,97,90,153,46,122,37,134,169,90,108,122,246,242,202,139,141,70,59,155,238,102,211,73,12,134,58,88,110,131,160,155,255,234,91,214,209,33,201,29,123,167,164,122,234,145,62,157,77,249,68,156,121,236,82,51,104,172,10,225,18,74,175,6,173,253,240,70,208,15,134,5,172,235,26,174,66,116,78,249,237,245,168,11,13,41,44,172,11,15,186,20,84,7,190,62,42,232,99,107,141,6,157,141,254,243,153,228,37,14,228,56,231,64,192,248,237,160,67,153,67,200,207,254,8,126,187,39,185,56,135,23,94,63,70,215,158,6,27,182,209,209,9,150,219,111,212,2,239,202,70,252,3,165,200,247,67,250,26,78,152,229,254,7,147,10,85,161,180,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("346c17cb-c7b3-4b13-89c8-26d13a32c8da"));
		}

		#endregion

	}

	#endregion

}

