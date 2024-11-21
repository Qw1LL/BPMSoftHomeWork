namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ThrottlingScheduleRequestSchema

	/// <exclude/>
	public class ThrottlingScheduleRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ThrottlingScheduleRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ThrottlingScheduleRequestSchema(ThrottlingScheduleRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9582f96f-5bbb-484d-b61c-0857214e30ce");
			Name = "ThrottlingScheduleRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,83,75,111,219,48,12,62,39,64,254,3,145,94,182,139,125,239,235,208,7,138,29,50,4,245,110,69,17,168,22,237,18,144,173,76,148,6,120,69,255,251,40,197,94,189,196,233,30,152,97,216,18,69,126,252,200,143,2,104,85,131,188,85,37,194,213,122,85,216,202,103,215,182,173,168,14,78,121,178,237,98,254,178,152,131,60,129,169,173,161,232,216,99,115,182,152,207,198,251,236,62,180,158,26,204,10,116,164,12,125,79,161,111,94,147,200,217,245,109,177,178,26,13,139,163,184,230,121,14,231,28,154,70,185,238,178,223,127,121,118,214,123,19,49,184,124,70,29,12,130,86,94,65,19,3,179,33,42,31,133,61,220,200,185,36,242,78,149,254,81,12,219,240,100,168,132,210,40,230,17,96,209,227,137,135,84,40,223,217,137,195,90,120,193,218,217,45,58,79,200,167,176,78,193,187,243,132,188,194,230,9,221,135,207,210,53,184,128,165,86,221,242,99,204,50,164,161,214,195,141,234,224,5,106,244,103,192,241,243,250,78,60,26,213,109,36,221,6,27,69,102,2,43,58,172,209,221,198,227,63,69,77,88,156,96,39,9,38,48,22,212,35,76,79,176,213,187,102,164,189,88,101,0,226,50,14,194,158,78,131,41,210,128,178,239,59,120,11,97,43,74,33,248,67,9,179,17,208,72,186,104,219,87,47,218,126,35,224,61,126,13,200,254,20,174,20,163,12,224,55,42,7,219,46,62,201,27,23,71,216,15,230,59,244,12,214,197,78,48,164,22,66,104,73,128,128,52,202,124,87,132,174,167,126,140,254,207,18,166,4,217,144,78,82,12,142,125,93,119,129,244,78,145,79,250,80,140,191,229,61,110,183,52,209,99,221,9,253,127,164,61,32,28,97,78,50,74,69,239,242,63,184,27,98,15,182,122,187,234,231,140,8,165,195,234,98,121,168,251,50,191,124,167,172,233,139,49,32,255,122,37,14,177,31,30,97,88,238,151,21,147,201,111,150,222,215,31,68,31,147,31,64,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9582f96f-5bbb-484d-b61c-0857214e30ce"));
		}

		#endregion

	}

	#endregion

}

