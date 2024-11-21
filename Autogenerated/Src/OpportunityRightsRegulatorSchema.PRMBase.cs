namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OpportunityRightsRegulatorSchema

	/// <exclude/>
	public class OpportunityRightsRegulatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OpportunityRightsRegulatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OpportunityRightsRegulatorSchema(OpportunityRightsRegulatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1f85e969-5663-4fc5-857b-99942ce033c3");
			Name = "OpportunityRightsRegulator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6efc2b6b-5901-4b9d-a21e-e587e5c1977b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,84,77,111,218,64,16,61,59,82,254,195,40,185,128,20,153,123,190,164,20,209,136,3,5,133,38,215,106,187,30,214,43,217,179,214,126,64,221,40,255,189,203,46,24,236,128,68,139,122,177,52,179,59,239,205,123,59,99,98,37,154,138,113,132,47,179,201,92,45,108,58,84,180,144,194,105,102,165,162,203,139,247,203,139,196,25,73,2,230,181,177,88,222,53,241,174,160,44,21,29,202,107,60,156,77,71,100,165,149,104,210,39,83,19,159,86,24,217,204,95,94,79,199,100,81,47,124,247,235,74,95,123,173,81,248,3,24,22,204,152,91,152,86,149,210,214,145,180,245,139,20,185,53,47,40,92,193,172,210,225,246,96,48,128,123,227,202,146,233,250,113,19,135,74,88,229,146,231,128,191,144,59,139,6,212,150,17,22,74,3,207,25,137,117,143,58,96,130,79,171,29,81,10,91,228,193,30,116,229,126,22,146,3,15,232,159,218,10,178,154,222,224,22,198,65,113,61,90,34,217,182,102,143,229,95,196,127,27,173,95,37,22,153,23,59,211,114,201,44,198,195,42,6,48,55,85,132,234,232,135,31,186,157,136,254,37,215,72,89,196,109,147,76,208,230,234,40,203,82,201,12,38,140,152,192,61,109,83,45,24,201,223,161,237,72,223,59,42,235,73,11,3,76,11,87,250,35,211,135,245,212,37,73,183,201,52,114,68,148,3,240,13,64,156,152,122,156,221,4,156,164,123,48,84,133,43,233,141,21,206,15,213,51,218,239,117,133,89,8,239,159,157,204,30,123,87,51,166,45,161,30,103,87,253,79,24,211,34,251,7,152,254,122,184,147,143,147,156,91,249,154,255,97,217,30,238,97,99,206,112,44,128,159,235,87,3,210,191,131,173,95,167,76,101,88,175,141,181,113,213,130,179,163,184,193,189,87,131,218,255,215,8,121,216,98,215,10,111,224,76,143,225,1,8,87,71,119,173,215,165,235,122,59,231,57,150,236,155,255,19,199,25,73,78,89,165,93,87,199,106,246,30,187,115,121,51,132,29,91,99,182,157,244,185,63,131,194,182,147,34,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1f85e969-5663-4fc5-857b-99942ce033c3"));
		}

		#endregion

	}

	#endregion

}

