namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EsqDataSourceBuilderSchema

	/// <exclude/>
	public class EsqDataSourceBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EsqDataSourceBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EsqDataSourceBuilderSchema(EsqDataSourceBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("788f8d96-84a9-4c96-b0f8-5fd9201be0a6");
			Name = "EsqDataSourceBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("907f2de3-5104-49b3-a54a-bb8730240b72");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,83,203,106,2,65,16,60,43,228,31,26,115,81,144,253,0,53,66,124,4,114,48,152,72,78,33,135,113,108,117,96,157,49,243,48,9,33,255,158,30,71,116,119,93,215,7,230,178,208,189,93,213,93,53,221,146,45,208,44,25,71,232,12,7,35,53,181,81,87,201,169,152,57,205,172,80,50,122,193,165,210,86,200,89,244,192,140,13,81,95,206,132,196,168,111,62,110,202,63,55,229,146,51,244,255,12,124,51,7,163,49,63,75,48,110,149,22,104,246,255,239,184,123,204,178,145,114,154,99,116,63,54,86,19,134,154,123,8,129,110,53,206,40,130,110,204,140,105,0,141,189,43,239,56,17,79,80,175,235,222,122,56,101,46,182,29,33,39,68,90,181,223,75,84,211,234,227,94,117,173,14,79,100,27,220,65,165,63,122,174,212,222,9,188,116,227,88,112,224,190,71,110,11,104,192,94,174,21,20,236,242,41,239,90,68,83,88,224,211,237,250,182,27,198,200,109,155,102,161,55,161,239,78,55,57,97,181,243,54,146,252,225,122,208,80,177,25,58,111,220,234,171,65,77,72,73,156,158,196,165,194,154,71,151,26,48,102,6,171,93,141,204,166,39,27,106,181,18,158,37,3,171,67,40,246,237,78,169,9,154,250,95,235,23,85,197,165,124,142,11,118,176,180,6,126,83,75,191,27,107,80,78,130,59,105,171,6,104,231,106,226,93,210,98,69,196,27,155,66,0,198,146,56,14,137,133,200,21,125,141,87,109,67,145,171,197,111,19,148,150,52,90,167,37,72,252,132,194,126,219,177,79,26,44,235,107,51,225,106,158,79,73,246,196,150,230,237,193,185,170,54,140,135,246,232,216,100,153,221,250,143,91,44,216,228,11,197,30,57,136,163,154,121,234,72,174,185,169,121,55,120,169,200,12,77,129,200,204,33,135,108,58,73,185,63,228,34,164,230,229,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("788f8d96-84a9-4c96-b0f8-5fd9201be0a6"));
		}

		#endregion

	}

	#endregion

}

