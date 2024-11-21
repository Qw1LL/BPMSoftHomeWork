namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ContactCommunication

	/// <exclude/>
	public class ContactCommunication : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ContactCommunication(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactCommunication";
		}

		public ContactCommunication(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ContactCommunication";
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
		/// Дата создания.
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
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Дата изменения.
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
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <exclude/>
		public Guid CommunicationTypeId {
			get {
				return GetTypedColumnValue<Guid>("CommunicationTypeId");
			}
			set {
				SetColumnValue("CommunicationTypeId", value);
				_communicationType = null;
			}
		}

		/// <exclude/>
		public string CommunicationTypeName {
			get {
				return GetTypedColumnValue<string>("CommunicationTypeName");
			}
			set {
				SetColumnValue("CommunicationTypeName", value);
				if (_communicationType != null) {
					_communicationType.Name = value;
				}
			}
		}

		private CommunicationType _communicationType;
		/// <summary>
		/// Тип.
		/// </summary>
		public CommunicationType CommunicationType {
			get {
				return _communicationType ??
					(_communicationType = new CommunicationType(LookupColumnEntities.GetEntity("CommunicationType")));
			}
		}

		/// <summary>
		/// Номер.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <summary>
		/// Позиция.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Id соц.сети.
		/// </summary>
		public string SocialMediaId {
			get {
				return GetTypedColumnValue<string>("SocialMediaId");
			}
			set {
				SetColumnValue("SocialMediaId", value);
			}
		}

		/// <summary>
		/// Номер для поиска.
		/// </summary>
		public string SearchNumber {
			get {
				return GetTypedColumnValue<string>("SearchNumber");
			}
			set {
				SetColumnValue("SearchNumber", value);
			}
		}

		/// <summary>
		/// Активные процессы.
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
		/// Не актуальный.
		/// </summary>
		public bool NonActual {
			get {
				return GetTypedColumnValue<bool>("NonActual");
			}
			set {
				SetColumnValue("NonActual", value);
			}
		}

		/// <exclude/>
		public Guid NonActualReasonId {
			get {
				return GetTypedColumnValue<Guid>("NonActualReasonId");
			}
			set {
				SetColumnValue("NonActualReasonId", value);
				_nonActualReason = null;
			}
		}

		/// <exclude/>
		public string NonActualReasonName {
			get {
				return GetTypedColumnValue<string>("NonActualReasonName");
			}
			set {
				SetColumnValue("NonActualReasonName", value);
				if (_nonActualReason != null) {
					_nonActualReason.Name = value;
				}
			}
		}

		private NonActualReason _nonActualReason;
		/// <summary>
		/// Причина неактуальности.
		/// </summary>
		public NonActualReason NonActualReason {
			get {
				return _nonActualReason ??
					(_nonActualReason = new NonActualReason(LookupColumnEntities.GetEntity("NonActualReason")));
			}
		}

		/// <summary>
		/// Не актуален с.
		/// </summary>
		public DateTime DateSetNonActual {
			get {
				return GetTypedColumnValue<DateTime>("DateSetNonActual");
			}
			set {
				SetColumnValue("DateSetNonActual", value);
			}
		}

		/// <summary>
		/// Created by synchronization.
		/// </summary>
		public bool IsCreatedBySynchronization {
			get {
				return GetTypedColumnValue<bool>("IsCreatedBySynchronization");
			}
			set {
				SetColumnValue("IsCreatedBySynchronization", value);
			}
		}

		/// <summary>
		/// Тип средства связи во внешнем ресурсе.
		/// </summary>
		public string ExternalCommunicationType {
			get {
				return GetTypedColumnValue<string>("ExternalCommunicationType");
			}
			set {
				SetColumnValue("ExternalCommunicationType", value);
			}
		}

		#endregion

	}

	#endregion

}

