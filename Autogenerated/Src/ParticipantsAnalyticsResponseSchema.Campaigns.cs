namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ParticipantsAnalyticsResponseSchema

	/// <exclude/>
	public class ParticipantsAnalyticsResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ParticipantsAnalyticsResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ParticipantsAnalyticsResponseSchema(ParticipantsAnalyticsResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f53c9ec6-85b8-4636-8f98-86f86c8b298c");
			Name = "ParticipantsAnalyticsResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,75,79,195,48,12,199,207,67,226,59,88,227,2,151,246,206,99,18,12,52,77,2,52,177,35,226,224,165,110,177,148,164,37,15,208,64,124,119,156,118,157,246,224,33,46,145,254,177,99,255,252,119,44,26,242,13,42,130,171,217,221,188,46,67,54,174,109,201,85,116,24,184,182,135,7,31,135,7,131,232,217,86,48,95,250,64,230,108,71,75,190,214,164,82,178,207,38,100,201,177,218,203,121,136,54,176,161,108,46,81,212,252,222,214,150,44,201,59,114,84,137,128,177,70,239,79,97,134,46,176,226,6,109,240,151,22,245,82,148,127,16,68,41,79,237,131,60,207,225,220,71,99,208,45,71,43,221,39,64,89,59,88,231,16,129,114,84,94,12,199,104,26,228,202,74,251,87,86,148,237,234,9,133,111,251,30,255,64,243,18,201,135,147,97,62,202,86,189,196,179,128,108,61,176,21,2,211,142,7,184,168,99,128,102,163,4,160,214,181,234,162,108,129,80,61,131,90,177,0,39,163,122,246,124,99,192,199,107,12,152,58,56,84,225,73,46,154,184,208,172,64,37,199,254,50,108,32,251,147,115,109,243,204,213,13,201,11,74,94,183,117,186,248,174,171,221,88,107,182,130,100,129,37,147,75,132,251,136,29,227,29,153,5,185,227,123,249,82,112,1,195,126,178,105,49,60,73,216,61,247,36,114,177,46,61,45,32,253,176,193,160,162,112,6,94,142,164,62,127,129,186,101,31,160,46,183,141,243,240,246,204,201,205,126,17,155,182,255,131,25,123,7,167,169,232,54,247,244,198,70,67,14,23,154,206,191,117,61,189,25,193,150,244,191,76,119,68,182,232,182,210,234,238,118,251,242,243,11,119,98,24,11,159,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f53c9ec6-85b8-4636-8f98-86f86c8b298c"));
		}

		#endregion

	}

	#endregion

}

