namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SysWorkspaceFeaturesSchema

	/// <exclude/>
	public class SysWorkspaceFeaturesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysWorkspaceFeaturesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysWorkspaceFeaturesSchema(SysWorkspaceFeaturesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f433f309-ae33-4c7e-b563-db6b55384ed9");
			Name = "SysWorkspaceFeatures";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,93,75,195,64,16,124,78,161,255,97,233,147,130,109,223,253,2,27,176,20,180,10,1,125,148,235,101,83,15,47,187,97,111,163,4,201,127,247,18,27,75,109,95,14,110,103,103,134,153,37,83,98,168,140,69,88,60,63,102,92,232,44,101,42,220,182,22,163,142,105,60,250,30,143,146,58,56,218,66,214,4,197,50,226,222,163,237,192,48,91,34,161,56,123,245,183,179,23,17,140,211,56,175,234,141,119,22,172,55,33,192,43,203,71,239,118,143,70,107,193,0,151,176,74,185,172,162,217,198,121,167,205,0,68,102,231,156,84,226,62,141,34,4,141,43,22,4,77,206,228,27,88,61,184,160,215,65,37,186,222,194,91,49,232,221,0,225,23,28,128,189,78,50,159,79,158,8,83,102,191,179,152,92,12,243,12,45,83,14,235,72,60,194,238,136,245,29,229,36,111,205,58,125,65,105,166,39,209,46,150,71,69,223,44,76,126,204,253,111,214,254,214,53,244,117,152,111,137,58,20,115,118,190,11,36,24,255,180,143,222,29,33,105,123,145,248,182,63,183,70,235,207,217,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f433f309-ae33-4c7e-b563-db6b55384ed9"));
		}

		#endregion

	}

	#endregion

}

