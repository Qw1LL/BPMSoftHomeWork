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

	#region Class: JunkFilterTypeOfFieldSchema

	/// <exclude/>
	public class JunkFilterTypeOfFieldSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public JunkFilterTypeOfFieldSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public JunkFilterTypeOfFieldSchema(JunkFilterTypeOfFieldSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public JunkFilterTypeOfFieldSchema(JunkFilterTypeOfFieldSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ba7ed54f-f565-4b27-a99d-99fe6a130b3e");
			RealUId = new Guid("ba7ed54f-f565-4b27-a99d-99fe6a130b3e");
			Name = "JunkFilterTypeOfField";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("974b9298-2413-4f75-b309-a858d37c307a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3df7b9b4-11dd-4530-b431-1bbd3c171eb9")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("3df7b9b4-11dd-4530-b431-1bbd3c171eb9"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("ba7ed54f-f565-4b27-a99d-99fe6a130b3e"),
				ModifiedInSchemaUId = new Guid("ba7ed54f-f565-4b27-a99d-99fe6a130b3e"),
				CreatedInPackageId = new Guid("59955e0a-90db-4796-8f0c-f9403b7d622f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new JunkFilterTypeOfField(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new JunkFilterTypeOfField_JunkFilterEventsProcess(userConnection);
		}

		public override object Clone() {
			return new JunkFilterTypeOfFieldSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new JunkFilterTypeOfFieldSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba7ed54f-f565-4b27-a99d-99fe6a130b3e"));
		}

		#endregion

	}

	#endregion

	#region Class: JunkFilterTypeOfField

	/// <summary>
	/// Тип значения поля Email или Домен.
	/// </summary>
	public class JunkFilterTypeOfField : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public JunkFilterTypeOfField(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "JunkFilterTypeOfField";
		}

		public JunkFilterTypeOfField(JunkFilterTypeOfField source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Код.
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
			var process = new JunkFilterTypeOfField_JunkFilterEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("JunkFilterTypeOfFieldDeleted", e);
			Validating += (s, e) => ThrowEvent("JunkFilterTypeOfFieldValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new JunkFilterTypeOfField(this);
		}

		#endregion

	}

	#endregion

	#region Class: JunkFilterTypeOfField_JunkFilterEventsProcess

	/// <exclude/>
	public partial class JunkFilterTypeOfField_JunkFilterEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : JunkFilterTypeOfField
	{

		public JunkFilterTypeOfField_JunkFilterEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "JunkFilterTypeOfField_JunkFilterEventsProcess";
			SchemaUId = new Guid("ba7ed54f-f565-4b27-a99d-99fe6a130b3e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ba7ed54f-f565-4b27-a99d-99fe6a130b3e");
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

	#region Class: JunkFilterTypeOfField_JunkFilterEventsProcess

	/// <exclude/>
	public class JunkFilterTypeOfField_JunkFilterEventsProcess : JunkFilterTypeOfField_JunkFilterEventsProcess<JunkFilterTypeOfField>
	{

		public JunkFilterTypeOfField_JunkFilterEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: JunkFilterTypeOfField_JunkFilterEventsProcess

	public partial class JunkFilterTypeOfField_JunkFilterEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: JunkFilterTypeOfFieldEventsProcess

	/// <exclude/>
	public class JunkFilterTypeOfFieldEventsProcess : JunkFilterTypeOfField_JunkFilterEventsProcess
	{

		public JunkFilterTypeOfFieldEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

