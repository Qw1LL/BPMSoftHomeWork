define("StorageUtilities", ["ext-base", "BPMSoft", "sandbox", "StorageUtilitiesResources"], function(Ext, BPMSoft) {
	var clearStorageModes = {
		ALL: "all",
		GROUP: "group",
		ITEM: "item",
		GROUP_ITEM: "groupItem"
	};

	var getESQResultByKey = function(config) {
		var result = BPMSoft.configuration.Storage[config.key];
		if (result) {
			config.callback.call(config.scope, result);
		} else {
			var setESQResultByKey = function(result) {
				BPMSoft.configuration.Storage[config.key] = result;
				config.callback.call(config.scope, result);
			};
			if (config.extraQuery) {
				config.extraQuery.query.getEntityCollection(function(result) {
					BPMSoft.configuration.Storage[config.extraQuery.key] = result;
					config.esq.getEntityCollection(setESQResultByKey);
				});
			} else {
				config.esq.getEntityCollection(setESQResultByKey);
			}
		}
	};

	function isFunction(functionToCheck) {
		var getType = {};
		return functionToCheck && getType.toString.call(functionToCheck) === "[object Function]";
	}
	function cloneResult(result) {
		var returnedResult = [];
		for (var i = 0; i < result.length; i++) {
			returnedResult.push(BPMSoft.deepClone(result[i]));
		}
		return returnedResult;
	}
	function workRequestWithStorage(storageKeyGenerator, requestFunction, callbackFunction, scope) {
		scope = scope || this;
		var storageKey = null;
		var groupName = null;
		if (isFunction(storageKeyGenerator)) {
			storageKey = storageKeyGenerator.apply(scope, Array.prototype.slice.call(arguments, 4));
		} else {
			storageKey = storageKeyGenerator;
		}
		if (Ext.isEmpty(storageKey)) {
			callbackFunction.call(scope, {});
			return;
		}
		if (storageKey.constructor === Object &&
			storageKey.hasOwnProperty("groupName") &&
			storageKey.hasOwnProperty("valueKey")) {
			groupName = storageKey.groupName;
			storageKey = storageKey.valueKey;
		}
		var result = {};
		if (!Ext.isEmpty(groupName)) {
			result = BPMSoft.configuration.Storage[groupName];
			if (!Ext.isEmpty(result)) {
				result = result[storageKey];
			}
		} else {
			result = BPMSoft.configuration.Storage[storageKey];
		}
		if (!Ext.isEmpty(result)) {
			callbackFunction.apply(scope, cloneResult(result));
		} else {
			const saveResultFunction = function(result, success) {
				if (success) {
					if (Ext.isEmpty(groupName)) {
						BPMSoft.configuration.Storage[storageKey] = arguments;
					} else {
						let group = BPMSoft.configuration.Storage[groupName];
						if (Ext.isEmpty(group)) {
							group = BPMSoft.configuration.Storage[groupName] = {};
						}
						group[storageKey] = arguments;
					}
				}
				callbackFunction.apply(scope, cloneResult(arguments));
			};
			const requestArguments = Array.prototype.slice.call(arguments, 4);
			requestArguments.unshift(saveResultFunction);
			requestFunction.apply(scope, requestArguments);
		}
		return storageKey;
	}
	function clearAllInStorage() {
		for (var storageValue in BPMSoft.configuration.Storage) {
			delete BPMSoft.configuration.Storage[storageValue];
		}
	}
	function clearItemInStorage(name) {
		if (BPMSoft.configuration.Storage.hasOwnProperty(name)) {
			delete BPMSoft.configuration.Storage[name];
		}
	}
	function clearGroupItemInStorage(groupName, itemName) {
		if (BPMSoft.configuration.Storage.hasOwnProperty(groupName) &&
			BPMSoft.configuration.Storage[groupName].hasOwnProperty(itemName)) {
			delete BPMSoft.configuration.Storage[groupName][itemName];
		}
	}
	function clearStorage(mod, groupName, itemName) {
		switch (mod) {
			case clearStorageModes.ALL:
				clearAllInStorage();
				return;
			case clearStorageModes.GROUP:
			case clearStorageModes.ITEM:
				clearItemInStorage(groupName);
				break;
			case clearStorageModes.GROUP_ITEM:
				clearGroupItemInStorage(groupName, itemName);
				break;
		}
	}

	function innerGetItem(groupName, itemName) {
		var group = (groupName && itemName)
			? BPMSoft.configuration.Storage[groupName] || {}
			: BPMSoft.configuration.Storage;
		var key = itemName || groupName;
		var item = group[key];
		return BPMSoft.deepClone(item);
	}

	function innerSetItem(item, groupName, itemName) {
		if (groupName && itemName) {
			var group = BPMSoft.configuration.Storage[groupName] || (BPMSoft.configuration.Storage[groupName] = {});
			group[itemName] = item;
		} else {
			var key = groupName || itemName;
			BPMSoft.configuration.Storage[key] = item;
		}
	}

	function innerDeleteItem(groupName, itemName) {
		if (groupName && itemName) {
			delete BPMSoft.configuration.Storage[groupName][itemName];
		} else {
			var key = groupName || itemName;
			delete BPMSoft.configuration.Storage[key];
		}
	}

	return {
		GetESQResultByKey: getESQResultByKey,
		workRequestWithStorage: workRequestWithStorage,
		ClearStorageModes: clearStorageModes,
		clearStorage: clearStorage,
		getItem: innerGetItem,
		setItem: innerSetItem,
		deleteItem: innerDeleteItem
	};
});
