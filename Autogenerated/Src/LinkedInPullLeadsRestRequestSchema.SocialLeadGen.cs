namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LinkedInPullLeadsRestRequestSchema

	/// <exclude/>
	public class LinkedInPullLeadsRestRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LinkedInPullLeadsRestRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LinkedInPullLeadsRestRequestSchema(LinkedInPullLeadsRestRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6413fce5-0d56-4454-a110-907134c1fae3");
			Name = "LinkedInPullLeadsRestRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,83,221,106,194,48,20,190,174,224,59,28,216,197,238,236,253,20,133,169,147,130,99,197,238,5,210,228,52,11,75,147,46,63,27,34,190,251,210,84,103,55,134,58,88,47,90,122,250,253,157,147,83,69,106,180,13,161,8,247,249,99,161,43,55,154,107,85,9,238,13,113,66,171,81,161,169,32,114,141,132,173,80,13,7,187,225,32,241,86,40,14,197,214,58,172,199,195,1,132,171,95,10,2,82,34,109,217,118,20,72,104,4,13,176,14,120,99,144,135,15,48,151,196,218,59,88,11,245,138,44,83,185,151,209,195,110,208,186,13,190,249,240,56,82,210,52,133,137,245,117,77,204,118,122,42,205,165,246,12,76,135,133,197,243,19,124,8,247,2,66,85,218,212,49,59,144,82,123,7,77,208,6,217,138,3,141,173,245,100,211,239,186,141,47,165,160,64,219,112,23,178,37,237,36,146,99,59,185,209,13,26,39,48,244,148,71,145,54,125,146,252,200,222,21,10,71,140,3,70,28,126,65,122,57,146,228,144,194,58,19,135,218,162,23,1,12,59,224,232,198,96,219,219,254,223,244,151,138,253,73,61,83,84,122,134,97,208,36,156,241,59,130,33,138,163,61,107,85,106,45,143,196,236,192,219,68,218,213,182,107,17,78,89,87,32,184,210,6,193,198,181,140,199,10,130,221,158,183,207,150,202,215,104,72,41,113,210,117,61,133,44,234,156,182,59,11,235,113,253,8,28,242,238,255,8,230,103,173,87,94,176,89,159,144,177,171,109,30,194,34,95,210,151,90,241,89,68,254,38,28,87,20,21,235,182,52,190,119,134,223,139,251,79,125,106,225,74,5,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6413fce5-0d56-4454-a110-907134c1fae3"));
		}

		#endregion

	}

	#endregion

}

