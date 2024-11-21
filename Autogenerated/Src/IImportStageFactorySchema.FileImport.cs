namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImportStageFactorySchema

	/// <exclude/>
	public class IImportStageFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImportStageFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImportStageFactorySchema(IImportStageFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("65f0da7e-4515-4c52-863a-8b3f9080781c");
			Name = "IImportStageFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,82,65,106,195,48,16,60,199,224,63,8,95,218,64,136,31,80,39,144,152,6,124,40,132,134,62,64,81,214,70,96,73,102,87,58,152,146,191,87,178,156,198,73,13,189,73,163,217,153,221,89,105,174,128,58,46,128,237,143,31,39,83,219,117,105,116,45,27,135,220,74,163,215,7,217,66,165,58,131,54,77,190,211,100,225,72,234,102,194,69,120,75,19,143,231,121,206,10,114,74,113,236,183,227,253,19,58,4,2,109,137,73,109,1,235,96,83,27,100,2,129,91,127,244,218,76,14,226,47,196,200,242,6,232,38,149,79,180,58,119,110,165,152,104,84,177,163,83,168,56,112,97,13,246,158,22,218,251,211,199,0,148,209,47,90,69,35,118,238,153,188,252,86,76,237,34,210,113,228,138,105,31,207,38,147,119,187,108,91,228,195,211,60,211,17,160,15,80,131,8,233,253,67,22,166,117,74,211,17,141,0,34,131,51,116,4,235,80,211,182,32,128,16,91,189,201,246,156,224,190,149,216,84,238,43,111,212,80,91,205,144,198,20,38,200,235,19,131,222,181,83,99,74,3,176,98,95,15,243,176,199,241,86,193,202,155,149,113,142,93,211,32,52,220,111,99,119,225,157,223,21,123,30,112,233,255,202,226,154,38,215,31,250,35,249,112,118,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("65f0da7e-4515-4c52-863a-8b3f9080781c"));
		}

		#endregion

	}

	#endregion

}

