namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailUserTaskSenderFactorySchema

	/// <exclude/>
	public class EmailUserTaskSenderFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailUserTaskSenderFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailUserTaskSenderFactorySchema(EmailUserTaskSenderFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("638e470d-51ca-4d2c-ac7f-a8a2d6682831");
			Name = "EmailUserTaskSenderFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("da7de29a-d2b3-4248-bf8e-b7a592dc81f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,81,193,78,195,48,12,61,103,210,254,193,210,46,221,165,31,48,196,1,198,64,59,12,85,218,248,128,144,122,93,68,155,84,137,163,50,161,253,59,78,179,14,42,85,220,184,56,241,179,223,243,147,109,100,131,190,149,10,225,177,216,237,237,145,242,181,117,152,23,206,42,244,158,19,115,212,85,112,146,180,53,243,217,215,124,38,130,215,166,130,253,217,19,54,119,183,252,135,253,139,48,200,60,161,215,149,65,199,237,76,88,56,172,184,8,235,90,122,191,130,77,35,117,253,230,209,29,164,255,216,163,41,209,61,75,69,214,157,251,238,54,188,215,90,129,39,86,84,160,34,231,79,138,96,143,28,111,83,118,72,39,91,242,156,162,23,74,197,177,232,118,66,15,94,144,122,56,165,89,255,63,96,211,214,146,112,104,133,112,253,44,33,110,70,8,223,105,82,39,200,178,200,74,148,115,139,203,161,45,31,195,87,146,80,210,35,140,74,249,67,32,187,74,85,225,144,130,51,96,176,131,8,79,153,189,10,9,17,113,62,129,65,21,247,15,247,55,135,249,184,50,79,253,151,120,192,105,7,59,105,130,172,39,60,164,194,127,184,40,241,40,67,77,195,76,58,57,219,245,35,95,45,109,121,243,216,160,33,44,55,159,10,219,72,207,150,137,120,137,145,67,124,22,108,37,93,190,207,19,58,6,25,251,6,191,246,242,0,246,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("638e470d-51ca-4d2c-ac7f-a8a2d6682831"));
		}

		#endregion

	}

	#endregion

}

