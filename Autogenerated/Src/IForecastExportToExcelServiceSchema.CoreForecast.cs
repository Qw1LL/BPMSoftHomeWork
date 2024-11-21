namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IForecastExportToExcelServiceSchema

	/// <exclude/>
	public class IForecastExportToExcelServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IForecastExportToExcelServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IForecastExportToExcelServiceSchema(IForecastExportToExcelServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7c9ba928-203d-4631-aa4f-bccc69f69d0a");
			Name = "IForecastExportToExcelService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,82,193,110,194,48,12,61,15,137,127,176,122,218,36,68,165,93,7,61,12,1,66,211,180,9,38,238,105,234,66,182,52,65,78,10,84,19,255,62,167,129,137,10,46,85,243,242,252,242,158,109,35,42,116,59,33,17,94,63,223,87,182,244,195,137,53,165,218,212,36,188,178,102,56,179,132,82,56,191,126,238,247,126,251,189,135,218,41,179,129,85,227,60,86,76,213,26,101,224,185,225,28,13,146,146,47,255,156,251,122,211,227,206,146,255,178,211,163,68,205,100,166,167,105,10,35,87,87,149,160,38,59,159,23,198,35,149,193,86,105,9,176,45,10,162,229,217,14,108,149,243,150,26,40,72,105,93,216,131,129,66,120,1,222,50,153,149,135,23,221,244,74,120,87,231,90,73,80,255,218,139,75,186,142,171,21,210,94,73,228,2,14,204,223,27,131,45,48,33,20,30,29,8,83,192,129,84,248,109,95,6,231,249,166,10,78,180,149,34,156,45,137,13,182,68,66,95,147,57,231,129,31,108,130,207,91,163,17,217,9,98,29,195,3,26,39,165,210,108,58,182,50,201,102,237,41,38,150,157,246,142,210,182,234,190,136,205,191,121,90,107,161,107,92,162,180,84,184,36,251,104,49,216,7,144,237,181,232,0,14,91,37,183,112,224,214,66,142,103,187,88,220,170,199,60,46,27,57,68,144,132,229,56,233,180,114,201,187,197,203,129,73,154,69,156,159,136,8,107,93,138,131,218,221,42,152,99,119,50,111,216,60,198,236,177,19,112,221,150,1,44,166,166,174,144,68,174,113,20,115,93,101,205,224,54,254,83,216,214,83,191,119,130,63,59,154,139,18,7,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7c9ba928-203d-4631-aa4f-bccc69f69d0a"));
		}

		#endregion

	}

	#endregion

}

