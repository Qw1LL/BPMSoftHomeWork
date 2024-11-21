namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SocialMessagePublisherSchema

	/// <exclude/>
	public class SocialMessagePublisherSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SocialMessagePublisherSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SocialMessagePublisherSchema(SocialMessagePublisherSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("338fe51c-5d19-4505-9d2c-889953ea22f6");
			Name = "SocialMessagePublisher";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("203eb078-3e33-4e60-b9e9-a0b134c55d99");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,80,203,106,195,48,16,60,203,224,127,88,210,75,10,33,31,224,62,14,73,218,158,82,2,166,31,176,81,54,142,64,150,130,86,58,152,146,127,239,202,10,180,110,90,16,146,102,52,59,171,157,196,198,117,208,14,28,169,95,174,189,181,164,163,241,142,151,111,228,40,24,253,80,87,105,148,172,118,219,214,31,163,104,2,9,89,87,14,123,226,51,106,250,241,228,142,166,75,1,179,67,93,125,214,149,146,117,23,168,19,12,107,139,204,13,180,94,27,180,91,98,198,142,118,105,111,13,159,40,100,67,117,206,72,131,206,194,127,116,208,192,10,153,110,203,149,116,147,253,187,155,204,16,67,210,209,135,6,70,157,46,130,107,147,191,237,231,31,76,65,74,93,73,1,210,4,46,96,99,198,11,134,225,81,220,37,150,5,148,243,25,200,69,19,135,87,67,246,192,27,140,120,159,155,169,6,246,242,221,249,111,159,27,49,228,176,148,122,25,249,86,159,168,199,119,201,23,158,96,54,249,233,76,162,87,234,114,157,149,220,161,140,59,226,194,78,201,203,23,209,242,59,112,224,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("338fe51c-5d19-4505-9d2c-889953ea22f6"));
		}

		#endregion

	}

	#endregion

}

