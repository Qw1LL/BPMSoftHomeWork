namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EntityOwnerEventAsyncOperationArgsSchema

	/// <exclude/>
	public class EntityOwnerEventAsyncOperationArgsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EntityOwnerEventAsyncOperationArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EntityOwnerEventAsyncOperationArgsSchema(EntityOwnerEventAsyncOperationArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6eeec1f5-f32a-4553-8347-9fd59c89add8");
			Name = "EntityOwnerEventAsyncOperationArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,83,193,110,194,48,12,61,131,196,63,88,236,178,73,83,123,103,12,137,33,14,28,54,144,246,5,33,184,85,165,214,169,226,100,140,161,253,251,156,164,48,216,152,216,165,74,236,231,231,231,231,148,84,131,220,42,141,240,180,122,126,53,133,203,102,134,138,170,244,86,185,202,208,160,191,31,244,123,158,43,42,225,117,199,14,155,135,227,253,187,192,98,54,39,87,185,10,249,74,58,155,242,142,244,178,197,68,31,224,82,112,99,177,148,27,204,106,197,60,130,8,222,45,183,132,118,254,134,228,206,107,166,182,228,88,149,231,57,140,217,55,141,178,187,73,119,159,110,54,210,199,144,170,193,132,122,80,182,244,141,112,48,56,3,173,208,67,69,114,194,119,212,222,25,155,29,120,242,19,162,214,175,235,74,131,14,106,254,33,230,32,248,79,173,61,241,80,190,199,49,87,214,8,32,216,49,130,85,236,149,242,63,7,138,129,23,89,16,152,2,48,246,232,166,210,166,246,13,5,241,191,213,31,228,179,179,97,13,81,249,44,226,35,213,30,74,116,15,192,225,243,217,233,66,218,36,105,231,58,229,37,8,137,215,226,211,127,148,46,72,172,87,117,245,129,12,132,91,49,154,157,34,29,213,143,25,17,180,197,226,113,120,221,208,97,62,185,60,89,140,180,202,170,6,72,102,121,28,38,83,134,147,196,153,141,243,152,252,3,27,155,5,250,201,130,10,3,106,109,188,59,190,15,136,105,62,163,232,140,188,46,248,54,65,186,29,221,67,130,73,34,177,134,211,29,140,96,173,24,111,15,152,147,76,248,197,122,151,119,145,162,167,193,222,160,255,249,5,29,99,62,88,181,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6eeec1f5-f32a-4553-8347-9fd59c89add8"));
		}

		#endregion

	}

	#endregion

}

