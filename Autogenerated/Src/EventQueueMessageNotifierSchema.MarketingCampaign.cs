namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EventQueueMessageNotifierSchema

	/// <exclude/>
	public class EventQueueMessageNotifierSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EventQueueMessageNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EventQueueMessageNotifierSchema(EventQueueMessageNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0443272f-7961-4d10-902e-c867ff5bc1e2");
			Name = "EventQueueMessageNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,84,93,111,218,48,20,125,166,82,255,131,149,189,36,18,10,239,109,225,161,159,67,90,43,214,116,218,179,113,110,192,107,98,103,254,96,101,85,255,251,174,237,24,72,129,170,123,0,197,215,247,227,156,227,99,11,218,128,110,41,3,114,57,187,47,100,101,242,43,41,42,190,176,138,26,46,197,233,201,235,233,201,192,106,46,22,164,88,107,3,205,249,102,189,45,80,112,56,154,95,95,226,6,110,125,81,176,192,110,228,170,166,90,159,145,155,21,8,243,221,130,133,123,208,154,46,224,65,26,94,113,80,62,121,52,26,145,11,109,155,134,170,245,164,91,251,10,210,132,108,210,42,201,240,211,141,19,93,101,30,11,71,59,149,173,157,215,156,17,230,166,30,31,74,206,200,37,213,112,24,207,0,249,227,255,150,129,20,218,40,203,140,84,72,100,230,7,132,140,247,176,125,96,39,157,84,248,187,208,0,132,41,168,198,201,81,60,201,104,18,32,59,78,251,164,66,164,165,138,54,68,224,233,141,19,171,65,225,32,1,204,29,89,50,185,24,249,93,159,220,73,112,116,88,250,163,87,76,250,189,50,212,102,142,218,164,239,195,206,21,131,183,78,26,16,101,80,167,47,213,76,201,22,148,225,224,132,82,210,96,45,148,31,104,245,128,100,136,172,136,89,162,68,86,41,119,226,187,199,123,64,138,54,182,37,114,5,74,241,18,8,202,237,124,17,249,249,166,175,100,1,134,140,39,228,14,204,211,186,133,52,203,93,252,156,188,125,18,142,130,134,139,210,245,69,80,220,172,137,102,75,104,232,127,163,122,140,125,10,95,223,7,231,14,83,86,169,63,170,108,131,237,152,186,247,96,150,178,244,210,242,21,53,16,118,219,176,136,243,144,175,111,231,6,165,119,150,151,4,220,114,90,118,39,56,88,81,69,52,212,136,150,140,137,128,63,164,240,139,119,174,200,124,238,0,239,116,109,27,145,38,174,93,18,131,183,74,54,105,15,123,220,249,185,4,5,105,50,45,147,44,159,234,155,223,150,214,105,104,145,207,156,65,193,160,255,34,160,140,80,221,77,119,143,201,96,16,96,229,69,11,140,87,235,7,249,77,178,231,175,92,24,157,102,33,65,129,177,74,116,240,243,155,23,96,214,64,193,104,77,213,69,224,63,233,82,63,47,229,190,75,185,64,22,220,148,146,145,209,177,211,245,202,162,214,133,157,255,194,173,105,153,186,7,229,137,234,231,221,43,23,159,175,168,125,135,63,141,175,26,242,223,187,166,89,238,67,211,114,151,199,167,113,109,93,16,174,3,243,111,250,53,104,166,120,235,62,63,196,57,140,245,238,26,251,202,71,208,182,54,61,239,68,198,104,159,158,0,145,235,249,38,213,31,180,119,252,184,239,203,77,143,108,155,28,238,125,192,59,163,6,141,34,176,172,239,202,28,187,160,41,104,205,255,210,121,13,133,7,219,115,226,161,7,47,27,6,119,38,142,250,174,44,79,240,98,146,14,66,180,150,111,153,223,74,213,80,147,30,192,52,220,178,26,238,201,244,129,245,66,180,31,196,216,63,15,248,153,204,141,7,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateBaseNotificationTextLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateBaseNotificationTextLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("533eb283-d1e0-4283-97c3-990f51f39aaf"),
				Name = "BaseNotificationText",
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e"),
				CreatedInSchemaUId = new Guid("0443272f-7961-4d10-902e-c867ff5bc1e2"),
				ModifiedInSchemaUId = new Guid("0443272f-7961-4d10-902e-c867ff5bc1e2")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0443272f-7961-4d10-902e-c867ff5bc1e2"));
		}

		#endregion

	}

	#endregion

}

