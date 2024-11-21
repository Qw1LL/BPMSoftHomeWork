namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwSectionDesignerModuleInfo

	/// <exclude/>
	public class VwSectionDesignerModuleInfo : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSectionDesignerModuleInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSectionDesignerModuleInfo";
		}

		public VwSectionDesignerModuleInfo(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwSectionDesignerModuleInfo";
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
		/// Code.
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
		/// WorkspaceId.
		/// </summary>
		public Guid WorkspaceId {
			get {
				return GetTypedColumnValue<Guid>("WorkspaceId");
			}
			set {
				SetColumnValue("WorkspaceId", value);
			}
		}

		/// <summary>
		/// WorkspaceName.
		/// </summary>
		public string WorkspaceName {
			get {
				return GetTypedColumnValue<string>("WorkspaceName");
			}
			set {
				SetColumnValue("WorkspaceName", value);
			}
		}

		/// <summary>
		/// EntityId.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <summary>
		/// EntityName.
		/// </summary>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
			}
		}

		/// <summary>
		/// SectionSchemaId.
		/// </summary>
		public Guid SectionSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SectionSchemaId");
			}
			set {
				SetColumnValue("SectionSchemaId", value);
			}
		}

		/// <summary>
		/// SectionSchemaName.
		/// </summary>
		public string SectionSchemaName {
			get {
				return GetTypedColumnValue<string>("SectionSchemaName");
			}
			set {
				SetColumnValue("SectionSchemaName", value);
			}
		}

		/// <summary>
		/// EntityFolderId.
		/// </summary>
		public Guid EntityFolderId {
			get {
				return GetTypedColumnValue<Guid>("EntityFolderId");
			}
			set {
				SetColumnValue("EntityFolderId", value);
			}
		}

		/// <summary>
		/// EntityFolderName.
		/// </summary>
		public string EntityFolderName {
			get {
				return GetTypedColumnValue<string>("EntityFolderName");
			}
			set {
				SetColumnValue("EntityFolderName", value);
			}
		}

		/// <summary>
		/// EntityInFolderId.
		/// </summary>
		public Guid EntityInFolderId {
			get {
				return GetTypedColumnValue<Guid>("EntityInFolderId");
			}
			set {
				SetColumnValue("EntityInFolderId", value);
			}
		}

		/// <summary>
		/// EntityInFolderName.
		/// </summary>
		public string EntityInFolderName {
			get {
				return GetTypedColumnValue<string>("EntityInFolderName");
			}
			set {
				SetColumnValue("EntityInFolderName", value);
			}
		}

		/// <summary>
		/// TypeColumnId.
		/// </summary>
		public Guid TypeColumnId {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnId");
			}
			set {
				SetColumnValue("TypeColumnId", value);
			}
		}

		/// <summary>
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Header.
		/// </summary>
		public string Header {
			get {
				return GetTypedColumnValue<string>("Header");
			}
			set {
				SetColumnValue("Header", value);
			}
		}

		/// <summary>
		/// SysModuleEntityId.
		/// </summary>
		public Guid SysModuleEntityId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEntityId");
			}
			set {
				SetColumnValue("SysModuleEntityId", value);
			}
		}

		/// <summary>
		/// SysModuleCaptionLczId.
		/// </summary>
		public Guid SysModuleCaptionLczId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleCaptionLczId");
			}
			set {
				SetColumnValue("SysModuleCaptionLczId", value);
			}
		}

		/// <summary>
		/// SysModuleHeaderLczId.
		/// </summary>
		public Guid SysModuleHeaderLczId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleHeaderLczId");
			}
			set {
				SetColumnValue("SysModuleHeaderLczId", value);
			}
		}

		/// <summary>
		/// CultureId.
		/// </summary>
		public Guid CultureId {
			get {
				return GetTypedColumnValue<Guid>("CultureId");
			}
			set {
				SetColumnValue("CultureId", value);
			}
		}

		/// <summary>
		/// Image32Id.
		/// </summary>
		public Guid Image32Id {
			get {
				return GetTypedColumnValue<Guid>("Image32Id");
			}
			set {
				SetColumnValue("Image32Id", value);
			}
		}

		/// <summary>
		/// SectionDetailId.
		/// </summary>
		public Guid SectionDetailId {
			get {
				return GetTypedColumnValue<Guid>("SectionDetailId");
			}
			set {
				SetColumnValue("SectionDetailId", value);
			}
		}

		/// <summary>
		/// SectionDetailName.
		/// </summary>
		public string SectionDetailName {
			get {
				return GetTypedColumnValue<string>("SectionDetailName");
			}
			set {
				SetColumnValue("SectionDetailName", value);
			}
		}

		/// <summary>
		/// LogoId.
		/// </summary>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
			}
		}

		/// <summary>
		/// EntityTagId.
		/// </summary>
		public Guid EntityTagId {
			get {
				return GetTypedColumnValue<Guid>("EntityTagId");
			}
			set {
				SetColumnValue("EntityTagId", value);
			}
		}

		/// <summary>
		/// EntityTagName.
		/// </summary>
		public string EntityTagName {
			get {
				return GetTypedColumnValue<string>("EntityTagName");
			}
			set {
				SetColumnValue("EntityTagName", value);
			}
		}

		/// <summary>
		/// EntityInTagId.
		/// </summary>
		public Guid EntityInTagId {
			get {
				return GetTypedColumnValue<Guid>("EntityInTagId");
			}
			set {
				SetColumnValue("EntityInTagId", value);
			}
		}

		/// <summary>
		/// EntityInTagName.
		/// </summary>
		public string EntityInTagName {
			get {
				return GetTypedColumnValue<string>("EntityInTagName");
			}
			set {
				SetColumnValue("EntityInTagName", value);
			}
		}

		/// <summary>
		/// CaptionOld.
		/// </summary>
		public string CaptionOld {
			get {
				return GetTypedColumnValue<string>("CaptionOld");
			}
			set {
				SetColumnValue("CaptionOld", value);
			}
		}

		/// <summary>
		/// HeaderOld.
		/// </summary>
		public string HeaderOld {
			get {
				return GetTypedColumnValue<string>("HeaderOld");
			}
			set {
				SetColumnValue("HeaderOld", value);
			}
		}

		/// <summary>
		/// Default caption.
		/// </summary>
		public string DefaultCaption {
			get {
				return GetTypedColumnValue<string>("DefaultCaption");
			}
			set {
				SetColumnValue("DefaultCaption", value);
			}
		}

		/// <summary>
		/// Default header.
		/// </summary>
		public string DefaultHeader {
			get {
				return GetTypedColumnValue<string>("DefaultHeader");
			}
			set {
				SetColumnValue("DefaultHeader", value);
			}
		}

		#endregion

	}

	#endregion

}

