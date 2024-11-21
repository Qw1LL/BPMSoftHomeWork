namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BulkEmailMacroInfoSchema

	/// <exclude/>
	public class BulkEmailMacroInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BulkEmailMacroInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BulkEmailMacroInfoSchema(BulkEmailMacroInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dd908fae-7593-41a7-85f2-5a9b52456b8d");
			Name = "BulkEmailMacroInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7b5cce97-2e1e-4b17-90ca-f9813022e3eb");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,144,79,107,195,48,12,197,207,45,244,59,8,122,111,118,222,198,160,45,59,236,16,26,210,177,187,234,42,153,169,255,4,75,46,27,165,223,125,142,211,192,216,198,200,69,88,178,223,123,63,203,161,37,238,80,17,108,170,114,239,27,89,109,189,107,116,27,3,138,246,110,49,191,44,230,179,162,40,224,145,163,181,24,62,159,110,125,77,93,32,38,39,12,242,78,112,68,65,80,222,73,64,37,208,248,0,135,104,78,64,22,181,1,139,42,120,56,163,137,4,140,103,237,218,213,232,90,124,179,237,226,193,104,5,202,32,51,108,146,252,185,87,151,189,248,197,53,62,189,72,48,169,206,150,129,218,4,7,85,240,29,5,209,196,247,80,101,241,112,255,147,55,15,178,15,3,26,141,12,70,159,8,202,245,182,222,237,239,122,150,223,48,35,13,75,72,188,176,206,178,11,180,36,15,192,125,185,254,147,181,11,186,213,14,199,159,11,125,164,157,4,111,211,201,118,6,133,38,101,102,226,215,94,59,53,183,38,142,70,110,155,246,205,16,63,41,235,45,75,254,200,89,146,59,14,235,206,125,154,94,191,0,156,130,15,22,52,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dd908fae-7593-41a7-85f2-5a9b52456b8d"));
		}

		#endregion

	}

	#endregion

}

