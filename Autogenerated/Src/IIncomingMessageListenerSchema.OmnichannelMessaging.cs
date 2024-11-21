namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IIncomingMessageListenerSchema

	/// <exclude/>
	public class IIncomingMessageListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IIncomingMessageListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IIncomingMessageListenerSchema(IIncomingMessageListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e4621d47-b46b-4fa0-8ceb-e6a359374028");
			Name = "IIncomingMessageListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("92ff52b6-dfba-4556-90d8-6f4c37f69c5d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,145,193,74,196,48,16,134,207,91,232,59,12,235,69,47,201,125,93,247,176,158,10,86,139,226,3,196,118,210,13,52,147,144,164,130,200,190,187,217,164,45,181,144,203,76,254,249,248,255,25,18,26,189,21,45,194,185,169,63,140,12,236,217,144,84,253,232,68,80,134,216,155,38,213,94,4,17,14,172,70,239,69,175,168,47,139,223,178,40,139,221,157,195,62,138,160,162,128,78,70,200,1,170,138,90,163,163,38,139,241,213,4,37,21,186,164,231,156,195,209,143,90,11,247,115,154,234,119,180,14,61,82,240,160,102,12,72,227,96,80,62,32,69,82,236,103,36,232,204,244,12,102,24,95,209,236,248,53,168,118,69,217,122,121,73,196,155,151,93,246,191,4,168,49,92,76,231,15,208,36,70,254,220,186,77,141,38,178,141,211,30,68,123,219,15,196,183,181,199,150,225,181,187,220,177,194,9,13,20,151,254,180,159,228,251,211,108,115,1,28,121,210,165,177,111,163,58,248,180,157,8,120,191,28,96,10,52,15,60,60,78,113,144,186,156,40,213,215,124,164,127,205,235,31,85,35,5,73,241,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e4621d47-b46b-4fa0-8ceb-e6a359374028"));
		}

		#endregion

	}

	#endregion

}

