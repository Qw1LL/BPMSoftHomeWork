define("MainHeaderSchema", [], function() {
	return {
		methods: {
			/**
			 * @override
			 * @protected
			 */
			getSchemaName: function() {
				const hash = BPMSoft.router.Router.getHash();
				const pages = hash.split("/");
				const isHomePage = this._getIsHomePage();
				return isHomePage ? pages[1] : this.openedSchemaName;
			},

			/**
			 * @protected
			 */
			handlingIncorrectSchemaType: function() {
				const caption = this.get("Resources.Strings.CannotEditPageMessage");
				const buttons = [
					{
						className: "BPMSoft.Button",
						returnCode: "redirect",
						caption: this.get("Resources.Strings.RedirectToWorkplaceCaption")
					},
					"cancel"
				];
				BPMSoft.showMessage({
					caption,
					scope: this,
					handler: this._navigateToWorkplace,
					style: BPMSoft.MessageBoxStyles.ORANGE,
					buttons,
					defaultButton: 0
				});
			},

			/**
			 * @private
			 */
			_navigateToWorkplace: function(result) {
				if (result === "redirect") {
					const info = this.sandbox.publish("GetWorkplaceInfo", this.sandbox.id);
					this.sandbox.publish("PushHistoryState", {
						hash: "CardModuleV2/SysWorkplacePageV2/edit/" + info.workplaceId
					});
				}
			},

			/**
			 * @override
			 * @protected
			 */
			setSystemDesignerButtonVisible: function() {
				const isHomePage = this._getIsHomePage();
				this.set("IsSystemDesignerButtonVisible", !(isHomePage || this.openedSchemaName));
			},

			/**
			 * @private
			 */
			_getIsHomePage: function() {
				const hash = BPMSoft.router.Router.getHash();
				const pages = hash.split("/");
				let isHomePage = false;
				if (BPMSoft.Features.getIsDisabled("DisableHomePageInWorkplace")) {
					isHomePage = pages.length > 1 &&
							(pages[0] === "HomePage" || (pages[0] === "IntroPage" && pages[1] !== "SystemDesigner"));
				}
				return isHomePage;
			}
		},
	};
});
