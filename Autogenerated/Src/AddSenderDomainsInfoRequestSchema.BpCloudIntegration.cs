namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AddSenderDomainsInfoRequestSchema

	/// <exclude/>
	public class AddSenderDomainsInfoRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AddSenderDomainsInfoRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AddSenderDomainsInfoRequestSchema(AddSenderDomainsInfoRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7cef863d-9684-4a82-a74b-e9746da57616");
			Name = "AddSenderDomainsInfoRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,77,79,194,64,20,60,75,194,127,120,41,23,189,180,119,62,76,4,140,241,128,33,212,155,241,176,116,95,235,38,237,110,221,183,139,65,226,127,119,63,0,21,136,132,83,251,166,51,211,55,179,43,89,131,212,178,2,97,60,159,229,170,52,233,68,201,82,84,86,51,35,148,76,39,247,249,76,113,172,169,219,217,116,59,221,206,149,37,33,43,200,215,100,176,73,23,86,26,209,96,154,163,22,172,22,159,65,51,8,188,158,198,202,13,48,169,25,81,31,238,56,207,81,114,212,83,213,48,33,233,81,150,106,129,239,22,201,4,122,150,101,48,36,219,52,76,175,111,183,115,144,66,169,52,232,200,4,163,128,113,14,18,63,128,130,27,240,96,151,238,28,178,3,139,33,33,178,154,20,20,26,203,81,114,38,99,58,102,132,46,203,74,20,184,93,46,129,204,123,189,76,153,97,78,101,52,43,204,171,3,90,187,172,69,1,69,88,241,159,112,208,135,99,83,167,143,101,238,91,154,107,213,162,54,2,93,85,243,96,29,191,31,214,18,128,7,52,4,174,21,242,79,243,134,191,74,56,110,33,34,43,86,91,220,143,207,167,52,63,148,16,118,134,205,18,245,245,147,187,31,48,130,36,210,147,27,159,125,23,158,140,246,119,33,134,134,13,84,104,6,126,169,1,124,93,178,189,244,191,80,101,120,111,181,90,9,87,228,101,89,206,56,252,159,108,39,240,243,201,124,238,108,246,132,83,41,123,238,232,227,49,134,57,162,127,65,135,125,3,60,105,252,222,105,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7cef863d-9684-4a82-a74b-e9746da57616"));
		}

		#endregion

	}

	#endregion

}

