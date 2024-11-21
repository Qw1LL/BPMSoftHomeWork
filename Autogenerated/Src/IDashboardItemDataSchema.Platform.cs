namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IDashboardItemDataSchema

	/// <exclude/>
	public class IDashboardItemDataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDashboardItemDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDashboardItemDataSchema(IDashboardItemDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6b9c62e2-4fb8-44c6-bf30-c17c6dcdc426");
			Name = "IDashboardItemData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,193,74,195,64,16,61,183,208,127,152,163,94,146,15,168,120,48,5,73,81,91,48,34,120,219,164,179,113,213,204,196,221,13,82,75,255,221,201,166,13,33,70,240,178,48,243,222,219,55,243,118,73,85,232,106,85,32,220,108,239,31,89,251,40,97,210,166,108,172,242,134,105,49,63,44,230,179,198,25,42,33,97,139,203,190,122,192,47,207,228,90,197,218,49,69,119,134,62,5,21,60,142,99,184,114,77,85,41,187,191,62,213,41,121,180,186,181,209,108,97,167,220,107,206,202,238,192,120,172,164,244,42,58,11,227,129,178,110,242,15,83,128,233,197,233,234,172,76,69,184,18,157,176,100,66,57,127,217,134,198,147,67,11,5,19,97,209,174,19,65,207,28,250,204,90,90,210,179,130,106,80,30,160,68,191,132,99,231,179,222,228,111,2,64,151,19,140,209,140,223,145,96,171,172,4,43,99,187,49,193,121,27,226,19,120,26,121,54,59,233,102,251,122,140,79,46,216,7,210,69,89,168,58,236,57,189,230,201,33,233,72,255,185,62,51,50,230,55,19,2,107,237,208,255,113,177,188,80,160,190,8,115,19,136,211,153,221,162,111,63,203,197,101,247,83,2,122,252,1,208,166,168,171,131,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6b9c62e2-4fb8-44c6-bf30-c17c6dcdc426"));
		}

		#endregion

	}

	#endregion

}

