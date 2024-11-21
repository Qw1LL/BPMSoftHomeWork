namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactMLangBinderSchema

	/// <exclude/>
	public class ContactMLangBinderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactMLangBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactMLangBinderSchema(ContactMLangBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("28c6993a-5103-498a-bc0d-ef34c1059002");
			Name = "ContactMLangBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5fe5418-b108-401a-ba83-ff1213a966db");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,81,77,107,195,48,12,61,167,208,255,32,186,75,7,35,185,119,165,176,148,13,10,13,43,244,176,179,147,168,153,33,182,131,173,132,149,209,255,62,57,118,70,182,94,108,172,247,33,61,89,11,133,174,19,21,66,126,42,206,230,66,233,222,232,139,108,122,43,72,26,189,92,124,47,23,73,239,164,110,102,4,139,233,155,168,200,88,137,238,249,14,255,192,146,57,74,25,205,24,163,15,22,27,182,130,125,43,156,219,0,251,19,139,139,163,208,77,46,117,141,118,100,101,89,6,91,215,43,37,236,117,23,223,145,10,170,111,73,182,204,239,69,131,80,121,31,40,71,105,58,41,179,153,180,235,203,86,86,145,119,223,14,54,240,210,117,175,3,106,58,74,71,168,209,230,194,33,11,57,43,159,191,3,23,72,159,166,230,145,79,163,97,0,163,185,25,208,90,89,35,12,70,214,240,174,217,241,76,194,210,122,178,246,125,241,139,160,10,247,35,248,69,38,73,201,157,210,25,125,130,253,26,147,100,92,81,88,237,53,245,211,110,15,126,110,31,251,64,200,95,98,236,211,148,232,63,176,91,175,34,178,10,110,183,152,6,117,29,2,141,239,80,253,91,188,253,0,79,12,183,213,6,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("28c6993a-5103-498a-bc0d-ef34c1059002"));
		}

		#endregion

	}

	#endregion

}

