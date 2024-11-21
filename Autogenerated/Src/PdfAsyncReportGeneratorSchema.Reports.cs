namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PdfAsyncReportGeneratorSchema

	/// <exclude/>
	public class PdfAsyncReportGeneratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PdfAsyncReportGeneratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PdfAsyncReportGeneratorSchema(PdfAsyncReportGeneratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e562fee6-cd50-43d6-8ac4-36911be07fee");
			Name = "PdfAsyncReportGenerator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,84,77,107,219,64,16,61,43,144,255,48,40,23,9,130,124,79,98,67,109,215,33,135,20,83,183,228,80,74,217,74,35,123,65,222,21,179,35,55,166,244,191,119,86,235,164,145,145,220,166,237,197,120,231,227,189,121,243,33,163,182,232,106,149,35,76,151,247,43,91,114,54,179,166,212,235,134,20,107,107,206,207,190,159,159,69,141,211,102,13,11,93,161,56,119,72,140,228,31,111,31,25,141,147,40,24,119,157,217,172,210,104,56,243,198,235,231,252,95,4,52,96,205,22,42,103,75,26,93,159,255,69,89,217,123,172,45,241,10,105,167,115,15,38,225,23,132,107,95,203,172,82,206,93,193,178,40,223,184,189,201,67,228,45,26,148,84,75,109,232,104,52,130,27,215,108,183,138,246,147,195,91,226,8,157,84,237,64,1,181,73,176,126,202,2,109,128,55,8,203,249,2,74,75,91,197,217,19,204,232,5,206,167,57,150,170,169,120,170,77,33,181,39,188,175,209,150,201,93,95,33,233,37,188,147,222,75,235,98,65,141,211,207,146,95,55,95,43,157,67,238,21,12,9,128,43,152,42,135,253,218,34,153,150,252,62,247,98,161,177,42,124,51,72,239,20,99,112,214,225,33,34,85,97,77,181,135,187,99,138,47,223,44,21,71,198,208,228,232,2,77,17,192,187,76,50,30,199,212,248,241,121,190,86,200,129,46,136,26,144,147,164,224,55,44,138,250,56,165,57,237,52,195,90,236,179,91,228,155,227,98,39,73,252,32,153,113,234,87,38,250,113,186,202,37,217,90,54,84,22,204,247,196,50,230,140,69,8,105,135,169,205,6,73,115,97,101,8,132,229,56,30,106,117,182,178,13,229,216,185,130,120,52,9,237,61,224,130,149,107,32,93,224,137,203,201,186,119,212,131,10,227,201,31,231,103,115,155,63,94,255,149,158,15,138,214,200,255,91,79,15,234,171,244,200,210,252,102,239,238,145,55,182,248,231,113,46,229,226,21,97,48,39,31,29,146,212,103,4,79,56,46,225,40,186,243,41,74,135,219,20,210,230,138,149,84,55,140,15,205,43,232,32,239,144,31,142,135,144,27,50,189,119,43,71,211,254,195,228,152,166,139,116,226,124,130,181,107,20,219,79,107,201,117,193,59,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e562fee6-cd50-43d6-8ac4-36911be07fee"));
		}

		#endregion

	}

	#endregion

}

