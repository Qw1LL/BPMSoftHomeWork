namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PortalColumnAccessListEventListenerSchema

	/// <exclude/>
	public class PortalColumnAccessListEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PortalColumnAccessListEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PortalColumnAccessListEventListenerSchema(PortalColumnAccessListEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("67f28e51-44e9-4af8-8454-8ad240db235e");
			Name = "PortalColumnAccessListEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d7352345-17a4-46e8-b32e-306ac0453d7a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,229,83,77,139,219,48,16,61,123,97,255,195,224,61,108,2,197,190,167,73,32,235,93,232,161,219,6,188,61,149,30,38,210,216,81,145,165,32,201,41,161,244,191,87,31,241,146,108,157,118,233,169,208,139,177,230,227,205,155,247,36,133,29,217,29,50,130,187,245,99,173,27,87,84,90,53,162,237,13,58,161,213,245,213,247,235,171,172,183,66,181,39,5,134,222,142,70,139,7,229,132,19,100,255,144,46,30,246,164,220,165,170,218,165,1,62,123,99,168,245,44,160,146,104,237,12,214,218,56,148,149,150,125,167,86,140,145,181,239,133,117,17,44,252,144,34,19,219,202,178,132,185,237,187,14,205,97,121,60,15,5,208,104,3,183,227,72,183,224,145,132,59,0,69,126,197,0,85,190,192,154,91,34,148,86,3,51,212,44,242,223,237,88,220,161,165,24,59,156,241,204,161,12,104,159,71,82,147,154,109,169,195,15,222,25,88,64,62,78,53,159,126,241,237,187,126,35,5,3,22,228,121,141,58,48,131,11,124,60,152,119,218,127,159,53,127,36,183,213,60,168,30,135,164,228,75,101,99,224,29,42,46,201,14,226,213,184,39,158,36,12,10,254,42,97,138,236,208,96,7,202,111,185,200,45,41,238,53,89,70,74,144,78,197,188,140,37,227,29,148,47,159,182,20,157,56,186,240,52,187,224,67,100,181,106,28,153,8,191,50,173,13,234,131,80,214,161,242,55,159,105,229,80,168,112,17,221,150,134,113,113,1,224,232,240,140,201,81,114,189,39,99,4,39,216,107,193,225,163,138,75,79,244,230,43,177,97,129,55,48,54,26,104,10,225,77,101,217,198,59,81,12,157,67,11,77,195,171,200,178,212,10,187,19,79,253,101,152,164,240,52,85,167,202,186,94,215,196,122,19,28,85,173,80,84,84,146,208,84,232,111,17,95,73,169,191,17,79,0,118,114,10,87,124,178,100,252,99,87,158,177,247,59,205,253,241,122,155,239,73,146,251,255,140,190,79,107,255,149,213,67,239,191,101,246,141,199,79,111,62,158,83,244,60,232,99,63,1,104,211,70,114,41,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("67f28e51-44e9-4af8-8454-8ad240db235e"));
		}

		#endregion

	}

	#endregion

}

