namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IOpenIdRoleChangeValidatorSchema

	/// <exclude/>
	public class IOpenIdRoleChangeValidatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IOpenIdRoleChangeValidatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IOpenIdRoleChangeValidatorSchema(IOpenIdRoleChangeValidatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("27d79e02-b230-4aff-9431-c743373f79e9");
			Name = "IOpenIdRoleChangeValidator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5daf09f1-167a-4d95-90ab-547ed370e530");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,79,203,10,194,48,16,60,183,208,127,88,240,162,32,253,0,61,105,15,146,131,40,22,189,167,205,182,6,210,77,201,227,32,210,127,55,105,171,226,69,216,195,206,238,204,238,12,241,14,109,207,107,132,253,249,88,234,198,229,133,166,70,182,222,112,39,53,229,167,30,137,137,157,119,247,44,125,102,105,226,173,164,22,202,135,117,216,109,63,248,171,53,24,167,161,22,6,219,112,0,24,57,52,77,120,176,1,54,29,187,104,133,197,157,83,139,55,174,164,224,78,155,44,13,138,222,87,74,214,32,223,130,191,252,36,154,73,42,173,21,20,156,166,245,213,162,97,20,233,203,216,134,32,132,117,76,1,254,7,174,225,224,165,24,135,76,204,192,4,21,19,171,104,126,152,3,32,137,41,195,136,135,23,90,12,6,40,42,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("27d79e02-b230-4aff-9431-c743373f79e9"));
		}

		#endregion

	}

	#endregion

}

