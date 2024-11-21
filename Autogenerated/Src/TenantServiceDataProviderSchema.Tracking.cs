namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TenantServiceDataProviderSchema

	/// <exclude/>
	public class TenantServiceDataProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TenantServiceDataProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TenantServiceDataProviderSchema(TenantServiceDataProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("187f0e27-7e57-4243-a537-36ca44a321f2");
			Name = "TenantServiceDataProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,193,110,219,48,12,61,171,64,255,129,72,47,54,48,216,247,181,9,176,101,195,208,195,186,0,73,119,45,84,155,14,132,217,146,65,73,1,130,160,255,62,90,178,155,216,157,179,28,28,139,126,34,223,123,36,181,108,208,182,178,64,248,186,249,185,53,149,203,214,70,87,106,239,73,58,101,116,182,35,89,252,81,122,127,123,115,186,189,17,222,242,235,5,146,240,254,61,218,157,226,93,88,134,195,56,19,3,25,122,71,184,231,3,172,107,105,237,103,24,178,127,147,78,110,200,28,84,137,20,112,121,158,195,131,245,77,35,233,184,234,207,61,0,148,174,12,53,33,41,84,100,26,112,168,165,118,96,145,14,170,192,108,184,158,95,220,111,253,107,173,10,40,186,178,176,11,248,109,132,95,150,134,57,70,130,197,243,243,157,62,127,105,145,156,66,214,176,33,117,144,14,35,96,202,59,4,182,71,235,176,97,126,206,113,102,11,154,61,7,214,0,175,210,226,132,61,120,170,59,5,31,37,136,54,22,2,235,168,243,59,170,248,82,150,132,214,110,251,220,79,93,234,229,10,22,131,142,136,122,166,122,17,27,32,238,80,151,81,197,53,73,198,97,225,176,140,144,73,225,23,55,228,188,159,149,188,251,32,10,14,178,246,56,43,173,47,56,22,199,37,160,27,59,33,246,232,250,55,161,42,72,34,42,123,180,79,190,174,127,209,247,166,117,199,228,204,43,77,7,176,56,7,251,169,140,67,153,113,79,6,207,178,31,232,126,119,228,146,103,230,203,223,53,83,97,75,62,205,91,156,102,59,179,13,28,146,52,152,192,63,66,231,73,79,221,17,226,13,176,230,54,159,254,7,11,127,225,249,118,189,83,204,144,245,251,194,25,234,122,21,38,251,202,244,173,207,112,48,21,200,184,4,51,141,8,145,86,146,108,194,148,46,23,126,100,201,98,245,200,201,164,230,150,114,170,177,93,217,67,30,46,198,134,198,125,155,221,180,137,213,48,46,147,242,34,118,187,145,76,195,39,248,183,55,49,58,14,114,236,47,66,185,151,99,221,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("187f0e27-7e57-4243-a537-36ca44a321f2"));
		}

		#endregion

	}

	#endregion

}

