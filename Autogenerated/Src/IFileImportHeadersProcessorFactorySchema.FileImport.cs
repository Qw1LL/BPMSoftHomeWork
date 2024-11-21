namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImportHeadersProcessorFactorySchema

	/// <exclude/>
	public class IFileImportHeadersProcessorFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImportHeadersProcessorFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImportHeadersProcessorFactorySchema(IFileImportHeadersProcessorFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c0f82a9d-1f0d-4e82-bc54-fa38907c8a4f");
			Name = "IFileImportHeadersProcessorFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,193,106,2,49,16,134,207,10,190,195,176,94,90,40,155,123,187,238,161,82,91,15,130,32,62,64,26,103,215,128,155,89,102,146,195,82,250,238,205,198,170,107,107,161,144,75,38,255,124,255,228,79,156,110,80,90,109,16,158,215,171,13,85,62,159,147,171,108,29,88,123,75,46,95,216,3,46,155,150,216,195,199,100,60,10,98,93,61,144,50,62,221,172,230,47,206,91,111,81,226,113,20,180,225,253,96,13,88,231,145,171,222,108,121,225,190,161,222,33,203,154,201,160,8,241,66,27,79,220,245,118,177,115,52,101,172,227,32,176,66,191,167,157,60,194,58,177,142,135,74,41,40,36,52,141,230,174,60,21,230,140,218,35,236,19,23,218,19,55,10,17,193,48,86,179,236,183,125,106,34,206,84,9,85,212,10,5,142,99,138,217,99,163,225,108,165,126,122,21,173,102,221,128,139,41,206,178,32,200,49,61,135,166,143,46,43,183,113,15,230,92,24,248,111,175,149,170,44,84,2,221,230,50,145,223,164,73,178,114,51,28,108,64,76,121,119,223,170,27,60,70,31,216,73,185,116,226,181,139,4,170,254,27,72,161,78,205,61,237,79,37,188,162,63,63,226,221,245,13,225,58,154,7,24,142,11,151,251,221,31,191,203,104,138,110,119,124,247,180,255,156,140,227,250,2,141,102,197,16,171,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c0f82a9d-1f0d-4e82-bc54-fa38907c8a4f"));
		}

		#endregion

	}

	#endregion

}

