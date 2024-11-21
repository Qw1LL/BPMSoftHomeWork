namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BulkDuplicatesCountResponseSchema

	/// <exclude/>
	public class BulkDuplicatesCountResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BulkDuplicatesCountResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BulkDuplicatesCountResponseSchema(BulkDuplicatesCountResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1b8e96c8-ec0b-4b5d-87fb-133c37e8eac7");
			Name = "BulkDuplicatesCountResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3066e968-6ad0-45b5-bf2b-b9af469e0d31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,145,77,79,195,48,12,134,207,173,180,255,96,109,23,184,180,119,86,118,88,39,245,52,168,86,110,136,67,218,185,37,144,38,85,62,144,198,180,255,142,211,106,27,42,3,164,157,18,59,239,107,251,137,37,107,209,116,172,66,88,230,235,66,213,54,74,149,172,121,227,52,179,92,201,73,184,159,132,129,51,92,54,80,236,140,197,118,62,138,73,47,4,86,94,108,162,12,37,106,94,253,169,121,44,223,232,186,86,91,20,63,116,27,39,45,111,49,42,168,10,19,252,179,159,129,84,164,155,105,108,40,128,84,48,99,238,96,233,196,251,202,117,130,87,204,162,201,180,114,221,134,64,168,1,246,242,231,21,179,140,80,172,102,149,125,161,68,231,74,18,67,229,237,35,119,170,168,237,217,29,120,228,83,191,92,171,14,181,229,72,77,243,190,70,95,63,136,227,24,18,227,218,150,233,221,226,152,200,208,26,80,26,140,63,237,43,130,116,109,137,26,84,13,141,31,209,68,39,107,60,246,38,31,76,56,92,60,93,114,37,241,240,232,181,61,217,26,189,226,230,129,182,7,247,48,29,100,61,199,244,214,211,30,113,133,162,207,205,206,175,176,135,6,237,220,15,56,135,195,117,36,219,211,199,1,151,87,114,93,172,241,31,229,217,244,27,233,104,167,151,104,103,40,183,195,106,41,26,114,223,83,147,240,240,5,148,68,216,99,19,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b8e96c8-ec0b-4b5d-87fb-133c37e8eac7"));
		}

		#endregion

	}

	#endregion

}

