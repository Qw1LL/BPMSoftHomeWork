namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: NonPersistentColumnsAggregatorAdapterSchema

	/// <exclude/>
	public class NonPersistentColumnsAggregatorAdapterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NonPersistentColumnsAggregatorAdapterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NonPersistentColumnsAggregatorAdapterSchema(NonPersistentColumnsAggregatorAdapterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0e17349a-19a3-44d5-b001-2f4514573b56");
			Name = "NonPersistentColumnsAggregatorAdapter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,193,106,194,64,16,61,43,248,15,67,188,40,72,114,183,26,176,210,22,15,150,128,248,1,235,102,140,11,201,110,152,221,20,68,250,239,29,147,24,53,106,241,208,75,47,66,30,111,230,189,153,183,163,22,25,218,92,72,132,215,104,185,50,91,231,207,141,222,170,164,32,225,148,209,254,187,74,113,145,229,134,92,175,123,232,117,59,133,85,58,129,213,222,58,204,152,154,166,40,143,60,235,127,160,70,82,242,165,225,156,251,17,50,202,120,159,48,97,46,192,60,21,214,142,225,211,232,8,201,42,238,165,29,247,42,50,109,103,73,194,44,225,12,205,98,145,59,164,178,50,8,2,152,40,189,99,5,23,27,9,146,112,59,245,234,146,136,140,68,107,13,121,65,200,220,188,216,164,138,41,71,141,231,36,96,12,237,86,35,88,60,54,212,225,69,240,111,51,15,111,204,58,42,36,115,120,170,168,212,175,24,165,111,91,100,153,160,125,120,2,230,132,194,161,5,197,85,66,243,230,205,22,220,62,71,102,34,214,163,61,229,155,231,245,27,149,160,45,51,201,5,137,12,52,7,60,245,10,139,196,54,117,149,150,23,174,249,27,100,3,248,147,160,100,223,47,150,165,126,179,27,235,133,151,244,122,223,79,57,30,172,175,124,192,181,173,209,177,93,167,179,120,211,69,134,36,54,41,78,234,20,26,237,16,218,102,134,85,209,24,54,194,226,160,213,240,150,13,7,248,190,200,230,252,166,202,183,243,63,3,251,187,4,134,191,44,243,98,117,125,212,113,245,246,175,15,97,137,110,103,226,123,55,112,115,187,15,207,171,58,226,211,76,95,70,197,80,199,55,168,254,135,162,227,220,200,76,14,164,5,60,182,88,161,215,32,99,63,8,26,108,40,254,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0e17349a-19a3-44d5-b001-2f4514573b56"));
		}

		#endregion

	}

	#endregion

}

