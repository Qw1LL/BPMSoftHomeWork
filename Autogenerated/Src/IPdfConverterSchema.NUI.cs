namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IPdfConverterSchema

	/// <exclude/>
	public class IPdfConverterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPdfConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPdfConverterSchema(IPdfConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("76370a5e-e3c8-4be4-b8c3-cb6e28b3bda1");
			Name = "IPdfConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,143,205,10,194,48,16,132,207,22,250,14,139,39,189,52,15,96,237,65,79,30,4,193,163,120,216,182,137,20,204,15,155,173,34,226,187,155,212,212,31,132,92,118,119,102,190,137,65,45,189,195,70,194,106,183,221,91,197,197,218,26,213,157,122,66,238,172,201,179,123,158,77,132,16,80,250,94,107,164,91,149,230,141,97,73,42,26,149,37,104,172,185,72,98,208,30,174,150,90,32,233,108,24,217,130,107,85,49,70,136,175,12,215,215,231,174,129,238,29,179,217,181,42,176,99,140,36,8,216,32,250,35,15,139,164,122,195,90,100,76,168,88,70,35,71,226,63,242,181,113,72,168,193,132,127,47,167,209,57,173,182,41,167,190,177,244,67,90,81,138,65,246,113,145,228,158,140,175,66,201,95,221,120,136,202,120,56,28,199,126,179,52,70,225,124,17,238,143,60,11,239,9,138,122,68,88,114,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("76370a5e-e3c8-4be4-b8c3-cb6e28b3bda1"));
		}

		#endregion

	}

	#endregion

}

