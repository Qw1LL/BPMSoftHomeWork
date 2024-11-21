namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FileImportStagesEnumSchema

	/// <exclude/>
	public class FileImportStagesEnumSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FileImportStagesEnumSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FileImportStagesEnumSchema(FileImportStagesEnumSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bb4174ad-6f70-437d-9b0f-36d3b9a6d06b");
			Name = "FileImportStagesEnum";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,205,77,10,194,48,16,134,225,117,3,189,67,14,32,5,127,182,110,12,21,92,8,133,158,32,134,105,25,72,102,66,50,89,73,239,110,212,133,162,221,126,239,3,31,217,0,57,90,7,250,52,92,71,158,164,51,76,19,206,37,89,65,166,238,140,30,46,33,114,146,86,221,91,213,196,114,243,232,52,80,9,250,211,70,177,51,228,190,142,149,60,89,51,36,136,54,193,15,209,71,189,221,188,51,59,200,217,176,47,129,242,191,218,125,171,158,4,5,97,133,237,95,204,112,136,30,100,229,236,80,243,210,170,229,1,148,65,51,100,230,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bb4174ad-6f70-437d-9b0f-36d3b9a6d06b"));
		}

		#endregion

	}

	#endregion

}

