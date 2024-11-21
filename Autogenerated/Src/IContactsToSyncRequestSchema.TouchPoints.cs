namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IContactsToSyncRequestSchema

	/// <exclude/>
	public class IContactsToSyncRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IContactsToSyncRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IContactsToSyncRequestSchema(IContactsToSyncRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fe2401fc-4445-4ccb-8923-5d73436003de");
			Name = "IContactsToSyncRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,207,110,194,48,12,198,207,32,241,14,22,92,54,105,162,247,13,122,216,31,33,164,33,77,192,30,32,180,46,68,162,14,179,157,3,155,246,238,115,91,96,43,108,210,46,85,226,124,253,252,251,226,144,43,81,118,46,67,184,127,153,45,66,161,195,135,64,133,95,71,118,234,3,245,186,31,189,110,39,138,167,53,44,246,162,88,222,157,237,77,191,221,98,86,137,101,56,65,66,246,217,183,230,219,148,209,170,86,31,48,174,77,11,83,82,228,194,26,223,194,212,90,170,203,84,150,97,177,167,108,142,111,17,69,107,117,146,36,48,146,88,150,142,247,233,97,63,199,29,163,32,169,64,137,186,9,185,128,6,88,163,66,118,240,129,34,48,228,78,29,136,249,109,56,144,127,175,227,12,143,150,201,15,207,93,92,109,125,6,254,8,244,39,79,199,238,194,190,167,8,179,166,251,45,188,212,14,205,225,57,241,1,89,35,147,64,36,111,94,224,115,163,247,133,71,22,8,197,255,176,47,185,155,202,206,177,43,129,108,140,227,126,20,100,99,167,102,28,253,116,74,162,142,44,145,53,25,9,34,100,140,197,184,255,218,150,37,233,112,148,212,54,191,187,154,7,235,163,83,236,167,139,106,89,33,226,229,47,220,100,76,159,189,232,143,84,22,86,76,124,60,173,228,211,39,138,37,178,91,109,113,52,137,62,79,97,130,218,190,243,171,54,35,180,147,221,64,133,179,244,37,194,9,238,186,121,94,157,1,82,222,204,167,222,127,54,143,174,85,180,218,23,246,231,152,30,247,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fe2401fc-4445-4ccb-8923-5d73436003de"));
		}

		#endregion

	}

	#endregion

}

