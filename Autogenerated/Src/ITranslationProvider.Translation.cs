namespace BPMSoft.Configuration.Translation
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core.Entities;

	#region Interface: ITranslationProvider

	public interface ITranslationProvider
	{

		#region Methods: Public

		/// <summary>
		/// Writes translation.
		/// </summary>
		/// <param name="key">Resource key.</param>
		/// <param name="translationColumnName">Translation column name.</param>
		/// <param name="translationColumnValue">Translation column value.</param>
		void WriteTranslation(string key, string translationColumnName, string translationColumnValue);

		/// <summary>
		/// Selects changed translation columns values.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="readMethod">Translation column value processing method.</param>
		void ReadChangedTranslationColumnsValues(Entity entity, Action<string, string, int, DateTime> readMethod);

		/// <summary>
		/// Reads changed translations.
		/// <param name="sysCulturesInfo">Entity.</param>
		/// <param name="readMethod">Entity.</param>
		/// </summary>
		void ReadChangedTranslations(List<ISysCultureInfo> sysCulturesInfo,
			Action<string, string, int, DateTime> readMethod);

		/// <summary>
		/// Resets changed translations state.
		/// <param name="sysCulturesInfo">System cultures information.</param>
		/// </summary>
		void ResetChangedTranslationsState(IEnumerable<ISysCultureInfo> sysCulturesInfo);

		/// <summary>
		/// Executes action in transaction.
		/// <param name="action">Action.</param>
		/// </summary>
		void Transaction(Action action);

		#endregion

	}

	#endregion

}

