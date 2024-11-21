namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: HeaderExcelCellWriterSchema

	/// <exclude/>
	public class HeaderExcelCellWriterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public HeaderExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public HeaderExcelCellWriterSchema(HeaderExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("881c36f8-3731-4978-a3c3-2634f94cdae3");
			Name = "HeaderExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,142,77,139,194,48,16,134,207,22,250,31,6,188,55,119,191,14,91,92,246,34,20,20,60,199,116,236,6,210,76,153,166,126,32,254,119,167,169,202,170,11,201,192,204,188,239,188,143,215,53,182,141,54,8,95,197,106,77,251,144,229,228,247,182,234,88,7,75,62,91,158,26,226,176,161,229,201,160,75,147,75,154,140,228,141,25,43,217,66,238,116,219,78,224,7,117,137,28,37,57,58,183,101,27,144,211,68,132,74,41,152,181,93,93,107,62,47,238,253,160,6,236,229,32,223,193,49,26,178,135,94,253,49,52,221,206,89,3,166,15,250,63,7,38,176,14,108,125,245,145,63,18,90,169,79,218,130,169,65,14,22,5,185,136,119,135,189,132,206,172,255,69,177,149,100,64,245,185,143,96,58,32,179,45,17,158,215,191,137,107,29,62,250,249,226,125,148,13,184,211,59,4,250,114,224,136,253,53,214,215,225,245,6,58,14,75,139,141,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("881c36f8-3731-4978-a3c3-2634f94cdae3"));
		}

		#endregion

	}

	#endregion

}

