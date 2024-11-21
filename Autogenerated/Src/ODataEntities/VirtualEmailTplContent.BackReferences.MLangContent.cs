namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VirtualEmailTplContent

	/// <exclude/>
	public class VirtualEmailTplContent : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VirtualEmailTplContent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VirtualEmailTplContent";
		}

		public VirtualEmailTplContent(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VirtualEmailTplContent";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <summary>
		/// Email subject.
		/// </summary>
		public string Subject {
			get {
				return GetTypedColumnValue<string>("Subject");
			}
			set {
				SetColumnValue("Subject", value);
			}
		}

		/// <summary>
		/// Body.
		/// </summary>
		public string Body {
			get {
				return GetTypedColumnValue<string>("Body");
			}
			set {
				SetColumnValue("Body", value);
			}
		}

		/// <exclude/>
		public Guid LanguageId {
			get {
				return GetTypedColumnValue<Guid>("LanguageId");
			}
			set {
				SetColumnValue("LanguageId", value);
				_language = null;
			}
		}

		/// <exclude/>
		public string LanguageName {
			get {
				return GetTypedColumnValue<string>("LanguageName");
			}
			set {
				SetColumnValue("LanguageName", value);
				if (_language != null) {
					_language.Name = value;
				}
			}
		}

		private SysLanguage _language;
		/// <summary>
		/// Template language.
		/// </summary>
		public SysLanguage Language {
			get {
				return _language ??
					(_language = new SysLanguage(LookupColumnEntities.GetEntity("Language")));
			}
		}

		/// <summary>
		/// Language code.
		/// </summary>
		public string LanguageCode {
			get {
				return GetTypedColumnValue<string>("LanguageCode");
			}
			set {
				SetColumnValue("LanguageCode", value);
			}
		}

		#endregion

	}

	#endregion

}

