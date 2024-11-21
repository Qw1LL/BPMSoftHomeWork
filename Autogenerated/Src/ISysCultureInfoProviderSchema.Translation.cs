namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISysCultureInfoProviderSchema

	/// <exclude/>
	public class ISysCultureInfoProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISysCultureInfoProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISysCultureInfoProviderSchema(ISysCultureInfoProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e8d77611-044f-49a7-9b8f-472b0b015ec7");
			Name = "ISysCultureInfoProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,146,203,106,195,48,16,69,215,9,228,31,68,178,105,55,246,62,113,179,168,23,198,208,128,169,251,3,170,53,114,4,214,200,232,81,26,74,255,189,99,9,27,234,82,186,235,70,72,87,231,206,92,61,144,107,112,35,239,128,61,54,151,214,72,159,149,6,165,234,131,229,94,25,204,94,44,71,55,196,249,110,251,177,219,110,130,83,216,179,246,230,60,232,211,106,77,222,97,128,110,130,93,86,1,130,85,29,49,68,29,44,244,164,178,26,61,88,73,237,142,172,38,79,25,6,31,44,212,40,77,99,205,155,18,96,35,62,134,215,65,117,76,205,244,239,240,134,50,209,184,52,184,128,191,26,225,142,172,137,37,210,102,158,231,172,112,65,107,110,111,231,89,168,192,59,230,98,110,214,165,210,212,80,26,171,211,201,23,99,190,118,22,35,183,92,51,164,171,123,216,43,177,63,183,171,42,2,208,43,169,192,102,69,30,217,104,93,157,129,61,3,23,119,85,80,130,12,247,167,127,72,138,2,222,127,134,157,212,191,115,210,83,36,116,78,250,164,156,47,86,232,57,177,51,50,121,74,19,208,47,202,1,80,164,135,138,235,207,244,55,190,137,164,125,1,146,197,72,137,148,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e8d77611-044f-49a7-9b8f-472b0b015ec7"));
		}

		#endregion

	}

	#endregion

}

