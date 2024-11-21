namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: NotificationCounterFactorySchema

	/// <exclude/>
	public class NotificationCounterFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NotificationCounterFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NotificationCounterFactorySchema(NotificationCounterFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b249d9e1-6ca1-4cdb-b5cf-9f2e4cc638b6");
			Name = "NotificationCounterFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,84,193,138,219,48,16,61,59,144,127,24,220,139,23,22,251,190,77,2,219,208,13,57,236,18,186,244,92,20,123,236,136,202,82,24,73,41,97,217,127,175,36,219,137,99,156,236,182,224,139,70,51,111,222,123,51,178,100,53,234,61,203,17,190,109,158,95,85,105,210,165,146,37,175,44,49,195,149,156,78,222,166,147,200,106,46,43,120,61,106,131,181,187,23,2,115,127,169,211,21,74,36,158,127,61,229,156,65,234,90,201,177,56,225,120,52,125,98,185,81,196,81,251,123,247,125,33,172,92,19,88,10,166,245,3,188,40,195,75,158,7,86,75,101,165,65,106,42,142,211,137,203,206,178,12,102,218,214,53,163,227,162,61,111,72,29,120,129,26,24,212,104,118,170,0,163,128,229,57,106,13,102,135,144,123,100,119,93,42,130,10,141,241,148,66,188,129,215,105,135,155,245,128,247,118,43,120,222,212,222,32,5,15,176,190,69,57,122,139,188,200,147,202,39,142,162,112,50,55,196,15,204,96,208,20,237,155,3,16,178,66,73,113,132,159,26,201,205,71,54,254,195,47,123,113,118,198,5,72,148,69,131,218,158,59,35,221,196,12,89,79,192,55,10,58,218,62,141,166,235,124,147,65,227,203,190,119,224,151,36,138,46,163,233,114,135,249,239,71,170,108,141,210,188,88,33,18,233,150,77,149,201,160,250,206,15,60,138,6,98,96,62,232,18,178,222,111,75,124,14,99,190,102,227,250,187,116,92,136,109,5,206,198,134,179,128,21,154,145,184,94,59,227,152,116,123,147,56,3,253,150,84,164,236,190,147,125,96,4,188,203,112,180,195,194,182,198,185,23,98,30,133,24,111,151,4,152,251,0,18,73,252,211,159,80,231,91,18,95,186,16,223,15,167,222,249,71,104,44,201,51,147,127,243,171,183,13,195,167,20,2,63,2,186,238,9,85,165,203,66,247,90,8,203,121,60,38,48,206,22,176,61,246,179,250,73,43,47,222,165,156,90,246,95,89,19,217,51,98,53,248,173,153,199,193,171,120,241,1,216,44,11,53,103,136,198,21,189,56,255,181,62,71,124,150,117,149,189,7,242,223,11,52,186,55,237,192,62,220,185,166,232,218,56,219,88,63,244,254,23,252,161,210,101,213,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b249d9e1-6ca1-4cdb-b5cf-9f2e4cc638b6"));
		}

		#endregion

	}

	#endregion

}

