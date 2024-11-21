namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AddressTypeConstsSchema

	/// <exclude/>
	public class AddressTypeConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AddressTypeConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AddressTypeConstsSchema(AddressTypeConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e7b21208-c42d-4094-802d-89e094c04cb6");
			Name = "AddressTypeConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("45b7d114-643d-4217-a8b2-b9950d3eddb7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,146,79,75,195,48,24,135,207,45,244,59,132,157,244,16,151,172,105,146,34,30,156,7,21,20,133,9,158,243,231,205,86,236,218,210,180,200,16,191,187,105,101,7,203,176,135,65,46,121,127,79,242,240,35,233,125,81,109,209,230,224,59,216,95,39,113,18,87,106,15,190,81,6,208,250,245,121,83,187,238,234,174,174,92,177,237,91,213,21,117,149,196,95,73,28,53,189,46,11,131,124,23,102,6,153,82,121,143,110,173,109,193,251,183,67,3,225,132,239,124,224,6,54,90,46,143,25,234,66,136,48,122,175,219,143,33,249,123,77,11,202,214,85,121,64,247,125,97,71,230,209,162,27,84,193,231,56,185,88,8,73,180,227,210,96,166,57,96,235,40,197,58,151,18,19,66,45,39,144,167,210,240,197,229,216,226,148,117,87,239,97,206,250,16,152,137,149,57,169,87,150,11,44,168,37,152,101,78,99,153,11,192,198,50,149,18,169,114,97,200,63,214,39,216,170,114,78,59,66,211,182,226,172,182,155,93,209,52,225,109,231,212,71,110,106,231,103,217,215,125,248,87,97,63,103,63,114,19,187,211,66,165,142,43,236,82,174,49,101,148,96,238,36,197,212,112,199,51,200,72,202,210,209,30,69,167,253,47,221,14,218,57,249,8,77,204,6,104,38,134,182,142,173,50,204,228,208,91,17,192,144,74,202,65,130,1,155,253,154,191,147,56,172,31,142,146,89,32,64,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e7b21208-c42d-4094-802d-89e094c04cb6"));
		}

		#endregion

	}

	#endregion

}

