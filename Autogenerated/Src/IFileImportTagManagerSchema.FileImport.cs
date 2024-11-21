namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImportTagManagerSchema

	/// <exclude/>
	public class IFileImportTagManagerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImportTagManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImportTagManagerSchema(IFileImportTagManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ee7c80a9-3a5c-4e84-9235-9be88e7c35d7");
			Name = "IFileImportTagManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,147,77,106,195,48,16,133,215,49,248,14,67,54,109,161,216,7,168,27,72,210,20,178,72,41,164,61,192,196,30,185,42,150,100,164,177,193,148,220,189,178,108,247,143,20,218,93,118,35,241,205,211,188,39,73,163,34,87,99,78,176,122,220,237,141,224,100,109,180,144,101,99,145,165,209,201,189,172,104,171,106,99,57,142,222,226,104,86,55,135,74,230,32,53,147,21,125,219,246,147,120,194,114,135,26,75,178,30,236,225,89,154,166,144,185,70,41,180,221,98,218,88,91,66,38,7,140,165,75,62,168,244,39,150,213,104,81,129,246,3,222,206,29,233,130,236,124,177,105,73,51,12,43,48,135,87,202,57,201,210,64,158,110,68,91,186,169,205,215,141,242,133,251,214,210,26,89,140,51,121,3,238,114,80,29,207,184,134,21,9,99,71,131,27,205,146,37,185,61,182,20,36,151,94,189,151,117,87,55,113,244,171,225,30,247,88,85,5,203,224,245,128,48,127,1,25,68,169,0,175,36,185,59,151,44,130,187,48,209,169,60,190,36,209,245,100,241,143,32,238,168,162,233,230,65,138,193,183,207,19,10,67,78,95,240,152,200,185,4,49,140,251,96,248,217,81,113,42,139,165,240,191,224,143,79,227,24,71,199,119,113,190,14,193,109,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ee7c80a9-3a5c-4e84-9235-9be88e7c35d7"));
		}

		#endregion

	}

	#endregion

}

