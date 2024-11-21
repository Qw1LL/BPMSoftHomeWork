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

	#region Class: Product_ProductBase_BPMSoftSchema

	/// <exclude/>
	public class Product_ProductBase_BPMSoftSchema : BPMSoft.Configuration.Product_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public Product_ProductBase_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Product_ProductBase_BPMSoftSchema(Product_ProductBase_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Product_ProductBase_BPMSoftSchema(Product_ProductBase_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893");
			Name = "Product_ProductBase_BPMSoft";
			ParentSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed");
			ExtendParent = true;
			CreatedInPackageId = new Guid("a08eefe5-e3d9-4a0c-8558-f93b596572d7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreatePictureColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3f6a282b-4d25-4f87-b63a-4a192abd19f6")) == null) {
				Columns.Add(CreateIsArchiveColumn());
			}
		}

		protected override EntitySchemaColumn CreateUnitColumn() {
			EntitySchemaColumn column = base.CreateUnitColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Settings,
				ValueSource = @"DefaultUnit"
			};
			column.ModifiedInSchemaUId = new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893");
			column.CreatedInPackageId = new Guid("a08eefe5-e3d9-4a0c-8558-f93b596572d7");
			return column;
		}

		protected override EntitySchemaColumn CreateTaxColumn() {
			EntitySchemaColumn column = base.CreateTaxColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Settings,
				ValueSource = @"DefaultTax"
			};
			column.ModifiedInSchemaUId = new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893");
			column.CreatedInPackageId = new Guid("a08eefe5-e3d9-4a0c-8558-f93b596572d7");
			return column;
		}

		protected override EntitySchemaColumn CreateActiveColumn() {
			EntitySchemaColumn column = base.CreateActiveColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893");
			column.CreatedInPackageId = new Guid("a08eefe5-e3d9-4a0c-8558-f93b596572d7");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893");
			column.CreatedInPackageId = new Guid("a08eefe5-e3d9-4a0c-8558-f93b596572d7");
			return column;
		}

		protected override EntitySchemaColumn CreateProductSourceColumn() {
			EntitySchemaColumn column = base.CreateProductSourceColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893");
			column.CreatedInPackageId = new Guid("a08eefe5-e3d9-4a0c-8558-f93b596572d7");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePictureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("3da5d5e7-908f-4cb2-81af-aa137eabb041"),
				Name = @"Picture",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893"),
				ModifiedInSchemaUId = new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893"),
				CreatedInPackageId = new Guid("a08eefe5-e3d9-4a0c-8558-f93b596572d7")
			};
		}

		protected virtual EntitySchemaColumn CreateIsArchiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3f6a282b-4d25-4f87-b63a-4a192abd19f6"),
				Name = @"IsArchive",
				CreatedInSchemaUId = new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893"),
				ModifiedInSchemaUId = new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893"),
				CreatedInPackageId = new Guid("a08eefe5-e3d9-4a0c-8558-f93b596572d7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Product_ProductBase_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Product_ProductBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Product_ProductBase_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Product_ProductBase_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893"));
		}

		#endregion

	}

	#endregion

	#region Class: Product_ProductBase_BPMSoft

	/// <summary>
	/// Продукт.
	/// </summary>
	public class Product_ProductBase_BPMSoft : BPMSoft.Configuration.Product_Base_BPMSoft
	{

		#region Constructors: Public

		public Product_ProductBase_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Product_ProductBase_BPMSoft";
		}

		public Product_ProductBase_BPMSoft(Product_ProductBase_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PictureId {
			get {
				return GetTypedColumnValue<Guid>("PictureId");
			}
			set {
				SetColumnValue("PictureId", value);
				_picture = null;
			}
		}

		/// <exclude/>
		public string PictureName {
			get {
				return GetTypedColumnValue<string>("PictureName");
			}
			set {
				SetColumnValue("PictureName", value);
				if (_picture != null) {
					_picture.Name = value;
				}
			}
		}

		private SysImage _picture;
		/// <summary>
		/// Изображение.
		/// </summary>
		public SysImage Picture {
			get {
				return _picture ??
					(_picture = LookupColumnEntities.GetEntity("Picture") as SysImage);
			}
		}

		/// <summary>
		/// Архивный.
		/// </summary>
		public bool IsArchive {
			get {
				return GetTypedColumnValue<bool>("IsArchive");
			}
			set {
				SetColumnValue("IsArchive", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Product_ProductBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Product_ProductBase_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Product_ProductBase_BPMSoftInserting", e);
			Saving += (s, e) => ThrowEvent("Product_ProductBase_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Product_ProductBase_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Product_ProductBase_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Product_ProductBaseEventsProcess

	/// <exclude/>
	public partial class Product_ProductBaseEventsProcess<TEntity> : BPMSoft.Configuration.Product_BaseEventsProcess<TEntity> where TEntity : Product_ProductBase_BPMSoft
	{

		public Product_ProductBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Product_ProductBaseEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8f3e9f02-7d38-42e3-9363-21bb922a4893");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _productSaveEventSubProcess;
		public ProcessFlowElement ProductSaveEventSubProcess {
			get {
				return _productSaveEventSubProcess ?? (_productSaveEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ProductSaveEventSubProcess",
					SchemaElementUId = new Guid("5d23c651-dbbc-4da8-89f4-a86b3ec21240"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage1ProductSaving;
		public ProcessFlowElement StartMessage1ProductSaving {
			get {
				return _startMessage1ProductSaving ?? (_startMessage1ProductSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage1ProductSaving",
					SchemaElementUId = new Guid("7b63df84-d087-49cc-9010-5d592eae87f0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediateThrowMessageEvent1ProductSaving;
		public ProcessThrowMessageEvent IntermediateThrowMessageEvent1ProductSaving {
			get {
				return _intermediateThrowMessageEvent1ProductSaving ?? (_intermediateThrowMessageEvent1ProductSaving = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "IntermediateThrowMessageEvent1ProductSaving",
					SchemaElementUId = new Guid("f12e0710-110a-4e20-b352-9cdcc62cc8c3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "ProductInserting",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask1ProductSaving;
		public ProcessScriptTask ScriptTask1ProductSaving {
			get {
				return _scriptTask1ProductSaving ?? (_scriptTask1ProductSaving = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1ProductSaving",
					SchemaElementUId = new Guid("6a4e3dc4-08e4-463f-80ef-bac86bbc777c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1ProductSavingExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[ProductSaveEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ProductSaveEventSubProcess };
			FlowElements[StartMessage1ProductSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage1ProductSaving };
			FlowElements[IntermediateThrowMessageEvent1ProductSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateThrowMessageEvent1ProductSaving };
			FlowElements[ScriptTask1ProductSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1ProductSaving };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "ProductSaveEventSubProcess":
						break;
					case "StartMessage1ProductSaving":
						e.Context.QueueTasks.Enqueue("ScriptTask1ProductSaving");
						break;
					case "IntermediateThrowMessageEvent1ProductSaving":
						break;
					case "ScriptTask1ProductSaving":
						e.Context.QueueTasks.Enqueue("IntermediateThrowMessageEvent1ProductSaving");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage1ProductSaving");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "ProductSaveEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage1ProductSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage1ProductSaving";
					result = StartMessage1ProductSaving.Execute(context);
					break;
				case "IntermediateThrowMessageEvent1ProductSaving":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "ProductInserting");
					result = IntermediateThrowMessageEvent1ProductSaving.Execute(context);
					break;
				case "ScriptTask1ProductSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1ProductSaving";
					result = ScriptTask1ProductSaving.Execute(context, ScriptTask1ProductSavingExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1ProductSavingExecute(ProcessExecutingContext context) {
			var pictureId = Entity.GetColumnValue("PictureId");
			if (pictureId == null) { 
				return true;
			}
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, Entity.Schema.Name);
			entitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"Picture.Id", pictureId));
			var entities = entitySchemaQuery.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				var pictureESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysImage");
				pictureESQ.AddAllSchemaColumns();
				var picture = pictureESQ.GetEntity(UserConnection, pictureId);
				if (picture != null) {
					Guid pictureNewGuid = Guid.NewGuid();
					var sysImageSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysImage");
					var sysImage = sysImageSchema.CreateEntity(UserConnection);
					sysImage.SetDefColumnValues();
					sysImage.SetColumnValue("Id", pictureNewGuid);
					sysImage.SetColumnValue("Name", picture.GetTypedColumnValue<string>("Name"));
					sysImage.SetColumnValue("Data", picture.GetColumnValue("Data"));
					sysImage.SetColumnValue("MimeType", picture.GetTypedColumnValue<string>("MimeType"));
					sysImage.SetColumnValue("HasRef", picture.GetTypedColumnValue<bool>("HasRef"));
					sysImage.SetColumnValue("PreviewData", picture.GetColumnValue("PreviewData"));
					sysImage.Save();
					Entity.SetColumnValue("PictureId", pictureNewGuid);
				}
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Product_ProductBase_BPMSoftInserting":
							if (ActivatedEventElements.Contains("StartMessage1ProductSaving")) {
							context.QueueTasks.Enqueue("StartMessage1ProductSaving");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Product_ProductBaseEventsProcess

	/// <exclude/>
	public class Product_ProductBaseEventsProcess : Product_ProductBaseEventsProcess<Product_ProductBase_BPMSoft>
	{

		public Product_ProductBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Product_ProductBaseEventsProcess

	public partial class Product_ProductBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

