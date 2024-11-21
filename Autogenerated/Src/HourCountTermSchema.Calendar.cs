namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: HourCountTermSchema

	/// <exclude/>
	public class HourCountTermSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public HourCountTermSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public HourCountTermSchema(HourCountTermSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e2216cbe-4197-4a17-8a40-fbb367f7eb39");
			Name = "HourCountTerm";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("761f835c-6644-4753-9a3e-2c2ccab7b4d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,83,193,110,219,48,12,61,187,64,255,129,72,47,46,80,216,247,45,51,176,165,91,23,160,1,10,52,251,0,197,102,19,1,178,148,137,82,1,99,232,191,143,146,34,199,77,218,110,23,195,162,222,35,31,249,40,45,122,164,189,104,17,190,61,172,30,205,147,171,22,70,63,201,173,183,194,73,163,171,133,80,168,59,97,233,242,226,207,229,69,225,73,234,45,60,14,228,176,255,124,114,102,166,82,216,6,26,85,119,168,209,202,246,12,115,47,245,239,99,240,205,154,124,205,128,43,139,91,62,192,66,9,34,248,4,63,141,183,11,227,181,91,163,237,35,162,174,107,152,147,239,123,97,135,230,112,142,8,112,12,129,205,0,59,230,80,149,161,245,4,187,247,27,37,91,104,99,242,87,169,185,212,74,106,239,112,82,172,224,214,249,59,106,90,161,219,153,46,168,122,136,121,210,237,169,158,36,72,168,214,43,225,16,58,254,172,101,143,65,88,123,152,106,208,118,46,46,69,246,194,138,30,52,251,243,101,214,137,129,102,77,246,130,83,13,84,205,235,136,120,155,16,59,159,53,161,51,2,103,66,193,36,227,156,102,209,121,171,233,152,221,177,72,134,229,120,0,30,198,101,158,209,90,217,33,220,230,94,198,246,202,229,119,237,123,180,98,163,112,190,204,185,110,197,208,68,181,55,32,217,151,168,234,26,194,34,21,197,189,217,102,54,207,116,169,217,180,103,161,168,76,240,4,13,155,82,20,73,73,234,250,135,180,228,202,235,113,47,179,146,234,107,215,197,110,203,9,243,229,3,99,238,208,241,100,118,24,219,5,175,165,163,255,117,35,187,55,107,214,204,31,189,252,208,16,134,36,56,255,188,239,193,122,212,2,109,88,191,127,216,16,102,202,125,4,214,175,64,42,199,193,159,88,144,53,222,192,212,166,60,187,60,251,6,246,252,102,121,177,179,69,135,193,111,4,33,63,232,73,157,99,190,145,17,87,61,6,249,49,19,15,51,189,34,90,234,96,203,212,142,43,70,165,135,20,207,41,250,58,248,242,23,40,119,136,174,151,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e2216cbe-4197-4a17-8a40-fbb367f7eb39"));
		}

		#endregion

	}

	#endregion

}

