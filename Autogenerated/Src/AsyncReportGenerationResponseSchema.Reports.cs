namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AsyncReportGenerationResponseSchema

	/// <exclude/>
	public class AsyncReportGenerationResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AsyncReportGenerationResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AsyncReportGenerationResponseSchema(AsyncReportGenerationResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("59415005-e6b4-4fec-b04e-4cda4c279496");
			Name = "AsyncReportGenerationResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,143,193,106,195,48,16,68,207,9,228,31,22,122,183,239,113,8,180,57,152,64,11,38,238,15,168,242,218,93,98,75,102,87,46,152,144,127,239,90,78,221,38,135,94,36,52,122,59,59,227,76,135,210,27,139,240,82,188,149,190,14,201,193,187,154,154,129,77,32,239,54,235,203,102,189,26,132,92,3,229,40,1,187,236,225,173,124,219,162,157,96,73,114,116,200,100,149,81,234,137,177,81,21,14,173,17,217,194,179,140,206,158,176,247,28,34,22,253,79,186,92,7,49,14,244,195,71,75,22,236,196,255,143,195,22,238,98,150,200,95,100,241,215,109,165,177,245,92,50,20,236,123,228,64,168,65,138,184,102,254,79,211,20,118,50,116,157,225,113,255,35,228,24,4,60,131,76,119,248,68,176,75,69,240,53,80,133,46,80,77,200,74,213,192,49,35,52,75,72,8,70,206,146,44,246,233,95,255,91,199,227,43,73,216,229,3,85,123,120,44,249,174,227,199,74,224,162,158,33,155,82,100,112,189,213,65,87,205,141,226,123,86,239,197,235,55,216,171,213,65,210,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("59415005-e6b4-4fec-b04e-4cda4c279496"));
		}

		#endregion

	}

	#endregion

}

