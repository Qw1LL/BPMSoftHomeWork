namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PortalSchemaAccessListEventListenerSchema

	/// <exclude/>
	public class PortalSchemaAccessListEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PortalSchemaAccessListEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PortalSchemaAccessListEventListenerSchema(PortalSchemaAccessListEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9f33f8d7-fd5c-42c2-b59b-96e61f427ef7");
			Name = "PortalSchemaAccessListEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d7352345-17a4-46e8-b32e-306ac0453d7a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,229,83,77,139,219,48,16,61,123,97,255,195,224,61,108,2,197,190,167,73,32,235,93,232,161,219,6,188,61,149,30,38,210,216,81,145,165,32,201,41,161,244,191,87,31,241,146,108,157,118,233,169,208,139,177,230,227,205,155,247,36,133,29,217,29,50,130,187,245,99,173,27,87,84,90,53,162,237,13,58,161,213,245,213,247,235,171,172,183,66,181,39,5,134,222,142,70,139,7,229,132,19,100,255,144,46,30,246,164,220,165,170,218,165,1,62,123,99,168,245,44,160,146,104,237,12,214,218,56,148,53,219,82,135,43,198,200,218,247,194,186,8,22,126,72,145,137,109,101,89,194,220,246,93,135,230,176,60,158,135,2,104,180,129,219,113,164,91,240,72,194,29,128,34,191,98,128,42,95,96,205,45,17,74,171,129,25,106,22,249,239,118,44,238,208,82,140,29,206,120,230,80,6,180,207,35,169,73,162,245,193,59,3,11,200,199,169,230,211,47,190,125,215,111,164,96,192,130,60,175,81,7,102,112,129,143,7,243,78,251,239,179,230,143,228,182,154,7,213,227,144,148,124,169,108,12,188,67,197,37,217,65,188,26,247,196,147,132,65,193,95,37,76,145,29,26,236,64,249,45,23,185,37,197,189,38,203,72,9,210,169,152,151,177,100,188,131,242,229,211,150,162,19,71,23,158,102,23,124,136,172,86,141,35,19,225,87,166,181,65,125,16,202,58,84,254,230,51,173,28,10,21,46,162,219,210,48,46,46,0,28,29,158,49,57,74,174,247,100,140,224,4,123,45,56,124,84,113,233,137,222,124,37,54,44,240,6,198,70,3,77,33,188,169,44,219,120,39,138,161,115,104,161,105,120,21,89,150,90,97,119,226,169,191,12,147,20,158,166,234,84,89,215,235,154,88,111,130,163,170,21,138,138,74,18,154,10,125,19,95,73,169,191,17,175,180,236,59,101,39,167,112,197,39,75,198,63,118,229,25,123,191,211,220,31,175,183,249,158,36,185,255,207,232,251,180,246,95,89,61,244,254,91,102,223,120,252,244,230,227,57,69,207,131,62,246,19,58,24,158,94,41,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9f33f8d7-fd5c-42c2-b59b-96e61f427ef7"));
		}

		#endregion

	}

	#endregion

}

