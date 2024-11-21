namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IPersistentFileImporterSchema

	/// <exclude/>
	public class IPersistentFileImporterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPersistentFileImporterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPersistentFileImporterSchema(IPersistentFileImporterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ad942417-9bd3-4771-a7af-0535dd659ac6");
			Name = "IPersistentFileImporter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,147,203,110,194,48,16,69,215,32,241,15,35,216,180,82,149,236,75,154,5,244,161,44,144,144,64,221,155,120,2,22,137,29,249,81,21,161,254,123,39,118,8,80,40,139,74,93,37,190,158,185,115,143,157,72,86,161,169,89,142,48,153,207,22,170,176,209,84,201,66,172,157,102,86,40,25,189,138,18,179,170,86,218,194,126,208,239,57,35,228,26,22,59,99,177,26,255,88,71,203,141,70,198,73,160,29,218,27,105,92,147,5,100,210,162,46,104,196,35,100,115,212,70,80,177,180,71,99,212,190,188,87,187,85,41,114,16,135,242,223,170,129,124,38,204,224,153,182,15,30,221,208,25,218,141,226,166,85,227,56,134,196,184,170,98,122,151,118,202,51,150,104,17,10,242,129,66,171,10,68,0,173,153,166,83,33,87,19,29,187,227,139,246,196,215,129,164,218,167,97,209,133,89,160,49,148,32,227,195,180,61,56,19,20,16,60,74,98,223,20,76,62,148,224,109,136,134,229,238,205,209,250,138,209,253,248,38,198,59,43,5,103,4,226,234,82,49,142,193,35,130,127,205,238,77,52,90,167,165,73,147,248,240,118,228,154,110,48,223,102,166,1,243,1,111,210,81,211,13,192,151,79,204,29,241,137,16,105,181,251,211,13,181,36,158,141,31,184,174,64,157,246,88,181,69,57,76,151,205,3,10,165,33,103,50,199,178,77,114,229,54,3,91,96,237,6,62,192,212,183,149,254,151,10,102,222,249,20,125,132,146,135,111,183,89,126,133,27,63,19,7,125,82,191,1,43,59,194,243,176,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ad942417-9bd3-4771-a7af-0535dd659ac6"));
		}

		#endregion

	}

	#endregion

}

