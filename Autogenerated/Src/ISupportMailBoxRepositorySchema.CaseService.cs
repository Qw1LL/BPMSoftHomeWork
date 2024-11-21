namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISupportMailBoxRepositorySchema

	/// <exclude/>
	public class ISupportMailBoxRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISupportMailBoxRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISupportMailBoxRepositorySchema(ISupportMailBoxRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8b7ac775-ccba-4dbf-ac65-c1caf69c4152");
			Name = "ISupportMailBoxRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77fa8847-960e-4748-ad77-e37bb90e03a0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,81,65,106,195,64,12,60,219,224,63,236,177,189,216,15,168,241,33,37,13,57,4,66,253,130,181,43,7,129,119,215,72,218,16,83,242,247,238,174,19,18,146,30,74,143,146,102,52,163,145,213,6,120,210,61,168,213,126,215,186,65,202,119,103,7,60,120,210,130,206,22,249,119,145,103,158,209,30,84,59,179,128,121,123,168,3,126,28,161,143,96,46,55,96,129,176,191,97,110,75,9,202,181,21,20,4,14,227,0,168,170,74,213,236,141,209,52,55,151,122,79,238,136,95,192,202,117,162,209,198,13,110,80,236,167,201,145,40,163,113,236,220,9,184,188,210,171,59,254,228,187,17,123,133,86,128,134,120,208,182,93,120,187,64,91,185,211,39,76,142,81,28,205,1,28,175,122,114,144,26,27,16,254,93,241,89,50,75,29,2,241,100,185,185,200,221,145,234,234,58,139,224,237,218,122,3,164,187,17,234,20,197,220,68,181,104,47,193,95,94,151,96,150,173,127,241,165,6,114,70,113,250,131,98,16,9,129,253,195,233,131,79,22,138,193,223,172,125,4,149,229,217,237,162,145,156,102,231,34,63,255,0,94,45,102,201,63,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8b7ac775-ccba-4dbf-ac65-c1caf69c4152"));
		}

		#endregion

	}

	#endregion

}

