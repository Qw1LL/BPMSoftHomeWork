define('FolderFilterView', ['ext-base', 'BPMSoft', 'FolderFilterViewResources'],
	function(Ext, BPMSoft, resources) {

		function getMainButtonMenuConfig(favorites) {
			var menuConfig = {
				items: [
					{
						className: 'BPMSoft.MenuItem',
						caption: resources.localizableStrings.AddConditionMenuItemCaption,
						click: {
							bindTo: 'selectFolder'
						}
					},
					{
						className: 'BPMSoft.MenuSeparator'
					}
				]
			};
			BPMSoft.each(favorites, function(favorite) {
				var favoriteMenuItemConfig = {
					className: 'BPMSoft.MenuItem',
					caption: favorite.displayValue,
					tag: favorite.value,
					click: {
						bindTo: 'addFavoriteFolderFilter'
					}
				};
				menuConfig.items.push(favoriteMenuItemConfig);
			}, this);
			return menuConfig;
		}

		function getMainButtonConfig(config) {
			var buttonConfig = {
				className: 'BPMSoft.Button',
				caption: {
					bindTo: 'buttonCaption'
				},
				imageConfig: resources.localizableImages.FolderImage,
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT
			};
			if (config.favorites) {
				buttonConfig.menu = getMainButtonMenuConfig(config.favorites);
			}
			else {
				buttonConfig.click = {
					bindTo: 'selectFolder'
				};
			}
			return buttonConfig;
		}

		function generate(config) {
			var viewConfig = {
				id: config.folderFilterContainerName,
				selectors: {
					el: "#" + config.folderFilterContainerName,
					wrapEl: "#" + config.folderFilterContainerName
				},
				tpl: [
					'<span id="{id}" style="{wrapStyles}" class="{wrapClassName}">',
					'{%this.renderItems(out, values)%}',
					'</span>'
				],
				items: [
					{
						className: 'BPMSoft.Container',
						id: config.folderFilterButtonContainerName,
						selectors: {
							el: "#" + config.folderFilterButtonContainerName,
							wrapEl: "#" + config.folderFilterButtonContainerName
						},
						classes: {
							wrapClassName: 'filter-inner-container'
						},
						items: [
							getMainButtonConfig(config)
						]
					}
				],
				afterrender: {
					bindTo: 'initialize'
				}
			};
			return viewConfig;
		}

		//TODO ####### ##### ############
		function generateAddSimpleFolderFilterConfig(simpleFilterEditContainer) {
			var viewConfig = {
				id: simpleFilterEditContainer,
				selectors: {
					el: "#" + simpleFilterEditContainer,
					wrapEl: "#" + simpleFilterEditContainer
				},
				classes: {
					wrapClassName: 'filter-inner-container'
				},
				items: [
					{
						className: 'BPMSoft.ComboBoxEdit',
						classes: {
							wrapClass: 'filter-simple-filter-edit'
						},
						value: {
							bindTo: 'folderFilterColumn'
						},
						list: {
							bindTo: 'folderFilterColumnList'
						},
						placeholder: resources.localizableStrings.FolderFilterEmptyFolderEditPlaceHolder
					},
					{
						className: 'BPMSoft.Button',
						imageConfig: resources.localizableImages.ApplyButtonImage,
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						classes: {
							wrapperClass: ['filter-element-with-right-space']
						},
						click: {
							bindTo: 'applyFolderFilter'
						}
					},
					{
						className: 'BPMSoft.Button',
						imageConfig: resources.localizableImages.CancelButtonImage,
						click: {
							bindTo: 'destroySimpleFilterAddingContainer'
						}
					}
				],
				destroy: {
					bindTo: 'clearSimpleFilterProperties'
				}
			};
			return viewConfig;
		}

		return {
			generate: generate,
			generateAddSimpleFolderFilterConfig: generateAddSimpleFolderFilterConfig
		};

	});
