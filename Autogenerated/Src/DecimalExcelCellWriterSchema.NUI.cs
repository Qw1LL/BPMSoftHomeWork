namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DecimalExcelCellWriterSchema

	/// <exclude/>
	public class DecimalExcelCellWriterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DecimalExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DecimalExcelCellWriterSchema(DecimalExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("11e09c36-5811-41ad-acea-44711f05f95b");
			Name = "DecimalExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,147,77,79,195,48,12,134,207,69,226,63,88,112,25,151,246,206,128,3,227,67,28,248,144,134,128,107,214,186,35,40,31,149,147,142,1,218,127,199,73,186,105,180,3,14,149,106,215,175,253,248,77,106,132,70,215,136,18,225,252,225,118,106,107,159,79,172,169,229,188,37,225,165,53,249,229,178,177,228,31,237,229,178,68,181,191,247,181,191,151,181,78,154,57,76,63,156,71,61,238,197,249,181,178,51,161,228,103,84,243,87,254,126,72,56,231,0,38,74,56,119,12,23,88,74,45,84,108,56,65,165,174,44,105,225,61,82,44,46,138,2,78,92,171,181,160,143,179,46,238,20,128,65,2,252,40,120,39,201,138,124,45,40,182,20,77,59,83,178,132,50,76,27,12,123,142,58,56,134,115,225,176,151,101,109,88,111,195,251,64,182,65,242,18,25,154,223,61,150,30,171,8,57,160,12,137,236,190,65,3,75,173,192,53,60,181,102,6,211,234,25,79,171,227,134,32,77,109,3,241,16,57,107,214,237,225,46,74,146,39,55,44,128,208,245,69,171,65,254,11,230,232,199,176,74,64,135,104,170,132,221,197,187,118,136,198,108,22,56,145,230,21,121,241,202,150,80,36,138,228,156,93,32,145,172,16,122,71,52,136,79,207,250,169,188,243,123,252,55,21,95,49,231,169,45,189,165,30,87,135,176,251,216,70,71,16,15,40,251,205,147,83,48,248,62,180,48,137,178,148,239,90,79,177,17,124,197,45,177,232,32,63,136,21,171,112,155,179,127,28,189,69,255,106,171,237,43,1,127,89,186,41,218,184,202,155,135,255,37,241,61,9,213,226,200,206,222,184,8,22,33,88,239,184,16,4,85,98,141,69,204,201,182,113,19,159,63,218,110,137,81,82,68,236,140,208,183,100,126,104,184,114,26,167,141,126,113,44,73,119,108,220,229,182,83,171,111,90,40,204,49,43,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("11e09c36-5811-41ad-acea-44711f05f95b"));
		}

		#endregion

	}

	#endregion

}

