namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ICategoryProviderWrapperSchema

	/// <exclude/>
	public class ICategoryProviderWrapperSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICategoryProviderWrapperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICategoryProviderWrapperSchema(ICategoryProviderWrapperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f178ef2e-9d2a-41d3-899c-ea2ef4382810");
			Name = "ICategoryProviderWrapper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,145,207,106,195,48,12,198,207,13,228,29,68,79,27,140,248,1,214,229,208,194,202,14,133,178,28,118,118,19,39,104,196,127,144,237,209,48,250,238,147,155,164,41,116,23,35,11,253,244,125,146,140,212,202,59,89,43,216,30,15,149,109,67,177,179,166,197,46,146,12,104,77,158,253,230,217,42,122,52,29,84,131,15,74,191,230,25,103,132,16,176,241,81,107,73,67,57,253,143,100,127,176,81,80,75,159,158,160,58,75,3,180,100,53,104,137,61,156,236,185,152,81,113,199,186,120,234,177,6,52,65,81,155,156,124,236,38,120,234,72,95,36,157,83,196,181,201,205,131,248,53,177,87,97,17,37,213,115,216,140,226,62,58,103,41,220,76,128,235,89,165,1,107,184,174,70,135,202,4,159,156,61,90,27,51,78,146,212,96,120,83,111,235,133,88,151,159,183,248,5,190,45,26,238,137,6,124,32,222,86,177,17,87,108,233,66,42,68,50,190,156,135,251,223,28,115,115,97,34,247,17,155,52,218,12,189,51,83,141,200,129,137,173,61,63,141,122,119,163,60,243,137,86,151,60,187,252,1,226,83,214,255,220,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f178ef2e-9d2a-41d3-899c-ea2ef4382810"));
		}

		#endregion

	}

	#endregion

}

