namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: FavoritesSchema

	/// <exclude/>
	public class FavoritesSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public FavoritesSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FavoritesSchema(FavoritesSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FavoritesSchema(FavoritesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62");
			RealUId = new Guid("b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62");
			Name = "Favorites";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("26a9bb7b-13ac-483e-b9f7-b509de43c77d")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("4635886d-64eb-41ec-acf4-a974bcab3964")) == null) {
				Columns.Add(CreateKnowledgeBaseColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("67f86eb6-ce69-4b9f-8266-91d261f6596d"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62"),
				ModifiedInSchemaUId = new Guid("b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62"),
				CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("26a9bb7b-13ac-483e-b9f7-b509de43c77d"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62"),
				ModifiedInSchemaUId = new Guid("b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62"),
				CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f")
			};
		}

		protected virtual EntitySchemaColumn CreateKnowledgeBaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4635886d-64eb-41ec-acf4-a974bcab3964"),
				Name = @"KnowledgeBase",
				ReferenceSchemaUId = new Guid("0326868c-ce5e-4934-8f1f-178801bfe6c3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62"),
				ModifiedInSchemaUId = new Guid("b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62"),
				CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Favorites(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Favorites_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FavoritesSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FavoritesSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62"));
		}

		#endregion

	}

	#endregion

	#region Class: Favorites

	/// <summary>
	/// Favorite knowledge base articles.
	/// </summary>
	public class Favorites : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Favorites(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Favorites";
		}

		public Favorites(Favorites source)
			: base(source) {
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
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
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
		/// <summary>
		/// Article.
		/// </summary>
		public KnowledgeBase KnowledgeBase {
			get {
				return _knowledgeBase ??
					(_knowledgeBase = LookupColumnEntities.GetEntity("KnowledgeBase") as KnowledgeBase);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Favorites_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Favorites(this);
		}

		#endregion

	}

	#endregion

	#region Class: Favorites_BaseEventsProcess

	/// <exclude/>
	public partial class Favorites_BaseEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : Favorites
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public Favorites_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Favorites_BaseEventsProcess";
			SchemaUId = new Guid("b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b0a1ddbb-d5bf-42e2-a12c-ce161fc50e62");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Favorites_BaseEventsProcess

	/// <exclude/>
	public class Favorites_BaseEventsProcess : Favorites_BaseEventsProcess<Favorites>
	{

		public Favorites_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Favorites_BaseEventsProcess

	public partial class Favorites_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FavoritesEventsProcess

	/// <exclude/>
	public class FavoritesEventsProcess : Favorites_BaseEventsProcess
	{

		public FavoritesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

