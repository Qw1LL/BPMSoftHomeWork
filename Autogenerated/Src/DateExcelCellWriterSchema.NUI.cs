namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DateExcelCellWriterSchema

	/// <exclude/>
	public class DateExcelCellWriterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateExcelCellWriterSchema(DateExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("73d3a6ae-b385-4134-8118-e70bf2e8f09f");
			Name = "DateExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,146,223,107,219,48,16,199,159,29,200,255,112,180,123,176,97,200,239,109,87,216,178,12,6,235,18,136,233,246,170,216,231,68,67,210,153,179,156,198,148,252,239,147,228,31,43,109,217,131,109,221,249,171,251,126,238,36,43,13,182,141,44,17,190,108,31,118,84,59,177,34,91,171,67,199,210,41,178,98,125,110,136,93,65,235,115,137,122,185,120,94,46,146,174,85,246,0,187,190,117,104,110,151,11,159,185,102,60,120,49,172,180,108,219,27,248,42,29,70,253,10,181,254,197,202,33,71,89,158,231,112,215,118,198,72,238,239,199,56,104,1,131,24,252,163,225,41,202,197,164,206,95,200,155,110,175,85,9,101,48,121,207,3,188,51,150,202,72,253,198,60,9,220,51,230,150,169,65,118,10,61,235,54,22,141,120,193,241,78,217,35,250,77,21,149,144,7,211,201,149,78,200,172,42,132,185,246,55,98,35,221,155,248,211,253,235,148,8,172,195,160,146,107,180,213,64,49,198,35,210,3,186,35,85,129,135,201,97,233,176,250,31,210,164,249,71,213,58,14,135,50,24,62,74,221,97,74,251,63,94,4,167,16,100,16,7,144,156,36,3,99,219,105,207,57,238,17,107,211,184,254,54,254,86,53,164,1,182,80,6,69,193,253,86,114,139,105,172,32,10,218,69,125,154,125,4,234,66,93,134,202,107,163,89,54,25,36,142,251,105,153,204,78,179,78,20,180,249,28,28,210,204,47,199,130,155,6,237,111,163,127,118,102,143,60,116,240,221,214,148,13,76,201,5,74,233,202,35,164,27,223,108,173,233,41,140,183,9,151,211,223,155,217,55,249,65,190,21,102,226,244,195,213,59,151,67,192,138,58,93,129,37,7,245,112,82,177,175,27,120,158,233,46,34,30,93,172,237,243,120,190,92,205,16,241,51,188,25,93,199,118,156,99,252,239,243,175,15,119,204,189,76,93,254,2,162,3,9,150,108,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("73d3a6ae-b385-4134-8118-e70bf2e8f09f"));
		}

		#endregion

	}

	#endregion

}

