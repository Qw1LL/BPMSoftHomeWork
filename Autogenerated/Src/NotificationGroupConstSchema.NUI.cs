namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: NotificationGroupConstSchema

	/// <exclude/>
	public class NotificationGroupConstSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NotificationGroupConstSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NotificationGroupConstSchema(NotificationGroupConstSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5b4de5f4-8161-4ca8-921e-9f19f6876f8d");
			Name = "NotificationGroupConst";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,144,65,107,195,48,12,133,207,13,228,63,136,246,222,220,219,173,176,149,178,211,66,88,97,119,47,113,130,192,145,131,229,20,194,216,127,159,236,173,155,9,148,230,100,63,249,125,79,178,72,245,154,7,85,107,120,174,94,207,182,245,219,163,165,22,187,209,41,143,150,242,236,51,207,86,27,167,59,17,112,52,138,121,7,165,245,216,98,29,13,47,206,142,131,32,236,243,76,156,69,81,192,3,143,125,175,220,116,248,213,241,85,145,103,176,45,116,193,207,64,73,196,246,202,21,9,56,140,31,6,107,16,208,203,81,135,198,55,251,174,194,140,255,67,94,219,237,160,138,33,113,176,89,160,211,170,177,100,38,209,14,169,131,119,100,5,143,176,14,231,122,127,223,255,166,123,164,38,220,4,250,19,75,200,50,249,68,128,83,189,132,63,157,203,121,196,172,180,36,229,137,8,47,218,177,108,59,36,36,114,17,109,76,164,140,9,238,184,124,77,205,207,254,69,125,197,90,90,146,202,55,160,71,46,199,105,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5b4de5f4-8161-4ca8-921e-9f19f6876f8d"));
		}

		#endregion

	}

	#endregion

}

