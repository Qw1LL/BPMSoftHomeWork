namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DefaultFileImportHeadersProcessorSchema

	/// <exclude/>
	public class DefaultFileImportHeadersProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DefaultFileImportHeadersProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DefaultFileImportHeadersProcessorSchema(DefaultFileImportHeadersProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5d4b90d0-4c5e-4fab-b39c-029dbd674809");
			Name = "DefaultFileImportHeadersProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,77,107,227,48,16,61,167,176,255,97,104,47,9,4,251,158,182,57,212,155,110,3,91,26,8,221,187,34,141,19,129,62,220,145,84,8,165,255,125,199,150,211,184,73,217,194,94,140,231,227,189,121,188,209,56,97,49,52,66,34,220,173,30,215,190,142,69,229,93,173,183,137,68,212,222,21,247,218,224,210,54,158,34,188,253,184,24,165,160,221,22,214,251,16,209,94,159,196,140,52,6,101,11,11,197,47,116,72,90,158,245,252,214,238,229,152,60,206,36,252,58,91,44,92,212,81,99,224,50,55,92,17,110,153,31,42,35,66,152,193,79,172,69,50,241,40,242,1,133,66,10,43,242,18,67,240,212,129,202,178,132,27,237,118,44,40,42,47,65,18,214,183,151,119,34,224,25,176,34,20,209,211,101,57,63,224,66,178,86,208,254,16,51,243,171,86,24,64,229,209,32,91,37,80,123,130,38,15,133,93,166,42,14,12,229,128,162,73,27,163,101,15,250,86,61,204,224,95,42,153,143,119,194,223,163,45,108,125,164,36,185,200,238,172,186,97,185,163,31,252,237,200,241,115,64,98,26,151,23,9,233,83,56,105,169,70,51,216,176,170,241,73,9,222,224,189,87,131,78,101,65,159,213,61,98,220,121,213,10,35,31,25,133,42,215,79,125,254,191,133,193,7,114,104,248,168,57,204,2,255,138,68,188,59,232,158,212,126,45,119,104,5,191,217,100,29,220,107,167,242,239,120,185,112,201,34,137,141,193,155,243,206,57,144,247,113,152,9,83,96,207,219,119,43,187,248,143,48,9,217,141,206,42,194,152,200,157,99,248,174,40,196,39,234,247,49,206,80,184,157,247,92,197,226,37,9,19,250,124,81,137,166,245,120,58,28,49,133,117,215,90,121,219,8,210,129,143,245,137,148,118,194,44,183,142,47,167,98,187,38,147,246,170,70,95,239,37,103,135,201,247,191,147,19,232,210,14,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5d4b90d0-4c5e-4fab-b39c-029dbd674809"));
		}

		#endregion

	}

	#endregion

}

