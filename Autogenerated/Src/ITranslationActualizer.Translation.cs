namespace BPMSoft.Configuration.Translation
{
	using System;
	using BPMSoft.Core.Entities;

	#region Interface: ITranslationActualizer

	public interface ITranslationActualizer
	{

		#region Events: Public

		event EventHandler<WriteLocalizableValueEventArgs> WriteLocalizableValueError;

		#endregion

		#region Methods: Public

		/// <summary>
		/// Actualizes translation.
		/// </summary>
		/// <param name="actualizeFrom">The date to start actualization from.</param>
		void ActualizeTranslation(DateTime actualizeFrom);

		/// <summary>
		/// Actualizes localizable values.
		/// </summary>
		void ActualizeLocalizableValues();

		/// <summary>
		/// Sets translation state.
		/// </summary>
		/// <param name="translation">Translation.</param>
		void SetIsTranslationChanged(Entity translation);

		#endregion

	}

	#endregion

}

