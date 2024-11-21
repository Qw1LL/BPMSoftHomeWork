namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationInfoExecutorSchema

	/// <exclude/>
	public class INotificationInfoExecutorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationInfoExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationInfoExecutorSchema(INotificationInfoExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("70829de2-1828-4038-881b-1a16b2b88f30");
			Name = "INotificationInfoExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,145,77,75,3,49,16,134,207,13,236,127,24,122,105,123,73,208,131,30,44,61,88,60,172,160,43,246,40,30,146,237,164,4,178,153,146,15,181,168,255,221,236,174,213,148,66,72,38,147,121,102,222,151,164,96,220,14,54,135,16,177,187,169,88,197,156,236,48,236,101,139,112,251,244,176,33,29,249,154,156,54,187,228,101,52,228,42,246,89,177,137,16,2,150,33,117,157,244,135,213,239,189,118,17,189,238,65,77,30,28,69,163,77,59,48,128,31,216,166,62,226,71,86,20,240,75,163,2,89,140,56,159,94,243,139,43,126,9,95,69,179,119,99,45,40,4,143,29,189,225,22,164,206,47,176,197,30,0,141,50,38,143,48,123,44,198,133,198,53,14,215,86,134,112,79,106,198,167,139,215,60,101,159,148,53,45,152,191,198,117,201,212,78,211,221,160,146,124,46,206,30,243,126,102,115,72,148,216,169,179,115,107,99,198,99,22,233,194,234,121,60,255,33,8,81,70,228,75,113,172,232,17,69,100,97,212,130,243,69,254,147,201,119,197,242,250,1,80,191,123,113,170,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("70829de2-1828-4038-881b-1a16b2b88f30"));
		}

		#endregion

	}

	#endregion

}

