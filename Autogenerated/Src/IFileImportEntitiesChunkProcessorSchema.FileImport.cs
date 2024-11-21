namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImportEntitiesChunkProcessorSchema

	/// <exclude/>
	public class IFileImportEntitiesChunkProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImportEntitiesChunkProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImportEntitiesChunkProcessorSchema(IFileImportEntitiesChunkProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cea1c9a4-d455-4ca6-92a0-f145d998b68e");
			Name = "IFileImportEntitiesChunkProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,203,110,131,48,16,60,7,41,255,176,74,46,237,37,220,83,138,212,70,84,229,16,9,41,95,224,192,66,172,6,27,237,26,84,84,245,223,107,108,2,125,41,202,201,242,204,236,236,206,218,74,212,200,141,200,17,158,179,253,65,151,102,179,211,170,148,85,75,194,72,173,54,47,242,140,105,221,104,50,203,224,99,25,44,90,150,170,130,67,207,6,235,135,101,96,145,53,97,101,149,0,169,50,72,165,181,218,66,58,151,37,202,72,35,145,119,167,86,189,101,164,115,100,214,228,42,155,246,120,150,57,200,75,221,45,101,139,97,136,169,103,210,161,50,12,91,200,156,213,64,225,0,121,226,85,168,226,140,20,125,115,236,15,162,195,194,177,79,84,113,12,127,56,31,234,22,155,132,72,211,21,43,199,143,118,107,84,133,159,121,188,147,15,176,71,115,210,5,207,1,6,50,12,67,136,184,173,107,65,125,124,1,146,119,204,91,131,32,93,23,176,93,221,126,224,216,67,35,152,177,176,7,217,199,180,187,228,205,228,18,254,182,137,156,10,148,85,62,174,188,87,54,213,173,226,40,116,188,147,119,90,22,48,174,222,61,195,157,79,56,235,199,97,102,224,254,255,184,159,254,163,252,0,45,246,5,209,152,65,255,124,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cea1c9a4-d455-4ca6-92a0-f145d998b68e"));
		}

		#endregion

	}

	#endregion

}

