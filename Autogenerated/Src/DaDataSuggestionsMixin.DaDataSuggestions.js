define("DaDataSuggestionsMixin", ["ServiceHelper", "SearchableTextEdit", "css!SuggestionsListCSS"],
	function(ServiceHelper) {
		Ext.define("BPMSoft.configuration.mixins.DaDataSuggestionsMixin", {
			alternateClassName: "BPMSoft.DaDataSuggestionsMixin",
			
			/**
			 * Наполняет объект свойствами из подсказок.
			 * @param {Object} entity Объект, наполняемый свойствами.
			 * @param {Object} suggestion Подсказка из DaData.
			 * @param {String} parentPropertyName Имя корневого свойства.
			 */
			setSuggestionProperties: function(entity, suggestion, parentPropertyName) {
				for (let key in suggestion) {
					let suggestionKey = suggestion[key];
					if (typeof suggestionKey === "object") {
						let propertyName = (parentPropertyName && parentPropertyName !== "")
							? Ext.String.format("{0}.{1}", parentPropertyName, key)
							: key;
						this.setSuggestionProperties(entity, suggestionKey, propertyName);
					} else {
						let resultName = (parentPropertyName && parentPropertyName !== "")
							? Ext.String.format("{0}.{1}", parentPropertyName, key)
							: key;

						resultName = resultName.replace(/[.]/g, "_");
						entity[resultName] = suggestionKey;						
					}
				}
			},

			checkAutoCompleteSettingSet: function(callback){
				BPMSoft.SysSettings.querySysSettings([
					"EnableAutoCompleteDaData"
				],
				function({EnableAutoCompleteDaData}) {
					callback.call(this, EnableAutoCompleteDaData)
				})
			},

			/**
			 * Checks required system settings for suggest feature.
			 * @private
			 * @param {Function} callback The callback function.
			 */
			checkRequiredSysSettingsSet: function(callback) {
				this.callService({
					serviceName: "DaDataSuggestionsService",
					methodName: "IsDaDataAPIKeyEmpty",
					data: {
					},
					timeout: 120000
				}, function({IsDaDataAPIKeyEmptyResult}){
					callback.call(this, IsDaDataAPIKeyEmptyResult);
				})
			},
			
			/**
			 * Инициализирует настройки подсказок DaData.
			 * @param {String} entitySchemaName Имя схемы объекта.
			 */
			initDaDataSuggestionsSettings: function(entitySchemaName) {
				let esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "DaDataSuggestionsSettings"
				});
				esq.addColumn("DaDataSuggestionsField.Code", "DaDataSuggestionsFieldCode");
				esq.addColumn("DaDataSuggestionsField.Name", "DaDataSuggestionsFieldName");
				esq.addColumn("EntityColumnName");
				esq.filters.add("SysEntitySchemaFilter", esq.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "DaDataSuggestionsEntity.EntitySchemaName", entitySchemaName));
				esq.filters.add("ActiveFilter", esq.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "IsActive", true));
				esq.getEntityCollection(function (result) {
					if (result.success) {
						let suggestionsSettings = [];
						result.collection.each(function(item) {
							suggestionsSettings.push(item.values);
						});
						
						this.set("DaDataSuggestionsSettings", suggestionsSettings);
					}
				}, this);
			},

			callGetAccountSuggestionsFullList: function(entity, callback){
				this.callService({
					serviceName: "DaDataSuggestionsService",
					methodName: "GetFullAccountSuggestionsList",
					data: {
						"inn": entity.inn
					},
					timeout: 120000
				}, function(response){
					if(response){
						let responseData = response.GetFullAccountSuggestionsListResult.value.suggestions;
						responseData.forEach((suggestion) => {
							if(suggestion.value === entity.name){
								entity = this.getNewAccount(0, suggestion)
							}
						});
						callback(entity);
					}
				})
			},

			saveAddressToDatabase: function() {
				let mainAddress = this.get("MainAddress");
				if(Object.keys(mainAddress).length){
					if(this.get("InsertAccountAddressOnSave") || this.get("AddressWasForcedToInsert")){
						var insert = this.getInsertAddressQuery(mainAddress);
						insert.execute(function(){
							this.onDaDataSuggestionResultSaved()
						}, this); 
					} else {
						let update = this.getUpdateAddressQuery(mainAddress);
						update.execute(function(){
							this.onDaDataSuggestionResultSaved()
						}, this);
					}
				} else {
					this.onDaDataSuggestionResultSaved()
				}
				this.set("MainAddress", {})
				this.set("AddressWasForcedToInsert", false)
			},

			getUpdateAddressQuery: function(item){
				var update = Ext.create("BPMSoft.UpdateQuery", { rootSchemaName: "AccountAddress" });
				update.filters.add("AddressIdFilter", 
					update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Id", item.Id)
				);
				update.setParameterValue("Country", item.Country?.value, BPMSoft.DataValueType.GUID);
				update.setParameterValue("Region", item.Region?.value, BPMSoft.DataValueType.GUID);
				update.setParameterValue("City", item.City?.value, BPMSoft.DataValueType.GUID);
				update.setParameterValue("Address", item.Address, BPMSoft.DataValueType.TEXT);
				update.setParameterValue("Zip", item.Zip, BPMSoft.DataValueType.TEXT);
				update.setParameterValue("Account", this.get("Id"), BPMSoft.DataValueType.GUID);
				update.setParameterValue("GPSN", item.GPSN, BPMSoft.DataValueType.TEXT);
				update.setParameterValue("GPSE", item.GPSE, BPMSoft.DataValueType.TEXT);
				return update;
			},

			getInsertAddressQuery: function(item) {
				var insert = this.Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "AccountAddress"
				});
				insert.setParameterValue("Id", item.Id, BPMSoft.DataValueType.GUID);
				insert.setParameterValue("AddressType", item.AddressType.value, BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Country", item.Country?.value, BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Region", item.Region?.value, BPMSoft.DataValueType.GUID);
				insert.setParameterValue("City", item.City?.value, BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Address", item.Address, BPMSoft.DataValueType.TEXT);
				insert.setParameterValue("Zip", item.Zip, BPMSoft.DataValueType.TEXT);
				insert.setParameterValue("Primary", item.Primary, BPMSoft.DataValueType.BOOLEAN);
				insert.setParameterValue("Account", this.get("Id"), BPMSoft.DataValueType.GUID);
				insert.setParameterValue("ProcessListeners", 0, BPMSoft.DataValueType.INTEGER);
				insert.setParameterValue("GPSN", item.GPSN, BPMSoft.DataValueType.TEXT);
				insert.setParameterValue("GPSE", item.GPSE, BPMSoft.DataValueType.TEXT);
				return insert;
			},

			setExtraFields: function(entity){
				this.set("MainAddress", {});
				this.set("InsertAccountAddressOnSave", true)
				let detailColumnMapping = this.get("AddressDetailColumnMapping");
				let newAddressRow = detailColumnMapping ? this.addNewAddressRow() : null;
				let suggestionsSettings = this.get("DaDataSuggestionsSettings");
				
				suggestionsSettings.forEach(function(item, i) {						
					let column = this.columns[item.EntityColumnName];
					if (column) {
						let addressMap = BPMSoft.findWhere(detailColumnMapping, {TagName: item.EntityColumnName});
						if(newAddressRow && addressMap) {
							if(addressMap){
								newAddressRow[item.EntityColumnName] = entity[item.DaDataSuggestionsFieldCode];
							}
						} else {
							if (column.dataValueType === BPMSoft.DataValueType.DATE || column.dataValueType === BPMSoft.DataValueType.DATE_TIME) {							
								let milliseconds = Number.parseInt(entity[item.DaDataSuggestionsFieldCode]);
								let date = milliseconds
									? new Date(milliseconds)
									: null;
								this.set(item.EntityColumnName, date);
							} else if (column.isLookup) {
								this.setLookupValueByName(
									entity[item.DaDataSuggestionsFieldCode], column.referenceSchemaName, item.EntityColumnName);
							} else {
								this.set(item.EntityColumnName, entity[item.DaDataSuggestionsFieldCode]);
							}
						}
					} else {
						this.set(item.EntityColumnName, entity[item.DaDataSuggestionsFieldCode]);
					}
				}, this);

				this.afterEntitySet();
				if(newAddressRow){
					this.setLookupsConfig(newAddressRow, function(){
						this.selectPrimaryAddress(newAddressRow);
					})
				}
			},

			setNewMainAddress: function(newAddress) {
				if(newAddress){
					this.set("MainAddress", newAddress)
				} 
			},

			selectPrimaryAddress: function(newAddressRow, forceToInsert){
				if(forceToInsert){
					this.sandbox.publish("UpdateAddressRow", [newAddressRow, null, forceToInsert])
					this.set("AddressWasForcedToInsert", true);
					return;
				}
				let esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "AccountAddress"
				});
				esq.addColumn("Id")
				esq.filters.add("AccountFilter", esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Account", this.get("Id")));
				esq.filters.add("PrimaryFilter", esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Primary", true));
				esq.getEntityCollection(function(response){
					let id = null;
					if (response && response.success && !response.collection.isEmpty()) {
						let result = response.collection.first();
						id = result.get("Id");
						this.set("InsertAccountAddressOnSave", false)
					}
					if(id){
						newAddressRow.Id = id;
					}
					forceToInsert = this.get("AddressWasForcedToInsert")
					if(forceToInsert){
						id = 1;
					}
					this.sandbox.publish("UpdateAddressRow", [newAddressRow, id, forceToInsert])
				}, this)
			},

			getLookupValueByName: function(name, rootSchemaName, lookupColumnName, callback) {
				if (name) {
					let esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: rootSchemaName
					});
					esq.addColumn("Id");
					esq.filters.add("NameFilter", esq.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.START_WITH, "Name", name));
					esq.getEntityCollection(function(response) {
						if (response && response.success && !response.collection.isEmpty()) {
							let result = response.collection.first();
							let id = result.get("Id");
							callback.call(this, id);
						} else {
							callback.call(this, null);
						}
					}, this);
				} else {
					callback.call(this, null);
				}
			},

			setLookupsConfig: function(newAddressRow, callback, currentKey) {
				let keys = Object.keys(newAddressRow);
				if(!currentKey){
					this.setLookupsConfig(newAddressRow, callback, keys[0]);
					return;
				}
				let detailColumnMapping = this.get("AddressDetailColumnMapping");
				let addressMap = BPMSoft.findWhere(detailColumnMapping, {TagName: currentKey});
				if(!addressMap){
					this.checkIndex(newAddressRow, callback, currentKey);
					return;
				}
				if(addressMap.isLookup){
					let column = this.columns[currentKey]
					this.getLookupValueByName(newAddressRow[currentKey], column.referenceSchemaName, currentKey, function(lookupValue){
						if(lookupValue){
							newAddressRow[currentKey] = this.getLookupConfig(lookupValue, newAddressRow[currentKey]);
						} else {
							newAddressRow[currentKey] = null;
						}
						this.checkIndex(newAddressRow, callback, currentKey);
					}, this)
					return;
				}
				this.checkIndex(newAddressRow, callback, currentKey);
			},

			checkIndex: function(newAddressRow, callback, currentKey) {
				let keys = Object.keys(newAddressRow);
				let currentIndex = keys.indexOf(currentKey);
				if(currentIndex !== keys.length - 1){
					currentKey = keys[currentIndex + 1];
					this.setLookupsConfig(newAddressRow, callback, currentKey)
				} else {
					callback.call(this);
				}
			},

			getLookupConfig: function(lookupValue, displayValue){
				return {
					value: lookupValue,
					displayValue: displayValue,
					primaryImageValue: ''
				}
			},

			addNewAddressRow: Ext.emptyFn,

			setFullEntity: function(entity){
				let name = entity.name;
				if (!name) name = entity.name_short;
				if (!name) name = entity.name_full;						
					
				this.set(this.get("DaDataDisplayColumnName"), name);

				if(this.entitySchemaName === "Account"){
					this.checkAutoCompleteSettingSet((autocompleteSettingResponse) => {
						if(autocompleteSettingResponse){
							this.setExtraFields(entity);
						}
					})
				} else {
					this.setExtraFields(entity);
				}
			},

			afterEntitySet: function(){
				this.updateSearchLines();
				this.setAdditionalFields();
			},
			
			/**
			 * Обновляет значения колонок, связанных с поисковыми строками.
			 * @param {Object} customEntity Пользовательский объект.
			 * @param {String} columnName Название колонки, на которую сработал метод.
			 */
			updateRelatedColumns: function(customEntity, columnName) {
				let displayValue = (customEntity && customEntity.displayValue)
					? customEntity.displayValue
					: "";
				
				if (columnName === "DaDataSearchLine") {
					this.set(this.get("DaDataDisplayColumnName"), displayValue);
				}
			},
			
			/**
			 * Обновляет значения поисковых строк.
			 */
			updateSearchLines: function() {
				let daDataDisplayValue = !Ext.isEmpty(this.get(this.get("DaDataDisplayColumnName")))
					? this.get(this.get("DaDataDisplayColumnName"))
					: "";
				
				this.set("DaDataSearchLine", daDataDisplayValue);
			},
			
			setDaDataSuggestions: function (suggestions, getNewSuggestion) {
				const list = this.get("DaDataSuggestions");
				list.clear();
				if (suggestions) {
					let daDataSuggestions = [];
					suggestions.forEach(function(item, i) {
						daDataSuggestions[i] = getNewSuggestion.call(this, i, item);
					}, this);
					const itemList = {};
					BPMSoft.each(daDataSuggestions, function(suggestion) {
						itemList[suggestion.value] = {
							value: suggestion.value,
							markerValue: "suggestions-list-item",
							displayValue: suggestion.name,
							data: suggestion,
							customHtml: suggestion.customHtml,
						};
					}, this);
					list.loadAll(itemList);
				}
			},
			
			/**
			 * Возвращает сформированную модель подсказки по орагнизации.
			 * @param {Object} accountData Данные подсказки по орагнизации.
			 * @return {Object} Модель подсказки подсказки по орагнизации.
			 */
			getNewAccount: function (index, accountData, scope) {
				let displayValue = "";
				let name = "";
				let inn = "";
				let address = "";
				
				let suggestion = accountData.data;
				if (accountData.value) {
					name = accountData.value;
					displayValue += accountData.value;
				}
				if (suggestion.inn) {
					inn = suggestion.inn;
					displayValue += suggestion.inn;
				}
				
				if (suggestion.address && suggestion.address.value) {
					address = suggestion.address.value;
					displayValue += suggestion.address.value;
				}
				
				let customHtmlTemplate = "<div data-value=\"{0}\" style=\"line-height: 20px;margin: 3px 0;\">{1} {2}<br data-value=\"{0}\"><i data-value=\"{0}\">{3}</i></div>";
				
				let account = {
					displayValue: displayValue.trim(),
					customHtml: Ext.String.format(customHtmlTemplate, index, name, inn, address),
					name: accountData.value,
					address: address,
					value: index,
				};
				
				this.setSuggestionProperties(account, suggestion);
				
				return account;
			},
			
			/**
			 * Возвращает сформированную модель подсказки по адресу.
			 * @param {Integer} index Индекс записи.
			 * @param {Object} addressData Данные подсказки по адресу.
			 * @return {Object} Модель подсказки по адресу.
			 */
			getNewAddress: function (index, addressData) {
				let displayValue = "";
				let name = "";
				
				let suggestion = addressData.data;
				if (addressData.value) {
					name = addressData.value;
					displayValue += addressData.value;
				}
				
				let customHtmlTemplate = "<div style=\"line-height: 20px;margin: 3px 0;\">{0}</div>";
				
				let address = {
					value: index,
					displayValue: displayValue.trim(),
					customHtml: Ext.String.format(customHtmlTemplate, name),
					name: addressData.value
				};
				
				this.setSuggestionProperties(address, suggestion);
				
				return address;
			},
			
			/**
			 * Вызывает сервис получения подсказок по организациям из DaData.
			 * @param {String} filterValue Введенный фрагмент для поиска.
			 * @param {String} columnName Имя колонки, в которой производится ввод.
			 * @param {Function} callback Callback-функция.
			 */
			callDaDataAccountSuggestionsService: function(filterValue, columnName, callback) {
				let serviceConfig;
				if (columnName === "DaDataSearchLine" && filterValue !== "") {
					serviceConfig = {
						serviceName: "DaDataSuggestionsService",
						methodName: "GetAccountSuggestionsList",
						data: {
							"query":filterValue
						},
						callback: callback || this.getAccountSuggestionsListCallback,
						scope: this,
						timeout: 120000
					};
				}
				ServiceHelper.callService(serviceConfig);
			},
			
			/**
			 * Обработка ответа метода GetAccountSuggestionsList.
			 * @param {Object} response Ответ метода GetAccountSuggestionsList.
			 */
			getAccountSuggestionsListCallback: function(response) {
				if (response?.GetAccountSuggestionsListResult?.errorInfo?.stackTrace?.includes("License")) {
					return BPMSoft.showErrorMessage(
						response.GetAccountSuggestionsListResult.errorInfo.message);
				}
				
				if (response?.GetAccountSuggestionsListResult?.value?.suggestions) {
					return this.setDaDataSuggestions(
						response.GetAccountSuggestionsListResult.value.suggestions, this.getNewAccount);
				}
				
				console.error(response);
			},
			
			/**
			 * Вызывает сервис получения подсказок по адресам из DaData.
			 * @param {String} filterValue Введенный фрагмент для поиска.
			 * @param {String} columnName Имя колонки, в которой производится ввод.
			 * @param {Function} callback Callback-функция.
			 * @param {Integer} count Количество возвращаемых записей.
			 */
			callDaDataAddressSuggestionsService: function(filterValue, columnName, callback, count) {
				let serviceConfig;
				if (columnName === "DaDataSearchLine" && filterValue !== "") {
					serviceConfig = {
						serviceName: "DaDataSuggestionsService",
						methodName: "GetAddressSuggestionsList",
						data: {
							"query": filterValue,
							"count": count
						},
						callback: callback || this.getAddressSuggestionsListCallback,
						scope: this,
						timeout: 120000
					};
				}
				ServiceHelper.callService(serviceConfig);
			},
			
			/**
			 * Обработка ответа метода GetAddressSuggestionsList.
			 * @param {Object} response Ответ метода GetAddressSuggestionsList.
			 */
			getAddressSuggestionsListCallback: function(response) {
				if (response?.GetAddressSuggestionsListResult?.errorInfo?.stackTrace?.includes("License")) {
					return BPMSoft.showErrorMessage(
						response.GetAddressSuggestionsListResult.errorInfo.message);
				}
				
				if (response?.GetAddressSuggestionsListResult?.value?.suggestions) {
					return this.setDaDataSuggestions(
						response.GetAddressSuggestionsListResult.value.suggestions, this.getNewAddress);
				}
				
				console.error(response);
			},
			
			/**
			 * Устанавливает значение справочного поля по имени.
			 * @param {String} name Имя для поиска.
			 * @param {String} rootSchemaName Имя схемы объекта справочного поля.
			 * @param {String} lookupColumnName Имя справочного поля.
			 */
			setLookupValueByName: function(name, rootSchemaName, lookupColumnName) {
				if (name) {
					let esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: rootSchemaName
					});
					esq.addColumn("Id");
					esq.filters.add("NameFilter", esq.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.START_WITH, "Name", name));
					esq.getEntityCollection(function(response) {
						if (response && response.success && !response.collection.isEmpty()) {
							let result = response.collection.first();
							let id = result.get("Id");
							this.loadLookupDisplayValue(lookupColumnName, id);
						} else {
							this.set(lookupColumnName, null);
						}
					}, this);
				} else {
					this.set(lookupColumnName, null);
				}
			},

			/**
			 * Инициализирует настройки объектов. использующих подсказки.
			 */
			initDaDataSuggestionsEntity: function(entityName, callback, scope) {
				const daDataSuggestions = Ext.create("BPMSoft.Collection");
				this.set("DaDataSuggestions", daDataSuggestions);

				this.checkRequiredSysSettingsSet((notSet) => {
					if(notSet){
						Ext.callback(callback, scope, [false]);
					} else{
						let esq = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "DaDataSuggestionsEntity"
						});
						esq.addColumn("IsActive");
						esq.filters.add("EntitySchemaNameFilter", esq.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.EQUAL, "EntitySchemaName", entityName));
						esq.getEntityCollection(function(response) {
							if (response.success && response.collection.getCount() > 0) {
								let item = response.collection.getByIndex(0);
								let result = item.get("IsActive");
								Ext.callback(callback, scope, [result]);
							}
						}, this);
					}
				})
			},
			
			/**
			 * Выполняется после заполнения сущности значениями из выбранной подсказки.
			 * Может быть использована для заполнения доп. полей (например справочников).
			 */
			setAdditionalFields: Ext.emptyFn,

			/**
			 * Prepares suggestions list.
			 * @param {String} partialName Partial suggestion name for search.
			 * @param {BPMSoft.Collection} list Suggestions list.
			 */
			prepareSuggestionsExpandableList: function(partialName, list) {
				this.checkRequiredSysSettingsSet((notSet) => {
					if(notSet){
						list.clear();
						return;
					}
					if (!partialName) {
						list.clear();
						return;
					}
					if(!this.get("DaDataIsActive")){
						list.clear();
						return;
					}
					this.callDaDataService(partialName)
				})
			},

			callDaDataService: Ext.emptyFn,

			onSuggestionsListViewItemRender: function(item) {
				const tpl = [
					"<div class=\"listview-item suggestion-info\" data-value=\"{0}\">",
					"<div class=\"listview-item-info suggestion-info\" data-value=\"{0}\">{1}</div>",
					"</div>",
				].join("");
				item.customHtml = this.Ext.String.format(tpl, item.value, item.customHtml);
			},

			onSuggestionItemSelected: function(suggestionListItem) {
				let data = suggestionListItem.data;
				this.enrichData(data, (data) => {
					this.setFullEntity(data);
				})
			},
			enrichData: function(data, callback){
				callback(data);
			}
		});
	}
);