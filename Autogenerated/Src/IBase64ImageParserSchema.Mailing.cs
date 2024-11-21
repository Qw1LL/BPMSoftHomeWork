namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IBase64ImageParserSchema

	/// <exclude/>
	public class IBase64ImageParserSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBase64ImageParserSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBase64ImageParserSchema(IBase64ImageParserSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d22fb757-667d-4ac9-b5bd-1e09eb515bb0");
			Name = "IBase64ImageParser";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5d774dd3-3f0d-4e5d-9409-9a3b17d3417e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,106,195,48,12,61,183,208,127,16,233,101,131,145,92,198,14,91,155,67,199,96,129,21,74,219,31,112,51,57,51,36,118,144,236,149,50,250,239,83,146,166,4,90,198,216,78,198,66,239,233,189,39,219,170,10,185,86,57,194,98,181,220,56,237,227,103,103,181,41,2,41,111,156,141,151,202,148,198,22,147,241,215,100,60,154,18,22,82,132,204,122,36,45,160,71,200,22,138,241,225,62,171,84,129,43,69,140,52,25,75,103,146,36,48,227,80,85,138,14,233,233,190,198,154,144,209,122,6,211,19,128,118,4,181,224,100,6,188,110,151,111,45,209,75,137,149,244,1,187,64,210,35,221,14,206,164,136,144,19,234,121,244,163,224,120,160,43,74,210,184,135,39,3,81,117,216,149,38,31,136,185,102,102,212,24,191,240,211,22,100,240,39,146,216,241,31,8,236,169,241,64,189,201,86,13,56,13,202,130,105,8,101,14,168,198,198,127,125,92,26,233,42,18,163,170,192,202,66,231,17,83,30,165,155,46,190,161,6,9,50,239,84,199,179,164,5,92,199,183,221,81,154,89,246,202,118,28,141,201,63,170,6,163,207,198,251,101,239,21,3,135,60,71,102,29,202,59,112,194,79,123,195,8,54,148,229,165,58,66,31,200,114,186,238,78,240,20,36,82,253,11,62,173,74,70,33,236,25,26,202,157,115,37,108,233,208,110,249,230,180,59,9,77,112,193,195,64,125,151,219,237,147,128,142,237,203,158,162,125,239,190,65,115,61,126,3,221,198,171,123,64,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d22fb757-667d-4ac9-b5bd-1e09eb515bb0"));
		}

		#endregion

	}

	#endregion

}

