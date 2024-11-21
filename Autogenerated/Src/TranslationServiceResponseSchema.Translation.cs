namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TranslationServiceResponseSchema

	/// <exclude/>
	public class TranslationServiceResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TranslationServiceResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TranslationServiceResponseSchema(TranslationServiceResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5fe50c86-213a-4ba1-9a12-4686b15dab3c");
			Name = "TranslationServiceResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2c48a34f-0c95-44d9-a69e-4bfc769a17b3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,146,203,110,194,48,16,69,215,70,226,31,44,216,148,77,62,128,62,22,165,80,85,42,21,34,221,85,85,229,152,33,181,228,216,145,31,244,165,254,123,39,49,160,56,20,4,98,19,197,227,153,59,103,174,71,177,2,108,201,56,208,219,217,52,213,75,151,140,180,90,138,220,27,230,132,86,201,179,97,202,202,250,191,219,249,233,118,136,183,66,229,52,253,178,14,138,203,214,25,107,165,4,94,37,219,228,30,20,24,193,119,114,230,94,57,81,64,146,226,45,147,226,187,214,198,44,204,235,27,200,241,64,71,146,89,59,164,141,222,152,188,18,28,230,200,138,218,80,103,191,220,49,199,144,214,25,198,221,43,6,74,159,73,193,41,175,170,15,20,211,33,141,102,220,209,38,56,39,126,183,56,19,1,114,129,60,51,35,86,204,133,230,161,251,20,138,12,204,197,19,154,72,175,105,79,151,16,36,31,117,222,27,84,72,164,12,53,244,97,172,124,129,183,153,132,43,235,12,250,113,67,223,154,249,193,1,210,7,181,8,109,99,6,36,198,50,207,157,54,109,146,77,139,253,19,95,12,104,245,116,228,247,232,130,241,39,135,178,186,160,48,64,191,50,134,49,56,89,229,191,161,155,51,175,5,73,100,4,26,217,242,101,219,114,159,57,83,112,239,186,126,161,122,3,214,124,97,27,172,67,37,126,104,29,70,6,112,142,212,115,14,214,98,212,75,183,49,140,24,112,222,40,170,224,227,160,189,77,200,179,250,30,235,152,57,138,43,170,60,131,113,194,132,244,166,138,86,140,209,110,156,130,3,17,67,235,49,67,52,14,98,236,15,252,47,49,83,160,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5fe50c86-213a-4ba1-9a12-4686b15dab3c"));
		}

		#endregion

	}

	#endregion

}

