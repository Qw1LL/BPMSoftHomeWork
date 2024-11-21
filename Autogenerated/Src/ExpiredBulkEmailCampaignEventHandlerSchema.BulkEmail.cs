namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ExpiredBulkEmailCampaignEventHandlerSchema

	/// <exclude/>
	public class ExpiredBulkEmailCampaignEventHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExpiredBulkEmailCampaignEventHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExpiredBulkEmailCampaignEventHandlerSchema(ExpiredBulkEmailCampaignEventHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bfe2abbc-c116-4dda-8eb1-abdef10b7756");
			Name = "ExpiredBulkEmailCampaignEventHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7b5cce97-2e1e-4b17-90ca-f9813022e3eb");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,85,77,79,227,48,16,189,35,241,31,188,229,146,72,200,221,51,133,74,20,2,27,169,108,89,181,44,231,105,50,105,45,28,167,216,78,161,187,240,223,119,242,73,210,180,20,105,125,169,234,249,122,243,230,141,163,32,70,179,130,0,217,232,254,110,154,68,150,95,37,42,18,139,84,131,21,137,58,62,250,123,124,196,232,164,70,168,5,155,110,140,197,120,208,189,162,40,41,49,200,66,12,191,69,133,90,4,187,220,198,66,61,183,238,63,170,198,113,162,246,152,52,242,43,136,87,32,22,95,240,224,222,26,149,253,1,42,148,168,247,187,95,143,90,182,236,174,202,48,13,150,24,3,187,96,237,188,109,51,69,23,241,39,26,23,212,54,187,146,96,204,25,243,94,87,66,99,56,74,229,147,23,131,144,85,84,19,85,21,186,74,231,82,4,204,32,72,12,89,144,37,248,82,60,59,99,187,174,71,96,240,148,249,19,85,25,127,131,20,33,88,60,45,202,101,167,97,29,97,68,253,77,97,141,133,153,38,253,225,87,117,117,135,118,153,132,212,215,189,22,107,74,213,244,89,21,87,108,158,36,146,221,34,193,48,37,250,28,185,113,124,79,165,49,106,152,75,60,191,77,69,56,100,68,156,144,126,104,220,172,90,149,39,59,34,98,206,183,7,131,154,228,167,10,33,145,142,172,111,110,16,108,170,209,83,89,150,208,233,205,180,88,44,80,231,21,102,75,157,88,43,105,126,191,82,76,177,231,178,183,183,186,4,247,141,23,175,236,198,113,59,197,178,163,145,210,42,22,129,52,88,42,161,58,239,237,191,107,208,52,162,76,221,36,9,133,47,108,154,255,113,218,104,93,146,85,170,172,163,104,161,146,200,169,231,199,253,208,117,249,141,78,226,142,201,117,187,176,248,227,18,53,238,201,226,43,135,246,44,141,21,191,7,77,30,22,181,113,106,74,119,101,187,84,97,55,87,62,164,124,189,175,105,124,89,94,51,70,99,38,218,123,78,65,118,74,56,153,215,76,196,200,31,108,240,51,121,33,62,193,148,36,12,186,84,229,120,76,78,6,241,85,16,71,37,49,72,45,78,3,144,160,207,133,178,67,199,221,138,45,7,210,12,31,178,239,13,167,247,93,218,235,74,140,84,83,183,74,180,56,59,54,219,228,63,29,89,148,8,10,43,191,145,201,139,39,49,166,253,50,124,18,205,54,43,60,191,3,253,132,150,244,150,103,47,173,212,10,47,37,241,202,46,134,236,149,183,221,104,116,135,186,88,39,34,100,213,182,54,119,200,233,128,172,41,166,222,136,223,78,183,173,78,183,57,206,130,151,91,91,90,36,233,236,110,45,171,193,142,69,221,206,241,201,134,29,222,45,250,0,25,88,96,129,99,28,252,153,90,77,212,17,27,105,189,7,95,121,20,221,198,43,87,157,94,19,229,68,209,91,71,153,171,224,222,118,107,109,238,248,101,24,150,35,161,77,241,85,148,56,37,210,211,218,179,109,31,227,26,37,127,4,173,168,202,222,153,159,160,10,139,199,245,243,247,54,255,54,52,93,250,253,62,59,55,105,28,131,222,12,219,215,5,5,134,1,237,79,70,9,179,75,176,76,24,166,65,24,250,180,204,243,167,158,5,37,236,82,226,204,208,219,31,242,173,10,253,110,137,242,59,149,171,116,210,248,110,116,213,185,91,195,131,61,84,180,58,58,212,3,145,83,227,95,215,188,87,173,25,11,218,242,195,224,43,128,255,11,189,59,197,218,220,54,209,245,63,5,78,179,186,100,9,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateExpiredEmailOnSavingCampaignLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateExpiredEmailOnSavingCampaignLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("c4cf7837-443a-45c8-e95c-827f665cb8d6"),
				Name = "ExpiredEmailOnSavingCampaign",
				CreatedInPackageId = new Guid("7b5cce97-2e1e-4b17-90ca-f9813022e3eb"),
				CreatedInSchemaUId = new Guid("bfe2abbc-c116-4dda-8eb1-abdef10b7756"),
				ModifiedInSchemaUId = new Guid("bfe2abbc-c116-4dda-8eb1-abdef10b7756")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bfe2abbc-c116-4dda-8eb1-abdef10b7756"));
		}

		#endregion

	}

	#endregion

}

