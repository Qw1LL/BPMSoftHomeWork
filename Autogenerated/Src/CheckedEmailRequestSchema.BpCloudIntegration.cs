namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CheckedEmailRequestSchema

	/// <exclude/>
	public class CheckedEmailRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CheckedEmailRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CheckedEmailRequestSchema(CheckedEmailRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("942945d7-ac66-48ca-b114-0dbc0d994415");
			Name = "CheckedEmailRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,146,65,79,2,49,16,133,207,146,248,31,38,120,209,203,238,93,192,3,72,140,7,12,1,111,198,67,233,190,197,198,110,187,118,186,36,72,252,239,78,119,65,17,77,188,180,153,233,155,215,190,47,117,170,2,215,74,131,198,243,217,210,151,49,155,120,87,154,117,19,84,52,222,101,147,233,114,230,11,88,62,239,237,206,123,103,13,27,183,166,229,150,35,42,81,90,11,157,100,156,221,193,33,24,61,56,213,44,26,23,77,133,108,41,167,202,154,247,214,85,84,162,187,8,88,75,65,19,171,152,175,105,242,2,253,138,98,90,41,99,23,120,107,192,177,149,229,121,78,67,110,170,74,133,237,205,190,94,160,14,96,184,200,20,58,41,69,79,58,57,16,146,1,167,122,5,218,200,181,165,65,65,114,79,29,252,198,20,8,196,178,102,7,231,252,196,122,200,128,178,44,110,1,229,168,255,15,149,108,172,24,146,109,99,52,246,143,238,83,158,188,158,110,85,84,50,21,131,210,241,89,26,117,179,178,70,147,78,105,255,10,75,215,244,219,76,230,4,187,172,95,180,230,193,215,8,209,64,144,205,91,203,238,60,63,193,212,54,238,32,132,188,36,78,123,124,1,89,35,23,249,242,8,82,11,45,209,248,141,163,235,108,148,109,240,85,62,138,73,55,124,52,243,45,105,83,207,80,173,16,46,31,228,107,209,136,250,157,188,127,149,32,28,40,220,79,93,83,33,168,149,197,144,99,144,15,115,67,45,12,166,29,173,17,7,233,201,3,250,216,103,135,43,186,248,109,221,117,127,54,165,247,9,2,208,100,71,203,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("942945d7-ac66-48ca-b114-0dbc0d994415"));
		}

		#endregion

	}

	#endregion

}

