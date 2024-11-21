namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ImportDataChunkSchema

	/// <exclude/>
	public class ImportDataChunkSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImportDataChunkSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImportDataChunkSchema(ImportDataChunkSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fd201402-92ae-464e-8ec8-0ef3cbe29b35");
			Name = "ImportDataChunk";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,203,78,194,64,20,134,215,144,240,14,39,184,53,52,234,78,74,23,34,26,18,77,72,218,157,113,49,180,135,58,161,157,105,230,178,168,132,119,119,46,45,152,130,80,55,147,244,204,127,230,255,206,165,140,148,40,43,146,34,60,173,222,99,190,81,147,57,103,27,154,107,65,20,229,108,242,66,11,92,150,21,23,106,52,220,141,134,3,45,41,203,33,174,165,194,114,58,26,154,200,141,192,220,40,97,193,116,249,8,94,59,255,210,108,27,43,162,208,73,42,189,46,104,10,104,20,103,4,3,251,238,32,225,43,193,83,148,18,102,112,119,107,35,75,118,140,220,187,72,243,141,153,137,60,152,192,222,3,32,203,60,195,101,158,164,174,46,226,248,123,79,243,198,249,86,87,7,148,5,83,84,213,150,227,154,235,188,32,82,182,182,207,68,17,247,180,147,4,65,0,161,212,101,73,68,29,53,223,238,22,248,6,50,35,5,234,178,38,173,54,232,136,67,101,8,43,34,72,9,204,140,109,54,78,198,81,24,28,130,86,246,17,163,160,164,160,223,100,93,224,231,177,214,212,98,117,169,194,36,106,235,109,241,77,135,43,20,138,162,169,97,229,82,29,250,9,187,11,196,102,22,54,105,153,217,10,142,240,167,244,45,198,171,166,89,67,209,36,155,220,29,228,168,166,32,237,177,255,211,204,119,202,91,117,154,117,197,207,101,246,246,113,75,9,105,59,23,239,2,151,109,186,59,13,254,236,103,104,199,1,118,136,125,155,216,89,89,112,199,63,188,122,218,36,94,221,121,216,45,203,175,213,63,251,55,236,127,0,59,100,10,160,86,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fd201402-92ae-464e-8ec8-0ef3cbe29b35"));
		}

		#endregion

	}

	#endregion

}

