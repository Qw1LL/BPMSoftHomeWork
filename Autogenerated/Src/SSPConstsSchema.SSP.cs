namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SSPConstsSchema

	/// <exclude/>
	public class SSPConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SSPConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SSPConstsSchema(SSPConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("baddafff-9580-40c5-a726-cdd52e87d9ee");
			Name = "SSPConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("39b1aa09-c30c-47e9-9379-18a9c48e3a0f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,146,77,111,194,32,28,135,207,54,233,119,32,158,182,3,190,180,180,213,152,29,104,11,139,135,69,179,110,31,128,181,232,72,42,52,64,53,110,217,119,31,86,55,231,14,187,184,4,72,128,223,255,225,9,208,26,33,215,160,216,27,203,55,51,223,243,61,201,54,220,52,172,228,32,93,62,20,106,101,7,153,146,43,177,110,53,179,66,73,223,123,247,189,94,211,190,212,162,4,198,186,181,18,148,53,51,6,20,197,210,37,141,53,110,223,101,220,216,27,14,193,35,95,11,99,143,181,128,111,152,168,129,59,169,169,153,229,64,84,92,90,177,18,92,15,14,233,75,168,230,172,82,178,222,131,251,86,84,23,24,114,160,60,157,32,243,10,220,1,201,119,93,236,166,143,163,60,39,40,139,97,146,135,83,136,146,96,4,49,118,211,9,33,73,26,198,4,211,20,247,111,103,223,114,27,33,43,208,56,253,157,210,213,85,126,165,218,114,189,95,158,80,127,57,34,148,101,120,146,34,24,77,243,0,34,66,66,152,146,8,193,28,37,148,208,56,11,147,32,61,59,206,229,86,216,107,175,239,12,249,23,49,191,83,195,149,187,189,227,171,40,13,86,174,43,189,102,82,188,29,109,93,179,175,28,52,74,91,86,31,42,254,18,188,96,81,165,23,63,72,11,185,236,24,238,147,118,177,103,41,236,47,243,152,78,49,141,71,1,12,113,224,204,163,40,131,233,40,138,97,144,209,49,10,208,152,78,81,248,101,254,225,123,174,125,2,118,10,74,165,248,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("baddafff-9580-40c5-a726-cdd52e87d9ee"));
		}

		#endregion

	}

	#endregion

}

