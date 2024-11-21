namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DelayedNotificationCleaningSchema

	/// <exclude/>
	public class DelayedNotificationCleaningSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DelayedNotificationCleaningSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DelayedNotificationCleaningSchema(DelayedNotificationCleaningSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("df08478c-376b-45c2-ab1f-44f5d2bfcce8");
			Name = "DelayedNotificationCleaning";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,82,193,78,227,48,16,61,7,137,127,24,101,47,137,132,156,59,91,42,65,11,171,174,4,170,182,66,156,93,103,218,26,57,118,53,182,203,86,171,254,251,78,156,180,16,64,112,177,60,111,102,222,60,207,179,149,13,250,173,84,8,55,243,251,133,91,5,49,113,118,165,215,145,100,208,206,158,159,253,59,63,203,162,215,118,13,139,189,15,216,112,222,24,84,109,210,139,95,104,145,180,250,121,170,153,56,194,97,36,166,55,239,128,133,218,96,29,13,18,227,156,249,65,184,102,50,152,24,233,61,92,194,20,141,220,99,253,224,130,94,105,149,84,76,12,74,203,253,169,190,170,42,24,249,216,52,146,246,227,62,254,131,91,66,143,54,120,144,160,250,106,120,118,75,112,43,144,134,80,214,123,104,243,96,223,208,122,113,164,171,222,240,109,227,210,104,197,44,173,156,47,196,176,212,217,111,183,188,253,139,42,6,71,220,201,171,226,243,244,160,123,12,27,87,183,79,154,39,202,46,251,94,126,2,120,12,6,244,223,72,253,168,181,67,182,146,100,3,150,157,188,202,163,71,98,7,109,231,80,62,126,228,24,212,9,16,163,42,85,127,222,156,238,44,132,124,62,158,159,238,131,158,126,59,59,77,33,74,3,59,167,107,232,86,128,197,227,96,54,12,165,92,192,108,170,211,141,181,143,124,32,94,225,5,184,229,51,167,199,240,58,185,132,246,199,101,217,78,18,212,105,45,112,5,22,95,250,29,21,67,214,50,213,102,226,142,92,83,228,159,184,149,31,43,158,54,72,88,228,215,170,213,189,64,91,79,101,192,188,20,92,92,148,98,230,31,162,49,69,9,50,121,206,131,218,79,155,101,157,2,113,124,97,153,208,67,150,245,78,51,77,103,118,138,15,221,127,30,128,135,255,151,198,56,10,97,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("df08478c-376b-45c2-ab1f-44f5d2bfcce8"));
		}

		#endregion

	}

	#endregion

}

