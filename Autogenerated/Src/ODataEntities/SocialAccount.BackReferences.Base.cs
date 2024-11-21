namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SocialAccount

	/// <exclude/>
	public class SocialAccount : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SocialAccount(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialAccount";
		}

		public SocialAccount(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SocialAccount";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<ActivityCorrespondence> ActivityCorrespondenceCollectionBySourceAccount {
			get;
			set;
		}

		public IEnumerable<Contact> ContactCollectionByFacebookAFDA {
			get;
			set;
		}

		public IEnumerable<Contact> ContactCollectionByLinkedInAFDA {
			get;
			set;
		}

		public IEnumerable<Contact> ContactCollectionByTwitterAFDA {
			get;
			set;
		}

		public IEnumerable<ContactCorrespondence> ContactCorrespondenceCollectionBySourceAccount {
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

		/// <summary>
		/// Описание.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <summary>
		/// Логин.
		/// </summary>
		public string Login {
			get {
				return GetTypedColumnValue<string>("Login");
			}
			set {
				SetColumnValue("Login", value);
			}
		}

		/// <summary>
		/// Общая.
		/// </summary>
		public bool Public {
			get {
				return GetTypedColumnValue<bool>("Public");
			}
			set {
				SetColumnValue("Public", value);
			}
		}

		/// <summary>
		/// Access Token.
		/// </summary>
		public string AccessToken {
			get {
				return GetTypedColumnValue<string>("AccessToken");
			}
			set {
				SetColumnValue("AccessToken", value);
			}
		}

		/// <summary>
		/// Access Secret Token.
		/// </summary>
		public string AccessSecretToken {
			get {
				return GetTypedColumnValue<string>("AccessSecretToken");
			}
			set {
				SetColumnValue("AccessSecretToken", value);
			}
		}

		/// <summary>
		/// Consumer Key.
		/// </summary>
		public string ConsumerKey {
			get {
				return GetTypedColumnValue<string>("ConsumerKey");
			}
			set {
				SetColumnValue("ConsumerKey", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private CommunicationType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public CommunicationType Type {
			get {
				return _type ??
					(_type = new CommunicationType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <exclude/>
		public Guid UserId {
			get {
				return GetTypedColumnValue<Guid>("UserId");
			}
			set {
				SetColumnValue("UserId", value);
				_user = null;
			}
		}

		/// <exclude/>
		public string UserName {
			get {
				return GetTypedColumnValue<string>("UserName");
			}
			set {
				SetColumnValue("UserName", value);
				if (_user != null) {
					_user.Name = value;
				}
			}
		}

		private SysAdminUnit _user;
		/// <summary>
		/// Пользователь.
		/// </summary>
		public SysAdminUnit User {
			get {
				return _user ??
					(_user = new SysAdminUnit(LookupColumnEntities.GetEntity("User")));
			}
		}

		/// <summary>
		/// Пользователь соц. сети.
		/// </summary>
		public string SocialId {
			get {
				return GetTypedColumnValue<string>("SocialId");
			}
			set {
				SetColumnValue("SocialId", value);
			}
		}

		/// <summary>
		/// Срок действия истек.
		/// </summary>
		public bool IsExpired {
			get {
				return GetTypedColumnValue<bool>("IsExpired");
			}
			set {
				SetColumnValue("IsExpired", value);
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

		#endregion

	}

	#endregion

}

