namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailTemplateUserTaskMLangBinderSchema

	/// <exclude/>
	public class EmailTemplateUserTaskMLangBinderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailTemplateUserTaskMLangBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailTemplateUserTaskMLangBinderSchema(EmailTemplateUserTaskMLangBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0b12cd08-0384-44fd-b87b-86ac638b898a");
			Name = "EmailTemplateUserTaskMLangBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6b752d82-945c-4729-b067-d3f384b1bc2d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,145,65,107,194,64,16,133,207,17,252,15,131,189,88,40,201,221,138,80,197,130,160,84,208,210,243,36,25,211,165,217,221,176,59,43,149,226,127,239,100,19,139,109,189,100,217,125,111,190,153,121,49,168,201,55,88,16,204,183,155,157,61,112,186,176,230,160,170,224,144,149,53,195,193,215,112,144,4,175,76,117,101,112,148,62,99,193,214,41,242,143,255,244,55,202,197,163,181,53,162,137,122,231,168,18,20,44,106,244,126,2,75,141,170,126,245,228,246,232,63,54,107,52,213,92,153,146,92,244,102,89,6,83,31,180,70,119,154,245,247,88,0,76,186,169,145,9,130,148,2,75,45,232,80,179,170,5,16,176,34,40,90,60,228,145,149,94,80,217,21,171,9,121,173,138,222,23,161,251,158,121,99,154,9,60,53,205,242,72,134,215,202,51,25,114,115,244,36,20,201,67,190,63,75,109,136,223,109,41,107,109,35,189,19,251,78,246,72,206,169,146,224,104,85,9,47,70,136,59,70,199,227,11,90,162,102,250,100,40,186,243,30,218,176,147,36,151,78,233,149,253,34,183,81,39,73,140,177,139,255,148,182,195,78,87,237,216,109,6,43,38,249,109,214,61,220,94,239,175,109,54,30,221,244,141,186,78,231,126,83,50,101,183,108,188,119,175,191,31,207,223,46,26,52,154,70,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b12cd08-0384-44fd-b87b-86ac638b898a"));
		}

		#endregion

	}

	#endregion

}

