namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FileImportFactorySchema

	/// <exclude/>
	public class FileImportFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FileImportFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FileImportFactorySchema(FileImportFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4c7625a4-8130-4b80-a086-770eb086519c");
			Name = "FileImportFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,65,107,194,64,16,133,207,17,252,15,131,189,36,32,230,110,107,65,173,41,57,88,4,233,169,244,176,110,38,113,33,217,13,179,27,90,41,254,247,78,54,165,106,99,161,13,100,195,206,62,190,121,111,39,90,84,104,107,33,17,22,155,245,214,228,110,178,52,58,87,69,67,194,41,163,39,137,42,49,173,106,67,14,134,131,143,225,32,104,172,210,197,153,152,240,246,106,117,146,8,233,12,41,180,124,206,138,27,194,130,129,0,203,82,88,59,133,19,184,19,30,188,42,142,227,59,165,247,72,202,101,70,130,36,204,103,163,180,167,29,197,247,44,126,121,192,92,52,165,91,40,157,113,251,208,29,106,52,121,216,151,71,99,120,226,156,48,3,205,31,150,244,21,209,235,112,0,252,212,205,174,84,220,184,53,217,247,56,133,62,156,141,180,247,242,29,112,141,110,111,50,78,184,241,40,31,235,31,185,130,86,254,229,34,221,144,170,4,29,86,218,41,119,72,56,38,18,60,162,187,82,14,159,45,18,143,78,163,108,231,6,205,197,118,12,233,210,148,77,165,237,188,40,216,167,224,102,243,76,212,142,121,178,59,216,144,145,104,173,161,8,124,156,246,13,84,14,225,37,105,194,237,83,155,160,112,13,225,74,139,93,137,89,56,226,230,9,58,185,79,12,109,81,144,220,175,222,149,117,157,191,84,159,98,142,162,200,115,125,135,32,32,100,138,6,141,111,112,25,169,101,113,166,159,33,122,86,219,95,47,8,142,126,245,203,175,196,238,146,254,6,100,158,31,40,234,172,155,41,239,186,218,121,233,248,9,194,118,113,17,59,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4c7625a4-8130-4b80-a086-770eb086519c"));
		}

		#endregion

	}

	#endregion

}

