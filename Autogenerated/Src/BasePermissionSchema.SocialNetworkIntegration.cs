namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BasePermissionSchema

	/// <exclude/>
	public class BasePermissionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BasePermissionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BasePermissionSchema(BasePermissionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("61e6f54e-7847-49e3-aff5-86a7ed440807");
			Name = "BasePermission";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a1c45040-f900-4d72-b99e-b97e9cbc42dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,207,78,195,48,12,198,207,173,212,119,176,196,21,85,112,221,196,101,127,180,11,160,138,62,65,200,188,202,82,226,150,56,57,192,180,119,199,105,153,128,174,151,68,182,127,254,62,219,108,60,202,96,44,194,166,121,105,251,83,172,183,61,159,168,75,193,68,234,185,110,123,75,198,85,229,185,42,171,178,72,66,220,65,251,41,17,189,130,206,161,205,148,212,7,100,12,100,215,115,230,153,248,227,38,249,150,56,146,199,186,213,22,227,232,107,116,82,74,185,187,128,157,6,176,231,228,87,208,96,240,36,162,137,54,154,152,100,68,134,244,238,200,2,42,177,0,20,58,104,81,236,208,58,98,60,194,19,60,220,231,196,33,24,142,99,252,168,225,101,242,66,62,78,118,255,172,183,206,136,172,96,99,4,127,229,255,58,219,12,220,212,179,113,118,186,202,52,161,31,48,68,66,213,106,198,198,169,46,49,228,83,188,234,221,225,12,29,198,53,72,126,166,153,174,229,29,138,13,52,228,195,44,81,243,189,225,231,91,64,103,91,46,173,126,249,6,15,119,233,54,5,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("61e6f54e-7847-49e3-aff5-86a7ed440807"));
		}

		#endregion

	}

	#endregion

}

