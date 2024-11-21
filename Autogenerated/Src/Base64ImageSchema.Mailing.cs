namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: Base64ImageSchema

	/// <exclude/>
	public class Base64ImageSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public Base64ImageSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public Base64ImageSchema(Base64ImageSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("efe46806-614f-4213-8fdf-a9bbacc250fd");
			Name = "Base64Image";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5d774dd3-3f0d-4e5d-9409-9a3b17d3417e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,82,203,78,195,48,16,60,167,82,255,97,149,94,64,42,201,5,113,232,35,135,86,61,244,16,84,9,126,192,77,183,193,82,253,144,237,28,42,212,127,199,241,163,4,72,161,112,65,138,44,103,119,103,118,102,189,156,48,212,146,84,8,139,77,249,36,246,38,91,10,190,167,117,163,136,161,130,103,37,161,7,202,235,225,224,117,56,72,70,10,107,27,132,229,129,104,61,129,5,209,248,112,191,102,164,70,155,180,95,158,231,48,211,13,99,68,29,139,240,239,210,160,80,42,212,200,13,238,128,104,216,58,36,104,163,44,119,22,145,121,7,42,155,237,129,86,80,181,157,62,53,106,149,188,75,17,220,178,52,149,17,202,42,218,56,148,23,227,57,37,81,132,1,183,46,231,41,163,12,159,143,18,211,162,92,151,171,59,99,175,32,246,96,94,16,104,203,157,205,114,87,94,244,162,43,97,213,115,147,22,75,127,185,12,13,218,59,170,111,188,83,136,10,198,193,58,4,210,219,22,150,76,44,31,213,161,54,91,49,105,142,227,14,36,214,130,27,192,233,146,203,246,76,139,71,123,254,194,220,255,143,166,101,58,143,229,226,156,188,247,196,185,155,59,204,212,5,202,0,176,193,136,245,137,168,104,30,41,166,221,225,141,144,239,252,34,197,64,88,171,141,18,18,149,161,216,187,84,157,61,117,129,175,195,62,151,118,119,58,186,15,158,28,202,251,169,209,235,74,116,184,156,190,107,87,90,135,61,79,116,77,207,22,234,230,244,151,190,189,175,123,77,215,8,252,161,233,135,215,8,193,110,236,244,6,68,1,65,165,173,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("efe46806-614f-4213-8fdf-a9bbacc250fd"));
		}

		#endregion

	}

	#endregion

}

