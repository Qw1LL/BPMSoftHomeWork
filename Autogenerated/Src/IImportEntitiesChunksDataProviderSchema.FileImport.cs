namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImportEntitiesChunksDataProviderSchema

	/// <exclude/>
	public class IImportEntitiesChunksDataProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImportEntitiesChunksDataProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImportEntitiesChunksDataProviderSchema(IImportEntitiesChunksDataProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2a8003b9-4985-421c-aeb6-96632952b722");
			Name = "IImportEntitiesChunksDataProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,203,110,194,48,16,60,131,196,63,172,224,210,74,40,185,151,144,67,41,69,57,32,33,248,2,199,222,128,213,216,142,252,128,162,138,127,175,237,64,68,169,212,28,122,244,120,118,231,225,68,18,129,166,33,20,225,117,179,222,169,202,38,11,37,43,190,119,154,88,174,100,242,206,107,44,68,163,180,29,13,191,70,195,129,51,92,238,97,119,54,22,197,236,225,236,71,235,26,105,152,51,201,10,37,106,78,61,199,179,38,26,247,30,133,66,90,212,149,87,123,129,162,221,186,148,150,91,142,102,113,112,242,195,188,17,75,54,90,29,57,67,29,7,211,52,133,204,56,33,136,62,231,215,115,59,8,204,115,161,185,146,161,82,218,19,17,129,106,172,230,227,190,48,73,212,61,71,213,32,58,134,52,79,110,122,233,157,96,227,202,154,83,224,55,227,253,190,187,104,221,242,219,77,214,226,1,138,119,217,131,137,60,7,95,177,23,237,250,90,163,61,40,102,90,240,177,139,8,236,200,17,189,59,31,95,196,140,64,74,229,108,232,133,162,137,111,163,213,9,52,26,87,219,16,240,119,194,1,28,21,103,113,209,166,157,66,182,85,167,167,149,243,40,13,222,10,54,13,5,132,77,133,100,248,57,133,82,169,26,140,163,129,13,115,176,218,225,243,236,15,151,91,180,154,163,119,74,187,47,4,78,220,30,122,157,155,191,173,23,75,233,4,106,82,214,152,221,155,223,198,161,28,86,104,239,97,243,35,84,143,99,161,254,221,108,44,182,221,212,111,99,130,146,181,207,30,207,151,246,199,185,3,47,223,252,250,136,222,172,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2a8003b9-4985-421c-aeb6-96632952b722"));
		}

		#endregion

	}

	#endregion

}

