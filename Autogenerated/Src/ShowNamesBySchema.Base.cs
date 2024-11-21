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

	#region Class: ShowNamesBySchema

	/// <exclude/>
	public class ShowNamesBySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ShowNamesBySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ShowNamesBySchema(ShowNamesBySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ShowNamesBySchema(ShowNamesBySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
			RealUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
			Name = "ShowNamesBy";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5741501e-fb86-4c7b-b1ac-4a2cd53430ce")) == null) {
				Columns.Add(CreateSeparatorColumn());
			}
			if (Columns.FindByUId(new Guid("f36a44b8-faf2-42ce-a4af-f44e45795230")) == null) {
				Columns.Add(CreateConverterColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
			column.CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
			column.CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
			column.CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
			column.CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
			column.CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
			column.CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
			column.CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
			column.CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSeparatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("5741501e-fb86-4c7b-b1ac-4a2cd53430ce"),
				Name = @"Separator",
				CreatedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7"),
				ModifiedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7"),
				CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847")
			};
		}

		protected virtual EntitySchemaColumn CreateConverterColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f36a44b8-faf2-42ce-a4af-f44e45795230"),
				Name = @"Converter",
				CreatedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7"),
				ModifiedInSchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7"),
				CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ShowNamesBy(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ShowNamesBy_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ShowNamesBySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ShowNamesBySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7"));
		}

		#endregion

	}

	#endregion

	#region Class: ShowNamesBy

	/// <summary>
	/// Order of first/last names.
	/// </summary>
	public class ShowNamesBy : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ShowNamesBy(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ShowNamesBy";
		}

		public ShowNamesBy(ShowNamesBy source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Separator line.
		/// </summary>
		public string Separator {
			get {
				return GetTypedColumnValue<string>("Separator");
			}
			set {
				SetColumnValue("Separator", value);
			}
		}

		/// <summary>
		/// Converter.
		/// </summary>
		public string Converter {
			get {
				return GetTypedColumnValue<string>("Converter");
			}
			set {
				SetColumnValue("Converter", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ShowNamesBy_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ShowNamesByDeleted", e);
			Inserting += (s, e) => ThrowEvent("ShowNamesByInserting", e);
			Validating += (s, e) => ThrowEvent("ShowNamesByValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ShowNamesBy(this);
		}

		#endregion

	}

	#endregion

	#region Class: ShowNamesBy_BaseEventsProcess

	/// <exclude/>
	public partial class ShowNamesBy_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ShowNamesBy
	{

		public ShowNamesBy_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ShowNamesBy_BaseEventsProcess";
			SchemaUId = new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fe0e9a8c-3ba6-46fb-835e-71ac1d91e2b7");
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

	#region Class: ShowNamesBy_BaseEventsProcess

	/// <exclude/>
	public class ShowNamesBy_BaseEventsProcess : ShowNamesBy_BaseEventsProcess<ShowNamesBy>
	{

		public ShowNamesBy_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ShowNamesBy_BaseEventsProcess

	public partial class ShowNamesBy_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ShowNamesByEventsProcess

	/// <exclude/>
	public class ShowNamesByEventsProcess : ShowNamesBy_BaseEventsProcess
	{

		public ShowNamesByEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

