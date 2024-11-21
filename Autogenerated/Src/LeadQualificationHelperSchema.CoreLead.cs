namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LeadQualificationHelperSchema

	/// <exclude/>
	public class LeadQualificationHelperSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LeadQualificationHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LeadQualificationHelperSchema(LeadQualificationHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b0f5b581-b090-487e-b10f-878e77de698a");
			Name = "LeadQualificationHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("574c9bf8-30b5-4eb9-aa34-ee8fc5cac038");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,84,219,74,195,64,16,125,142,224,63,12,233,75,5,109,222,91,91,168,130,90,80,168,150,126,192,154,76,234,194,102,19,54,27,161,136,255,238,236,230,98,54,109,106,171,152,167,204,236,92,206,156,179,179,146,37,152,103,44,68,184,89,62,173,210,88,143,110,83,25,243,77,161,152,230,169,132,143,243,51,175,200,185,220,192,106,155,107,76,38,141,253,29,175,144,188,228,31,40,220,152,156,133,212,168,98,170,57,134,197,35,178,232,185,96,130,199,60,180,21,31,80,100,168,108,124,16,4,112,157,23,73,194,212,118,86,217,131,250,131,55,27,120,53,48,174,198,253,125,222,24,163,186,82,208,42,149,21,175,130,135,192,107,36,189,64,204,128,20,191,131,197,1,211,238,10,187,56,74,203,224,216,5,82,122,50,166,88,2,146,184,158,250,130,128,44,34,127,214,45,233,22,187,14,108,142,45,241,158,242,8,230,161,1,61,143,105,160,69,132,82,55,115,12,239,11,58,46,171,94,24,121,62,75,49,80,70,165,30,142,54,161,96,121,62,134,95,201,82,73,242,23,65,108,251,190,238,227,31,85,170,167,184,227,2,35,26,99,169,82,141,161,198,232,8,17,59,52,119,61,61,242,101,117,7,80,4,45,149,98,11,235,28,21,45,137,36,183,193,226,154,147,3,72,214,47,143,240,155,134,185,86,102,225,230,89,38,42,86,214,74,84,141,58,50,55,12,17,34,74,43,66,157,42,195,147,101,255,24,146,246,222,241,234,143,210,16,33,84,24,79,253,30,161,252,96,118,236,30,20,14,111,173,125,248,65,167,246,102,236,20,101,14,71,254,172,67,121,59,183,186,145,61,131,12,59,42,187,104,47,107,77,220,126,23,246,185,244,188,78,238,180,147,109,150,212,243,92,57,41,200,173,101,131,62,15,139,252,132,250,45,141,78,209,23,14,168,220,88,255,247,146,85,156,191,115,165,137,114,56,225,97,43,153,221,207,199,190,7,143,124,95,22,98,55,38,219,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b0f5b581-b090-487e-b10f-878e77de698a"));
		}

		#endregion

	}

	#endregion

}

