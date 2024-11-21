namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImportLogItemSchema

	/// <exclude/>
	public class IImportLogItemSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImportLogItemSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImportLogItemSchema(IImportLogItemSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a68587a1-ef86-40c0-811b-ca07c771c3c7");
			Name = "IImportLogItem";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1101e5cd-b945-4f88-8001-faccb4fdb24c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,221,10,194,48,12,133,175,59,216,59,4,188,223,238,167,120,161,40,12,20,6,250,2,117,102,165,104,127,72,51,80,196,119,183,91,85,4,65,239,210,147,47,231,36,181,210,96,240,178,69,88,52,219,157,235,184,88,58,219,105,213,147,100,237,108,177,214,103,172,141,119,196,121,118,203,179,60,19,19,66,21,59,80,91,70,234,226,100,5,117,34,54,78,213,140,102,164,124,127,56,235,22,244,11,250,98,68,114,123,219,53,228,60,18,107,12,21,52,227,112,234,151,101,9,179,208,27,35,233,58,127,9,209,5,226,222,65,42,44,222,80,249,73,5,38,109,21,108,19,4,49,76,8,161,144,167,99,17,158,197,253,71,198,234,210,162,31,254,0,2,203,246,4,76,241,140,223,105,187,1,220,15,220,159,192,9,218,99,186,123,124,39,245,83,140,202,3,7,243,234,144,154,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a68587a1-ef86-40c0-811b-ca07c771c3c7"));
		}

		#endregion

	}

	#endregion

}

