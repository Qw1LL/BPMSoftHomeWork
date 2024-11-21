namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISysTranslationColumnsConfiguratorSchema

	/// <exclude/>
	public class ISysTranslationColumnsConfiguratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISysTranslationColumnsConfiguratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISysTranslationColumnsConfiguratorSchema(ISysTranslationColumnsConfiguratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("72ebf492-d797-436e-ab08-aef6a2bee1fc");
			Name = "ISysTranslationColumnsConfigurator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,145,177,110,195,32,16,64,103,91,242,63,160,100,105,23,179,167,174,135,86,85,228,33,82,164,244,7,8,62,187,72,112,142,238,96,136,170,252,123,177,137,155,164,85,212,46,192,29,247,142,7,160,114,192,7,165,65,188,108,55,187,161,243,229,235,128,157,233,3,41,111,6,44,223,73,33,219,105,93,228,159,69,158,5,54,216,139,221,145,61,184,88,107,45,232,113,147,203,53,32,144,209,79,69,30,171,150,4,125,204,138,6,61,80,23,219,175,68,19,153,171,110,17,13,14,249,114,218,64,19,41,165,20,21,7,231,20,29,235,115,124,38,19,40,116,34,227,124,65,203,153,148,87,232,33,236,173,209,194,204,14,255,82,200,226,37,227,248,125,131,13,248,143,161,229,149,216,78,221,210,230,79,201,108,76,172,193,243,31,170,48,122,78,197,55,162,41,67,224,3,33,215,21,3,8,77,208,61,47,126,201,206,174,176,144,117,37,103,98,108,209,188,97,112,64,106,111,161,186,143,213,163,229,253,39,128,246,225,49,125,96,182,4,108,211,19,76,241,41,125,235,77,242,244,5,51,165,170,42,61,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("72ebf492-d797-436e-ab08-aef6a2bee1fc"));
		}

		#endregion

	}

	#endregion

}

