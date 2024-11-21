namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IGeneratedWebFormProcessHandlerSchema

	/// <exclude/>
	public class IGeneratedWebFormProcessHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IGeneratedWebFormProcessHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IGeneratedWebFormProcessHandlerSchema(IGeneratedWebFormProcessHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fd2443d1-4e8b-456e-8121-999e79c2ef1c");
			Name = "IGeneratedWebFormProcessHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,143,49,11,194,48,16,133,103,11,253,15,7,221,219,93,196,65,65,237,32,20,28,156,211,230,18,3,205,37,92,82,161,136,255,221,212,90,232,230,248,142,239,189,119,143,132,197,224,69,135,112,104,174,55,167,98,121,116,164,140,30,88,68,227,40,207,94,121,182,41,24,117,18,80,83,68,86,9,222,66,125,70,194,196,160,188,99,123,114,108,27,118,29,134,112,17,36,123,228,60,75,182,170,170,96,23,6,107,5,143,251,159,78,216,211,72,12,96,150,44,80,142,193,207,110,67,26,156,130,248,64,232,24,167,116,64,138,38,142,160,216,89,232,83,248,132,120,161,177,92,10,170,85,131,31,218,222,116,171,236,191,111,110,166,125,239,239,187,5,146,156,135,78,50,221,62,82,79,110,91,28,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fd2443d1-4e8b-456e-8121-999e79c2ef1c"));
		}

		#endregion

	}

	#endregion

}

