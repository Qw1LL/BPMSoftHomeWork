namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SocialLeadGenRestProviderResponseSchema

	/// <exclude/>
	public class SocialLeadGenRestProviderResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SocialLeadGenRestProviderResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SocialLeadGenRestProviderResponseSchema(SocialLeadGenRestProviderResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bb4700f9-fd00-5da9-06bb-a7b825d87bb3");
			Name = "SocialLeadGenRestProviderResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,144,77,78,195,64,12,133,215,141,148,59,88,101,159,236,11,116,65,85,177,161,82,68,79,48,76,156,169,165,196,19,217,147,34,84,245,238,204,228,7,21,88,192,38,26,219,47,159,223,51,155,14,181,55,22,225,169,58,28,125,19,138,157,231,134,220,32,38,144,231,226,232,45,153,246,5,77,253,140,156,103,151,60,203,179,213,157,160,139,67,216,181,70,117,3,223,52,175,168,161,18,127,166,26,37,190,123,207,138,227,79,101,89,194,131,14,93,103,228,99,59,215,139,0,108,34,65,227,37,74,48,150,130,205,227,250,79,238,186,220,130,225,26,136,79,40,20,176,158,56,168,197,178,175,188,89,216,15,111,45,217,121,213,63,60,175,166,176,95,105,163,162,71,9,132,49,114,53,178,166,249,207,96,99,35,94,49,24,98,5,20,137,169,226,145,213,56,132,247,19,50,36,204,120,93,32,133,129,117,176,54,142,147,231,223,166,23,215,26,132,216,193,62,209,14,51,236,2,14,195,61,104,250,92,103,175,200,245,100,119,172,167,238,109,243,250,9,199,156,185,68,241,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bb4700f9-fd00-5da9-06bb-a7b825d87bb3"));
		}

		#endregion

	}

	#endregion

}

