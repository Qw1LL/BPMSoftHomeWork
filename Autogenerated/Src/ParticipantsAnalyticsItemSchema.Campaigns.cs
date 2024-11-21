namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ParticipantsAnalyticsItemSchema

	/// <exclude/>
	public class ParticipantsAnalyticsItemSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ParticipantsAnalyticsItemSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ParticipantsAnalyticsItemSchema(ParticipantsAnalyticsItemSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f63154a0-be3b-4482-959d-f99cde09a649");
			Name = "ParticipantsAnalyticsItem";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,84,77,111,219,48,12,61,167,64,255,3,145,30,182,93,236,251,218,14,216,220,97,235,161,69,176,236,54,244,160,200,180,67,192,250,152,40,97,200,134,254,247,81,246,18,184,31,49,226,211,46,54,72,63,61,190,71,210,178,202,32,123,165,17,62,173,238,214,174,137,69,229,108,67,109,10,42,146,179,231,103,127,206,207,22,137,201,182,176,222,113,68,115,249,44,46,190,37,27,201,96,177,198,64,170,163,223,253,57,65,9,238,34,96,43,1,84,157,98,126,15,43,21,34,105,242,202,70,254,104,85,183,147,136,111,133,163,7,151,101,9,87,156,140,81,97,247,225,95,124,131,172,3,109,144,193,38,35,252,90,117,64,182,150,119,116,129,161,113,65,66,33,128,95,20,183,114,26,17,116,192,230,122,153,89,111,235,101,185,39,186,42,71,204,63,110,84,84,98,51,6,165,227,131,36,124,218,116,164,65,103,153,83,42,23,210,12,121,30,124,173,130,243,40,104,204,230,122,142,225,251,115,43,125,162,82,198,43,106,45,80,22,76,53,74,219,26,194,80,28,78,140,53,14,34,239,208,108,48,188,189,151,33,193,53,44,105,112,245,46,107,222,139,254,146,168,134,193,46,228,89,45,22,45,198,75,96,121,228,232,113,66,209,216,41,104,39,115,124,209,199,189,232,17,180,88,71,244,149,51,190,195,136,185,197,64,12,248,51,201,104,98,72,56,195,142,222,147,140,133,84,89,199,83,139,50,98,168,142,98,255,187,235,70,117,60,199,182,117,182,154,225,252,126,10,62,97,254,181,210,24,130,11,39,212,252,252,42,110,102,49,31,156,70,206,87,197,9,21,87,199,193,51,203,114,98,143,182,62,169,183,235,163,216,185,91,245,221,69,89,5,255,114,183,154,224,12,196,45,30,254,255,55,12,157,107,103,236,203,150,88,110,187,221,9,118,190,30,65,78,152,185,16,251,195,109,214,199,67,246,105,242,241,47,173,20,135,99,36,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f63154a0-be3b-4482-959d-f99cde09a649"));
		}

		#endregion

	}

	#endregion

}

