namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationCounterSchema

	/// <exclude/>
	public class INotificationCounterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationCounterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationCounterSchema(INotificationCounterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8b7d7230-b757-4090-bbb0-2b97d1bc90cb");
			Name = "INotificationCounter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,146,193,106,195,48,12,134,207,43,244,29,68,119,217,160,36,247,173,203,97,29,148,28,54,202,250,4,174,173,164,102,177,29,100,185,35,140,190,251,108,167,161,101,101,183,88,254,253,253,210,175,88,97,208,247,66,34,188,110,223,119,174,225,98,237,108,163,219,64,130,181,179,243,217,207,124,118,23,188,182,45,236,6,207,104,158,255,156,163,190,235,80,38,177,47,54,104,145,180,140,154,168,186,39,108,99,21,106,203,72,77,180,120,130,250,195,177,110,180,204,236,181,11,233,38,107,203,178,132,149,15,198,8,26,170,243,121,75,238,168,21,122,16,96,144,15,78,1,59,104,145,129,15,8,54,152,61,18,184,6,236,21,210,195,126,128,150,92,232,139,9,90,94,81,251,176,239,180,4,61,53,244,79,63,119,105,230,155,150,114,225,19,57,80,180,185,54,5,57,62,204,230,210,89,22,146,147,253,173,255,88,233,5,9,3,54,6,255,178,56,203,107,181,168,98,238,233,19,226,200,54,193,145,138,85,153,181,151,167,52,218,87,111,58,7,30,177,75,248,62,32,33,124,225,0,218,143,179,167,84,114,79,32,172,130,163,232,2,166,187,92,138,204,9,146,168,245,133,180,242,76,113,173,203,20,79,5,27,228,155,108,30,54,65,171,105,194,90,61,166,95,225,52,174,26,173,26,183,61,159,157,126,1,233,13,234,98,83,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8b7d7230-b757-4090-bbb0-2b97d1bc90cb"));
		}

		#endregion

	}

	#endregion

}

