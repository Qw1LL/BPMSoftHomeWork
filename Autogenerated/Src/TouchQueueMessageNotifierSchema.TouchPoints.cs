namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TouchQueueMessageNotifierSchema

	/// <exclude/>
	public class TouchQueueMessageNotifierSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TouchQueueMessageNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TouchQueueMessageNotifierSchema(TouchQueueMessageNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("38be02db-3e45-4885-b616-878b6f010bac");
			Name = "TouchQueueMessageNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,84,77,111,219,48,12,61,167,64,255,3,225,93,82,96,136,239,205,199,161,93,81,244,144,34,109,186,31,160,200,116,162,53,146,92,74,42,16,20,251,239,163,36,123,73,188,164,216,118,176,33,81,228,227,123,143,150,141,208,232,26,33,17,110,22,243,165,173,253,232,214,154,90,173,3,9,175,172,185,188,248,184,188,24,4,167,204,26,150,59,231,81,143,127,239,247,5,132,28,229,248,23,194,53,23,193,237,86,56,119,13,47,54,200,205,83,192,128,115,116,78,172,241,209,122,85,43,164,148,92,150,37,76,92,208,90,208,110,214,238,83,33,120,11,38,102,238,64,172,108,240,188,103,28,120,139,64,160,51,18,52,100,37,47,35,15,66,23,182,222,141,58,204,242,0,180,9,171,173,146,32,19,238,89,62,112,13,55,194,225,105,170,3,118,128,223,123,113,214,56,79,65,122,75,172,113,145,26,228,140,190,162,44,105,159,14,53,63,19,135,8,146,176,158,22,103,249,20,229,44,83,142,154,254,20,149,35,141,32,161,193,240,252,166,69,112,72,220,200,160,140,67,43,102,147,50,157,166,228,214,130,179,205,134,223,143,138,225,24,235,138,189,89,177,55,195,126,248,3,126,182,190,160,169,178,53,199,62,45,200,122,78,198,234,132,73,202,108,144,148,175,172,44,51,199,46,23,236,59,18,169,10,129,77,139,195,237,88,62,178,78,152,206,32,155,182,176,202,120,87,140,255,11,242,25,181,50,21,175,150,114,131,90,116,200,209,73,91,15,19,254,213,248,115,109,115,244,27,91,157,26,255,95,208,184,15,170,130,123,244,203,176,250,193,71,15,213,48,126,124,47,194,189,30,142,7,218,47,157,157,142,56,3,66,31,200,164,226,209,157,110,252,46,94,196,65,59,131,127,116,128,155,103,95,101,186,228,223,208,73,82,77,92,126,74,229,107,87,111,27,204,191,135,231,116,245,122,20,123,167,135,60,123,126,230,232,113,144,99,191,0,66,172,12,201,148,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("38be02db-3e45-4885-b616-878b6f010bac"));
		}

		#endregion

	}

	#endregion

}

