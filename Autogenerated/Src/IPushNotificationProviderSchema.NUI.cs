namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IPushNotificationProviderSchema

	/// <exclude/>
	public class IPushNotificationProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPushNotificationProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPushNotificationProviderSchema(IPushNotificationProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e415681b-39a4-4c62-9fc4-58927242174a");
			Name = "IPushNotificationProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d653ba80-e9e2-4f78-8775-8ba14502d8a8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,81,75,195,48,16,199,159,83,232,119,56,240,69,65,218,247,57,6,186,129,236,97,82,172,95,32,182,215,122,152,38,37,151,14,134,236,187,155,166,117,204,209,14,125,41,105,238,126,255,227,199,69,203,6,185,149,5,194,83,182,203,77,229,146,181,209,21,213,157,149,142,140,142,163,175,56,18,29,147,174,33,63,176,195,198,215,149,194,162,47,114,242,140,26,45,21,15,113,228,187,110,44,214,254,22,182,218,161,173,124,228,2,182,89,199,31,47,198,81,69,69,200,203,172,217,83,137,54,0,105,154,194,146,187,166,145,246,176,26,255,79,48,152,10,90,79,131,62,195,161,29,121,78,126,248,244,44,160,237,222,21,21,64,167,140,43,243,69,47,38,246,134,74,200,81,151,183,151,157,27,233,36,148,254,115,231,237,196,113,48,244,141,131,228,47,225,181,146,204,11,152,74,152,245,124,197,214,34,163,118,60,97,217,143,189,38,88,244,3,103,230,137,224,53,54,178,179,253,230,222,204,39,106,8,5,81,163,235,133,132,224,241,48,168,93,18,228,20,254,139,216,33,179,172,255,200,108,40,60,32,111,181,28,240,251,49,102,5,143,101,73,161,166,194,6,230,227,38,119,114,252,6,69,3,141,227,208,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e415681b-39a4-4c62-9fc4-58927242174a"));
		}

		#endregion

	}

	#endregion

}

