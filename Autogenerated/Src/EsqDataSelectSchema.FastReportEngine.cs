namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EsqDataSelectSchema

	/// <exclude/>
	public class EsqDataSelectSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EsqDataSelectSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EsqDataSelectSchema(EsqDataSelectSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5bd55bed-b9af-4b85-843e-a772a217d3c2");
			Name = "EsqDataSelect";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("907f2de3-5104-49b3-a54a-bb8730240b72");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,80,203,106,195,48,16,60,59,144,127,88,232,165,133,160,15,72,218,66,155,164,37,135,80,55,254,2,69,217,184,2,91,114,244,56,152,208,127,239,74,50,78,213,80,200,197,70,179,51,179,51,171,120,139,182,227,2,225,181,220,86,250,232,216,82,171,163,172,189,225,78,106,197,118,216,105,227,164,170,217,27,183,46,189,214,170,150,10,217,218,158,166,147,243,116,82,120,75,115,168,122,235,176,37,121,211,160,8,90,203,222,81,161,145,98,49,114,46,59,12,233,149,147,78,162,189,30,95,150,174,184,227,149,246,70,32,123,217,91,103,248,224,28,112,210,145,242,206,96,77,16,44,27,110,237,28,40,84,212,96,8,17,9,157,223,55,82,128,8,243,124,12,115,216,252,38,23,84,134,190,23,75,218,228,140,23,78,27,114,46,163,79,98,12,158,153,219,125,236,211,87,226,11,91,254,233,209,244,128,246,52,131,205,14,249,225,67,53,253,74,198,240,220,244,143,100,75,237,102,144,254,207,129,72,119,243,173,218,242,238,1,194,77,139,130,204,225,41,76,194,125,226,115,164,36,124,124,70,194,247,144,29,213,33,197,207,187,148,70,119,72,55,197,127,154,92,101,15,235,207,80,163,91,192,96,61,80,111,233,147,133,205,93,254,4,76,104,14,18,246,3,130,178,223,221,151,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5bd55bed-b9af-4b85-843e-a772a217d3c2"));
		}

		#endregion

	}

	#endregion

}

