namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MLBatchRegressorSchema

	/// <exclude/>
	public class MLBatchRegressorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MLBatchRegressorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MLBatchRegressorSchema(MLBatchRegressorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b141c318-5fc2-4336-be2b-b9cb83f27062");
			Name = "MLBatchRegressor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("97d940bd-1454-46d7-84c7-92245c2594a8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,146,193,107,194,48,20,198,207,10,254,15,143,238,82,97,180,247,77,61,232,24,8,42,178,185,211,216,33,141,175,53,208,38,229,37,101,184,177,255,125,47,105,167,179,110,151,64,190,188,247,229,123,191,68,139,10,109,45,36,194,124,187,126,54,185,75,22,70,231,170,104,72,56,101,116,178,94,141,134,159,163,225,160,177,74,23,191,106,8,239,255,84,147,71,33,157,33,133,150,207,185,226,134,176,96,31,88,148,194,218,59,88,175,230,194,201,195,19,22,132,214,26,10,53,105,154,194,196,54,85,37,232,56,235,246,93,133,111,85,85,93,98,133,218,161,11,153,32,55,196,70,144,121,39,168,9,247,74,134,172,63,86,105,207,107,98,17,69,105,13,72,194,124,26,253,55,104,210,133,219,52,21,146,146,219,214,216,80,4,169,119,122,125,192,92,52,165,155,43,189,231,169,99,119,172,209,228,241,178,235,58,149,143,111,97,195,80,97,202,25,249,10,235,108,114,30,102,75,38,227,97,118,220,59,126,99,211,186,201,74,37,65,122,58,87,112,224,196,171,31,137,59,249,81,120,61,243,245,55,81,227,15,25,243,54,216,182,21,125,186,65,88,106,229,148,40,213,7,90,16,160,241,29,20,247,11,205,255,192,228,224,14,24,160,117,192,250,185,162,116,214,38,246,196,175,145,183,74,45,72,84,160,153,196,52,106,44,18,7,212,24,222,41,154,237,216,223,107,32,79,98,50,73,67,71,48,232,168,244,239,141,95,46,124,130,197,121,59,102,92,153,176,24,247,101,255,125,7,95,29,46,212,251,150,88,216,183,234,165,200,218,55,102,126,225,137,21,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b141c318-5fc2-4336-be2b-b9cb83f27062"));
		}

		#endregion

	}

	#endregion

}

