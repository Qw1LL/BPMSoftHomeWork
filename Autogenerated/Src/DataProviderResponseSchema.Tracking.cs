namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DataProviderResponseSchema

	/// <exclude/>
	public class DataProviderResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DataProviderResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DataProviderResponseSchema(DataProviderResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("128127f7-43f7-4cf4-9f1d-06f7c505c1c3");
			Name = "DataProviderResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,203,78,195,64,12,69,215,141,148,127,176,202,62,217,243,232,130,194,178,82,84,248,1,51,113,210,17,141,39,178,39,69,168,226,223,241,228,129,34,96,51,146,239,216,215,231,154,177,35,237,209,17,60,86,135,151,208,196,98,31,184,241,237,32,24,125,224,226,85,208,189,123,110,243,236,154,103,121,182,185,17,106,77,135,253,25,85,111,225,9,35,86,18,46,190,38,57,154,81,96,165,177,175,44,75,184,215,161,235,80,62,119,115,189,52,128,75,195,208,4,177,22,178,82,168,121,216,46,155,214,150,219,114,7,200,53,120,62,145,248,72,245,52,74,90,44,43,202,213,142,126,120,59,123,55,187,255,79,182,153,82,252,196,176,142,158,36,122,178,44,213,56,62,253,255,198,31,5,187,76,68,207,10,36,98,236,118,56,197,150,224,227,68,12,201,102,188,24,120,133,129,117,112,206,190,19,230,95,206,5,84,163,88,94,120,78,110,135,217,236,10,45,197,59,208,244,124,205,172,196,245,132,59,214,147,186,22,77,249,6,86,190,66,155,199,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("128127f7-43f7-4cf4-9f1d-06f7c505c1c3"));
		}

		#endregion

	}

	#endregion

}

