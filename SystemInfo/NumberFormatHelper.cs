/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 20.04.2015
 * Время: 9:52
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;

namespace SystemInfo
{
	/// <summary>
	/// Description of FormatHelper.
	/// </summary>
	public class NumberFormatHelper
	{
		private static string[] _targetName=new string[]
		{
			"TotalPhysicalMemory",
			"AdapterRAM",
			"Size"
		};
		
		public static string Format(string inputKey, string inputVal)
		{
			double result;
			if(double.TryParse(inputVal,out result)==false)
			{
				return inputVal;
			}
			
			if(!Array.Exists(_targetName,(i)=>i==inputKey))
			{
				return inputVal;
			}
			
			inputVal= inputVal + string.Format("  ({0:f2} ГБ)",result/(double)(1024*1024*1024));
			return inputVal;
		}
	}
}
