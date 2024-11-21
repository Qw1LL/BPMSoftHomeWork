namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LowerExpressionConveterSchema

	/// <exclude/>
	public class LowerExpressionConveterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LowerExpressionConveterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LowerExpressionConveterSchema(LowerExpressionConveterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("85ba78c6-496b-4aee-a5ba-e9335cf632be");
			Name = "LowerExpressionConveter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,143,59,11,194,64,16,132,107,3,249,15,75,42,5,57,176,18,181,243,209,41,10,41,197,226,18,55,241,224,114,27,110,239,124,160,249,239,110,180,13,108,51,59,179,223,176,78,55,200,173,46,17,214,167,67,78,85,80,27,114,149,169,163,215,193,144,75,147,119,154,140,34,27,87,67,254,226,128,205,74,180,204,249,88,48,89,12,56,206,230,106,161,102,240,129,45,129,163,0,145,17,194,205,48,148,86,51,79,193,56,57,211,215,223,126,176,67,237,233,129,126,247,108,61,50,139,22,243,142,62,160,207,38,23,105,106,99,97,77,249,167,193,80,84,146,176,28,116,122,8,8,162,255,161,75,147,238,11,106,20,60,171,237,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("85ba78c6-496b-4aee-a5ba-e9335cf632be"));
		}

		#endregion

	}

	#endregion

}

