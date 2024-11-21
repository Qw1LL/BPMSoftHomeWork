namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ImportEntitySaveErrorEventArgsSchema

	/// <exclude/>
	public class ImportEntitySaveErrorEventArgsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImportEntitySaveErrorEventArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImportEntitySaveErrorEventArgsSchema(ImportEntitySaveErrorEventArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5beeed51-04c6-4feb-97c6-7d344852fe83");
			Name = "ImportEntitySaveErrorEventArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,142,75,10,131,64,12,134,215,10,222,33,224,222,3,232,170,21,11,93,8,130,39,152,218,56,12,232,140,36,81,16,233,221,59,58,180,216,85,55,129,124,252,47,171,70,228,73,117,8,215,166,110,93,47,89,233,108,111,244,76,74,140,179,217,205,12,120,31,39,71,146,196,91,18,71,51,27,171,161,93,89,112,44,146,216,147,148,80,123,37,64,57,40,230,28,130,186,178,98,100,109,213,130,21,145,163,106,65,43,23,210,124,88,166,249,49,152,14,186,221,240,71,15,57,28,160,70,102,165,241,148,19,237,115,190,237,13,185,9,73,12,250,5,205,17,127,52,125,170,206,37,191,207,6,26,165,0,222,207,43,120,82,180,207,16,235,191,192,206,200,147,55,234,250,233,40,54,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5beeed51-04c6-4feb-97c6-7d344852fe83"));
		}

		#endregion

	}

	#endregion

}

