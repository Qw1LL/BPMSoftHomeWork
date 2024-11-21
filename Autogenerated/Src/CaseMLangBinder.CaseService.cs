namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	// MOVE TO CaseService AFTER IMPLEMENTATION.

	#region Class: CaseMLangBinder

	/// <summary>
	/// Case multilanguage class binder.
	/// </summary>
	public class CaseMLangBinder: AppEventListenerBase
	{

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<ILanguageIterator, CaseLanguageIterator>("Case");
		}

		#endregion

	}

	#endregion

}
