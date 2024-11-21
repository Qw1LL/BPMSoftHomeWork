namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: StopEmailRequestSchema

	/// <exclude/>
	public class StopEmailRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public StopEmailRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public StopEmailRequestSchema(StopEmailRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3d11e55e-cb8c-465a-9cb7-dfaf13400a61");
			Name = "StopEmailRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,82,77,107,194,64,20,60,87,240,63,60,210,75,123,73,238,126,20,170,21,233,193,34,198,91,41,229,153,125,73,23,118,179,233,238,91,193,138,255,189,155,141,90,170,208,94,18,102,50,243,152,25,2,53,106,114,13,22,4,147,229,34,55,37,167,83,83,151,178,242,22,89,154,58,157,206,242,133,17,164,92,191,183,239,247,110,188,147,117,5,249,206,49,233,225,5,78,87,190,102,169,41,205,201,74,84,242,43,94,8,170,160,187,181,84,5,0,83,133,206,13,224,81,136,53,233,70,33,211,138,62,61,57,142,170,44,203,96,228,188,214,104,119,15,71,28,29,80,26,11,182,83,2,27,112,108,26,32,141,82,165,39,91,118,225,27,57,34,84,206,64,97,169,28,39,255,180,75,39,232,40,228,222,202,226,148,40,129,172,189,245,250,132,140,193,197,22,11,126,11,68,227,55,74,22,80,196,92,121,8,50,107,115,28,77,48,128,235,75,193,20,182,11,207,243,12,75,107,26,178,44,41,108,177,140,247,186,239,151,3,68,98,78,236,32,244,119,237,155,63,168,43,14,82,80,152,187,148,100,219,13,174,71,232,152,45,42,79,103,184,254,219,253,35,142,173,23,164,55,100,239,94,194,47,2,99,72,162,241,93,138,228,190,157,225,180,195,220,75,1,113,130,103,1,123,168,136,135,109,210,33,28,142,149,169,22,93,235,136,59,246,55,121,248,6,10,196,146,41,134,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3d11e55e-cb8c-465a-9cb7-dfaf13400a61"));
		}

		#endregion

	}

	#endregion

}

