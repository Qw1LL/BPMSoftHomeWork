namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IDuplicateDeletionManagerSchema

	/// <exclude/>
	public class IDuplicateDeletionManagerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDuplicateDeletionManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDuplicateDeletionManagerSchema(IDuplicateDeletionManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a1767778-661d-431a-a382-dbbf65e7e3a2");
			Name = "IDuplicateDeletionManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3066e968-6ad0-45b5-bf2b-b9af469e0d31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,81,77,75,195,64,16,61,39,208,255,48,164,23,5,73,238,181,230,160,17,201,33,82,90,60,137,135,49,59,137,11,221,221,184,31,133,32,253,239,110,54,105,109,171,120,89,118,222,188,247,230,49,35,81,144,233,176,38,184,95,85,27,213,216,244,65,201,134,183,78,163,229,74,166,5,49,215,109,121,29,170,89,252,53,139,35,103,184,108,97,211,27,75,226,118,22,123,100,174,169,245,109,40,165,37,221,120,179,5,148,197,36,163,130,182,52,136,43,148,216,146,14,130,44,203,96,105,156,16,168,251,124,170,143,2,96,147,34,61,48,179,19,106,231,222,61,13,248,97,212,127,147,34,31,215,191,199,124,21,217,15,197,204,2,86,193,100,108,94,102,9,192,154,132,218,145,1,77,181,210,204,64,163,149,240,185,78,118,1,12,45,14,9,127,71,28,145,14,53,10,144,126,191,119,9,73,203,109,255,236,255,73,254,24,254,161,145,46,179,192,250,91,228,36,255,116,180,14,9,74,102,146,252,37,0,83,38,64,173,177,63,115,216,41,206,32,44,129,174,140,213,195,149,126,6,223,192,147,227,236,245,13,46,108,175,199,19,70,115,146,108,92,83,168,247,227,97,207,192,253,55,209,13,234,60,45,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a1767778-661d-431a-a382-dbbf65e7e3a2"));
		}

		#endregion

	}

	#endregion

}

