namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: UidSinceSyncStrategySchema

	/// <exclude/>
	public class UidSinceSyncStrategySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UidSinceSyncStrategySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UidSinceSyncStrategySchema(UidSinceSyncStrategySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ea1a0baf-434e-4325-bd23-753efc693955");
			Name = "UidSinceSyncStrategy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,83,205,143,154,64,20,63,99,226,255,240,66,47,154,24,232,217,174,30,180,219,100,15,110,108,136,167,166,135,17,30,116,82,152,33,111,30,141,100,227,255,222,55,160,46,90,182,23,96,222,188,175,223,7,70,85,232,106,149,34,108,246,187,196,230,28,237,148,46,167,147,183,233,36,104,156,54,197,45,190,181,38,215,69,67,138,181,53,95,70,174,9,199,163,209,179,97,205,26,221,7,215,223,84,202,150,250,123,201,248,68,88,200,4,216,150,202,185,37,28,116,150,104,147,98,210,154,52,97,153,142,69,219,229,197,113,12,79,174,169,42,69,237,250,118,70,132,148,48,95,133,47,195,130,48,94,131,174,234,18,43,52,172,52,91,179,128,12,75,253,7,9,51,200,201,86,195,82,25,185,81,14,179,135,14,209,117,72,252,56,149,80,142,191,221,245,60,86,15,141,4,128,45,56,44,49,101,80,101,9,194,188,83,5,58,208,38,195,147,188,187,69,132,32,81,195,201,162,144,73,233,251,212,193,148,31,95,49,87,77,201,27,169,20,62,103,220,214,104,243,217,29,230,249,2,94,69,92,88,65,56,198,97,56,255,41,141,234,230,88,234,20,82,207,245,40,213,176,28,133,35,165,226,16,121,222,228,218,147,173,145,184,93,250,47,22,136,152,245,9,143,58,117,129,4,21,165,191,0,79,53,9,9,190,158,81,244,185,224,253,151,230,160,190,54,5,43,162,145,206,132,34,38,239,165,131,113,178,216,206,21,125,207,239,13,82,11,222,190,65,80,32,95,190,2,66,110,200,64,152,188,188,110,159,225,237,243,57,244,110,12,130,179,127,158,47,80,208,100,61,154,123,104,226,124,153,213,120,151,138,33,247,29,101,255,193,22,249,196,15,96,116,145,90,145,170,192,136,56,171,80,108,65,210,223,8,54,25,21,174,15,114,134,244,22,136,158,226,46,123,61,90,236,129,39,200,44,52,184,112,61,112,176,255,135,143,246,212,41,118,189,247,191,128,224,80,34,240,93,215,139,5,198,196,159,249,109,222,183,243,30,30,28,23,208,253,216,45,12,215,152,119,172,46,225,40,142,153,61,230,223,37,246,202,140,83,223,71,135,193,96,58,57,255,5,83,99,233,246,172,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ea1a0baf-434e-4325-bd23-753efc693955"));
		}

		#endregion

	}

	#endregion

}

