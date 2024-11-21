define('ColumnHelper', ['ext-base', 'BPMSoft', 'ColumnHelperResources'],
	function(Ext, BPMSoft, resources) {
	var Type = {
		STRING: {
			valueName: 'StringType',
			caption: resources.localizableStrings.StringTypeCaption,
			dataValueType: BPMSoft.DataValueType.TEXT,
			enumName: 'Strings',
			baseDataType: 'ShortText'
		},
		INTEGER: {
			caption: resources.localizableStrings.IntegerTypeCaption,
			dataValueType: BPMSoft.DataValueType.INTEGER,
			enumName: 'Numbers',
			baseDataType: 'Integer'
		},
		FLOAT: {
			valueName: 'FloatType',
			caption: resources.localizableStrings.FloatTypeCaption,
			dataValueType: BPMSoft.DataValueType.FLOAT,
			enumName: 'Numbers',
			baseDataType: 'Float2'
		},
		DATE: {
			valueName: 'DateType',
			caption: BPMSoft.data.constants.DataValueTypeConfig.DATE.displayValue,
			dataValueType: BPMSoft.DataValueType.DATE,
			enumName: 'Dates',
			baseDataType: 'Date'

		},
		LOOKUP: {
			caption: resources.localizableStrings.LookupTypeCaption,
			dataValueType: BPMSoft.DataValueType.LOOKUP,
			enumName: 'Dictionaries',
			baseDataType: 'Lookup'
		},
		BOOLEAN: {
			caption: resources.localizableStrings.BooleanTypeCaption,
			dataValueType: BPMSoft.DataValueType.BOOLEAN,
			enumName: 'Others',
			baseDataType: 'Boolean'
		}
	};
	function getTypeByDataValueType(dataValueType) {
		switch (dataValueType) {
			case BPMSoft.DataValueType.TEXT:
				return Type.STRING;
			case BPMSoft.DataValueType.INTEGER:
				return Type.INTEGER;
			case BPMSoft.DataValueType.FLOAT:
			case BPMSoft.DataValueType.MONEY:
				return Type.FLOAT;
			case BPMSoft.DataValueType.DATE:
			case BPMSoft.DataValueType.DATE_TIME:
			case BPMSoft.DataValueType.TIME:
				return Type.DATE;
			case BPMSoft.DataValueType.LOOKUP:
			case BPMSoft.DataValueType.ENUM:
				return Type.LOOKUP;
			case BPMSoft.DataValueType.BOOLEAN:
				return Type.BOOLEAN;
		}
	}

	function applyChange(entitySchemaId, changedColumns, callback, scope) {
		var ajaxProvider = BPMSoft.AjaxProvider;
		var collection = [];
		BPMSoft.each(changedColumns, function(item) {
			collection.push({
				Name: item.name,
				Caption: item.caption,
				TypeGroupName: item.baseDataTypeGroup,
				TypeName:  item.baseDataType,
				IsRequired: item.isRequired,
				IsNewLookup: (item.lookupType === 'New') || false,
				IsEnum: (item.dataValueType === BPMSoft.DataValueType.ENUM),
				IsMultiline: item.isMultiline || false,
				ReferenceSchemaName: item.referenceSchemaName,
				ReferenceSchemaCaption: item.referenceSchemaCaption
			});
		}, this);

		var dataSend = {
			entitySchemaId: entitySchemaId,
			changedColumns: collection
		};
		callServiceMethod.call(scope, ajaxProvider, 'ApplyChanges', function(responce) {
			callback.call(scope, responce.ApplyChangesResult);
		}, dataSend, 20 * 60 * 1000);
	}

	function callServiceMethod(ajaxProvider, methodName, callback, dataSend, timeout) {
		var data = dataSend || {};
		var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
		var requestUrl = workspaceBaseUrl + '/rest/ColumnService/' + methodName;
		var request = ajaxProvider.request({
			url: requestUrl,
			headers: {
				'Accept': 'application/json',
				'Content-Type': 'application/json'
			},
			method: 'POST',
			jsonData: data,
			callback: function(request, success, response) {
				var responseObject = {};
				if (success) {
					responseObject = BPMSoft.decode(response.responseText);
				}
				callback.call(this, responseObject);
			},
			scope: this,
			timeout: timeout
		});
		return request;
	}

	return {
		Resources: resources,
		Type: Type,
		ApplyChange: applyChange,
		GetTypeByDataValueType: getTypeByDataValueType

	};
});
