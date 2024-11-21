/**
 * ########## ###### ##### ##########. ############ ### ########## ###### # ######## #######.
 */
define("MainHeaderExtensions", ["ext-base"], function(Ext) {
	return {

		/**
		 * ############# ############## ###### ############# ##### ##########.
		 * @param {BPMSoft.BaseViewModel} viewModel
		 */
		customInitViewModel: Ext.emptyFn,

		/**
		 * ######### ######## ###### ############# ##### ##########.
		 * @param {Object} values ############ ######## ######.
		 */
		extendViewModelValues: Ext.emptyFn,

		/**
		 * ######### ###### ###### ############# ##### ##########.
		 * @param {Object} methods ############ ###### ######.
		 */
		extendViewModelMethods: Ext.emptyFn,

		/**
		 * ######### ######### ########### ########## ############.
		 * @param {BPMSoft.Container} imageContainer ######### ########### ########## ############.
		 */
		extendImageContainer: Ext.emptyFn
	};
});
