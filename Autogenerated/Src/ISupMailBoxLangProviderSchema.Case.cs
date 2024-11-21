namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISupMailBoxLangProviderSchema

	/// <exclude/>
	public class ISupMailBoxLangProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISupMailBoxLangProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISupMailBoxLangProviderSchema(ISupMailBoxLangProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("15f7828f-b2b8-4927-9695-3e8e4374d7a6");
			Name = "ISupMailBoxLangProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,145,77,106,195,48,16,133,215,13,228,14,67,86,45,20,251,0,77,189,72,11,166,144,64,192,39,80,148,145,59,96,253,48,146,74,66,200,221,59,178,99,90,154,93,23,90,204,204,247,244,158,52,78,89,140,65,105,132,205,126,215,121,147,170,55,239,12,245,153,85,34,239,150,139,203,114,241,144,35,185,30,186,115,76,104,95,254,212,194,15,3,234,2,199,170,69,135,76,90,24,161,234,186,134,117,204,214,42,62,55,183,250,29,163,102,58,96,132,116,14,248,12,233,83,37,8,236,191,232,40,189,65,185,62,171,30,193,176,183,96,21,13,112,240,39,25,24,207,64,78,11,228,18,48,246,20,211,148,175,154,125,234,95,70,33,31,6,210,34,72,200,166,60,237,163,203,97,39,183,109,252,105,43,22,251,201,143,5,189,200,185,11,58,54,110,208,127,67,221,167,154,58,65,177,178,224,228,215,95,87,140,154,2,137,58,174,154,173,168,193,27,192,98,16,171,117,61,130,63,58,198,148,217,197,166,228,31,211,140,182,100,8,89,224,121,90,240,54,211,17,90,76,51,249,88,174,94,75,54,217,89,35,57,103,207,167,178,201,235,114,113,253,6,153,221,128,125,3,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("15f7828f-b2b8-4927-9695-3e8e4374d7a6"));
		}

		#endregion

	}

	#endregion

}

