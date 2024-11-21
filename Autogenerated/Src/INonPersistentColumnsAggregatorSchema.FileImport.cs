namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INonPersistentColumnsAggregatorSchema

	/// <exclude/>
	public class INonPersistentColumnsAggregatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INonPersistentColumnsAggregatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INonPersistentColumnsAggregatorSchema(INonPersistentColumnsAggregatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("872298ee-2333-4faf-aa08-02b8773d99f5");
			Name = "INonPersistentColumnsAggregator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,142,65,10,194,64,12,69,215,22,122,135,64,183,210,3,184,179,5,97,22,74,193,19,140,53,29,6,218,164,36,233,170,120,119,163,214,149,46,243,121,239,255,80,156,80,231,216,35,52,221,249,202,131,213,45,211,144,211,34,209,50,83,125,202,35,134,105,102,177,178,88,203,98,87,9,38,207,33,144,161,12,238,29,32,180,60,46,19,105,39,220,163,42,75,89,56,56,47,183,49,247,144,191,28,132,11,83,135,162,89,13,201,54,231,152,146,23,70,99,1,47,250,67,108,165,123,8,77,84,252,177,124,104,133,199,123,176,66,186,127,158,123,157,158,61,1,204,204,19,34,219,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("872298ee-2333-4faf-aa08-02b8773d99f5"));
		}

		#endregion

	}

	#endregion

}

