namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImportFactorySchema

	/// <exclude/>
	public class IFileImportFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImportFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImportFactorySchema(IFileImportFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("40607472-ce99-41c0-a6b6-c3ff07be295d");
			Name = "IFileImportFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,77,107,132,48,16,61,43,248,31,6,123,105,161,232,189,221,10,219,165,22,15,5,161,244,7,100,117,148,128,38,50,73,10,82,246,191,119,98,182,235,110,119,115,203,99,222,199,188,81,98,68,51,137,6,225,181,254,248,212,157,205,118,90,117,178,119,36,172,212,42,43,229,128,213,56,105,178,73,252,147,196,192,207,25,169,250,179,113,194,231,36,78,226,232,142,176,103,10,84,202,34,117,44,249,4,213,74,47,69,99,53,205,126,146,103,243,60,135,141,113,227,40,104,46,142,255,19,15,58,77,176,119,114,104,189,17,42,43,173,68,3,86,195,42,151,253,137,228,103,42,147,219,15,178,1,121,18,186,229,31,241,26,209,85,128,5,120,71,11,19,73,143,5,219,25,58,169,90,36,239,118,109,23,144,73,144,24,65,113,143,47,169,51,72,220,159,194,198,151,151,22,193,154,27,67,2,131,214,242,62,38,219,228,11,229,182,66,163,7,55,42,83,147,110,208,24,77,105,177,11,8,124,139,193,161,201,46,232,85,29,210,190,45,97,203,37,171,223,226,6,124,255,117,145,109,201,180,126,31,161,58,250,108,251,158,239,40,184,171,109,43,38,46,18,254,71,122,224,115,71,135,112,114,84,109,184,186,255,30,126,1,246,247,113,185,77,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("40607472-ce99-41c0-a6b6-c3ff07be295d"));
		}

		#endregion

	}

	#endregion

}

