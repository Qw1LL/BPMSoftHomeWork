namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailStatisticHandlerSchema

	/// <exclude/>
	public class EmailStatisticHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailStatisticHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailStatisticHandlerSchema(EmailStatisticHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5d44b0b4-3404-4787-ab8e-d4ae4b31c20c");
			Name = "EmailStatisticHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("56ea33ea-e32a-430c-959f-44e40c0eb1dc");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,203,75,204,77,45,46,72,76,78,85,112,10,240,13,206,79,43,209,115,206,207,75,203,76,47,45,74,44,201,204,207,83,168,230,229,226,84,46,74,77,7,177,157,115,18,139,139,173,20,92,115,19,51,115,130,75,128,242,197,37,153,201,30,137,121,41,57,169,69,188,92,64,133,5,165,73,57,153,201,10,201,32,117,216,149,129,204,3,43,173,5,147,202,169,121,41,16,195,121,185,106,1,39,13,63,238,139,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5d44b0b4-3404-4787-ab8e-d4ae4b31c20c"));
		}

		#endregion

	}

	#endregion

}

