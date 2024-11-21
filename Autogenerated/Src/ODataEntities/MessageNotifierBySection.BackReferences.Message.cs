namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MessageNotifierBySection

	/// <exclude/>
	public class MessageNotifierBySection : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MessageNotifierBySection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MessageNotifierBySection";
		}

		public MessageNotifierBySection(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MessageNotifierBySection";
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

		/// <exclude/>
		public Guid SectionId {
			get {
				return GetTypedColumnValue<Guid>("SectionId");
			}
			set {
				SetColumnValue("SectionId", value);
				_section = null;
			}
		}

		/// <exclude/>
		public string SectionCaption {
			get {
				return GetTypedColumnValue<string>("SectionCaption");
			}
			set {
				SetColumnValue("SectionCaption", value);
				if (_section != null) {
					_section.Caption = value;
				}
			}
		}

		private SysModule _section;
		/// <summary>
		/// Section.
		/// </summary>
		public SysModule Section {
			get {
				return _section ??
					(_section = new SysModule(LookupColumnEntities.GetEntity("Section")));
			}
		}

		/// <exclude/>
		public Guid MessageNotifierId {
			get {
				return GetTypedColumnValue<Guid>("MessageNotifierId");
			}
			set {
				SetColumnValue("MessageNotifierId", value);
				_messageNotifier = null;
			}
		}

		/// <exclude/>
		public string MessageNotifierName {
			get {
				return GetTypedColumnValue<string>("MessageNotifierName");
			}
			set {
				SetColumnValue("MessageNotifierName", value);
				if (_messageNotifier != null) {
					_messageNotifier.Name = value;
				}
			}
		}

		private MessageNotifier _messageNotifier;
		/// <summary>
		/// Message notifier.
		/// </summary>
		public MessageNotifier MessageNotifier {
			get {
				return _messageNotifier ??
					(_messageNotifier = new MessageNotifier(LookupColumnEntities.GetEntity("MessageNotifier")));
			}
		}

		#endregion

	}

	#endregion

}

