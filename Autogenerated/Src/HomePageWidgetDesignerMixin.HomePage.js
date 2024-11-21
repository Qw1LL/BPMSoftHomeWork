define("HomePageWidgetDesignerMixin", ["ext-base", "WidgetEnums"], function(Ext) {
	Ext.define("BPMSoft.configuration.mixins.HomePageWidgetDesignerMixin", {
		alternateClassName: "BPMSoft.HomePageWidgetDesignerMixin",

		isPopupOpened: false,

		//region Methods: Public

		/**
		 * Observes the mutations on body tag.
		 */
         observeBodyMutations: function() {
            const mutationObserver = new MutationObserver((mutations) => {
                if (!mutations) {
                    return;
                }
                for (let mutation of mutations) {
                    const { target, oldValue} = mutation;
                    const isStructureExplorerExist = target.getElementsByTagName?.('ts-structure-explorer').length > 0;
                    const isModalOpening = !this.isPopupOpened && (isStructureExplorerExist ||
                            target?.classList?.contains('ts-modalbox-opened') ||
                            oldValue?.includes('ts-messagebox-box'));
                    const isModalClosing = this.isPopupOpened && (target?.classList?.contains('close') ||
                        oldValue?.includes('ts-modalbox-opened') ||
                        (target?.className === 'ts-messagebox-cover' && target?.style?.display === 'none'));
                    if (isModalOpening) {
                        this.sandbox.publish('ModalOpening', null, [this.sandbox.id]);
                        this.isPopupOpened = true;
                        break;
                    } else if (isModalClosing) {
                        this.sandbox.publish('ModalClosing', null, [this.sandbox.id]);
                        this.isPopupOpened = false;
                        break;
                    }
                }
            });
            mutationObserver.observe(document.querySelector('body'), {
                characterData: true,
                attributeOldValue: true,
                subtree: true,
            });
        },

        hideDesignerLoadingMask: function() {
            const body = Ext.getBody();
			body.set({"maskState": "none"});
        },

		/**
		 * Gets the value from the resources by pattern.
		 */
        getResourceValue: function(resourcePattern) {
            const pattern = /^\#Resource[^(]+\(([^)]+)\)\#$/;
            if (pattern.test(resourcePattern)) {
                const resourceKey = resourcePattern.match(pattern)[1];
                const resources = this.get("Resources");
                const widgetResources = resources?.strings[resourceKey] ?? {};
                const currentCultureResources = widgetResources[BPMSoft.currentUserCultureName];
                const defaultCultureResources = widgetResources[BPMSoft.SysValue.PRIMARY_LANGUAGE.code];
                return currentCultureResources ?? defaultCultureResources ?? '';
            } else {
                return resourcePattern;
            }
        },

        /**
		 * Upsert the resource for current location except the value is not falsy and not setted for the first time.
         * If resource is successfully setted returns true, if not - false.
		 */
        upsertResource: function(key, value) {
            const resources = this.get("Resources");
            const isFirstSet = !resources.strings[key];
            const valueIsEmpty = !value;
            const skipSetResource = isFirstSet  && valueIsEmpty;
            if (skipSetResource) {
                return false;
            }
            resources.strings[key] = resources.strings[key] || {};
            resources.strings[key][BPMSoft.currentUserCultureName] = value;
            this.setResources(resources);
            return true;
        },

        /**
		 * Sets the resources.
		 */
        setResources(resources) {
            this.set("Resources", resources ?? {});
        },

        getPatternLocalizedString: function(resourceKey) {
            return `#ResourceString(${resourceKey})#`;
        },

        getWidgetThemeDefaultConfig: function() {
            return BPMSoft.WidgetEnums.WidgetTheme;
        },
        
        prepareWidgetThemeList: function(filter, list) {
            this.reloadList(list, this.getWidgetThemeDefaultConfig());
        },

        reloadList: function(list, items) {
            if (list === null) {
                return;
            }
            list.clear();
            list.loadAll(items);
        },
            
		//endregion

	});
	return Ext.create("BPMSoft.HomePageWidgetDesignerMixin");
});
