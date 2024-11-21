namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LinkedInAdAccountListResponseSchema

	/// <exclude/>
	public class LinkedInAdAccountListResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LinkedInAdAccountListResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LinkedInAdAccountListResponseSchema(LinkedInAdAccountListResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("26f7958d-2eef-c66c-ca40-74d11543a381");
			Name = "LinkedInAdAccountListResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5eec482-a90e-42cc-86d3-ef2673139bae");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,146,205,106,195,48,16,132,207,54,228,29,22,114,183,239,73,8,164,57,148,128,83,76,253,4,170,180,49,162,182,100,180,114,33,132,188,123,215,241,79,28,199,180,20,122,17,120,52,59,243,73,178,17,37,82,37,36,194,75,122,204,236,201,71,123,107,78,58,175,157,240,218,154,40,179,82,139,34,65,161,94,209,44,194,203,34,12,106,210,38,135,236,76,30,75,118,23,5,202,198,74,17,59,208,105,185,94,132,236,90,58,204,89,133,125,33,136,86,144,104,243,137,234,96,118,106,39,165,173,141,79,52,249,119,174,230,65,188,13,196,113,12,27,170,203,82,184,243,182,251,238,229,120,164,87,245,71,161,37,200,38,247,231,88,88,193,3,62,235,62,117,246,75,43,116,247,234,128,207,196,235,20,120,72,108,119,167,116,61,222,51,223,35,224,40,38,232,155,134,42,134,169,208,121,141,220,151,222,166,58,195,83,219,80,55,211,215,23,146,119,205,195,12,141,7,5,23,200,209,175,129,154,229,250,159,217,111,252,219,204,166,47,209,168,246,116,173,208,233,83,249,183,27,248,251,117,55,15,191,25,248,182,119,84,154,227,156,240,180,234,88,188,126,3,248,8,114,31,25,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("26f7958d-2eef-c66c-ca40-74d11543a381"));
		}

		#endregion

	}

	#endregion

}

