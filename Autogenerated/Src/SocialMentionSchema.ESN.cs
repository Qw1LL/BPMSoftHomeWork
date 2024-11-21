namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;

	#region Class: SocialMention_ESN_BPMSoftSchema

	/// <exclude/>
	public class SocialMention_ESN_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SocialMention_ESN_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialMention_ESN_BPMSoftSchema(SocialMention_ESN_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialMention_ESN_BPMSoftSchema(SocialMention_ESN_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe");
			RealUId = new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe");
			Name = "SocialMention_ESN_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0d46ff73-7074-4257-9aa5-fd7b5963b0a4")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("a13460c7-635b-44af-93ce-17f2bb4d374d")) == null) {
				Columns.Add(CreateSocialMessageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0d46ff73-7074-4257-9aa5-fd7b5963b0a4"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe"),
				ModifiedInSchemaUId = new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3")
			};
		}

		protected virtual EntitySchemaColumn CreateSocialMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a13460c7-635b-44af-93ce-17f2bb4d374d"),
				Name = @"SocialMessage",
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe"),
				ModifiedInSchemaUId = new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe"),
				CreatedInPackageId = new Guid("48ad66af-f62a-4e7d-a95a-4445bfd263b3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialMention_ESN_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialMention_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialMention_ESN_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialMention_ESN_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialMention_ESN_BPMSoft

	/// <summary>
	/// User mention.
	/// </summary>
	public class SocialMention_ESN_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SocialMention_ESN_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialMention_ESN_BPMSoft";
		}

		public SocialMention_ESN_BPMSoft(SocialMention_ESN_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		public Guid SocialMessageId {
			get {
				return GetTypedColumnValue<Guid>("SocialMessageId");
			}
			set {
				SetColumnValue("SocialMessageId", value);
				_socialMessage = null;
			}
		}

		/// <exclude/>
		public string SocialMessageMessage {
			get {
				return GetTypedColumnValue<string>("SocialMessageMessage");
			}
			set {
				SetColumnValue("SocialMessageMessage", value);
				if (_socialMessage != null) {
					_socialMessage.Message = value;
				}
			}
		}

		private SocialMessage _socialMessage;
		/// <summary>
		/// Message.
		/// </summary>
		public SocialMessage SocialMessage {
			get {
				return _socialMessage ??
					(_socialMessage = LookupColumnEntities.GetEntity("SocialMessage") as SocialMessage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialMention_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SocialMention_ESN_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("SocialMention_ESN_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialMention_ESN_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialMention_ESNEventsProcess

	/// <exclude/>
	public partial class SocialMention_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SocialMention_ESN_BPMSoft
	{

		public SocialMention_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialMention_ESNEventsProcess";
			SchemaUId = new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe");
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

	#region Class: SocialMention_ESNEventsProcess

	/// <exclude/>
	public class SocialMention_ESNEventsProcess : SocialMention_ESNEventsProcess<SocialMention_ESN_BPMSoft>
	{

		public SocialMention_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialMention_ESNEventsProcess

	public partial class SocialMention_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

