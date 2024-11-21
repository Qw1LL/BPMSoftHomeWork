namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ServiceSchemaClientSchema

	/// <exclude/>
	public class ServiceSchemaClientSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ServiceSchemaClientSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ServiceSchemaClientSchema(ServiceSchemaClientSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3c738511-5733-4fc5-9114-2b98f15b5f10");
			Name = "ServiceSchemaClient";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("73951534-6fa4-4e40-b925-a1e2e4e079e3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,193,110,194,48,12,134,207,69,226,29,34,118,105,37,212,7,96,99,7,96,155,56,48,33,170,157,166,29,66,112,75,166,54,101,73,138,86,77,188,251,156,166,133,6,202,208,78,85,226,223,191,237,47,174,160,25,168,29,101,64,38,203,69,148,199,58,156,230,34,230,73,33,169,230,185,8,35,144,123,206,32,98,91,200,104,191,247,211,239,121,133,226,34,33,81,169,52,100,168,78,83,96,70,170,194,23,16,32,57,187,63,106,78,150,18,186,111,195,103,202,116,46,57,168,203,120,93,218,68,48,118,39,33,193,42,100,46,52,200,24,27,30,145,185,211,220,52,229,32,116,165,221,21,235,148,51,194,27,233,21,165,103,166,241,154,152,189,93,33,13,156,5,200,211,55,176,66,131,111,36,222,155,2,137,92,132,157,148,20,206,113,72,42,141,210,210,116,175,172,219,43,114,117,3,25,232,109,190,105,221,207,120,149,78,101,249,96,37,67,146,175,63,209,243,145,236,168,68,29,118,175,2,195,229,96,9,128,216,88,8,120,104,17,153,166,84,169,17,185,6,227,125,6,49,45,82,61,225,98,131,69,124,93,238,32,143,253,46,36,65,240,113,162,199,140,109,151,43,25,253,201,179,78,191,129,245,6,209,46,152,151,28,255,129,145,84,189,121,123,42,73,70,5,77,64,146,113,117,227,249,231,251,230,238,252,194,170,3,183,67,220,117,237,196,253,65,87,214,160,122,62,91,86,181,227,115,161,52,21,184,153,227,166,29,227,216,220,78,74,51,158,223,154,254,210,167,126,139,113,183,111,56,149,64,53,56,111,224,187,35,92,90,174,224,171,0,213,242,180,121,181,87,29,245,79,252,107,7,55,59,172,191,203,35,123,244,59,61,132,77,145,160,11,41,206,202,52,171,225,250,217,34,248,7,116,252,5,253,222,225,23,139,244,73,53,192,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3c738511-5733-4fc5-9114-2b98f15b5f10"));
		}

		#endregion

	}

	#endregion

}

