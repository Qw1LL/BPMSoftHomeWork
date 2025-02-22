﻿define('AddressDetail', ['ext-base', 'BPMSoft', 'sandbox', 'LeadAddress', 'AddressDetailStructure',
	'AddressDetailResources', 'BusinessRuleModule'],
	function(Ext, BPMSoft, sandbox, LeadAddress, structure, resources, BusinessRuleModule) {

		var getContainerConfig = function(id, styles) {
			var container = {
				className: 'BPMSoft.Container',
				items: [],
				id: id,
				selectors: {
					wrapEl: '#' + id
				}
			};
			if (styles) {
				container.classes = {
					wrapClassName: styles
				};
			}
			return container;
		};

		var getLabelConfig = function(caption, labelClass) {
			return {
				className: 'BPMSoft.Label',
				caption: {
					bindTo: caption
				},
				labelClass: labelClass
			};
		};

		var filterSchemaName;

		structure.userCode = function() {
			this.entitySchema = LeadAddress;
			filterSchemaName = 'Lead';
			this.name = 'AddressDetailViewModel';
			this.parentColumnPath = 'Id';
			this.typeColumn = 'AddressType';
			this.filterColumnPath = filterSchemaName;
			this.attributes = [
				{
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: 'AddressType',
					columnPath: 'AddressType',
					dataValueType: BPMSoft.DataValueType.ENUM,
					visible: true
				}, {
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Address',
					columnPath: 'Address',
					dataValueType: BPMSoft.DataValueType.TEXT,
					visible: true
				}, {
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Country',
					columnPath: 'Country',
					dataValueType: BPMSoft.DataValueType.ENUM,
					visible: true
				}, {
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Region',
					columnPath: 'Region',
					dataValueType: BPMSoft.DataValueType.ENUM,
					visible: true
				}, {
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: 'City',
					columnPath: 'City',
					dataValueType: BPMSoft.DataValueType.ENUM,
					visible: true
				}, {
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Zip',
					columnPath: 'Zip',
					dataValueType: BPMSoft.DataValueType.TEXT,
					visible: true
				}, {
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: filterSchemaName,
					columnPath: filterSchemaName,
					dataValueType: BPMSoft.DataValueType.ENUM,
					visible: false,
					viewVisible: false
				}
			];

			this.methods.filterTypes = function(select) {
				select.filters.add('schemaTypeFilter', BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, 'For' + filterSchemaName, true));
			};

			this.methods.getAddItems = function(collection) {
				return collection;
			};

			this.methods.typeChanged = function(tag) {
				this.set('AddresType', tag);
			};

			this.methods.onLocationIconClick = function(context) {
				var instanceId = context.target.id.substring(0, 36);
				var viewModelItems = this.get('gridData').collection.items;
				var filteredItems = viewModelItems.filter(function(value) {
						return (value.instanceId === instanceId);
					}
				);
				var viewModelItem = filteredItems[0];
				var address = viewModelItem.getConcatenatedAddress();
				var object = viewModelItem.get(filterSchemaName) ?
					viewModelItem.get(filterSchemaName).displayValue : undefined;
				if (address && object) {
					Ext.get(instanceId + '-locationMarker').dom.href =
						'https://maps.google.com?q=' + encodeURIComponent(address);
				}
			};

			this.methods.getConcatenatedAddress = function() {
				var address = this.get('Address');
				var city = this.get('City') ? this.get('City').displayValue : undefined;
				var country = this.get('Country') ? this.get('Country').displayValue : undefined;
				var zip = this.get('Zip');
				var concatenatedAddress = [];
				if (address) {
					concatenatedAddress.push(address);
				}
				if (city) {
					concatenatedAddress.push(city);
				}
				if (country) {
					concatenatedAddress.push(country);
				}
				if (zip) {
					concatenatedAddress.push(zip);
				}
				return concatenatedAddress.join(', ');
			};

			this.methods.getLookupQuery = function(filterValue, columnName) {
				var esq = this.callParent(arguments);
				var country = this.get('Country');
				var region = this.get('Region');
				switch (columnName) {
					case 'City':
						if (country) {
							esq.addColumn('Country');
							esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.EQUAL, 'Country', country.value));
						}
						if (region) {
							esq.addColumn('Region');
							esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.EQUAL, 'Region', region.value));
						}
						break;
					case 'Region':
						esq.addColumn('Country');
						if (country) {
							esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.EQUAL, 'Country', country.value));
						}
						break;
				}
				return esq;
			};

			//this.methods.onDataChange = function(obj, options) {
			//	this.callParent(arguments);
			//}

			//this.methods.getCountryIcon = function(value) {
			//	var config = resources.localizableImages[icon];
			//	return BPMSoft.ImageUrlBuilder.getUrl(config);
			//};

			this.methods.getCustomItemView = function(viewModel, itemKey, action, types) {
				BPMSoft.each(types, function(item) {
					item.click = {
						bindTo: 'typeChanged'
					};
				});
				var columns = viewModel.attributes;
				var typeColumn = columns[0];
				var addressColumn = columns[1];
				var countryColumn = columns[2];
				var regionColumn = columns[3];
				var cityColumn = columns[4];
				var zipColumn = columns[5];
				var viewConfig = getContainerConfig(itemKey + '-view', 'detail-view-container-user-class');
				switch (action) {
					case 'add':
					case 'copy':
					case 'edit':
						var typeButton = {
							id: itemKey + '-type',
							className: 'BPMSoft.Button',
							classes: {
								wrapperClass: 'detail-type-btn-user-class detail-control-container-user-class'
							},
							style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							selectors: {
								wrapEl: '#' + itemKey + '-type'
							},
							caption: {
								bindTo: typeColumn.name,
								bindConfig: {
									converter: BPMSoft.getTypedStringValue
								}
							},
							menu: {
								items: types
							}
						};
						var deleteButton = {
							id: itemKey + '-delete',
							className: 'BPMSoft.Button',
							classes: {
								wrapperClass: 'detail-delete-btn-user-class'
							},
							imageConfig: resources.localizableImages.DeleteIcon,
							style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							selectors: {
								wrapEl: '#' + itemKey + '-delete'
							},
							click: {
								bindTo: 'delete'
							}
						};
						var addressLabel = {
							className: 'BPMSoft.Label',
							labelClass: 't-label controlCaption',
							caption: resources.localizableStrings.AddressCaption
						};
						var addressEdit = {
							id: itemKey + '-address-edit',
							className: 'BPMSoft.TextEdit',
							classes: {
								wrapClass: 'detail-control-container-user-class'
							},
							value: {
								bindTo: addressColumn.name
							}
						};
						var countryLabel = {
							className: 'BPMSoft.Label',
							labelClass: 't-label controlCaption',
							caption: resources.localizableStrings.CountryCaption
						};
						var countryEdit = {
							id: itemKey + '-country-edit',
							className: 'BPMSoft.ComboBoxEdit',
							value: {
								bindTo: countryColumn.name
							},
							classes: {
								wrapClass: 'detail-control-container-user-class'
							},
							list: {
								bindTo: 'CountryList'
							}
							//leftIconConfig: {
							//	source: BPMSoft.ImageSources.URL,
							//	url: {
							//		bindTo: countryColumn.name,
							//		bindConfig: function(value) {
							//			return getCountryIcon(value);
							//		}
							//	}
							//},
							//enableLeftIcon: true
						};
						var regionLabel = {
							className: 'BPMSoft.Label',
							labelClass: 't-label controlCaption',
							caption: resources.localizableStrings.RegionCaption
						};
						var regionEdit = {
							id: itemKey + '-region-edit',
							className: 'BPMSoft.ComboBoxEdit',
							value: {
								bindTo: regionColumn.name
							},
							classes: {
								wrapClass: 'detail-control-container-user-class'
							},
							list: {
								bindTo: 'RegionList'
							}
						};
						var cityLabel = {
							className: 'BPMSoft.Label',
							labelClass: 't-label controlCaption',
							caption: resources.localizableStrings.CityCaption
						};
						var cityEdit = {
							id: itemKey + '-city-edit',
							className: 'BPMSoft.ComboBoxEdit',
							value: {
								bindTo: cityColumn.name
							},
							classes: {
								wrapClass: 'detail-control-container-user-class'
							},
							list: {
								bindTo: 'CityList'
							}
						};
						var zipLabel = {
							className: 'BPMSoft.Label',
							labelClass: 't-label controlCaption',
							caption: resources.localizableStrings.ZipCaption
						};
						var zipEdit = {
							id: itemKey + '-zip-edit',
							className: 'BPMSoft.TextEdit',
							classes: {
								wrapClass: 'detail-control-container-user-class'
							},
							value: {
								bindTo: zipColumn.name
							}
						};
						viewConfig.items.push(typeButton, deleteButton);
						viewConfig.items.push(addressLabel, addressEdit);
						viewConfig.items.push(countryLabel, countryEdit);
						viewConfig.items.push(regionLabel, regionEdit);
						viewConfig.items.push(cityLabel, cityEdit);
						viewConfig.items.push(zipLabel, zipEdit);
						break;
					case 'view':
						viewConfig.classes = {
							wrapClassName: 'detail-view-container-user-class'
						};
						var typeLabel = {
							className: 'BPMSoft.Label',
							labelClass: 't-label addresses-header-lbl-user-class controlCaption',
							caption: {
								bindTo: typeColumn.name,
								bindConfig: {
									converter: BPMSoft.getTypedStringValue
								}
							}
						};
						var valueLabel = {
							className: 'BPMSoft.Label',
							labelClass: 't-label addresses-value-lbl-user-class',
							caption: {
								bindTo: 'getConcatenatedAddress'
							}
						};
						var onLocationIconClick = this.onLocationIconClick;
						var self = this;
						var name = itemKey + '-loaction-img-control';
						var imageConfig = resources.localizableImages.LocationIcon;
						var imageUrl = BPMSoft.ImageUrlBuilder.getUrl(imageConfig);
						var html = '<a id="' + itemKey + '-locationMarker">' +
							'<img id = "' + name + '" class = "addresses-location-btn-user-class" ' +
							'src = "' + imageUrl + '"></a>';
						var locationIcon = {
							id: name,
							className: 'BPMSoft.HtmlControl',
							html: html,
							selectors: {
								wrapEl: '#' + name
							},
							onAfterRender: function() {
								Ext.get(name).on("click", onLocationIconClick.bind(self));
							}
						};
						var emptyContainer = getContainerConfig(itemKey + '-empty',
							'detail-empty-user-class');
						viewConfig.items.push(typeLabel);
						viewConfig.items.push(valueLabel);
						viewConfig.items.push(locationIcon);
						viewConfig.items.push(emptyContainer);
						break;
				}
				return viewConfig;
			};

			this.loadedColumns = [
				{
					columnPath: 'AddressType'
				}, {
					columnPath: 'Address'
				}, {
					columnPath: 'Country'
				}, {
					columnPath: 'Region'
				}, {
					columnPath: 'City'
				}, {
					columnPath: 'Zip'
				}, {
					columnPath: filterSchemaName
				}
			];
		};

		return structure;
	});
