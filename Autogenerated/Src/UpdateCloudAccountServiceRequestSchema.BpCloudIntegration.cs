namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: UpdateCloudAccountServiceRequestSchema

	/// <exclude/>
	public class UpdateCloudAccountServiceRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UpdateCloudAccountServiceRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UpdateCloudAccountServiceRequestSchema(UpdateCloudAccountServiceRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("924fae82-030c-42fa-84b9-94064bc4d89e");
			Name = "UpdateCloudAccountServiceRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,145,65,79,194,64,16,133,207,144,240,31,38,112,209,75,123,23,36,193,106,8,81,76,3,241,100,60,44,219,105,221,216,238,214,157,169,73,37,254,119,167,45,40,162,7,188,180,153,55,111,223,126,51,107,85,129,84,42,141,112,21,47,215,46,229,32,114,54,53,89,229,21,27,103,131,232,102,189,116,9,230,52,232,111,7,253,94,69,198,102,176,174,137,177,16,103,158,163,110,108,20,204,209,162,55,122,124,236,89,85,150,77,129,193,90,186,42,55,239,109,170,184,196,55,242,152,73,1,81,174,136,46,224,161,76,20,99,148,187,42,153,105,237,228,156,156,121,51,26,87,248,90,33,113,123,38,12,67,152,80,85,20,202,215,211,93,189,194,210,35,161,101,2,223,89,129,29,84,109,28,80,151,65,224,82,224,103,4,213,69,7,251,172,240,32,236,241,90,177,146,241,217,43,205,79,34,148,213,38,55,26,116,3,120,2,95,79,54,36,223,175,193,98,239,74,244,108,80,166,139,219,168,174,127,60,68,43,204,81,248,157,23,96,249,55,164,179,120,1,47,88,55,164,191,81,59,214,37,22,27,244,103,247,242,134,112,9,67,85,154,91,172,135,231,13,250,158,157,216,55,175,49,107,91,176,133,12,121,220,220,49,134,143,255,192,232,102,236,239,101,138,206,18,75,144,138,233,96,165,39,130,238,115,126,162,222,25,226,201,110,167,11,155,186,41,236,10,250,139,123,132,54,233,246,220,214,157,250,83,20,237,19,160,24,112,105,223,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("924fae82-030c-42fa-84b9-94064bc4d89e"));
		}

		#endregion

	}

	#endregion

}

