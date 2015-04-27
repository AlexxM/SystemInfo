/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 09.04.2015
 * Время: 15:06
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.DirectoryServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
namespace SystemInfo
{
	/// <summary>
	/// Description of WinComputers.
	/// </summary>
	public class WinComputers
	{
		public WinComputers()
		{
		}
		
		
		public static List<string> GetNetworkComputers()
		{
			List<string> compArr=new List<string>();
			DirectoryEntry de = new DirectoryEntry("WinNT:");
			foreach(DirectoryEntry domains in de.Children)
			{
				foreach(DirectoryEntry computers in domains.Children)
				{
					if(computers.Name!="Schema" && computers.SchemaClassName=="Computer")
						compArr.Add(computers.Name);
				}
			}
			
			return compArr;
		}
		
		public static List<string> GetOnlineComputers()
		{
			
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c net view");
              
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
 
                System.Diagnostics.Process proc = new Process();
                procStartInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
                
                proc.StartInfo = procStartInfo;
                proc.Start();
               
                string result = proc.StandardOutput.ReadToEnd();
                Regex r = new Regex(@"\\\\(\d*\w+)");
                MatchCollection mc = r.Matches(result);
                
                List<string> output = new List<string>();
                foreach(Match i in mc)
                {
                	output.Add(i.Groups[1].Value);
                }
                
                return output;
                   
		}
	}
}
