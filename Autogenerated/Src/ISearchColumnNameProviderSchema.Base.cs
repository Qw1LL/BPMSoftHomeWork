namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISearchColumnNameProviderSchema

	/// <exclude/>
	public class ISearchColumnNameProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISearchColumnNameProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISearchColumnNameProviderSchema(ISearchColumnNameProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("90958362-e618-422a-ad51-19a35fdf8930");
			Name = "ISearchColumnNameProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,145,193,110,131,48,16,68,207,32,241,15,171,228,210,94,240,61,161,28,146,67,149,67,42,84,190,192,129,133,88,138,109,180,182,43,69,81,254,189,196,134,200,180,85,143,30,207,120,222,122,65,113,137,102,224,13,194,174,58,214,186,179,249,94,171,78,244,142,184,21,90,101,41,220,178,52,75,147,53,97,63,158,225,160,44,82,55,250,55,112,168,145,83,115,222,235,139,147,234,99,124,167,34,253,37,90,36,31,0,198,24,20,198,73,201,233,90,206,66,136,64,227,51,96,172,38,161,122,120,64,192,48,165,243,103,152,197,233,193,157,46,162,1,49,247,255,87,159,76,208,79,234,35,218,179,110,13,108,160,242,207,132,219,95,136,137,87,62,209,58,82,230,47,200,7,91,48,45,224,38,105,224,196,165,247,189,173,76,4,183,42,23,99,231,5,243,206,40,73,161,178,172,227,174,130,205,178,55,26,235,175,222,209,254,28,252,37,22,32,110,126,221,78,147,174,81,181,225,47,194,114,238,97,169,11,245,254,13,86,159,122,101,13,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("90958362-e618-422a-ad51-19a35fdf8930"));
		}

		#endregion

	}

	#endregion

}

