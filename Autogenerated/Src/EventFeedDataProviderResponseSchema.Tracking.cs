namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EventFeedDataProviderResponseSchema

	/// <exclude/>
	public class EventFeedDataProviderResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EventFeedDataProviderResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EventFeedDataProviderResponseSchema(EventFeedDataProviderResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cf4ac696-3045-4224-8196-29e9ed1c351b");
			Name = "EventFeedDataProviderResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,81,193,110,194,48,12,61,131,196,63,88,112,111,239,208,113,24,108,187,108,162,2,126,32,75,157,46,90,155,32,59,69,98,104,255,62,183,105,17,218,16,218,37,138,157,247,158,159,95,156,170,145,15,74,35,60,230,111,59,111,66,178,242,206,216,178,33,21,172,119,201,158,148,254,180,174,156,140,207,147,241,168,97,185,194,238,196,1,107,1,86,21,234,22,197,201,11,58,36,171,23,147,177,160,102,132,165,116,97,85,41,230,57,60,29,209,133,103,196,98,173,130,202,201,31,109,129,180,149,169,66,196,142,144,166,41,100,220,212,181,162,211,178,175,7,0,232,86,5,140,39,129,160,148,132,230,97,42,175,190,33,141,215,146,211,116,9,202,21,96,221,135,120,9,88,68,42,114,210,75,174,247,27,208,222,5,101,29,3,161,246,84,68,225,163,229,70,85,246,11,133,27,17,58,128,17,199,3,51,75,175,220,29,154,247,202,234,222,215,221,229,96,14,183,119,30,73,152,114,94,146,18,196,1,41,88,148,184,242,78,62,190,255,14,166,107,108,140,97,12,224,205,176,67,235,242,175,205,193,39,7,106,63,173,103,157,161,196,176,0,185,46,224,251,206,144,118,165,255,233,191,90,14,217,37,134,109,71,89,198,92,248,214,184,25,186,34,174,221,213,177,123,221,148,206,15,205,56,206,34,150,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cf4ac696-3045-4224-8196-29e9ed1c351b"));
		}

		#endregion

	}

	#endregion

}

