namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FileSizeConverterSchema

	/// <exclude/>
	public class FileSizeConverterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FileSizeConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FileSizeConverterSchema(FileSizeConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b9844b9b-b3bf-4414-a49f-287d942d6932");
			Name = "FileSizeConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,80,193,138,194,48,16,61,175,224,63,12,122,209,61,24,93,246,164,181,7,133,5,15,5,65,127,32,77,71,13,52,73,73,210,5,87,252,119,39,109,218,69,133,64,242,222,188,247,50,51,154,43,116,21,23,8,155,125,118,48,39,63,219,26,125,146,231,218,114,47,141,134,219,112,48,28,124,140,45,158,3,218,150,220,185,37,252,200,18,15,242,15,73,250,139,214,163,37,9,157,170,206,75,41,192,121,178,10,16,65,251,46,141,137,125,100,134,254,98,10,10,221,55,238,182,200,24,131,196,213,74,113,123,77,59,34,70,128,163,56,144,228,204,193,155,30,229,87,143,110,214,155,217,171,59,169,184,229,10,52,205,187,30,5,211,78,103,249,40,77,88,195,255,203,44,250,218,106,71,133,238,21,74,207,163,21,40,164,226,37,117,112,52,155,240,239,68,234,182,175,16,58,133,117,10,147,168,153,118,44,124,194,98,254,245,29,175,85,92,2,234,162,221,67,131,239,237,178,159,72,226,30,59,162,159,165,164,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b9844b9b-b3bf-4414-a49f-287d942d6932"));
		}

		#endregion

	}

	#endregion

}

