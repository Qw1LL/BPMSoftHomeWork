namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IGeneratedWebFormValidatorSchema

	/// <exclude/>
	public class IGeneratedWebFormValidatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IGeneratedWebFormValidatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IGeneratedWebFormValidatorSchema(IGeneratedWebFormValidatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("61c26b2e-18c1-4d99-9cd7-da3ae5fc724c");
			Name = "IGeneratedWebFormValidator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("30ff16fc-9eaa-40ad-9611-33924da6f041");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,144,75,106,195,48,16,134,215,49,248,14,34,171,118,99,29,160,174,23,45,52,120,81,8,53,164,107,197,26,155,1,107,100,244,72,48,165,119,239,168,142,211,98,131,22,210,232,127,124,12,41,3,126,84,45,136,151,227,123,99,187,80,188,90,234,176,143,78,5,180,84,28,128,128,175,160,63,225,252,102,157,105,192,93,176,133,60,251,202,179,93,244,72,189,104,38,31,192,60,229,25,79,164,148,162,244,209,24,229,166,234,246,62,169,1,53,71,120,209,227,5,72,12,138,116,242,1,5,12,83,177,184,228,63,219,24,207,3,182,2,41,128,235,18,92,189,230,56,205,161,214,177,58,161,108,154,87,213,219,210,109,235,60,25,149,83,70,16,239,229,121,127,157,203,106,189,175,106,157,172,29,130,19,182,91,226,138,82,254,202,255,220,14,66,116,228,171,154,124,80,196,228,44,190,81,240,58,63,192,199,33,148,114,81,37,219,250,247,14,253,112,136,168,197,29,225,145,55,188,251,206,51,62,63,233,199,205,30,181,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("61c26b2e-18c1-4d99-9cd7-da3ae5fc724c"));
		}

		#endregion

	}

	#endregion

}

