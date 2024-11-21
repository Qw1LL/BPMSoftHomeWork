namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: UpdateUserSettingsRequestSchema

	/// <exclude/>
	public class UpdateUserSettingsRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UpdateUserSettingsRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UpdateUserSettingsRequestSchema(UpdateUserSettingsRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("83429a60-95f6-4bbb-baae-d29f929fc531");
			Name = "UpdateUserSettingsRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,77,79,194,64,16,134,207,146,240,31,38,112,80,47,237,157,15,19,62,140,38,6,67,168,196,131,241,48,148,1,54,180,221,186,51,171,65,226,127,119,187,5,140,128,31,92,154,204,236,188,207,206,251,118,51,76,137,115,140,9,186,195,65,164,103,18,244,116,54,83,115,107,80,148,206,130,222,117,52,208,83,74,184,90,89,87,43,213,202,153,101,149,205,33,90,177,80,26,140,108,38,42,165,32,34,163,48,81,239,94,211,244,115,117,67,115,87,64,47,65,230,6,140,243,41,10,141,153,76,68,34,14,193,35,122,177,196,226,135,195,48,132,22,219,52,69,179,186,218,212,94,8,51,109,192,148,147,32,26,172,199,0,198,177,118,87,159,51,88,71,4,222,32,131,45,42,220,99,181,152,8,19,214,16,27,154,181,107,127,88,13,186,200,228,44,189,170,152,54,91,214,32,44,88,79,125,20,116,42,49,24,203,179,107,228,118,146,168,24,98,191,235,143,30,161,1,135,72,167,46,19,221,69,53,52,58,39,35,138,92,94,67,15,46,207,247,211,241,141,27,18,6,237,189,51,200,130,224,141,38,176,208,122,9,152,231,78,234,61,193,84,167,168,178,34,151,195,96,202,206,43,38,150,118,229,195,191,65,95,58,31,202,128,210,9,153,139,123,247,156,160,13,53,199,184,117,136,78,158,247,189,176,118,89,164,181,141,139,197,20,143,232,113,111,8,214,48,39,105,22,150,154,240,113,138,119,180,238,235,158,226,102,217,37,173,78,179,252,171,254,119,167,133,244,142,86,71,13,118,202,179,99,190,234,148,77,203,223,238,235,178,251,189,233,122,159,6,160,207,187,158,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("83429a60-95f6-4bbb-baae-d29f929fc531"));
		}

		#endregion

	}

	#endregion

}

