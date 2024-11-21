namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: WebhookParserSchema

	/// <exclude/>
	public class WebhookParserSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookParserSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookParserSchema(WebhookParserSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("27f94e71-ff84-4026-a617-5aa9c6d13750");
			Name = "WebhookParser";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,83,177,110,194,48,16,157,131,196,63,156,96,161,75,178,183,52,67,65,170,84,1,69,98,232,236,56,71,226,54,177,145,237,20,209,138,127,239,217,9,165,129,80,164,14,205,96,201,231,247,222,61,191,115,36,43,209,108,24,71,120,88,206,87,106,109,195,137,146,107,145,85,154,89,161,100,184,82,92,176,98,134,44,125,68,217,239,125,246,123,65,101,132,204,96,129,91,171,164,113,140,39,163,228,93,191,71,71,67,141,25,177,96,82,48,99,110,225,5,147,92,169,183,37,211,6,181,7,68,81,4,99,83,149,37,211,187,184,217,55,40,216,120,88,120,64,69,63,96,155,42,41,4,7,99,201,20,7,238,212,79,197,3,178,70,235,183,133,57,218,92,165,100,98,233,185,245,225,105,123,95,240,10,80,208,21,65,42,43,214,59,216,54,142,82,102,153,243,115,110,168,174,144,99,86,130,164,8,239,7,14,59,136,167,180,194,54,23,60,7,97,64,34,166,96,21,36,8,92,201,119,212,182,222,219,188,187,159,74,94,145,219,112,28,121,225,99,31,141,182,210,210,196,179,223,56,7,144,99,181,243,114,180,133,103,29,162,246,87,62,150,71,198,106,55,83,119,135,27,112,51,14,130,90,14,220,108,39,181,247,112,138,148,52,189,6,241,129,207,190,235,248,76,57,30,121,13,122,13,65,176,191,154,57,61,61,195,50,252,207,216,47,180,188,150,252,252,10,237,114,248,13,179,35,255,214,201,159,71,208,165,223,49,133,33,202,180,254,51,252,222,87,129,190,118,125,255,5,79,126,111,77,15,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("27f94e71-ff84-4026-a617-5aa9c6d13750"));
		}

		#endregion

	}

	#endregion

}

