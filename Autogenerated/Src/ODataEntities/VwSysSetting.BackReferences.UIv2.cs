namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwSysSetting

	/// <exclude/>
	public class VwSysSetting : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysSetting(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSetting";
		}

		public VwSysSetting(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwSysSetting";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<TelephonyIntegration> TelephonyIntegrationCollectionByLogin {
			get;
			set;
		}

		public IEnumerable<TelephonyIntegration> TelephonyIntegrationCollectionByPassword {
			get;
			set;
		}

		public IEnumerable<TelephonyIntegration> TelephonyIntegrationCollectionByTelephonyServerTimeZone {
			get;
			set;
		}

		public IEnumerable<TelephonyIntegration> TelephonyIntegrationCollectionByToken {
			get;
			set;
		}

		public IEnumerable<TelephonyIntegration> TelephonyIntegrationCollectionByUisCallEndTimeShift {
			get;
			set;
		}

		public IEnumerable<TelephonyIntegration> TelephonyIntegrationCollectionByUisCallStartTimeShift {
			get;
			set;
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Код.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Тип.
		/// </summary>
		public string ValueTypeName {
			get {
				return GetTypedColumnValue<string>("ValueTypeName");
			}
			set {
				SetColumnValue("ValueTypeName", value);
			}
		}

		/// <summary>
		/// Идентификатор справочника системной настройки.
		/// </summary>
		public Guid ReferenceSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ReferenceSchemaUId");
			}
			set {
				SetColumnValue("ReferenceSchemaUId", value);
			}
		}

		/// <summary>
		/// Персональная.
		/// </summary>
		public bool IsPersonal {
			get {
				return GetTypedColumnValue<bool>("IsPersonal");
			}
			set {
				SetColumnValue("IsPersonal", value);
			}
		}

		/// <summary>
		/// Кешируется.
		/// </summary>
		public bool IsCacheable {
			get {
				return GetTypedColumnValue<bool>("IsCacheable");
			}
			set {
				SetColumnValue("IsCacheable", value);
			}
		}

		/// <summary>
		/// Разрешить для пользователей портала.
		/// </summary>
		public bool IsSSPAvailable {
			get {
				return GetTypedColumnValue<bool>("IsSSPAvailable");
			}
			set {
				SetColumnValue("IsSSPAvailable", value);
			}
		}

		#endregion

	}

	#endregion

}

