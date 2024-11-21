namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationSchema

	/// <exclude/>
	public class INotificationSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationSchema(INotificationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bc959941-3df6-44cb-bc9f-61641c97b720");
			Name = "INotification";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,80,75,106,195,48,16,93,199,224,59,204,178,221,88,7,136,241,162,165,24,47,26,66,114,2,69,29,25,129,53,50,35,169,16,66,238,94,41,78,138,66,218,210,133,36,244,230,253,24,146,22,253,44,21,194,203,246,125,239,116,104,94,29,105,51,70,150,193,56,170,171,83,93,173,162,55,52,194,254,232,3,218,52,159,38,84,121,232,155,30,9,217,168,117,93,37,150,16,2,90,31,173,149,124,236,174,255,129,2,178,206,246,218,49,144,11,70,27,117,113,134,153,221,167,249,64,110,110,82,81,104,231,120,152,140,2,243,45,31,54,133,54,17,82,173,116,63,100,94,128,29,134,200,228,239,226,114,202,99,204,130,240,194,239,202,136,166,21,55,56,243,134,55,138,22,89,30,38,108,239,170,12,164,93,7,61,134,18,244,79,207,203,74,126,238,215,179,139,51,80,218,252,47,173,124,224,188,240,133,119,130,17,195,26,206,127,24,110,175,171,252,135,231,38,49,10,203,85,58,0,117,149,158,47,37,141,0,158,10,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bc959941-3df6-44cb-bc9f-61641c97b720"));
		}

		#endregion

	}

	#endregion

}

