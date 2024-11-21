namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IndexingTypeSchema

	/// <exclude/>
	public class IndexingTypeSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IndexingTypeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IndexingTypeSchema(IndexingTypeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9ad4db37-38f8-4550-9801-018f4f9abf1e");
			Name = "IndexingType";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("eef27540-b1e9-466b-87b9-62933f9468f4");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,143,75,106,195,48,16,64,215,49,248,14,115,0,99,95,160,116,209,20,74,22,133,66,218,3,140,173,81,34,208,15,125,104,77,201,221,59,82,210,98,8,14,233,206,30,61,61,189,177,104,40,122,156,8,158,222,94,247,78,166,126,235,172,84,135,28,48,41,103,251,23,237,70,212,123,194,48,29,219,230,187,109,54,195,48,192,67,204,198,96,152,31,47,255,239,179,167,8,78,130,178,130,190,148,61,244,191,224,176,32,125,30,181,154,128,108,54,176,187,128,229,38,31,21,241,149,185,14,42,200,114,4,225,166,108,200,166,226,190,150,111,42,216,181,13,252,67,213,129,68,165,35,40,185,24,194,56,67,58,98,2,37,0,117,32,20,51,112,107,76,204,89,62,161,243,150,43,25,91,190,144,168,227,138,213,142,15,47,24,185,99,165,51,120,211,181,179,145,2,151,45,242,121,25,235,210,95,186,15,20,203,216,113,121,248,84,145,32,87,237,234,155,69,120,243,77,65,154,238,234,127,174,32,127,157,218,230,244,3,239,250,242,248,106,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9ad4db37-38f8-4550-9801-018f4f9abf1e"));
		}

		#endregion

	}

	#endregion

}

