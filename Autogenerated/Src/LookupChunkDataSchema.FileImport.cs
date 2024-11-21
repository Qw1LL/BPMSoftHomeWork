namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LookupChunkDataSchema

	/// <exclude/>
	public class LookupChunkDataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LookupChunkDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LookupChunkDataSchema(LookupChunkDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c8fe945c-3ca6-454e-abfa-54dbb19e8a55");
			Name = "LookupChunkData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,141,65,10,131,48,16,69,215,21,188,67,78,224,5,186,171,165,80,168,32,181,116,63,198,177,13,38,153,152,204,172,74,239,94,197,186,81,152,213,127,239,49,30,28,166,0,26,213,169,174,26,234,185,40,201,247,230,37,17,216,144,47,46,198,226,213,5,138,156,103,159,60,59,4,105,173,209,74,91,72,73,221,136,6,9,229,91,252,112,6,134,9,207,202,234,44,244,9,86,48,61,168,142,164,49,165,10,29,122,38,181,153,27,6,198,227,46,254,83,236,22,125,141,55,243,46,110,137,236,252,193,116,19,184,227,40,38,98,87,146,21,231,211,236,125,243,108,186,31,250,175,43,22,251,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c8fe945c-3ca6-454e-abfa-54dbb19e8a55"));
		}

		#endregion

	}

	#endregion

}

