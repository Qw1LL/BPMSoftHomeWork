namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactConstsSchema

	/// <exclude/>
	public class ContactConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactConstsSchema(ContactConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("42db62ea-f92c-4df6-b6a2-c994e9708c0b");
			Name = "ContactConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,144,203,106,195,48,16,69,215,54,248,31,132,87,237,66,177,20,165,170,66,31,96,59,114,200,34,16,72,127,64,181,39,193,224,23,146,188,48,37,255,94,41,161,161,93,180,161,155,145,24,206,101,206,204,104,234,238,136,246,147,177,208,62,69,97,20,118,170,5,51,168,18,80,182,219,238,251,131,157,229,125,119,168,143,163,86,182,238,187,40,252,136,194,96,24,223,155,186,68,198,186,94,137,202,70,25,131,28,102,85,105,221,99,172,113,140,231,130,36,73,208,179,25,219,86,233,233,245,171,241,54,13,128,48,146,237,208,244,19,192,149,75,190,131,63,71,172,199,186,186,6,124,126,83,121,232,60,35,56,130,69,151,95,160,193,142,186,59,227,179,157,210,6,238,98,78,30,25,147,69,142,11,198,51,76,23,148,224,84,8,134,41,95,9,150,167,25,89,10,18,223,187,221,93,252,228,171,43,191,170,175,161,171,64,59,249,173,106,96,246,167,121,233,15,225,252,181,63,176,199,55,21,122,65,177,148,105,190,152,75,137,249,67,198,241,170,160,20,11,70,83,76,8,93,113,34,151,76,228,60,62,219,220,150,40,160,253,159,198,37,112,17,41,242,249,66,176,66,220,20,113,247,56,125,2,114,19,95,61,39,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("42db62ea-f92c-4df6-b6a2-c994e9708c0b"));
		}

		#endregion

	}

	#endregion

}

