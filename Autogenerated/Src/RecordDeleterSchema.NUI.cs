namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: RecordDeleterSchema

	/// <exclude/>
	public class RecordDeleterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RecordDeleterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RecordDeleterSchema(RecordDeleterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a61c9bf9-deb2-46d9-9e0b-bc4b5a27b8cc");
			Name = "RecordDeleter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("edbaf284-b37c-4101-84cb-76a44645334f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,144,221,110,194,48,12,133,175,131,196,59,88,236,166,72,168,15,192,126,46,248,217,52,105,108,8,52,237,58,164,166,205,84,146,202,73,17,104,226,221,231,38,29,208,105,187,169,82,31,251,243,241,49,114,135,174,146,10,97,178,92,172,237,214,167,83,107,182,58,175,73,122,109,13,124,245,123,162,118,218,228,176,62,58,143,59,150,203,18,85,163,185,244,9,13,146,86,183,231,158,11,131,240,239,106,58,155,176,192,210,13,97,222,44,152,150,210,185,49,172,80,89,202,102,88,162,71,10,13,85,189,41,181,2,213,232,93,25,198,48,145,14,99,109,126,64,85,123,203,51,130,189,242,247,66,102,139,158,106,197,34,47,88,6,92,236,104,209,29,104,242,238,144,120,196,196,227,160,238,252,142,224,121,166,195,75,210,241,142,177,124,215,8,236,230,147,229,7,168,36,113,140,12,113,195,6,47,196,24,54,108,48,249,205,184,234,11,193,10,17,45,172,116,94,248,183,10,219,204,239,97,173,10,220,201,43,241,5,247,88,186,116,42,77,180,219,132,203,211,141,52,63,40,172,154,185,5,58,39,115,228,241,193,220,120,237,143,145,146,158,27,210,87,27,38,30,45,165,17,51,8,156,83,155,27,154,44,70,215,205,113,129,190,176,217,85,132,66,132,16,201,122,62,12,51,176,123,36,210,25,194,222,234,12,34,249,124,77,242,115,106,244,212,46,254,208,190,224,99,20,150,75,178,138,141,39,195,255,172,132,109,177,222,41,247,123,167,111,3,241,142,71,189,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a61c9bf9-deb2-46d9-9e0b-bc4b5a27b8cc"));
		}

		#endregion

	}

	#endregion

}

