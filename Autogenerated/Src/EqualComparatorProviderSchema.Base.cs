namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EqualComparatorProviderSchema

	/// <exclude/>
	public class EqualComparatorProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EqualComparatorProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EqualComparatorProviderSchema(EqualComparatorProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ebef606a-f1e5-4bdb-b9fe-2515dda709fc");
			Name = "EqualComparatorProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,84,203,74,195,64,20,93,167,208,127,184,34,72,10,146,236,173,85,176,45,226,66,45,86,220,143,201,77,29,73,102,226,60,132,248,248,119,39,51,147,152,166,169,11,65,55,13,115,238,61,231,220,23,101,164,64,89,146,4,225,98,117,189,230,153,138,230,156,101,116,163,5,81,148,179,104,201,20,85,213,186,98,201,147,224,140,190,89,116,60,122,31,143,198,163,64,75,202,54,176,174,164,194,98,106,145,67,129,27,147,0,243,156,72,121,2,203,23,77,242,57,47,74,98,228,184,88,9,254,74,83,20,54,53,142,99,56,149,186,40,136,168,206,252,219,39,72,72,90,142,132,140,11,72,105,150,161,64,166,64,85,37,202,168,225,199,29,129,82,63,230,52,129,164,182,222,231,12,39,112,181,183,168,192,117,213,54,113,141,234,137,167,166,141,149,85,118,193,126,217,22,184,67,165,5,147,128,181,116,167,120,91,187,84,194,140,169,46,121,183,102,135,8,71,63,251,46,42,58,141,27,176,206,242,173,245,214,48,231,185,46,204,111,235,118,137,106,109,205,122,45,134,19,48,173,5,65,224,52,33,197,28,55,68,97,200,31,159,49,81,32,185,22,9,62,144,92,227,49,120,204,108,65,81,102,125,108,160,145,104,52,194,14,9,14,102,192,116,158,195,209,209,14,175,27,235,80,34,91,162,12,119,108,38,206,37,248,248,48,22,110,114,87,242,198,8,220,138,101,81,170,42,244,232,164,35,54,177,226,63,37,239,218,152,123,53,46,159,246,243,249,219,213,166,102,136,247,180,192,127,90,238,194,216,253,229,106,23,190,157,115,79,107,222,48,131,176,141,117,7,63,237,243,58,210,195,228,190,247,116,232,168,22,13,117,248,174,250,97,127,49,237,129,53,241,200,93,90,253,28,56,183,129,172,237,227,235,141,224,231,82,124,120,232,172,14,145,165,238,31,197,190,29,186,13,26,236,11,250,8,83,115,137,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ebef606a-f1e5-4bdb-b9fe-2515dda709fc"));
		}

		#endregion

	}

	#endregion

}

