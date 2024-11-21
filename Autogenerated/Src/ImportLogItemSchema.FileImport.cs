namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ImportLogItemSchema

	/// <exclude/>
	public class ImportLogItemSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImportLogItemSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImportLogItemSchema(ImportLogItemSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("567fdcd5-bfe6-4534-8033-3043e6eaac3e");
			Name = "ImportLogItem";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1101e5cd-b945-4f88-8001-faccb4fdb24c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,221,106,194,64,16,133,175,87,240,29,6,123,211,222,152,123,91,5,43,22,4,5,193,190,192,186,157,164,75,179,63,236,78,160,161,244,221,59,155,141,212,216,34,222,132,201,228,48,231,59,51,177,210,96,244,82,33,60,239,119,7,87,210,116,229,108,169,171,38,72,210,206,78,95,116,141,27,227,93,160,241,232,107,60,18,77,212,182,130,67,27,9,205,227,120,196,157,187,128,21,43,97,85,203,24,103,144,197,91,87,109,88,209,9,138,162,128,167,216,24,35,67,187,232,223,151,22,180,141,36,45,27,187,18,232,93,71,80,105,0,112,17,152,200,217,168,143,53,66,233,2,68,114,33,185,234,110,52,212,142,75,203,31,76,70,60,89,20,103,30,190,57,214,90,245,35,7,72,192,136,23,140,130,131,241,243,55,9,155,83,104,20,219,206,96,223,77,202,130,203,36,93,99,21,80,18,198,97,158,214,35,43,17,65,5,44,231,147,129,225,164,88,36,230,191,208,39,234,129,250,254,1,210,222,133,56,144,84,31,175,33,157,106,206,43,73,27,153,174,141,167,150,207,32,196,119,31,1,237,91,78,49,140,180,15,206,99,32,141,241,134,68,91,94,48,255,21,81,86,120,29,52,83,192,46,107,123,206,10,169,35,18,177,47,122,180,127,173,214,159,10,125,186,34,207,226,120,64,41,223,77,166,103,235,184,238,123,177,146,220,61,111,114,231,7,201,61,240,172,6,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("567fdcd5-bfe6-4534-8033-3043e6eaac3e"));
		}

		#endregion

	}

	#endregion

}

