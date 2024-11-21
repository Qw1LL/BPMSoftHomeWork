namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SysSettingsValueEventListenerSchema

	/// <exclude/>
	public class SysSettingsValueEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysSettingsValueEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysSettingsValueEventListenerSchema(SysSettingsValueEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b87f92fc-2bfc-4aea-b3b7-8872e42ad5ac");
			Name = "SysSettingsValueEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,79,131,64,16,61,211,196,255,48,105,47,109,210,192,189,86,19,75,122,179,166,9,234,197,120,88,97,74,55,129,93,178,187,96,208,248,223,29,22,105,88,164,218,11,100,190,222,190,247,102,4,203,81,23,44,70,216,236,119,145,60,24,63,148,226,192,211,82,49,195,165,184,154,124,94,77,188,82,115,145,246,26,20,94,143,102,253,173,48,220,112,212,255,148,253,109,133,194,244,186,154,106,84,235,8,141,161,80,195,141,59,231,80,242,123,141,103,17,158,89,86,226,197,48,182,155,176,8,109,166,48,165,42,132,25,211,122,5,195,38,75,252,158,107,131,2,149,29,8,130,0,214,186,204,115,166,234,219,159,216,14,67,161,100,197,19,212,128,86,45,28,153,72,178,134,235,65,42,208,53,97,228,160,59,197,85,131,174,253,14,48,232,33,190,88,219,106,231,233,121,20,31,49,103,15,180,61,82,57,29,210,156,46,94,105,176,40,223,50,30,67,108,217,252,169,4,86,176,97,186,111,160,83,94,143,185,219,80,163,227,160,239,201,180,29,154,163,76,200,182,189,146,6,99,131,73,91,47,186,16,100,133,74,145,41,227,251,10,21,50,131,77,169,149,60,127,210,168,104,107,130,134,27,252,210,9,23,208,220,166,231,41,52,165,18,32,240,125,20,117,62,152,106,110,198,251,58,75,172,146,60,129,187,216,148,44,227,31,23,115,89,90,38,222,168,170,248,132,177,132,246,31,210,41,164,248,88,23,8,228,178,147,232,68,13,144,252,19,35,139,169,7,162,150,206,35,191,48,251,146,103,40,146,118,93,54,110,179,110,146,114,240,13,200,150,90,57,24,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b87f92fc-2bfc-4aea-b3b7-8872e42ad5ac"));
		}

		#endregion

	}

	#endregion

}

