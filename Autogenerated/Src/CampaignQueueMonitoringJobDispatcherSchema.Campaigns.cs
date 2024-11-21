namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignQueueMonitoringJobDispatcherSchema

	/// <exclude/>
	public class CampaignQueueMonitoringJobDispatcherSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignQueueMonitoringJobDispatcherSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignQueueMonitoringJobDispatcherSchema(CampaignQueueMonitoringJobDispatcherSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("47239ecf-12fc-4c08-a358-3dca5b05f858");
			Name = "CampaignQueueMonitoringJobDispatcher";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bac310da-8f6a-4932-87be-74eb3d9d7067");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,86,95,143,219,54,12,127,118,129,126,7,226,250,226,0,129,179,190,166,151,20,237,245,208,101,235,109,109,239,14,123,44,20,155,241,105,181,37,87,146,211,102,67,191,251,40,203,178,35,39,190,228,176,23,39,34,197,127,63,82,36,5,43,81,87,44,69,120,251,241,230,86,110,76,114,37,197,134,231,181,98,134,75,241,252,217,191,207,159,69,181,230,34,135,79,53,83,230,159,87,221,185,23,80,152,220,166,15,152,213,5,170,67,254,95,184,166,59,101,41,69,207,179,50,87,172,172,24,207,5,25,212,70,195,162,33,38,158,154,4,108,38,140,238,165,243,66,174,89,49,159,59,173,201,7,153,231,68,38,62,221,120,161,48,39,199,225,170,96,90,207,193,107,249,84,99,141,55,82,112,35,21,221,253,77,174,223,113,138,219,144,219,170,145,155,205,102,112,169,235,178,100,106,183,108,207,31,149,220,242,12,53,148,104,30,100,166,193,72,120,96,34,43,16,214,74,126,69,1,105,171,30,190,89,253,80,118,6,18,175,114,182,167,179,170,215,5,79,33,181,174,157,229,25,204,225,45,211,216,92,9,24,83,88,189,169,170,235,45,10,243,129,107,131,194,70,17,81,174,232,219,67,224,145,155,83,36,124,203,12,58,126,229,14,144,90,62,112,97,96,224,195,157,226,121,142,138,132,232,104,118,148,154,151,191,56,116,163,23,40,50,167,62,180,69,80,85,168,12,71,107,172,9,179,181,229,66,150,91,84,138,160,4,109,172,1,160,96,222,43,89,87,127,80,249,193,98,9,97,45,116,185,223,191,214,58,48,204,83,67,120,35,40,12,27,43,213,177,220,16,31,41,58,133,155,197,197,8,202,23,179,165,75,131,205,211,97,162,58,136,70,196,225,203,183,144,240,106,47,214,49,153,225,217,190,172,40,202,209,88,0,134,10,225,245,107,136,15,136,11,16,248,125,204,64,124,175,81,17,128,2,83,251,116,39,147,198,169,72,143,24,88,192,150,21,181,133,53,138,126,254,47,108,127,197,130,114,255,84,72,157,20,124,73,131,243,49,32,219,155,131,99,8,95,168,197,161,55,160,133,224,57,226,9,204,14,52,156,7,217,123,164,126,38,21,144,26,234,25,15,216,183,9,237,219,100,2,171,199,65,13,158,59,97,123,2,213,213,81,185,62,130,128,188,15,242,136,224,113,234,113,204,195,59,1,244,33,43,204,64,192,59,51,17,67,125,7,249,24,235,79,55,174,131,219,78,40,13,217,192,108,47,127,92,144,54,110,50,153,206,90,80,219,59,125,223,90,209,144,177,121,181,179,134,188,157,88,175,232,255,13,19,140,206,73,207,57,156,108,93,55,115,55,108,47,179,209,61,201,122,55,94,173,15,221,193,185,241,14,55,172,46,122,106,226,43,235,137,70,182,146,103,224,181,16,208,113,219,171,191,75,245,181,89,17,172,231,83,223,193,107,221,134,210,22,5,141,163,222,3,255,239,134,139,218,96,177,35,109,151,231,204,187,101,220,232,138,206,24,7,211,161,95,222,161,41,208,83,229,50,91,9,103,157,114,254,114,234,212,114,125,187,163,97,89,218,90,155,131,81,181,13,199,59,61,239,98,167,233,90,181,163,111,126,98,52,78,14,122,193,185,64,223,11,111,249,94,176,212,212,172,160,232,116,236,225,164,50,77,81,235,206,37,98,182,166,117,124,244,1,117,32,237,69,17,27,39,210,148,137,211,27,241,77,71,78,126,199,93,98,33,179,59,159,97,212,229,99,170,174,187,93,133,241,164,161,79,188,55,81,116,167,118,189,199,182,56,206,118,98,207,88,251,168,45,94,246,59,57,217,72,91,20,104,3,11,23,173,209,102,120,28,235,149,48,168,4,43,174,127,96,74,21,209,129,60,200,109,242,185,22,241,228,105,221,100,111,213,57,26,129,7,130,118,200,246,45,192,223,114,13,27,154,14,131,221,145,246,74,139,21,54,91,166,66,143,181,223,52,91,24,199,166,107,67,169,152,98,37,8,202,220,226,130,150,59,131,63,204,197,114,100,206,248,245,241,170,189,71,19,230,114,214,40,88,238,77,135,6,190,63,133,125,220,134,182,255,120,32,101,87,72,251,235,1,165,242,9,251,120,236,47,184,204,83,21,125,238,34,179,85,20,160,125,96,243,90,100,143,88,132,163,98,183,84,47,100,248,148,187,143,10,159,103,119,80,28,142,26,18,127,254,7,153,228,8,72,95,13,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateExecutionExceptionLocalizableString());
			LocalizableStrings.Add(CreateCreateJobErrorLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateExecutionExceptionLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("fe22e7df-a5c5-4b9d-824b-76db35cfd28d"),
				Name = "ExecutionException",
				CreatedInPackageId = new Guid("bac310da-8f6a-4932-87be-74eb3d9d7067"),
				CreatedInSchemaUId = new Guid("47239ecf-12fc-4c08-a358-3dca5b05f858"),
				ModifiedInSchemaUId = new Guid("47239ecf-12fc-4c08-a358-3dca5b05f858")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateCreateJobErrorLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("04db795e-fe79-4373-8e8e-a00606a0efa9"),
				Name = "CreateJobError",
				CreatedInPackageId = new Guid("bac310da-8f6a-4932-87be-74eb3d9d7067"),
				CreatedInSchemaUId = new Guid("47239ecf-12fc-4c08-a358-3dca5b05f858"),
				ModifiedInSchemaUId = new Guid("47239ecf-12fc-4c08-a358-3dca5b05f858")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("47239ecf-12fc-4c08-a358-3dca5b05f858"));
		}

		#endregion

	}

	#endregion

}

