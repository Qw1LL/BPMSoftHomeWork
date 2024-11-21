namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DateTimeExpressionConveterSchema

	/// <exclude/>
	public class DateTimeExpressionConveterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateTimeExpressionConveterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateTimeExpressionConveterSchema(DateTimeExpressionConveterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("35da4edf-d91a-423a-87ed-e938ea1f0686");
			Name = "DateTimeExpressionConveter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,143,49,11,194,64,12,133,103,11,253,15,161,147,130,28,56,137,186,105,29,69,161,110,226,112,173,105,123,208,222,149,75,78,20,237,127,55,213,213,66,150,188,247,242,61,98,117,139,212,233,2,97,123,58,100,174,100,181,115,182,52,85,240,154,141,179,113,244,138,163,73,32,99,43,200,158,196,216,110,100,151,185,28,115,114,13,50,78,147,165,90,169,5,188,33,117,96,29,67,32,4,174,13,65,209,104,162,57,24,43,103,250,246,213,255,118,168,84,51,158,77,139,251,71,231,145,72,36,241,239,232,25,125,50,187,74,89,23,242,198,20,63,32,140,164,37,12,235,49,115,64,9,103,248,165,143,163,254,3,112,214,231,60,245,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("35da4edf-d91a-423a-87ed-e938ea1f0686"));
		}

		#endregion

	}

	#endregion

}

