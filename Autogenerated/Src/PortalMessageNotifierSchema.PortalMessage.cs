namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PortalMessageNotifierSchema

	/// <exclude/>
	public class PortalMessageNotifierSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PortalMessageNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PortalMessageNotifierSchema(PortalMessageNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1d380dfa-98cc-4b28-8b3b-626ea934efae");
			Name = "PortalMessageNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3cbee395-bc39-4c92-abe2-fb401673f115");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,219,110,194,48,12,134,175,139,196,59,68,236,102,72,168,15,192,14,210,128,137,33,141,129,6,219,125,150,186,197,82,155,160,28,52,85,136,119,159,155,20,200,54,132,184,106,226,124,254,109,255,181,51,40,11,182,170,141,133,234,174,219,113,209,53,29,171,178,4,97,81,73,147,78,65,130,70,113,68,70,203,249,74,229,150,24,13,233,179,180,104,17,12,189,118,59,146,87,96,182,92,64,196,200,28,11,167,121,35,213,237,236,26,42,185,209,80,208,149,141,75,110,204,144,45,149,182,188,156,131,49,188,128,55,101,49,71,208,30,20,13,112,254,157,13,217,136,27,248,151,149,132,18,167,26,52,129,213,78,88,165,169,146,251,42,81,4,96,235,207,231,197,111,253,84,53,3,255,233,51,210,76,146,164,133,102,50,87,236,129,73,248,102,113,36,48,7,136,128,144,76,238,217,117,189,133,140,28,117,149,252,228,165,131,123,234,136,140,124,188,237,181,116,175,63,8,217,99,13,220,66,54,170,103,217,101,133,169,195,140,242,35,254,175,198,66,94,86,152,16,180,198,10,78,42,11,121,212,120,225,230,201,90,46,54,21,41,144,14,57,8,237,211,193,163,119,16,74,103,113,159,75,141,21,215,117,84,100,16,82,86,98,3,21,255,136,217,16,74,41,214,50,175,72,123,71,123,102,168,47,222,218,59,65,191,129,164,233,231,29,48,63,245,193,233,100,119,133,65,225,71,30,27,160,1,175,78,106,104,182,15,181,194,103,79,75,238,207,126,193,64,102,97,199,252,61,68,127,7,247,63,223,204,183,194,98,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1d380dfa-98cc-4b28-8b3b-626ea934efae"));
		}

		#endregion

	}

	#endregion

}

