namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ExportFiltersResponseSchema

	/// <exclude/>
	public class ExportFiltersResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExportFiltersResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExportFiltersResponseSchema(ExportFiltersResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("83451a60-7d62-4ce4-941d-7458d5f504cd");
			Name = "ExportFiltersResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,144,177,78,195,64,12,134,231,86,234,59,88,237,2,75,30,160,21,11,161,44,40,40,74,70,196,112,13,110,100,145,187,139,124,14,52,84,125,119,156,11,20,5,202,98,201,246,239,207,191,237,140,197,208,154,10,225,54,207,74,191,151,36,245,110,79,117,199,70,200,187,164,192,214,179,148,200,111,84,225,98,126,92,204,103,93,32,87,67,217,7,65,155,20,157,19,178,152,168,130,76,67,31,113,106,115,86,93,132,106,91,5,43,198,90,19,72,27,19,194,26,182,135,97,209,61,53,130,28,10,245,228,93,192,40,124,186,51,98,20,32,108,42,121,214,66,219,237,26,170,160,26,6,47,207,193,26,38,27,191,252,255,96,103,122,136,198,179,137,156,125,139,44,132,234,36,143,248,177,31,119,103,104,119,200,87,143,250,42,184,129,229,43,246,203,235,193,199,183,145,32,60,220,250,128,61,28,107,148,13,4,13,167,255,1,214,28,182,250,53,233,11,255,158,122,125,224,20,71,78,32,251,45,249,75,94,161,123,25,221,199,124,172,78,139,167,79,16,30,204,64,222,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("83451a60-7d62-4ce4-941d-7458d5f504cd"));
		}

		#endregion

	}

	#endregion

}

