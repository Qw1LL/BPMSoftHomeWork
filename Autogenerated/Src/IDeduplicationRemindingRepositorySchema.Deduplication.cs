namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IDeduplicationRemindingRepositorySchema

	/// <exclude/>
	public class IDeduplicationRemindingRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDeduplicationRemindingRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDeduplicationRemindingRepositorySchema(IDeduplicationRemindingRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("de0d4303-7aff-4f8a-be80-67a2241441e9");
			Name = "IDeduplicationRemindingRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,65,110,194,48,16,69,215,32,113,135,81,86,173,132,146,3,148,102,81,216,116,209,10,37,234,1,76,60,9,70,181,29,141,109,36,84,113,247,142,67,0,35,80,213,157,103,60,243,253,254,151,141,208,232,122,209,32,188,173,63,106,219,250,124,105,77,171,186,64,194,43,107,242,21,202,208,127,171,102,168,102,211,159,217,116,18,156,50,93,50,78,248,50,155,114,191,40,10,88,184,160,181,160,67,57,214,107,178,123,37,209,129,70,191,181,18,90,75,160,133,17,93,148,144,169,54,16,106,101,36,247,93,126,22,43,18,181,62,108,120,20,148,241,72,109,228,125,191,65,171,206,219,21,246,214,41,111,233,192,75,17,247,142,107,104,44,9,133,103,174,225,213,129,102,115,128,78,237,49,1,97,64,215,144,234,163,254,28,92,216,236,176,241,32,140,188,37,63,75,186,102,139,90,128,225,68,163,131,123,11,167,78,47,72,232,97,234,53,11,14,137,243,54,172,203,66,89,249,197,53,52,151,70,190,40,134,233,199,203,23,206,213,21,51,43,171,71,244,255,20,170,79,22,83,145,209,245,223,2,39,231,159,124,206,202,58,73,33,93,218,91,37,199,212,47,234,79,209,239,213,63,220,198,193,145,123,138,12,143,140,222,95,142,240,243,248,216,100,188,188,130,61,243,31,157,28,227,63,61,254,2,252,249,210,48,243,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("de0d4303-7aff-4f8a-be80-67a2241441e9"));
		}

		#endregion

	}

	#endregion

}

