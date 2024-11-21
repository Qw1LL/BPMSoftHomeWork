namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: OAuthApplications

	/// <exclude/>
	public class OAuthApplications : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OAuthApplications(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthApplications";
		}

		public OAuthApplications(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OAuthApplications";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<MailServer> MailServerCollectionByOAuthApplication {
			get;
			set;
		}

		public IEnumerable<OAuth20AppFile> OAuth20AppFileCollectionByOAuth20App {
			get;
			set;
		}

		public IEnumerable<OAuth20AppInFolder> OAuth20AppInFolderCollectionByOAuth20App {
			get;
			set;
		}

		public IEnumerable<OAuth20AppInTag> OAuth20AppInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<OAuthAppScope> OAuthAppScopeCollectionByOAuth20App {
			get;
			set;
		}

		public IEnumerable<OAuthTokenStorage> OAuthTokenStorageCollectionByOAuthApp {
			get;
			set;
		}

		public IEnumerable<VwOAuthAppUser> VwOAuthAppUserCollectionByOAuthApp {
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
		/// Имя класса приложения.
		/// </summary>
		public string AppClassName {
			get {
				return GetTypedColumnValue<string>("AppClassName");
			}
			set {
				SetColumnValue("AppClassName", value);
			}
		}

		/// <summary>
		/// Идентификатор клиента в приложении.
		/// </summary>
		public string ClientId {
			get {
				return GetTypedColumnValue<string>("ClientId");
			}
			set {
				SetColumnValue("ClientId", value);
			}
		}

		/// <summary>
		/// Секретный ключ приложения.
		/// </summary>
		public string SecretKey {
			get {
				return GetTypedColumnValue<string>("SecretKey");
			}
			set {
				SetColumnValue("SecretKey", value);
			}
		}

		/// <summary>
		/// Имя класса OAuth клиента.
		/// </summary>
		public string ClientClassName {
			get {
				return GetTypedColumnValue<string>("ClientClassName");
			}
			set {
				SetColumnValue("ClientClassName", value);
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
		/// URL запроса кода авторизации.
		/// </summary>
		public string AuthorizeUrl {
			get {
				return GetTypedColumnValue<string>("AuthorizeUrl");
			}
			set {
				SetColumnValue("AuthorizeUrl", value);
			}
		}

		/// <summary>
		/// URL запроса токена.
		/// </summary>
		public string TokenUrl {
			get {
				return GetTypedColumnValue<string>("TokenUrl");
			}
			set {
				SetColumnValue("TokenUrl", value);
			}
		}

		/// <summary>
		/// URL отзыва токена.
		/// </summary>
		public string RevokeTokenUrl {
			get {
				return GetTypedColumnValue<string>("RevokeTokenUrl");
			}
			set {
				SetColumnValue("RevokeTokenUrl", value);
			}
		}

		/// <summary>
		/// Использовать общего пользователя.
		/// </summary>
		public bool UseSharedUser {
			get {
				return GetTypedColumnValue<bool>("UseSharedUser");
			}
			set {
				SetColumnValue("UseSharedUser", value);
			}
		}

		/// <exclude/>
		public Guid SharedUserId {
			get {
				return GetTypedColumnValue<Guid>("SharedUserId");
			}
			set {
				SetColumnValue("SharedUserId", value);
				_sharedUser = null;
			}
		}

		/// <exclude/>
		public string SharedUserName {
			get {
				return GetTypedColumnValue<string>("SharedUserName");
			}
			set {
				SetColumnValue("SharedUserName", value);
				if (_sharedUser != null) {
					_sharedUser.Name = value;
				}
			}
		}

		private SysAdminUnit _sharedUser;
		/// <summary>
		/// Общий пользователь.
		/// </summary>
		public SysAdminUnit SharedUser {
			get {
				return _sharedUser ??
					(_sharedUser = new SysAdminUnit(LookupColumnEntities.GetEntity("SharedUser")));
			}
		}

		/// <exclude/>
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Image.
		/// </summary>
		/// <remarks>
		/// Image.
		/// </remarks>
		public SysImage Image {
			get {
				return _image ??
					(_image = new SysImage(LookupColumnEntities.GetEntity("Image")));
			}
		}

		/// <summary>
		/// Отправлять данные авторизации в.
		/// </summary>
		public int CredentialsLocationInRequest {
			get {
				return GetTypedColumnValue<int>("CredentialsLocationInRequest");
			}
			set {
				SetColumnValue("CredentialsLocationInRequest", value);
			}
		}

		/// <summary>
		/// AccessType.
		/// </summary>
		public int AccessType {
			get {
				return GetTypedColumnValue<int>("AccessType");
			}
			set {
				SetColumnValue("AccessType", value);
			}
		}

		#endregion

	}

	#endregion

}

