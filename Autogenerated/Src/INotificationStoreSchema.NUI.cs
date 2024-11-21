namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationStoreSchema

	/// <exclude/>
	public class INotificationStoreSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationStoreSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationStoreSchema(INotificationStoreSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5ee4e1be-170c-44d3-92be-47cd9f1c5368");
			Name = "INotificationStore";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,144,77,106,195,48,16,133,215,54,248,14,179,108,55,214,1,106,188,104,41,193,139,134,80,159,64,81,70,169,192,26,153,209,168,16,74,239,222,113,82,183,134,128,36,164,249,121,223,211,144,141,152,103,235,16,158,15,111,99,242,210,190,36,242,225,92,216,74,72,212,212,95,77,93,149,28,232,12,227,37,11,70,205,79,19,186,37,153,219,29,18,114,112,79,77,173,85,198,24,232,114,137,209,242,165,255,125,15,36,200,126,145,247,137,193,58,135,57,195,201,138,133,228,65,62,16,40,73,240,193,93,97,48,115,250,12,39,228,220,174,114,102,163,55,151,227,20,28,132,63,201,97,191,105,30,37,49,106,149,250,213,243,206,204,53,240,142,82,152,242,63,7,72,191,191,192,238,105,183,8,223,58,250,206,172,183,37,53,188,82,137,200,246,56,97,151,133,117,56,61,236,80,182,118,14,43,98,175,132,135,71,157,80,85,233,254,110,106,93,63,202,48,93,178,117,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5ee4e1be-170c-44d3-92be-47cd9f1c5368"));
		}

		#endregion

	}

	#endregion

}

