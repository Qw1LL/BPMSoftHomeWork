namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FileImporterFactorySchema

	/// <exclude/>
	public class FileImporterFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FileImporterFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FileImporterFactorySchema(FileImporterFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a32b6e83-4c3b-c886-59ec-834898926b24");
			Name = "FileImporterFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,77,107,195,48,12,134,207,41,244,63,136,156,18,40,201,125,107,11,75,183,142,28,54,10,99,167,177,131,155,202,157,33,177,131,108,111,148,209,255,62,185,107,104,90,50,232,14,249,144,252,234,209,107,217,90,52,104,91,81,33,20,171,167,23,35,93,182,48,90,170,173,39,225,148,209,217,82,213,88,54,173,33,55,30,125,143,71,145,183,74,111,123,90,194,219,193,108,182,20,149,51,164,208,242,58,43,242,60,135,169,210,31,72,202,109,76,5,21,161,156,197,229,9,143,244,91,177,139,243,121,167,183,190,105,4,237,186,152,133,53,54,168,157,5,165,185,64,6,219,210,80,128,9,199,191,12,3,117,164,117,140,188,7,121,187,71,41,124,237,10,165,55,108,56,113,187,22,141,76,134,92,164,19,120,230,209,192,12,52,127,88,52,164,73,223,25,218,250,117,173,120,67,181,176,22,6,84,112,3,67,13,184,50,204,243,223,131,233,250,149,133,176,216,87,193,35,186,126,156,188,90,36,62,76,141,85,56,73,240,103,97,10,135,238,209,167,160,139,149,59,218,218,176,109,252,2,78,90,71,62,116,231,172,15,163,79,226,115,117,60,185,4,135,251,16,69,74,66,114,190,144,177,191,210,46,249,164,60,225,131,22,235,26,55,73,204,38,87,72,86,89,199,240,147,253,56,237,12,70,132,92,160,97,17,230,123,156,68,64,77,203,161,58,164,249,69,219,176,157,163,167,253,225,253,39,239,58,74,128,240,179,255,1,220,23,138,72,57,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a32b6e83-4c3b-c886-59ec-834898926b24"));
		}

		#endregion

	}

	#endregion

}

