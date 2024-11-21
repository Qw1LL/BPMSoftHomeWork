namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IndexingEntitySchema

	/// <exclude/>
	public class IndexingEntitySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IndexingEntitySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IndexingEntitySchema(IndexingEntitySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("63239894-55a3-454b-b98c-866936068d3b");
			Name = "IndexingEntity";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("eef27540-b1e9-466b-87b9-62933f9468f4");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,148,203,78,194,64,20,134,215,144,240,14,39,176,129,132,180,123,81,23,226,37,198,96,8,237,206,184,24,218,3,76,152,153,214,153,105,66,53,190,187,167,211,86,65,176,164,110,218,156,203,127,254,175,115,169,98,18,77,202,34,132,155,249,44,72,86,214,155,38,106,197,215,153,102,150,39,202,123,16,201,146,137,0,153,142,54,189,238,71,175,219,201,12,87,107,8,114,99,81,122,139,76,89,46,209,11,80,115,38,248,187,19,77,122,93,234,27,104,92,83,0,83,193,140,185,128,71,21,227,142,148,119,36,176,185,235,240,125,31,46,77,38,37,211,249,117,21,47,48,213,104,80,89,3,188,82,0,58,137,87,43,252,61,201,203,45,179,140,136,173,102,145,125,165,68,154,45,5,143,32,42,76,143,60,59,5,255,55,216,61,71,17,19,217,220,73,28,209,17,146,75,148,114,216,162,99,56,134,40,41,102,40,151,168,135,207,180,160,112,5,253,39,204,251,163,130,168,70,50,86,23,31,67,249,201,121,47,19,109,80,50,80,52,172,133,103,41,46,162,147,214,63,229,38,130,57,211,180,224,213,162,255,19,164,156,113,6,231,119,83,19,84,240,38,192,226,206,182,96,32,73,72,138,147,214,85,173,201,177,62,59,96,243,20,97,232,14,227,24,34,141,204,226,24,178,212,160,182,197,59,118,113,140,2,45,142,90,224,213,243,67,26,127,200,184,95,57,8,154,112,67,186,0,219,2,87,38,49,95,113,140,33,74,68,38,85,219,157,11,171,57,83,167,254,115,239,142,219,26,119,143,58,5,194,138,23,15,193,214,109,150,201,148,226,67,138,101,146,8,168,75,149,243,0,85,92,222,108,138,62,203,95,208,94,202,101,190,0,166,59,133,29,238,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("63239894-55a3-454b-b98c-866936068d3b"));
		}

		#endregion

	}

	#endregion

}

