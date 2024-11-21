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

	#region Class: SocialMentionSchema

	/// <exclude/>
	public class SocialMentionSchema : BPMSoft.Configuration.SocialMention_ESN_BPMSoftSchema
	{

		#region Constructors: Public

		public SocialMentionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialMentionSchema(SocialMentionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialMentionSchema(SocialMentionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("6ace341b-7d5e-4273-8fb8-3fd792a96ede");
			Name = "SocialMention";
			ParentSchemaUId = new Guid("99ab74f3-cdbf-4054-83d8-96c433f423fe");
			ExtendParent = true;
			CreatedInPackageId = new Guid("479f70b4-9acf-4e9e-85c9-3a190e2b8f8d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialMention(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialMention_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialMentionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialMentionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6ace341b-7d5e-4273-8fb8-3fd792a96ede"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialMention

	/// <summary>
	/// User mention.
	/// </summary>
	public class SocialMention : BPMSoft.Configuration.SocialMention_ESN_BPMSoft
	{

		#region Constructors: Public

		public SocialMention(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialMention";
		}

		public SocialMention(SocialMention source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialMention_SSPEventsProcess(UserConnection);
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
			return new SocialMention(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialMention_SSPEventsProcess

	/// <exclude/>
	public partial class SocialMention_SSPEventsProcess<TEntity> : BPMSoft.Configuration.SocialMention_ESNEventsProcess<TEntity> where TEntity : SocialMention
	{

		public SocialMention_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialMention_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6ace341b-7d5e-4273-8fb8-3fd792a96ede");
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

	#region Class: SocialMention_SSPEventsProcess

	/// <exclude/>
	public class SocialMention_SSPEventsProcess : SocialMention_SSPEventsProcess<SocialMention>
	{

		public SocialMention_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialMention_SSPEventsProcess

	public partial class SocialMention_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialMentionEventsProcess

	/// <exclude/>
	public class SocialMentionEventsProcess : SocialMention_SSPEventsProcess
	{

		public SocialMentionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

