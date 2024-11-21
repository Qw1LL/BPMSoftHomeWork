namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: StoppedBulkEmailCampaignEventHandlerSchema

	/// <exclude/>
	public class StoppedBulkEmailCampaignEventHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public StoppedBulkEmailCampaignEventHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public StoppedBulkEmailCampaignEventHandlerSchema(StoppedBulkEmailCampaignEventHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("750ec918-cad6-4585-94ac-d3ec62f1b68d");
			Name = "StoppedBulkEmailCampaignEventHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7b5cce97-2e1e-4b17-90ca-f9813022e3eb");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,85,93,79,219,48,20,125,71,226,63,120,229,37,145,42,119,207,180,84,162,172,64,36,170,34,101,27,15,211,30,220,248,182,181,112,156,206,118,10,221,216,127,223,117,190,72,234,22,144,230,151,40,190,31,62,231,222,123,108,197,82,48,27,150,0,153,220,207,226,108,105,233,85,166,150,98,149,107,102,69,166,78,79,254,156,158,16,92,185,17,106,69,226,157,177,144,14,253,45,140,146,18,18,23,98,232,13,40,208,34,57,228,118,39,212,175,206,254,235,169,105,154,169,35,38,13,244,138,165,27,38,86,31,240,160,211,45,40,123,203,20,151,160,143,187,127,153,116,108,110,175,206,16,39,107,72,25,185,32,221,188,93,51,70,151,241,103,26,86,72,155,92,73,102,204,57,137,109,182,217,0,159,228,242,113,154,50,33,235,168,54,170,58,116,147,47,164,72,136,1,38,129,147,196,37,248,80,60,57,39,135,182,39,204,64,159,68,115,85,27,191,51,41,56,179,208,47,143,115,171,101,157,192,18,249,197,108,11,165,25,59,253,234,87,179,154,129,93,103,28,121,221,107,177,197,84,109,159,77,185,69,22,89,38,201,13,32,12,83,64,126,16,118,29,91,102,115,19,220,228,130,255,248,73,22,53,155,114,59,226,8,115,170,242,20,52,91,72,24,57,175,49,193,162,10,25,113,19,58,36,245,25,110,137,37,9,62,125,51,160,113,52,85,57,100,56,99,54,50,215,128,217,52,76,149,203,194,131,94,83,52,87,196,94,72,94,94,154,164,52,66,108,27,187,11,66,47,189,91,26,48,145,34,75,38,13,84,115,81,175,191,221,223,45,211,216,48,55,235,56,32,10,158,72,92,252,4,93,124,33,14,89,174,108,160,80,94,217,50,104,128,209,136,135,33,189,214,89,234,153,194,208,135,69,31,214,160,225,72,150,72,5,168,186,60,85,244,158,105,244,176,160,77,208,20,241,80,182,75,197,253,92,117,75,142,101,244,122,135,21,100,166,162,61,244,139,83,32,48,5,125,172,80,89,42,58,125,134,36,183,16,39,76,50,61,18,202,142,131,112,47,182,106,65,59,124,76,62,183,156,90,141,240,103,208,31,39,156,144,134,36,22,36,56,160,112,83,124,188,129,168,144,148,86,122,45,179,167,169,132,20,117,102,232,124,249,117,183,129,209,140,233,71,176,120,111,20,217,43,43,82,162,213,48,60,147,139,49,121,166,93,55,172,92,151,141,207,98,155,9,78,106,213,86,55,65,17,27,120,32,155,82,35,55,172,179,199,182,195,116,191,214,46,120,237,169,181,76,115,64,197,56,230,40,226,3,178,153,161,31,210,195,185,55,88,156,150,252,92,216,45,211,188,226,224,4,255,166,239,68,3,123,68,107,196,247,196,215,127,189,22,134,7,110,5,159,196,27,242,126,95,216,248,22,26,182,130,178,16,119,201,239,216,106,4,133,13,201,27,17,126,228,126,14,91,23,110,189,122,237,118,206,21,130,213,110,50,234,240,222,62,189,110,3,233,37,231,213,92,224,237,18,169,101,22,84,88,251,141,103,215,126,7,91,144,244,129,105,133,167,28,29,188,51,80,188,188,233,223,190,252,139,135,170,237,50,24,12,200,200,228,105,202,244,110,220,221,46,139,96,8,67,49,187,162,16,187,102,150,8,67,52,19,6,223,185,69,241,238,144,164,130,93,233,140,24,124,136,56,221,59,97,224,31,81,61,154,133,84,230,173,71,204,151,200,97,33,13,143,148,162,195,232,61,14,88,156,6,255,182,169,123,77,205,184,230,210,247,193,215,0,255,23,186,223,197,198,220,53,225,246,63,140,218,198,86,241,9,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateStoppedEmailOnStartingCampaignLocalizableString());
			LocalizableStrings.Add(CreateActiveEmailsOnStoppedCampaignMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateStoppedEmailOnStartingCampaignLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("648f590e-70c3-a25b-fff8-a0b67cd53c49"),
				Name = "StoppedEmailOnStartingCampaign",
				CreatedInPackageId = new Guid("7b5cce97-2e1e-4b17-90ca-f9813022e3eb"),
				CreatedInSchemaUId = new Guid("750ec918-cad6-4585-94ac-d3ec62f1b68d"),
				ModifiedInSchemaUId = new Guid("750ec918-cad6-4585-94ac-d3ec62f1b68d")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateActiveEmailsOnStoppedCampaignMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("aa1b197a-4713-f78b-4c1e-2b5e403d60c6"),
				Name = "ActiveEmailsOnStoppedCampaignMessage",
				CreatedInPackageId = new Guid("7b5cce97-2e1e-4b17-90ca-f9813022e3eb"),
				CreatedInSchemaUId = new Guid("750ec918-cad6-4585-94ac-d3ec62f1b68d"),
				ModifiedInSchemaUId = new Guid("750ec918-cad6-4585-94ac-d3ec62f1b68d")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("750ec918-cad6-4585-94ac-d3ec62f1b68d"));
		}

		#endregion

	}

	#endregion

}

