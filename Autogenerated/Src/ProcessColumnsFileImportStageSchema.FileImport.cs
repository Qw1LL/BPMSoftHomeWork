namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ProcessColumnsFileImportStageSchema

	/// <exclude/>
	public class ProcessColumnsFileImportStageSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ProcessColumnsFileImportStageSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ProcessColumnsFileImportStageSchema(ProcessColumnsFileImportStageSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7af17616-4f9f-4644-894a-b58b57826cf5");
			Name = "ProcessColumnsFileImportStage";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,193,78,220,48,16,61,7,137,127,24,193,37,171,210,228,190,116,169,216,237,162,70,130,106,37,212,19,226,96,226,73,176,148,216,209,216,174,64,136,127,239,36,78,96,119,9,65,112,73,236,153,55,243,242,222,76,180,168,209,54,34,71,88,110,174,174,77,225,146,149,209,133,42,61,9,167,140,78,46,84,133,89,221,24,114,135,7,79,135,7,145,183,74,151,91,88,194,211,209,104,114,33,114,103,72,161,229,60,35,142,9,75,238,7,176,170,132,181,115,216,144,201,209,218,149,169,124,173,237,43,203,181,19,37,118,21,105,154,194,15,165,239,145,148,147,38,135,156,176,88,28,45,133,197,61,244,81,122,54,192,173,175,107,65,143,195,125,253,128,185,119,8,77,32,131,60,176,13,232,116,11,126,243,11,11,225,43,183,84,90,178,150,216,61,54,104,138,56,27,225,155,157,192,31,118,13,22,160,249,197,160,73,45,179,217,45,183,111,252,93,165,88,67,43,126,90,59,204,97,132,147,91,176,251,252,124,49,146,199,100,29,249,214,228,214,206,174,127,64,244,92,147,44,241,95,139,196,45,52,230,237,152,193,239,92,79,218,54,81,148,245,181,231,101,201,164,130,153,206,165,104,28,210,96,100,79,97,104,22,10,230,112,199,159,30,239,53,123,139,134,39,120,238,213,160,150,65,208,174,58,198,54,72,142,215,103,87,219,39,151,98,240,194,252,67,34,37,17,246,80,118,173,125,13,221,49,147,176,56,27,205,39,147,78,158,78,11,185,66,119,111,100,88,120,199,134,160,252,162,144,161,124,90,203,79,200,52,15,72,139,170,255,232,56,32,54,130,120,87,57,99,161,121,57,242,28,186,185,173,246,230,147,244,167,53,145,33,248,182,128,208,227,210,148,37,82,242,91,104,89,97,151,107,127,253,247,203,227,45,166,105,100,32,250,254,17,17,161,243,164,39,103,180,214,78,181,91,243,118,72,81,52,190,114,33,186,27,228,216,127,75,76,63,76,24,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7af17616-4f9f-4644-894a-b58b57826cf5"));
		}

		#endregion

	}

	#endregion

}

