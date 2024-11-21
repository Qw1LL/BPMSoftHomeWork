namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MultiOperationProviderSchema

	/// <exclude/>
	public class MultiOperationProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MultiOperationProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MultiOperationProviderSchema(MultiOperationProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("13cc5a20-1dd4-486f-abc0-6d6d0a98a042");
			Name = "MultiOperationProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,83,219,78,227,64,12,125,14,18,255,96,193,75,42,85,233,59,80,164,133,237,162,74,20,42,250,1,85,54,113,195,72,115,9,115,41,27,173,248,119,60,153,78,146,94,88,45,47,73,198,246,57,62,118,206,200,92,160,169,243,2,225,110,185,88,169,141,205,238,149,220,176,202,233,220,50,37,207,207,254,158,159,37,206,48,89,193,170,49,22,197,245,193,153,234,57,199,194,23,155,236,1,37,106,86,28,213,60,50,249,214,7,251,78,66,40,73,113,202,92,106,172,136,2,238,121,110,204,21,44,28,183,236,185,198,160,98,169,213,150,149,168,219,202,201,100,2,55,198,9,145,235,230,118,119,142,5,176,81,26,132,199,214,28,65,69,188,201,34,110,50,0,214,238,55,103,5,20,190,227,151,13,19,154,159,158,157,190,95,12,121,73,2,151,154,109,115,139,33,89,135,3,104,204,75,37,121,3,243,125,186,149,165,55,86,13,172,205,238,235,250,36,140,178,126,63,107,148,150,217,230,137,126,205,233,186,71,102,236,205,131,99,229,45,172,53,22,74,151,102,94,134,61,38,151,40,203,160,117,95,56,253,86,162,119,133,85,218,203,111,103,223,169,15,123,56,189,129,244,171,81,226,36,227,168,186,23,61,30,10,236,244,141,192,91,41,73,216,6,210,8,134,233,20,164,227,60,230,18,251,170,213,59,72,124,135,31,186,114,130,56,159,40,61,251,83,96,237,187,167,23,177,255,197,168,93,77,242,49,228,36,25,217,220,120,196,179,158,137,218,54,105,47,106,244,255,61,102,29,232,184,75,55,206,65,163,111,208,191,68,138,125,246,206,27,48,237,150,27,242,3,63,80,238,192,28,73,239,0,152,246,219,110,115,68,252,47,75,44,208,190,170,214,204,3,55,28,94,175,54,240,83,245,151,201,223,165,227,203,20,93,180,101,218,186,156,195,86,177,146,96,157,111,210,184,159,110,204,108,152,29,140,56,30,120,58,44,232,244,24,33,186,31,252,248,4,242,44,127,87,207,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("13cc5a20-1dd4-486f-abc0-6d6d0a98a042"));
		}

		#endregion

	}

	#endregion

}

