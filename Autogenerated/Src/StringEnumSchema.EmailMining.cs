namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: StringEnumSchema

	/// <exclude/>
	public class StringEnumSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public StringEnumSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public StringEnumSchema(StringEnumSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3d732c7c-0f8d-47a1-85af-96c11b6df501");
			Name = "StringEnum";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b6327e89-1dee-4b6f-a695-226c016beae1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,147,75,107,219,64,16,199,207,50,248,59,12,238,197,57,196,186,183,182,161,9,41,244,96,48,77,238,101,43,141,236,5,237,131,217,145,139,91,250,221,59,222,213,51,137,125,202,73,104,158,255,249,205,172,85,6,131,87,5,194,195,126,247,236,42,94,61,58,91,233,67,67,138,181,179,171,39,163,116,189,211,86,219,195,124,246,119,62,155,207,178,79,132,7,113,193,99,173,66,248,12,207,76,226,124,178,141,137,222,60,207,97,29,26,99,20,157,183,237,255,131,10,8,197,37,28,42,71,16,98,6,240,217,227,125,80,21,222,163,36,131,87,204,72,54,197,97,88,117,181,242,81,49,223,252,170,117,209,150,26,55,206,146,180,94,219,55,141,117,41,226,246,164,79,138,49,57,95,75,139,134,151,35,194,73,213,13,94,26,190,237,152,249,84,1,8,85,233,108,125,238,212,255,140,73,95,218,182,104,203,212,121,42,67,88,74,120,83,176,163,40,198,49,22,140,229,13,57,223,173,102,173,106,253,7,3,40,176,248,27,180,148,80,86,22,228,42,96,17,187,14,40,48,9,171,205,98,32,176,200,183,137,202,149,41,162,197,43,82,6,172,108,124,179,136,234,23,219,97,250,117,30,221,237,204,173,208,17,227,101,59,119,140,190,3,225,157,101,89,130,0,27,232,96,100,217,191,219,68,118,200,71,23,55,19,87,121,131,196,30,73,142,197,8,6,11,218,120,9,214,12,133,179,39,164,112,169,84,145,51,215,97,176,155,248,206,129,209,172,82,136,184,63,132,82,140,38,228,134,108,152,156,19,97,104,106,238,246,53,72,30,117,29,167,181,71,45,91,102,249,244,163,58,143,242,6,251,231,178,28,230,155,238,32,149,106,245,189,184,20,182,188,27,47,227,93,190,63,146,4,185,178,171,160,224,2,242,168,88,38,242,50,20,90,14,242,175,67,127,147,183,56,190,38,243,245,99,250,188,67,206,9,95,210,37,118,79,115,128,48,69,212,63,217,107,87,154,172,83,163,216,254,3,42,164,16,17,36,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3d732c7c-0f8d-47a1-85af-96c11b6df501"));
		}

		#endregion

	}

	#endregion

}

