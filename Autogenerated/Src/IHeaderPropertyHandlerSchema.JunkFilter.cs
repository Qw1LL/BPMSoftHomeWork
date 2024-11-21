namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IHeaderPropertyHandlerSchema

	/// <exclude/>
	public class IHeaderPropertyHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IHeaderPropertyHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IHeaderPropertyHandlerSchema(IHeaderPropertyHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d2905c9d-29e0-4bdd-9d08-907bf3906707");
			Name = "IHeaderPropertyHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d875cf44-2089-4c90-a894-025355d0d9a7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,65,106,195,48,16,69,215,53,248,14,67,86,237,198,62,64,83,47,26,40,201,34,16,104,47,48,150,199,177,82,89,18,163,113,130,41,189,123,37,219,105,10,41,104,163,175,249,143,167,177,216,83,240,168,8,94,15,251,119,215,74,177,113,182,213,199,129,81,180,179,121,246,149,103,15,101,89,194,58,12,125,143,60,86,203,125,103,133,184,77,69,215,2,245,168,13,116,132,13,49,120,118,158,88,70,232,208,54,134,184,184,18,202,63,8,63,212,70,43,208,191,148,221,118,106,31,150,242,118,238,198,201,36,112,103,48,5,123,146,206,53,32,29,74,4,53,90,161,80,128,75,23,227,168,113,212,103,178,112,70,51,16,232,0,168,20,121,193,218,16,212,99,236,196,104,241,3,199,96,157,36,205,123,207,57,241,200,216,131,141,187,122,89,77,196,85,53,235,222,62,59,197,197,186,156,70,111,77,38,25,216,134,234,131,147,70,11,248,175,81,20,129,55,52,33,46,51,185,95,116,72,168,107,55,193,106,231,12,108,58,82,159,143,174,62,145,146,153,243,244,28,31,191,243,44,158,31,193,79,208,254,202,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d2905c9d-29e0-4bdd-9d08-907bf3906707"));
		}

		#endregion

	}

	#endregion

}

