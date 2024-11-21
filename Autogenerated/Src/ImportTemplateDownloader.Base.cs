namespace BPMSoft.Configuration
{
	using System;
	using System.Web;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	public static class ImportTemplateDownloader
	{
		public static void DownloadTemplate(UserConnection userConnection, LocalizableString fileName) {
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var entitySchema = entitySchemaManager.GetInstanceByName("KnowledgeBaseFile"); 
			var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, entitySchema.Name);
			var dataColumn = entitySchemaQuery.AddColumn("Data");
			entitySchemaQuery.Filters.Add(
				entitySchemaQuery.CreateFilterWithParameters(
					FilterComparisonType.Equal, "KnowledgeBase", new object[] {new Guid("edb71f06-f46b-1410-e980-20cf30b39373")}));
			entitySchemaQuery.Filters.Add(
				entitySchemaQuery.CreateFilterWithParameters(
					FilterComparisonType.Equal, "Name", new object[] {fileName.ToString()}));
			var entityCollection = entitySchemaQuery.GetEntityCollection(userConnection);
			if (entityCollection.Count > 0) {
				var data = entityCollection[0].GetBytesValue(dataColumn.Name)  as byte[];    
				var response = HttpContext.Current.Response; 
				BPMSoft.Configuration.PageResponse.Write(response, data, fileName, BPMSoft.Configuration.ContentType.XmlType);
			}
		}
	}
}
