namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SchemaUIdConstsSchema

	/// <exclude/>
	public class SchemaUIdConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SchemaUIdConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SchemaUIdConstsSchema(SchemaUIdConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5dcd2477-a927-4f24-b4d0-93f8657dbaa4");
			Name = "SchemaUIdConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,145,193,107,131,48,20,198,207,21,252,31,66,119,105,15,153,90,141,38,148,29,98,76,198,14,194,152,116,247,76,211,46,160,177,52,74,41,163,255,251,82,183,195,60,117,239,240,224,125,239,123,124,63,120,163,213,230,0,170,139,29,84,183,245,61,223,51,178,83,246,40,107,5,242,215,178,234,247,195,35,235,205,94,31,198,147,28,116,111,124,239,203,247,22,199,241,163,213,53,176,131,211,106,80,183,210,90,80,213,159,170,147,187,151,198,249,237,96,157,235,230,92,4,1,120,248,91,63,19,128,51,53,152,180,213,204,184,190,93,207,131,78,74,54,189,105,47,224,121,212,13,120,63,59,108,218,116,218,236,140,30,192,19,48,234,60,109,86,203,2,21,97,36,88,1,211,2,51,152,228,27,2,9,71,24,50,70,99,33,120,186,137,211,100,185,222,254,135,15,76,253,30,139,35,41,251,102,108,149,232,219,70,157,102,48,24,11,138,9,70,16,229,121,1,19,146,33,72,80,30,65,20,49,202,89,20,18,156,209,123,48,238,23,236,173,188,71,81,74,109,74,101,198,89,60,226,72,16,74,56,164,52,115,241,161,107,132,71,28,70,108,147,176,88,144,28,145,223,248,171,239,93,191,1,152,30,61,163,16,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5dcd2477-a927-4f24-b4d0-93f8657dbaa4"));
		}

		#endregion

	}

	#endregion

}

