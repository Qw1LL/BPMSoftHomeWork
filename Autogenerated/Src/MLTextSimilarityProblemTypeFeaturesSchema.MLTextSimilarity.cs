namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MLTextSimilarityProblemTypeFeaturesSchema

	/// <exclude/>
	public class MLTextSimilarityProblemTypeFeaturesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MLTextSimilarityProblemTypeFeaturesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MLTextSimilarityProblemTypeFeaturesSchema(MLTextSimilarityProblemTypeFeaturesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9fc5d315-3ac5-48a3-af06-cad122142a03");
			Name = "MLTextSimilarityProblemTypeFeatures";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d4e7fe16-4978-48c7-8486-0391de2e8fa7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,145,79,107,2,49,16,197,207,46,236,119,152,163,66,217,189,215,182,7,45,210,130,219,46,232,173,244,48,238,78,36,144,100,150,252,41,21,241,187,119,86,221,86,172,144,28,50,121,249,189,153,23,135,150,66,135,13,193,172,174,86,172,98,49,103,167,244,54,121,140,154,93,81,45,243,108,159,103,163,20,180,219,94,104,60,21,11,108,34,123,77,97,154,103,162,40,203,18,30,66,178,22,253,238,233,124,174,209,71,221,36,131,30,20,97,76,158,2,176,130,53,125,71,88,105,171,229,66,199,29,116,158,55,134,44,196,93,71,197,128,42,47,88,31,207,164,48,153,56,211,174,149,62,198,189,144,213,248,181,90,214,167,167,107,41,44,206,14,147,59,120,147,169,224,17,170,101,239,244,103,84,123,106,117,223,116,113,93,231,1,50,249,20,187,46,109,140,110,160,49,24,194,13,200,175,120,112,132,123,81,157,91,188,113,45,196,62,194,81,191,175,83,58,22,94,80,98,73,177,75,17,198,17,253,150,226,4,26,54,201,58,80,236,193,114,75,6,162,71,237,100,248,62,160,255,9,13,61,243,23,121,175,91,130,13,179,233,193,239,71,238,252,68,219,131,176,167,112,144,108,20,154,64,242,115,163,67,158,201,250,1,132,192,101,33,8,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9fc5d315-3ac5-48a3-af06-cad122142a03"));
		}

		#endregion

	}

	#endregion

}

