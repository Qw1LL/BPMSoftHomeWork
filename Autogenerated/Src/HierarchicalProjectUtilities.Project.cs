using System;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.DB;
using System.Linq;
using System.Collections.Generic;
using BPMSoft.Configuration;
using BPMSoft.Core.Entities;
using BPMSoft.UI.WebControls.Controls;
using System.Collections.ObjectModel;



public static class HierarchicalProjectUtilities {
	public static string GetProjectPath(Guid projectId,UserConnection userConnection) {
		if( projectId == Guid.Empty) {
			return String.Empty;
		}
		var projects =  GetParentProjects(projectId,userConnection) ;
		return String.Join("/",projects.Reverse().Select(n=>n.Value));
	}
	
	public static List<Guid> GetParentProjectsIDs(Guid projectId,UserConnection userConnection) {
		if( projectId == Guid.Empty) {
			return new List<Guid>();
		}
		var projects =  GetParentProjects(projectId,userConnection) ;
		return projects.Select(n=>n.Key).ToList();
	}
	public static List<string> GetParentProjectsNames(Guid projectId,UserConnection userConnection) {
		if( projectId == Guid.Empty) {
			return new List<string>();
		}
		var projects =  GetParentProjects(projectId,userConnection) ;
		return projects.Select(n=>n.Value).ToList();
	}
	
	private static System.Collections.ObjectModel.Collection<KeyValuePair<Guid,string>> GetParentProjects(Guid projectId,UserConnection userConnection) {
		Select projectSelect =
				new BPMSoft.Core.DB.Select(userConnection)
					.Column("Id").As("Id")
					.Column("Name").As("Name")
					.Column("ParentProjectId").As("ParentProjectId")
				.From("Project") as Select;
			HierarchicalSelectOptions options = new HierarchicalSelectOptions() {
				PrimaryColumnName = "Id",
				ParentColumnName = "ParentProjectId",
				SelectType = HierarchicalSelectType.Parents
			};
			QueryCondition startingCondition = options.StartingPrimaryColumnCondition;
			startingCondition.LeftExpression = new QueryColumnExpression("Id");
			startingCondition.IsEqual(Column.Parameter(projectId, "ParentProjectId", BPMSoft.Common.ParameterDirection.Input));
			projectSelect.HierarchicalOptions = options;
			var list = new System.Collections.ObjectModel.Collection<KeyValuePair<Guid,string>>();
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (var reader = projectSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid id = Guid.Empty;
						if(Guid.TryParse(reader[0].ToString(), out id)) {
							list.Add(new KeyValuePair<Guid,string>(id,reader[1].ToString()));
						}
					}
				}
			}
		return list;
	}
	
	public static List<Guid> GetChildProjectsIDs(Guid projectId,UserConnection userConnection) {
		if( projectId == Guid.Empty) {
			return new List<Guid>();
		}
		var projects =  GetChildProjects(projectId,userConnection) ;
		return projects.Select(n=>n.Key).ToList();
	}
	
	public static Dictionary<Guid,KeyValuePair<Guid,string>> GetChildProjects(Guid projectId,UserConnection userConnection) {
		Select projectSelect =
				new BPMSoft.Core.DB.Select(userConnection)
					.Column("Id").As("Id")
					.Column("Name").As("Name")
					.Column("ParentProjectId").As("ParentProjectId")
				.From("Project") as Select;
			HierarchicalSelectOptions options = new HierarchicalSelectOptions() {
				PrimaryColumnName = "Id",
				ParentColumnName = "ParentProjectId",
				SelectType = HierarchicalSelectType.Children
			};
			QueryCondition startingCondition = options.StartingPrimaryColumnCondition;
			startingCondition.LeftExpression = new QueryColumnExpression("Id");
			startingCondition.IsEqual(Column.Parameter(projectId, "ParentProjectId", BPMSoft.Common.ParameterDirection.Input));
			projectSelect.HierarchicalOptions = options;
			var list = new Dictionary<Guid,KeyValuePair<Guid,string>>();
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (var reader = projectSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						if (!reader.IsDBNull(0)){
							var parentId = Guid.Empty;
							if (!reader.IsDBNull(2)){
								parentId = userConnection.DBTypeConverter.DBValueToGuid(reader[2]);
							}
							var id = userConnection.DBTypeConverter.DBValueToGuid(reader[0]);
							list.Add(id,new KeyValuePair<Guid,string>(parentId,reader[1].ToString()));
						}
					}
				}
			}
		return list;
	}
	public static DateTime GetActualProjectEndDate(Guid projectId,UserConnection userConnection) {
		var dataValueTypeManager = (DataValueTypeManager)userConnection.AppManagerProvider.GetManager("DataValueTypeManager");
		var storedProcedure = new StoredProcedure(userConnection, "tsp_GetProjectActualEndDate");
		storedProcedure.WithParameter(Column.Parameter(projectId));
		storedProcedure.WithOutputParameter("return_value", dataValueTypeManager.GetInstanceByName("DateTime"));
		using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
			storedProcedure.Execute(dbExecutor);
			if (storedProcedure.Parameters.FindByName("return_value")?.Value is DateTime) {
				return (DateTime)storedProcedure.Parameters.FindByName("return_value")?.Value;
			}
		}
		return DateTime.Now;
	}
}

