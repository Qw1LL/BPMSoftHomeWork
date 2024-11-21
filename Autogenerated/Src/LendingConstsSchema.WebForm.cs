namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LendingConstsSchema

	/// <exclude/>
	public class LendingConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LendingConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LendingConstsSchema(LendingConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5d6b4cef-d71c-4217-89fd-d792efa796f2");
			Name = "LendingConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("aa93560d-2a86-466f-a9e4-295d1f97bfe2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,146,219,106,131,64,16,134,175,19,200,59,12,241,166,189,216,104,236,122,234,9,116,213,82,104,75,193,39,216,234,70,4,93,131,187,182,72,233,187,119,61,36,152,230,162,180,123,53,135,127,254,249,88,134,211,138,137,61,77,25,4,175,207,73,189,147,27,82,243,93,145,183,13,149,69,205,225,115,181,92,180,162,224,57,36,157,144,172,186,89,45,85,69,107,88,222,119,73,73,133,184,134,39,198,51,37,81,147,66,138,65,160,235,58,220,138,182,170,104,211,221,79,185,54,189,99,48,143,225,180,126,38,212,54,7,87,125,102,187,111,223,202,34,5,33,21,108,10,105,79,115,10,211,243,43,221,25,207,9,208,140,2,29,194,227,208,124,221,143,125,13,163,89,205,203,14,30,218,34,3,63,149,197,59,155,182,39,74,193,30,51,184,3,206,62,134,254,197,58,14,34,211,179,183,24,17,195,36,8,99,59,66,62,113,9,138,156,216,54,9,118,61,47,34,235,203,241,131,255,4,252,127,230,151,154,254,70,109,96,63,52,173,173,139,176,225,70,8,91,177,131,92,207,118,208,149,29,155,33,241,130,48,246,173,129,122,241,53,158,134,178,26,175,163,79,85,237,27,209,202,65,144,98,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5d6b4cef-d71c-4217-89fd-d792efa796f2"));
		}

		#endregion

	}

	#endregion

}

