namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SysSettingsRightsEventListenerSchema

	/// <exclude/>
	public class SysSettingsRightsEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysSettingsRightsEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysSettingsRightsEventListenerSchema(SysSettingsRightsEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("42f59b37-f248-46d7-8658-207f7a813139");
			Name = "SysSettingsRightsEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,79,131,64,16,61,211,164,255,97,210,94,218,164,129,123,173,38,150,244,102,77,35,122,50,30,86,152,194,38,176,75,118,23,12,26,255,187,195,98,27,182,165,218,11,100,190,222,190,247,102,4,43,80,151,44,70,88,239,182,145,220,27,63,148,98,207,211,74,49,195,165,24,143,190,198,35,175,210,92,164,189,6,133,55,131,89,127,35,12,55,28,245,63,101,127,83,163,48,189,174,182,26,53,58,66,99,40,212,112,235,206,57,148,252,94,227,69,132,39,158,102,230,122,156,174,157,208,8,111,170,48,165,50,132,57,211,122,9,103,93,150,251,3,215,6,5,42,59,17,4,1,172,116,85,20,76,53,119,191,177,157,134,82,201,154,39,168,1,173,96,200,152,72,242,150,238,94,42,208,13,97,20,160,15,162,149,133,247,15,128,65,15,241,213,58,215,56,79,207,162,56,195,130,61,210,2,73,231,228,140,231,100,254,70,147,101,245,158,243,24,98,75,231,111,45,176,132,53,211,125,23,157,242,106,208,226,150,29,157,8,125,143,198,109,209,100,50,33,235,118,74,26,140,13,38,93,189,60,132,32,107,84,138,124,185,176,181,80,33,51,216,214,58,217,179,23,141,138,118,39,104,186,125,160,114,194,57,180,39,234,121,10,77,165,4,8,252,24,134,157,157,140,181,183,227,125,95,164,86,75,158,192,125,108,42,150,243,207,171,201,44,192,114,241,134,133,197,71,148,5,116,255,144,46,34,197,231,166,68,32,171,157,196,65,215,9,148,127,228,52,40,107,225,60,114,134,217,23,61,69,145,116,43,179,113,151,117,147,148,131,31,189,174,38,28,34,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("42f59b37-f248-46d7-8658-207f7a813139"));
		}

		#endregion

	}

	#endregion

}

