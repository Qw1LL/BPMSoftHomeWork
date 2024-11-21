define('ProcessLogFolderFilterView', ['ext-base', 'BPMSoft',
	'ProcessLogFolderFilterViewResources', 'FolderLookupPageView'],
		function(Ext, BPMSoft, resources, FolderLookupPageView ) {

			function generate() {
				return FolderLookupPageView.generate();
			}

			function getFolderView() {
				var view = FolderLookupPageView.getFolderView();
				var lookupeditCaptionConfig = {
					className: 'BPMSoft.Label',
					labelClass: 't-label controlCaption',
					caption: resources.localizableStrings.SysProcessEntity,
					markerValue: 'SysProcessEntity'
				};
                var lookupEditConfig = {
                    id: 'entitySchemaLookupEdit',
                    className: 'BPMSoft.LookupEdit',
					markerValue: 'SysProcessEntity',
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
				view.items.splice(1, 0, lookupeditCaptionConfig);
				view.items.splice(2, 0, lookupEditConfig);
				return view;
			}

			return {
				generate: generate,
				getFolderView: getFolderView
			};
		});
