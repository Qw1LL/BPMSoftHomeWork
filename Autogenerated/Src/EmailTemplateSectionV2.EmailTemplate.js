/**
 * Parent: BaseLookupSection
 */
define("EmailTemplateSectionV2", ["css!EmailTemplateSectionV2PageCSS"], function() {
	return {
		entitySchemaName: "EmailTemplate",

		methods: {

			//region Methods: Private

			_isLookupSection() {
				return this.sandbox.moduleName === "LookupSectionModule"
			},

			//endregion

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#destroy
			 * @overridden
			 */
			destroy: function() {
				Ext.get("communicationPanelContent").dom.querySelectorAll(".t-btn-wrapper").forEach((item)=>{
					item.removeEventListener('click', this.setOffsetMethod);
				});
				Ext.EventManager.removeListener(window, 'resize', this.setOffsetMethod);
				this.initOffsetMethod().disconnect();

			},

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseDataView#loadFiltersContainersVisibility
			 * @overridden
			 */
			loadFiltersContainersVisibility: function() {
				if (!this._isLookupSection()) {
					this.set("IsFoldersVisible", false);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseDataView#showFolderTree
			 * @overridden
			 */
			showFolderTree: function() {
				if (!this._isLookupSection()) {
					this.callParent(arguments);
				}
			},

			//endregion

			setOffsetMethod: function() {
				var containers = [
					Ext.get("ActionButtonsContainer"),
					Ext.get("LeftSectionContainer"),
					Ext.get("DataViewsContainer"),
					Ext.get("EmailTemplateSectionV2GridUtilsContainerContainer"),
					Ext.select(".grid-captions"),
					Ext.get("centerPanelContainer")
				]
				
				if(containers.length === 6) {
					var centerPanelContainerOffset = parseInt(getComputedStyle(containers[5].dom).paddingTop, 10);
					var buttonsContainerHeight = containers[0].dom.offsetHeight;
					var offset = buttonsContainerHeight + 8;
					var dataViewsOffset = offset + 34;
					var filtersContainerOffset = centerPanelContainerOffset + dataViewsOffset;
					var gridCaptionsOffset = filtersContainerOffset + containers[3].dom.offsetHeight;

					containers[1].setStyle("margin-top", `${offset}` + "px");
					containers[2].setStyle("padding-top", `${dataViewsOffset}` + "px");
					containers[3].setStyle("top", `${filtersContainerOffset}` + "px");
					containers[4].setStyle("top", `${gridCaptionsOffset}` + "px");
				}
			},
		
			initOffsetMethod: function() {
				Ext.EventManager.addListener(window, 'resize', this.setOffsetMethod);
				Ext.get("communicationPanelContent").dom.querySelectorAll(".t-btn-wrapper").forEach((item)=>{
					item.addEventListener("click", this.setOffsetMethod);
				});
				var observer = new MutationObserver(this.setOffsetMethod);
				observer.observe(Ext.get("EmailTemplateSectionV2SeparateModeActionButtonsContainerContainer").dom, {
					childList: true,
					subtree: true
				});

				return observer;
			},

		},
		details: /**SCHEMA_DETAILS*/ {} /**SCHEMA_DETAILS*/ ,
		diff: /**SCHEMA_DIFF*/ [
			{
				"operation": "merge",
				"name": "ActionButtonsContainer",
				"values": {
					"afterrender": {"bindTo": "initOffsetMethod"}
				}
			}
		] /**SCHEMA_DIFF*/
	};
});
