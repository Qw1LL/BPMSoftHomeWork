namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailUserTaskMessageProviderFactorySchema

	/// <exclude/>
	public class EmailUserTaskMessageProviderFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailUserTaskMessageProviderFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailUserTaskMessageProviderFactorySchema(EmailUserTaskMessageProviderFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("31e7a4a6-b0cf-4c1c-8657-06e2b3d26b6a");
			Name = "EmailUserTaskMessageProviderFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("da7de29a-d2b3-4248-bf8e-b7a592dc81f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,75,110,131,48,16,93,19,41,119,176,212,13,217,112,128,116,151,52,173,178,160,138,20,122,0,215,76,192,42,216,200,51,148,162,170,119,239,96,62,109,232,39,217,140,152,55,239,51,242,96,100,9,88,73,5,98,115,136,143,246,68,209,214,58,136,14,206,42,64,228,198,156,116,86,59,73,218,154,229,226,125,185,8,106,212,38,19,199,22,9,202,219,169,255,82,127,19,140,54,119,128,58,51,224,152,206,130,27,7,25,15,197,182,144,136,107,177,43,165,46,158,16,92,34,241,37,102,182,204,128,117,175,58,5,119,47,21,89,215,122,89,85,63,23,90,9,36,182,86,66,117,226,235,180,1,111,205,117,202,141,129,114,155,114,242,193,59,246,195,115,247,253,127,198,226,1,200,207,103,120,232,193,4,202,170,144,4,163,88,212,195,199,74,116,175,23,4,216,104,82,185,8,195,141,77,219,145,157,180,21,172,70,102,244,99,50,72,3,37,145,15,53,155,70,103,185,235,158,25,56,160,218,25,97,160,17,191,238,21,207,150,159,214,236,110,250,103,212,112,208,75,97,51,218,181,153,41,156,100,93,208,232,74,185,179,141,55,125,180,180,103,43,40,193,16,164,187,55,5,85,247,127,133,131,240,163,171,92,252,149,193,164,253,161,125,223,163,231,32,99,159,186,245,90,137,247,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("31e7a4a6-b0cf-4c1c-8657-06e2b3d26b6a"));
		}

		#endregion

	}

	#endregion

}

