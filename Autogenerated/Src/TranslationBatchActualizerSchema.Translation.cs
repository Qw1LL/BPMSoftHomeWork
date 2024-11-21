namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TranslationBatchActualizerSchema

	/// <exclude/>
	public class TranslationBatchActualizerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TranslationBatchActualizerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TranslationBatchActualizerSchema(TranslationBatchActualizerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8fccbdb7-dc23-4a94-a151-19c141114606");
			Name = "TranslationBatchActualizer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ab054f7f-9309-4520-a5a0-bfba22ceff76");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,82,193,106,194,64,16,61,175,224,63,44,120,137,32,249,0,165,72,181,20,132,10,82,133,30,203,154,140,113,33,238,202,236,36,208,150,254,123,55,217,52,38,38,107,123,232,161,151,176,153,121,243,222,190,183,163,196,9,204,89,68,192,23,155,245,86,31,40,92,106,117,144,73,134,130,164,86,225,14,133,50,105,121,30,14,62,134,3,150,25,169,18,190,125,51,4,167,89,253,127,25,70,104,206,88,132,197,140,16,18,251,195,151,169,48,102,202,27,253,133,160,232,120,31,81,38,82,249,14,88,162,207,217,62,149,17,143,10,240,13,44,111,17,53,57,152,189,167,253,94,100,181,50,132,89,68,26,173,250,166,164,119,136,74,202,47,18,172,26,189,13,234,92,198,86,153,186,181,73,65,199,216,202,6,179,204,82,202,16,86,234,160,235,9,211,91,158,240,38,253,147,78,146,54,185,171,140,29,245,148,239,133,129,160,79,219,75,223,229,226,197,27,178,207,95,219,127,6,163,51,140,160,118,130,87,133,182,135,127,17,81,247,138,127,25,218,8,84,236,22,171,189,101,150,224,12,72,18,138,29,67,77,16,17,196,85,206,40,115,65,208,9,186,246,254,74,158,206,204,141,87,108,126,2,111,163,188,57,75,128,170,19,67,176,142,149,95,145,207,231,14,200,2,63,230,142,7,62,197,113,207,54,140,75,27,69,128,63,166,184,6,58,234,184,47,194,239,12,116,14,136,150,149,231,90,198,124,165,8,80,137,180,222,217,134,124,240,96,67,223,201,19,216,165,21,241,35,234,83,245,146,172,88,147,240,230,104,61,225,174,238,115,27,190,160,180,26,87,93,48,129,155,235,55,235,170,237,162,173,125,1,137,188,183,31,139,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8fccbdb7-dc23-4a94-a151-19c141114606"));
		}

		#endregion

	}

	#endregion

}

