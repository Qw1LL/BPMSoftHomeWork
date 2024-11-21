namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IChildImportEntitiesSetterSchema

	/// <exclude/>
	public class IChildImportEntitiesSetterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IChildImportEntitiesSetterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IChildImportEntitiesSetterSchema(IChildImportEntitiesSetterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("06530102-5f59-41f5-9ac8-4a7901f07ee8");
			Name = "IChildImportEntitiesSetter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,207,74,196,48,16,135,207,91,232,59,132,158,20,36,121,0,107,15,46,85,122,16,22,250,4,217,238,116,29,200,159,146,76,196,34,251,238,38,173,205,234,226,45,153,249,205,247,13,99,164,6,63,201,1,216,243,225,173,183,35,241,189,53,35,158,131,147,132,214,240,23,84,208,233,201,58,42,139,175,178,216,5,143,230,204,250,217,19,232,24,85,10,134,148,243,252,21,12,56,28,30,115,230,202,115,192,91,67,72,8,62,182,99,96,10,71,133,3,67,67,224,198,228,238,246,239,168,78,171,103,139,246,64,177,29,211,73,187,19,66,176,218,7,173,165,155,155,173,208,3,121,6,159,232,41,9,225,103,144,145,101,184,160,114,137,103,132,184,101,212,147,116,82,51,19,239,240,84,45,111,136,90,95,53,235,54,236,90,226,181,88,62,255,143,110,170,170,105,111,23,250,51,248,97,241,148,22,191,91,249,135,140,255,101,122,96,93,107,130,6,39,143,10,234,229,32,115,147,113,247,233,198,151,178,184,124,3,193,53,88,203,188,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("06530102-5f59-41f5-9ac8-4a7901f07ee8"));
		}

		#endregion

	}

	#endregion

}

