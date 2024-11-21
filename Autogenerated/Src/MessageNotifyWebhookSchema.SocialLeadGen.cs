namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MessageNotifyWebhookSchema

	/// <exclude/>
	public class MessageNotifyWebhookSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MessageNotifyWebhookSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MessageNotifyWebhookSchema(MessageNotifyWebhookSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b64b5e73-bc62-4ff2-a773-7df631ba5e5b");
			Name = "MessageNotifyWebhook";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,83,59,79,195,48,16,158,91,137,255,112,106,23,88,218,29,42,6,90,132,138,104,169,84,36,6,196,224,56,151,196,224,216,145,207,81,21,42,254,59,118,226,150,38,148,215,98,41,231,207,247,61,238,162,88,142,84,48,142,112,181,90,172,117,98,71,83,173,18,145,150,134,89,161,213,104,173,185,96,242,14,89,124,131,234,164,191,61,233,247,74,18,42,133,37,110,172,86,228,95,220,146,86,23,251,139,117,69,22,115,215,70,74,228,190,7,141,220,83,52,130,59,140,67,13,13,166,174,10,83,201,136,206,225,17,163,76,235,215,21,51,132,166,6,140,199,99,152,80,153,231,204,84,151,225,123,129,68,44,69,80,218,138,164,130,77,243,104,180,67,143,15,224,79,94,206,125,244,226,200,79,23,152,71,104,214,142,156,73,241,214,56,186,47,236,92,157,61,59,100,81,70,82,112,224,94,200,142,97,89,19,4,81,14,227,12,187,179,43,58,128,155,187,174,222,186,48,67,226,70,68,72,224,67,145,8,121,112,144,104,19,92,120,245,95,229,31,85,229,235,62,250,35,100,173,120,184,142,17,54,153,224,25,196,123,1,155,140,89,200,88,81,160,27,197,103,147,22,105,147,218,202,232,2,141,173,78,7,190,209,160,14,105,47,136,172,241,227,157,122,138,45,164,104,47,128,252,241,222,164,240,139,50,91,21,248,87,114,143,237,144,11,101,225,193,149,255,193,60,67,203,132,196,56,36,81,248,225,131,78,118,131,248,171,152,131,215,199,3,153,29,180,223,182,213,245,122,65,226,16,85,220,108,80,123,157,2,141,64,183,83,171,186,235,15,43,21,162,36,55,229,221,175,245,205,10,117,44,4,199,20,244,7,249,243,107,85,230,104,88,36,113,18,90,95,126,114,116,156,28,49,209,84,219,197,247,15,60,27,53,162,79,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b64b5e73-bc62-4ff2-a773-7df631ba5e5b"));
		}

		#endregion

	}

	#endregion

}

