namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: GoogleSynchronizationDataAccessExceptionSchema

	/// <exclude/>
	public class GoogleSynchronizationDataAccessExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GoogleSynchronizationDataAccessExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GoogleSynchronizationDataAccessExceptionSchema(GoogleSynchronizationDataAccessExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fa6fe31b-4855-4a7a-adcc-c5b7fb65f30f");
			Name = "GoogleSynchronizationDataAccessException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,146,193,106,195,48,16,68,207,54,248,31,150,228,98,67,136,239,110,27,104,146,210,83,33,224,47,216,40,107,87,96,75,66,146,105,221,210,127,175,108,197,181,147,246,144,208,246,168,97,103,246,13,43,129,53,25,133,140,96,189,123,202,101,97,151,27,41,10,94,54,26,45,151,34,10,223,163,48,10,131,198,112,81,66,222,26,75,245,77,175,204,53,149,110,0,54,21,26,147,193,163,148,101,69,121,43,216,179,150,130,191,245,238,45,90,188,103,140,140,121,120,101,164,124,160,243,166,105,10,183,166,169,107,212,237,234,248,246,1,128,138,195,193,217,0,123,31,208,96,132,23,141,74,145,94,14,254,116,18,160,154,125,197,25,176,142,229,98,20,200,96,130,21,248,162,99,47,41,140,213,13,179,82,187,122,187,126,129,159,56,167,63,10,68,192,52,21,119,179,175,208,56,153,165,171,142,247,59,240,64,124,41,107,156,128,227,11,130,143,107,17,92,7,119,185,63,4,241,129,224,126,141,193,146,146,46,34,200,96,143,134,226,65,251,21,234,98,60,202,191,81,79,118,0,23,130,244,184,242,135,62,139,243,153,147,126,115,18,7,255,101,250,183,87,79,69,167,125,2,94,200,108,137,103,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fa6fe31b-4855-4a7a-adcc-c5b7fb65f30f"));
		}

		#endregion

	}

	#endregion

}

