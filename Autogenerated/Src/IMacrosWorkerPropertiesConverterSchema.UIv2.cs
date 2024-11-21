namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMacrosWorkerPropertiesConverterSchema

	/// <exclude/>
	public class IMacrosWorkerPropertiesConverterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMacrosWorkerPropertiesConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMacrosWorkerPropertiesConverterSchema(IMacrosWorkerPropertiesConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9fea00b7-db2d-4922-a2b4-e3c0ba2cab34");
			Name = "IMacrosWorkerPropertiesConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,144,205,10,194,48,16,132,207,22,250,14,139,39,5,105,30,192,218,131,158,122,40,22,21,60,199,178,45,193,230,199,77,34,136,248,238,54,210,22,17,17,143,187,204,124,179,179,138,75,180,134,87,8,235,178,216,235,218,37,27,173,106,209,120,226,78,104,21,71,247,56,154,48,198,32,181,94,74,78,183,172,159,115,229,144,234,96,172,53,65,165,213,21,201,9,213,128,228,21,105,11,134,180,9,27,180,201,64,96,31,136,212,221,12,26,78,92,130,234,206,88,77,15,59,188,120,180,110,154,229,202,120,247,5,149,178,209,243,139,98,125,219,65,182,222,253,69,49,254,212,138,10,196,216,40,47,94,150,163,166,51,82,57,250,186,207,132,146,72,233,112,232,2,250,176,128,9,159,154,244,51,244,218,217,160,124,139,159,47,59,225,35,142,30,79,208,218,116,21,124,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9fea00b7-db2d-4922-a2b4-e3c0ba2cab34"));
		}

		#endregion

	}

	#endregion

}

