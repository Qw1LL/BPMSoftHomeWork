namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ProductPriceDataSchema

	/// <exclude/>
	public class ProductPriceDataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ProductPriceDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ProductPriceDataSchema(ProductPriceDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("525ed2a1-425c-433b-81f6-b5e01bce93f9");
			Name = "ProductPriceData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c797525-d05e-4bd8-84e9-5dcb79ad7c60");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,77,106,195,48,16,70,215,54,248,14,3,217,199,251,166,116,81,23,74,160,5,67,122,1,85,26,155,1,91,50,35,9,98,74,238,94,253,196,165,105,168,219,108,12,26,205,123,243,201,146,22,35,218,73,72,132,199,246,245,96,58,183,109,140,238,168,247,44,28,25,93,149,31,85,89,120,75,186,135,195,108,29,142,187,170,12,149,13,99,31,182,161,25,132,181,119,208,178,81,94,186,150,73,226,147,112,34,245,212,117,13,247,214,143,163,224,249,225,188,78,253,32,141,118,130,52,50,116,134,47,224,237,194,213,223,192,201,191,15,36,65,38,246,122,84,17,34,134,239,87,166,208,49,33,59,194,24,44,161,121,255,103,158,84,120,19,71,32,133,218,81,71,200,113,252,245,252,37,192,179,39,21,129,189,218,253,234,107,60,51,106,57,223,38,93,168,53,115,58,49,188,144,117,183,185,219,200,69,108,85,142,44,131,19,76,7,78,28,215,173,10,37,141,98,136,127,226,140,253,21,58,88,167,124,109,255,51,39,42,63,180,98,131,90,229,139,77,235,83,126,126,23,197,211,39,94,135,247,178,197,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("525ed2a1-425c-433b-81f6-b5e01bce93f9"));
		}

		#endregion

	}

	#endregion

}

