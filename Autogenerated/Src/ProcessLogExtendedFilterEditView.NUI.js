define('ProcessLogExtendedFilterEditView', ['ext-base', 'BPMSoft',
	'ProcessLogExtendedFilterEditViewResources', 'ExtendedFilterEditView'],
	function(Ext, BPMSoft, resources, ExtendedFilterEditView) {

        function generateView(renderTo) {
            var view = ExtendedFilterEditView.generateView(renderTo);
            var lookupeditCaptionConfig = {
                className: 'BPMSoft.Label',
                labelClass: 't-label controlCaption',
                caption: resources.localizableStrings.SysProcessEntity
            };
            var lookupEditConfig = {
                id: 'entitySchemaLookupEdit',
                className: 'BPMSoft.LookupEdit',
                value: {
                    bindTo: 'lookupSelectedValue'
                },
                list: {
                    bindTo: 'entitySchemaLookupEditList'
                },
                prepareList: {
                    bindTo: 'getEntitySchemaNames'
                },
                loadVocabulary: {
                    bindTo: 'loadEntitySchemaNames'
                },
                change: {
                    bindTo:'changedEntitySchemaName'
                }
            };
            var extendedFilterEditContainer = {
                className: 'BPMSoft.Container',
                id: 'extendedFilterEdit',
                selectors: {
                el: '#extendedFilterEdit',
                    wrapEl: '#extendedFilterEdit'
                },
                items: []
            };
            var moduleTitle = view.items[0];
            var buttonPanel = view.items[1];
            var filterEdit = view.items[2];
            extendedFilterEditContainer.items = [
                lookupeditCaptionConfig,
                lookupEditConfig
            ];
            view.items = [
                moduleTitle,
                buttonPanel,
                extendedFilterEditContainer,
                filterEdit
            ]
			return view;
		}

		return {
            generateView: generateView
		};
	});
