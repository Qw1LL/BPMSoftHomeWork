namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailProcessTemplateUserTaskMessageProviderSchema

	/// <exclude/>
	public class EmailProcessTemplateUserTaskMessageProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailProcessTemplateUserTaskMessageProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailProcessTemplateUserTaskMessageProviderSchema(EmailProcessTemplateUserTaskMessageProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0b79b40c-b679-49a4-ace9-9049573f8669");
			Name = "EmailProcessTemplateUserTaskMessageProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("da7de29a-d2b3-4248-bf8e-b7a592dc81f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,145,77,110,194,48,16,133,215,65,234,29,44,117,19,54,57,0,136,5,208,168,43,36,90,232,1,76,50,9,86,19,59,204,216,72,81,197,221,59,206,15,36,192,134,77,20,143,223,155,247,205,88,203,18,168,146,9,136,213,118,179,51,153,141,214,6,33,218,162,73,128,136,15,58,83,185,67,105,149,209,111,147,191,183,73,224,72,233,124,160,30,8,122,219,7,144,202,53,224,252,137,156,155,199,218,42,171,128,248,154,5,239,8,57,123,197,186,144,68,51,17,151,82,21,93,159,61,148,85,33,45,252,16,224,94,210,239,134,107,50,7,190,61,171,20,176,177,87,238,80,168,68,36,222,253,138,89,204,196,74,18,116,226,198,248,208,62,224,121,249,123,67,52,154,44,186,196,26,100,210,109,147,220,42,58,138,23,242,195,70,123,47,18,174,251,153,250,174,193,76,28,152,49,188,22,133,127,128,224,210,81,129,78,91,176,49,229,6,236,209,164,30,16,141,133,196,66,218,49,246,71,97,206,128,200,16,130,167,241,175,243,9,182,161,89,153,180,14,187,144,0,193,58,212,237,72,61,94,228,21,243,1,195,147,158,177,127,221,122,151,28,161,148,95,14,176,246,237,119,204,10,24,211,233,218,254,81,6,116,18,139,102,224,104,236,104,2,3,149,137,118,103,87,24,47,105,183,88,87,32,22,11,17,42,109,167,163,106,180,116,214,244,145,1,39,68,236,94,166,165,210,223,42,63,90,226,192,76,22,4,109,4,15,117,27,156,197,195,73,239,182,221,86,199,197,203,63,36,108,58,203,77,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b79b40c-b679-49a4-ace9-9049573f8669"));
		}

		#endregion

	}

	#endregion

}

