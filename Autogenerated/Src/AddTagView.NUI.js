define('AddTagView', ['ext-base', 'BPMSoft', 'AddTagViewResources'],
	function(Ext, BPMSoft, resources) {

		function generateAddTagConfig() {
			var config = 'BPMSoft.TextEdit';
			var viewConfig = {
				id: 'simpleTagFilterEditContainer',
				selectors: {
					el: "#simpleTagFilterEditContainer",
					wrapEl: "#simpleTagFilterEditContainer"
				},
				classes: {
					wrapClassName: 'tag-inner-container'
				},
				items: [
					getTagValueEditConfig(config),
					{
						className: 'BPMSoft.Button',
						imageConfig: resources.localizableImages.ApplyButtonImage,
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						classes: {
							wrapperClass: ['tag-element-with-right-space']
						},
						click: {
							bindTo: 'applyTag'
						}
					},
					{
						className: 'BPMSoft.Button',
						imageConfig: resources.localizableImages.CancelButtonImage,
						click: {
							bindTo: 'destroyTagAddingContainer'
						}
					}
				],
				destroy: {
					bindTo: 'clearTagProperties'
				}
			};
			return viewConfig;
		}

		function generate() {
			var viewConfig = {
				id: 'tagContainer',
				selectors: {
					el: "#tagContainer",
					wrapEl: "#tagContainer"
				},
				tpl: [
					'<span id="{id}" style="{wrapStyles}" class="{wrapClassName}">',
					'{%this.renderItems(out, values)%}',
					'</span>'
				],
				items: [
					{
						className: 'BPMSoft.Container',
						id: 'tagFilterButtonContainer',
						selectors: {
							el: "#tagFilterButtonContainer",
							wrapEl: "#tagFilterButtonContainer"
						},
						classes: {
							wrapClassName: 'tag-inner-container'
						},
						items: [
							{
								className: 'BPMSoft.Button',
								imageConfig: resources.localizableImages.ImageFilter,
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								classes: {
									wrapperClass: 'image-container'
								}
							}
						]
					}, {
						className: "BPMSoft.Container",
						id: "tagCommonContainer",
						selectors: {
							el: "#tagCommonContainer",
							wrapEl: "#tagCommonContainer"
						},
						items: []
					}, {
						className: 'BPMSoft.Container',
						id: 'addTagButtonContainer',
						selectors: {
							el: "#addTagButtonContainer",
							wrapEl: "#addTagButtonContainer"
						},
						classes: {
							wrapClassName: 'tag-inner-container'
						},
						items: [
							{
								className: 'BPMSoft.Button',
								caption: {
									bindTo: 'getAddButtonCaption'
								},
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								click: {
									bindTo: 'addTag'
								},
								visible: {
									bindTo: 'editVisible'
								}
							}
						]
					}
				]
			};
			return viewConfig;
		}

		function getTagValueEditConfig(config) {
			var controlConfig = {
				classes: {
					wrapClass: 'tag-simple-tag-edit'
				},
				value: {
					bindTo: 'tagValueColumn'
				},
				enterkeypressed: {
					bindTo: 'applyTag'
				},
				placeholder: resources.localizableStrings.TagEmptyValueEditPlaceHolder
			};
			if (config.className) {
				Ext.apply(controlConfig, config);
			}
			else {
				controlConfig.className = config;
			}
			return controlConfig;
		}

		function generateTagViewConfig(tagName, action) {
			var viewConfig = {
				classes: {
					wrapClassName: ['tag-inner-container', 'tag-' + action]
				},
				visible: {
					bindTo: 'viewVisible',
					bindConfig: {
						converter: function(x) {
							if (x === false) {
								return false;
							}
							return true;
						}
					}
				},
				items: [
					{
						className: 'BPMSoft.Label',
						classes: {
							labelClass: ['tag-value-label', 'tag-element-with-right-space']
						},
						caption: {
							bindTo: 'displayValue'
						},
						click: {
							bindTo: 'editTag'
						},
						tag: tagName
					},
					{
						className: 'BPMSoft.Button',
						classes: {
							wrapperClass: 'tag-remove-button'
						},
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						imageConfig: resources.localizableImages.RemoveButtonImage,
						visible: {
							bindTo: 'readOnlyMode',
							bindConfig: {
								converter: function(x) {
									return !x;
								}
							}
						},
						click: {
							bindTo: 'removeTag'
						},
						tag: tagName
					}
				]
			};
			return viewConfig;
		}

		return {
			generate: generate,
			generateAddTagConfig: generateAddTagConfig,
			getTagValueEditConfig: getTagValueEditConfig,
			generateTagViewConfig: generateTagViewConfig
		};

	});
