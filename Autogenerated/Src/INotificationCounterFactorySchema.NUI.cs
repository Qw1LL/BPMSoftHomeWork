namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationCounterFactorySchema

	/// <exclude/>
	public class INotificationCounterFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationCounterFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationCounterFactorySchema(INotificationCounterFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("77f3b853-df5f-4ea2-af13-167cb7ffd1ed");
			Name = "INotificationCounterFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,193,78,195,48,12,134,207,171,212,119,176,198,5,46,237,29,186,30,152,160,218,1,52,49,94,32,203,220,46,82,155,84,182,131,84,161,189,59,105,202,88,37,38,196,45,249,253,251,207,23,217,86,117,200,189,210,8,143,219,151,157,171,37,91,59,91,155,198,147,18,227,108,154,124,166,201,194,179,177,13,236,6,22,236,66,189,109,81,143,69,206,42,180,72,70,63,164,73,112,221,16,54,65,133,141,21,164,58,68,222,195,230,213,137,169,141,142,89,107,231,199,202,179,210,226,104,136,45,121,158,67,193,190,235,20,13,229,247,125,75,238,195,28,144,65,65,135,114,116,7,16,7,74,107,100,6,57,34,232,86,49,135,114,237,8,26,20,25,209,162,62,197,115,118,206,205,103,193,189,223,183,70,131,57,163,253,77,182,24,63,253,11,46,10,111,40,158,44,135,36,22,101,3,20,184,58,184,48,188,79,88,175,150,215,114,151,121,9,251,97,238,154,155,42,114,190,15,150,159,39,231,220,147,210,43,82,29,216,48,170,213,178,137,246,242,61,252,56,30,163,156,21,121,244,92,90,104,226,44,47,211,250,31,104,145,159,59,199,168,205,147,245,29,146,218,183,88,92,107,40,161,66,185,162,243,45,11,141,131,137,136,119,97,63,22,167,105,71,208,30,166,53,73,147,211,23,65,107,11,86,124,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("77f3b853-df5f-4ea2-af13-167cb7ffd1ed"));
		}

		#endregion

	}

	#endregion

}

