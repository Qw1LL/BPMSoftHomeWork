namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IContentStoreSchema

	/// <exclude/>
	public class IContentStoreSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IContentStoreSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IContentStoreSchema(IContentStoreSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e3c7a9a4-e4fe-4de6-9313-1b0c8d8e8ead");
			Name = "IContentStore";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("16e592d3-2033-426b-b620-6aa2b1f8eec0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,146,207,106,2,49,16,198,207,10,190,195,96,47,45,20,247,174,86,104,181,136,80,169,40,125,128,184,153,93,67,119,147,37,153,80,68,124,247,206,254,137,237,90,45,189,245,176,129,153,124,243,205,111,178,163,69,142,174,16,49,194,211,106,185,49,9,13,166,70,39,42,245,86,144,50,186,215,61,244,186,29,239,148,78,97,179,119,132,249,232,20,79,141,197,118,52,120,214,164,72,161,227,52,95,220,88,76,217,3,22,154,208,38,220,99,8,11,118,39,212,180,33,150,87,162,40,138,96,236,124,158,11,187,159,52,241,26,11,139,142,101,14,92,41,132,196,88,200,125,70,42,19,58,245,34,69,136,107,159,65,112,136,190,89,20,126,155,169,24,84,104,123,222,181,195,51,241,121,226,91,89,83,160,45,185,135,176,170,106,235,251,115,180,42,49,67,118,205,149,70,7,31,59,164,29,90,32,3,36,222,177,108,104,64,196,177,241,154,192,170,116,199,252,156,113,152,97,76,32,5,137,18,247,39,111,103,107,76,6,111,14,31,37,27,175,235,194,3,164,72,35,46,230,227,216,240,162,150,53,114,155,127,201,24,70,254,5,126,141,228,173,118,225,245,128,63,69,251,43,84,85,166,16,86,228,160,121,75,30,250,181,122,33,251,147,87,158,78,105,145,53,6,39,63,37,203,68,162,208,14,198,81,85,122,217,41,252,198,210,235,37,252,210,223,138,109,13,62,89,94,90,130,48,198,56,10,178,178,174,218,197,61,204,145,110,231,94,201,70,180,144,247,80,133,95,8,119,163,63,188,152,196,68,112,239,127,121,185,48,213,236,50,195,181,177,27,121,123,250,48,236,217,46,213,27,214,78,30,63,1,203,108,234,52,28,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e3c7a9a4-e4fe-4de6-9313-1b0c8d8e8ead"));
		}

		#endregion

	}

	#endregion

}

