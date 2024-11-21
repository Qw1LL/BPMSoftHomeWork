namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ExportToExcelExceptionSchema

	/// <exclude/>
	public class ExportToExcelExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExportToExcelExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExportToExcelExceptionSchema(ExportToExcelExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("091dd986-6c16-40af-a793-56676e4cbe11");
			Name = "ExportToExcelException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,143,193,10,131,48,12,134,207,19,124,135,224,201,129,148,157,55,118,217,112,176,131,48,112,47,80,93,38,130,182,165,169,224,16,223,125,169,186,201,96,135,134,52,253,255,47,127,149,108,145,140,44,17,78,183,44,215,79,39,206,90,61,235,170,179,210,213,90,137,180,55,218,186,187,78,251,18,155,48,24,194,96,211,81,173,42,200,95,228,176,61,132,1,79,76,87,52,117,9,101,35,137,224,199,225,139,241,32,216,243,195,210,179,195,115,190,54,173,200,1,57,235,177,25,18,201,10,47,218,182,210,193,17,162,149,240,232,38,5,78,124,112,154,59,222,32,224,170,20,218,233,50,235,134,221,24,205,185,62,27,254,71,138,87,52,246,91,14,88,72,194,120,206,33,230,0,241,79,156,132,117,98,153,108,19,207,223,120,227,244,151,145,11,159,48,24,223,210,188,202,103,82,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("091dd986-6c16-40af-a793-56676e4cbe11"));
		}

		#endregion

	}

	#endregion

}

