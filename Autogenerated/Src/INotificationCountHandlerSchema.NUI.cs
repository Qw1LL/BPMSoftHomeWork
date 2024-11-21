namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationCountHandlerSchema

	/// <exclude/>
	public class INotificationCountHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationCountHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationCountHandlerSchema(INotificationCountHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e44863be-4aaa-47e8-b8fa-552d50bcc3f3");
			Name = "INotificationCountHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,82,193,78,194,64,16,61,67,194,63,76,240,162,9,105,239,138,61,136,9,114,144,16,137,31,176,110,167,101,99,187,219,204,206,98,136,225,223,157,221,130,34,232,161,135,153,125,239,205,155,215,177,170,69,223,41,141,240,176,122,94,187,138,179,153,179,149,169,3,41,54,206,142,134,159,163,225,32,120,99,107,88,239,60,99,123,119,86,11,190,105,80,71,176,207,230,104,145,140,22,140,160,174,8,107,233,194,194,50,82,37,35,110,97,177,116,108,42,163,147,246,204,5,203,79,202,150,13,18,36,70,158,231,48,245,161,109,21,237,138,67,189,34,183,53,37,122,104,145,55,174,4,118,64,200,100,112,139,192,27,4,29,85,144,124,118,228,231,39,2,93,120,107,140,6,115,116,240,191,1,1,199,77,7,241,59,183,145,26,47,200,129,172,255,53,19,42,71,160,32,120,164,12,190,153,167,6,250,78,167,72,181,96,37,234,251,177,118,150,149,230,69,57,46,94,133,7,178,155,141,150,68,98,154,39,224,223,188,154,92,232,198,197,82,10,112,85,178,145,90,151,44,137,39,58,45,30,77,250,43,226,100,2,31,27,36,132,119,220,129,241,61,47,138,164,61,64,2,128,173,106,2,198,183,212,18,205,163,72,84,93,252,40,77,189,68,111,235,73,140,180,128,57,242,69,158,18,203,245,60,152,82,148,14,139,78,160,39,245,115,111,226,1,237,251,3,65,91,246,55,50,26,238,191,0,172,248,78,210,137,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e44863be-4aaa-47e8-b8fa-552d50bcc3f3"));
		}

		#endregion

	}

	#endregion

}

