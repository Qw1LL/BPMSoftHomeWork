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

	#region Class: SysUserSessionSchema

	/// <exclude/>
	public class SysUserSessionSchema : BPMSoft.Configuration.SysUserSession_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysUserSessionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUserSessionSchema(SysUserSessionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUserSessionSchema(SysUserSessionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateISysUserSessEndDateIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("97fc6e87-0eac-4738-a3a0-cded3ee2affe");
			index.Name = "ISysUserSessEndDateId";
			index.CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			EntitySchemaIndexColumn sessionEndDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("99d28ef5-8120-4605-a15c-a47bf3268905"),
				ColumnUId = new Guid("86a0a1f4-7d2d-45da-b313-8f96c983215c"),
				CreatedInSchemaUId = Guid.Empty,
				ModifiedInSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sessionEndDateIndexColumn);
			EntitySchemaIndexColumn sessionIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("97d387d1-2969-4331-8bd8-cc9cac20c9c7"),
				ColumnUId = new Guid("f443b1a3-3c1c-4a25-8add-b3255ea19099"),
				CreatedInSchemaUId = Guid.Empty,
				ModifiedInSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sessionIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateISysUserSessionUserIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("e1f2730f-03f5-4526-acf1-cd929fdbb3a0");
			index.Name = "ISysUserSessionUserId";
			index.CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf");
			EntitySchemaIndexColumn sysUserIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("cdda2024-8137-4a11-ad6f-11d702d8a8f6"),
				ColumnUId = new Guid("61b6df7e-99db-458f-980d-68308d2dd08c"),
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysUserIdIndexColumn);
			EntitySchemaIndexColumn sessionEndDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ffcfaa0a-d163-4978-bf5d-73a7e781472a"),
				ColumnUId = new Guid("86a0a1f4-7d2d-45da-b313-8f96c983215c"),
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sessionEndDateIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("662bc408-b2df-48a2-8207-85beb94eb2e4");
			Name = "SysUserSession";
			ParentSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			ExtendParent = true;
			CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("69fb32b0-1fcf-4310-86be-7db7212fe4a8")) == null) {
				Columns.Add(CreateExternalAccessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateExternalAccessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("69fb32b0-1fcf-4310-86be-7db7212fe4a8"),
				Name = @"ExternalAccess",
				ReferenceSchemaUId = new Guid("f3858e46-ea38-412e-af4a-2011f08718ae"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("662bc408-b2df-48a2-8207-85beb94eb2e4"),
				ModifiedInSchemaUId = new Guid("662bc408-b2df-48a2-8207-85beb94eb2e4"),
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISysUserSessEndDateIdIndex());
			Indexes.Add(CreateISysUserSessionUserIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysUserSession(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUserSession_ExternalAccessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUserSessionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUserSessionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("662bc408-b2df-48a2-8207-85beb94eb2e4"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUserSession

	/// <summary>
	/// User session.
	/// </summary>
	public class SysUserSession : BPMSoft.Configuration.SysUserSession_Base_BPMSoft
	{

		#region Constructors: Public

		public SysUserSession(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUserSession";
		}

		public SysUserSession(SysUserSession source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ExternalAccessId {
			get {
				return GetTypedColumnValue<Guid>("ExternalAccessId");
			}
			set {
				SetColumnValue("ExternalAccessId", value);
				_externalAccess = null;
			}
		}

		/// <exclude/>
		public string ExternalAccessAccessReason {
			get {
				return GetTypedColumnValue<string>("ExternalAccessAccessReason");
			}
			set {
				SetColumnValue("ExternalAccessAccessReason", value);
				if (_externalAccess != null) {
					_externalAccess.AccessReason = value;
				}
			}
		}

		private ExternalAccess _externalAccess;
		/// <summary>
		/// External access.
		/// </summary>
		public ExternalAccess ExternalAccess {
			get {
				return _externalAccess ??
					(_externalAccess = LookupColumnEntities.GetEntity("ExternalAccess") as ExternalAccess);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysUserSession_ExternalAccessEventsProcess(UserConnection);
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
			return new SysUserSession(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserSession_ExternalAccessEventsProcess

	/// <exclude/>
	public partial class SysUserSession_ExternalAccessEventsProcess<TEntity> : BPMSoft.Configuration.SysUserSession_BaseEventsProcess<TEntity> where TEntity : SysUserSession
	{

		public SysUserSession_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUserSession_ExternalAccessEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("662bc408-b2df-48a2-8207-85beb94eb2e4");
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

	#region Class: SysUserSession_ExternalAccessEventsProcess

	/// <exclude/>
	public class SysUserSession_ExternalAccessEventsProcess : SysUserSession_ExternalAccessEventsProcess<SysUserSession>
	{

		public SysUserSession_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUserSession_ExternalAccessEventsProcess

	public partial class SysUserSession_ExternalAccessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysUserSessionEventsProcess

	/// <exclude/>
	public class SysUserSessionEventsProcess : SysUserSession_ExternalAccessEventsProcess
	{

		public SysUserSessionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

