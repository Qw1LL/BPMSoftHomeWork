namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImapClientSchema

	/// <exclude/>
	public class IImapClientSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImapClientSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImapClientSchema(IImapClientSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4eefcdc0-dfe1-496a-a1c1-f92ded0404ac");
			Name = "IImapClient";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("80eb4b00-d20b-4335-a2cc-1f02c0e63f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,145,225,106,194,48,20,133,127,43,248,14,129,253,113,32,125,0,29,251,49,117,82,88,71,65,95,32,109,111,235,133,52,41,185,183,110,50,124,247,221,38,206,21,65,104,32,247,228,227,228,228,212,234,22,168,211,37,168,183,60,219,187,154,147,76,163,153,77,127,102,211,73,79,104,27,181,63,19,67,187,186,155,147,181,51,6,74,70,103,41,217,129,5,143,165,48,66,61,121,104,68,85,169,101,240,181,56,47,85,154,182,186,91,27,4,203,2,200,215,245,133,193,82,225,31,50,38,4,223,32,117,142,116,97,64,216,33,201,205,52,3,62,186,138,150,42,15,14,225,194,73,225,156,81,7,127,222,128,1,134,119,103,42,240,115,98,63,164,173,195,244,41,175,124,94,221,216,181,7,125,15,90,248,138,66,174,249,24,217,147,195,74,101,238,4,25,16,233,6,14,238,145,247,66,93,37,41,51,144,200,230,95,172,64,26,179,122,232,42,26,140,162,108,45,245,254,26,101,251,141,196,244,40,249,135,28,190,132,158,34,253,170,118,192,113,75,243,1,9,61,129,173,98,85,195,36,235,18,255,201,72,190,252,2,99,247,101,35,243,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4eefcdc0-dfe1-496a-a1c1-f92ded0404ac"));
		}

		#endregion

	}

	#endregion

}

