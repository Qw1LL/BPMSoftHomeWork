namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LoggingFileImporterSchema

	/// <exclude/>
	public class LoggingFileImporterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LoggingFileImporterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LoggingFileImporterSchema(LoggingFileImporterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("10ecd8e5-f4a7-4119-9170-ce80b8367b66");
			Name = "LoggingFileImporter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,84,193,106,227,48,16,61,187,208,127,16,217,139,115,241,7,164,44,101,55,164,37,208,208,64,104,47,203,178,40,246,68,43,176,53,102,36,231,82,250,239,59,146,181,205,166,18,222,148,30,146,200,227,247,230,189,55,35,98,100,7,182,151,53,136,239,219,205,14,15,174,90,162,57,104,53,144,116,26,77,117,167,91,88,119,61,146,187,190,122,185,190,42,6,171,141,18,170,197,189,108,23,139,37,118,29,131,30,80,41,46,223,188,189,63,245,34,200,87,171,59,89,59,36,13,150,223,51,226,11,129,98,61,177,108,165,181,11,17,59,158,212,129,2,236,199,227,17,136,116,3,63,249,161,31,246,173,174,69,237,41,57,134,88,136,243,6,5,39,224,239,147,24,26,235,104,240,70,88,115,27,218,141,136,216,58,211,180,124,178,64,76,52,80,251,1,137,225,236,113,206,154,123,105,161,124,95,246,179,43,94,163,60,152,102,116,112,110,103,75,216,3,57,158,9,155,33,116,204,133,38,250,33,125,148,14,196,154,29,137,95,45,134,89,115,53,130,198,186,255,4,157,66,129,139,167,130,192,13,100,2,71,220,222,138,50,28,190,122,236,70,26,169,128,170,123,112,62,39,71,155,213,97,159,223,250,158,29,2,205,230,243,32,227,125,255,215,252,6,220,111,108,114,206,255,122,196,184,58,113,68,205,142,195,60,203,241,103,43,137,239,33,79,215,138,254,237,24,135,86,176,185,106,109,14,88,206,70,240,206,73,114,179,104,205,15,187,138,189,254,161,222,100,153,43,211,68,222,235,180,185,13,144,138,27,95,25,167,253,74,62,230,52,211,32,181,157,83,153,200,144,129,95,28,136,151,82,131,181,75,108,135,206,60,203,118,248,104,160,76,131,52,80,78,101,34,80,6,126,113,160,181,209,238,51,11,74,249,153,107,149,106,76,93,177,4,189,186,52,204,78,30,63,117,219,82,126,26,38,163,49,17,38,69,39,97,222,253,17,140,213,243,34,215,254,0,55,193,109,151,96,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("10ecd8e5-f4a7-4119-9170-ce80b8367b66"));
		}

		#endregion

	}

	#endregion

}

