namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ExcelCellFormatSchema

	/// <exclude/>
	public class ExcelCellFormatSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExcelCellFormatSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExcelCellFormatSchema(ExcelCellFormatSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5521b4a2-bdcb-488d-b088-5f4a850b95ea");
			Name = "ExcelCellFormat";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,89,75,195,64,20,133,159,83,232,127,184,224,75,11,33,233,230,66,181,130,93,164,130,75,49,85,4,241,97,154,222,164,131,179,196,201,12,86,165,255,221,153,164,130,40,109,245,33,129,155,123,206,201,199,225,10,194,49,207,72,140,208,159,92,69,50,209,193,64,138,132,166,70,17,77,165,8,70,203,76,42,61,149,163,101,140,172,90,249,168,86,170,21,207,228,84,164,48,148,177,225,40,244,185,84,156,232,224,38,67,241,192,89,16,101,10,201,60,95,32,234,227,66,189,167,48,181,81,48,18,134,119,161,8,26,32,99,165,173,80,132,97,8,39,185,225,156,168,183,211,245,92,232,192,62,12,146,66,9,104,253,193,151,58,252,38,207,204,140,209,184,216,255,142,247,44,178,231,61,22,223,175,13,159,161,42,55,181,132,176,28,235,79,110,219,151,146,65,15,154,254,6,169,86,6,125,104,53,154,119,246,221,46,61,67,162,209,122,90,59,60,206,209,240,161,70,133,174,143,165,162,239,82,104,194,206,24,77,133,235,238,158,48,131,121,112,75,211,133,94,231,98,76,57,113,56,109,127,27,185,15,47,70,106,156,40,76,232,178,11,238,119,101,192,216,182,143,202,250,59,219,209,154,255,70,187,16,218,198,238,239,192,122,165,115,189,232,66,199,70,111,32,140,180,114,247,211,131,131,93,133,55,126,20,62,165,220,149,126,248,55,132,86,123,35,194,165,148,207,38,179,81,71,118,90,149,103,138,98,94,94,170,27,87,159,35,243,122,64,25,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5521b4a2-bdcb-488d-b088-5f4a850b95ea"));
		}

		#endregion

	}

	#endregion

}

