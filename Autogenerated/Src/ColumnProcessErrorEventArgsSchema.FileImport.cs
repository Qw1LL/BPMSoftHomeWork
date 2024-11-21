namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ColumnProcessErrorEventArgsSchema

	/// <exclude/>
	public class ColumnProcessErrorEventArgsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ColumnProcessErrorEventArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ColumnProcessErrorEventArgsSchema(ColumnProcessErrorEventArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a1ce7950-dd79-4139-9857-1c8e2032f3d9");
			Name = "ColumnProcessErrorEventArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,79,203,10,194,64,12,60,183,208,127,88,240,222,15,208,147,150,10,61,20,138,253,130,181,102,151,133,221,108,73,182,130,136,255,110,250,64,244,226,37,36,147,201,76,6,117,0,30,245,0,234,212,181,125,52,169,172,34,26,103,39,210,201,69,44,207,206,67,19,198,72,169,200,159,69,158,77,236,208,170,254,193,9,194,161,200,5,217,17,88,97,170,202,107,230,189,170,162,159,2,118,20,7,96,174,137,34,213,119,192,116,36,203,11,125,156,174,222,13,106,152,217,255,200,106,175,26,52,177,149,133,182,240,165,145,201,27,82,63,190,114,61,2,37,7,98,222,45,226,235,126,51,226,68,243,199,21,120,127,1,3,4,40,89,231,36,89,102,33,73,4,105,120,107,94,155,50,224,109,21,95,230,21,253,5,5,123,3,206,133,80,44,58,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a1ce7950-dd79-4139-9857-1c8e2032f3d9"));
		}

		#endregion

	}

	#endregion

}

