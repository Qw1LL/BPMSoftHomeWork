namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImporterSchema

	/// <exclude/>
	public class IFileImporterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImporterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImporterSchema(IFileImporterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fa525843-9e33-4417-81db-be5e451e98f6");
			Name = "IFileImporter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,77,111,194,48,12,134,207,84,234,127,176,216,5,46,173,56,76,147,160,67,2,196,52,14,104,104,236,54,237,16,90,183,68,106,147,202,73,153,208,198,127,95,154,14,202,199,90,237,22,231,181,31,219,111,82,40,46,18,88,239,149,198,108,228,58,174,35,88,134,42,103,33,194,116,181,92,203,88,123,51,41,98,158,20,196,52,151,194,123,226,41,46,178,92,146,118,157,47,215,233,228,197,38,229,33,112,161,145,226,178,108,81,103,32,193,16,22,83,166,240,252,206,20,149,133,29,223,247,33,80,69,150,49,218,143,143,23,107,182,67,224,54,19,118,44,45,80,129,150,16,109,32,150,4,10,25,133,91,64,161,185,230,168,78,16,255,154,18,228,140,88,6,229,46,143,93,123,70,211,88,117,199,129,111,163,58,145,80,23,36,148,17,142,167,82,122,127,217,40,153,154,154,94,247,193,27,220,123,3,248,134,183,45,130,193,108,101,4,92,65,132,57,97,200,52,70,94,183,255,81,214,108,164,76,237,248,175,236,179,90,117,254,59,103,175,10,87,167,57,160,30,169,111,77,239,116,238,8,19,99,47,204,119,102,59,53,132,149,181,181,210,176,188,171,148,103,38,162,20,41,56,107,176,55,61,205,27,90,121,66,137,26,195,173,56,250,47,8,231,68,146,154,89,149,222,140,155,162,121,39,188,92,223,150,213,196,166,148,102,232,36,54,78,181,50,39,127,103,180,172,45,98,185,68,165,88,114,142,185,36,44,145,146,54,196,149,51,81,139,107,81,51,102,38,211,34,19,43,146,161,25,231,218,253,91,241,248,93,80,68,213,143,177,241,193,117,14,63,85,52,202,234,202,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fa525843-9e33-4417-81db-be5e451e98f6"));
		}

		#endregion

	}

	#endregion

}

