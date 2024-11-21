namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IChildImportEntitiesGetterSchema

	/// <exclude/>
	public class IChildImportEntitiesGetterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IChildImportEntitiesGetterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IChildImportEntitiesGetterSchema(IChildImportEntitiesGetterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("62efa7fa-c711-4c24-a8e7-b07f25c59080");
			Name = "IChildImportEntitiesGetter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,144,193,110,195,32,12,64,207,141,148,127,64,61,109,23,248,128,178,28,86,117,85,14,147,42,245,11,40,115,58,75,224,68,6,14,81,213,127,31,36,75,50,237,6,246,179,159,109,50,30,194,96,44,136,247,203,231,181,239,162,60,246,212,225,61,177,137,216,147,252,64,7,173,31,122,142,117,245,168,171,93,10,72,119,113,29,67,4,159,81,231,192,22,46,200,51,16,48,218,195,202,108,253,24,228,137,34,70,132,144,211,25,24,210,205,161,21,72,17,184,43,238,246,248,141,238,107,246,44,232,25,98,78,103,186,104,119,74,41,161,67,242,222,240,216,44,129,140,4,97,75,169,128,223,42,185,194,234,63,173,7,195,198,11,202,27,191,237,167,55,100,65,216,55,179,87,108,33,169,213,244,217,74,25,98,98,10,205,52,231,38,211,106,73,20,178,61,81,242,192,230,230,64,79,91,140,77,25,241,101,238,127,89,219,255,49,189,150,123,61,235,234,249,3,85,39,2,145,136,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("62efa7fa-c711-4c24-a8e7-b07f25c59080"));
		}

		#endregion

	}

	#endregion

}

