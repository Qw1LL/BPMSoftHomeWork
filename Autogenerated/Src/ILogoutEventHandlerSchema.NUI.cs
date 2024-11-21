namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ILogoutEventHandlerSchema

	/// <exclude/>
	public class ILogoutEventHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ILogoutEventHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ILogoutEventHandlerSchema(ILogoutEventHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("06f8ea2d-d42f-9e96-1ad8-2155021d7863");
			Name = "ILogoutEventHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,145,207,106,195,48,12,135,207,41,228,29,68,122,217,46,201,189,75,115,216,24,172,176,66,97,219,3,184,142,146,26,252,39,88,118,199,24,125,247,41,246,58,218,178,91,172,252,244,249,147,101,133,65,154,132,68,120,220,109,223,220,16,234,39,103,7,53,70,47,130,114,182,92,124,151,139,34,146,178,227,69,192,227,67,185,224,250,210,227,200,33,216,216,128,126,96,200,10,54,175,110,116,49,60,31,209,134,23,97,123,141,62,69,155,166,129,150,162,49,194,127,117,191,231,157,119,71,213,35,129,152,20,12,206,67,197,172,72,232,65,39,72,5,66,206,18,4,202,76,26,13,35,147,84,125,230,53,23,192,41,238,181,146,160,206,42,255,153,0,15,195,209,63,239,45,134,131,235,105,5,187,212,156,127,222,154,22,115,225,253,160,8,76,138,195,167,210,26,246,8,82,104,141,61,127,177,58,102,111,66,162,25,140,182,103,19,224,192,141,58,205,238,137,120,37,159,43,147,240,194,128,229,141,172,171,40,171,174,37,228,91,60,14,235,234,131,233,188,24,139,233,65,170,166,99,60,5,97,37,214,109,147,250,18,230,232,84,15,121,216,52,247,221,117,31,68,121,159,55,87,44,89,49,191,66,58,159,242,62,175,138,167,31,101,15,178,0,28,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("06f8ea2d-d42f-9e96-1ad8-2155021d7863"));
		}

		#endregion

	}

	#endregion

}

