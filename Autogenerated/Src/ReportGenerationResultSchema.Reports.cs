namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ReportGenerationResultSchema

	/// <exclude/>
	public class ReportGenerationResultSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportGenerationResultSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportGenerationResultSchema(ReportGenerationResultSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0ee0c217-8753-49b8-84d4-5d609fc7ae8a");
			Name = "ReportGenerationResult";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,145,49,107,195,48,16,133,103,7,242,31,14,178,56,80,242,3,18,186,52,67,233,144,214,196,99,200,32,187,23,71,96,75,230,116,38,56,33,255,189,146,165,80,203,164,75,23,131,158,222,251,238,233,172,68,131,166,21,37,194,91,182,203,245,137,87,91,173,78,178,234,72,176,212,106,62,187,205,103,73,103,164,170,32,239,13,99,179,153,156,87,31,95,86,178,226,130,176,178,9,216,214,194,152,53,236,177,213,196,239,168,208,147,246,104,186,154,7,231,33,71,146,162,150,87,81,212,120,180,66,219,21,181,44,161,116,201,63,131,137,109,98,191,191,115,180,50,76,93,201,154,236,184,108,64,120,71,192,61,7,165,54,228,218,211,112,251,105,159,255,2,69,207,120,56,6,201,114,25,21,47,29,41,89,3,159,165,73,199,102,133,23,216,97,163,169,207,153,80,52,105,28,91,130,219,88,114,255,103,149,124,96,78,170,120,100,226,41,206,7,175,163,144,251,35,143,203,16,127,92,7,192,224,8,141,22,168,190,253,6,227,117,102,164,91,36,150,248,124,153,161,234,168,194,13,42,228,13,196,15,13,243,163,50,177,113,50,223,171,177,120,255,1,61,166,246,101,149,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0ee0c217-8753-49b8-84d4-5d609fc7ae8a"));
		}

		#endregion

	}

	#endregion

}

