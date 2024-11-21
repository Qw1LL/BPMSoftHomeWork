namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISysCultureInfoSchema

	/// <exclude/>
	public class ISysCultureInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISysCultureInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISysCultureInfoSchema(ISysCultureInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ea1fdfd0-6ef8-44d6-b478-24f2418a19b8");
			Name = "ISysCultureInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6d2d1275-178c-4cc9-a265-eb797a3ca54a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,81,77,107,195,48,12,61,59,144,255,32,232,61,185,119,99,135,229,48,114,216,8,116,236,238,217,74,102,72,228,32,219,176,50,246,223,167,58,107,201,24,165,228,98,236,167,247,97,73,164,39,12,179,54,8,143,221,243,193,247,177,106,60,245,110,72,172,163,243,84,189,178,166,48,230,123,89,124,149,133,74,193,209,0,135,99,136,56,221,149,133,32,59,198,65,202,208,82,68,238,197,106,15,173,212,155,52,198,196,216,82,239,51,109,78,239,163,51,224,206,172,255,36,37,254,114,94,12,59,246,51,114,116,24,246,208,101,245,82,175,235,26,238,67,154,38,205,199,135,51,176,252,8,204,98,8,206,34,69,215,59,228,234,34,169,215,154,167,228,44,180,22,78,61,41,53,96,148,102,148,250,222,144,64,22,63,175,152,75,147,50,14,169,111,176,95,77,26,140,31,211,68,64,178,156,43,9,33,242,105,15,43,81,147,53,47,34,217,16,250,134,44,67,50,27,83,215,170,91,177,191,146,54,52,31,154,6,180,183,248,59,36,187,236,63,191,23,244,47,40,216,15,85,249,148,36,183,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ea1fdfd0-6ef8-44d6-b478-24f2418a19b8"));
		}

		#endregion

	}

	#endregion

}

