namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationFactorySchema

	/// <exclude/>
	public class INotificationFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationFactorySchema(INotificationFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("105f1ef7-143f-4c69-82ab-4aee819c63e5");
			Name = "INotificationFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,144,207,10,194,48,12,198,207,14,246,14,101,39,189,172,15,224,220,193,129,176,131,34,248,4,177,182,163,176,165,35,237,4,17,223,221,118,238,159,136,144,67,154,228,151,239,75,17,26,105,91,16,146,237,207,199,139,81,46,45,12,42,93,117,4,78,27,140,163,103,28,173,124,112,206,89,102,187,166,1,122,228,195,187,68,39,73,5,86,25,98,130,164,71,176,98,104,156,86,90,244,60,107,201,220,245,77,82,58,238,224,139,37,109,119,173,181,96,122,218,83,158,22,236,1,132,51,244,240,115,193,195,143,131,190,80,4,81,121,251,175,249,43,250,169,180,64,208,48,244,215,239,18,81,131,181,39,159,38,121,17,210,190,156,102,188,159,153,17,146,174,35,180,249,210,227,172,149,241,177,31,128,175,67,6,151,37,90,7,40,228,218,58,10,255,52,201,110,182,30,121,197,145,143,55,113,217,217,111,143,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("105f1ef7-143f-4c69-82ab-4aee819c63e5"));
		}

		#endregion

	}

	#endregion

}

