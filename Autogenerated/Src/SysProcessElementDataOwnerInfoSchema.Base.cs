namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SysProcessElementDataOwnerInfoSchema

	/// <exclude/>
	public class SysProcessElementDataOwnerInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysProcessElementDataOwnerInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysProcessElementDataOwnerInfoSchema(SysProcessElementDataOwnerInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6f11982c-9819-47d8-bc8d-e74e12e283ba");
			Name = "SysProcessElementDataOwnerInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,145,77,107,195,48,12,134,207,9,228,63,8,122,111,238,235,216,97,93,41,57,108,13,228,23,120,177,156,25,252,17,108,133,16,74,255,251,252,209,142,178,141,117,108,23,97,75,242,251,62,146,13,211,232,71,214,35,60,182,207,157,21,180,222,90,35,228,48,57,70,210,154,170,60,86,101,49,121,105,6,232,22,79,168,55,85,25,50,43,135,67,40,195,86,49,239,239,98,169,117,182,71,239,119,10,53,26,122,98,196,14,179,65,215,24,97,211,139,186,174,225,222,79,90,51,183,60,156,239,29,89,135,30,100,232,113,58,249,129,193,168,18,122,128,44,244,111,204,12,8,54,10,129,21,48,102,15,192,108,2,60,184,172,47,218,245,149,248,56,189,42,217,67,31,233,110,194,21,97,196,16,63,102,10,205,35,58,146,24,6,107,147,80,174,127,158,32,37,26,30,4,165,144,25,48,158,105,137,72,95,153,46,80,251,73,114,216,165,198,134,195,17,6,164,13,248,24,78,55,124,132,164,179,143,85,252,219,101,228,85,253,194,255,160,120,222,192,95,9,12,206,255,35,120,193,249,7,130,21,26,158,191,35,221,115,246,58,89,84,229,233,29,227,235,21,61,188,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6f11982c-9819-47d8-bc8d-e74e12e283ba"));
		}

		#endregion

	}

	#endregion

}

