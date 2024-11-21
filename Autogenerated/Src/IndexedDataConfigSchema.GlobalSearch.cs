namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IndexedDataConfigSchema

	/// <exclude/>
	public class IndexedDataConfigSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IndexedDataConfigSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IndexedDataConfigSchema(IndexedDataConfigSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5326868b-e6e3-4b52-8fc8-2345a24cdc02");
			Name = "IndexedDataConfig";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("30c103fe-34c6-441e-895c-acadc354f737");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,144,203,10,194,48,16,69,215,22,250,15,129,110,165,31,80,197,133,10,210,133,32,116,41,46,166,233,88,3,233,164,36,41,88,196,127,119,98,236,194,23,204,102,134,195,189,135,33,232,208,245,32,81,172,15,251,202,156,125,190,49,116,86,237,96,193,43,67,249,78,155,26,116,133,96,229,37,77,110,105,50,27,156,162,86,84,163,243,216,49,172,53,202,64,186,124,135,132,86,201,69,154,48,149,89,108,249,42,54,26,156,43,68,73,13,94,177,217,130,135,152,207,8,79,63,212,90,73,33,3,244,205,136,66,108,213,51,28,236,184,116,222,114,241,124,194,170,88,27,201,21,103,5,183,123,140,205,144,154,216,255,218,127,202,188,37,252,247,249,196,66,207,4,70,167,227,73,148,45,25,139,13,191,99,232,200,241,11,130,202,183,9,31,31,117,249,21,155,113,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5326868b-e6e3-4b52-8fc8-2345a24cdc02"));
		}

		#endregion

	}

	#endregion

}

