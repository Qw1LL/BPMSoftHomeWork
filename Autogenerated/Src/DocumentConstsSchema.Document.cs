namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DocumentConstsSchema

	/// <exclude/>
	public class DocumentConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DocumentConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DocumentConstsSchema(DocumentConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c6fbe5f3-8af5-45bb-b253-d7c21e1e0cb2");
			Name = "DocumentConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e5f52fab-ebea-4990-be49-0763f7c9fbd6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,144,193,106,195,32,24,128,207,13,228,29,164,167,237,224,80,19,77,164,236,96,52,25,59,140,13,250,4,153,177,37,144,104,81,195,40,163,239,62,187,221,178,195,6,61,252,7,127,62,191,15,126,219,207,38,156,122,109,64,243,246,178,119,135,248,32,157,61,140,199,197,247,113,116,54,207,62,243,108,179,132,209,30,193,254,28,162,153,119,233,189,73,115,90,222,167,81,131,16,19,167,129,158,250,16,128,114,122,153,141,141,73,17,98,72,208,245,243,138,244,166,31,156,157,206,224,105,25,7,144,200,232,123,29,159,7,240,8,172,249,248,222,222,109,11,222,144,154,145,18,242,186,101,80,117,24,67,94,225,6,34,132,21,67,45,47,106,201,182,247,187,191,236,226,151,152,225,174,18,180,42,32,37,183,136,165,243,62,157,205,217,193,88,109,86,13,34,27,42,133,196,16,83,82,192,22,165,134,224,165,184,54,40,85,168,44,8,42,255,209,120,245,131,241,43,117,221,52,188,163,82,38,33,106,97,89,85,29,228,165,164,144,17,161,56,82,45,147,82,252,168,47,121,118,249,2,157,55,64,31,220,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c6fbe5f3-8af5-45bb-b253-d7c21e1e0cb2"));
		}

		#endregion

	}

	#endregion

}

