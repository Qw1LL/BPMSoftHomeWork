namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IAfterDeduplicationActionSchema

	/// <exclude/>
	public class IAfterDeduplicationActionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IAfterDeduplicationActionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IAfterDeduplicationActionSchema(IAfterDeduplicationActionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("aec23552-782f-4407-a3bb-de7bbc336923");
			Name = "IAfterDeduplicationAction";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4b7fcaef-4d0d-4f1c-b466-136a63eb8599");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,145,203,106,195,48,16,69,215,54,248,31,134,100,211,110,164,125,154,6,146,54,139,44,12,161,253,2,213,26,59,2,235,129,30,165,161,244,223,59,145,234,224,180,208,141,241,92,205,28,238,220,49,66,99,112,162,67,216,29,219,87,219,71,246,100,77,175,134,228,69,84,214,176,103,148,201,141,170,203,85,83,127,54,117,149,130,50,195,172,221,35,219,155,168,162,194,240,208,212,212,176,244,56,80,55,28,76,68,223,19,123,5,135,109,79,255,55,176,109,87,144,52,192,57,135,117,72,90,11,127,222,252,212,47,232,60,6,52,49,128,128,147,48,114,68,15,248,129,93,138,40,65,92,112,32,231,60,232,172,118,35,70,100,19,145,207,144,46,189,81,35,168,201,210,127,142,42,218,146,190,215,61,90,140,39,43,195,10,142,25,82,30,127,123,206,194,13,238,106,104,178,127,49,246,215,89,81,156,240,66,131,161,107,60,46,52,250,1,101,206,244,188,216,180,185,2,10,35,141,17,40,16,82,217,154,231,129,60,255,110,149,132,125,73,230,174,76,193,28,113,95,174,82,45,209,200,178,81,174,191,202,173,102,34,41,223,31,158,2,82,15,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aec23552-782f-4407-a3bb-de7bbc336923"));
		}

		#endregion

	}

	#endregion

}

