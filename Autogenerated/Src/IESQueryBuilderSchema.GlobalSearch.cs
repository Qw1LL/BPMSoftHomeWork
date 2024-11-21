namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IESQueryBuilderSchema

	/// <exclude/>
	public class IESQueryBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IESQueryBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IESQueryBuilderSchema(IESQueryBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("88313c62-0396-406c-abf5-3debda333fb2");
			Name = "IESQueryBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3c3a921b-299a-4f38-a040-5c0154a25bee");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,145,205,110,131,48,16,132,207,32,241,14,86,114,105,47,112,79,83,14,137,162,42,135,72,84,60,193,2,11,177,228,31,234,159,67,84,229,221,235,120,129,146,246,134,199,51,179,31,107,5,18,237,8,45,178,67,117,169,117,239,242,163,86,61,31,188,1,199,181,202,63,132,110,64,212,8,166,189,102,233,119,150,102,105,226,45,87,195,226,63,9,176,142,183,100,121,139,134,173,193,33,132,217,89,57,52,125,40,223,177,243,169,254,244,104,110,7,207,69,135,38,218,138,162,96,123,235,165,4,115,43,167,243,212,198,108,172,99,95,143,12,107,230,16,69,138,85,102,244,141,8,118,62,79,250,63,40,33,232,5,234,130,238,170,59,187,99,85,140,210,229,95,148,40,196,10,203,112,66,34,150,222,104,25,232,4,182,142,148,124,201,175,185,72,25,193,128,100,42,236,248,125,67,127,20,217,54,37,109,107,42,216,23,209,247,27,51,232,188,81,182,172,96,64,104,4,62,35,4,255,108,120,36,102,211,180,185,56,128,208,227,231,11,141,34,121,197,240,74,79,149,108,81,117,180,153,120,190,211,3,62,137,247,31,207,75,68,179,37,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("88313c62-0396-406c-abf5-3debda333fb2"));
		}

		#endregion

	}

	#endregion

}

