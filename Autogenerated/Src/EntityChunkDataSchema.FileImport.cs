namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EntityChunkDataSchema

	/// <exclude/>
	public class EntityChunkDataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EntityChunkDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EntityChunkDataSchema(EntityChunkDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2514f3cc-6ad8-4976-a835-7cf0143ff738");
			Name = "EntityChunkData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,144,61,79,195,48,16,134,231,86,234,127,56,181,11,44,249,1,20,24,8,1,117,40,138,200,192,80,49,56,238,53,181,240,151,252,49,148,138,255,206,57,166,145,74,91,196,226,200,231,247,185,231,114,154,41,244,150,113,132,135,122,217,152,77,40,74,163,55,162,139,142,5,97,116,241,36,36,46,148,53,46,76,198,251,201,120,20,189,208,29,52,59,31,80,205,127,221,9,149,18,121,226,124,241,140,26,157,224,39,153,215,168,131,80,88,52,244,202,164,248,236,53,148,162,220,204,97,71,23,128,82,50,239,111,160,162,100,216,149,219,168,63,30,89,96,125,102,53,112,173,196,119,42,216,216,74,193,129,39,228,148,24,209,204,116,14,173,107,103,44,186,32,144,218,215,61,153,223,87,41,190,68,213,162,187,122,161,149,192,29,76,49,53,163,228,244,58,121,14,162,69,165,163,66,151,244,183,121,49,89,74,48,1,230,62,207,64,24,236,161,195,48,7,159,142,175,203,26,31,57,71,239,105,178,244,193,245,207,63,24,218,211,177,89,232,0,205,229,240,127,125,246,192,190,137,176,173,156,51,238,79,227,160,58,23,63,231,156,161,94,231,109,247,247,92,61,46,82,237,27,157,84,71,242,120,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2514f3cc-6ad8-4976-a835-7cf0143ff738"));
		}

		#endregion

	}

	#endregion

}

