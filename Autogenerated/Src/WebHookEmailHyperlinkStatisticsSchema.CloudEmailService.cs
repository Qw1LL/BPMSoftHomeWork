namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: WebHookEmailHyperlinkStatisticsSchema

	/// <exclude/>
	public class WebHookEmailHyperlinkStatisticsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebHookEmailHyperlinkStatisticsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebHookEmailHyperlinkStatisticsSchema(WebHookEmailHyperlinkStatisticsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("360ea3e1-2a77-455d-9130-520eefc7c9b3");
			Name = "WebHookEmailHyperlinkStatistics";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,77,79,227,48,20,60,7,137,255,96,133,139,35,170,104,207,172,56,108,75,213,86,187,72,213,102,43,206,110,252,218,90,117,237,224,15,150,10,241,223,247,57,142,11,22,93,184,88,177,253,102,222,204,248,69,177,3,216,142,181,64,198,203,251,70,111,92,61,209,106,35,182,222,48,39,180,186,188,120,185,188,40,188,21,106,75,154,163,117,112,248,126,218,79,180,129,124,87,223,141,241,0,143,174,12,108,17,77,38,146,89,123,67,166,7,38,228,252,216,129,145,66,237,27,135,212,214,137,214,246,181,157,95,75,209,146,54,148,254,183,146,220,144,49,179,240,0,235,185,214,123,68,161,44,92,79,141,150,70,35,198,9,192,110,203,158,48,222,15,228,51,47,120,228,94,112,18,28,21,197,22,92,16,95,20,118,248,120,205,16,214,153,224,170,151,242,11,165,124,129,186,2,197,163,148,140,69,40,135,25,136,118,111,191,194,15,62,238,193,237,52,63,111,66,63,129,49,130,67,210,54,3,55,51,218,119,63,225,72,171,129,223,128,243,70,145,53,102,85,231,247,215,201,127,253,71,55,61,65,127,120,50,120,38,131,83,195,39,141,241,205,153,226,50,189,0,93,89,48,56,41,10,218,48,38,196,103,219,164,38,216,223,165,6,191,49,250,91,50,224,87,78,72,17,158,43,168,156,191,43,161,57,211,232,77,224,40,25,168,98,130,98,67,104,78,126,75,190,165,206,67,16,177,18,93,225,170,224,47,89,117,156,57,248,208,163,28,123,185,207,71,175,172,34,79,221,128,163,101,124,195,137,246,202,149,35,28,117,233,15,170,94,50,131,63,143,3,67,227,117,149,32,15,59,48,64,223,72,23,188,172,234,133,157,62,122,38,233,7,112,114,149,208,63,20,167,37,250,249,12,243,222,119,85,213,211,103,104,61,250,138,201,156,31,201,16,66,248,51,179,211,215,127,231,165,167,201,255,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("360ea3e1-2a77-455d-9130-520eefc7c9b3"));
		}

		#endregion

	}

	#endregion

}

