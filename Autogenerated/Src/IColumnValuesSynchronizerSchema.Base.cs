namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IColumnValuesSynchronizerSchema

	/// <exclude/>
	public class IColumnValuesSynchronizerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IColumnValuesSynchronizerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IColumnValuesSynchronizerSchema(IColumnValuesSynchronizerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("27011a19-7509-4ec0-bb21-cf388cf23492");
			Name = "IColumnValuesSynchronizer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("dd282faf-27c2-4fbe-9d4d-aa5a0b526cd3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,80,205,106,195,48,12,62,167,208,119,16,244,178,65,201,3,172,99,135,253,210,67,97,16,216,221,115,148,84,224,200,193,178,7,89,233,187,87,137,219,165,236,176,227,46,6,89,223,175,216,116,40,189,177,8,143,239,187,202,55,177,124,242,220,80,155,130,137,228,185,124,225,72,113,168,6,182,251,224,153,190,167,223,229,226,176,92,20,73,136,91,168,6,137,216,41,203,57,180,227,82,202,55,100,12,100,55,63,152,89,58,96,86,36,20,93,43,96,21,176,85,18,108,57,98,104,52,199,29,108,85,43,117,252,97,92,66,153,157,49,76,132,62,125,58,178,64,23,252,95,240,66,99,234,91,124,121,170,225,106,117,137,112,147,219,129,248,20,44,174,225,60,214,40,145,120,106,186,30,233,197,104,113,110,119,255,235,20,217,124,103,250,94,139,62,128,189,30,229,54,119,204,254,175,228,220,243,172,156,189,254,41,193,49,223,26,185,206,231,30,199,227,9,171,54,52,152,251,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("27011a19-7509-4ec0-bb21-cf388cf23492"));
		}

		#endregion

	}

	#endregion

}

