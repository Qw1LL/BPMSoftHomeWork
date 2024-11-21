namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: StatisticEventTypeSchema

	/// <exclude/>
	public class StatisticEventTypeSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public StatisticEventTypeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public StatisticEventTypeSchema(StatisticEventTypeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4f9f834a-d6b3-457b-ba8a-e93406998209");
			Name = "StatisticEventType";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b39fd9cb-6840-4142-8022-7c9d0489d323");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,147,91,75,132,64,24,134,175,21,252,15,195,118,83,16,43,29,47,170,237,162,18,186,89,136,172,171,136,80,247,91,27,114,14,204,33,144,232,191,247,141,174,182,162,200,174,151,51,62,239,251,61,131,51,60,97,160,101,146,1,185,123,90,198,98,109,230,247,130,175,105,110,85,98,168,224,129,255,19,248,158,213,148,231,36,46,181,1,134,223,153,20,28,184,89,138,21,20,215,129,143,192,129,130,28,105,18,113,203,174,72,108,48,171,13,205,162,111,196,94,74,9,21,20,134,33,185,209,150,177,68,149,183,155,117,139,18,131,152,158,55,88,184,197,73,155,22,8,0,118,15,86,123,78,177,215,94,109,68,44,161,5,209,77,200,213,247,251,189,183,7,208,153,162,210,29,248,112,6,46,243,209,102,244,236,232,221,65,85,85,59,94,147,5,57,57,174,142,53,60,249,25,50,42,41,58,238,57,93,53,185,190,65,91,217,177,56,221,205,226,83,88,85,148,147,101,234,248,136,211,99,5,116,204,206,118,52,195,159,168,10,202,191,166,203,53,13,99,126,13,211,81,60,31,83,172,47,207,84,189,250,26,141,168,85,245,195,90,23,99,90,175,92,219,212,13,74,97,79,37,251,159,220,56,108,119,45,200,37,110,253,214,239,25,248,170,126,210,110,137,123,127,250,109,241,38,39,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f9f834a-d6b3-457b-ba8a-e93406998209"));
		}

		#endregion

	}

	#endregion

}

