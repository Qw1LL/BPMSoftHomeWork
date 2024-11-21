namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MissingConsumerSecretExceptionSchema

	/// <exclude/>
	public class MissingConsumerSecretExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MissingConsumerSecretExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MissingConsumerSecretExceptionSchema(MissingConsumerSecretExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0f8b9071-26fc-4a2e-b670-8e728d131210");
			Name = "MissingConsumerSecretException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,142,61,10,195,48,12,70,103,27,124,7,65,247,28,32,221,26,58,6,10,62,129,171,42,198,224,63,44,27,90,74,238,94,187,89,186,117,208,32,241,222,247,41,154,64,156,13,18,92,110,171,78,91,157,150,20,55,103,91,49,213,165,56,233,132,206,120,37,223,74,138,198,46,90,208,47,174,20,206,74,246,203,169,144,237,20,44,222,48,207,176,58,30,72,79,224,22,168,104,194,66,245,250,68,202,35,235,107,228,118,247,14,1,135,240,135,135,25,126,92,49,62,16,125,246,163,153,226,227,40,31,235,254,1,156,88,222,155,199,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0f8b9071-26fc-4a2e-b670-8e728d131210"));
		}

		#endregion

	}

	#endregion

}

