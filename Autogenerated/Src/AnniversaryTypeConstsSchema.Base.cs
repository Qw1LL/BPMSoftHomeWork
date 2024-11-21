namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AnniversaryTypeConstsSchema

	/// <exclude/>
	public class AnniversaryTypeConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AnniversaryTypeConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AnniversaryTypeConstsSchema(AnniversaryTypeConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a51c8b1b-32d7-45c3-a82d-781a607be12f");
			Name = "AnniversaryTypeConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("45b7d114-643d-4217-a8b2-b9950d3eddb7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,143,77,75,3,49,16,134,207,27,200,127,24,122,210,67,218,253,168,91,23,241,96,43,138,7,65,168,127,32,205,36,109,96,55,89,242,161,4,241,191,155,238,161,40,82,20,230,244,206,51,195,243,70,175,205,30,182,201,7,57,220,80,66,137,225,131,244,35,23,18,214,47,207,91,171,194,124,99,141,210,251,232,120,208,214,80,242,65,73,49,198,93,175,5,248,144,51,1,162,231,222,195,157,49,250,77,58,207,93,122,77,163,204,87,62,248,204,30,249,98,177,248,190,135,144,1,96,176,214,46,28,144,167,35,241,243,165,147,28,173,233,19,60,70,141,39,238,9,225,22,140,124,159,210,139,89,181,106,240,170,197,154,41,20,156,161,170,42,214,237,106,206,202,178,194,182,148,93,115,45,218,217,229,212,234,156,193,198,14,35,55,9,148,141,6,167,130,240,15,159,135,19,125,255,75,170,238,150,203,182,145,171,63,165,138,79,74,242,124,1,241,129,251,208,129,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a51c8b1b-32d7-45c3-a82d-781a607be12f"));
		}

		#endregion

	}

	#endregion

}

