namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CalendarUtilitiesSchema

	/// <exclude/>
	public class CalendarUtilitiesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CalendarUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CalendarUtilitiesSchema(CalendarUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("62f7c1b7-845c-4ca7-86ea-eb981e255cb0");
			Name = "CalendarUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,93,79,220,48,16,124,14,18,255,97,203,3,74,40,178,232,75,85,9,29,18,247,33,132,4,162,106,56,221,179,147,219,28,6,199,6,123,173,35,170,248,239,93,39,105,238,128,163,69,145,19,123,60,158,153,221,56,120,101,86,144,55,158,176,62,221,223,11,237,114,252,243,58,183,21,137,137,173,107,107,118,192,14,119,130,98,58,30,240,78,82,92,41,243,244,22,155,88,173,177,36,101,141,23,23,104,208,169,114,135,156,169,212,42,56,25,105,187,205,102,134,20,41,244,239,118,231,151,98,129,5,43,144,179,218,71,169,118,242,175,24,55,197,61,79,175,237,18,53,211,186,231,49,20,90,149,224,137,51,148,80,106,233,61,76,164,70,179,148,110,78,74,183,230,240,123,127,47,121,205,84,134,224,2,105,97,221,3,187,221,170,26,199,72,107,68,51,149,132,62,141,239,8,70,186,163,184,58,134,1,99,241,14,153,123,116,28,220,116,1,33,188,90,102,173,107,226,144,130,51,91,94,83,217,248,116,75,182,87,203,224,8,126,240,248,126,194,181,37,47,255,9,220,138,124,38,100,159,98,96,192,104,195,22,183,246,202,150,82,71,126,154,137,8,69,239,164,63,202,212,126,246,17,49,14,85,193,166,26,56,123,227,155,208,157,179,107,48,184,134,115,183,10,53,26,154,61,151,248,24,27,148,30,92,154,210,58,199,237,2,254,111,4,75,217,192,1,124,29,36,78,163,66,236,68,107,212,55,18,102,134,101,156,44,52,138,95,210,172,48,61,57,134,111,155,83,34,15,5,57,89,210,38,85,76,220,248,172,205,35,114,140,247,41,181,85,229,145,96,116,182,213,142,243,37,43,112,95,187,189,172,63,176,184,67,135,105,204,198,100,254,68,177,155,106,129,248,0,95,70,127,175,233,128,137,92,114,204,200,62,60,252,12,59,240,69,109,122,167,137,13,134,210,182,108,174,250,229,15,126,214,50,169,246,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("62f7c1b7-845c-4ca7-86ea-eb981e255cb0"));
		}

		#endregion

	}

	#endregion

}

