namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: RequestContentTypeSchema

	/// <exclude/>
	public class RequestContentTypeSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RequestContentTypeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RequestContentTypeSchema(RequestContentTypeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9276eb3a-690d-4f9a-89bf-69e191abc4b4");
			Name = "RequestContentType";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,143,189,10,194,64,16,132,235,28,228,29,22,44,210,229,172,69,45,20,27,65,16,205,11,156,113,19,35,222,143,247,83,4,241,221,221,220,69,16,98,57,187,223,206,236,40,33,209,25,81,35,108,142,135,179,110,124,185,213,170,233,218,96,133,239,180,202,217,43,103,57,203,102,22,91,146,176,83,65,46,224,132,207,128,206,19,233,81,249,170,55,24,33,206,57,44,93,144,82,216,126,61,234,234,134,96,19,14,117,226,193,211,65,249,229,249,207,129,9,151,71,87,3,82,200,223,140,44,61,51,9,138,131,145,140,238,80,8,99,200,42,118,224,119,167,85,49,4,78,19,179,61,237,96,5,243,104,252,78,93,81,93,83,221,65,210,236,3,115,54,15,143,36,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9276eb3a-690d-4f9a-89bf-69e191abc4b4"));
		}

		#endregion

	}

	#endregion

}

