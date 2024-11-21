namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DateBasedSentSinceSyncStrategySchema

	/// <exclude/>
	public class DateBasedSentSinceSyncStrategySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateBasedSentSinceSyncStrategySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateBasedSentSinceSyncStrategySchema(DateBasedSentSinceSyncStrategySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("15be1ecd-0b88-4e9e-b6d5-d613f5e51e4e");
			Name = "DateBasedSentSinceSyncStrategy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,219,110,219,48,12,125,118,129,254,3,225,189,116,64,22,239,57,107,3,172,137,7,20,88,130,108,78,62,64,177,25,79,152,45,25,20,61,212,40,242,239,163,236,92,156,212,203,94,108,145,226,229,240,240,200,168,18,93,165,82,132,231,213,34,177,59,30,47,148,46,238,239,222,238,239,130,218,105,147,159,252,51,107,118,58,175,73,177,182,230,203,192,53,225,176,119,28,27,214,172,209,201,181,4,124,32,204,165,2,204,10,229,220,4,230,138,241,89,57,204,18,52,156,104,147,98,210,152,52,97,233,131,121,211,102,68,81,4,143,174,46,75,69,205,244,100,35,66,74,184,123,10,95,250,9,97,52,5,93,86,5,150,82,78,105,182,102,4,25,22,250,15,18,102,176,35,91,246,83,207,205,47,75,140,143,93,162,235,182,132,98,254,118,71,251,54,122,168,229,6,216,130,195,2,83,6,85,20,96,44,127,202,72,237,120,212,29,229,134,37,72,182,224,84,142,110,116,40,44,44,202,78,156,84,133,76,106,157,1,245,0,84,245,182,208,41,164,158,200,255,33,233,19,125,193,111,32,155,150,239,105,45,43,178,21,18,55,19,127,98,65,141,89,23,112,189,133,214,145,160,162,244,23,224,107,69,50,128,207,103,20,246,15,136,223,115,24,84,199,162,96,101,37,164,51,25,146,201,75,102,99,156,0,91,184,188,171,249,163,70,106,192,203,48,8,114,228,195,41,32,228,154,12,132,155,229,252,231,215,111,107,144,127,252,61,94,199,115,72,226,229,58,121,89,206,98,120,251,188,15,189,20,131,96,239,191,251,195,128,104,178,110,198,203,129,69,215,130,160,78,217,146,200,113,213,114,122,99,226,25,161,76,231,134,85,52,68,125,171,72,105,161,196,255,15,82,90,79,165,72,149,96,228,61,62,133,162,27,18,92,70,152,18,136,225,116,35,54,164,39,199,248,49,106,163,135,147,157,111,142,204,66,170,11,167,61,156,254,101,111,237,107,11,238,120,223,7,215,175,122,208,214,237,209,30,60,174,51,78,47,247,158,57,130,246,225,55,208,7,244,177,221,203,4,182,82,244,225,58,254,34,176,219,248,240,242,58,111,223,185,255,11,191,207,148,12,201,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("15be1ecd-0b88-4e9e-b6d5-d613f5e51e4e"));
		}

		#endregion

	}

	#endregion

}

