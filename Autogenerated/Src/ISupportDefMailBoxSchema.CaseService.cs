namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISupportDefMailBoxSchema

	/// <exclude/>
	public class ISupportDefMailBoxSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISupportDefMailBoxSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISupportDefMailBoxSchema(ISupportDefMailBoxSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c365918f-f01b-41e0-998d-6395d5736989");
			Name = "ISupportDefMailBox";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77fa8847-960e-4748-ad77-e37bb90e03a0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,141,77,10,131,48,16,133,215,10,222,97,150,237,198,28,160,226,194,22,74,23,66,193,19,68,153,72,192,252,48,153,128,82,188,123,19,90,187,232,106,224,205,247,190,103,165,193,224,229,132,208,61,251,193,41,174,175,206,42,61,71,146,172,157,173,202,87,85,22,62,142,139,158,64,91,70,82,153,125,12,209,123,71,124,67,213,75,189,116,110,77,84,38,11,33,4,52,33,26,35,105,107,143,224,142,12,225,211,0,147,120,24,221,10,138,156,129,176,5,198,116,144,89,219,185,254,25,196,191,162,33,228,72,54,180,223,229,159,167,110,196,241,202,108,96,74,162,188,120,58,95,82,176,87,229,254,6,47,46,91,191,228,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c365918f-f01b-41e0-998d-6395d5736989"));
		}

		#endregion

	}

	#endregion

}

