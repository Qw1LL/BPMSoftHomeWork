namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DeleteRelationshipEntityAsyncOperationSchema

	/// <exclude/>
	public class DeleteRelationshipEntityAsyncOperationSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DeleteRelationshipEntityAsyncOperationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DeleteRelationshipEntityAsyncOperationSchema(DeleteRelationshipEntityAsyncOperationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2810347f-8d41-bc89-5b74-bf02880df2b3");
			Name = "DeleteRelationshipEntityAsyncOperation";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ac9dec01-f305-4a8c-bd6f-7a943e292d3e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,203,106,195,48,16,60,43,144,127,16,233,197,129,160,15,72,31,144,135,91,124,8,13,41,253,0,85,222,40,2,91,50,43,41,173,41,253,247,202,82,8,118,72,160,189,8,105,119,103,103,118,86,154,215,96,27,46,128,46,183,155,55,179,119,108,101,244,94,73,143,220,41,163,217,14,170,120,177,7,213,172,193,42,169,1,199,163,239,241,136,120,171,180,236,161,16,238,175,70,89,174,157,114,10,44,91,216,86,139,215,6,82,107,251,207,114,86,104,7,184,15,82,111,33,159,185,112,6,85,204,135,138,59,4,25,128,116,85,113,107,231,116,13,21,56,232,207,19,153,218,33,77,68,54,254,163,82,130,138,14,248,71,28,157,211,34,197,243,35,104,119,217,148,4,199,194,121,214,180,1,119,48,101,80,181,141,84,41,121,162,61,26,85,210,252,11,132,119,144,189,91,192,176,17,13,34,178,248,193,115,70,111,82,46,80,90,202,81,250,58,164,236,148,118,27,35,228,200,145,98,127,163,138,75,228,245,134,107,46,1,233,99,242,42,249,216,178,23,112,15,197,224,3,12,202,159,178,216,147,104,248,164,65,147,117,232,59,92,96,142,164,217,100,40,118,50,187,80,63,157,118,123,36,228,182,32,150,188,79,67,46,219,29,8,131,101,81,102,231,185,210,103,105,139,50,181,250,57,153,12,186,76,62,199,119,138,246,131,33,242,11,124,234,221,5,248,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2810347f-8d41-bc89-5b74-bf02880df2b3"));
		}

		#endregion

	}

	#endregion

}

