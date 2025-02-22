﻿define("HotkeyItemsModule", ["ext-base", "BPMSoft", "sandbox"], function(Ext, BPMSoft, sandbox) {
		var hotkeyCollection = new BPMSoft.Collection();

		function init() {
			sandbox.publish("GetEventsConfig", {
				keydown: onKeydownHandler
			}, ["ViewModel_HotkeyItemsModule"]);
		}

		function onKeydownHandler(e) {
			var firedHotkeys = hotkeyCollection.filter(function(hotkey) {
				return (hotkey.keyCode === e.keyCode &&
					((hotkey.ctrl === e.ctrlKey) || (hotkey.ctrl === undefined)) &&
					((hotkey.shift === e.shiftKey) || (hotkey.shift === undefined)) &&
					((hotkey.alt === e.altKey) || (hotkey.alt === undefined)));
			});
			firedHotkeys.each(function(hotkey) {
				if (Ext.isFunction(hotkey.handler)) {
					hotkey.handler.call(hotkey.scope || hotkey, e);
				}
			});
		}

		return {
			init: init
		};
	}
);
