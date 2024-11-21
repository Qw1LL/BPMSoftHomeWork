namespace BPMSoft.Configuration
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Reflection;
    using Core.Entities;
    using Core.DB;
    using BPMSoft.Configuration.DaDataSuggestions;
    using BPMSoft.Core.ServiceModelContract;
    using BPMSoft.Web.Common;
    using BPMSoft.DaDataSuggestions;

    #region Class: DaDataSuggestionsService

    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class DaDataSuggestionsService : BaseService
    {
        #region Constants: Private

        private const string DaDataAPIKeyName="DaDataAPIKey";
        private const string accountSchemaName="Account";
		private const string AccountEnrichedDataSchemaName = "AccountEnrichedData";
        private const string AccountEnrichmentServiceSchemaName = "AccountEnrichmentService";
        private const string DaDataSuggestionsServiceName = "DaDataSuggestionsService";
        
        private Guid _daDataSuggestionsServiceId = Guid.Empty;

        #endregion
		
		#region Fields: Private
		
		private string fieldCodeColumnName = "DaDataSuggestionsField_Code";
		private string entityColumnNameColumnName = "EntityColumnName";
		
		#endregion

        #region Methods: Private

        private ValueResponse<T> CreateErrorResponse<T>(Exception exception) where T:DaDataSuggestionsResponse 
            => new ValueResponse<T>() {
                    Success = false,
                    ErrorInfo = new ErrorInfo()
                    {
                        ErrorCode = "400",
                        Message = exception.Message,
                        StackTrace = exception.StackTrace
                    }
                };


        private async Task<ValueResponse<T>> ExecuteDaData<T>(string query, 
            Func<string,DaDataSuggestionsClient,Task<T>> clientMethod) where T : DaDataSuggestionsResponse 
        {
            var userConnection = this.UserConnection;
            var helper = new DaDataSuggestionsHelper(userConnection);
            var response = helper.GetCachedSuggestionsResponse<T>(query);    
            if (response != null)
            {
                return new ValueResponse<T>()
                {
                    Value = response
                };
            }
            var apiKey = (string)Core.Configuration.SysSettings.GetValue(userConnection, DaDataAPIKeyName);
            var daDataSuggestionsClient = new DaDataSuggestionsClient(apiKey);
            response = await clientMethod(query,daDataSuggestionsClient);
            string methodName = nameof(clientMethod);
            helper.SetCachedSuggestionsResponse(response, methodName + query);
            return new ValueResponse<T>() { Value = response    };
        }

        private string SetupAccountName(Guid accountId) {
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName("Account");
			var esq = new EntitySchemaQuery(schema);
			var accountColumn = esq.AddColumn("Name");
			var accountIdFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", accountId);
			esq.Filters.Add(accountIdFilter);
			var list = esq.GetEntityCollection(UserConnection);
			string accountName = string.Empty;
			foreach (var item in list) {
				if (string.IsNullOrEmpty(accountName)) {
					accountName = item.GetTypedColumnValue<string>(accountColumn.Name);
				}
			}
			return accountName;
		}

        private AccountSuggestion GetAccountSuggestionByQuery(AccountSuggestion[] suggestions, string query, bool setFirstIfNotFound){
            AccountSuggestion accountSuggestion = setFirstIfNotFound ? suggestions[0] : null;
            foreach (var suggestion in suggestions){
                if(suggestion.Value == query){
                    accountSuggestion = suggestion;
                    break;
                }
            }
            return accountSuggestion;
        }

        private void getDaDataSuggestionsSettings(AccountSuggestion accountSuggestion, Guid accountId){
            var schema = UserConnection.EntitySchemaManager.GetInstanceByName("DaDataSuggestionsSettings");
			var esq = new EntitySchemaQuery(schema);
            var entityColumnNameColumn = esq.AddColumn("EntityColumnName");
			var fieldCodeColumn = esq.AddColumn("DaDataSuggestionsField.Code");
            var activeFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsActive", true);
            esq.Filters.Add(activeFilter);
            var sysEntitySchemaFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DaDataSuggestionsEntity.EntitySchemaName", accountSchemaName);
            esq.Filters.Add(sysEntitySchemaFilter);
            EntityCollection daDataSettings = esq.GetEntityCollection(UserConnection);
			
			fieldCodeColumnName = fieldCodeColumn.Name;
			entityColumnNameColumnName = entityColumnNameColumn.Name;
			
            UpdateEnrichedData(accountId, accountSuggestion, daDataSettings);
        }

        private void ClearPreviousSearchData(Guid accountId) {
			var delete = (new Delete(UserConnection)
				.From(AccountEnrichedDataSchemaName)
				.Where("AccountId").IsEqual(Column.Parameter(accountId))
                .And("AccountEnrichmentServiceId").IsEqual(Column.Parameter(_daDataSuggestionsServiceId))) as Delete;
			delete.Execute();
		}

		private void UpdateEnrichedData(Guid accountId, AccountSuggestion accountSuggestion, EntityCollection daDataSettings) {
            InsertRowInEntity(accountId, "Name", accountSuggestion.Value);
            setAdditionalProperties(accountId, daDataSettings, accountSuggestion);
		}

        private void setAdditionalProperties(Guid accountId, EntityCollection daDataSettings, AccountSuggestion accountSuggestion){
            foreach(var item in daDataSettings){
				string key = item.GetTypedColumnValue<string>(fieldCodeColumnName); 
				string entityName = item.GetTypedColumnValue<string>(entityColumnNameColumnName); 
                object currentObject = accountSuggestion.Data;
                string[] pathToProperty = key.Split('_');
                for(int i = 0; i < pathToProperty.Length; i++){
                    string currentPart = pathToProperty[i];
                    bool isNumeric = int.TryParse(currentPart, out _);
                    if(!isNumeric){
                        currentPart = Char.ToUpper(currentPart[0]) + currentPart.Remove(0, 1);
                        var property = currentObject.GetType().GetProperty(currentPart);
                        while(property == null && ++i < pathToProperty.Length){
							currentPart += Char.ToUpper(pathToProperty[i][0]) + pathToProperty[i].Remove(0, 1);
							property = currentObject.GetType().GetProperty(currentPart);
                        }
                        currentObject = getNextProp(property, currentObject);
                    } else {
                        var array = ((object[])currentObject);
                        for(int j = 0; j < array.Length; j++){
                            int index = i + 1;
							if(index < pathToProperty.Length){
								currentPart = pathToProperty[index];
								var resultProp = getNextPropInArray(currentPart, array[j], pathToProperty, index);
								InsertRowInEntity(accountId, entityName, resultProp);
							}
                        }
                        currentObject = null;
                    }
                    if(currentObject == null){
                        i = pathToProperty.Length;
                    }
                }
                if(currentObject != null){
                    InsertRowInEntity(accountId, entityName, (string)currentObject);
                }
            }
        }

        private string getNextPropInArray(string currentPart, object currentObject, string[] pathToProperty, int i){
            currentPart = Char.ToUpper(currentPart[0]) + currentPart.Remove(0, 1);
            var property = currentObject.GetType().GetProperty(currentPart);
            while(property == null && ++i < pathToProperty.Length){
                currentPart += Char.ToUpper(pathToProperty[i][0]) + pathToProperty[i].Remove(0, 1);
                property = currentObject.GetType().GetProperty(currentPart);
            }
            var prop = getNextProp(property, currentObject);
            if(++i < pathToProperty.Length){
                currentPart = pathToProperty[i];
                return getNextPropInArray(currentPart, prop, pathToProperty, i);
            } else {
                return (string)prop;
            }
        }

        private object getNextProp(PropertyInfo property, object currentObject){
            
            if(property != null){
                return currentObject = property.GetValue(currentObject, null);
            }
            return null;
        }

        private void InsertRowInEntity(Guid accountId, string type, string value){
            EntitySchema enrichedSchema =
                UserConnection.EntitySchemaManager.GetInstanceByName(AccountEnrichedDataSchemaName);
            Entity entity = enrichedSchema.CreateEntity(UserConnection);
            DateTime date = UserConnection.CurrentUser.GetCurrentDateTime();
            entity.SetDefColumnValues();
            entity.SetColumnValue("SearchDate", date);
            entity.SetColumnValue("CategoryTag", type);
            entity.SetColumnValue("Value", value);
            entity.SetColumnValue("AccountId", accountId);
            entity.SetColumnValue("AccountEnrichmentServiceId", _daDataSuggestionsServiceId);
            entity.Save();
        }

        private void SetDaDataServiceId(){
            var schema = UserConnection.EntitySchemaManager.GetInstanceByName(AccountEnrichmentServiceSchemaName);
			var esq = new EntitySchemaQuery(schema);
			var idColumn = esq.AddColumn("Id");
			var accountIdFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Name", DaDataSuggestionsServiceName);
			esq.Filters.Add(accountIdFilter);
			var entity = esq.GetEntityCollection(UserConnection);
			_daDataSuggestionsServiceId = new Guid(entity[0].GetTypedColumnValue<string>(idColumn.Name));
        }

        #endregion

        #region Methods: Public
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public async Task<ValueResponse<DaDataSuggestionsAccountResponse>> GetFullAccountSuggestionsList(string inn)
        {
            try
            {
                return await ExecuteDaData(inn, (str,client)=>client.GetAccountDataByFilter(str));
            }
            catch (Exception e)
            {
                return CreateErrorResponse<DaDataSuggestionsAccountResponse>(e);
            }
        }

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public async Task<ValueResponse<DaDataSuggestionsAccountResponse>> GetAccountSuggestionsList(
            string query)
        {
            try
            {
                return await ExecuteDaData(query, (str,client)=>client.GetAccountData(str));
            }
            catch (Exception e)
            {
                return CreateErrorResponse<DaDataSuggestionsAccountResponse>(e);
            }
        }

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public async Task<ValueResponse<DaDataSuggestionsAddressResponse>> GetAddressSuggestionsList(
            string query, int count = 0)
        {
            try
            {
                return await ExecuteDaData(query, (str,client)=>client.GetAddressData(str,count));
            }
            catch (Exception e)
            {
                return CreateErrorResponse<DaDataSuggestionsAddressResponse>(e);
            }
        }

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public bool IsDaDataAPIKeyEmpty()
        {
            var userConnection = this.UserConnection;
            var apiKey = (string)Core.Configuration.SysSettings.GetValue(userConnection, DaDataAPIKeyName);
            return String.IsNullOrEmpty(apiKey);
        }

        [OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public async Task<SearchAccountInfoResult> SearchAccountInfo(Guid accountId) {
            if(_daDataSuggestionsServiceId == Guid.Empty){
                SetDaDataServiceId();
            }
            ClearPreviousSearchData(accountId);
			string query = SetupAccountName(accountId);
            var enrichmentList = await GetAccountSuggestionsList(query);
            if(!enrichmentList.Success){
                return new SearchAccountInfoResult {IsSuccessSearch = false, Success = false};
            }
            var suggestions = enrichmentList.Value.Suggestions;
            if(suggestions.Length == 0){
                return new SearchAccountInfoResult {IsSuccessSearch = false, Success = true};
            }
            var accountSuggestion = GetAccountSuggestionByQuery(suggestions, query, true);
            string inn = accountSuggestion.Data.Inn;
            enrichmentList = await GetFullAccountSuggestionsList(inn);
            suggestions = enrichmentList.Value.Suggestions;
            AccountSuggestion tempAccountSuggestion = GetAccountSuggestionByQuery(suggestions, query, false);
            if(tempAccountSuggestion != null){
                accountSuggestion = tempAccountSuggestion;
            }
            getDaDataSuggestionsSettings(accountSuggestion, accountId);
            return new SearchAccountInfoResult {IsSuccessSearch = true, Success = true};
		}

        #endregion

    }

    #endregion

    #region Class: SearchAccountInfoResult

	/// <summary>
	/// Represents response of company autocomplete service.
	/// </summary>
	public class SearchAccountInfoResult
	{

		#region Properties: Public

		/// <summary>
		/// Returns true if any new information where found.
		/// </summary>
		public bool Success {
			get;
			set;
		}

		/// <summary>
		/// Returns true if enrichment is impossible due to lack of data.
		/// </summary>
		public bool IsSuccessSearch {
			get;
			set;
		}

		#endregion

	}

	#endregion

}
