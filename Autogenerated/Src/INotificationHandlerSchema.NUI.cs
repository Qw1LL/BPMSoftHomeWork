namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationHandlerSchema

	/// <exclude/>
	public class INotificationHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationHandlerSchema(INotificationHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f9c66d6e-bd4a-4fc2-8d6b-edbb5e21ba56");
			Name = "INotificationHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,144,77,78,195,48,16,133,215,141,148,59,140,186,130,77,124,128,134,44,64,8,178,0,85,234,9,92,119,92,44,217,51,145,127,144,170,170,119,175,227,20,104,200,114,126,222,247,222,12,73,135,97,144,10,225,121,251,177,99,29,155,23,38,109,142,201,203,104,152,234,234,92,87,171,20,12,29,97,119,10,17,93,158,91,139,106,28,134,230,13,9,189,81,155,186,202,91,66,8,104,67,114,78,250,83,119,171,123,138,232,245,136,215,236,97,240,172,48,20,24,113,52,218,168,98,18,154,31,181,184,147,15,105,111,141,2,243,75,232,63,239,52,239,146,14,22,125,222,27,3,46,188,75,99,59,217,97,88,186,45,237,166,206,32,189,116,64,249,41,79,235,153,104,221,253,221,13,172,33,126,225,63,106,43,138,184,176,190,217,28,96,138,248,208,191,82,114,232,229,222,98,59,59,161,39,205,221,28,242,152,63,185,186,212,213,229,10,126,167,245,15,151,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f9c66d6e-bd4a-4fc2-8d6b-edbb5e21ba56"));
		}

		#endregion

	}

	#endregion

}

