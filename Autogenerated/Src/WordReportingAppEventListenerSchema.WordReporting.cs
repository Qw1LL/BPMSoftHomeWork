namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: WordReportingAppEventListenerSchema

	/// <exclude/>
	public class WordReportingAppEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WordReportingAppEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WordReportingAppEventListenerSchema(WordReportingAppEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c074c284-2329-406d-b902-b8e6677ad447");
			Name = "WordReportingAppEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7609649d-94a6-447b-b054-9d91465ffa7b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,81,203,78,195,64,12,60,167,82,255,97,165,94,146,75,62,160,148,74,180,60,132,68,69,69,133,122,222,38,110,88,209,122,87,94,39,128,16,255,142,183,75,31,41,129,203,38,30,143,61,30,27,245,22,188,211,5,168,201,124,182,176,107,206,167,22,215,166,170,73,179,177,152,63,129,179,196,6,171,124,105,169,60,68,253,222,103,191,151,212,94,126,79,10,183,91,139,23,29,248,223,13,195,243,10,212,85,68,208,141,230,183,186,96,75,6,252,239,252,18,86,199,49,36,59,32,168,68,84,77,55,218,251,161,106,89,184,114,238,166,1,228,7,227,25,16,104,87,224,234,213,198,20,170,8,252,255,233,106,168,206,161,137,246,32,61,100,51,242,30,180,231,100,29,72,11,144,1,230,100,26,205,16,9,46,6,234,217,3,201,142,16,138,176,160,243,240,114,28,167,143,174,63,242,59,224,81,155,50,78,179,232,54,25,0,150,81,245,108,132,58,184,26,170,25,240,139,45,253,143,252,14,84,182,1,34,83,130,106,172,41,213,35,138,169,5,107,226,116,239,78,132,24,222,89,21,241,155,169,112,249,36,89,137,217,252,132,190,79,135,163,36,73,107,228,137,193,114,116,127,220,230,53,120,83,97,188,252,56,77,179,224,17,225,173,189,239,83,82,218,54,156,69,145,175,78,211,17,109,131,130,125,3,25,27,71,233,232,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c074c284-2329-406d-b902-b8e6677ad447"));
		}

		#endregion

	}

	#endregion

}

