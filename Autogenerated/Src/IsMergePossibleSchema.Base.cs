namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Globalization;

	#region Class: IsMergePossible

	[DesignModeProperty(Name = "MergableIdentifiers", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3b3fd61250644f7da70cdcec574087e4", CaptionResourceItem = "Parameters.MergableIdentifiers.Caption", DescriptionResourceItem = "Parameters.MergableIdentifiers.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EmployeeIdentifiers", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3b3fd61250644f7da70cdcec574087e4", CaptionResourceItem = "Parameters.EmployeeIdentifiers.Caption", DescriptionResourceItem = "Parameters.EmployeeIdentifiers.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MergableSchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3b3fd61250644f7da70cdcec574087e4", CaptionResourceItem = "Parameters.MergableSchemaId.Caption", DescriptionResourceItem = "Parameters.MergableSchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "InvalidEntitiesCount", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3b3fd61250644f7da70cdcec574087e4", CaptionResourceItem = "Parameters.InvalidEntitiesCount.Caption", DescriptionResourceItem = "Parameters.InvalidEntitiesCount.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "InvalidRights", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3b3fd61250644f7da70cdcec574087e4", CaptionResourceItem = "Parameters.InvalidRights.Caption", DescriptionResourceItem = "Parameters.InvalidRights.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "InvalidContacts", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3b3fd61250644f7da70cdcec574087e4", CaptionResourceItem = "Parameters.InvalidContacts.Caption", DescriptionResourceItem = "Parameters.InvalidContacts.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class IsMergePossible : ProcessUserTask
	{

		#region Constructors: Public

		public IsMergePossible(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("3b3fd612-5064-4f7d-a70c-dcec574087e4");
		}

		#endregion

		#region Properties: Public

		public virtual Object MergableIdentifiers {
			get;
			set;
		}

		public virtual Object EmployeeIdentifiers {
			get;
			set;
		}

		public virtual Guid MergableSchemaId {
			get;
			set;
		}

		public virtual bool InvalidEntitiesCount {
			get;
			set;
		}

		public virtual bool InvalidRights {
			get;
			set;
		}

		public virtual bool InvalidContacts {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var securityEngine = UserConnection.DBSecurityEngine;
			var canMergeDuplicates = securityEngine.GetCanExecuteOperation("CanMergeDuplicates", UserConnection.CurrentUser.Id);
			var mergableIdentifiers = MergableIdentifiers as List<Guid>;
			InvalidEntitiesCount = InvalidRights = InvalidContacts = false;
			if (mergableIdentifiers.Count < 2) {
				InvalidEntitiesCount = true;
			} else if (!canMergeDuplicates) {
				InvalidRights = true;
			} else if (MergableSchemaId == new Guid("16BE3651-8FE2-4159-8DD0-A803D4683DD3")) {
				var employeeIdentifiers = new List<Guid>();
				EmployeeIdentifiers = employeeIdentifiers;
				var identifiers = new List<QueryParameter>();
				foreach (var contactId in mergableIdentifiers) {	
					identifiers.Add(new QueryParameter(contactId));
				}
				Select employeesSelectQuery = new Select(UserConnection)
													.Column("ContactId")
							                    	.From("Employee")								
							                    	.Where("ContactId").In(identifiers) as Select;									
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
					using(IDataReader dr = employeesSelectQuery.ExecuteReader(dbExecutor)) {
						while (dr.Read()) {
							Guid empId = UserConnection.DBTypeConverter.DBValueToGuid(dr.GetValue(0));
							employeeIdentifiers.Add(empId);
						}
					}
				}
				InvalidContacts = employeeIdentifiers.Count > 0;
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (MergableIdentifiers != null) {
				if (MergableIdentifiers.GetType().IsSerializable || MergableIdentifiers.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("MergableIdentifiers", MergableIdentifiers, null);
				}
			}
			if (EmployeeIdentifiers != null) {
				if (EmployeeIdentifiers.GetType().IsSerializable || EmployeeIdentifiers.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("EmployeeIdentifiers", EmployeeIdentifiers, null);
				}
			}
			if (!HasMapping("MergableSchemaId")) {
				writer.WriteValue("MergableSchemaId", MergableSchemaId, Guid.Empty);
			}
			if (!HasMapping("InvalidEntitiesCount")) {
				writer.WriteValue("InvalidEntitiesCount", InvalidEntitiesCount, false);
			}
			if (!HasMapping("InvalidRights")) {
				writer.WriteValue("InvalidRights", InvalidRights, false);
			}
			if (!HasMapping("InvalidContacts")) {
				writer.WriteValue("InvalidContacts", InvalidContacts, false);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "MergableIdentifiers":
					MergableIdentifiers = reader.GetSerializableObjectValue();
				break;
				case "EmployeeIdentifiers":
					EmployeeIdentifiers = reader.GetSerializableObjectValue();
				break;
				case "MergableSchemaId":
					MergableSchemaId = reader.GetGuidValue();
				break;
				case "InvalidEntitiesCount":
					InvalidEntitiesCount = reader.GetBoolValue();
				break;
				case "InvalidRights":
					InvalidRights = reader.GetBoolValue();
				break;
				case "InvalidContacts":
					InvalidContacts = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

