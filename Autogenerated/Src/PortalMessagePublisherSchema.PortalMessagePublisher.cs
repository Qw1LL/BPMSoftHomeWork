namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PortalMessagePublisherSchema

	/// <exclude/>
	public class PortalMessagePublisherSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PortalMessagePublisherSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PortalMessagePublisherSchema(PortalMessagePublisherSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6244c208-b197-4059-8d43-d8de62679b3c");
			Name = "PortalMessagePublisher";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4b8eb560-035d-46d4-af40-51e85d9668c1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,80,203,106,195,48,16,60,203,224,127,88,210,75,10,33,31,224,62,14,73,154,156,82,12,166,31,176,81,54,142,64,150,131,86,58,152,146,127,239,202,10,180,110,90,16,146,102,53,59,163,157,200,198,181,208,12,28,168,91,174,123,107,73,7,211,59,94,238,200,145,55,250,169,44,226,72,89,213,251,166,63,5,225,120,146,98,89,56,236,136,47,168,233,199,147,59,153,54,122,76,10,101,241,89,22,74,214,131,167,86,48,172,45,50,87,80,247,62,160,221,19,51,182,84,199,131,53,124,38,159,4,213,37,33,13,58,17,255,225,65,5,43,100,186,111,87,226,38,251,183,155,204,16,124,212,161,247,226,57,10,103,194,205,228,111,249,249,7,147,151,86,151,83,128,56,129,11,216,152,241,130,126,120,22,117,137,101,1,249,124,5,114,193,132,97,107,200,30,121,131,1,31,147,153,170,224,32,223,157,255,214,185,35,67,10,75,169,183,177,222,232,51,117,248,46,249,194,11,204,38,63,157,73,244,74,93,111,179,146,59,230,113,71,156,171,211,226,245,11,191,185,195,71,224,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6244c208-b197-4059-8d43-d8de62679b3c"));
		}

		#endregion

	}

	#endregion

}

