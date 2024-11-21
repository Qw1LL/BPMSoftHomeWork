namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImportLookupChunksDataProviderSchema

	/// <exclude/>
	public class IImportLookupChunksDataProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImportLookupChunksDataProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImportLookupChunksDataProviderSchema(IImportLookupChunksDataProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("425cd682-be37-44b5-8c48-07738afab1de");
			Name = "IImportLookupChunksDataProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,205,10,131,48,16,132,207,21,124,135,197,222,205,189,88,15,181,20,132,22,132,62,65,170,27,27,212,36,172,73,161,20,223,189,254,35,189,244,184,59,51,31,195,40,222,96,107,120,142,112,202,110,119,45,108,152,104,37,100,233,136,91,169,85,120,145,53,166,141,209,100,225,227,123,190,183,219,19,150,189,0,169,178,72,162,15,30,32,157,12,87,173,43,103,146,167,83,85,123,230,150,103,164,95,178,64,26,99,140,49,136,90,215,52,156,222,241,124,207,220,162,247,130,153,205,32,52,245,70,68,200,9,197,49,216,64,7,102,0,44,14,23,28,219,240,140,123,212,50,7,185,180,250,87,10,214,218,43,123,145,162,233,63,188,70,45,250,233,16,199,195,20,187,110,154,3,85,49,45,226,123,221,23,87,136,234,112,77,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("425cd682-be37-44b5-8c48-07738afab1de"));
		}

		#endregion

	}

	#endregion

}

