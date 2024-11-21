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

	#region Class: CommandParamsSchema

	/// <exclude/>
	public class CommandParamsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CommandParamsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CommandParamsSchema(CommandParamsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CommandParamsSchema(CommandParamsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e");
			RealUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e");
			Name = "CommandParams";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d75d1e5f-0414-4dff-a8d7-e415c6f43067")) == null) {
				Columns.Add(CreateCommandColumn());
			}
			if (Columns.FindByUId(new Guid("b796b8eb-9c18-41d7-a7d3-67248cc78185")) == null) {
				Columns.Add(CreateMainParamColumn());
			}
			if (Columns.FindByUId(new Guid("1da56012-f89d-437f-ab67-8e7e41aa114f")) == null) {
				Columns.Add(CreateAdditionalParamColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCommandColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d75d1e5f-0414-4dff-a8d7-e415c6f43067"),
				Name = @"Command",
				ReferenceSchemaUId = new Guid("0feb9eed-fd62-4ea6-8fd4-2514306e1090"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e"),
				ModifiedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e"),
				CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f")
			};
		}

		protected virtual EntitySchemaColumn CreateMainParamColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b796b8eb-9c18-41d7-a7d3-67248cc78185"),
				Name = @"MainParam",
				ReferenceSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e"),
				ModifiedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e"),
				CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f")
			};
		}

		protected virtual EntitySchemaColumn CreateAdditionalParamColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1da56012-f89d-437f-ab67-8e7e41aa114f"),
				Name = @"AdditionalParam",
				ReferenceSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e"),
				ModifiedInSchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e"),
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
			return new CommandParams(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CommandParams_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CommandParamsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CommandParamsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e"));
		}

		#endregion

	}

	#endregion

	#region Class: CommandParams

	/// <summary>
	/// Parameters of macros for command line.
	/// </summary>
	public class CommandParams : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CommandParams(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CommandParams";
		}

		public CommandParams(CommandParams source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CommandId {
			get {
				return GetTypedColumnValue<Guid>("CommandId");
			}
			set {
				SetColumnValue("CommandId", value);
				_command = null;
			}
		}

		/// <exclude/>
		public string CommandName {
			get {
				return GetTypedColumnValue<string>("CommandName");
			}
			set {
				SetColumnValue("CommandName", value);
				if (_command != null) {
					_command.Name = value;
				}
			}
		}

		private Command _command;
		/// <summary>
		/// Command.
		/// </summary>
		public Command Command {
			get {
				return _command ??
					(_command = LookupColumnEntities.GetEntity("Command") as Command);
			}
		}

		/// <exclude/>
		public Guid MainParamId {
			get {
				return GetTypedColumnValue<Guid>("MainParamId");
			}
			set {
				SetColumnValue("MainParamId", value);
				_mainParam = null;
			}
		}

		/// <exclude/>
		public string MainParamName {
			get {
				return GetTypedColumnValue<string>("MainParamName");
			}
			set {
				SetColumnValue("MainParamName", value);
				if (_mainParam != null) {
					_mainParam.Name = value;
				}
			}
		}

		private MainParam _mainParam;
		/// <summary>
		/// Primary parameter.
		/// </summary>
		public MainParam MainParam {
			get {
				return _mainParam ??
					(_mainParam = LookupColumnEntities.GetEntity("MainParam") as MainParam);
			}
		}

		/// <exclude/>
		public Guid AdditionalParamId {
			get {
				return GetTypedColumnValue<Guid>("AdditionalParamId");
			}
			set {
				SetColumnValue("AdditionalParamId", value);
				_additionalParam = null;
			}
		}

		/// <exclude/>
		public string AdditionalParamColumnCaption {
			get {
				return GetTypedColumnValue<string>("AdditionalParamColumnCaption");
			}
			set {
				SetColumnValue("AdditionalParamColumnCaption", value);
				if (_additionalParam != null) {
					_additionalParam.ColumnCaption = value;
				}
			}
		}

		private AdditionalParam _additionalParam;
		/// <summary>
		/// Additional parameter.
		/// </summary>
		public AdditionalParam AdditionalParam {
			get {
				return _additionalParam ??
					(_additionalParam = LookupColumnEntities.GetEntity("AdditionalParam") as AdditionalParam);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CommandParams_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CommandParamsDeleted", e);
			Inserting += (s, e) => ThrowEvent("CommandParamsInserting", e);
			Validating += (s, e) => ThrowEvent("CommandParamsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CommandParams(this);
		}

		#endregion

	}

	#endregion

	#region Class: CommandParams_NUIEventsProcess

	/// <exclude/>
	public partial class CommandParams_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CommandParams
	{

		public CommandParams_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CommandParams_NUIEventsProcess";
			SchemaUId = new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e2f77269-f819-46fd-8799-9d5ecef00f8e");
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

	#region Class: CommandParams_NUIEventsProcess

	/// <exclude/>
	public class CommandParams_NUIEventsProcess : CommandParams_NUIEventsProcess<CommandParams>
	{

		public CommandParams_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CommandParams_NUIEventsProcess

	public partial class CommandParams_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CommandParamsEventsProcess

	/// <exclude/>
	public class CommandParamsEventsProcess : CommandParams_NUIEventsProcess
	{

		public CommandParamsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

