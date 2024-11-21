namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BulkDuplicatesGroupResponseSchema

	/// <exclude/>
	public class BulkDuplicatesGroupResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BulkDuplicatesGroupResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BulkDuplicatesGroupResponseSchema(BulkDuplicatesGroupResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eb44fa4e-3083-461b-a753-81b61ff52720");
			Name = "BulkDuplicatesGroupResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3066e968-6ad0-45b5-bf2b-b9af469e0d31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,84,203,110,194,48,16,60,131,212,127,88,193,165,149,42,184,3,229,64,168,16,7,218,138,28,171,30,76,178,68,110,29,27,249,209,42,69,252,123,55,142,120,36,188,66,47,78,236,204,172,199,179,158,72,150,162,89,177,8,97,244,54,11,213,210,118,2,37,151,60,113,154,89,174,228,93,115,125,215,108,56,195,101,2,97,102,44,166,253,202,156,240,66,96,148,131,77,103,130,18,53,143,46,98,94,23,159,244,58,83,49,138,35,220,220,73,203,83,236,132,84,133,9,254,235,53,16,138,112,109,141,9,77,32,16,204,152,30,140,156,248,122,38,176,205,2,193,81,218,177,91,9,30,49,139,102,162,149,91,121,202,251,152,89,70,199,177,154,69,246,131,22,86,110,65,32,136,242,18,215,42,64,15,46,214,111,228,198,52,186,221,46,12,140,75,83,166,179,225,118,97,26,19,129,47,57,106,80,75,72,114,124,103,7,238,30,162,189,194,25,166,11,212,247,47,212,9,120,130,150,199,79,227,214,67,174,120,43,89,226,15,76,28,143,193,239,62,141,97,13,9,218,62,152,124,216,248,211,214,209,98,148,211,212,234,124,201,102,55,104,42,120,133,31,85,105,94,86,88,2,212,86,23,40,106,120,46,44,222,217,11,92,222,108,217,158,237,11,150,245,9,69,247,107,223,190,98,203,186,2,195,67,195,182,143,111,38,28,154,127,218,87,22,55,230,62,21,68,30,24,171,41,9,143,160,124,62,134,37,75,79,232,45,198,54,202,184,8,198,185,144,84,46,238,156,210,78,41,196,154,1,25,159,102,83,56,206,124,185,24,140,253,111,96,23,140,91,108,44,8,199,193,216,151,29,92,9,245,176,200,143,169,250,121,210,205,205,31,107,26,1,210,28,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb44fa4e-3083-461b-a753-81b61ff52720"));
		}

		#endregion

	}

	#endregion

}

