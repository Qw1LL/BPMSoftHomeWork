namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TextColumnHelperSchema

	/// <exclude/>
	public class TextColumnHelperSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TextColumnHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TextColumnHelperSchema(TextColumnHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a1a85a55-168d-4a14-be59-272acc0d963d");
			Name = "TextColumnHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7e188b25-9774-4cd9-86fe-ed132c1bc48f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,146,81,107,194,48,16,199,159,43,248,29,110,14,196,129,180,123,222,180,15,115,140,9,19,4,197,247,216,94,53,208,166,37,185,12,221,240,187,239,146,212,205,78,95,2,119,249,255,238,254,119,137,18,21,154,70,100,8,47,203,197,170,46,40,158,213,170,144,59,171,5,201,90,197,111,178,196,121,213,212,154,250,189,239,126,47,178,70,170,221,133,86,227,115,191,199,249,123,141,59,214,195,172,20,198,60,193,26,15,52,171,75,91,169,119,44,27,212,94,147,36,9,76,140,173,42,161,143,105,27,115,55,18,82,25,32,38,32,243,136,1,75,178,148,116,132,10,105,95,231,38,62,195,201,5,221,216,109,41,51,48,196,70,51,200,92,223,27,109,35,54,205,231,175,191,69,168,248,4,75,143,135,203,255,198,124,98,169,177,17,26,59,206,224,83,148,22,99,88,237,121,33,200,70,125,12,178,0,73,144,215,44,86,53,65,193,1,237,177,101,156,249,107,247,33,195,13,68,5,138,223,96,58,200,5,137,141,43,183,62,54,56,72,95,57,108,203,19,39,226,73,226,197,183,89,175,27,164,179,75,147,87,128,70,178,90,153,180,29,44,191,49,216,36,57,139,28,213,221,176,33,237,158,190,165,255,54,189,113,228,200,197,206,178,143,220,4,208,153,103,124,198,125,159,7,112,95,41,138,120,111,163,187,142,46,158,155,133,56,172,228,23,194,112,216,154,250,64,181,163,61,164,221,138,177,19,157,11,69,97,81,211,150,88,217,109,104,55,122,28,223,162,248,203,50,115,242,103,24,184,5,215,90,86,163,112,205,183,254,223,160,202,195,215,241,113,200,118,147,167,31,70,171,122,103,68,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a1a85a55-168d-4a14-be59-272acc0d963d"));
		}

		#endregion

	}

	#endregion

}

