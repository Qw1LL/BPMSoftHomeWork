namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ImportEntitySavingEventArgsSchema

	/// <exclude/>
	public class ImportEntitySavingEventArgsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImportEntitySavingEventArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImportEntitySavingEventArgsSchema(ImportEntitySavingEventArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9ddd5a40-8a06-4e75-ab40-8d237a2f6898");
			Name = "ImportEntitySavingEventArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("457f3a21-2903-49a8-8e29-be203e6136ba");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,143,65,10,194,64,12,69,215,45,244,14,3,221,123,0,93,105,81,112,33,20,235,5,198,154,14,3,109,82,38,25,69,196,187,155,182,34,138,32,110,134,228,207,203,255,9,218,14,184,183,53,152,85,185,171,168,145,89,65,216,120,23,131,21,79,56,219,248,22,182,93,79,65,178,244,150,165,73,100,143,206,84,87,22,232,22,89,170,74,30,192,41,105,138,214,50,207,205,4,175,81,188,92,43,123,86,122,125,6,148,101,112,60,226,125,60,182,190,54,245,64,255,130,141,90,97,67,59,96,182,14,222,60,18,93,67,223,87,110,25,168,135,32,30,52,188,28,205,167,255,103,80,244,40,230,64,98,219,61,93,184,160,168,237,112,72,146,56,16,189,64,11,126,22,247,239,65,53,175,117,3,56,253,59,156,3,158,166,197,198,126,82,63,69,213,30,217,166,48,218,118,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9ddd5a40-8a06-4e75-ab40-8d237a2f6898"));
		}

		#endregion

	}

	#endregion

}

