namespace BPMSoft.Configuration
{

	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;
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
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: Case_CaseEventsProcess

	public partial class Case_CaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void SetProcessParameters() {
			var currentContactId = UserConnection.CurrentUser.ContactId;
			NewOwnerId = Entity.GetTypedColumnValue<Guid>("OwnerId");
			OldOwnerId = Entity.GetTypedOldColumnValue<Guid>("OwnerId");
			IsNeedSendRemind = NewOwnerId != OldOwnerId;
			SendToOldOwner = OldOwnerId != currentContactId && OldOwnerId != Guid.Empty;
			SendToNewOwner = NewOwnerId != currentContactId && NewOwnerId != Guid.Empty && NewOwnerId != OldOwnerId;
		}

		public virtual void SetPortalCaseSubject() {
			var subject = Entity.GetTypedColumnValue<string>("Subject"); 
			if (!string.IsNullOrEmpty(subject)) {
				return;
			}
			var number = Entity.GetTypedColumnValue<string>("Number"); 
			var categoryId = Entity.GetTypedColumnValue<Guid>("CategoryId");
			var categoryCaption = GetCaseGategoryCaption(categoryId);
			var byCaption = categoryId != CaseConsts.CaseCategoryServiceCallId ? SubjectByString : SubjectForString;
			var serviceCaption = GetServiceCaption();
			var generatedSubject = string.Format("{0} {1} {2} {3} ", number, categoryCaption, byCaption, serviceCaption);
			Entity.SetColumnValue("Subject", generatedSubject);
		}

		public virtual string GetServiceCaption() {
			return string.Empty; 
		}

		public virtual string GetCaseGategoryCaption(Guid categoryId) {
			var categoryQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "CaseCategory");
			categoryQuery.AddColumn("Name"); 
			var category = categoryQuery .GetEntity(UserConnection, categoryId);
			if(category == null) {
				return string.Empty; 
			} 
			return category.GetTypedColumnValue<string>("Name"); 
		}

		public virtual bool IsStatusChanged(Entity entity) {
			Guid? value = entity.GetTypedColumnValue<Guid>("StatusId");
			Guid? oldValue = entity.GetTypedOldColumnValue<Guid>("StatusId");
			return ((value != null) && !value.Equals(oldValue)) ||
				((value == null) && oldValue != null);
		}

		#endregion

	}

	#endregion

}

