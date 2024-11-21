namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BaseCommunication

	/// <exclude/>
	public class BaseCommunication : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BaseCommunication(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseCommunication";
		}

		public BaseCommunication(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BaseCommunication";
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
		/// Type.
		/// </summary>
		public CommunicationType CommunicationType {
			get {
				return _communicationType ??
					(_communicationType = new CommunicationType(LookupColumnEntities.GetEntity("CommunicationType")));
			}
		}

		/// <summary>
		/// Number.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <summary>
		/// Position.
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
		/// Social network Id.
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
		/// Number for search.
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

		#endregion

	}

	#endregion

}

