using BPMSoft.Core;

namespace BPMSoft.Configuration
{

	#region Class: CalendarHelperEditPageScriptManager

	/// <summary>
	/// ############### ##### ######## ############## #########.
	/// ######## ## ######### ########## ########.
	/// </summary>
	public static class CalendarHelperEditPageScriptManager
	{
		#region Methods: Public

		/// <summary>
		/// ########## ########## ###### ######### ##### ### ####### ####### ###### # #########.
		/// </summary>
		/// <param name="userConnection">########### ############</param>
		/// <returns>###### #########</returns>
		public static string GetValidationFunctionScript(UserConnection userConnection) {
			string intervalFromGretherThanToMessage = LocalizableStringHelper.GetValue(userConnection,
				"CalendarHelperEditPageScriptManager", "IntervalFromGretherThanToMessage");
			string intervalsIntersectsMessage = LocalizableStringHelper.GetValue(userConnection,
				"CalendarHelperEditPageScriptManager", "IntervalsIntersectsMessage");
			string script = @"function validateWeekControls() {
				var requireControls = [PageContainer_DayTypeWeekEdit, PageContainer_WeekFrom0Edit, 
					PageContainer_WeekTo0Edit];
				var intervalControls = [
					{
						from: PageContainer_WeekFrom0Edit,
						to: PageContainer_WeekTo0Edit
					},
					{
						from: PageContainer_WeekFrom1Edit,
						to: PageContainer_WeekTo1Edit
					},
					{
						from: PageContainer_WeekFrom2Edit,
						to: PageContainer_WeekTo2Edit
					},
					{
						from: PageContainer_WeekFrom3Edit,
						to: PageContainer_WeekTo3Edit
					},
					{
						from: PageContainer_WeekFrom4Edit,
						to: PageContainer_WeekTo4Edit
					},
				]
				return validateControls(requireControls, intervalControls);
			}

			function validateCalendarControls() {
				var requireControls = [PageContainer_DayTypeCalendarEdit, PageContainer_CalendarFrom0Edit, PageContainer_CalendarTo0Edit];
				var intervalControls = [
					{
						from: PageContainer_CalendarFrom0Edit,
						to: PageContainer_CalendarTo0Edit
					},
					{
						from: PageContainer_CalendarFrom1Edit,
						to: PageContainer_CalendarTo1Edit
					},
					{
						from: PageContainer_CalendarFrom2Edit,
						to: PageContainer_CalendarTo2Edit
					},
					{
						from: PageContainer_CalendarFrom3Edit,
						to: PageContainer_CalendarTo3Edit
					},
					{
						from: PageContainer_CalendarFrom4Edit,
						to: PageContainer_CalendarTo4Edit
					},
				]
				return validateControls(requireControls, intervalControls);
			}

			function validateControls(requireControls, intervalControls) {
				return validateRequireControls(requireControls) && validateIntervalsData(intervalControls) && validateIntervalsIntersect(intervalControls);
			}

			function validateIntervalsIntersect(intervals) {
				var vmp = Ext.FormValidator.getVMP();
				if (vmp) {
					vmp.clear();
				}

				var filledIntervals = [];
				for (var i = 0, ln = intervals.length; i < ln; i++) {
					if (intervals[i].from.time.value && intervals[i].to.time.value) {
						filledIntervals.push(intervals[i]);
					}
				}

				var isOverlap = false;
				for (var i = 0, ln = filledIntervals.length; i < ln; i++) {
					var fromInterval = filledIntervals[i].from;
					var toInterval = filledIntervals[i].to;
					var fromIntervalTime = fromInterval.parseDate(fromInterval.time.value);
					var toIntervalTime = toInterval.parseDate(toInterval.time.value);

					var overlapControls = [];
					for (var j = i + 1, ln = filledIntervals.length; j < ln; j++) {
						var checkFromInterval = filledIntervals[j].from;
						var checkToInterval = filledIntervals[j].to;
						var checkFromIntervalTime = checkFromInterval.parseDate(checkFromInterval.time.value);
						var checkToIntervalTime = checkToInterval.parseDate(checkToInterval.time.value);
						var isOverlap = fromIntervalTime <= checkToIntervalTime && toIntervalTime >= checkFromIntervalTime;
						if (isOverlap) {
							overlapControls = [fromInterval, toInterval, checkFromInterval, checkToInterval];
							break;
						}
					}

					if (isOverlap) {
						for (var i = 0, ln = overlapControls.length; i < ln; i++) {
							overlapControls[i].time.wrap.addClass(overlapControls[i].time.invalidClass);
						}
						break;
					}
				}

				if (isOverlap) {
					var message = '" + intervalsIntersectsMessage + @"';
					vmp.addMessage('validation', Ext.StringList('WC.Common').getValue('FormValidator.Warning'), message, 'warning');
					delete Ext.FormValidator.invalidFieldsExist;
					return false;
				}

				delete Ext.FormValidator.invalidFieldsExist;
				return true;
			}

			function validateIntervalsData(intervals) {
				var vmp = Ext.FormValidator.getVMP();
				if (vmp) {
					vmp.clear();
				}
				var reqFields = [];
				var reqLinks = [];
				var message = '';

				for (var i = 0, ln = intervals.length; i < ln; i++) {
					var fromInterval = intervals[i].from;
					var toInterval = intervals[i].to;
					var isNotValid = fromInterval.time.value && toInterval.time.value 
						&& toInterval.parseDate(toInterval.time.value) <= fromInterval.parseDate(fromInterval.time.value);
					if (isNotValid) {
						reqFields.push('{' + fromInterval.id + '}');
						reqFields.push('{' + toInterval.id + '}');
						reqLinks.push(fromInterval.getLinkConfig());
						reqLinks.push(toInterval.getLinkConfig());
						fromInterval.time.wrap.addClass(fromInterval.time.invalidClass);
						toInterval.time.wrap.addClass(toInterval.time.invalidClass);
						break;
					} else if(fromInterval.time.wrap) {
						fromInterval.time.wrap.removeClass(fromInterval.time.invalidClass);
						toInterval.time.wrap.removeClass(toInterval.time.invalidClass);
					}
				}

				if (reqFields.length > 0) {
					var reqFieldsMsg = '" + intervalFromGretherThanToMessage + @"';
					message = Ext.Link.applyLinks(String.format(reqFieldsMsg, reqFields[0], reqFields[1]), reqLinks);
				}

				if (Ext.isEmpty(message)) {
					delete Ext.FormValidator.invalidFieldsExist;
					return true;
				}
				vmp.addMessage('validation', Ext.StringList('WC.Common').getValue('FormValidator.Warning'), message, 'warning');
				delete Ext.FormValidator.invalidFieldsExist;
				return false;
			}

			function validateRequireControls(controls) {
				var vmp = Ext.FormValidator.getVMP();
				if (vmp) {
					vmp.clear();
				}

				var reqFields = [];
				var reqLinks = [];
				var message = '';

				for (var i = 0, ln = controls.length; i < ln; i++) {
					var control = controls[i];
					if (!controls[i].validate()) {
						reqFields.push('{' + control.id + '}');
						reqLinks.push(control.getLinkConfig());
					}
				}

				if (reqFields.length > 0) {
					var reqFieldsMsg = Ext.StringList('WC.Common').getValue('FormValidator.RequiredFieldsMessage'),
						reqFieldMsg = Ext.StringList('WC.Common').getValue('FormValidator.RequiredFieldMessage');
					message = Ext.Link.applyLinks(String.format((reqFields.length == 1 ? reqFieldMsg :
						reqFieldsMsg) + '<br />', reqFields.join(', ')), reqLinks);
				}

				if (Ext.isEmpty(message)) {
					delete Ext.FormValidator.invalidFieldsExist;
					return true;
				}
				vmp.addMessage('validation', Ext.StringList('WC.Common').getValue('FormValidator.Warning'), message, 'warning');
				delete Ext.FormValidator.invalidFieldsExist;
				return false;
			};

			window.validateCalendarControls = validateCalendarControls;
			window.validateWeekControls = validateWeekControls;";
			return script;
		}

		/// <summary>
		/// ########## ########## ###### ######### ######### ######## ###### # ######## #### # #########.
		/// </summary>
		/// <returns>########## ######</returns>
		public static string GetRowChangedFunctionScript() {
			string script = @"{0}.on('activerowchanged', function(s, e) {{	
				var previousActiveRowId = this.{3}ActiveRowId;
				var primaryColumnValue = {0}.getPrimaryColumnValue();
				if (primaryColumnValue === previousActiveRowId) {{
					return;
				}}
				if (validate{3}Controls()) {{
					window.BPMSoft.AjaxMethods.ThrowClientEventWithMask('{1}', '{2}');
					this.{3}ActiveRowId = primaryColumnValue;
				}} else if (previousActiveRowId) {{
					{4}.selectNodeById(previousActiveRowId, false);
					{0}.setActiveRow(previousActiveRowId, false);
				}}
			}}, this);";

			return script;
		}

		#endregion
	}

	#endregion
}

