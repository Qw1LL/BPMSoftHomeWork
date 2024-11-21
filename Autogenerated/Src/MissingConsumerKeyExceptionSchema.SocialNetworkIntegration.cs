namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MissingConsumerKeyExceptionSchema

	/// <exclude/>
	public class MissingConsumerKeyExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MissingConsumerKeyExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MissingConsumerKeyExceptionSchema(MissingConsumerKeyExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("430df10a-1542-481b-a502-d52c3facc4ee");
			Name = "MissingConsumerKeyException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,141,59,10,195,48,16,68,107,9,116,135,133,244,62,128,211,197,164,10,134,128,78,160,40,107,177,160,31,94,9,98,130,239,30,41,110,82,165,152,98,135,183,243,162,9,200,217,88,132,203,125,214,105,41,195,148,226,66,174,174,166,80,138,131,78,150,140,87,242,173,164,168,76,209,129,222,184,96,56,43,217,154,211,138,174,81,48,121,195,60,194,76,220,145,182,192,53,224,122,195,237,250,178,152,251,208,23,207,245,225,201,130,237,244,63,24,70,248,121,20,221,45,90,246,195,137,241,121,104,251,185,127,0,215,114,143,25,193,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("430df10a-1542-481b-a502-d52c3facc4ee"));
		}

		#endregion

	}

	#endregion

}

