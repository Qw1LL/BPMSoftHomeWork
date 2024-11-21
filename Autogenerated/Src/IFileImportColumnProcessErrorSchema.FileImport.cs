namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImportColumnProcessErrorSchema

	/// <exclude/>
	public class IFileImportColumnProcessErrorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImportColumnProcessErrorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImportColumnProcessErrorSchema(IFileImportColumnProcessErrorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("27561062-e504-4d29-b9de-042dd1879b77");
			Name = "IFileImportColumnProcessError";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,141,65,10,194,48,20,68,215,13,228,14,57,65,47,160,8,90,42,118,81,40,244,4,49,254,132,64,242,127,249,73,4,41,189,187,109,93,40,184,153,197,204,188,25,212,17,210,164,13,168,203,208,143,100,115,221,16,90,239,10,235,236,9,235,171,15,208,197,137,56,75,49,75,81,149,228,209,169,241,149,50,196,131,20,171,51,149,123,240,70,121,204,192,118,27,234,190,76,67,161,68,28,152,12,164,212,50,19,175,192,172,118,174,130,39,96,86,237,166,55,141,143,0,124,252,239,239,241,153,93,58,169,95,251,115,189,72,177,188,1,142,104,124,145,193,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("27561062-e504-4d29-b9de-042dd1879b77"));
		}

		#endregion

	}

	#endregion

}

