namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FileImportHeadersProcessorFactorySchema

	/// <exclude/>
	public class FileImportHeadersProcessorFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FileImportHeadersProcessorFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FileImportHeadersProcessorFactorySchema(FileImportHeadersProcessorFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f308309d-78f0-4eae-9765-b45ee0dd84b7");
			Name = "FileImportHeadersProcessorFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,75,195,64,16,61,167,208,255,48,228,148,64,73,238,218,10,182,90,237,65,41,84,79,226,97,221,76,218,133,100,55,204,238,86,130,244,191,187,73,19,251,17,75,64,33,95,59,51,111,230,205,155,137,100,57,234,130,113,132,233,242,105,165,82,19,205,148,76,197,218,18,51,66,201,104,46,50,92,228,133,34,3,95,195,129,103,181,144,235,163,80,194,235,95,173,209,189,52,194,8,212,23,220,115,198,141,162,189,223,69,196,113,12,99,109,243,156,81,121,211,158,133,220,32,9,147,40,14,156,48,157,248,139,3,153,71,100,9,146,94,146,226,168,181,162,125,190,210,143,91,180,243,108,69,130,192,51,166,53,164,138,170,28,204,32,108,106,36,20,45,178,173,22,31,149,127,187,195,148,217,204,76,133,76,28,245,192,148,5,170,52,232,175,31,142,224,217,9,10,19,144,238,229,32,253,136,240,221,21,44,236,71,38,120,67,182,23,115,5,253,76,234,105,185,171,35,237,63,181,237,138,213,146,239,102,152,85,138,59,229,31,208,252,36,11,94,53,146,91,49,137,188,218,47,176,39,199,17,212,123,83,174,248,6,115,6,164,148,217,127,134,117,63,158,183,101,116,6,185,165,181,174,244,198,79,112,70,109,200,86,108,157,213,230,40,77,224,159,70,251,163,51,120,88,45,168,231,137,20,130,67,181,104,63,196,9,248,171,82,191,16,147,58,171,255,6,191,165,225,17,26,75,18,102,213,192,26,125,34,215,230,248,52,254,178,166,55,65,183,139,134,202,174,126,94,42,208,108,230,95,50,87,137,221,61,28,236,190,1,133,205,227,76,245,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f308309d-78f0-4eae-9765-b45ee0dd84b7"));
		}

		#endregion

	}

	#endregion

}

