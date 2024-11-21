namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IPersistentColumnsAggregatorSchema

	/// <exclude/>
	public class IPersistentColumnsAggregatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPersistentColumnsAggregatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPersistentColumnsAggregatorSchema(IPersistentColumnsAggregatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("333054bb-29a4-4f0e-82ae-cc1b1c7cc202");
			Name = "IPersistentColumnsAggregator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,205,65,10,195,32,16,64,209,117,5,239,48,7,40,57,64,119,77,160,224,162,32,244,4,86,70,17,212,145,153,113,21,114,247,180,235,172,63,143,223,67,67,25,33,34,172,254,253,161,164,203,70,61,149,60,57,104,161,190,188,74,69,215,6,177,90,179,91,115,27,243,91,75,132,210,21,57,253,153,243,200,82,68,177,235,70,117,182,46,207,156,25,115,80,98,120,92,179,103,138,40,114,7,183,6,193,11,249,45,118,56,192,154,227,4,178,220,118,208,154,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("333054bb-29a4-4f0e-82ae-cc1b1c7cc202"));
		}

		#endregion

	}

	#endregion

}

