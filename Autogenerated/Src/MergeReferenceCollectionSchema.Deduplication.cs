namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MergeReferenceCollectionSchema

	/// <exclude/>
	public class MergeReferenceCollectionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MergeReferenceCollectionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MergeReferenceCollectionSchema(MergeReferenceCollectionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5a6b80e9-72e3-4e49-9d00-89ee49b01416");
			Name = "MergeReferenceCollection";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,142,65,10,131,48,16,69,215,21,188,195,64,183,197,3,216,226,162,10,221,40,148,122,130,52,126,67,32,70,201,36,11,41,222,189,137,45,116,213,197,192,252,153,55,243,191,21,19,120,17,18,116,189,119,253,60,250,162,158,237,168,85,112,194,235,217,22,13,134,176,24,45,119,149,103,175,60,59,4,214,86,81,191,178,199,20,105,99,32,211,146,139,27,44,156,150,231,60,139,212,209,65,197,41,213,70,48,151,212,193,41,60,48,194,193,74,252,174,118,118,9,207,104,65,50,161,127,73,42,169,209,123,39,220,122,97,239,98,138,19,181,154,253,87,84,85,124,149,2,110,177,82,2,216,225,19,34,153,108,111,101,181,104,3,234,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5a6b80e9-72e3-4e49-9d00-89ee49b01416"));
		}

		#endregion

	}

	#endregion

}

