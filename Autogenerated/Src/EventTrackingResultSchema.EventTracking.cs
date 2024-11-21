namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EventTrackingResultSchema

	/// <exclude/>
	public class EventTrackingResultSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EventTrackingResultSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EventTrackingResultSchema(EventTrackingResultSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("994af77d-fdfe-407e-9278-b280ee07b73c");
			Name = "EventTrackingResult";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("47949cd8-6780-414e-8fda-4fa996b6db3c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,221,74,196,48,16,70,175,83,232,59,4,188,149,197,127,65,240,162,235,86,88,68,87,172,62,64,76,167,221,176,237,36,76,38,66,145,125,119,167,89,65,47,246,110,230,124,135,143,97,208,140,16,131,177,160,151,175,207,141,239,120,241,224,177,115,125,34,195,206,227,162,254,2,228,119,50,118,231,176,127,131,152,6,46,139,239,178,40,11,117,66,208,139,162,107,76,227,157,62,42,150,133,10,233,115,112,86,131,72,199,29,37,109,74,109,118,250,94,159,157,206,99,21,220,19,76,47,158,31,125,194,86,240,121,198,107,236,200,68,166,100,57,17,72,188,130,48,248,9,102,227,34,27,27,222,2,213,68,158,4,93,254,235,170,6,2,211,78,31,49,203,87,191,117,214,19,129,229,101,24,171,196,91,209,36,187,206,89,51,197,6,152,229,200,117,172,199,192,115,114,147,147,149,31,141,195,63,122,43,112,127,248,6,96,123,120,200,188,238,127,0,177,216,151,208,88,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("994af77d-fdfe-407e-9278-b280ee07b73c"));
		}

		#endregion

	}

	#endregion

}

