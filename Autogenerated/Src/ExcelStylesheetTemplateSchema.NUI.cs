namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ExcelStylesheetTemplateSchema

	/// <exclude/>
	public class ExcelStylesheetTemplateSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExcelStylesheetTemplateSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExcelStylesheetTemplateSchema(ExcelStylesheetTemplateSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("962cb08b-b35b-4310-92bb-ae488ec1da3f");
			Name = "ExcelStylesheetTemplate";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,144,79,75,3,49,16,197,207,187,176,223,97,192,123,246,174,226,193,181,226,69,20,182,136,215,49,157,110,3,147,63,36,19,104,41,126,119,179,105,171,123,81,60,36,228,133,247,126,195,60,135,150,82,64,77,112,255,250,60,250,173,168,193,187,173,153,114,68,49,222,169,213,62,248,40,107,191,218,107,226,174,61,118,109,215,54,57,25,55,193,131,215,217,146,147,71,31,45,138,122,9,228,222,45,171,49,68,194,77,218,17,201,77,117,95,69,154,10,10,6,198,148,174,161,146,70,57,48,85,207,154,108,96,20,170,214,190,239,225,54,101,107,49,30,238,206,186,198,64,118,40,160,189,19,52,46,1,205,12,72,223,16,144,51,69,93,32,253,130,18,242,7,27,13,186,130,126,29,223,148,221,154,139,247,199,176,124,30,97,42,75,65,154,175,207,133,123,32,230,83,11,240,134,156,105,161,255,17,121,42,117,81,252,35,83,206,92,35,185,205,169,201,89,214,191,47,50,179,245,60,189,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("962cb08b-b35b-4310-92bb-ae488ec1da3f"));
		}

		#endregion

	}

	#endregion

}

