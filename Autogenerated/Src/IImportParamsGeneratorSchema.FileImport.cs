namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImportParamsGeneratorSchema

	/// <exclude/>
	public class IImportParamsGeneratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImportParamsGeneratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImportParamsGeneratorSchema(IImportParamsGeneratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("36bfcac9-e88e-4dbb-b7ce-a67ca5579bb2");
			Name = "IImportParamsGenerator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,82,193,106,195,48,12,61,167,208,127,16,237,101,131,146,220,183,44,135,117,93,233,161,80,232,216,221,75,149,212,16,219,193,118,10,101,236,223,103,203,73,218,173,109,110,131,157,18,73,79,210,123,207,146,76,160,169,89,142,240,188,89,111,85,97,227,185,146,5,47,27,205,44,87,114,60,250,28,143,162,198,112,89,194,246,104,44,10,87,175,42,204,125,209,196,75,148,168,121,254,216,99,174,14,137,95,121,133,43,81,43,109,175,33,53,198,11,105,185,229,104,92,217,1,166,26,75,215,6,43,105,81,23,142,219,3,172,66,251,134,105,38,12,109,101,86,105,66,39,73,2,169,105,132,96,250,152,181,241,70,171,3,223,161,1,129,118,175,118,6,10,165,129,211,8,168,105,6,148,97,136,167,215,13,73,206,166,212,205,71,197,115,224,29,133,155,12,34,111,80,79,217,45,174,81,123,41,196,237,130,28,37,150,104,13,216,61,66,174,170,70,72,56,176,170,65,227,105,92,242,8,25,66,244,225,219,64,235,9,249,194,233,145,220,156,212,88,237,44,159,65,248,102,48,167,230,119,234,5,226,31,149,72,111,19,125,5,222,83,148,187,32,169,141,91,125,235,224,167,79,13,200,35,115,48,104,36,187,209,185,56,40,144,80,32,29,242,105,18,52,77,50,47,179,213,151,38,4,184,142,71,127,60,199,109,190,71,193,66,87,200,128,161,212,101,179,70,219,104,105,178,52,233,254,124,233,236,125,137,110,175,227,148,186,91,156,173,106,183,132,96,6,3,118,7,17,247,225,184,255,198,51,252,7,30,116,2,127,221,78,184,168,159,73,151,251,6,95,68,172,146,121,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("36bfcac9-e88e-4dbb-b7ce-a67ca5579bb2"));
		}

		#endregion

	}

	#endregion

}

