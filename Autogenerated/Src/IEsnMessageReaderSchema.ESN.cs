namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IEsnMessageReaderSchema

	/// <exclude/>
	public class IEsnMessageReaderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEsnMessageReaderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEsnMessageReaderSchema(IEsnMessageReaderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("06f8b050-f68f-4336-acf7-4f1801ecd769");
			Name = "IEsnMessageReader";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,85,201,110,219,48,16,61,219,128,255,97,160,94,90,160,144,238,173,35,160,117,93,67,135,52,65,220,31,96,196,145,77,68,28,26,28,178,129,81,244,223,203,69,138,221,44,133,19,160,203,73,212,112,230,205,123,143,27,9,141,188,19,45,194,199,203,243,181,233,92,185,48,212,169,141,183,194,41,67,229,114,253,101,54,253,62,155,78,60,43,218,192,122,207,14,245,251,123,255,161,166,239,177,141,5,92,174,144,208,170,246,144,179,48,22,203,37,57,229,20,114,8,135,137,87,22,55,33,25,160,33,135,182,11,237,223,65,179,100,58,71,102,177,193,43,20,18,109,202,172,170,10,230,236,181,22,118,95,15,255,151,214,124,83,18,25,52,186,173,145,12,157,177,192,166,85,162,7,66,119,107,236,13,216,0,17,155,235,140,200,229,136,85,29,129,237,252,117,175,90,80,35,137,199,56,76,162,248,7,52,82,96,133,14,90,163,53,82,252,142,14,36,54,67,219,216,245,97,219,28,217,9,43,52,80,240,255,172,24,210,27,89,212,67,123,80,178,156,87,41,231,80,98,209,121,75,92,207,25,17,90,139,221,89,145,124,221,23,85,173,136,157,160,160,225,192,36,0,140,21,17,162,89,146,215,104,197,117,143,243,92,86,67,84,185,200,18,248,245,202,43,57,50,111,228,155,188,84,79,75,255,119,26,239,9,203,243,73,203,128,252,66,41,112,171,220,22,68,223,71,19,189,38,6,76,208,255,163,196,15,125,191,200,36,243,220,115,37,183,91,79,55,119,199,35,109,218,231,137,205,217,81,235,64,78,255,70,242,113,97,60,154,23,187,116,89,20,245,213,112,78,77,14,192,177,39,76,71,122,199,10,168,234,191,117,48,242,248,151,45,53,138,126,11,143,178,75,215,206,48,126,201,10,120,70,11,29,162,60,117,17,236,159,243,242,112,167,131,233,238,22,247,211,215,139,167,113,195,228,128,121,138,189,159,131,206,209,220,147,220,156,252,200,143,7,146,204,239,199,108,26,34,63,1,126,99,200,61,194,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("06f8b050-f68f-4336-acf7-4f1801ecd769"));
		}

		#endregion

	}

	#endregion

}

