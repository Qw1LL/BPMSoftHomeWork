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

	#region Class: CommandSchema

	/// <exclude/>
	public class CommandSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CommandSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CommandSchema(CommandSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CommandSchema(CommandSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090");
			RealUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090");
			Name = "Command";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4b27f7ed-038d-4412-8fb5-2357794a7bbf")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("61de004e-1d41-4bbf-9add-20d505f30dac"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090"),
				ModifiedInSchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090"),
				CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("4b27f7ed-038d-4412-8fb5-2357794a7bbf"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090"),
				ModifiedInSchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090"),
				CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Command(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Command_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CommandSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CommandSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090"));
		}

		#endregion

	}

	#endregion

	#region Class: Command

	/// <summary>
	/// Macro in command line.
	/// </summary>
	public class Command : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Command(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Command";
		}

		public Command(Command source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Command_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CommandDeleted", e);
			Inserting += (s, e) => ThrowEvent("CommandInserting", e);
			Validating += (s, e) => ThrowEvent("CommandValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Command(this);
		}

		#endregion

	}

	#endregion

	#region Class: Command_NUIEventsProcess

	/// <exclude/>
	public partial class Command_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Command
	{

		public Command_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Command_NUIEventsProcess";
			SchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090");
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

	#region Class: Command_NUIEventsProcess

	/// <exclude/>
	public class Command_NUIEventsProcess : Command_NUIEventsProcess<Command>
	{

		public Command_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Command_NUIEventsProcess

	public partial class Command_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CommandEventsProcess

	/// <exclude/>
	public class CommandEventsProcess : Command_NUIEventsProcess
	{

		public CommandEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

