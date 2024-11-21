namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: UserReportGenerationTaskSchema

	/// <exclude/>
	public class UserReportGenerationTaskSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UserReportGenerationTaskSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UserReportGenerationTaskSchema(UserReportGenerationTaskSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bd121194-abe4-482b-9424-0b625f81bd05");
			Name = "UserReportGenerationTask";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,81,177,110,194,48,16,157,131,196,63,156,196,2,18,34,123,104,59,148,1,49,180,138,74,59,85,29,76,114,73,79,77,236,232,124,30,40,234,191,215,118,82,90,42,144,88,108,233,249,189,123,239,157,181,106,209,118,170,64,184,207,31,182,166,146,197,202,232,138,106,199,74,200,232,241,232,48,30,37,206,146,174,97,187,183,130,237,114,60,242,200,132,177,246,207,176,106,148,181,25,188,88,228,39,236,12,203,26,53,246,210,103,101,63,34,247,117,139,76,170,161,79,181,107,240,205,3,157,219,53,84,64,17,180,23,165,144,193,249,137,137,79,228,207,223,8,70,91,97,87,136,97,159,36,143,179,123,198,224,115,201,97,58,131,80,46,249,186,142,125,54,164,248,99,14,107,71,37,56,47,220,148,179,48,42,201,96,167,44,78,195,235,34,240,54,229,60,82,23,253,144,71,191,244,193,60,9,126,155,18,110,7,189,95,239,49,209,4,117,217,151,60,109,156,179,233,144,133,240,95,223,52,77,225,198,186,182,85,188,191,251,1,214,40,22,12,131,13,183,210,64,37,106,161,138,144,193,84,209,20,228,93,9,144,38,137,191,132,192,49,36,212,199,170,125,246,163,69,250,215,99,88,91,92,193,208,229,224,165,178,12,142,75,56,95,165,71,79,65,143,125,3,235,177,156,252,141,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bd121194-abe4-482b-9424-0b625f81bd05"));
		}

		#endregion

	}

	#endregion

}

