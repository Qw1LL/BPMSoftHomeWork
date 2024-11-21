namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PriceListPickerRebinderSchema

	/// <exclude/>
	public class PriceListPickerRebinderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PriceListPickerRebinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PriceListPickerRebinderSchema(PriceListPickerRebinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("58d4987a-d23e-4bb9-a16c-5a1bd52bc088");
			Name = "PriceListPickerRebinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5ae20eb0-a56b-4e38-9555-e43d9bbc10d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,80,77,107,195,48,12,61,167,208,255,32,216,165,131,145,220,187,82,88,202,6,131,149,133,246,176,179,227,168,169,88,99,7,217,9,43,163,255,125,74,156,140,172,163,23,27,233,125,72,122,70,85,232,106,165,17,210,108,187,183,7,31,111,172,57,80,217,176,242,100,205,124,246,61,159,69,141,35,83,78,8,140,241,139,210,222,50,161,123,252,135,127,96,46,156,170,178,70,48,65,239,24,75,177,130,205,73,57,183,132,140,73,227,27,57,159,145,254,68,222,97,78,166,64,238,169,73,146,192,202,53,85,165,248,188,30,234,215,43,1,232,206,7,120,208,197,163,44,153,232,234,38,63,145,30,152,55,6,194,18,158,234,250,185,69,227,59,16,13,114,170,28,138,90,78,150,247,119,239,45,250,163,45,186,205,123,215,0,14,19,108,139,204,84,32,180,150,10,120,55,226,184,247,138,253,98,180,150,52,61,126,121,208,225,191,135,46,207,40,202,101,82,60,161,143,112,151,102,20,245,73,133,132,207,241,14,83,217,119,117,29,195,3,100,34,148,165,221,145,234,43,108,189,8,70,151,225,16,52,69,184,165,175,67,247,111,243,242,3,68,33,149,158,8,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("58d4987a-d23e-4bb9-a16c-5a1bd52bc088"));
		}

		#endregion

	}

	#endregion

}

