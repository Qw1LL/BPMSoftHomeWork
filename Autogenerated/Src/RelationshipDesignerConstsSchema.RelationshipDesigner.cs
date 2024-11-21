namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: RelationshipDesignerConstsSchema

	/// <exclude/>
	public class RelationshipDesignerConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RelationshipDesignerConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RelationshipDesignerConstsSchema(RelationshipDesignerConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("718abfbc-0c58-497c-88f9-59343c161b6f");
			Name = "RelationshipDesignerConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("306bd3dc-c1db-4d7d-a14d-6d8f14db70cb");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,146,65,79,220,48,16,133,207,68,202,127,176,56,149,195,128,99,59,78,34,196,33,137,199,112,161,66,208,59,74,131,217,90,202,218,81,156,45,90,16,255,157,236,178,93,26,9,84,80,47,150,71,243,222,155,79,99,175,130,117,11,114,179,14,163,89,158,198,81,28,185,102,105,66,223,180,134,84,87,151,55,254,126,60,174,189,187,183,139,213,208,140,214,187,227,107,211,109,47,225,151,237,149,9,118,225,204,16,71,79,113,116,208,175,126,118,182,37,97,156,250,45,105,187,38,4,242,158,122,202,155,52,110,12,147,103,227,59,56,57,249,35,35,227,186,55,164,245,206,153,246,173,6,162,253,176,108,186,141,118,62,100,48,205,157,119,221,154,156,175,236,221,126,216,143,201,84,239,51,54,213,237,107,0,57,35,206,60,108,197,223,14,83,169,50,78,43,13,44,211,41,8,166,10,200,185,210,144,108,78,134,53,149,101,114,120,116,250,57,192,239,126,252,111,198,125,198,12,83,170,68,49,38,56,40,161,16,132,146,2,202,178,18,192,56,162,18,148,37,165,164,31,96,246,62,216,109,5,228,194,15,246,209,187,241,243,128,87,59,243,237,155,117,198,85,214,180,64,45,51,144,200,5,8,141,8,133,230,18,170,180,210,89,150,32,79,121,246,111,46,101,135,105,3,241,87,153,94,109,51,30,74,69,174,179,92,131,40,153,156,120,74,10,57,149,21,168,26,121,81,200,20,211,244,163,231,252,139,231,218,252,54,67,48,95,6,218,249,102,68,9,34,230,168,40,48,153,76,31,12,57,131,66,200,26,56,21,152,20,133,46,243,122,183,161,231,56,122,126,1,179,43,113,8,137,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("718abfbc-0c58-497c-88f9-59343c161b6f"));
		}

		#endregion

	}

	#endregion

}

