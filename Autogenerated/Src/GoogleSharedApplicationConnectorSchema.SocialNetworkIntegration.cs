namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: GoogleSharedApplicationConnectorSchema

	/// <exclude/>
	public class GoogleSharedApplicationConnectorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GoogleSharedApplicationConnectorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GoogleSharedApplicationConnectorSchema(GoogleSharedApplicationConnectorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("052166b4-a428-48fe-9cd6-6ad37cc6b8ec");
			Name = "GoogleSharedApplicationConnector";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,81,203,106,195,48,16,60,59,224,127,88,232,37,185,216,247,212,13,52,57,132,30,2,161,254,2,69,94,59,2,91,50,43,41,165,148,252,123,55,146,237,54,78,161,23,129,118,30,59,26,105,209,161,237,133,68,216,30,15,165,169,93,182,51,186,86,141,39,225,148,209,89,105,164,18,109,186,248,74,23,137,183,74,55,19,111,111,76,211,98,137,116,65,98,141,70,233,12,61,167,11,38,62,17,54,44,6,217,10,107,215,48,48,207,130,176,122,237,251,86,201,224,61,137,130,166,247,39,6,162,228,95,5,172,97,43,236,124,57,187,112,76,62,167,0,7,116,103,83,113,132,99,112,143,96,158,231,80,88,223,117,130,62,55,227,224,29,157,39,109,65,26,205,16,18,40,93,27,234,194,90,16,39,227,29,52,33,20,216,144,10,196,79,172,108,114,205,231,182,5,69,223,13,135,124,240,205,138,124,132,111,252,161,129,248,246,145,255,198,116,216,163,251,125,95,174,224,246,29,73,114,17,52,164,154,53,1,47,160,241,99,172,241,30,91,174,248,147,88,28,87,255,173,207,30,54,6,205,117,104,23,117,21,11,14,247,56,189,31,94,191,1,98,8,160,159,88,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("052166b4-a428-48fe-9cd6-6ad37cc6b8ec"));
		}

		#endregion

	}

	#endregion

}

