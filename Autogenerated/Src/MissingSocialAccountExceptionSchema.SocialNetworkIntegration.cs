namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MissingSocialAccountExceptionSchema

	/// <exclude/>
	public class MissingSocialAccountExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MissingSocialAccountExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MissingSocialAccountExceptionSchema(MissingSocialAccountExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4f684624-c132-4775-9271-2d2847917daa");
			Name = "MissingSocialAccountException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,141,193,10,195,32,12,64,207,10,254,67,96,247,126,64,119,218,202,142,133,129,95,224,50,43,1,27,165,42,116,140,254,251,116,94,118,218,33,135,132,247,242,216,172,54,69,131,22,174,247,89,135,37,15,83,224,133,92,217,76,166,192,131,14,72,198,43,249,86,82,148,68,236,64,191,82,182,235,89,201,122,57,109,214,85,10,38,111,82,26,97,166,212,144,238,92,16,67,225,124,219,209,198,246,234,43,196,242,240,132,128,141,255,143,195,8,63,170,104,125,81,231,232,93,203,207,158,110,235,241,1,244,114,113,18,197,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f684624-c132-4775-9271-2d2847917daa"));
		}

		#endregion

	}

	#endregion

}

