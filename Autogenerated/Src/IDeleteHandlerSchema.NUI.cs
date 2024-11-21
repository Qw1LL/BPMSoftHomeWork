namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IDeleteHandlerSchema

	/// <exclude/>
	public class IDeleteHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDeleteHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDeleteHandlerSchema(IDeleteHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("20195bd2-50b1-4e93-a074-7128a08c449a");
			Name = "IDeleteHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,77,78,195,48,16,133,215,69,226,14,163,118,3,155,102,79,75,23,64,5,89,84,66,237,9,220,120,18,89,138,237,104,60,150,136,42,238,142,127,146,166,162,66,116,151,25,191,231,207,111,50,70,104,116,157,168,16,94,62,119,7,91,243,242,213,154,90,53,158,4,43,107,224,116,127,55,243,78,153,6,14,189,99,212,171,115,61,233,9,151,91,195,138,21,186,112,28,4,11,194,38,154,75,195,72,117,184,252,9,202,55,108,145,241,67,24,217,34,37,85,81,20,176,118,94,107,65,253,102,168,75,221,181,168,209,48,200,164,7,194,202,146,4,91,67,104,42,238,151,163,177,184,112,118,254,216,170,10,212,136,251,69,139,33,130,234,10,152,26,123,100,79,198,1,126,85,216,165,200,129,149,225,145,117,13,155,109,207,202,233,235,4,13,242,10,190,111,1,17,89,130,48,117,39,26,252,23,230,152,226,176,183,209,180,27,60,55,192,114,254,0,75,67,131,99,63,14,82,201,216,170,21,210,31,192,212,233,4,9,13,38,236,198,243,60,27,75,57,223,164,159,220,95,94,177,46,146,114,50,82,14,185,217,163,243,45,95,164,91,23,227,81,212,30,173,109,135,55,62,188,123,37,135,215,149,242,49,47,80,142,182,64,35,243,38,197,50,244,126,0,30,198,115,141,173,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("20195bd2-50b1-4e93-a074-7128a08c449a"));
		}

		#endregion

	}

	#endregion

}

