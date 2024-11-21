define('FixedFilterView', ['ext-base', 'BPMSoft', 'FixedFilterViewResources'],
	function(Ext, BPMSoft, resources) {

		function getPeriodFilterConfig() {
		}

		var filterChangedDefined;

		function getFixedButtonBaseConfig() {
			return {
				className: 'BPMSoft.Button',
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT
			};
		}

		function getPeriodFilterViewConfig(filterConfig) {
			var periodConfig = getPeriodFilterConfig(filterConfig);
			var items = [
				{
					className: 'BPMSoft.Container',
					id: 'fixedFilter' + filterConfig.name + 'ButtonContainer',
					selectors: {
						el: '#fixedFilter' + filterConfig.name + 'ButtonContainer',
						wrapEl: '#fixedFilter' + filterConfig.name + 'ButtonContainer'
					},
					items: [
						getPeriodFixedButtonViewConfig(filterConfig.name)
					],
					classes: {
						wrapClassName: 'filter-inner-container'
					}
				},
				{
					className: 'BPMSoft.Container',
					id: 'fixedFilter' + filterConfig.name + 'ValuesContainer',
					selectors: {
						el: '#fixedFilter' + filterConfig.name + 'ValuesContainer',
						wrapEl: '#fixedFilter' + filterConfig.name + 'ValuesContainer'
					},
					items: [
						getDateFilterValueLabel(periodConfig, 'startDateColumnName',
							resources.localizableStrings.StartDatePlaceholder),
						{
							className: 'BPMSoft.Label',
							classes: {
								labelClass: ['filter-caption-label', 'filter-element-with-right-space']
							},
							caption: resources.localizableStrings.PeriodToLabelCaption
						},
						getDateFilterValueLabel(periodConfig, 'dueDateColumnName',
							resources.localizableStrings.DueDatePlaceholder),
						{
							className: 'BPMSoft.Button',
							style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							imageConfig: resources.localizableImages.RemoveButtonImage,
							classes: {
								wrapperClass: 'filter-remove-button'
							},
							click: {
								bindTo: 'clearPeriodFilter'
							},
							tag: periodConfig
						}
					],
					classes: {
						wrapClassName: 'filter-inner-container'
					}
				}
			];
			return items;
		}

		function getDateFilterValueLabel(periodConfig, currentColumnName, placeholder) {
			var columnName = periodConfig[currentColumnName];
			var config = {
				id: 'fixedFilter' + columnName + 'View',
				className: 'BPMSoft.LabelDateEdit',
				classes: {
					labelClass: ['filter-value-label', 'filter-element-with-right-space']
				},
				value: {
					bindTo: columnName
				},
				tag: {
					currentColumnName: columnName,
					periodConfig: periodConfig
				},
				placeholder: placeholder
			};
			if (filterChangedDefined) {
				config.change = {
					bindTo: 'periodChanged'
				};
			}
			return config;
		}

		function getPeriodFixedButtonViewConfig(filterName) {
			var config = getFixedButtonBaseConfig();
			config.imageConfig = resources.localizableImages.PeriodButtonImage;
			config.menu = {
				items: [
					{
						className: 'BPMSoft.MenuItem',
						caption: resources.localizableStrings.YesterdayCaption,
						click: {
							bindTo: 'setPeriod'
						},
						tag: filterName + '_Yesterday'
					},
					{
						className: 'BPMSoft.MenuItem',
						caption: resources.localizableStrings.TodayCaption,
						click: {
							bindTo: 'setPeriod'
						},
						tag: filterName + '_Today'
					},
					{
						className: 'BPMSoft.MenuItem',
						caption: resources.localizableStrings.TomorrowCaption,
						click: {
							bindTo: 'setPeriod'
						},
						tag: filterName + '_Tomorrow'
					},
					{
						className: 'BPMSoft.MenuSeparator'
					},
					{
						className: 'BPMSoft.MenuItem',
						caption: resources.localizableStrings.PastWeekCaption,
						click: {
							bindTo: 'setPeriod'
						},
						tag: filterName + '_PastWeek'
					},
					{
						className: 'BPMSoft.MenuItem',
						caption: resources.localizableStrings.CurrentWeekCaption,
						click: {
							bindTo: 'setPeriod'
						},
						tag: filterName + '_CurrentWeek'
					},
					{
						className: 'BPMSoft.MenuItem',
						caption: resources.localizableStrings.NextWeekCaption,
						click: {
							bindTo: 'setPeriod'
						},
						tag: filterName + '_NextWeek'
					},
					{
						className: 'BPMSoft.MenuSeparator'
					},
					{
						className: 'BPMSoft.MenuItem',
						caption: resources.localizableStrings.PastMonthCaption,
						click: {
							bindTo: 'setPeriod'
						},
						tag: filterName + '_PastMonth'
					},
					{
						className: 'BPMSoft.MenuItem',
						caption: resources.localizableStrings.CurrentMonthCaption,
						click: {
							bindTo: 'setPeriod'
						},
						tag: filterName + '_CurrentMonth'
					},
					{
						className: 'BPMSoft.MenuItem',
						caption: resources.localizableStrings.NextMonthCaption,
						click: {
							bindTo: 'setPeriod'
						},
						tag: filterName + '_NextMonth'
					}
				]
			};
			return config;
		}

		function getCustomFixedButtonConfig(filterConfig) {
			var config = getFixedButtonBaseConfig();
			config.caption = {
				bindTo: filterConfig.name + 'ButtonCaption'
			};
			config.imageConfig = filterConfig.buttonImageConfig || resources.localizableImages.LookupButtonImage;
			config.menu = {
				items: [
					{
						className: 'BPMSoft.MenuItem',
						caption: BPMSoft.SysValue.CURRENT_USER_CONTACT.displayValue,
						click: {
							bindTo: 'setCurrentContact'
						},
						tag: filterConfig.name
					},
					//TODO ###### ########### ##### ##### ########## ####### #####
//					{
//						className: 'BPMSoft.MenuSeparator'
//					},
//					{
//						className: 'BPMSoft.MenuItem',
//						caption: '##### ##### ####### #####'
//					},
					{
						className: 'BPMSoft.MenuSeparator'
					},
					{
						className: 'BPMSoft.MenuItem',
						caption: {
							bindTo: 'addOwnerCaption'
						},
						click: {
							bindTo: 'addLookupFilter'
						},
						tag: filterConfig.name
					},
					{
						className: 'BPMSoft.MenuItem',
						caption: resources.localizableStrings.ClearCaption,
						click: {
							bindTo: 'clearLookupFilter'
						},
						tag: filterConfig.name
					}
					//TODO ###### ########### ##### ##### ########### ######### ######## ######
//					,
//					{
//						className: 'BPMSoft.MenuSeparator'
//					},
//					{
//						className: 'BPMSoft.MenuItem',
//						caption: resources.localizableStrings.QuickListSettingsCaption,
//						tag: filterConfig.name
//					}
				]
			};
			return config;
		}

		function generate(schema) {
			getPeriodFilterConfig = schema.getPeriodFilterConfig;
			filterChangedDefined = schema.filterChangedDefined;
			var viewConfig = {
				id: 'fixedFilterContainer',
				selectors: {
					el: "#fixedFilterContainer",
					wrapEl: "#fixedFilterContainer"
				},
				items: [
				],
				tpl: [
					'<span id="{id}" style="{wrapStyles}" class="{wrapClassName}">',
					'{%this.renderItems(out, values)%}',
					'</span>'
				],
				afterrender: {
					bindTo: 'initialize'
				}
			};
			BPMSoft.each(schema.filters, function(filterConfig) {
				if (!filterConfig.moduleName) {
					var filterViewConfig = getFilterViewConfig(filterConfig);
					viewConfig.items.push(filterViewConfig);
				}
			}, this);
			return viewConfig;
		}

		function getFilterViewConfig(filterConfig) {
			var config = {
				className: 'BPMSoft.Container',
				id: 'fixedFilter' + filterConfig.name + 'Container',
				selectors: {
					el: '#fixedFilter' + filterConfig.name + 'Container',
					wrapEl: '#fixedFilter' + filterConfig.name + 'Container'
				},
				tpl: [
					'<span id="{id}" style="{wrapStyles}" class="{wrapClassName}">',
					'{%this.renderItems(out, values)%}',
					'</span>'
				],
				items: [
				]
			};
			if (filterConfig.dataValueType === BPMSoft.DataValueType.DATE) {
				config.items = getPeriodFilterViewConfig(filterConfig);
			} else {
				var buttonContainer = {
					className: 'BPMSoft.Container',
					id: 'fixedFilter' + filterConfig.name + 'ButtonContainer',
					selectors: {
						el: '#fixedFilter' + filterConfig.name + 'ButtonContainer',
						wrapEl: '#fixedFilter' + filterConfig.name + 'ButtonContainer'
					},
					items: [
						getCustomFixedButtonConfig(filterConfig)
					],
					classes: {
						wrapClassName: 'filter-inner-container'
					}
				};
				config.items.push(buttonContainer);
			}
			return config;
		}

//TODO ####### ##### ##### ########## ##### ## ###########
		function generateSimpleEditFilterConfig(filterName, simpleFilterEditContainerName) {
			var viewConfig = {
				id: simpleFilterEditContainerName,
				selectors: {
					el: '#' + simpleFilterEditContainerName,
					wrapEl: '#' + simpleFilterEditContainerName
				},
				classes: {
					wrapClassName: 'filter-inner-container'
				},
				items: [
					{
						className: 'BPMSoft.LookupEdit',
						classes: {
							wrapClass: 'filter-simple-filter-edit'
						},
						value: {
							bindTo: filterName
						},
						list: {
							bindTo: filterName + 'List'
						}
					},
					{
						className: 'BPMSoft.Button',
						imageConfig: resources.localizableImages.ApplyButtonImage,
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						classes: {
							wrapperClass: ['filter-element-with-right-space']
						},
						click: {
							bindTo: 'applyFilter'
						},
						tag: filterName
					},
					{
						className: 'BPMSoft.Button',
						imageConfig: resources.localizableImages.CancelButtonImage,
						click: {
							bindTo: 'destroySimpleFilterEdit'
						},
						tag: filterName
					}
				],
				destroy: {
					bindTo: 'clearSimpleFilterProperties'
				},
				tag: filterName
			};
			return viewConfig;
		}

		return {
			generate: generate,
			generateSimpleEditFilterConfig: generateSimpleEditFilterConfig
		};

	});
