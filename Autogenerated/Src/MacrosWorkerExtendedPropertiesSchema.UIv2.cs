namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MacrosWorkerExtendedPropertiesSchema

	/// <exclude/>
	public class MacrosWorkerExtendedPropertiesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MacrosWorkerExtendedPropertiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MacrosWorkerExtendedPropertiesSchema(MacrosWorkerExtendedPropertiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("46e56cc0-b0c4-4b85-901f-98aac1edceeb");
			Name = "MacrosWorkerExtendedProperties";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,145,77,107,195,48,12,134,207,46,244,63,136,238,158,220,187,173,135,150,50,118,40,4,202,216,217,181,149,84,204,177,131,101,179,133,209,255,62,231,163,105,246,1,187,24,235,149,95,233,145,108,101,141,220,72,133,176,45,14,71,87,134,108,231,108,73,85,244,50,144,179,203,197,231,114,33,34,147,173,224,216,114,192,250,126,138,111,6,143,127,169,179,50,217,75,32,195,233,81,122,118,231,177,74,18,236,140,100,94,195,65,42,239,248,213,249,55,244,251,143,128,86,163,46,188,107,208,7,66,238,29,121,158,195,3,199,186,150,190,221,140,113,239,6,178,74,54,28,141,12,8,82,107,234,122,73,3,205,228,135,247,51,169,51,40,105,225,132,16,25,117,242,164,98,136,160,60,150,143,171,173,100,220,219,64,161,157,131,172,242,77,118,109,156,207,58,55,241,100,72,129,234,155,255,71,46,210,234,210,57,13,124,203,173,161,232,11,13,249,159,227,245,194,176,108,80,209,132,232,17,72,99,130,44,9,125,199,245,27,236,74,246,20,73,119,222,221,224,123,214,208,253,159,16,21,134,238,139,132,224,241,114,25,217,18,245,128,215,199,131,250,93,188,124,1,233,236,211,16,35,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("46e56cc0-b0c4-4b85-901f-98aac1edceeb"));
		}

		#endregion

	}

	#endregion

}

