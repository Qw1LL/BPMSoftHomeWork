namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ProductConstsCodeSchema

	/// <exclude/>
	public class ProductConstsCodeSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ProductConstsCodeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ProductConstsCodeSchema(ProductConstsCodeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e82d2b87-855b-4382-aac0-c05f66836306");
			Name = "ProductConstsCode";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,141,189,10,131,48,28,196,103,5,223,225,143,83,59,88,252,194,32,210,193,15,44,29,4,65,250,0,105,140,18,208,68,76,66,17,233,187,55,84,186,244,134,91,238,119,119,28,207,84,46,152,80,40,218,166,19,131,186,148,130,15,108,212,43,86,76,112,199,222,29,219,210,146,241,17,186,77,42,58,103,142,13,70,139,126,78,140,128,84,6,35,64,38,44,37,180,171,232,53,81,102,64,42,121,96,59,152,186,245,71,175,20,247,130,79,27,220,52,235,127,173,198,248,68,31,247,30,174,192,233,235,155,157,220,40,175,43,132,170,196,171,99,84,123,113,157,134,94,154,228,190,135,162,188,40,3,63,8,243,36,113,207,25,88,214,241,247,118,236,247,7,252,49,97,103,211,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e82d2b87-855b-4382-aac0-c05f66836306"));
		}

		#endregion

	}

	#endregion

}

