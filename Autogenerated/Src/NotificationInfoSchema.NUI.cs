namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: NotificationInfoSchema

	/// <exclude/>
	public class NotificationInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NotificationInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NotificationInfoSchema(NotificationInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("026063fa-ed79-499f-833f-fe2eb2fb3566");
			Name = "NotificationInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,205,106,195,48,12,62,167,208,119,208,19,52,247,109,12,214,110,148,192,90,198,210,61,128,103,43,169,32,182,131,45,31,194,216,187,79,201,82,8,219,161,46,216,70,146,191,63,176,157,178,24,123,165,17,182,111,135,218,55,188,217,121,215,80,155,130,98,242,110,189,250,90,175,138,20,201,181,80,15,145,209,222,75,47,171,44,75,120,136,201,90,21,134,199,185,223,117,42,70,104,124,0,114,114,218,73,1,124,3,124,70,112,158,169,33,61,205,54,23,129,114,161,208,167,207,142,52,232,73,228,184,64,87,34,118,7,213,223,145,80,198,108,23,94,228,48,134,60,17,119,8,211,69,209,34,143,105,139,34,206,197,247,127,252,214,155,33,7,190,79,100,160,178,170,197,202,100,227,95,28,19,15,121,132,57,207,47,165,214,103,180,234,40,111,147,237,117,192,24,175,165,91,112,158,21,227,137,68,255,29,45,57,51,149,89,196,57,231,171,87,6,195,77,9,229,255,60,25,49,251,112,196,55,121,237,131,79,253,53,43,217,178,126,0,104,153,45,133,207,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("026063fa-ed79-499f-833f-fe2eb2fb3566"));
		}

		#endregion

	}

	#endregion

}

