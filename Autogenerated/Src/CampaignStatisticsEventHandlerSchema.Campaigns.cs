namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CampaignStatisticsEventHandlerSchema

	/// <exclude/>
	public class CampaignStatisticsEventHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CampaignStatisticsEventHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CampaignStatisticsEventHandlerSchema(CampaignStatisticsEventHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("056a2c31-7878-4573-8dca-ecafe4c5fd1b");
			Name = "CampaignStatisticsEventHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,86,75,111,219,56,16,62,171,64,255,3,225,189,72,64,160,116,175,109,183,128,227,58,109,128,188,80,59,237,161,232,129,161,198,50,177,18,169,229,35,137,83,228,191,239,240,33,201,15,217,73,177,64,177,23,91,34,103,190,153,249,62,14,71,130,214,160,27,202,128,156,92,95,204,228,194,228,19,41,22,188,180,138,26,46,197,235,87,63,95,191,74,172,230,162,36,179,149,54,80,191,235,222,123,7,5,249,216,24,197,111,173,1,189,199,96,66,235,134,242,82,228,211,59,16,230,51,21,69,5,106,143,237,199,147,103,64,112,27,13,254,80,80,98,142,100,82,81,173,223,146,118,115,61,128,183,59,62,62,38,239,181,173,107,170,86,31,226,59,86,105,40,23,154,212,96,150,178,208,196,72,66,153,177,180,226,143,64,88,132,34,218,32,13,218,112,166,73,97,149,203,167,219,2,23,70,231,45,254,241,90,128,198,222,86,156,17,13,180,130,130,48,151,94,151,221,172,67,92,207,147,12,167,127,66,53,28,145,179,43,209,123,203,102,99,97,250,0,204,58,165,230,160,106,46,168,1,140,143,154,225,111,207,143,20,88,7,38,251,150,92,43,126,231,109,220,126,19,94,8,115,251,88,170,175,111,90,65,221,39,112,137,199,131,252,69,4,254,201,69,122,184,134,236,221,94,208,214,113,78,111,43,24,198,124,129,247,53,85,24,147,55,88,202,1,160,53,43,135,233,137,0,81,4,46,54,137,185,86,178,1,180,6,199,140,215,236,176,253,69,56,43,123,104,156,65,5,204,144,79,96,230,210,208,106,32,31,61,145,86,152,96,151,102,196,181,86,146,220,81,133,39,197,187,98,45,112,31,113,210,27,13,10,149,19,248,140,177,51,111,155,36,216,7,149,173,69,122,106,5,203,61,92,58,58,43,70,89,220,207,79,149,172,211,67,132,181,134,223,150,160,32,29,181,166,14,35,63,211,211,127,176,3,210,16,35,71,119,116,48,160,122,225,217,18,106,154,79,133,225,102,117,86,100,25,161,58,230,235,229,75,66,33,249,172,1,198,23,171,75,121,46,217,223,159,57,86,158,6,125,19,5,198,42,236,171,222,231,105,31,139,95,128,98,184,98,190,132,79,146,86,191,68,227,139,53,24,72,42,31,139,34,29,185,35,110,181,99,37,242,245,44,55,93,151,229,3,81,99,45,174,144,22,121,135,188,45,34,238,36,47,200,77,83,224,115,11,56,182,5,7,193,192,151,0,74,111,20,111,124,193,125,113,191,78,131,67,81,125,162,59,88,47,20,164,7,179,62,251,120,172,67,41,91,199,250,104,247,106,232,78,250,12,240,108,207,169,42,99,21,35,52,14,228,207,236,109,12,182,93,116,54,228,61,102,75,142,183,245,144,255,112,185,91,40,23,178,224,11,14,197,149,232,33,122,253,63,98,85,115,94,67,126,99,216,165,188,223,227,123,130,237,50,228,189,73,71,62,177,74,225,141,234,86,221,32,54,56,146,220,73,217,236,217,255,208,171,65,132,160,80,80,39,255,198,205,50,180,168,83,233,139,188,111,123,54,205,178,13,195,48,106,32,10,252,244,210,171,114,237,94,221,30,196,126,97,220,52,21,222,192,221,32,94,72,53,56,127,17,84,227,244,203,59,191,118,90,235,222,156,198,6,193,249,17,58,164,179,222,152,207,201,247,43,85,32,85,127,190,121,147,253,240,61,23,6,182,111,185,43,63,100,187,214,50,106,21,159,146,231,154,49,176,245,132,233,24,182,36,233,244,129,65,227,84,37,240,208,162,37,113,164,225,71,151,166,37,132,190,58,103,143,51,191,252,149,86,22,210,221,9,124,68,70,33,171,14,114,20,131,37,109,54,231,178,44,241,204,76,149,146,234,84,170,154,154,52,198,56,194,240,125,155,109,159,138,8,99,150,74,222,199,252,215,212,29,20,172,251,116,170,100,137,164,29,208,11,218,143,19,98,218,175,147,223,32,223,238,39,209,255,79,204,233,78,142,191,91,218,173,198,13,171,155,139,184,246,47,42,207,83,244,31,12,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateOnExecutionTerminateExceptionLocalizableString());
			LocalizableStrings.Add(CreateOnStopExceptionLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateOnExecutionTerminateExceptionLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("0197d642-0e99-4a65-b19d-c37839084917"),
				Name = "OnExecutionTerminateException",
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef"),
				CreatedInSchemaUId = new Guid("056a2c31-7878-4573-8dca-ecafe4c5fd1b"),
				ModifiedInSchemaUId = new Guid("056a2c31-7878-4573-8dca-ecafe4c5fd1b")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateOnStopExceptionLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("240946f2-b208-45ac-909a-43c9b9be0ccb"),
				Name = "OnStopException",
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef"),
				CreatedInSchemaUId = new Guid("056a2c31-7878-4573-8dca-ecafe4c5fd1b"),
				ModifiedInSchemaUId = new Guid("056a2c31-7878-4573-8dca-ecafe4c5fd1b")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("056a2c31-7878-4573-8dca-ecafe4c5fd1b"));
		}

		#endregion

	}

	#endregion

}

