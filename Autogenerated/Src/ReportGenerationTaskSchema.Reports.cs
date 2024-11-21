namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ReportGenerationTaskSchema

	/// <exclude/>
	public class ReportGenerationTaskSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportGenerationTaskSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportGenerationTaskSchema(ReportGenerationTaskSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("68544e27-681d-4cfb-9b4f-a820834261f0");
			Name = "ReportGenerationTask";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,80,177,78,195,48,20,156,19,169,255,240,164,46,32,161,102,39,192,64,135,168,3,40,106,216,16,131,27,191,68,22,137,29,61,59,67,169,248,119,158,19,183,77,171,66,197,98,91,231,123,119,239,78,139,22,109,39,74,132,231,252,165,48,149,91,44,141,174,84,221,147,112,202,232,89,188,155,197,81,111,149,174,161,216,90,135,109,58,139,25,153,19,214,252,13,203,70,88,123,15,107,236,12,185,12,53,142,99,111,194,126,14,188,247,2,73,137,70,125,137,77,131,31,12,116,253,166,81,37,148,126,238,151,177,136,45,249,60,122,24,109,29,245,165,51,196,86,249,32,48,50,130,216,37,153,155,91,240,155,71,223,215,153,89,175,36,56,126,173,228,29,176,147,207,74,3,241,149,203,9,58,145,167,174,36,60,6,102,58,128,235,3,141,63,142,51,233,196,121,142,90,142,65,78,83,229,100,58,36,167,240,44,83,146,36,240,96,251,182,21,180,125,218,3,25,58,11,134,192,250,91,64,61,6,192,96,9,29,153,18,185,79,191,26,40,137,218,169,74,33,45,14,122,201,84,48,116,49,196,14,169,118,44,233,82,47,159,66,216,251,63,123,200,253,34,154,195,255,237,26,250,157,20,119,193,251,172,179,17,61,5,25,251,1,119,29,52,232,187,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("68544e27-681d-4cfb-9b4f-a820834261f0"));
		}

		#endregion

	}

	#endregion

}

