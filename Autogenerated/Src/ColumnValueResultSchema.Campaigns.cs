namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ColumnValueResultSchema

	/// <exclude/>
	public class ColumnValueResultSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ColumnValueResultSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ColumnValueResultSchema(ColumnValueResultSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3673988a-b579-40b7-b4e0-255d21d4b2d7");
			Name = "ColumnValueResult";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,147,201,78,195,48,16,134,207,169,212,119,24,133,11,92,154,59,93,14,68,21,234,1,169,162,42,119,215,157,4,163,196,54,94,10,165,234,187,227,37,105,232,6,92,172,120,60,51,255,55,191,29,78,106,212,146,80,132,135,249,211,66,20,102,144,11,94,176,210,42,98,152,224,131,156,212,146,176,146,235,126,111,215,239,37,86,51,94,194,98,171,13,214,195,126,207,69,110,20,150,46,17,242,138,104,125,15,185,168,108,205,95,72,101,241,25,181,173,76,72,202,178,12,70,218,214,53,81,219,73,179,143,199,32,10,160,161,6,54,190,8,24,55,168,164,66,183,66,33,20,120,193,10,155,156,65,219,43,251,209,76,218,85,197,40,80,15,112,73,63,113,224,110,237,72,5,215,70,89,106,132,114,192,243,80,29,51,78,49,67,96,198,153,97,164,98,95,232,206,208,145,40,44,198,233,153,78,154,77,28,187,54,132,83,244,152,231,156,49,34,137,34,53,112,103,251,56,141,67,45,103,235,116,178,228,236,221,79,191,70,110,88,193,220,240,206,24,243,122,24,124,148,133,194,208,167,25,248,12,225,246,209,178,53,28,154,222,129,191,177,36,201,219,0,140,187,67,119,121,73,178,111,140,65,190,142,222,28,27,53,87,66,162,50,12,255,99,211,212,113,155,109,123,151,78,225,138,9,13,124,64,237,200,118,80,162,25,130,84,108,67,12,130,246,155,134,238,162,90,172,140,79,230,119,33,177,122,67,106,32,216,212,202,252,217,222,77,78,81,135,183,142,159,20,165,255,21,128,249,11,81,226,35,188,194,235,130,211,67,65,247,117,65,247,196,244,24,61,14,238,191,1,169,232,5,100,157,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3673988a-b579-40b7-b4e0-255d21d4b2d7"));
		}

		#endregion

	}

	#endregion

}

