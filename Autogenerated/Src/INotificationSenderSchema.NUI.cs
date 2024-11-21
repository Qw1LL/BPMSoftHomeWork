namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationSenderSchema

	/// <exclude/>
	public class INotificationSenderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationSenderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationSenderSchema(INotificationSenderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d0434505-a3a8-488e-a33b-2a071c2954f0");
			Name = "INotificationSender";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,144,65,106,195,48,16,69,215,49,248,14,34,171,118,99,29,160,174,23,45,161,120,209,18,112,47,160,200,163,100,192,26,25,141,20,8,37,119,175,164,166,16,145,229,204,252,247,255,103,72,89,224,85,105,16,111,251,207,201,153,208,189,59,50,120,140,94,5,116,212,54,63,109,179,137,140,116,20,211,133,3,216,116,95,22,208,249,200,221,7,16,120,212,47,109,147,84,82,74,209,115,180,86,249,203,112,155,247,222,157,113,6,22,12,52,103,19,114,1,13,234,98,206,194,66,56,185,153,187,127,90,222,225,107,60,44,168,5,82,0,111,114,193,241,235,142,157,146,31,248,36,203,253,30,162,203,34,75,184,14,204,65,143,73,127,155,85,121,101,5,165,127,188,110,43,104,59,124,159,160,242,73,165,140,243,246,230,217,203,130,22,167,179,195,185,4,63,141,59,138,22,188,58,44,208,87,205,199,196,14,117,173,231,244,192,205,181,109,174,191,98,7,51,154,142,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d0434505-a3a8-488e-a33b-2a071c2954f0"));
		}

		#endregion

	}

	#endregion

}

