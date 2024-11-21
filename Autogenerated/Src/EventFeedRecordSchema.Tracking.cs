namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EventFeedRecordSchema

	/// <exclude/>
	public class EventFeedRecordSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EventFeedRecordSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EventFeedRecordSchema(EventFeedRecordSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("effa70fc-e7f0-40c3-a8f5-cf38bfc84003");
			Name = "EventFeedRecord";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,148,79,111,212,48,16,197,207,173,212,239,48,42,23,184,100,239,148,63,106,119,65,69,162,16,237,174,224,128,56,56,206,36,49,56,118,52,158,108,89,42,190,59,147,100,219,93,202,38,36,92,156,216,239,249,247,60,163,196,78,149,24,42,165,17,174,226,155,149,207,56,154,123,151,153,188,38,197,198,187,104,77,74,127,55,46,63,59,189,59,59,61,169,131,188,194,106,27,24,203,139,71,243,104,89,59,54,37,70,43,36,163,172,249,217,2,196,37,190,39,132,185,76,96,110,85,8,207,225,205,6,29,191,69,76,151,168,61,165,173,101,54,155,193,139,80,151,165,162,237,171,221,124,177,254,8,62,249,134,154,225,182,48,186,0,237,29,43,227,2,24,151,121,42,219,4,200,200,151,160,173,175,83,80,137,175,25,188,67,160,150,220,109,144,237,153,132,69,247,41,179,131,152,47,11,197,74,74,102,169,147,191,202,66,85,39,214,104,225,201,73,255,62,232,137,116,65,198,135,130,98,242,21,18,27,148,170,226,118,103,167,183,216,27,44,19,164,167,31,164,197,240,18,206,77,122,254,172,73,184,143,8,76,77,247,218,140,119,41,220,65,142,124,1,161,25,126,245,83,120,91,97,63,103,45,234,88,146,147,103,63,169,117,141,36,109,148,173,7,80,159,26,121,44,75,251,192,253,168,185,168,99,73,169,226,227,135,90,203,87,26,88,149,213,88,82,65,152,29,37,93,139,48,22,34,86,36,66,58,10,90,238,196,177,48,171,92,94,171,252,120,125,239,119,226,88,88,101,21,55,191,211,81,88,188,19,199,194,18,242,183,161,167,202,171,78,155,90,100,24,172,50,140,197,5,77,136,238,179,73,185,248,19,104,28,191,134,213,94,157,6,188,70,147,23,220,75,236,228,105,200,216,252,64,187,192,106,224,160,123,203,52,244,229,70,25,59,220,131,203,7,203,127,160,255,209,141,3,207,52,248,220,91,79,195,45,217,91,30,163,229,190,70,151,118,87,118,27,212,197,29,46,202,202,111,219,124,211,235,11,7,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("effa70fc-e7f0-40c3-a8f5-cf38bfc84003"));
		}

		#endregion

	}

	#endregion

}

