namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IEqualComparatorProviderSchema

	/// <exclude/>
	public class IEqualComparatorProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEqualComparatorProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEqualComparatorProviderSchema(IEqualComparatorProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("16767ff9-f891-4a8b-8bb0-10d7f21c7208");
			Name = "IEqualComparatorProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,143,193,10,130,80,16,69,215,10,254,195,131,54,181,241,3,106,151,73,184,8,4,191,224,165,163,13,232,140,77,243,2,139,254,189,151,226,70,40,218,12,220,225,222,115,185,100,59,184,245,182,4,179,207,79,5,215,26,39,76,53,54,78,172,34,83,156,146,162,14,197,64,229,69,152,240,49,126,163,240,25,133,81,24,172,4,26,47,77,70,10,82,123,200,214,100,233,213,217,54,225,174,183,158,192,146,11,223,177,2,25,253,189,59,183,88,26,156,237,63,220,193,212,16,44,154,19,110,93,231,239,28,48,71,208,66,5,169,89,144,214,155,221,223,128,131,85,248,18,127,77,59,129,170,105,234,71,250,223,27,241,89,157,90,54,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("16767ff9-f891-4a8b-8bb0-10d7f21c7208"));
		}

		#endregion

	}

	#endregion

}

