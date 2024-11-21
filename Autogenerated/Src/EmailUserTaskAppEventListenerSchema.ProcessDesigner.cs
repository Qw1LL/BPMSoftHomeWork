namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailUserTaskAppEventListenerSchema

	/// <exclude/>
	public class EmailUserTaskAppEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailUserTaskAppEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailUserTaskAppEventListenerSchema(EmailUserTaskAppEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b705c5b2-4b1a-4681-ad77-4eae6a95afd7");
			Name = "EmailUserTaskAppEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("da7de29a-d2b3-4248-bf8e-b7a592dc81f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,144,193,138,194,64,12,134,207,45,244,29,2,94,220,139,15,224,158,92,233,97,65,177,208,21,207,227,52,118,7,219,76,153,164,34,136,239,110,118,186,202,130,40,139,167,33,201,255,255,95,38,100,90,228,206,88,132,143,98,89,250,157,76,230,62,224,164,8,222,34,179,22,180,115,117,31,140,56,79,89,122,202,210,44,77,122,118,84,223,244,27,220,170,172,109,61,189,199,233,40,96,173,98,152,55,134,121,10,121,107,92,179,102,12,95,134,247,179,174,203,15,72,178,112,44,72,24,162,161,235,183,141,179,96,127,244,207,229,48,133,207,251,136,68,183,74,110,216,37,202,183,175,20,92,196,216,72,184,34,14,222,85,176,34,141,40,197,4,25,95,179,244,151,130,71,1,59,188,111,16,19,207,15,188,57,85,175,56,75,189,167,46,248,50,249,215,255,111,250,8,169,26,110,162,213,208,251,219,202,210,243,5,67,240,81,198,252,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b705c5b2-4b1a-4681-ad77-4eae6a95afd7"));
		}

		#endregion

	}

	#endregion

}

