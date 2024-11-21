namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MissingConsumerInfoServiceUriExceptionSchema

	/// <exclude/>
	public class MissingConsumerInfoServiceUriExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MissingConsumerInfoServiceUriExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MissingConsumerInfoServiceUriExceptionSchema(MissingConsumerInfoServiceUriExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5e6523ca-dcf1-4c7d-a366-78c39999c290");
			Name = "MissingConsumerInfoServiceUriException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,142,49,10,195,48,12,69,231,24,114,7,65,247,28,32,221,26,58,116,8,20,76,14,224,170,138,17,56,118,176,236,210,82,114,247,218,205,210,177,131,134,47,254,123,124,111,22,146,213,32,193,233,58,234,48,167,110,8,126,102,155,163,73,28,124,167,3,178,113,173,122,183,170,201,194,222,130,126,73,162,229,216,170,242,57,68,178,165,5,131,51,34,61,140,44,181,82,12,146,23,138,23,63,7,77,241,193,72,83,228,243,19,105,173,206,47,185,230,155,99,4,172,224,159,28,244,240,227,104,234,162,166,220,182,47,33,127,223,199,212,184,125,0,209,13,187,56,215,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5e6523ca-dcf1-4c7d-a366-78c39999c290"));
		}

		#endregion

	}

	#endregion

}

