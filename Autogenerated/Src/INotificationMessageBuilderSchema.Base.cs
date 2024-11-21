namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationMessageBuilderSchema

	/// <exclude/>
	public class INotificationMessageBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationMessageBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationMessageBuilderSchema(INotificationMessageBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b0a82eba-e0ad-4ba7-bced-e8d42f2a5640");
			Name = "INotificationMessageBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,193,106,2,49,16,134,207,17,124,135,129,94,218,139,123,215,82,168,61,216,61,108,17,164,15,16,205,236,26,48,137,100,146,130,148,190,123,39,137,43,106,89,177,151,221,100,50,255,63,223,76,98,165,65,218,203,13,194,124,217,172,92,27,38,111,206,182,186,139,94,6,237,236,120,244,61,30,137,72,218,118,176,58,80,64,51,59,237,123,65,131,68,178,227,8,75,141,113,150,51,56,231,193,99,199,6,80,219,128,190,229,2,83,168,63,92,208,173,222,100,231,162,194,121,212,59,133,62,75,170,170,130,103,138,198,72,127,120,57,238,151,222,125,105,133,4,6,195,214,41,130,224,96,157,52,96,207,204,248,52,187,77,122,151,234,204,102,31,215,59,189,1,221,131,220,230,16,220,48,127,79,252,12,176,71,31,52,210,20,150,217,169,156,95,195,230,192,2,3,129,243,64,233,207,216,54,213,65,15,174,133,176,69,144,202,104,11,209,234,144,64,255,146,138,69,212,42,205,249,53,37,126,114,94,173,32,93,128,16,29,134,52,121,33,232,184,248,57,98,162,85,133,244,18,187,41,227,186,131,57,119,78,32,251,25,158,113,223,162,204,178,90,61,62,205,254,227,189,69,169,6,125,235,134,186,247,156,80,132,101,253,207,10,107,167,14,3,254,20,124,126,183,73,50,231,180,59,157,135,30,218,64,7,69,120,242,190,186,160,114,109,151,65,142,253,2,212,136,143,149,135,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b0a82eba-e0ad-4ba7-bced-e8d42f2a5640"));
		}

		#endregion

	}

	#endregion

}

