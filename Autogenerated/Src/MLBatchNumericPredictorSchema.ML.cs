namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MLBatchNumericPredictorSchema

	/// <exclude/>
	public class MLBatchNumericPredictorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MLBatchNumericPredictorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MLBatchNumericPredictorSchema(MLBatchNumericPredictorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0aff8371-c82b-4302-bc26-bde1d1357452");
			Name = "MLBatchNumericPredictor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("73704ec6-562c-4400-8a4a-17477a18625f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,84,219,106,219,64,16,125,86,32,255,48,168,47,46,4,233,61,117,252,16,23,138,33,42,166,110,62,96,173,29,89,11,210,174,216,139,138,27,242,239,157,221,149,228,91,84,2,194,104,206,250,156,51,115,118,108,201,90,52,29,43,17,158,183,197,78,85,54,91,43,89,137,131,211,204,10,37,179,226,229,254,238,237,254,46,113,70,200,3,236,142,198,98,251,109,170,215,74,35,85,84,231,121,14,75,227,218,150,233,227,106,168,215,13,51,6,42,165,97,207,108,89,67,167,145,139,210,42,109,192,214,204,66,205,122,28,65,242,2,141,198,53,22,84,69,74,136,80,106,172,158,82,174,220,190,193,52,95,129,61,118,152,141,86,249,149,151,103,176,198,168,129,53,55,12,61,207,190,151,237,216,202,91,28,41,251,30,108,222,83,200,189,98,71,133,40,161,12,3,12,148,159,174,69,45,202,137,9,143,227,201,4,45,99,179,94,129,50,163,207,228,139,198,131,31,141,250,48,86,187,48,252,35,108,181,178,88,90,228,241,75,215,217,5,96,35,133,21,172,17,127,209,0,3,137,127,64,144,4,147,116,83,20,144,173,241,60,164,153,22,125,106,97,6,31,219,109,110,17,233,152,102,45,72,218,131,167,212,25,212,212,170,164,230,168,235,116,245,155,108,60,6,229,4,102,203,60,48,130,64,55,14,50,23,210,226,245,66,49,136,157,202,175,148,225,158,25,92,92,195,126,227,146,247,33,66,148,60,166,120,25,105,129,182,86,252,147,105,238,104,213,252,214,125,176,111,159,205,166,85,28,155,184,79,49,152,0,248,100,8,185,72,229,134,138,210,10,123,220,240,200,139,21,8,238,95,42,129,250,255,228,158,53,14,211,213,246,230,119,210,251,131,153,235,80,61,106,77,14,208,43,193,195,244,39,254,175,64,95,20,47,197,105,162,56,76,124,127,128,31,142,72,99,211,15,94,57,73,226,106,71,211,225,130,146,147,166,119,208,217,165,207,226,76,51,35,157,115,143,44,120,111,134,141,126,245,167,147,223,224,225,255,101,102,118,128,80,122,254,1,82,186,173,85,187,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0aff8371-c82b-4302-bc26-bde1d1357452"));
		}

		#endregion

	}

	#endregion

}

