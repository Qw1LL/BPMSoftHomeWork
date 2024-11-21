namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: RelationshipDiagramConfigProviderSchema

	/// <exclude/>
	public class RelationshipDiagramConfigProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RelationshipDiagramConfigProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RelationshipDiagramConfigProviderSchema(RelationshipDiagramConfigProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dd23d878-8d9c-8ece-5b7d-37cf027c27fd");
			Name = "RelationshipDiagramConfigProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("32e5a92e-2a79-472b-b08d-f730aa69067f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,84,77,111,155,64,16,61,59,82,254,195,138,147,45,5,7,176,113,220,90,62,24,47,142,144,210,202,170,213,94,170,30,182,48,224,149,96,23,237,71,42,43,242,127,239,242,209,196,196,180,78,115,1,118,247,189,55,243,118,102,96,164,0,89,146,24,80,176,253,180,227,169,26,175,57,75,105,166,5,81,148,179,241,23,200,235,15,185,167,37,6,73,51,6,226,250,234,233,250,106,160,37,101,25,218,29,164,130,98,241,188,126,81,17,48,222,144,88,113,65,65,154,115,131,40,245,207,156,198,40,206,137,148,8,83,146,9,82,116,162,25,76,165,252,7,24,50,69,213,161,131,64,27,42,164,122,128,71,200,155,125,84,19,6,25,168,5,146,230,81,173,142,23,52,118,16,115,150,188,65,228,120,158,118,143,222,171,172,239,53,77,208,46,222,67,65,190,70,201,165,252,164,18,213,181,97,42,203,156,28,190,145,92,195,154,231,186,96,127,33,158,83,163,130,100,255,230,116,125,80,166,64,164,85,197,163,78,113,79,235,177,21,252,145,38,85,165,27,107,125,197,66,247,160,58,27,195,209,226,57,214,119,12,41,209,185,10,40,75,76,146,67,117,40,129,167,195,203,17,71,163,31,175,175,252,34,7,125,252,15,43,173,244,27,29,181,55,42,64,105,193,16,131,95,253,196,6,53,56,107,206,101,77,233,235,193,150,49,120,105,148,101,221,57,227,45,17,18,134,150,231,227,187,181,187,10,108,23,135,142,61,245,29,215,14,166,142,103,59,94,232,132,254,234,206,195,179,208,26,221,160,219,91,18,199,92,51,213,234,245,52,210,18,89,159,205,148,91,55,45,36,58,105,24,115,182,106,248,15,60,227,81,98,53,152,99,139,61,159,148,247,59,114,103,65,56,153,249,174,61,223,132,158,61,117,253,15,246,28,99,199,94,205,157,9,158,206,230,19,140,39,141,35,19,83,153,63,199,187,29,109,247,92,157,120,169,95,199,211,97,48,91,191,1,175,231,31,56,248,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dd23d878-8d9c-8ece-5b7d-37cf027c27fd"));
		}

		#endregion

	}

	#endregion

}

