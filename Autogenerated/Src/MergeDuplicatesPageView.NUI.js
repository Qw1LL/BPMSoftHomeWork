define("MergeDuplicatesPageView", ["ext-base", "BPMSoft", "MergeDuplicatesPageViewResources",
	"CardViewGenerator"], function(Ext, BPMSoft, resources, CardViewGenerator) {

		function generate(viewModelConfig) {
			var attributesConfig = [];
			var entityColumns = viewModelConfig.values.entityColumns;
			var entitySchema = viewModelConfig.entitySchema;
			BPMSoft.each(entityColumns, function(columnName) {
				var column = viewModelConfig.entitySchema.columns[columnName];

				var itemConfig = {
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: columnName,
					columnPath: columnName,
					dataValueType: column.dataValueType
				};

				var labelConfig = CardViewGenerator.generateLabelConfig(entitySchema, itemConfig, {});
				var controlConfig = CardViewGenerator.generateControlConfig(entitySchema, itemConfig, {}, {});

				attributesConfig.push({
					className: "BPMSoft.Container",
					id: "attribute" + columnName + "Container",
					selectors: {
						wrapEl: "#attribute" + columnName + "Container"
					},
					visible: {
						bindTo: columnName + "BoxEnabled"
					},
					classes: {
						wrapClassName: "attributeContainer"
					},
					items: [
						{
							className: "BPMSoft.Container",
							id: "attribute" + columnName + "LeftContainer",
							selectors: {
								wrapEl: "#attribute" + columnName + "LeftContainer"
							},
							classes: {
								wrapClassName: "leftContainer"
							},
							items: [labelConfig, controlConfig]
						},
						{
							className: "BPMSoft.Container",
							id: "attribute" + columnName + "RightContainer",
							selectors: {
								wrapEl: "#attribute" + columnName + "RightContainer"
							},
							classes: {
								wrapClassName: "rightContainer"
							},
							items: []
						}
					]
				});
			}, this);

			var viewConfig = {
				id: "mergeDuplicatesContainer",
				selectors: {
					wrapEl: "#mergeDuplicatesContainer"
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "buttonsContainer",
						selectors: {
							wrapEl: "#buttonsContainer"
						},
						items: [
							{
								className: "BPMSoft.Button",
								id: "acceptButton",
								caption: resources.localizableStrings.AcceptButtonCaption,
								style: BPMSoft.controls.ButtonEnums.style.ORANGE,
								tag: "AcceptButton",
								enabled: {
									bindTo: "isEdit"
								},
								click: {
									bindTo: "onAcceptClick"
								}
							},
							{
								className: "BPMSoft.Button",
								id: "cancelButton",
								caption: resources.localizableStrings.CancelButtonCaption,
								tag: "CancelButton",
								enabled: {
									bindTo: "isEdit"
								},
								click: {
									bindTo: "onCancelClick"
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "descriptionContainer",
						selectors: {
							wrapEl: "#descriptionContainer"
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "descriptionLabel",
								caption: resources.localizableStrings.DescriptionCaption
							},
							{
								className: "BPMSoft.Container",
								id: "descriptionRadioChangeContainer",
								selectors: {
									wrapEl: "#descriptionRadioChangeContainer"
								},
								classes: {
									wrapClassName: ["custom-inline"]
								},
								items: [
									{
										className: "BPMSoft.RadioButton",
										tag: "Changed",
										checked: {
											bindTo: "isViewGroup"
										}
									},
									{
										className: "BPMSoft.Label",
										caption: resources.localizableStrings.ViewTypeChangeCaption
									}
								]
							},
							{
								className: "BPMSoft.Container",
								id: "descriptionRadioAllContainer",
								selectors: {
									wrapEl: "#descriptionRadioAllContainer"
								},
								classes: {
									wrapClassName: ["custom-inline"]
								},
								items: [
									{
										className: "BPMSoft.RadioButton",
										tag: "All",
										checked: {
											bindTo: "isViewGroup"
										}
									},
									{
										className: "BPMSoft.Label",
										caption: resources.localizableStrings.ViewTypeAllCaption
									}
								]
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "attributesContainer",
						selectors: {
							wrapEl: "#attributesContainer"
						},
						items: attributesConfig
					},
					{
						caption: resources.localizableStrings.CommunicationDetailCaption,
						className: "BPMSoft.ControlGroup",
						classes: {
							wrapContainerClass: ["control-group-container"]
						},
						collapsed: true,
						visible: true,
						id: "communicationGroupContainer",
						selectors: {
							wrapEl: "#communicationGroupContainer"
						},
						items: []
					},
					{
						caption: resources.localizableStrings.AddressDetailCaption,
						className: "BPMSoft.ControlGroup",
						classes: {
							wrapContainerClass: ["control-group-container"]
						},
						collapsed: true,
						visible: true,
						id: "addressGroupContainer",
						selectors: {
							wrapEl: "#addressGroupContainer"
						},
						items: []
					}
				]
			};

			return viewConfig;
		}
		function getHeaderCaption(entitySchemaName) {
			return resources.localizableStrings[entitySchemaName + "Caption"];
		}

		return {
			generate: generate,
			getHeaderCaption: getHeaderCaption
		};
	});
