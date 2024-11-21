namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OpportunityStageRepositorySchema

	/// <exclude/>
	public class OpportunityStageRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OpportunityStageRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OpportunityStageRepositorySchema(OpportunityStageRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("55be1109-390d-43ae-b7ab-5425c01ee864");
			Name = "OpportunityStageRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5ef32b22-5119-483b-953d-678c3fffad13");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,84,65,110,219,48,16,60,43,64,254,176,80,47,14,16,72,119,215,14,208,170,105,208,67,154,180,78,123,167,169,181,173,66,34,149,37,25,64,8,252,247,46,41,217,150,93,58,45,208,139,4,146,179,51,59,195,149,148,104,208,180,66,34,124,124,188,95,232,149,205,10,173,86,213,218,145,176,149,86,151,23,175,151,23,137,51,149,90,143,0,132,239,163,187,217,173,178,149,173,208,240,49,3,222,17,174,153,3,138,90,24,51,133,135,182,213,100,157,170,108,23,112,221,194,138,53,126,18,86,4,116,158,231,48,51,174,105,4,117,55,195,122,84,2,198,163,161,100,56,72,173,44,9,105,179,93,89,126,82,55,51,136,162,54,26,36,225,106,158,70,173,101,123,249,20,114,95,216,186,101,93,73,144,190,219,177,242,30,7,83,40,116,211,104,53,106,60,225,124,248,185,237,13,163,42,123,207,127,241,31,8,190,99,171,77,101,53,117,103,253,63,109,16,104,15,131,149,38,208,209,72,254,47,137,209,117,28,154,122,141,99,99,193,108,255,37,193,3,51,231,24,85,156,197,184,61,175,159,193,67,154,90,177,111,101,57,209,199,160,23,210,219,107,251,83,14,134,252,108,142,248,10,33,55,120,71,218,181,95,121,226,97,14,233,169,152,73,251,169,61,189,197,99,97,114,146,91,141,107,159,119,60,249,97,144,184,94,161,244,33,130,59,90,94,121,142,100,10,75,97,112,114,124,116,253,103,159,233,245,121,95,87,16,162,218,190,109,228,30,237,70,151,222,3,105,203,58,88,14,54,118,75,208,47,72,84,149,24,255,12,10,66,97,241,97,249,139,193,159,73,55,253,101,78,250,87,63,148,67,35,73,180,62,124,195,243,96,55,59,195,213,147,248,191,76,146,132,249,254,98,22,78,74,52,102,229,106,174,13,231,217,29,218,167,174,197,178,208,181,107,212,79,81,59,156,45,181,174,111,38,233,1,157,14,52,132,214,145,10,226,97,99,8,41,98,122,24,78,14,182,17,223,28,242,192,178,80,191,201,74,117,127,51,183,230,121,178,115,249,34,8,208,60,239,60,157,67,247,125,48,48,251,80,14,61,191,209,40,227,198,125,142,47,51,242,187,217,254,6,64,96,21,84,201,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("55be1109-390d-43ae-b7ab-5425c01ee864"));
		}

		#endregion

	}

	#endregion

}

