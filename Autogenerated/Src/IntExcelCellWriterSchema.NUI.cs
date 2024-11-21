namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IntExcelCellWriterSchema

	/// <exclude/>
	public class IntExcelCellWriterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IntExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IntExcelCellWriterSchema(IntExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("61d5eba2-33cc-431f-aed3-08714edf99a5");
			Name = "IntExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,144,65,111,194,48,12,133,207,69,226,63,88,218,5,46,237,157,1,7,58,38,237,128,84,9,180,157,67,106,74,166,52,174,220,180,99,154,248,239,115,83,96,131,161,29,34,197,246,123,126,95,226,84,137,117,165,52,194,34,91,173,105,231,227,148,220,206,20,13,43,111,200,197,203,67,69,236,55,180,60,104,180,195,193,215,112,48,28,68,15,140,133,12,33,181,170,174,39,240,132,218,148,202,6,73,138,214,62,19,151,202,123,228,32,78,146,4,166,117,83,150,138,63,231,167,250,197,121,44,144,1,59,11,200,177,240,193,70,28,241,217,144,252,114,84,205,214,26,13,186,75,235,172,151,160,183,224,129,9,44,84,141,55,93,241,245,176,23,218,140,169,66,246,6,5,57,11,43,251,185,228,77,141,219,163,216,114,210,144,116,145,231,76,106,145,217,228,8,55,143,251,83,207,230,183,173,88,72,31,79,4,232,242,30,226,154,104,133,126,79,121,135,195,228,81,123,204,255,35,58,107,126,160,106,207,198,21,208,231,189,42,219,224,136,182,239,34,130,182,43,198,32,63,16,69,81,171,24,140,235,5,48,131,145,220,199,65,32,120,50,102,244,13,187,139,34,222,208,58,236,29,141,195,252,120,247,13,125,247,186,121,252,6,43,234,147,23,77,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("61d5eba2-33cc-431f-aed3-08714edf99a5"));
		}

		#endregion

	}

	#endregion

}

