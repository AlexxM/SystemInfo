/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 21.04.2015
 * Время: 15:49
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;

namespace SystemInfo
{
	/// <summary>
	/// Description of SearchingCriteria.
	/// </summary>
	public class SearchingCriteria
	{

			public string nameElement;
			public string value;
			public SearchingType searchingType;
	}
	
	public enum SearchingType
	{
		Contains,
		Lt,
		Gt
	}
}
