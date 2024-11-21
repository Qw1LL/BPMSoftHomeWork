define('GlobalDuplicateModuleView', ['ext-base', 'BPMSoft',
	'GlobalDuplicateModuleViewResources'],
	function(Ext, BPMSoft, resources) {
	var entitySchemaName;
	function generate(entitySchemaName) {
		this.entitySchemaName = entitySchemaName;

		var columnsConfig = [];
		if (entitySchemaName === 'Account') {
			columnsConfig = [{
				cols: 6,
				key: [{
					name: resources.localizableStrings['GridTitle' + this.entitySchemaName],
					type: 'caption'
				}, {
					name: {
						bindTo: 'Name'
					}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleAccountPhone,
					type: 'caption'
				}, {
					name: {
						bindTo: 'Phone'
					}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleAccountAdditionalPhone,
					type: 'caption'
				}, {
					name: {
						bindTo: 'AdditionalPhone'
					}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleAccountWeb,
					type: 'caption'
				}, {
					name: {
						bindTo: 'Web'
					}
				}]
			}];
		} else {
			columnsConfig = [{
				cols: 6,
				key: [{
					name: resources.localizableStrings['GridTitle' + this.entitySchemaName],
					type: 'caption'
				}, {
					name: {
						bindTo: 'Name'
					}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleContactMobilePhone,
					type: 'caption'
				}, {
					name: {
						bindTo: 'MobilePhone'
					}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleContactHomePhone,
					type: 'caption'
				}, {
					name: {
						bindTo: 'HomePhone'
					}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleContactEmail,
					type: 'caption'
				}, {
					name: {
						bindTo: 'Email'
					}
				}]
			}];
		}

		var viewConfig = {
			id: 'globalDuplicateModuleView',
			className: 'BPMSoft.Container',
			selectors: {
				wrapEl: '#globalDuplicateModuleView'
			},
			items: [{
				className: 'BPMSoft.Container',
				id: 'buttonsContainer',
				selectors: {
					wrapEl: '#buttonsContainer'
				},
				items: [{
					className: 'BPMSoft.Button',
					id: 'startButton',
					caption: resources.localizableStrings.StartCaption,
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					tag: 'StartButton',
					enabled: {
						bindTo: 'duplicateStartEnabled'
					},
					click: {
						bindTo: 'onDuplicateStartClick'
					}
				}, {
					className: 'BPMSoft.Button',
					id: 'stopButton',
					caption: resources.localizableStrings.StopCaption,
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					tag: 'StopButton',
					enabled: {
						bindTo: 'duplicateStopEnabled'
					},
					click: {
						bindTo: 'onDuplicateStopClick'
					}
				}, {
					className: 'BPMSoft.Button',
					id: 'scheduleButton',
					caption: resources.localizableStrings.ScheduleCaption,
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					tag: 'ScheduleButton',
					enabled: {
						bindTo: 'duplicateScheduleEnabled'
					},
					click: {
						bindTo: 'onDuplicateScheduleClick'
					}
				}]
			}, {
				className: 'BPMSoft.Container',
				id: 'descriptionContainer',
				selectors: {
					wrapEl: '#descriptionContainer'
				},
				items: [{
					className: 'BPMSoft.Label',
					id: 'captionLabel',
					caption: {
						bindTo: 'getStatusDescription'
					}
				}]
			}, {
				className: 'BPMSoft.Container',
				id: 'gridContainer',
				selectors: {
					wrapEl: '#gridContainer'
				},
				items: [{
					id: 'duplicateGrid',
					className: 'BPMSoft.Grid',
					type: 'tiled',
					watchRowInViewport: 2,
					multiSelect: true,
					primaryColumnName: 'Id',
					hierarchical: true,
					hierarchicalColumnName: 'Parent',
					activeRow: {
						bindTo: 'activeRow'
					},
					isLoading: {
						bindTo: 'gridLoading'
					},
					watchedRowInViewport: {
						bindTo: 'loadNext'
					},
					columnsConfig: [columnsConfig],
					collection: {
						bindTo: 'duplicateGridData'
					}
				}]
			}]
		};
		return viewConfig;
	}

	return {
		generate: generate
	};
});
