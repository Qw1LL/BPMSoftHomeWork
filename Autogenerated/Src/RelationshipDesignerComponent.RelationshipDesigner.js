define("RelationshipDesignerComponent", [
		"RelationshipDesignerComponentResources",
		"RelationshipDiagramComponent"
], function(resources) {
	Ext.define("BPMSoft.RelationshipDesignerComponent", {
		extend: "BPMSoft.Component",

		mixins: {
			customEvent: "BPMSoft.mixins.CustomEventDomMixin"
		},

		/**
		 * The control resources receive event name.
		 * @protected
		 */
		getControlResourcesEventName: "getRelationshipDesignerTranslation",

		/**
		 * @inheritdoc BPMSoft.controls.Container#tpl
		 */
		tpl: [
			"<div id=\"relationship-designer-{id}-wrap\" class=\"{wrapClassName}\">" +
				"<ts-relationship-designer id=\"relationship-designer-{id}\" class=\"relationship-designer\"></ts-relationship-designer>" +
			"</div>"
		],

		diagramData: null,

		_subscribeCustomEvents: function() {
			this.mixins.customEvent.init();
			this._publishRelationshipDesignerLocalization();
		},

		_publishRelationshipDesignerLocalization: function () {
			this.mixins.customEvent.publish(this.getControlResourcesEventName, {
				ConfirmationDialog: {
					YES: resources.localizableStrings.ConfirmationDialogYes,
					NO: resources.localizableStrings.ConfirmationDialogNo
				},
				ConnectionPropertiesPage: {
					Comment: resources.localizableStrings.ConnectionPropertiesPageComment,
					Relations: resources.localizableStrings.ConnectionPropertiesPageRelations,
					RelationshipType: resources.localizableStrings.ConnectionPropertiesPageRelationshipType,
					Title: resources.localizableStrings.ConnectionPropertiesPageTitle,
					Placeholder: resources.localizableStrings.ConnectionPropertiesPagePlaceholder
				},
				ContainerPropertiesPage: {
					Address: resources.localizableStrings.ContainerPropertiesPageAddress,
					Email: resources.localizableStrings.ContainerPropertiesPageEmail,
					GeneralInformation: resources.localizableStrings.ContainerPropertiesPageGeneralInformation,
					Groups: resources.localizableStrings.ContainerPropertiesPageGroups,
					Phone: resources.localizableStrings.ContainerPropertiesPagePhone,
					RelationshipsWith: resources.localizableStrings.ContainerPropertiesPageRelationshipsWith,
					Type: resources.localizableStrings.ContainerPropertiesPageType,
					Web: resources.localizableStrings.ContainerPropertiesPageWeb
				},
				EntityInGroupPropertiesDialog: {
					AddToGroup: resources.localizableStrings.EntityInGroupPropertiesDialogAddToGroup,
					Cancel: resources.localizableStrings.EntityInGroupPropertiesDialogCancel,
					Comment: resources.localizableStrings.EntityInGroupPropertiesDialogComment,
					Edit: resources.localizableStrings.EntityInGroupPropertiesDialogEdit,
					Group: resources.localizableStrings.EntityInGroupPropertiesDialogGroup,
					Save: resources.localizableStrings.EntityInGroupPropertiesDialogSave
				},
				GroupPropertiesDialog: {
					Cancel: resources.localizableStrings.GroupPropertiesDialogCancel,
					Comment: resources.localizableStrings.GroupPropertiesDialogComment,
					EditGroup: resources.localizableStrings.GroupPropertiesDialogEditGroup,
					Name: resources.localizableStrings.GroupPropertiesDialogName,
					NewGroup: resources.localizableStrings.GroupPropertiesDialogNewGroup,
					Save: resources.localizableStrings.GroupPropertiesDialogSave
				},
				GroupsPropertiesPage: {
					Title: resources.localizableStrings.GroupsPropertiesPageTitle,
					Search: resources.localizableStrings.GroupsPropertiesPageSearch
				},
				InfoDialog: {
					OK: resources.localizableStrings.InfoDialogOk
				},
				RelationshipDesigner: {
					DeleteItemMessage: resources.localizableStrings.RelationshipDesignerDeleteItemMessage,
					RequiredControlErrorMessage: resources.localizableStrings.RelationshipDesignerRequiredControlErrorMessage
				},
				RelationshipDiagram: {
					NoAccess: resources.localizableStrings.RelationshipDiagramNoAccess,
					Tools: {
						FitToView: resources.localizableStrings.RelationshipDiagramToolsFitToView,
						ResetView: resources.localizableStrings.RelationshipDiagramToolsResetView,
						ZoomIn: resources.localizableStrings.RelationshipDiagramToolsZoomIn,
						ZoomOut: resources.localizableStrings.RelationshipDiagramToolsZoomOut,
						MiniMapClose: resources.localizableStrings.RelationshipDiagramToolsMiniMapClose,
						MiniMapOpen: resources.localizableStrings.RelationshipDiagramToolsMiniMapOpen
					}
				}
			});
		},

		// region Methods: Protected

		getSelectors: function() {
			return {
				wrapEl: "#relationship-designer-" + this.id + "-wrap",
				designerEl: "#relationship-designer-" + this.id
			};
		},

		/**
		 * @inheritdoc BPMSoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			const tplData = this.callParent(arguments);
			this.selectors = this.getSelectors();
			return tplData;
		},

		/**
		 * @inheritDoc BPMSoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this._subscribeCustomEvents();
		},

		onAfterRender: function() {
			this.callParent(arguments);
			this.initializeDiagramData();
		},

		onAfterReRender: function() {
			this.callParent(arguments);
			this.initializeDiagramData();
		},

		initializeDiagramData: function() {
			var designerEl = this.designerEl || {};
			designerEl = designerEl.dom;
			if (!designerEl) {
				return;
			}
			designerEl.data = this.diagramData;
		},

		// endregion

		// region Methods: Public

		setDiagramData: function(diagramData) {
			if (Ext.Object.equals(diagramData, this.diagramData)) {
				return false;
			}
			this.diagramData = diagramData;
			this.safeRerender();
			return true;
		}

		// endregion

	});
});
