namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CESMailingProviderConfigFactorySchema

	/// <exclude/>
	public class CESMailingProviderConfigFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CESMailingProviderConfigFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CESMailingProviderConfigFactorySchema(CESMailingProviderConfigFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("21e2f7e7-ec6e-4ec1-a3d8-235df40381e1");
			Name = "CESMailingProviderConfigFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bc5abc6e-45a7-497f-b7c0-68ae441d38e3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,82,95,75,195,48,16,127,222,192,239,112,204,151,9,210,190,207,173,160,69,101,15,131,225,240,3,196,236,90,3,107,82,46,201,100,136,223,221,107,146,185,110,78,5,95,82,122,127,126,127,238,78,139,6,109,43,36,194,221,114,177,50,149,203,74,163,43,85,123,18,78,25,125,49,124,191,24,14,188,85,186,238,21,16,222,156,141,102,15,66,58,67,10,45,231,185,226,146,176,102,16,40,55,194,218,9,148,247,171,133,80,27,238,90,146,217,170,53,82,228,138,93,187,208,146,231,57,76,173,111,26,65,187,34,253,167,106,11,13,186,87,179,182,80,25,2,73,200,10,89,128,210,214,9,45,153,20,76,5,238,21,185,31,177,203,87,179,209,252,44,225,40,47,178,61,87,222,35,107,253,203,70,73,144,157,220,191,212,194,4,230,191,187,25,240,232,248,253,154,194,34,170,159,192,50,208,196,228,169,223,16,40,59,111,236,39,89,195,51,198,126,82,151,172,125,247,22,35,173,32,209,128,230,165,207,70,222,134,38,141,178,219,244,168,152,247,216,122,76,207,199,101,140,63,205,3,204,1,149,208,121,210,182,120,138,223,255,234,158,230,123,160,14,57,45,227,252,144,211,136,246,146,199,199,34,225,216,218,21,116,71,60,24,108,5,1,234,90,105,188,165,218,194,12,52,190,1,151,89,71,190,219,25,71,125,131,218,141,79,71,115,125,10,216,157,127,196,147,27,227,215,247,1,148,1,195,161,167,3,200,30,209,77,239,218,166,164,166,60,20,21,227,131,130,62,76,116,149,36,253,48,163,113,106,136,197,217,10,105,171,36,222,182,138,251,122,58,122,137,88,31,158,56,218,68,20,226,31,233,60,81,175,227,133,134,255,24,61,14,114,236,19,11,231,202,168,40,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("21e2f7e7-ec6e-4ec1-a3d8-235df40381e1"));
		}

		#endregion

	}

	#endregion

}

