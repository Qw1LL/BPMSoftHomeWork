namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: KnowledgeBaseTagDecoupling

	/// <exclude/>
	public class KnowledgeBaseTagDecoupling : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public KnowledgeBaseTagDecoupling(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnowledgeBaseTagDecoupling";
		}

		public KnowledgeBaseTagDecoupling(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "KnowledgeBaseTagDecoupling";
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

		/// <exclude/>
		public Guid TagId {
			get {
				return GetTypedColumnValue<Guid>("TagId");
			}
			set {
				SetColumnValue("TagId", value);
				_tag = null;
			}
		}

		/// <exclude/>
		public string TagName {
			get {
				return GetTypedColumnValue<string>("TagName");
			}
			set {
				SetColumnValue("TagName", value);
				if (_tag != null) {
					_tag.Name = value;
				}
			}
		}

		private KnowledgeBaseTag _tag;
		/// <summary>
		/// Tag.
		/// </summary>
		public KnowledgeBaseTag Tag {
			get {
				return _tag ??
					(_tag = new KnowledgeBaseTag(LookupColumnEntities.GetEntity("Tag")));
			}
		}

		/// <exclude/>
		public Guid KnowledgeBaseId {
			get {
				return GetTypedColumnValue<Guid>("KnowledgeBaseId");
			}
			set {
				SetColumnValue("KnowledgeBaseId", value);
				_knowledgeBase = null;
			}
		}

		/// <exclude/>
		public string KnowledgeBaseName {
			get {
				return GetTypedColumnValue<string>("KnowledgeBaseName");
			}
			set {
				SetColumnValue("KnowledgeBaseName", value);
				if (_knowledgeBase != null) {
					_knowledgeBase.Name = value;
				}
			}
		}

		private KnowledgeBase _knowledgeBase;
		public KnowledgeBase KnowledgeBase {
			get {
				return _knowledgeBase ??
					(_knowledgeBase = new KnowledgeBase(LookupColumnEntities.GetEntity("KnowledgeBase")));
			}
		}

		#endregion

	}

	#endregion

}

