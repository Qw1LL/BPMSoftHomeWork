namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ParticipantsAnalyticsRequestSchema

	/// <exclude/>
	public class ParticipantsAnalyticsRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ParticipantsAnalyticsRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ParticipantsAnalyticsRequestSchema(ParticipantsAnalyticsRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2ebfd074-f11c-4f75-a663-f6dad21baf80");
			Name = "ParticipantsAnalyticsRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,84,77,111,219,48,12,61,167,64,255,3,145,93,218,75,114,95,63,128,45,69,187,30,58,4,205,118,26,118,96,100,218,33,32,75,158,68,111,240,134,254,247,81,118,156,196,105,215,194,192,46,70,40,62,145,239,61,145,113,88,82,172,208,16,124,92,62,172,124,46,179,133,119,57,23,117,64,97,239,78,79,254,156,158,76,234,200,174,128,85,19,133,202,139,163,120,246,88,59,225,146,102,43,10,140,150,127,183,247,20,165,184,119,129,10,13,96,97,49,198,247,176,196,32,108,184,66,39,241,131,67,219,104,20,31,233,71,77,81,90,252,124,62,135,203,88,151,37,134,230,122,27,111,243,80,97,80,170,66,1,114,31,118,88,34,48,129,242,171,233,2,203,10,185,112,202,226,39,27,154,29,199,119,36,47,182,63,123,141,212,249,116,126,61,219,246,82,91,4,217,197,61,145,152,152,128,65,107,106,139,66,81,127,118,61,19,100,87,19,176,47,218,87,186,156,31,72,252,118,131,130,169,118,64,35,223,245,160,170,215,150,13,152,100,217,27,142,77,244,109,244,187,179,121,25,124,69,122,129,146,215,109,153,46,127,108,107,167,167,39,203,25,233,3,230,220,57,11,191,54,108,54,67,5,142,40,139,123,161,67,69,207,37,117,154,30,168,92,83,56,251,172,94,193,21,76,123,111,238,179,233,121,146,217,235,188,171,57,219,113,185,207,32,141,219,100,82,144,92,64,212,79,138,158,94,81,177,18,37,10,57,219,52,24,25,54,35,24,117,151,218,2,154,165,33,173,116,242,69,167,26,110,135,168,177,252,110,106,218,179,19,26,77,79,239,191,73,110,139,25,75,237,214,98,1,178,65,1,118,25,155,118,130,235,72,135,75,117,36,94,183,65,223,62,123,142,232,89,106,126,184,17,125,175,40,40,250,111,161,35,211,206,152,108,72,231,204,91,2,157,87,246,217,8,91,148,97,146,222,245,141,67,95,214,222,91,248,58,0,192,127,49,5,11,2,159,239,247,219,250,34,61,39,142,227,253,137,163,248,208,164,228,203,188,15,0,255,228,189,221,120,114,89,183,244,109,220,41,26,30,62,253,5,18,186,151,83,218,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2ebfd074-f11c-4f75-a663-f6dad21baf80"));
		}

		#endregion

	}

	#endregion

}

