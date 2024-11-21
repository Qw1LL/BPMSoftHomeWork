namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImportCanProcessSchema

	/// <exclude/>
	public class IFileImportCanProcessSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImportCanProcessSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImportCanProcessSchema(IFileImportCanProcessSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0ebbb19c-387f-4ea6-9d4f-066fbfef8b64");
			Name = "IFileImportCanProcess";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,143,193,10,131,48,12,134,207,22,250,14,61,110,23,95,96,183,185,13,60,12,4,159,160,118,209,5,218,68,218,244,48,198,222,125,234,4,7,66,14,225,231,251,191,16,178,1,210,104,29,152,115,115,111,185,151,178,98,234,113,200,209,10,50,149,55,244,80,135,145,163,104,245,214,170,200,9,105,248,99,35,148,87,18,20,132,116,210,106,2,198,220,121,116,6,73,32,246,179,183,222,20,149,165,38,178,131,148,38,112,182,21,29,179,55,91,124,88,92,175,214,61,33,216,138,125,14,100,96,23,29,127,151,118,229,245,200,194,92,32,9,210,242,131,121,108,251,90,253,104,53,205,23,28,80,247,79,252,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0ebbb19c-387f-4ea6-9d4f-066fbfef8b64"));
		}

		#endregion

	}

	#endregion

}

