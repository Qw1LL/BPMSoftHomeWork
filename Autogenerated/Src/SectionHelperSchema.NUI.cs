namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SectionHelperSchema

	/// <exclude/>
	public class SectionHelperSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SectionHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SectionHelperSchema(SectionHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("33d4e612-facc-4d4c-9516-d0f60d673446");
			Name = "SectionHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9defff70-969f-468c-8263-69f6e8af1009");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,81,75,110,194,48,16,93,27,137,59,88,98,3,155,28,0,218,46,32,45,237,130,10,41,229,0,174,25,18,75,142,29,141,199,85,17,234,221,107,199,72,52,144,176,173,228,205,188,231,121,31,219,136,26,92,35,36,240,229,118,83,216,3,101,43,107,14,170,244,40,72,89,51,30,157,198,35,230,157,50,37,47,142,142,160,94,92,205,217,7,124,211,13,184,178,90,131,140,10,46,91,131,1,84,242,230,78,46,72,92,192,139,125,93,91,211,135,35,244,163,217,179,33,69,10,220,0,253,34,36,89,236,229,223,189,26,88,202,151,129,8,84,227,63,181,146,92,106,225,28,47,82,165,87,208,13,224,156,191,117,102,126,106,23,216,4,161,12,32,223,0,85,118,239,230,124,219,74,36,242,44,231,8,163,227,26,168,243,218,133,68,213,208,116,231,0,3,110,146,58,247,157,113,22,125,24,99,95,2,121,149,140,31,249,42,198,75,61,143,225,189,233,161,43,251,55,230,211,116,22,43,51,134,64,30,205,89,35,27,136,114,229,189,136,155,63,67,85,180,2,67,59,163,168,144,21,212,34,7,215,138,88,116,255,86,233,78,164,59,213,38,96,246,233,23,219,57,160,225,252,2,211,81,84,36,42,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("33d4e612-facc-4d4c-9516-d0f60d673446"));
		}

		#endregion

	}

	#endregion

}

