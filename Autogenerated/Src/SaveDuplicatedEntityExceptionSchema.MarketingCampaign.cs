namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SaveDuplicatedEntityExceptionSchema

	/// <exclude/>
	public class SaveDuplicatedEntityExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SaveDuplicatedEntityExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SaveDuplicatedEntityExceptionSchema(SaveDuplicatedEntityExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b337a224-56ad-46fe-b05d-92c5ffd63b6b");
			Name = "SaveDuplicatedEntityException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,81,203,110,194,48,16,60,131,196,63,172,232,133,94,146,59,165,28,74,57,244,128,132,68,127,96,113,54,193,42,177,45,123,211,52,69,252,123,215,78,40,125,72,92,44,237,104,103,118,102,108,176,166,224,80,17,60,109,55,59,91,114,182,178,166,212,85,227,145,181,53,217,6,253,27,177,54,213,10,107,135,186,50,147,241,105,50,30,53,65,32,216,117,129,169,126,152,140,5,185,243,84,9,1,86,71,12,97,14,59,124,167,231,198,29,181,66,166,98,109,88,115,183,254,80,228,162,106,34,228,121,14,139,208,212,53,250,110,57,204,223,27,192,7,111,219,0,237,129,12,20,23,29,160,164,3,236,187,120,158,45,104,19,200,115,118,145,203,127,232,185,102,47,44,80,209,207,109,59,48,191,30,22,162,228,147,247,26,200,154,192,190,81,108,189,228,218,38,213,126,227,111,130,4,188,24,205,26,143,250,147,2,32,24,106,163,71,70,35,13,219,82,98,209,208,90,118,61,175,146,197,86,243,65,24,193,145,210,165,166,2,200,123,235,65,190,39,96,69,49,226,255,140,61,226,208,99,13,70,126,242,113,58,172,79,151,175,114,105,24,228,42,50,20,20,148,215,123,177,21,77,36,241,108,145,39,110,146,26,250,186,217,212,76,154,136,205,15,194,247,145,55,26,205,97,143,129,102,23,16,78,112,30,42,36,83,244,45,166,185,71,127,131,231,47,156,95,45,179,129,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b337a224-56ad-46fe-b05d-92c5ffd63b6b"));
		}

		#endregion

	}

	#endregion

}

