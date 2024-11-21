namespace BPMSoft.Configuration.ServiceModel
{
	using System;
	using System.Data;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Common;
	using System.Web;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;
	using System.Runtime.Serialization;
	using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ServiceModelDiagramService: BaseService {

		#region Methods: Public

		/// <summary>
		/// ######## ######### ######## ########-######### ######.
		/// </summary>
		/// <param name="entitySchemaName">######## ######## ############ ########.</param>
		/// <param name="elementId">############# ############ ########.</param>
		/// <returns>######### ######## ########-######### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public ServiceModelDiagramServiceResponse GetServiceModelRelationshipDiagramInfo(string entitySchemaName, Guid elementId) {
			var response = new ServiceModelDiagramServiceResponse();
			try {
				response.MainElement = ElementInfo.GetServiceModelElementDiagram(UserConnection, entitySchemaName, elementId);
			}
			catch (Exception e) {
				response.Exception = e;
			}
			return response;
		}

		#endregion

		#region Class: Public

		[DataContract]
		public class ServiceModelDiagramServiceResponse : ConfigurationServiceResponse {

			#region Properties: Public

			/// <summary>
			/// ########### #######.
			/// </summary>
			[DataMember(Name = "mainElement")]
			public ElementInfo MainElement {
				get;
				set;
			}

			#endregion

		}

		[DataContract]
		public class ElementInfo {

			#region Constants: Private

			private const string ConfItemSchemaName = "ConfItem";
			private const string ServiceItemSchemaName = "ServiceItem";
			private const string ServiceRelationshipViewName = "VwServiceRelationship";
			private const string ConfItemRelationshipViewName = "VwConfItemRelationship";
			private const string ServiceInConfItemViewName = "VwServiceInConfItem";
			private const string DependencyCategoryColumnName = "DependencyCategory";
			private const string DependencyCategoryReverseColumnName = "DependencyCategoryReverse";
			private static readonly Guid DependenceCategoryId = new Guid("E1CD26CD-64DF-41E5-9267-2545008ED205");
			private static readonly Guid InfluenceCategoryId = new Guid("4E5E5C5B-F341-4836-AF4E-7F612E1F039D");

			#endregion

			#region Fields: Private

			/// <summary>
			/// ###### ######## ########-######### ######
			/// </summary>
			private List<object> ServiceItems = new List<object>();

			/// <summary>
			/// ###### ################ ###### ########-######### ######
			/// </summary>
			private List<object> ConfItems = new List<object>();

			#endregion

			#region Properties: Private

			private static UserConnection _userConnection;
			/// <summary>
			/// ################ ###########.
			/// </summary>
			private static UserConnection UserConnection {
				get
				{
					return _userConnection;
				}
			}

			/// <summary>
			/// ####### ####, ### ###### - ########### #######.
			/// </summary>
			private bool IsDiagramForService {
				get {
					return EntitySchemaName == ServiceItemSchemaName;
				}
			}

			#endregion

			#region Properties: Public

			/// <summary>
			/// ########## #############.
			/// </summary>
			[DataMember(Name = "id")]
			public Guid Id {
				get;
				set;
			}

			/// <summary>
			/// ######## ########.
			/// </summary>
			[DataMember(Name = "name")]
			public string Name {
				get;
				set;
			}

			/// <summary>
			/// ######## ##### ########.
			/// </summary>
			[DataMember(Name = "entitySchemaName")]
			public string EntitySchemaName {
				get;
				set;
			}

			/// <summary>
			/// ####### ######### ########.
			/// </summary>
			[DataMember(Name = "isActive")]
			public bool IsActive {
				get;
				set;
			}

			/// <summary>
			/// ######### ########### #######.
			/// </summary>
			[DataMember(Name = "categoryId")]
			public Guid CategoryId {
				get;
				set;
			}

			/// <summary>
			/// ######## #### ########### #######.
			/// </summary>
			[DataMember(Name = "typeName")]
			public string TypeName {
				get;
				set;
			}

			/// <summary>
			/// ############# ####### ################ #######.
			/// </summary>
			[DataMember(Name = "confItemStatusId")]
			public Guid ConfItemStatusId
			{
				get;
				set;
			}

			/// <summary>
			/// ############# ######### ################ #######.
			/// </summary>
			[DataMember(Name = "confItemCategoryId")]
			public Guid ConfItemCategoryId
			{
				get;
				set;
			}

			/// <summary>
			/// ############# #### ################ #######.
			/// </summary>
			[DataMember(Name = "confItemTypeId")]
			public Guid ConfItemTypeId
			{
				get;
				set;
			}

			/// <summary>
			/// ############# ###### ################ #######.
			/// </summary>
			[DataMember(Name = "confItemModelId")]
			public Guid ConfItemModelId
			{
				get;
				set;
			}

			/// <summary>
			/// ###### ######### #########.
			/// </summary>
			[DataMember(Name = "dependenceElements")]
			public List<ElementInfo> DependenceElements {
				get;
				set;
			}

			/// <summary>
			/// ###### ######## #########.
			/// </summary>
			[DataMember(Name = "influenceElements")]
			public List<ElementInfo> InfluenceElements {
				get;
				set;
			}

			#endregion

			#region Constructors: Private

			/// <summary>
			/// ####### ##### ####### ########-######### ######
			/// </summary>
			/// <param name="entityName">######## ######## ########</param>
			/// <param name="id">############# ########</param>
			private ElementInfo(string entityName, Guid id) {
				Id = id;
				EntitySchemaName = entityName;
			}

			#endregion

			#region Methods: Private

			/// <summary>
			/// ######### ########## # ######## #########.
			/// </summary>
			private void FillInfo() {
				var elementTableEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, EntitySchemaName);
				var nameColumnName = elementTableEsq.AddColumn("Name").Name;
				var isActiveColumnName = elementTableEsq.AddColumn("Status.Active").Name;
				var confItemStatusColumnName = string.Empty;
				var confItemCategoryColumnName = string.Empty;
				var confItemTypeColumnName = string.Empty;
				var confItemModelColumnName = string.Empty; 
				if (!IsDiagramForService) {
					confItemStatusColumnName = elementTableEsq.AddColumn("Status").Name;
					confItemCategoryColumnName = elementTableEsq.AddColumn("Category").Name;
					confItemTypeColumnName = elementTableEsq.AddColumn("Type").Name;
					confItemModelColumnName = elementTableEsq.AddColumn("Model").Name;
				}
				var entity = elementTableEsq.GetEntity(UserConnection, Id);
				if (entity == null) {
					return;
				}
				Name = entity.GetTypedColumnValue<string>(nameColumnName);
				IsActive = entity.GetTypedColumnValue<bool>(isActiveColumnName);
				if (!IsDiagramForService) {
					ConfItemStatusId = entity.GetTypedColumnValue<Guid>(confItemStatusColumnName + "Id");
					ConfItemCategoryId = entity.GetTypedColumnValue<Guid>(confItemCategoryColumnName + "Id");
					ConfItemTypeId = entity.GetTypedColumnValue<Guid>(confItemTypeColumnName + "Id");
					ConfItemModelId = entity.GetTypedColumnValue<Guid>(confItemModelColumnName + "Id");
				}
				SaveSelectedServiceModelElements(Id, !IsDiagramForService);
			}

			/// <summary>
			/// ######## ###### ######### ######## ### ################ ######.
			/// </summary>
			/// <param name="categoryId">############# ######### ########### ########.</param>
			/// <param name="searchRelationItems">###### #########, ## ####### ######### ##### ######.</param>
			/// <returns>###### ######### ######## ### ################ ######.</returns>
			private List<ElementInfo> GetServiceInConfItemItems(Guid categoryId, IList<object> searchRelationItems) {
				var elementsEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, ServiceInConfItemViewName);
				var elementSchemaColumnName = IsDiagramForService ? ConfItemSchemaName : ServiceItemSchemaName;
				var elementIdColumn = elementsEsq.AddColumn(elementSchemaColumnName);
				var elementNameColumn = elementsEsq.AddColumn(elementSchemaColumnName + ".Name");
				var isActiveElementColumn = elementsEsq.AddColumn(string.Format("{0}.Status.Active", elementSchemaColumnName));
				var dependencyTypeNameColumn = elementsEsq.AddColumn("DependencyType.Name");
				var dependencyTypeReverseNameColumn = elementsEsq.AddColumn("DependencyType.ReverseTypeName");
				var dependencyTypeCategoryColumn = elementsEsq.AddColumn("DependencyType.DependencyCategory");
				var confItemStatusColumnName = string.Empty; 
				var confItemCategoryColumnName = string.Empty;
				var confItemTypeColumnName = string.Empty;
				var confItemModelColumnName = string.Empty; 
				if (IsDiagramForService) {
					confItemStatusColumnName = elementsEsq.AddColumn(ConfItemSchemaName + ".Status").Name;
					confItemCategoryColumnName = elementsEsq.AddColumn(ConfItemSchemaName + ".Category").Name;
					confItemTypeColumnName = elementsEsq.AddColumn(ConfItemSchemaName + ".Type").Name;
					confItemModelColumnName = elementsEsq.AddColumn(ConfItemSchemaName + ".Model").Name;
				}
				var filterColumnName = IsDiagramForService ? ServiceItemSchemaName : ConfItemSchemaName;
				elementsEsq.Filters.Add(
					elementsEsq.CreateFilterWithParameters(FilterComparisonType.Equal, filterColumnName, Id));
				var filterDependencyCategoryColumnName = !IsDiagramForService 
					? DependencyCategoryReverseColumnName 
					: DependencyCategoryColumnName;
				elementsEsq.Filters.Add(
					elementsEsq.CreateFilterWithParameters(FilterComparisonType.Equal, filterDependencyCategoryColumnName, categoryId));
				var relationElements = new List<ElementInfo>();
				if (searchRelationItems != null) {
					if (searchRelationItems.Count == 0) {
						return relationElements;
					}
					var searchRelationItemsColumnName = IsDiagramForService ? ConfItemSchemaName : ServiceItemSchemaName;
						elementsEsq.Filters.Add(elementsEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
							searchRelationItemsColumnName, searchRelationItems.ToArray()));
				}
				var elementCollection = elementsEsq.GetEntityCollection(UserConnection);
				foreach (var record in elementCollection) {
					var id = record.GetTypedColumnValue<Guid>(elementIdColumn.Name + "Id");
					var element = new ElementInfo(elementSchemaColumnName, id) {
						Name = record.GetTypedColumnValue<string>(elementNameColumn.Name),
						CategoryId = categoryId
					};
					element.IsActive = record.GetTypedColumnValue<bool>(isActiveElementColumn.Name);
					var dependencyTypeCategoryId = record.GetTypedColumnValue<Guid>(dependencyTypeCategoryColumn.Name + "Id");
					element.TypeName = categoryId == dependencyTypeCategoryId
						? record.GetTypedColumnValue<string>(dependencyTypeNameColumn.Name)
						: record.GetTypedColumnValue<string>(dependencyTypeReverseNameColumn.Name);
					if (IsDiagramForService) {
						element.ConfItemStatusId = record.GetTypedColumnValue<Guid>(confItemStatusColumnName + "Id");
						element.ConfItemCategoryId = record.GetTypedColumnValue<Guid>(confItemCategoryColumnName + "Id");
						element.ConfItemTypeId = record.GetTypedColumnValue<Guid>(confItemTypeColumnName + "Id");
						element.ConfItemModelId = record.GetTypedColumnValue<Guid>(confItemModelColumnName + "Id");
					}
					SaveSelectedServiceModelElements(element.Id, !element.IsDiagramForService);
					relationElements.Add(element);
				}
				return relationElements;
			}

			/// <summary>
			/// ######## ###### ######### ######### ########-######### ######.
			/// </summary>
			/// <param name="categoryId">############# ######### ########### ########.</param>
			/// <param name="searchRelationItems">###### #########, ## ####### ######### ##### ######.</param>
			/// <returns>###### ######### ######### ########-######### ######.</returns>
			private List<ElementInfo> GetRelationItems(Guid categoryId, IList<object> searchRelationItems) {
				var viewName = IsDiagramForService ? ServiceRelationshipViewName : ConfItemRelationshipViewName;
				var schemaName = IsDiagramForService ? ServiceItemSchemaName : ConfItemSchemaName;
				var elementsEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, viewName);
				var elementIdColumnName = IsDiagramForService ? "ServiceItemB" : "ConfItemB";
				var elementIdColumn = elementsEsq.AddColumn(elementIdColumnName);
				var elementNameColumn = elementsEsq.AddColumn(elementIdColumnName + ".Name");
				var isActiveAtributeName = IsDiagramForService ? "Active" : "IsFinal";
				var isActiveElementColumn = elementsEsq.AddColumn(string.Format("{0}.Status.Active", elementIdColumnName));
				var dependencyTypeNameColumn = elementsEsq.AddColumn("DependencyType.Name");
				var dependencyTypeReverseNameColumn = elementsEsq.AddColumn("DependencyType.ReverseTypeName");
				var dependencyTypeCategoryColumn = elementsEsq.AddColumn("DependencyType.DependencyCategory");
				var confItemStatusColumnName = string.Empty;
				var confItemCategoryColumnName = string.Empty;
				var confItemTypeColumnName = string.Empty;
				var confItemModelColumnName = string.Empty; 
				if (!IsDiagramForService) {
					confItemStatusColumnName = elementsEsq.AddColumn(elementIdColumnName + ".Status").Name;
					confItemCategoryColumnName = elementsEsq.AddColumn(elementIdColumnName + ".Category").Name;
					confItemTypeColumnName = elementsEsq.AddColumn(elementIdColumnName + ".Type").Name;
					confItemModelColumnName = elementsEsq.AddColumn(elementIdColumnName + ".Model").Name;
				}
				var filterColumnName = IsDiagramForService ? "ServiceItemA" : "ConfItemA";
				elementsEsq.Filters.Add(elementsEsq.CreateFilterWithParameters(FilterComparisonType.Equal, 
					filterColumnName, Id));
				elementsEsq.Filters.Add(elementsEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
					DependencyCategoryColumnName, categoryId));
				var relationElements = new List<ElementInfo>();
				if (searchRelationItems != null) {
					if (searchRelationItems.Count == 0) {
						return relationElements; 
					}
					var searchRelationItemsColumnName = IsDiagramForService ? "ServiceItemB" : "ConfItemB";
					elementsEsq.Filters.Add(elementsEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
						searchRelationItemsColumnName, searchRelationItems.ToArray()));
				}
				var elementCollection = elementsEsq.GetEntityCollection(UserConnection);
				foreach (var record in elementCollection) {
					var id = record.GetTypedColumnValue<Guid>(elementIdColumn.Name + "Id");
					var element = new ElementInfo(EntitySchemaName, id) {
						Name = record.GetTypedColumnValue<string>(elementNameColumn.Name),
						CategoryId = categoryId
					};
					element.IsActive = record.GetTypedColumnValue<bool>(isActiveElementColumn.Name);
					var dependencyTypeCategoryId = record.GetTypedColumnValue<Guid>(dependencyTypeCategoryColumn.Name + "Id");
					element.TypeName = categoryId == dependencyTypeCategoryId
						? record.GetTypedColumnValue<string>(dependencyTypeNameColumn.Name)
						: record.GetTypedColumnValue<string>(dependencyTypeReverseNameColumn.Name);
					if (!IsDiagramForService) {
						element.ConfItemStatusId = record.GetTypedColumnValue<Guid>(confItemStatusColumnName + "Id");
						element.ConfItemCategoryId = record.GetTypedColumnValue<Guid>(confItemCategoryColumnName + "Id");
						element.ConfItemTypeId = record.GetTypedColumnValue<Guid>(confItemTypeColumnName + "Id");
						element.ConfItemModelId = record.GetTypedColumnValue<Guid>(confItemModelColumnName + "Id");
					}
					SaveSelectedServiceModelElements(element.Id, !element.IsDiagramForService);
					relationElements.Add(element);
				}
				return relationElements;
			}

			/// <summary>
			/// ######## ###### ######### ########-######### ######.
			/// </summary>
			/// <param name="categoryId">############# ######### ########### ########.</param>
			/// <returns>###### ######### ######### ########-######### ######.</returns>
			private List<ElementInfo> GetServiceModelElements(Guid categoryId, 
				IList<object> forServiceItems, IList<object> forConfItems) {
				var elements = new List<ElementInfo>();
				var relationItems = IsDiagramForService ? forServiceItems : forConfItems;
				var serviceInConfItemItems = IsDiagramForService ? forConfItems : forServiceItems;
				elements.AddRange(GetRelationItems(categoryId, relationItems));
				elements.AddRange(GetServiceInConfItemItems(categoryId, serviceInConfItemItems));
				return elements;
			}

			/// <summary>
			/// ######### ####### ####### ########-######### ###### 
			/// </summary>
			/// <param name="elementId">############# ######## ########</param>
			/// <param name="IsMainElementService">####### ####, ### ####### ######## #########</param>
			private void SaveSelectedServiceModelElements(Guid elementId, bool IsMainElementService) {
				if (IsMainElementService) {
					ConfItems.Add(elementId);
					return;
				}
				ServiceItems.Add(elementId);
			}

			#endregion

			#region Methods: Public

			/// <summary>
			/// ######## ########## # ########-######### ###### ########## ########.
			/// </summary>
			/// <param name="entityName">######## ##### ########.</param>
			/// <param name="elementId">############# ########.</param>
			/// <returns>########## # ########-######### ###### ########## ########.</returns>
			public static ElementInfo GetServiceModelElementDiagram(string entityName, Guid elementId) {
				return GetServiceModelElementDiagram(UserConnection, entityName, elementId);
			}

			/// <summary>
			/// ######## ########## ### ########### ########-######### ######.
			/// </summary>
			/// <param name="userConnection">################ ###########.</param>
			/// <param name="entityName">######## ##### ########.</param>
			/// <param name="elementId">############# ########.</param>
			/// <returns>########## # ########-######### ###### ########## ########.</returns>
			public static ElementInfo GetServiceModelElementDiagram(UserConnection userConnection, string entityName, 
				Guid elementId) {
				_userConnection = userConnection;
				var element = new ElementInfo(entityName, elementId);
				element.FillInfo();
				element.FillRelationsInfo();
				foreach (var item in element.DependenceElements.Concat(element.InfluenceElements)) {
					item.FillRelationsInfo(element.ServiceItems, element.ConfItems);
				}
				return element;
			}

			/// <summary>
			/// ######### ########## # ############ ######## ########.
			/// </summary>
			/// <param name="forServiceItems">###### ########, ## ####### ######### ##########.</param>
			/// <param name="forConfItems">###### ####.######, ## ####### ######### ##########.</param>
			/// <remarks>
			/// #### ###### #########, ## ####### ########### ##### ##### ####, ## ##### ########### ## #### #########
			/// </remarks
			public void FillRelationsInfo(IList<object> forServiceItems = null, IList<object> forConfItems = null) {
				DependenceElements = GetServiceModelElements(DependenceCategoryId, forServiceItems, forConfItems);
				InfluenceElements = GetServiceModelElements(InfluenceCategoryId, forServiceItems, forConfItems);
			}

			#endregion

		}

		#endregion

	}
}

