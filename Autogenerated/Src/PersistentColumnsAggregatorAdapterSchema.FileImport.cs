namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PersistentColumnsAggregatorAdapterSchema

	/// <exclude/>
	public class PersistentColumnsAggregatorAdapterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PersistentColumnsAggregatorAdapterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PersistentColumnsAggregatorAdapterSchema(PersistentColumnsAggregatorAdapterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a19ab3c1-267e-4152-ae6e-61811f92503a");
			Name = "PersistentColumnsAggregatorAdapter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,221,84,77,75,195,64,16,61,43,248,31,134,120,169,80,146,123,173,129,90,63,232,65,41,148,122,223,110,166,233,66,50,27,246,67,40,226,127,119,146,148,180,169,77,170,224,201,75,178,251,120,243,118,222,204,236,146,200,209,22,66,34,220,207,95,22,122,237,194,169,166,181,74,189,17,78,105,10,159,84,134,179,188,208,198,93,93,126,92,93,94,120,171,40,133,197,214,58,204,153,154,101,40,75,158,13,159,145,208,40,121,219,112,246,122,6,25,101,252,218,96,202,92,152,102,194,218,17,204,209,88,197,58,228,88,199,231,100,231,70,75,180,86,155,73,34,10,135,166,10,42,252,42,83,18,100,25,243,61,100,146,166,44,42,92,19,3,163,62,210,16,102,93,129,124,20,251,227,239,62,77,182,229,140,151,204,41,179,173,242,168,25,81,20,193,88,209,134,13,187,68,75,136,226,6,181,62,207,133,217,54,192,212,160,112,104,65,177,150,32,46,179,94,131,219,22,200,76,68,144,6,215,119,193,121,87,1,31,17,54,103,68,199,135,140,11,97,68,14,196,189,188,11,188,69,195,169,83,221,152,32,94,242,30,100,3,132,227,168,98,159,14,38,77,199,217,52,93,177,65,220,27,91,252,48,112,215,209,243,174,7,203,150,21,104,59,27,150,90,23,179,71,242,57,26,177,202,112,60,123,237,204,62,134,94,103,39,180,58,201,49,116,27,189,169,116,70,176,18,22,7,71,233,158,201,160,79,21,62,224,243,159,77,222,31,13,65,79,193,15,170,118,141,148,212,151,186,125,195,95,208,109,116,114,230,114,215,149,234,124,55,130,232,208,207,187,86,9,76,146,100,80,191,153,143,228,148,219,130,58,216,240,19,84,237,106,61,46,79,249,107,131,111,34,243,220,161,253,122,55,158,7,148,7,180,78,81,245,68,67,178,95,247,76,202,239,109,236,6,112,208,93,200,26,109,131,140,125,1,87,137,213,156,84,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a19ab3c1-267e-4152-ae6e-61811f92503a"));
		}

		#endregion

	}

	#endregion

}

