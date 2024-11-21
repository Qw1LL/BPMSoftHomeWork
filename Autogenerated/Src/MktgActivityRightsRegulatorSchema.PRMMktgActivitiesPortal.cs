namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MktgActivityRightsRegulatorSchema

	/// <exclude/>
	public class MktgActivityRightsRegulatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MktgActivityRightsRegulatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MktgActivityRightsRegulatorSchema(MktgActivityRightsRegulatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bd6f3ed9-1bd8-42f5-9da1-eedf8c901d2e");
			Name = "MktgActivityRightsRegulator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0d7ed7ad-953f-4448-9eef-c702acc0afc1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,84,77,79,219,64,16,61,59,82,254,195,8,46,137,132,156,123,160,160,52,138,80,14,33,17,105,185,47,235,201,122,85,123,215,218,143,4,183,226,191,119,189,27,130,109,236,150,150,246,98,105,190,222,155,121,59,99,65,114,212,5,161,8,159,55,171,173,220,153,120,46,197,142,51,171,136,225,82,12,7,63,134,131,200,106,46,24,108,75,109,48,191,60,217,175,5,121,46,69,151,95,97,183,55,94,8,195,13,71,29,207,116,41,232,186,192,192,166,255,48,61,94,10,131,106,231,186,175,42,93,237,185,66,230,2,48,207,136,214,83,88,125,51,108,70,13,223,115,83,222,115,150,26,125,143,204,102,196,72,229,211,39,147,9,92,105,155,231,68,149,215,71,219,151,194,33,229,52,5,124,66,106,13,106,144,47,148,176,147,10,104,74,4,171,154,84,30,19,156,187,206,20,195,11,244,164,134,93,216,199,140,83,160,30,254,23,141,193,20,150,126,222,114,177,71,97,154,19,59,28,247,30,238,123,154,116,163,170,222,42,113,166,176,9,20,33,225,200,183,213,69,64,107,211,244,5,130,144,209,57,138,36,80,52,249,86,104,82,153,84,100,138,239,137,193,35,89,48,96,47,121,2,43,34,8,195,250,136,107,197,136,224,223,253,8,129,110,212,59,226,76,49,13,68,49,155,187,144,30,67,181,127,81,212,215,109,28,200,66,172,131,230,4,20,118,168,92,38,23,30,47,106,7,230,50,179,185,120,32,153,117,107,118,139,230,75,89,96,226,205,171,91,203,147,235,209,217,140,82,105,133,89,38,103,227,55,24,235,44,249,11,152,113,181,238,209,243,251,36,60,8,84,255,83,187,26,126,183,66,31,144,206,131,127,84,184,19,200,248,18,234,194,253,126,83,253,37,52,174,194,139,188,8,215,61,250,170,81,185,159,158,64,39,181,171,179,13,243,2,254,145,218,240,169,255,22,111,110,64,224,161,55,62,106,183,212,126,129,45,77,49,39,119,238,87,30,86,42,122,215,9,190,182,222,91,84,91,138,86,118,183,248,193,219,116,62,15,7,63,1,176,88,138,179,101,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bd6f3ed9-1bd8-42f5-9da1-eedf8c901d2e"));
		}

		#endregion

	}

	#endregion

}

