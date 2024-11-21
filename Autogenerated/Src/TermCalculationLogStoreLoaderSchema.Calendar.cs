namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TermCalculationLogStoreLoaderSchema

	/// <exclude/>
	public class TermCalculationLogStoreLoaderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TermCalculationLogStoreLoaderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TermCalculationLogStoreLoaderSchema(TermCalculationLogStoreLoaderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e278331b-3fd3-439e-9087-7f82e26e675d");
			Name = "TermCalculationLogStoreLoader";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("28322dfd-15f8-434e-b343-12da0b1a75f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,82,77,79,194,64,16,61,151,132,255,48,169,23,72,76,123,87,232,65,14,198,4,149,128,31,71,179,46,67,217,164,221,109,118,118,49,104,248,239,78,183,24,1,41,209,120,106,118,222,204,155,247,222,84,139,18,169,18,18,225,106,114,59,51,11,151,140,140,94,168,220,91,225,148,209,221,206,71,183,19,121,82,58,223,105,176,120,121,180,154,204,92,131,49,154,166,41,12,200,151,165,176,235,108,251,158,98,101,145,80,59,130,194,136,57,90,48,11,112,104,75,144,162,144,190,8,43,25,202,9,168,102,74,190,120,210,29,162,202,191,22,74,130,44,4,17,60,240,240,232,123,118,108,242,32,97,28,216,185,185,86,31,85,86,173,132,67,176,40,230,70,23,107,120,36,180,108,83,163,12,11,95,252,222,187,209,31,157,89,204,107,148,1,114,214,75,230,165,11,152,132,237,77,199,161,197,80,184,209,202,41,81,168,119,36,208,248,6,138,167,133,230,124,217,234,128,16,65,90,92,12,227,147,194,227,52,171,173,255,244,222,84,42,97,69,9,154,47,55,140,189,140,179,65,26,42,161,97,155,206,73,250,222,129,127,47,251,16,130,138,14,146,128,33,99,245,169,163,205,54,19,212,243,38,150,253,140,38,214,84,104,157,194,223,36,20,148,80,235,233,91,156,159,54,214,144,110,93,228,232,96,24,134,126,56,74,102,72,196,223,145,144,75,76,158,149,91,142,13,11,168,159,252,51,247,250,205,80,148,92,163,123,18,133,199,65,203,190,172,215,2,36,251,181,176,231,142,47,213,15,49,70,244,127,105,51,116,247,118,138,165,89,97,144,248,87,37,231,176,170,199,26,65,199,239,202,213,205,39,7,96,46,128,25,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e278331b-3fd3-439e-9087-7f82e26e675d"));
		}

		#endregion

	}

	#endregion

}

