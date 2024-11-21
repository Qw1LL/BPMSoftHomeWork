namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImportCreateColumnsSchema

	/// <exclude/>
	public class IFileImportCreateColumnsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImportCreateColumnsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImportCreateColumnsSchema(IFileImportCreateColumnsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("23856807-8b4a-4f1f-8589-38bbae2e4f42");
			Name = "IFileImportCreateColumns";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,142,65,10,194,48,16,69,215,13,228,14,89,42,148,92,192,157,69,161,11,65,40,184,143,97,90,7,146,73,73,38,11,145,222,221,182,22,26,112,247,249,255,205,99,200,120,72,163,177,160,206,247,91,23,122,214,77,160,30,135,28,13,99,32,125,69,7,173,31,67,100,41,62,82,84,57,33,13,5,27,65,95,136,145,17,210,73,138,25,24,243,211,161,85,72,12,177,95,188,237,174,104,34,24,134,38,184,236,41,205,236,34,172,182,105,45,85,73,28,86,241,187,179,47,240,70,197,16,248,23,107,85,14,219,33,252,85,181,42,205,15,227,50,40,187,231,227,252,110,53,73,49,125,1,148,249,139,41,2,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("23856807-8b4a-4f1f-8589-38bbae2e4f42"));
		}

		#endregion

	}

	#endregion

}

