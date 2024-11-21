namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISearchProviderSchema

	/// <exclude/>
	public class ISearchProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISearchProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISearchProviderSchema(ISearchProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce4a57cc-37d9-4a85-b56a-a7ea95f370e8");
			Name = "ISearchProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,145,207,110,131,48,12,198,207,32,241,14,86,123,217,164,9,238,29,227,176,63,154,56,84,98,226,9,2,24,26,9,2,179,147,73,104,234,187,47,36,176,182,219,37,81,252,253,108,127,177,149,24,144,39,81,35,60,23,199,114,108,117,252,50,170,86,118,134,132,150,163,138,194,239,40,12,12,75,213,65,57,179,198,193,234,125,143,245,34,114,252,142,10,73,214,143,81,104,169,61,97,103,163,144,43,141,212,218,146,7,200,75,20,84,159,10,26,191,100,131,228,176,36,73,32,101,51,12,130,230,108,125,123,12,166,149,139,55,44,185,226,38,83,245,178,6,185,85,255,95,60,176,94,237,249,107,228,136,250,52,54,124,128,194,165,122,241,111,251,224,210,159,161,154,225,211,32,205,139,1,39,220,56,240,145,73,144,24,64,217,185,61,237,216,229,125,44,41,187,108,253,132,47,144,38,142,187,164,17,106,67,138,55,138,144,77,175,217,114,155,176,144,249,155,50,3,146,168,122,76,95,165,27,178,237,157,178,38,187,128,7,240,119,150,173,126,239,252,229,218,195,149,149,123,191,143,96,143,170,241,163,112,239,179,223,210,77,240,252,3,220,11,1,223,0,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce4a57cc-37d9-4a85-b56a-a7ea95f370e8"));
		}

		#endregion

	}

	#endregion

}

