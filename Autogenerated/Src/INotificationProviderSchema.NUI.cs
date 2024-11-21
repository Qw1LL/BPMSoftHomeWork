namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationProviderSchema

	/// <exclude/>
	public class INotificationProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationProviderSchema(INotificationProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("aabdace1-2a9b-4be1-a035-cadae80c10e3");
			Name = "INotificationProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,77,106,195,64,12,133,215,9,244,14,3,217,164,16,124,128,180,116,145,31,66,22,41,6,159,96,50,150,93,5,71,50,26,57,16,74,238,94,205,184,53,45,116,57,239,125,79,122,26,242,87,136,189,15,224,54,229,169,226,70,139,45,83,131,237,32,94,145,201,125,62,205,103,67,68,106,127,249,2,197,110,243,50,25,213,61,42,92,77,239,58,8,41,20,139,3,16,8,6,99,140,90,8,180,105,212,145,20,164,177,85,107,119,124,103,197,6,67,222,81,10,223,176,6,201,112,63,156,59,12,14,127,216,255,209,84,203,224,105,244,9,244,131,235,184,118,101,142,143,166,205,112,7,208,45,15,164,203,231,212,119,86,65,170,152,212,61,41,42,66,28,149,111,251,198,88,187,10,180,244,98,223,98,13,226,114,135,249,36,47,247,215,168,98,231,174,28,159,47,22,121,115,253,68,165,116,174,3,84,143,141,242,251,49,158,255,71,124,124,1,198,225,222,151,113,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aabdace1-2a9b-4be1-a035-cadae80c10e3"));
		}

		#endregion

	}

	#endregion

}

