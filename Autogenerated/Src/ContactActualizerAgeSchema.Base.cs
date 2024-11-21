namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactActualizerAgeSchema

	/// <exclude/>
	public class ContactActualizerAgeSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactActualizerAgeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactActualizerAgeSchema(ContactActualizerAgeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b6997510-8ca5-4b43-92fb-c0f6cd54daae");
			Name = "ContactActualizerAge";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("79c177f7-ba6c-471b-a777-73cb1e762283");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,205,110,194,48,12,62,131,212,119,176,224,194,164,9,237,204,4,18,148,29,217,42,33,30,32,164,110,137,22,210,42,113,166,49,196,187,207,165,165,64,105,181,195,46,85,98,127,63,182,227,26,177,71,151,11,137,176,136,86,235,44,161,113,152,153,68,165,222,10,82,153,9,250,199,160,223,243,78,153,244,6,96,241,53,232,115,124,104,49,101,16,64,168,133,115,19,96,42,9,73,115,73,94,104,245,131,243,20,207,184,220,111,181,146,32,11,212,3,200,50,10,38,176,16,14,239,98,204,99,111,254,214,54,204,116,100,189,164,204,78,32,58,107,150,128,74,191,77,121,180,113,104,57,97,80,22,253,128,191,187,62,177,241,150,141,71,205,240,17,78,255,148,126,6,101,8,194,157,55,159,107,38,148,215,149,248,94,98,106,17,63,146,72,88,161,53,106,229,246,55,208,200,102,18,93,49,238,37,106,113,232,174,175,168,173,167,18,24,213,14,48,131,151,75,162,71,59,229,198,215,212,244,90,8,191,28,231,79,53,191,189,164,71,177,14,220,180,163,167,166,77,91,119,29,21,55,81,85,241,141,240,141,65,245,84,67,52,113,185,41,193,221,218,48,49,71,75,10,121,67,249,76,60,67,140,75,72,126,185,66,246,133,214,170,24,129,55,172,88,246,55,67,138,14,239,252,119,192,116,6,131,234,253,7,103,215,110,214,38,143,5,97,201,13,51,237,247,166,86,224,133,249,139,93,242,150,172,208,224,46,148,165,93,17,47,20,90,90,45,7,112,31,60,253,2,103,26,176,58,218,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b6997510-8ca5-4b43-92fb-c0f6cd54daae"));
		}

		#endregion

	}

	#endregion

}

