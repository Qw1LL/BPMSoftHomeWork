﻿define('EditDetailViewGenerator', ['ext-base', 'BPMSoft', 'EditDetailViewGeneratorResources', 'CardViewGenerator',
		'StorageUtilities'], function(Ext, BPMSoft, resources, CardViewGenerator, StorageUtilities) {

	var entitySchema;

	function getFullViewModelSchema(sourceViewModelSchema, userCodes) {
		var viewModelSchema = BPMSoft.deepClone(sourceViewModelSchema);
		applyUserCode(viewModelSchema, userCodes);
		return viewModelSchema;
	}

	function applyUserCode(viewModelSchema, userCodes) {
		BPMSoft.each(userCodes, function(userCode) {
			userCode.call(viewModelSchema);
		});
	}

	function getContainerConfig(id) {
		return {
			className: 'BPMSoft.Container',
			items: [],
			id: id,
			selectors: {wrapEl: '#' + id}
		};
	}

	function getTypeItemConfig(typeColumnName, items) {
		BPMSoft.each(items, function(item) {
			item.click = {bindTo: 'typeChanged'};
		});
		return {
			className: 'BPMSoft.Button',
			classes: {
				wrapperClass: 'detail-type-btn-user-class',
				innerWrapperClass: 'detail-type-btn-inner-user-class'
			},
			style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
			caption: {
				bindTo: typeColumnName,
				bindConfig: {converter: BPMSoft.getTypedStringValue}
			},
			menu: {items: items}
		};
	}

	function getDeleteButtonConfig() {
		return {
			className: 'BPMSoft.Button',
			classes: {wrapperClass: 'detail-delete-btn-user-class'},
			imageConfig: resources.localizableImages.DeleteIcon,
			style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
			click: {bindTo: 'delete'}
		};
	}

	function generateItem(viewModelSchema, userCodes, parentId, action, typeCollection) {
		var containerPrefix = parentId || '';
		var container = getContainerConfig(containerPrefix + 'autoGeneratedContainer');
		var utilsConfig = getContainerConfig(containerPrefix + 'utils');
		if (action !== 'view') {
			if (viewModelSchema.typeColumn) {
				utilsConfig.items = [
					getTypeItemConfig(viewModelSchema.typeColumn, typeCollection),
					getDeleteButtonConfig()
				];
			} else {
				utilsConfig.items = [{
					className: 'BPMSoft.Button',
					caption: resources.localizableStrings.RemoveButtonCaption,
//					tag: 'ContactCardSchema',
					click: {bindTo: 'delete'}
				}];
			}
		}
		container.items = [utilsConfig];
		CardViewGenerator.generateView(container, viewModelSchema.attributes, {}, action, viewModelSchema.entitySchema);
		return container;
	}

	function generateAddButton(fullViewModelSchema, callback) {
		var addButton = {
			className: 'BPMSoft.Button',
			caption: resources.localizableStrings.AddButtonCaption,
			classes: {textClass: ['editDetailAddButton']}
		};
		if (fullViewModelSchema.methods.getAddButton) {
			addButton.classes.wrapperClass = ['edit-detail-custom-add-btn'];
		} else {
			addButton.classes.wrapperClass = ['editDetailAddButton', 'editDetailAddButtonContainer'];
		}
		if (fullViewModelSchema.typeColumn) {
			var column = fullViewModelSchema.entitySchema.getColumnByName(fullViewModelSchema.typeColumn);
			var referenceSchemaName = column.referenceSchemaName;
			var esq = Ext.create('BPMSoft.EntitySchemaQuery', {rootSchemaName: referenceSchemaName});
			esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, 'value');
			esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, 'displayValue');
			var filterName = 'typeFilter';
			if (fullViewModelSchema.methods.filterTypes) {
				filterName = fullViewModelSchema.methods.filterTypes(esq);
			}
			var innerCallback = function(result) {
				var addItemsCollection = [];
				result.collection.each(function(item) {
					addItemsCollection[addItemsCollection.length] = {
						caption: item.get('displayValue'),
						tag: {
							additionalValue: item.get('additionalValue'),
							displayValue: item.get('displayValue'),
							value: item.get('value')
						},
						click: {bindTo: 'add'}
					};
					fullViewModelSchema.typeCollection = addItemsCollection;
				});
				callback(generateAddButtonMenu(addItemsCollection, fullViewModelSchema, addButton));
			};
			var storageQueryConfig = {
				esq: esq,
				key: 'EditDetailType_' + referenceSchemaName + filterName,
				callback: innerCallback,
				scope: this
			};
			StorageUtilities.GetESQResultByKey(storageQueryConfig);
			return;
		}
		callback(generateAddButtonMenu([], fullViewModelSchema, addButton));
	}

	function generateAddButtonMenu(addItemsCollection, fullViewModelSchema, addButton) {
		if (fullViewModelSchema.methods && fullViewModelSchema.methods.getAddButton) {
			addButton = fullViewModelSchema.methods.getAddButton(addButton, addItemsCollection);
		} else if (fullViewModelSchema.methods && fullViewModelSchema.methods.getAddItems) {
			var addItems = fullViewModelSchema.methods.getAddItems(addItemsCollection);
			addButton.menu = {items: []};
			for (var i = addItems.length - 1; i >= 0; i--) {
				var pageConfig = addItems[i];
				var newItemElement = {
					caption: pageConfig.caption,
					tag: pageConfig.tag,
					click: {
						bindTo: pageConfig.click.bindTo
					}
				};
				addButton.menu.items.unshift(newItemElement);
			}
		} else {
			addButton.click = {
				bindTo: 'add'
			};
		}
		return addButton;
	}

	function generate(viewModelSchema, userCodes, parentId, action, callback, cardDetail) {
		cardDetail = cardDetail || {};
		if (cardDetail.isDestroyed) {
			return;
		}
		var containerPrefix = parentId || '';
		var fullViewModelSchema = getFullViewModelSchema(viewModelSchema, userCodes);
		entitySchema = fullViewModelSchema.entitySchema;
		var viewConfig = getContainerConfig(containerPrefix + 'autoGeneratedContainer');
		var utilsConfig = getContainerConfig(containerPrefix + 'utils');
		var gridPanelConfig = getContainerConfig(containerPrefix + 'autoGeneratedGridContainer');
		Ext.apply(gridPanelConfig, {});
		viewConfig.items = [gridPanelConfig, utilsConfig];
		if (action !== 'view') {
			generateAddButton(fullViewModelSchema, function(addButton) {
				utilsConfig.items = [addButton];
				if (cardDetail.isDestroyed) {
					return;
				}
				callback(viewConfig, fullViewModelSchema.typeCollection);
			});
			return;
		}
		callback(viewConfig);
	}

	return {
		generateItem : generateItem,
		generate: generate
	};
});
