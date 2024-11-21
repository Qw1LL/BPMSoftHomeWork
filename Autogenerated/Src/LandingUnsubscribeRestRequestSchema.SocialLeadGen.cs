namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LandingUnsubscribeRestRequestSchema

	/// <exclude/>
	public class LandingUnsubscribeRestRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LandingUnsubscribeRestRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LandingUnsubscribeRestRequestSchema(LandingUnsubscribeRestRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a0d75d98-819a-c4f5-150a-b26f00c1ebdd");
			Name = "LandingUnsubscribeRestRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,75,75,196,48,20,133,215,83,232,127,184,224,190,221,59,226,194,138,131,48,98,153,42,174,243,184,173,23,242,168,121,32,195,224,127,55,77,58,226,99,225,230,134,123,114,114,248,78,12,211,232,103,38,16,110,250,135,193,142,161,233,172,25,105,138,142,5,178,166,25,172,32,166,246,200,228,14,77,93,157,234,106,19,61,153,9,134,163,15,168,183,117,149,148,11,135,83,50,67,167,152,247,151,176,103,70,38,203,179,241,145,123,225,136,227,1,125,56,224,91,76,71,126,208,182,45,92,249,168,53,115,199,235,117,239,148,141,18,92,113,193,237,211,35,188,83,120,5,50,163,117,58,195,0,227,54,6,80,37,190,57,231,180,223,130,230,200,21,9,16,11,200,127,28,155,84,38,205,47,250,222,217,25,93,32,76,21,250,156,83,238,127,195,102,97,205,6,146,11,199,95,144,51,201,46,146,204,95,27,162,36,251,130,252,46,181,185,151,112,130,9,195,22,252,50,62,86,14,52,178,160,228,189,168,63,197,164,125,2,181,136,10,124,177,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a0d75d98-819a-c4f5-150a-b26f00c1ebdd"));
		}

		#endregion

	}

	#endregion

}

