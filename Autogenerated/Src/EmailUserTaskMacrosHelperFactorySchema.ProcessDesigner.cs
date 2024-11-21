namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailUserTaskMacrosHelperFactorySchema

	/// <exclude/>
	public class EmailUserTaskMacrosHelperFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailUserTaskMacrosHelperFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailUserTaskMacrosHelperFactorySchema(EmailUserTaskMacrosHelperFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d18446c3-8f82-456b-8ac3-209c16faa243");
			Name = "EmailUserTaskMacrosHelperFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1a6f4c5-4ce0-49cf-afb2-f720b4b96f90");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,82,203,110,194,48,16,60,27,169,255,224,170,151,68,66,249,0,16,7,160,180,229,64,21,21,250,1,198,89,18,171,137,29,217,155,210,168,226,223,107,39,36,36,64,81,79,189,88,217,199,204,236,78,86,178,12,76,206,56,208,89,184,90,171,29,6,115,165,33,8,181,226,96,140,13,228,78,196,133,102,40,148,188,27,124,223,13,72,97,132,140,233,186,52,8,217,184,141,79,232,14,160,161,121,4,35,98,9,218,182,91,192,131,134,216,22,233,60,101,198,140,232,34,99,34,125,55,160,55,204,124,172,24,215,202,188,64,154,131,126,98,28,149,46,43,76,94,108,83,193,169,65,203,203,41,119,200,63,0,137,157,215,190,173,226,10,48,81,145,213,12,43,186,186,216,167,94,94,97,181,91,124,138,8,52,125,6,236,234,120,14,78,72,133,216,64,150,167,12,161,65,210,226,248,49,164,46,101,109,145,192,157,39,85,225,20,250,212,121,74,200,86,169,212,149,166,81,38,228,155,136,19,52,116,210,146,4,107,144,81,173,83,230,64,239,39,212,19,18,253,94,54,152,22,168,220,15,33,196,236,5,242,132,122,222,76,69,101,51,153,235,241,91,194,139,202,113,14,194,153,177,183,112,86,13,122,59,142,234,78,162,1,11,45,169,132,61,189,234,65,207,171,70,185,21,34,228,204,152,122,221,83,98,216,233,187,176,165,147,56,182,29,198,183,22,56,94,226,141,21,194,186,227,215,171,250,191,13,34,216,177,34,197,102,70,76,180,218,87,35,190,42,92,218,249,33,3,137,16,45,190,56,228,78,198,243,107,224,193,189,246,169,78,222,158,70,125,245,85,92,103,251,201,195,15,36,181,88,250,252,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d18446c3-8f82-456b-8ac3-209c16faa243"));
		}

		#endregion

	}

	#endregion

}

